Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos
Imports System.Linq

Public Class prestamoDAO

    Public Function buscarLectores(texto As String) As List(Of Usuario)
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim lista As New List(Of Usuario)()
            Dim query As String = "SELECT u.id_usuario, u.nombre_usuario, u.ap_paterno, u.ap_materno, " &
                "u.numero_dni_usuario, u.email_usuario, u.estado_usuario, u.id_rol_usuario, r.nombre_rol_usuario " &
                "FROM Usuario u INNER JOIN RolUsuario r ON r.id_rol_usuario = u.id_rol_usuario " &
                "WHERE UPPER(LTRIM(RTRIM(u.estado_usuario))) = 'ACTIVO' " &
                "AND UPPER(LTRIM(RTRIM(r.nombre_rol_usuario))) IN ('ESTUDIANTE','LECTOR') " &
                "AND (CONCAT(u.nombre_usuario,' ',u.ap_paterno,' ',u.ap_materno) LIKE @texto " &
                "OR u.numero_dni_usuario LIKE @texto OR u.email_usuario LIKE @texto) " &
                "ORDER BY u.ap_paterno, u.ap_materno, u.nombre_usuario"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@texto", SqlDbType.VarChar, -1).Value = LecturaDAO.PatronContiene(texto)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Usuario With {
                                .IdUsuario = CInt(dr("id_usuario")), .NombreUsuario = CStr(dr("nombre_usuario")),
                                .ApPaterno = CStr(dr("ap_paterno")), .ApMaterno = Convert.ToString(dr("ap_materno")),
                                .NumeroDniUsuario = CStr(dr("numero_dni_usuario")), .EmailUsuario = CStr(dr("email_usuario")),
                                .EstadoUsuario = CStr(dr("estado_usuario")), .IdRolUsuario = CInt(dr("id_rol_usuario")),
                                .NombreRol = CStr(dr("nombre_rol_usuario"))})
                        End While
                    End Using
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Prestamo", "BUSQUEDA", "Buscar lectores activos")
            Return lista
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "prestamoDAO.buscarLectores")
        End Try
    End Function

    Public Function listar(filtro As String, texto As String, hoy As Date, Optional idLector As Integer = 0, Optional idPrestamo As Integer = 0, Optional agrupar As Boolean = True) As List(Of Prestamo)
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim lista As New List(Of Prestamo)()
            Dim query As String = "SELECT p.id_prestamo,p.id_operacion,p.fecha_inicio_prestamo,p.fecha_fin_prestamo,p.fecha_retorno_prestamo,p.estado_prestamo,p.dias_retraso_prestamo,p.id_usuario,p.id_bibliotecario,p.id_ejemplar, CONCAT(u.nombre_usuario,' ',u.ap_paterno,' ',u.ap_materno) AS lector, " &
                "u.numero_dni_usuario, u.email_usuario, CONCAT(b.nombre_usuario,' ',b.ap_paterno,' ',b.ap_materno) AS bibliotecario, " &
                "e.id_libro, l.titulo_libro FROM Prestamo p " &
                "INNER JOIN Usuario u ON u.id_usuario = p.id_usuario " &
                "INNER JOIN Usuario b ON b.id_usuario = p.id_bibliotecario " &
                "INNER JOIN Ejemplar e ON e.id_ejemplar = p.id_ejemplar " &
                "INNER JOIN Libro l ON l.id_libro = e.id_libro " &
                "WHERE (@filtro = 'Todos' " &
                "OR (@filtro = 'Activos' AND UPPER(LTRIM(RTRIM(p.estado_prestamo))) = 'ACTIVO' AND p.fecha_retorno_prestamo IS NULL) " &
                "OR (@filtro = 'Vencidos' AND UPPER(LTRIM(RTRIM(p.estado_prestamo))) = 'ACTIVO' AND p.fecha_retorno_prestamo IS NULL AND p.fecha_fin_prestamo < @hoy) " &
                "OR (@filtro = 'Devueltos' AND UPPER(LTRIM(RTRIM(p.estado_prestamo))) = 'DEVUELTO' AND p.fecha_retorno_prestamo IS NOT NULL)) " &
                "AND (CONCAT(u.nombre_usuario,' ',u.ap_paterno,' ',u.ap_materno) LIKE @texto " &
                "OR u.numero_dni_usuario LIKE @texto OR u.email_usuario LIKE @texto OR l.titulo_libro LIKE @texto " &
                "OR CONVERT(varchar(12), p.id_prestamo) LIKE @texto OR CONVERT(varchar(12), p.id_ejemplar) LIKE @texto) " &
                "AND (@lector = 0 OR p.id_usuario = @lector) AND (@prestamo=0 OR p.id_prestamo=@prestamo OR p.id_operacion=(SELECT id_operacion FROM Prestamo WHERE id_prestamo=@prestamo)) ORDER BY p.id_prestamo DESC"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@filtro", SqlDbType.VarChar, 20).Value = filtro
                    cmd.Parameters.Add("@texto", SqlDbType.VarChar, -1).Value = LecturaDAO.PatronContiene(texto)
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
                                .IdEjemplar = CInt(dr("id_ejemplar")),
                                .IdOperacion = If(IsDBNull(dr("id_operacion")), CType(Nothing, Guid?), CType(dr("id_operacion"), Guid)),
                                .NombreLector = CStr(dr("lector")),
                                .DniLector = CStr(dr("numero_dni_usuario")), .CorreoLector = CStr(dr("email_usuario")),
                                .NombreBibliotecario = CStr(dr("bibliotecario")), .IdLibro = CInt(dr("id_libro")),
                                .TituloLibro = CStr(dr("titulo_libro"))})
                        End While
                    End Using
                End Using
            End Using
            If agrupar Then lista = AgruparFilas(lista)
            AuditoriaDAO.RegistrarEvento(actor, "Prestamo", If(idLector > 0 OrElse idPrestamo > 0, "SELECT", "LISTADO"), $"Consultar préstamos | lector={idLector}; préstamo={idPrestamo}")
            Return lista
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "prestamoDAO.listar")
        End Try
    End Function

    Private Shared Function AgruparFilas(filas As List(Of Prestamo)) As List(Of Prestamo)
        Return filas.GroupBy(Function(p) If(p.IdOperacion.HasValue, p.IdOperacion.Value.ToString("N"), "anterior:" & p.IdPrestamo.ToString())).
            Select(Function(grupo)
                       Dim ordenadas = grupo.OrderBy(Function(p) p.IdPrestamo).ToList()
                       Dim principal = ordenadas(0)
                       principal.CantidadEjemplares = ordenadas.Count
                       principal.IdsPrestamos = ordenadas.Select(Function(p) p.IdPrestamo).ToList()
                       principal.TituloLibro = String.Join("; ", ordenadas.Select(Function(p) p.TituloLibro))
                       principal.Ejemplares = String.Join(", ", ordenadas.Select(Function(p) p.IdEjemplar.ToString()))
                       Return principal
                   End Function).OrderByDescending(Function(p) p.IdPrestamo).ToList()
    End Function

    Public Function registrar(idLector As Integer, idBibliotecario As Integer, idsEjemplares As IList(Of Integer),
                              inicio As Date, limite As Date, reglas As IReglasCirculacion) As Integer
        Try
            Dim query As String
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                EsquemaPago.ExigirColumna(cn)
                DisponibilidadReserva.ExigirEsquema(cn)
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    ' Bloquear al lector y comprobar el total antes de asignar otra copia.
                    reglas.ValidarLector(DisponibilidadReserva.LeerLector(cn, tx, idLector), idsEjemplares.Count)
                    reglas.ValidarUsuario(DisponibilidadReserva.LeerUsuario(cn, tx, idBibliotecario), "BIBLIOTECARIO", "La cuenta que registra la operación debe ser un bibliotecario activo.")
                    Dim solicitudesVigentes As Integer
                    query = "SELECT COUNT(*) FROM SolicitudPrestamo s WITH (UPDLOCK,HOLDLOCK) WHERE s.id_usuario=@lector AND " & DisponibilidadReserva.VigenteSql
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                        solicitudesVigentes = CInt(cmd.ExecuteScalar())
                    End Using
                    Dim operacion = Guid.NewGuid()
                    Dim titulos As New HashSet(Of Integer)()
                    Dim id As Integer = 0
                    For Each idEjemplar In idsEjemplares.OrderBy(Function(x) x)
                        query = "SELECT e.id_libro,e.estado_ejemplar,l.estado_libro FROM Ejemplar e WITH (UPDLOCK,HOLDLOCK) JOIN Libro l WITH (UPDLOCK,HOLDLOCK) ON l.id_libro=e.id_libro WHERE e.id_ejemplar=@id"
                        Dim idLibro As Integer
                        Using cmd As New SqlCommand(query, cn, tx)
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEjemplar
                            Using dr = cmd.ExecuteReader()
                                If Not dr.Read() Then Throw New InvalidOperationException("El ejemplar ya no existe.")
                                idLibro = dr.GetInt32(0)
                                reglas.ValidarLibro(dr.GetBoolean(2))
                                reglas.ValidarEjemplar(dr.GetBoolean(1), 0)
                            End Using
                        End Using
                        reglas.ValidarTituloUnico(titulos.Add(idLibro))
                        query = "SELECT COUNT(1) FROM Prestamo p WITH (UPDLOCK,HOLDLOCK) WHERE p.id_ejemplar=@id AND " & ejemplarDAO.PrestamoOcupaEjemplarSql
                        Using cmd As New SqlCommand(query, cn, tx)
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEjemplar
                            reglas.ValidarEjemplar(True, CInt(cmd.ExecuteScalar()))
                        End Using
                        reglas.ValidarVentanilla(solicitudesVigentes, DisponibilidadReserva.Capacidad(cn, tx, idLibro))
                        Dim nuevo = InsertarPrestamo(cn, tx, idLector, idBibliotecario, idEjemplar, inicio, limite, operacion)
                        If id = 0 Then id = nuevo
                    Next
                    AuditoriaDAO.Registrar(cn, tx, idBibliotecario, "Prestamo", "INSERT", $"Registrar préstamo | ID={id}; lector={idLector}; cantidad={idsEjemplares.Count}")
                    tx.Commit()
                    Return id
                    ' Dispose revierte la transacción ante cualquier excepción.
                End Using
            End Using
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "prestamoDAO.registrar")
        End Try
    End Function

    Public Function PrevisualizarDevolucion(idPrestamo As Integer, retorno As Date, reglas As IReglasCirculacion) As DevolucionCalculada
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim calculo As DevolucionCalculada
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    Dim ids = LeerIdsGrupo(cn, tx, idPrestamo, False)
                    calculo = reglas.CalcularDevolucion(MoraDAO.LeerDevolucion(cn, tx, ids(0), retorno, False))
                    calculo.CantidadEjemplares = ids.Count
                    tx.Commit()
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Prestamo", "SELECT", $"Calcular devolución | préstamo={idPrestamo}; fecha={retorno:yyyy-MM-dd}")
            Return calculo
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "prestamoDAO.PrevisualizarDevolucion")
        End Try
    End Function

    Public Function DevolverConfirmado(idPrestamo As Integer, idBibliotecario As Integer, retorno As Date, confirmado As DevolucionCalculada, reglas As IReglasCirculacion) As DevolucionCalculada
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim ejemplares As New List(Of Integer)
                Dim query As String = "SELECT p.id_ejemplar FROM Prestamo p WHERE p.id_prestamo=@id OR p.id_operacion=(SELECT id_operacion FROM Prestamo WHERE id_prestamo=@id) ORDER BY p.id_ejemplar"
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPrestamo
                    Using dr = cmd.ExecuteReader()
                        While dr.Read()
                            ejemplares.Add(dr.GetInt32(0))
                        End While
                    End Using
                End Using
                If ejemplares.Count = 0 Then Throw New InvalidOperationException("No se encontró el préstamo.")
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    query = "SELECT id_ejemplar FROM Ejemplar WITH (UPDLOCK,HOLDLOCK) WHERE id_ejemplar=@id"
                    For Each ejemplar In ejemplares
                        Using cmd As New SqlCommand(query, cn, tx)
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = ejemplar
                            If cmd.ExecuteScalar() Is Nothing Then Throw New InvalidOperationException("No se encontró un ejemplar.")
                        End Using
                    Next
                    reglas.ValidarUsuario(DisponibilidadReserva.LeerUsuario(cn, tx, idBibliotecario), "BIBLIOTECARIO", "La cuenta que registra la devolución debe ser un bibliotecario activo.")
                    Dim ids = LeerIdsGrupo(cn, tx, idPrestamo, True)
                    If ids.Count <> ejemplares.Count OrElse ids.Count <> confirmado.CantidadEjemplares Then Throw New InvalidOperationException("Cambió el contenido del préstamo. Calcula nuevamente la devolución.")
                    Dim calculo = reglas.CalcularDevolucion(MoraDAO.LeerDevolucion(cn, tx, ids(0), retorno, True))
                    calculo.CantidadEjemplares = ids.Count
                    reglas.ValidarConfirmacion(calculo, confirmado)
                    query = "UPDATE Prestamo SET fecha_retorno_prestamo=@retorno,estado_prestamo=@devuelto,dias_retraso_prestamo=@dias WHERE (id_prestamo=@id OR id_operacion=(SELECT id_operacion FROM Prestamo WHERE id_prestamo=@id)) AND fecha_retorno_prestamo IS NULL AND UPPER(LTRIM(RTRIM(estado_prestamo)))='ACTIVO'"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@retorno", SqlDbType.Date).Value = retorno.Date
                        cmd.Parameters.Add("@devuelto", SqlDbType.VarChar, 30).Value = Prestamo.EstadoDevuelto
                        cmd.Parameters.Add("@dias", SqlDbType.Int).Value = calculo.DiasRetraso
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idPrestamo
                        If cmd.ExecuteNonQuery() <> ids.Count Then Throw New InvalidOperationException("El préstamo ya fue devuelto o cambió durante la operación.")
                    End Using
                    If calculo.RegistrarCargo Then MoraDAO.Registrar(cn, tx, calculo)
                    AuditoriaDAO.Registrar(cn, tx, idBibliotecario, "Prestamo", "UPDATE", $"Confirmar devolución | préstamo={calculo.IdPrestamo}; ejemplares={ids.Count}; mora={calculo.Monto:0.00}")
                    tx.Commit()
                    Return calculo
                End Using
            End Using
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "prestamoDAO.DevolverConfirmado")
        End Try
    End Function

    Private Shared Function LeerIdsGrupo(cn As SqlConnection, tx As SqlTransaction, id As Integer, bloquear As Boolean) As List(Of Integer)
        Try
            Dim ids As New List(Of Integer)
            Dim query = "SELECT p.id_prestamo,p.fecha_retorno_prestamo,p.estado_prestamo FROM Prestamo p WITH (" &
                If(bloquear, "UPDLOCK,HOLDLOCK", "HOLDLOCK") &
                ") WHERE p.id_prestamo=@id OR p.id_operacion=(SELECT id_operacion FROM Prestamo WHERE id_prestamo=@id) ORDER BY p.id_prestamo"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                Using dr = cmd.ExecuteReader()
                    While dr.Read()
                        If Not dr.IsDBNull(1) OrElse Not String.Equals(dr.GetString(2).Trim(), Prestamo.EstadoActivo, StringComparison.OrdinalIgnoreCase) Then
                            Throw New InvalidOperationException("El préstamo ya fue devuelto o cambió durante la operación.")
                        End If
                        ids.Add(dr.GetInt32(0))
                    End While
                End Using
            End Using
            If ids.Count = 0 Then Throw New InvalidOperationException("No se encontró el préstamo.")
            Return ids
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "prestamoDAO.LeerIdsGrupo")
        End Try
    End Function

    Friend Shared Function InsertarPrestamo(cn As SqlConnection, tx As SqlTransaction, lector As Integer, operador As Integer, ejemplar As Integer, inicio As Date, limite As Date, operacion As Guid) As Integer
        Try
            Dim query As String = "INSERT INTO Prestamo(id_operacion,fecha_inicio_prestamo,fecha_fin_prestamo,fecha_retorno_prestamo,estado_prestamo,dias_retraso_prestamo,id_usuario,id_bibliotecario,id_ejemplar) OUTPUT INSERTED.id_prestamo VALUES(@operacion,@inicio,@limite,NULL,'Activo',0,@lector,@operador,@ejemplar)"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@operacion", SqlDbType.UniqueIdentifier).Value = operacion
                cmd.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio
                cmd.Parameters.Add("@limite", SqlDbType.Date).Value = limite
                cmd.Parameters.Add("@lector", SqlDbType.Int).Value = lector
                cmd.Parameters.Add("@operador", SqlDbType.Int).Value = operador
                cmd.Parameters.Add("@ejemplar", SqlDbType.Int).Value = ejemplar
                Return CInt(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "prestamoDAO.InsertarPrestamo")
        End Try
    End Function

End Class
