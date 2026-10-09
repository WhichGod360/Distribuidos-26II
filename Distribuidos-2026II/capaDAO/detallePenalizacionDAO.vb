Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class detallePenalizacionDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    ' VERIFICAR: nombre_usuario (Usuario), id_libro (Ejemplar) y titulo_libro (Libro)
    ' son supuestos; solo se ajustan aquí.
    Private Const NOMBRE_USUARIO_SQL As String =
    "LTRIM(RTRIM(u.nombre_usuario + ' ' + u.ap_paterno + ' ' + ISNULL(u.ap_materno, ''))) AS nombre_usuario"
    
    Private Const JOIN_PRESTAMO As String =
        " INNER JOIN Prestamo pr ON pr.id_prestamo = dp.id_prestamo " &
        " INNER JOIN Usuario u ON u.id_usuario = pr.id_usuario " &
        " INNER JOIN Ejemplar e ON e.id_ejemplar = pr.id_ejemplar " &
        " INNER JOIN Libro l ON l.id_libro = e.id_libro "

    Private Const SELECT_DETALLE As String =
        "SELECT dp.id_detalle_penalizacion, dp.descripcion_detallepenalizacion, dp.id_penalizacion, dp.id_prestamo, " &
        "p.tipo_penalizacion, p.monto_penalizacion, " & NOMBRE_USUARIO_SQL & ", l.titulo_libro, " &
        "pr.fecha_inicio_prestamo, pr.fecha_fin_prestamo, pr.fecha_retorno_prestamo, " &
        "pr.dias_retraso_prestamo, pr.estado_prestamo " &
        "FROM DetallePenalizacion dp " &
        "INNER JOIN Penalizacion p ON p.id_penalizacion = dp.id_penalizacion " & JOIN_PRESTAMO

    Private Function mapear(rs As SqlDataReader) As DetallePenalizacion
        Dim ordDesc As Integer = rs.GetOrdinal("descripcion_detallepenalizacion")
        Dim ordRet As Integer = rs.GetOrdinal("fecha_retorno_prestamo")
        Dim ordDias As Integer = rs.GetOrdinal("dias_retraso_prestamo")
        Return New DetallePenalizacion() With {
            .IdDetallePenalizacion = rs.GetInt32(rs.GetOrdinal("id_detalle_penalizacion")),
            .DescripcionDetallePenalizacion = If(rs.IsDBNull(ordDesc), "", rs.GetString(ordDesc)),
            .IdPenalizacion = rs.GetInt32(rs.GetOrdinal("id_penalizacion")),
            .IdPrestamo = rs.GetInt32(rs.GetOrdinal("id_prestamo")),
            .TipoPenalizacion = rs.GetString(rs.GetOrdinal("tipo_penalizacion")),
            .MontoPenalizacion = rs.GetDecimal(rs.GetOrdinal("monto_penalizacion")),
            .NombreUsuario = rs.GetString(rs.GetOrdinal("nombre_usuario")),
            .TituloLibro = rs.GetString(rs.GetOrdinal("titulo_libro")),
            .FechaInicio = rs.GetDateTime(rs.GetOrdinal("fecha_inicio_prestamo")),
            .FechaFin = rs.GetDateTime(rs.GetOrdinal("fecha_fin_prestamo")),
            .FechaRetorno = If(rs.IsDBNull(ordRet), CType(Nothing, Date?), rs.GetDateTime(ordRet)),
            .DiasRetraso = If(rs.IsDBNull(ordDias), 0, rs.GetInt32(ordDias)),
            .EstadoPrestamo = rs.GetString(rs.GetOrdinal("estado_prestamo"))
        }
    End Function

    ' idPenalizacion = 0 devuelve los detalles de todas las sanciones
    Public Function listar(idPenalizacion As Integer) As List(Of DetallePenalizacion)
        Dim lista As New List(Of DetallePenalizacion)()
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = SELECT_DETALLE &
                " WHERE (@idPen = 0 OR dp.id_penalizacion = @idPen) ORDER BY dp.id_detalle_penalizacion DESC"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@idPen", idPenalizacion)
                Using rs As SqlDataReader = cmd.ExecuteReader()
                    While rs.Read()
                        lista.Add(mapear(rs))
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
    End Function

    Public Function listarPrestamos() As List(Of PrestamoResumen)
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
                Using rs As SqlDataReader = cmd.ExecuteReader()
                    While rs.Read()
                        lista.Add(New PrestamoResumen() With {
                            .IdPrestamo = rs.GetInt32(rs.GetOrdinal("id_prestamo")),
                            .NombreUsuario = rs.GetString(rs.GetOrdinal("nombre_usuario")),
                            .TituloLibro = rs.GetString(rs.GetOrdinal("titulo_libro"))
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
    End Function

    Public Function agregarDetalle(descripcion As String, idPenalizacion As Integer, idPrestamo As Integer) As Boolean
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "INSERT INTO DetallePenalizacion (descripcion_detallepenalizacion, id_penalizacion, id_prestamo) " &
                                  "VALUES (@descripcion, @idPen, @idPrestamo)"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1).Value =
                    If(String.IsNullOrWhiteSpace(descripcion), DBNull.Value, CObj(descripcion))
                cmd.Parameters.AddWithValue("@idPen", idPenalizacion)
                cmd.Parameters.AddWithValue("@idPrestamo", idPrestamo)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
    End Function

    Public Function actualizarDetalle(idDetalle As Integer, descripcion As String, idPenalizacion As Integer, idPrestamo As Integer) As Boolean
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "UPDATE DetallePenalizacion SET descripcion_detallepenalizacion = @descripcion, " &
                                  "id_penalizacion = @idPen, id_prestamo = @idPrestamo WHERE id_detalle_penalizacion = @id"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@id", idDetalle)
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1).Value =
                    If(String.IsNullOrWhiteSpace(descripcion), DBNull.Value, CObj(descripcion))
                cmd.Parameters.AddWithValue("@idPen", idPenalizacion)
                cmd.Parameters.AddWithValue("@idPrestamo", idPrestamo)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
    End Function
End Class
