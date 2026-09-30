Imports System.Data
Imports System.Data.SqlClient

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
End Class