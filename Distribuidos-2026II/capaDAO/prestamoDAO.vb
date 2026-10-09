Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class prestamoDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    Public Function buscarLectores(texto As String) As List(Of Usuario)
        Dim lista As New List(Of Usuario)()
        Dim sql = "SELECT u.id_usuario, u.nombre_usuario, u.ap_paterno, u.ap_materno, " &
            "u.numero_dni_usuario, u.email_usuario, u.estado_usuario, u.id_rol_usuario, r.nombre_rol_usuario " &
            "FROM Usuario u INNER JOIN RolUsuario r ON r.id_rol_usuario = u.id_rol_usuario " &
            "WHERE UPPER(LTRIM(RTRIM(u.estado_usuario))) = 'ACTIVO' " &
            "AND UPPER(LTRIM(RTRIM(r.nombre_rol_usuario))) = 'ESTUDIANTE' " &
            "AND (u.nombre_usuario + ' ' + u.ap_paterno + ' ' + u.ap_materno LIKE @texto " &
            "OR u.numero_dni_usuario LIKE @texto OR u.email_usuario LIKE @texto) " &
            "ORDER BY u.ap_paterno, u.ap_materno, u.nombre_usuario"
        Using cn = con.CrearConexionIndependiente(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@texto", SqlDbType.VarChar, -1).Value = PatronBusqueda(texto)
            Using rs = cmd.ExecuteReader()
                While rs.Read()
                    lista.Add(New Usuario With {
                        .IdUsuario = CInt(rs("id_usuario")), .NombreUsuario = CStr(rs("nombre_usuario")),
                        .ApPaterno = CStr(rs("ap_paterno")), .ApMaterno = CStr(rs("ap_materno")),
                        .NumeroDniUsuario = CStr(rs("numero_dni_usuario")), .EmailUsuario = CStr(rs("email_usuario")),
                        .EstadoUsuario = CStr(rs("estado_usuario")), .IdRolUsuario = CInt(rs("id_rol_usuario")),
                        .NombreRol = CStr(rs("nombre_rol_usuario"))})
                End While
            End Using
        End Using
        Return lista
    End Function

    Public Function listar(filtro As String, texto As String, hoy As Date, Optional idLector As Integer = 0) As List(Of Prestamo)
        Dim lista As New List(Of Prestamo)()
        Dim sql = "SELECT p.*, u.nombre_usuario + ' ' + u.ap_paterno + ' ' + u.ap_materno AS lector, " &
            "u.numero_dni_usuario, u.email_usuario, b.nombre_usuario + ' ' + b.ap_paterno + ' ' + b.ap_materno AS bibliotecario, " &
            "e.id_libro, l.titulo_libro FROM Prestamo p " &
            "INNER JOIN Usuario u ON u.id_usuario = p.id_usuario " &
            "INNER JOIN Usuario b ON b.id_usuario = p.id_bibliotecario " &
            "INNER JOIN Ejemplar e ON e.id_ejemplar = p.id_ejemplar " &
            "INNER JOIN Libro l ON l.id_libro = e.id_libro " &
            "WHERE (@filtro = 'Todos' " &
            "OR (@filtro = 'Activos' AND UPPER(LTRIM(RTRIM(p.estado_prestamo))) = 'ACTIVO' AND p.fecha_retorno_prestamo IS NULL) " &
            "OR (@filtro = 'Vencidos' AND UPPER(LTRIM(RTRIM(p.estado_prestamo))) = 'ACTIVO' AND p.fecha_retorno_prestamo IS NULL AND p.fecha_fin_prestamo < @hoy) " &
            "OR (@filtro = 'Devueltos' AND UPPER(LTRIM(RTRIM(p.estado_prestamo))) = 'DEVUELTO' AND p.fecha_retorno_prestamo IS NOT NULL)) " &
            "AND (u.nombre_usuario + ' ' + u.ap_paterno + ' ' + u.ap_materno LIKE @texto " &
            "OR u.numero_dni_usuario LIKE @texto OR u.email_usuario LIKE @texto OR l.titulo_libro LIKE @texto " &
            "OR CONVERT(varchar(12), p.id_prestamo) LIKE @texto OR CONVERT(varchar(12), p.id_ejemplar) LIKE @texto) " &
            "AND (@lector = 0 OR p.id_usuario = @lector) ORDER BY p.id_prestamo DESC"
        Using cn = con.CrearConexionIndependiente(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@filtro", SqlDbType.VarChar, 20).Value = filtro
            cmd.Parameters.Add("@texto", SqlDbType.VarChar, -1).Value = PatronBusqueda(texto)
            cmd.Parameters.Add("@hoy", SqlDbType.Date).Value = hoy.Date
            cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
            Using rs = cmd.ExecuteReader()
                While rs.Read()
                    lista.Add(New Prestamo With {
                        .IdPrestamo = CInt(rs("id_prestamo")), .FechaInicio = CDate(rs("fecha_inicio_prestamo")),
                        .FechaFin = CDate(rs("fecha_fin_prestamo")),
                        .FechaRetorno = If(IsDBNull(rs("fecha_retorno_prestamo")), CType(Nothing, Date?), CDate(rs("fecha_retorno_prestamo"))),
                        .EstadoPrestamo = CStr(rs("estado_prestamo")),
                        .DiasRetraso = If(IsDBNull(rs("dias_retraso_prestamo")), 0, CInt(rs("dias_retraso_prestamo"))),
                        .IdUsuario = CInt(rs("id_usuario")), .IdBibliotecario = CInt(rs("id_bibliotecario")),
                        .IdEjemplar = CInt(rs("id_ejemplar")), .NombreLector = CStr(rs("lector")),
                        .DniLector = CStr(rs("numero_dni_usuario")), .CorreoLector = CStr(rs("email_usuario")),
                        .NombreBibliotecario = CStr(rs("bibliotecario")), .IdLibro = CInt(rs("id_libro")),
                        .TituloLibro = CStr(rs("titulo_libro"))})
                End While
            End Using
        End Using
        Return lista
    End Function

    Public Function registrar(idLector As Integer, idBibliotecario As Integer, idEjemplar As Integer,
                              inicio As Date, limite As Date) As Integer
        If inicio.Date > Date.Today OrElse limite.Date <= inicio.Date Then
            Throw New ArgumentException("Fechas inválidas: el inicio no puede ser futuro y el límite debe ser posterior al inicio.")
        End If
        If limite.Date <> PoliticaPrestamo.FechaLimite(inicio) Then Throw New ArgumentException("El préstamo debe durar exactamente cinco días.")
        Using cn = con.CrearConexionIndependiente()
            EsquemaPago.ExigirColumna(cn)
            ' Solo localizar el libro; se revalida la relación bajo bloqueo antes de insertar.
            Dim idLibro As Integer
            Using cmd As New SqlCommand("SELECT id_libro FROM Ejemplar WHERE id_ejemplar = @id", cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEjemplar
                Dim valor = cmd.ExecuteScalar()
                If valor Is Nothing Then Throw New InvalidOperationException("El ejemplar ya no existe.")
                idLibro = CInt(valor)
            End Using
            Using tx = cn.BeginTransaction(IsolationLevel.Serializable)
                ' Serializar primero al lector: dos copias distintas tampoco pueden prestarse a la misma persona.
                ValidarUsuario(cn, tx, idLector, "ESTUDIANTE", "El lector debe ser un estudiante activo.", True)
                ' Después, libro, ejemplar y préstamos como en los mantenimientos.
                Using cmd As New SqlCommand("SELECT estado_libro FROM Libro WITH (UPDLOCK, HOLDLOCK) WHERE id_libro = @id", cn, tx)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idLibro
                    Dim valor = cmd.ExecuteScalar()
                    If valor Is Nothing OrElse Not CBool(valor) Then Throw New InvalidOperationException("El libro no existe o está inactivo.")
                End Using
                Using cmd As New SqlCommand("SELECT estado_ejemplar FROM Ejemplar WITH (UPDLOCK, HOLDLOCK) " &
                                             "WHERE id_ejemplar = @id AND id_libro = @libro", cn, tx)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEjemplar
                    cmd.Parameters.Add("@libro", SqlDbType.Int).Value = idLibro
                    Dim valor = cmd.ExecuteScalar()
                    If valor Is Nothing OrElse Not CBool(valor) Then Throw New InvalidOperationException("El ejemplar no existe o está inactivo.")
                End Using
                ValidarUsuario(cn, tx, idBibliotecario, "BIBLIOTECARIO", "La cuenta que registra la operación debe ser un bibliotecario activo.")
                Using cmd As New SqlCommand("SELECT COUNT(1) FROM Prestamo p WITH (HOLDLOCK) " &
                                             "WHERE p.id_usuario = @lector AND " & ejemplarDAO.PrestamoOcupaEjemplarSql, cn, tx)
                    cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                    If CInt(cmd.ExecuteScalar()) >= PoliticaPrestamo.MaximoEjemplares Then
                        Throw New InvalidOperationException("El lector ya tiene un ejemplar sin devolver. El máximo es uno, incluido cualquier préstamo vencido o por revisar.")
                    End If
                End Using
                ' El pago pertenece a la penalización aplicada; la habilitación del catálogo no interviene.
                Using cmd As New SqlCommand("SELECT dp.estado_pago_detalle FROM DetallePenalizacion dp WITH (HOLDLOCK) " &
                                             "INNER JOIN Prestamo p WITH (HOLDLOCK) ON p.id_prestamo = dp.id_prestamo " &
                                             "WHERE p.id_usuario = @lector AND dp.estado_pago_detalle <> @pagada", cn, tx)
                    cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                    cmd.Parameters.Add("@pagada", SqlDbType.VarChar, 12).Value = DetallePenalizacion.PagoPagada
                    Using rs = cmd.ExecuteReader()
                        If rs.Read() Then
                            If rs.GetString(0) = DetallePenalizacion.PagoPendiente Then
                                Throw New InvalidOperationException("El lector tiene una penalización pendiente de pago. Debe regularizarla antes de recibir otro préstamo.")
                            End If
                            Throw New InvalidOperationException("El lector tiene una penalización con pago por revisar. Confirma su estado de pago antes de registrar otro préstamo.")
                        End If
                    End Using
                End Using
                ' El bloqueo de la copia dura hasta COMMIT. La consulta e INSERT son indivisibles.
                Using cmd As New SqlCommand("SELECT COUNT(1) FROM Prestamo p WITH (UPDLOCK, HOLDLOCK) " &
                                             "WHERE p.id_ejemplar = @id AND " & ejemplarDAO.PrestamoOcupaEjemplarSql, cn, tx)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEjemplar
                    If CInt(cmd.ExecuteScalar()) > 0 Then Throw New InvalidOperationException("El ejemplar ya tiene un préstamo sin cerrar. Actualiza la disponibilidad.")
                End Using
                Dim sql = "INSERT INTO Prestamo (fecha_inicio_prestamo, fecha_fin_prestamo, fecha_retorno_prestamo, " &
                    "estado_prestamo, dias_retraso_prestamo, id_usuario, id_bibliotecario, id_ejemplar) " &
                    "OUTPUT INSERTED.id_prestamo VALUES (@inicio, @limite, NULL, @estado, 0, @lector, @bibliotecario, @ejemplar)"
                Dim id As Integer
                Using cmd As New SqlCommand(sql, cn, tx)
                    cmd.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio.Date
                    cmd.Parameters.Add("@limite", SqlDbType.Date).Value = limite.Date
                    cmd.Parameters.Add("@estado", SqlDbType.VarChar, 30).Value = Prestamo.EstadoActivo
                    cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                    cmd.Parameters.Add("@bibliotecario", SqlDbType.Int).Value = idBibliotecario
                    cmd.Parameters.Add("@ejemplar", SqlDbType.Int).Value = idEjemplar
                    id = CInt(cmd.ExecuteScalar())
                End Using
                tx.Commit()
                Return id
                ' Dispose revierte la transacción ante cualquier excepción.
            End Using
        End Using
    End Function

    Public Function devolver(idPrestamo As Integer, idBibliotecario As Integer, retorno As Date) As Integer
        If retorno.Date > Date.Today Then Throw New ArgumentException("La devolución no puede tener una fecha futura.")
        Using cn = con.CrearConexionIndependiente()
            Dim idEjemplar As Integer
            Using cmd As New SqlCommand("SELECT id_ejemplar FROM Prestamo WHERE id_prestamo = @id", cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPrestamo
                Dim valor = cmd.ExecuteScalar()
                If valor Is Nothing Then Throw New InvalidOperationException("No se encontró el préstamo.")
                idEjemplar = CInt(valor)
            End Using
            Using tx = cn.BeginTransaction(IsolationLevel.Serializable)
                Using cmd As New SqlCommand("SELECT id_ejemplar FROM Ejemplar WITH (UPDLOCK, HOLDLOCK) WHERE id_ejemplar = @id", cn, tx)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEjemplar
                    If cmd.ExecuteScalar() Is Nothing Then Throw New InvalidOperationException("No se encontró el ejemplar.")
                End Using
                ValidarUsuario(cn, tx, idBibliotecario, "BIBLIOTECARIO", "La cuenta que registra la devolución debe ser un bibliotecario activo.")
                Dim inicio, limite As Date
                Using cmd As New SqlCommand("SELECT fecha_inicio_prestamo, fecha_fin_prestamo, fecha_retorno_prestamo, estado_prestamo " &
                                             "FROM Prestamo WITH (UPDLOCK, HOLDLOCK) WHERE id_prestamo = @id AND id_ejemplar = @ejemplar", cn, tx)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPrestamo
                    cmd.Parameters.Add("@ejemplar", SqlDbType.Int).Value = idEjemplar
                    Using rs = cmd.ExecuteReader()
                        If Not rs.Read() Then Throw New InvalidOperationException("No se encontró el préstamo.")
                        If Not IsDBNull(rs("fecha_retorno_prestamo")) OrElse
                            String.Equals(CStr(rs("estado_prestamo")).Trim(), Prestamo.EstadoDevuelto, StringComparison.OrdinalIgnoreCase) Then
                            Throw New InvalidOperationException("Este préstamo ya fue devuelto.")
                        End If
                        If Not String.Equals(CStr(rs("estado_prestamo")).Trim(), Prestamo.EstadoActivo, StringComparison.OrdinalIgnoreCase) Then
                            Throw New InvalidOperationException("El préstamo tiene un estado no reconocido. Revisa el registro antes de devolverlo.")
                        End If
                        inicio = CDate(rs("fecha_inicio_prestamo"))
                        limite = CDate(rs("fecha_fin_prestamo"))
                    End Using
                End Using
                If retorno.Date < inicio.Date Then Throw New ArgumentException("La devolución no puede ser anterior al inicio.")
                Dim dias = Math.Max(0, (retorno.Date - limite.Date).Days)
                Using cmd As New SqlCommand("UPDATE Prestamo SET fecha_retorno_prestamo = @retorno, " &
                                             "estado_prestamo = @devuelto, dias_retraso_prestamo = @dias " &
                                             "WHERE id_prestamo = @id AND fecha_retorno_prestamo IS NULL " &
                                             "AND UPPER(LTRIM(RTRIM(estado_prestamo))) = 'ACTIVO'", cn, tx)
                    cmd.Parameters.Add("@retorno", SqlDbType.Date).Value = retorno.Date
                    cmd.Parameters.Add("@devuelto", SqlDbType.VarChar, 30).Value = Prestamo.EstadoDevuelto
                    cmd.Parameters.Add("@dias", SqlDbType.Int).Value = dias
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPrestamo
                    If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException("El préstamo ya fue devuelto o cambió durante la operación.")
                End Using
                tx.Commit()
                Return dias
            End Using
        End Using
    End Function

    Private Shared Sub ValidarUsuario(cn As SqlConnection, tx As SqlTransaction, id As Integer, rol As String, mensaje As String, Optional bloquearLector As Boolean = False)
        Dim sql = "SELECT COUNT(1) FROM Usuario u WITH (" & If(bloquearLector, "UPDLOCK, HOLDLOCK", "HOLDLOCK") & ") " &
            "INNER JOIN RolUsuario r WITH (HOLDLOCK) ON r.id_rol_usuario = u.id_rol_usuario " &
            "WHERE u.id_usuario = @id AND UPPER(LTRIM(RTRIM(u.estado_usuario))) = 'ACTIVO' " &
            "AND UPPER(LTRIM(RTRIM(r.nombre_rol_usuario))) = @rol"
        Using cmd As New SqlCommand(sql, cn, tx)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
            cmd.Parameters.Add("@rol", SqlDbType.VarChar, 50).Value = rol
            If CInt(cmd.ExecuteScalar()) <> 1 Then Throw New InvalidOperationException(mensaje)
        End Using
    End Sub

    Private Shared Function PatronBusqueda(texto As String) As String
        Return "%" & If(texto, "").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") & "%"
    End Function
End Class
