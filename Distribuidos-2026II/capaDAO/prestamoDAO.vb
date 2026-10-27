Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class prestamoDAO

    Public Function buscarLectores(texto As String) As List(Of Usuario)
        Try
            Dim lista As New List(Of Usuario)()
            Dim query As String = "SELECT u.id_usuario, u.nombre_usuario, u.ap_paterno, u.ap_materno, " &
                "u.numero_dni_usuario, u.email_usuario, u.estado_usuario, u.id_rol_usuario, r.nombre_rol_usuario " &
                "FROM Usuario u INNER JOIN RolUsuario r ON r.id_rol_usuario = u.id_rol_usuario " &
                "WHERE UPPER(LTRIM(RTRIM(u.estado_usuario))) = 'ACTIVO' " &
                "AND UPPER(LTRIM(RTRIM(r.nombre_rol_usuario))) IN ('ESTUDIANTE','LECTOR') " &
                "AND (u.nombre_usuario + ' ' + u.ap_paterno + ' ' + u.ap_materno LIKE @texto " &
                "OR u.numero_dni_usuario LIKE @texto OR u.email_usuario LIKE @texto) " &
                "ORDER BY u.ap_paterno, u.ap_materno, u.nombre_usuario"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@texto", SqlDbType.VarChar, -1).Value = PatronBusqueda(texto)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Usuario With {
                                .IdUsuario = CInt(dr("id_usuario")), .NombreUsuario = CStr(dr("nombre_usuario")),
                                .ApPaterno = CStr(dr("ap_paterno")), .ApMaterno = CStr(dr("ap_materno")),
                                .NumeroDniUsuario = CStr(dr("numero_dni_usuario")), .EmailUsuario = CStr(dr("email_usuario")),
                                .EstadoUsuario = CStr(dr("estado_usuario")), .IdRolUsuario = CInt(dr("id_rol_usuario")),
                                .NombreRol = CStr(dr("nombre_rol_usuario"))})
                        End While
                    End Using
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "prestamoDAO.buscarLectores")
        End Try
    End Function

    Public Function listar(filtro As String, texto As String, hoy As Date, Optional idLector As Integer = 0, Optional idPrestamo As Integer = 0) As List(Of Prestamo)
        Try
            Dim lista As New List(Of Prestamo)()
            Dim query As String = "SELECT p.*, u.nombre_usuario + ' ' + u.ap_paterno + ' ' + u.ap_materno AS lector, " &
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
                "AND (@lector = 0 OR p.id_usuario = @lector) AND (@prestamo=0 OR p.id_prestamo=@prestamo) ORDER BY p.id_prestamo DESC"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@filtro", SqlDbType.VarChar, 20).Value = filtro
                    cmd.Parameters.Add("@texto", SqlDbType.VarChar, -1).Value = PatronBusqueda(texto)
                    cmd.Parameters.Add("@hoy", SqlDbType.Date).Value = hoy.Date
                    cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                    cmd.Parameters.Add("@prestamo", SqlDbType.Int).Value = idPrestamo
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Prestamo With {
                                .IdPrestamo = CInt(dr("id_prestamo")), .FechaInicio = CDate(dr("fecha_inicio_prestamo")),
                                .FechaFin = CDate(dr("fecha_fin_prestamo")),
                                .FechaRetorno = If(IsDBNull(dr("fecha_retorno_prestamo")), CType(Nothing, Date?), CDate(dr("fecha_retorno_prestamo"))),
                                .EstadoPrestamo = CStr(dr("estado_prestamo")),
                                .DiasRetraso = If(IsDBNull(dr("dias_retraso_prestamo")), 0, CInt(dr("dias_retraso_prestamo"))),
                                .IdUsuario = CInt(dr("id_usuario")), .IdBibliotecario = CInt(dr("id_bibliotecario")),
                                .IdEjemplar = CInt(dr("id_ejemplar")), .NombreLector = CStr(dr("lector")),
                                .DniLector = CStr(dr("numero_dni_usuario")), .CorreoLector = CStr(dr("email_usuario")),
                                .NombreBibliotecario = CStr(dr("bibliotecario")), .IdLibro = CInt(dr("id_libro")),
                                .TituloLibro = CStr(dr("titulo_libro"))})
                        End While
                    End Using
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "prestamoDAO.listar")
        End Try
    End Function

    Public Function registrar(idLector As Integer, idBibliotecario As Integer, idEjemplar As Integer,
                              inicio As Date, limite As Date, reglas As IReglasCirculacion) As Integer
        Try
            Dim query As String
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                EsquemaPago.ExigirColumna(cn)
                DisponibilidadReserva.ExigirEsquema(cn)
                ' Solo localizar el libro; se revalida la relación bajo bloqueo antes de insertar.
                Dim idLibro As Integer
                query = "SELECT id_libro FROM Ejemplar WHERE id_ejemplar = @id"
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEjemplar
                    Dim valor = cmd.ExecuteScalar()
                    If valor Is Nothing Then Throw New InvalidOperationException("El ejemplar ya no existe.")
                    idLibro = CInt(valor)
                End Using
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    ' Bloquear al lector y comprobar el total antes de asignar otra copia.
                    reglas.ValidarLector(DisponibilidadReserva.LeerLector(cn, tx, idLector), 1)
                    ' Después, libro, ejemplar y préstamos como en los mantenimientos.
                    query = "SELECT estado_libro FROM Libro WITH (UPDLOCK, HOLDLOCK) WHERE id_libro = @id"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idLibro
                        Dim valor = cmd.ExecuteScalar()
                        reglas.ValidarLibro(If(valor Is Nothing, CType(Nothing, Boolean?), CBool(valor)))
                    End Using
                    query = "SELECT estado_ejemplar FROM Ejemplar WITH (UPDLOCK, HOLDLOCK) " &
                                                 "WHERE id_ejemplar = @id AND id_libro = @libro"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEjemplar
                        cmd.Parameters.Add("@libro", SqlDbType.Int).Value = idLibro
                        Dim valor = cmd.ExecuteScalar()
                        reglas.ValidarEjemplar(If(valor Is Nothing, CType(Nothing, Boolean?), CBool(valor)), 0)
                    End Using
                    reglas.ValidarUsuario(DisponibilidadReserva.LeerUsuario(cn, tx, idBibliotecario), "BIBLIOTECARIO", "La cuenta que registra la operación debe ser un bibliotecario activo.")
                    ' El bloqueo de la copia dura hasta COMMIT. La consulta e INSERT son indivisibles.
                    query = "SELECT COUNT(1) FROM Prestamo p WITH (UPDLOCK, HOLDLOCK) " &
                                                 "WHERE p.id_ejemplar = @id AND " & ejemplarDAO.PrestamoOcupaEjemplarSql
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEjemplar
                        reglas.ValidarEjemplar(True, CInt(cmd.ExecuteScalar()))
                    End Using
                    query = "SELECT COUNT(*) FROM SolicitudPrestamo s WITH (UPDLOCK,HOLDLOCK) WHERE s.id_usuario=@lector AND " & DisponibilidadReserva.VigenteSql
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                        reglas.ValidarVentanilla(CInt(cmd.ExecuteScalar()), DisponibilidadReserva.Capacidad(cn, tx, idLibro))
                    End Using
                    query = "INSERT INTO Prestamo (fecha_inicio_prestamo, fecha_fin_prestamo, fecha_retorno_prestamo, " &
                        "estado_prestamo, dias_retraso_prestamo, id_usuario, id_bibliotecario, id_ejemplar) " &
                        "OUTPUT INSERTED.id_prestamo VALUES (@inicio, @limite, NULL, @estado, 0, @lector, @bibliotecario, @ejemplar)"
                    Dim id As Integer
                    Using cmd As New SqlCommand(query, cn, tx)
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
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "prestamoDAO.registrar")
        End Try
    End Function

    Public Function PrevisualizarDevolucion(idPrestamo As Integer, retorno As Date, reglas As IReglasCirculacion) As DevolucionCalculada
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    Dim calculo = reglas.CalcularDevolucion(MoraDAO.LeerDevolucion(cn, tx, idPrestamo, retorno, False))
                    tx.Commit()
                    Return calculo
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "prestamoDAO.PrevisualizarDevolucion")
        End Try
    End Function

    Public Function DevolverConfirmado(idPrestamo As Integer, idBibliotecario As Integer, retorno As Date, confirmado As DevolucionCalculada, reglas As IReglasCirculacion) As DevolucionCalculada
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim idEjemplar As Integer
                Dim query As String = "SELECT id_ejemplar FROM Prestamo WHERE id_prestamo=@id"
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPrestamo
                    Dim valor = cmd.ExecuteScalar()
                    If valor Is Nothing Then Throw New InvalidOperationException("No se encontró el préstamo.")
                    idEjemplar = CInt(valor)
                End Using
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    query = "SELECT id_ejemplar FROM Ejemplar WITH (UPDLOCK,HOLDLOCK) WHERE id_ejemplar=@id"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEjemplar
                        If cmd.ExecuteScalar() Is Nothing Then Throw New InvalidOperationException("No se encontró el ejemplar.")
                    End Using
                    reglas.ValidarUsuario(DisponibilidadReserva.LeerUsuario(cn, tx, idBibliotecario), "BIBLIOTECARIO", "La cuenta que registra la devolución debe ser un bibliotecario activo.")
                    Dim calculo = reglas.CalcularDevolucion(MoraDAO.LeerDevolucion(cn, tx, idPrestamo, retorno, True))
                    reglas.ValidarConfirmacion(calculo, confirmado)
                    query = "UPDATE Prestamo SET fecha_retorno_prestamo=@retorno,estado_prestamo=@devuelto,dias_retraso_prestamo=@dias WHERE id_prestamo=@id AND id_ejemplar=@ejemplar AND fecha_retorno_prestamo IS NULL AND UPPER(LTRIM(RTRIM(estado_prestamo)))='ACTIVO'"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@retorno", SqlDbType.Date).Value = retorno.Date
                        cmd.Parameters.Add("@devuelto", SqlDbType.VarChar, 30).Value = Prestamo.EstadoDevuelto
                        cmd.Parameters.Add("@dias", SqlDbType.Int).Value = calculo.DiasRetraso
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPrestamo
                        cmd.Parameters.Add("@ejemplar", SqlDbType.Int).Value = idEjemplar
                        If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException("El préstamo ya fue devuelto o cambió durante la operación.")
                    End Using
                    If calculo.RegistrarCargo Then MoraDAO.Registrar(cn, tx, calculo)
                    tx.Commit()
                    Return calculo
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "prestamoDAO.DevolverConfirmado")
        End Try
    End Function

    Friend Shared Function InsertarPrestamo(cn As SqlConnection, tx As SqlTransaction, lector As Integer, operador As Integer, ejemplar As Integer, inicio As Date, limite As Date) As Integer
        Try
            Dim query As String = "INSERT INTO Prestamo(fecha_inicio_prestamo,fecha_fin_prestamo,fecha_retorno_prestamo,estado_prestamo,dias_retraso_prestamo,id_usuario,id_bibliotecario,id_ejemplar) OUTPUT INSERTED.id_prestamo VALUES(@inicio,@limite,NULL,'Activo',0,@lector,@operador,@ejemplar)"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio
                cmd.Parameters.Add("@limite", SqlDbType.Date).Value = limite
                cmd.Parameters.Add("@lector", SqlDbType.Int).Value = lector
                cmd.Parameters.Add("@operador", SqlDbType.Int).Value = operador
                cmd.Parameters.Add("@ejemplar", SqlDbType.Int).Value = ejemplar
                Return CInt(cmd.ExecuteScalar())
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "prestamoDAO.InsertarPrestamo")
        End Try
    End Function

    Private Shared Function PatronBusqueda(texto As String) As String
        Return "%" & If(texto, "").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") & "%"
    End Function
End Class
