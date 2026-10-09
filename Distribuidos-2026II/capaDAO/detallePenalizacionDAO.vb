Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class detallePenalizacionDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    ' El estado de pago pertenece a la penalización aplicada, separado del catálogo.
    Private Const NOMBRE_USUARIO_SQL As String =
    "LTRIM(RTRIM(u.nombre_usuario + ' ' + u.ap_paterno + ' ' + ISNULL(u.ap_materno, ''))) AS nombre_usuario"
    
    Private Const JOIN_PRESTAMO As String =
        " INNER JOIN Prestamo pr ON pr.id_prestamo = dp.id_prestamo " &
        " INNER JOIN Usuario u ON u.id_usuario = pr.id_usuario " &
        " INNER JOIN Ejemplar e ON e.id_ejemplar = pr.id_ejemplar " &
        " INNER JOIN Libro l ON l.id_libro = e.id_libro "

    Private Const SELECT_DETALLE As String =
        "SELECT dp.id_detalle_penalizacion, dp.descripcion_detallepenalizacion, dp.id_penalizacion, dp.id_prestamo, dp.estado_pago_detalle, " &
        "p.tipo_penalizacion, p.descripcion_penalizacion, dp.monto_aplicado AS monto_penalizacion, " & NOMBRE_USUARIO_SQL & ", l.titulo_libro, " &
        "pr.fecha_inicio_prestamo, pr.fecha_fin_prestamo, pr.fecha_retorno_prestamo, " &
        "pr.dias_retraso_prestamo, pr.estado_prestamo " &
        "FROM DetallePenalizacion dp " &
        "INNER JOIN Penalizacion p ON p.id_penalizacion = dp.id_penalizacion " & JOIN_PRESTAMO

    Private Function mapear(dr As SqlDataReader) As DetallePenalizacion
        Dim ordDesc As Integer = dr.GetOrdinal("descripcion_detallepenalizacion")
        Dim ordRet As Integer = dr.GetOrdinal("fecha_retorno_prestamo")
        Dim ordDias As Integer = dr.GetOrdinal("dias_retraso_prestamo")
        Return New DetallePenalizacion() With {
            .IdDetallePenalizacion = dr.GetInt32(dr.GetOrdinal("id_detalle_penalizacion")),
            .DescripcionDetallePenalizacion = If(dr.IsDBNull(ordDesc), "", dr.GetString(ordDesc)),
            .IdPenalizacion = dr.GetInt32(dr.GetOrdinal("id_penalizacion")),
            .IdPrestamo = dr.GetInt32(dr.GetOrdinal("id_prestamo")),
            .EstadoPago = dr.GetString(dr.GetOrdinal("estado_pago_detalle")),
            .TipoPenalizacion = dr.GetString(dr.GetOrdinal("tipo_penalizacion")),
            .DescripcionTipoPenalizacion = If(IsDBNull(dr("descripcion_penalizacion")), "", CStr(dr("descripcion_penalizacion"))),
            .MontoPenalizacion = dr.GetDecimal(dr.GetOrdinal("monto_penalizacion")),
            .NombreUsuario = dr.GetString(dr.GetOrdinal("nombre_usuario")),
            .TituloLibro = dr.GetString(dr.GetOrdinal("titulo_libro")),
            .FechaInicio = dr.GetDateTime(dr.GetOrdinal("fecha_inicio_prestamo")),
            .FechaFin = dr.GetDateTime(dr.GetOrdinal("fecha_fin_prestamo")),
            .FechaRetorno = If(dr.IsDBNull(ordRet), CType(Nothing, Date?), dr.GetDateTime(ordRet)),
            .DiasRetraso = If(dr.IsDBNull(ordDias), 0, dr.GetInt32(ordDias)),
            .EstadoPrestamo = dr.GetString(dr.GetOrdinal("estado_prestamo"))
        }
    End Function

    ' idPenalizacion = 0 devuelve los detalles de todas las sanciones
    Public Function listar(idPenalizacion As Integer,Optional idPrestamo As Integer=0) As List(Of DetallePenalizacion)
        Try
            Dim lista As New List(Of DetallePenalizacion)()
            Dim cn As SqlConnection = con.ObtenerConexion()

            Try
                EsquemaPago.ExigirColumna(cn, If(con.EnTransaccion, con.TransaccionActual, Nothing))
                Dim query As String = SELECT_DETALLE &
                    " WHERE (@idPen = 0 OR dp.id_penalizacion = @idPen) AND (@prestamo=0 OR dp.id_prestamo=@prestamo) ORDER BY dp.id_detalle_penalizacion DESC"
                Using cmd As New SqlCommand(query, cn)
                    If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                    cmd.Parameters.Add("@idPen", SqlDbType.Int).Value = idPenalizacion
                    cmd.Parameters.Add("@prestamo",SqlDbType.Int).Value=idPrestamo
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(mapear(dr))
                        End While
                    End Using
                End Using
            Finally
                If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                    cn.Close()
                    cn.Dispose()
                End If
            End Try
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "detallePenalizacionDAO.listar")
        End Try
    End Function

    Public Function ListarPorLector(idLector As Integer) As List(Of DetallePenalizacion)
        Try
            Dim lista As New List(Of DetallePenalizacion)()
            Dim query As String = SELECT_DETALLE & " WHERE pr.id_usuario=@lector ORDER BY dp.id_detalle_penalizacion DESC"
            Using cn As SqlConnection = con.CrearConexionIndependiente()
                EsquemaPago.ExigirColumna(cn)
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(mapear(dr))
                        End While
                    End Using
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "detallePenalizacionDAO.ListarPorLector")
        End Try
    End Function

    Public Function listarPrestamos() As List(Of PrestamoResumen)
        Try
            Dim lista As New List(Of PrestamoResumen)()
            Dim cn As SqlConnection = con.ObtenerConexion()

            Try
                Dim query As String = "SELECT pr.id_prestamo, " & NOMBRE_USUARIO_SQL & ", l.titulo_libro " &
                    "FROM Prestamo pr " &
                    "INNER JOIN Usuario u ON u.id_usuario = pr.id_usuario " &
                    "INNER JOIN Ejemplar e ON e.id_ejemplar = pr.id_ejemplar " &
                    "INNER JOIN Libro l ON l.id_libro = e.id_libro " &
                    "ORDER BY pr.id_prestamo DESC"
                Using cmd As New SqlCommand(query, cn)
                    If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New PrestamoResumen() With {
                                .IdPrestamo = dr.GetInt32(dr.GetOrdinal("id_prestamo")),
                                .NombreUsuario = dr.GetString(dr.GetOrdinal("nombre_usuario")),
                                .TituloLibro = dr.GetString(dr.GetOrdinal("titulo_libro"))
                            })
                        End While
                    End Using
                End Using
            Finally
                If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                    cn.Close()
                    cn.Dispose()
                End If
            End Try
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "detallePenalizacionDAO.listarPrestamos")
        End Try
    End Function

    Public Function agregarDetalle(descripcion As String, idPenalizacion As Integer, idPrestamo As Integer, idOperador As Integer, reglas As IReglasPenalizacion, Optional estadoPago As String = DetallePenalizacion.PagoPendiente) As Boolean
        Try
            Using cn As SqlConnection=con.CrearConexionIndependiente()
                Using tx As SqlTransaction=cn.BeginTransaction(IsolationLevel.Serializable)
                    Dim prestamo As Prestamo = Nothing
                    Dim query As String = "SELECT dias_retraso_prestamo,fecha_retorno_prestamo FROM Prestamo WITH (UPDLOCK,HOLDLOCK) WHERE id_prestamo=@id"
                    Using cmd As New SqlCommand(query,cn,tx)
                        cmd.Parameters.Add("@id",SqlDbType.Int).Value=idPrestamo
                        Using dr As SqlDataReader=cmd.ExecuteReader()
                            If dr.Read() Then prestamo = New Prestamo With {.IdPrestamo=idPrestamo,.DiasRetraso=CInt(dr("dias_retraso_prestamo")),
                                .FechaRetorno=If(IsDBNull(dr("fecha_retorno_prestamo")),CType(Nothing,Date?),CDate(dr("fecha_retorno_prestamo")))}
                        End Using
                    End Using
                    reglas.ValidarPersonal(DisponibilidadReserva.LeerUsuario(cn,tx,idOperador))
                    Dim tipo As Penalizacion = Nothing
                    query = "SELECT * FROM Penalizacion WITH (HOLDLOCK) WHERE id_penalizacion=@id"
                    Using cmd As New SqlCommand(query,cn,tx)
                        cmd.Parameters.Add("@id",SqlDbType.Int).Value=idPenalizacion
                        Using dr As SqlDataReader=cmd.ExecuteReader()
                            If dr.Read() Then tipo=penalizacionDAO.Mapear(dr)
                        End Using
                    End Using
                    Dim cargos As New List(Of Penalizacion)
                    query="SELECT p.* FROM DetallePenalizacion d WITH (HOLDLOCK) JOIN Penalizacion p WITH (HOLDLOCK) ON p.id_penalizacion=d.id_penalizacion WHERE d.id_prestamo=@prestamo"
                    Using cmd As New SqlCommand(query,cn,tx)
                        cmd.Parameters.Add("@prestamo",SqlDbType.Int).Value=idPrestamo
                        Using dr As SqlDataReader=cmd.ExecuteReader()
                            While dr.Read()
                                cargos.Add(penalizacionDAO.Mapear(dr))
                            End While
                        End Using
                    End Using
                    reglas.ValidarCargo(tipo,prestamo,MoraDAO.LeerTramos(cn,tx),cargos)
                    query="INSERT INTO DetallePenalizacion(descripcion_detallepenalizacion,id_penalizacion,id_prestamo,estado_pago_detalle,monto_aplicado) VALUES(@motivo,@tipo,@prestamo,@pago,@monto)"
                    Using cmd As New SqlCommand(query,cn,tx)
                        cmd.Parameters.Add("@motivo",SqlDbType.VarChar,-1).Value=descripcion.Trim()
                        cmd.Parameters.Add("@tipo",SqlDbType.Int).Value=idPenalizacion
                        cmd.Parameters.Add("@prestamo",SqlDbType.Int).Value=idPrestamo
                        cmd.Parameters.Add("@pago",SqlDbType.VarChar,12).Value=estadoPago
                        penalizacionDAO.AgregarMonto(cmd,"@monto",tipo.MontoPenalizacion)
                        cmd.ExecuteNonQuery()
                    End Using
                    tx.Commit()
                    Return True
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "detallePenalizacionDAO.agregarDetalle")
        End Try
    End Function

    Public Function actualizarDetalle(idDetalle As Integer, descripcion As String, idPenalizacion As Integer, idPrestamo As Integer, idOperador As Integer, reglas As IReglasPenalizacion, Optional estadoPago As String = Nothing) As Boolean
        Try
            Using cn As SqlConnection=con.CrearConexionIndependiente()
                Using tx As SqlTransaction=cn.BeginTransaction()
                    reglas.ValidarPersonal(DisponibilidadReserva.LeerUsuario(cn,tx,idOperador))
                    Dim query As String="UPDATE DetallePenalizacion SET descripcion_detallepenalizacion=@motivo,estado_pago_detalle=COALESCE(@pago,estado_pago_detalle) WHERE id_detalle_penalizacion=@id AND id_penalizacion=@tipo AND id_prestamo=@prestamo"
                    Using cmd As New SqlCommand(query,cn,tx)
                        cmd.Parameters.Add("@motivo",SqlDbType.VarChar,-1).Value=descripcion.Trim()
                        cmd.Parameters.Add("@pago",SqlDbType.VarChar,12).Value=If(estadoPago Is Nothing,DBNull.Value,CObj(estadoPago))
                        cmd.Parameters.Add("@id",SqlDbType.Int).Value=idDetalle
                        cmd.Parameters.Add("@tipo",SqlDbType.Int).Value=idPenalizacion
                        cmd.Parameters.Add("@prestamo",SqlDbType.Int).Value=idPrestamo
                        If cmd.ExecuteNonQuery()<>1 Then Throw New InvalidOperationException("El cargo no existe o intentas cambiar su préstamo/tipo. Solo se editan el motivo y el pago.")
                    End Using
                    tx.Commit()
                    Return True
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "detallePenalizacionDAO.actualizarDetalle")
        End Try
    End Function

End Class
