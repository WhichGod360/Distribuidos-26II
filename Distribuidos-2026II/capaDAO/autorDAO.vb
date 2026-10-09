Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class autorDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    Public Function listarTodos() As List(Of Autor)
        Dim lista As New List(Of Autor)()
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT id_autor, nombre_autor FROM Autor ORDER BY nombre_autor"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                Using rs As SqlDataReader = cmd.ExecuteReader()
                    While rs.Read()
                        lista.Add(New Autor() With {
                            .IdAutor = rs.GetInt32(rs.GetOrdinal("id_autor")),
                            .NombreAutor = rs.GetString(rs.GetOrdinal("nombre_autor"))
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

    Public Function buscarPorId(idAutor As Integer) As Autor
        Dim objAutor As Autor = Nothing
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT id_autor, nombre_autor FROM Autor WHERE id_autor = @idAutor"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@idAutor", idAutor)
                Using rs As SqlDataReader = cmd.ExecuteReader()
                    If rs.Read() Then
                        objAutor = New Autor() With {
                            .IdAutor = rs.GetInt32(rs.GetOrdinal("id_autor")),
                            .NombreAutor = rs.GetString(rs.GetOrdinal("nombre_autor"))
                        }
                    End If
                End Using
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
        Return objAutor
    End Function

    Public Function buscarPorNombre(nombre As String) As Autor
        Dim objAutor As Autor = Nothing
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT id_autor, nombre_autor FROM Autor WHERE nombre_autor = @nombre"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@nombre", nombre)
                Using rs As SqlDataReader = cmd.ExecuteReader()
                    If rs.Read() Then
                        objAutor = New Autor() With {
                            .IdAutor = rs.GetInt32(rs.GetOrdinal("id_autor")),
                            .NombreAutor = rs.GetString(rs.GetOrdinal("nombre_autor"))
                        }
                    End If
                End Using
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
        Return objAutor
    End Function

    Public Function insertar(nombre As String) As Boolean
        Return ejecutarAccion("INSERT INTO Autor (nombre_autor) " &
                              "SELECT @nombre WHERE NOT EXISTS (SELECT 1 FROM Autor WHERE UPPER(LTRIM(RTRIM(nombre_autor))) = UPPER(LTRIM(RTRIM(@nombre))))",
                              Sub(cmd) cmd.Parameters.AddWithValue("@nombre", nombre))
    End Function

    Public Function actualizar(idAutor As Integer, nombre As String) As Boolean
        Return ejecutarAccion("UPDATE Autor SET nombre_autor = @nombre WHERE id_autor = @id " &
                              "AND NOT EXISTS (SELECT 1 FROM Autor WHERE id_autor <> @id AND UPPER(LTRIM(RTRIM(nombre_autor))) = UPPER(LTRIM(RTRIM(@nombre))))",
                              Sub(cmd)
                                  cmd.Parameters.AddWithValue("@nombre", nombre)
                                  cmd.Parameters.AddWithValue("@id", idAutor)
                              End Sub)
    End Function

    Public Function eliminar(idAutor As Integer) As Boolean
        Dim cn As SqlConnection = con.ObtenerConexion()
        Try
            Using cmd As New SqlCommand("IF EXISTS (SELECT 1 FROM DetalleLibro WHERE id_autor = @id) " &
                                        "THROW 50001, 'No se puede eliminar el autor porque está asociado a libros.', 1; " &
                                        "DELETE FROM Autor WHERE id_autor = @id", cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@id", idAutor)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
    End Function

    Private Function ejecutarAccion(sql As String, configurar As Action(Of SqlCommand)) As Boolean
        Dim cn As SqlConnection = con.ObtenerConexion()
        Try
            Using cmd As New SqlCommand(sql, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                configurar(cmd)
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
