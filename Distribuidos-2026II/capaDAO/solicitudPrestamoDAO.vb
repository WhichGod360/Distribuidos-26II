Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class solicitudPrestamoDAO
    Public Function solicitar(idLector As Integer, idsLibros As IList(Of Integer), reglas As IReglasCirculacion) As Integer
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                DisponibilidadReserva.ExigirEsquema(cn)
                EsquemaPago.ExigirColumna(cn)
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    reglas.ValidarLector(DisponibilidadReserva.LeerLector(cn, tx, idLector), idsLibros.Count)
                    For Each libro In idsLibros.OrderBy(Function(id) id)
                        reglas.ValidarLibro(DisponibilidadReserva.BloquearLibro(cn, tx, libro))
                    Next
                    Dim queryConsulta1 As String = "SELECT COUNT(*) FROM SolicitudPrestamo s WITH (UPDLOCK,HOLDLOCK) WHERE s.id_usuario=@lector AND " & DisponibilidadReserva.VigenteSql
                    Using cmd As New SqlCommand(queryConsulta1, cn, tx)
                        cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                        reglas.ValidarNuevaSolicitud(CInt(cmd.ExecuteScalar()))
                    End Using
                    For Each libro In idsLibros
                        reglas.ValidarDisponibilidad(DisponibilidadReserva.Capacidad(cn, tx, libro))
                    Next
                    Dim solicitud As Integer
                    Dim queryConsulta2 As String = "INSERT INTO SolicitudPrestamo(id_usuario) OUTPUT INSERTED.id_solicitud VALUES(@lector)"
                    Using cmd As New SqlCommand(queryConsulta2, cn, tx)
                        cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                        solicitud = CInt(cmd.ExecuteScalar())
                    End Using
                    For Each libro In idsLibros
                        Dim queryConsulta3 As String = "INSERT INTO DetalleSolicitudPrestamo(id_solicitud,id_libro) VALUES(@solicitud,@libro)"
                        Using cmd As New SqlCommand(queryConsulta3, cn, tx)
                            cmd.Parameters.Add("@solicitud", SqlDbType.Int).Value = solicitud
                            cmd.Parameters.Add("@libro", SqlDbType.Int).Value = libro
                            cmd.ExecuteNonQuery()
                        End Using
                    Next
                    tx.Commit()
                    Return solicitud
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "solicitudPrestamoDAO.solicitar")
        End Try
    End Function

    Public Function listar(Optional idLector As Integer = 0) As List(Of SolicitudPrestamo)
        Try
            Dim resultado As New Dictionary(Of Integer, SolicitudPrestamo)()
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                DisponibilidadReserva.ExigirEsquema(cn)
                Dim query As String = "SELECT s.*, u.nombre_usuario+' '+u.ap_paterno+' '+u.ap_materno AS lector, u.numero_dni_usuario, " &
                    "a.nombre_usuario+' '+a.ap_paterno+' '+a.ap_materno AS aprobador, d.id_detalle_solicitud,d.id_libro,d.id_prestamo,l.titulo_libro, " &
                    "CASE WHEN s.estado_solicitud IN ('Pendiente','Aprobada') AND s.fecha_limite_retiro<=SYSUTCDATETIME() THEN 'Vencida' ELSE s.estado_solicitud END AS estado_actual " &
                    "FROM SolicitudPrestamo s JOIN Usuario u ON u.id_usuario=s.id_usuario LEFT JOIN Usuario a ON a.id_usuario=s.id_aprobador " &
                    "JOIN DetalleSolicitudPrestamo d ON d.id_solicitud=s.id_solicitud JOIN Libro l ON l.id_libro=d.id_libro " &
                    "WHERE (@lector=0 OR s.id_usuario=@lector) ORDER BY s.id_solicitud DESC,d.id_detalle_solicitud"
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim id = CInt(dr("id_solicitud"))
                            If Not resultado.ContainsKey(id) Then
                                resultado.Add(id, New SolicitudPrestamo With {
                                    .IdSolicitud = id, .IdUsuario = CInt(dr("id_usuario")), .NombreLector = CStr(dr("lector")),
                                    .DniLector = CStr(dr("numero_dni_usuario")), .FechaSolicitud = CDate(dr("fecha_solicitud")),
                                    .FechaLimiteRetiro = CDate(dr("fecha_limite_retiro")), .EstadoSolicitud = CStr(dr("estado_solicitud")),
                                    .EstadoActual = CStr(dr("estado_actual")), .NombreAprobador = If(IsDBNull(dr("aprobador")), "", CStr(dr("aprobador"))),
                                    .FechaAprobacion = If(IsDBNull(dr("fecha_aprobacion")), CType(Nothing, Date?), CDate(dr("fecha_aprobacion"))),
                                    .IdAprobador = If(IsDBNull(dr("id_aprobador")), CType(Nothing, Integer?), CInt(dr("id_aprobador"))),
                                    .FechaCierre = If(IsDBNull(dr("fecha_cierre")), CType(Nothing, Date?), CDate(dr("fecha_cierre")))})
                            End If
                            resultado(id).Detalles.Add(New DetalleSolicitudPrestamo With {
                                .IdDetalle = CInt(dr("id_detalle_solicitud")), .IdSolicitud = id, .IdLibro = CInt(dr("id_libro")),
                                .TituloLibro = CStr(dr("titulo_libro")), .IdPrestamo = If(IsDBNull(dr("id_prestamo")), CType(Nothing, Integer?), CInt(dr("id_prestamo")))})
                        End While
                    End Using
                End Using
            End Using
            Return resultado.Values.ToList()
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "solicitudPrestamoDAO.listar")
        End Try
    End Function

    Public Sub aprobar(idSolicitud As Integer, idOperador As Integer, reglas As IReglasCirculacion)
        CambiarEstado(idSolicitud, idOperador, "Aprobada", True, reglas)
    End Sub

    Public Sub cancelar(idSolicitud As Integer, idLector As Integer, reglas As IReglasCirculacion)
        CambiarEstado(idSolicitud, idLector, "Cancelada", False, reglas)
    End Sub

    Public Sub rechazar(idSolicitud As Integer, idOperador As Integer, reglas As IReglasCirculacion)
        CambiarEstado(idSolicitud, idOperador, "Rechazada", True, reglas)
    End Sub

    Private Sub CambiarEstado(idSolicitud As Integer, idOperador As Integer, estado As String, personal As Boolean, reglas As IReglasCirculacion)
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                DisponibilidadReserva.ExigirEsquema(cn)
                Dim lector = ObtenerLector(cn, idSolicitud)
                reglas.ValidarTitularSolicitud(lector, idOperador, personal)
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    If personal AndAlso estado = "Rechazada" Then
                        ' El personal puede liberar una reserva aunque su titular haya sido desactivado.
                        Dim queryTitular As String = "SELECT id_usuario FROM Usuario WITH (UPDLOCK,HOLDLOCK) WHERE id_usuario=@lector"
                        Using cmd As New SqlCommand(queryTitular, cn, tx)
                            cmd.Parameters.Add("@lector", SqlDbType.Int).Value = lector
                            Using dr As SqlDataReader = cmd.ExecuteReader()
                                If Not dr.Read() Then Throw New InvalidOperationException("El titular de la solicitud ya no existe.")
                            End Using
                        End Using
                    Else
                        reglas.ValidarUsuario(DisponibilidadReserva.LeerUsuario(cn, tx, lector, True), "ESTUDIANTE", "El lector debe estar activo.")
                    End If
                    If personal Then reglas.ValidarUsuario(DisponibilidadReserva.LeerUsuario(cn, tx, idOperador), "BIBLIOTECARIO", "El operador debe ser bibliotecario o administrador activo.")
                    Dim libros = LibrosSolicitud(cn, tx, idSolicitud)
                    For Each libro In libros
                        Dim queryConsulta4 As String = "SELECT id_libro FROM Libro WITH (UPDLOCK,HOLDLOCK) WHERE id_libro=@id"
                        Using cmd As New SqlCommand(queryConsulta4, cn, tx)
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = libro
                            cmd.ExecuteScalar()
                        End Using
                    Next
                    Dim query As String
                    If estado = "Aprobada" Then
                        reglas.ValidarLector(DisponibilidadReserva.LeerLector(cn, tx, lector), libros.Count)
                        For Each libro In libros
                            DisponibilidadReserva.LeerCobertura(cn, tx, libro, reglas)
                        Next
                        query = "UPDATE SolicitudPrestamo SET estado_solicitud='Aprobada',fecha_aprobacion=SYSUTCDATETIME(),id_aprobador=@operador WHERE id_solicitud=@id AND estado_solicitud='Pendiente' AND fecha_limite_retiro>SYSUTCDATETIME()"
                    Else
                        query = "UPDATE SolicitudPrestamo SET estado_solicitud=CASE WHEN fecha_limite_retiro<=SYSUTCDATETIME() THEN 'Vencida' ELSE @estado END,fecha_cierre=SYSUTCDATETIME() WHERE id_solicitud=@id AND estado_solicitud IN ('Pendiente','Aprobada')"
                    End If
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idSolicitud
                        cmd.Parameters.Add("@operador", SqlDbType.Int).Value = idOperador
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar, 12).Value = estado
                        If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException("La solicitud cambió, ya está cerrada o venció. Actualiza la lista.")
                    End Using
                    tx.Commit()
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "solicitudPrestamoDAO.CambiarEstado")
        End Try
    End Sub

    Public Function entregar(idSolicitud As Integer, idOperador As Integer, seleccion As IDictionary(Of Integer, Integer), inicio As Date, limite As Date, reglas As IReglasCirculacion) As List(Of Integer)
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                DisponibilidadReserva.ExigirEsquema(cn)
                EsquemaPago.ExigirColumna(cn)
                Dim lector = ObtenerLector(cn, idSolicitud)
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    reglas.ValidarLector(DisponibilidadReserva.LeerLector(cn, tx, lector), seleccion.Count)
                    Dim libros = LibrosSolicitud(cn, tx, idSolicitud)
                    reglas.ValidarEntregaCompleta(libros, seleccion)
                    For Each libro In libros
                        reglas.ValidarLibro(DisponibilidadReserva.BloquearLibro(cn, tx, libro))
                        DisponibilidadReserva.LeerCobertura(cn, tx, libro, reglas)
                    Next
                    reglas.ValidarUsuario(DisponibilidadReserva.LeerUsuario(cn, tx, idOperador), "BIBLIOTECARIO", "La entrega exige un bibliotecario o administrador activo.")
                    Dim query As String = "SELECT estado_solicitud,fecha_limite_retiro,SYSUTCDATETIME() AS ahora FROM SolicitudPrestamo WITH (UPDLOCK,HOLDLOCK) WHERE id_solicitud=@id AND id_usuario=@lector"
                    Dim actual As SolicitudPrestamo = Nothing
                    Dim ahora As Date
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idSolicitud
                        cmd.Parameters.Add("@lector", SqlDbType.Int).Value = lector
                        Using dr As SqlDataReader = cmd.ExecuteReader()
                            If dr.Read() Then
                                actual = New SolicitudPrestamo With {.EstadoSolicitud = dr.GetString(0), .FechaLimiteRetiro = dr.GetDateTime(1)}
                                ahora = dr.GetDateTime(2)
                            End If
                        End Using
                    End Using
                    reglas.ValidarSolicitudParaEntrega(actual, ahora)
                    Dim prestamos As New List(Of Integer)()
                    For Each libro In libros
                        Dim copia = seleccion(libro)
                        query = "SELECT e.estado_ejemplar,(SELECT COUNT(*) FROM Prestamo p WITH (UPDLOCK,HOLDLOCK) WHERE p.id_ejemplar=e.id_ejemplar AND " & ejemplarDAO.PrestamoOcupaEjemplarSql & ") AS abiertos FROM Ejemplar e WITH (UPDLOCK,HOLDLOCK) WHERE e.id_ejemplar=@copia AND e.id_libro=@libro"
                        Dim estadoEjemplar As Boolean? = Nothing
                        Dim abiertos As Integer
                        Using cmd As New SqlCommand(query, cn, tx)
                            cmd.Parameters.Add("@copia", SqlDbType.Int).Value = copia
                            cmd.Parameters.Add("@libro", SqlDbType.Int).Value = libro
                            Using dr As SqlDataReader = cmd.ExecuteReader()
                                If dr.Read() Then
                                    estadoEjemplar = dr.GetBoolean(0)
                                    abiertos = dr.GetInt32(1)
                                End If
                            End Using
                        End Using
                        reglas.ValidarEjemplar(estadoEjemplar, abiertos)
                        Dim prestamo = prestamoDAO.InsertarPrestamo(cn, tx, lector, idOperador, copia, inicio, limite)
                        Dim queryConsulta5 As String = "UPDATE DetalleSolicitudPrestamo SET id_prestamo=@prestamo WHERE id_solicitud=@solicitud AND id_libro=@libro AND id_prestamo IS NULL"
                        Using cmd As New SqlCommand(queryConsulta5, cn, tx)
                            cmd.Parameters.Add("@prestamo", SqlDbType.Int).Value = prestamo
                            cmd.Parameters.Add("@solicitud", SqlDbType.Int).Value = idSolicitud
                            cmd.Parameters.Add("@libro", SqlDbType.Int).Value = libro
                            If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException("El detalle ya fue entregado. No se registró ninguna entrega.")
                        End Using
                        prestamos.Add(prestamo)
                    Next
                    Dim queryConsulta6 As String = "UPDATE SolicitudPrestamo SET estado_solicitud='Atendida',fecha_cierre=SYSUTCDATETIME() WHERE id_solicitud=@id AND estado_solicitud='Aprobada' AND fecha_limite_retiro>SYSUTCDATETIME()"
                    Using cmd As New SqlCommand(queryConsulta6, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idSolicitud
                        If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException("La reserva venció durante la entrega. No se registró ningún préstamo.")
                    End Using
                    tx.Commit()
                    Return prestamos
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "solicitudPrestamoDAO.entregar")
        End Try
    End Function

    Private Shared Function ObtenerLector(cn As SqlConnection, solicitud As Integer) As Integer
        Try
            Dim queryConsulta7 As String = "SELECT id_usuario FROM SolicitudPrestamo WHERE id_solicitud=@id"
            Using cmd As New SqlCommand(queryConsulta7, cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = solicitud
                Dim valor = cmd.ExecuteScalar()
                If valor Is Nothing Then Throw New InvalidOperationException("La solicitud no existe.")
                Return CInt(valor)
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "solicitudPrestamoDAO.ObtenerLector")
        End Try
    End Function

    Private Shared Function LibrosSolicitud(cn As SqlConnection, tx As SqlTransaction, solicitud As Integer) As List(Of Integer)
        Try
            Dim resultado As New List(Of Integer)()
            Dim queryConsulta8 As String = "SELECT id_libro FROM DetalleSolicitudPrestamo WHERE id_solicitud=@id ORDER BY id_libro"
            Using cmd As New SqlCommand(queryConsulta8, cn, tx)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = solicitud
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        resultado.Add(dr.GetInt32(0))
                    End While
                End Using
            End Using
            If resultado.Count = 0 Then Throw New InvalidOperationException("La solicitud no contiene libros.")
            Return resultado
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "solicitudPrestamoDAO.LibrosSolicitud")
        End Try
    End Function
End Class
