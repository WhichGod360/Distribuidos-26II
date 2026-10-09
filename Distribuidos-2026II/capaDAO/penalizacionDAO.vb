Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class penalizacionDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    Private Const COLUMNAS As String =
        "id_penalizacion, tipo_penalizacion, descripcion_penalizacion, monto_penalizacion, estado_penalizacion"

    Private Function mapear(rs As SqlDataReader) As Penalizacion
        Dim ordDesc As Integer = rs.GetOrdinal("descripcion_penalizacion")
        Return New Penalizacion() With {
            .IdPenalizacion = rs.GetInt32(rs.GetOrdinal("id_penalizacion")),
            .TipoPenalizacion = rs.GetString(rs.GetOrdinal("tipo_penalizacion")),
            .DescripcionPenalizacion = If(rs.IsDBNull(ordDesc), "", rs.GetString(ordDesc)),
            .MontoPenalizacion = rs.GetDecimal(rs.GetOrdinal("monto_penalizacion")),
            .EstadoPenalizacion = rs.GetBoolean(rs.GetOrdinal("estado_penalizacion"))
        }
    End Function

    Public Function listarTodos() As List(Of Penalizacion)
        Dim lista As New List(Of Penalizacion)()
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT " & COLUMNAS & " FROM Penalizacion ORDER BY tipo_penalizacion, id_penalizacion"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
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

    ' estado: Nothing = todos, True = activos, False = inactivos
    Public Function buscar(texto As String, estado As Boolean?) As List(Of Penalizacion)
        Dim lista As New List(Of Penalizacion)()
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT " & COLUMNAS & " FROM Penalizacion " &
                "WHERE (tipo_penalizacion LIKE @texto OR descripcion_penalizacion LIKE @texto) " &
                "AND (@estado IS NULL OR estado_penalizacion = @estado) " &
                "ORDER BY tipo_penalizacion, id_penalizacion"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@texto", "%" & texto & "%")
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value =
                    If(estado.HasValue, CObj(estado.Value), DBNull.Value)
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

    Public Function buscarPorId(idPenalizacion As Integer) As Penalizacion
        Dim obj As Penalizacion = Nothing
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT " & COLUMNAS & " FROM Penalizacion WHERE id_penalizacion = @id"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@id", idPenalizacion)
                Using rs As SqlDataReader = cmd.ExecuteReader()
                    If rs.Read() Then obj = mapear(rs)
                End Using
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
        Return obj
    End Function

    Public Function agregarPenalizacion(tipo As String, descripcion As String, monto As Decimal, estado As Boolean) As Boolean
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "INSERT INTO Penalizacion (tipo_penalizacion, descripcion_penalizacion, monto_penalizacion, estado_penalizacion) " &
                                  "VALUES (@tipo, @descripcion, @monto, @estado)"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@tipo", tipo)
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1).Value =
                    If(String.IsNullOrWhiteSpace(descripcion), DBNull.Value, CObj(descripcion))
                Dim pMonto As SqlParameter = cmd.Parameters.Add("@monto", SqlDbType.Decimal)
                pMonto.Precision = 7
                pMonto.Scale = 2
                pMonto.Value = monto
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
    End Function

    Public Function actualizarPenalizacion(idPenalizacion As Integer, tipo As String, descripcion As String, monto As Decimal, estado As Boolean) As Boolean
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "UPDATE Penalizacion SET tipo_penalizacion = @tipo, descripcion_penalizacion = @descripcion, " &
                                  "monto_penalizacion = @monto, estado_penalizacion = @estado WHERE id_penalizacion = @id"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@id", idPenalizacion)
                cmd.Parameters.AddWithValue("@tipo", tipo)
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1).Value =
                    If(String.IsNullOrWhiteSpace(descripcion), DBNull.Value, CObj(descripcion))
                Dim pMonto As SqlParameter = cmd.Parameters.Add("@monto", SqlDbType.Decimal)
                pMonto.Precision = 7
                pMonto.Scale = 2
                pMonto.Value = monto
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
    End Function

    Public Function cambiarEstado(idPenalizacion As Integer, estado As Boolean) As Boolean
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "UPDATE Penalizacion SET estado_penalizacion = @estado WHERE id_penalizacion = @id"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@id", idPenalizacion)
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado
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
