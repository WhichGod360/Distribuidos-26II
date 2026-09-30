Imports System.Data
Imports System.Data.SqlClient

Public Class categoriaDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    Public Function listarTodos() As List(Of Categoria)
        Dim lista As New List(Of Categoria)()
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            ' Se especifican las columnas exactas en lugar de usar SELECT *
            Dim query As String = "SELECT id_categoria, nombre_categoria FROM Categoria ORDER BY nombre_categoria"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                Using rs As SqlDataReader = cmd.ExecuteReader()
                    While rs.Read()
                        lista.Add(New Categoria() With {
                            .IdCategoria = rs.GetInt32(rs.GetOrdinal("id_categoria")),
                            .NombreCategoria = rs.GetString(rs.GetOrdinal("nombre_categoria"))
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

    Public Function buscarPorId(idCategoria As Integer) As Categoria
        Dim objCategoria As Categoria = Nothing
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT id_categoria, nombre_categoria FROM Categoria WHERE id_categoria = @idCategoria"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria)
                Using rs As SqlDataReader = cmd.ExecuteReader()
                    If rs.Read() Then
                        objCategoria = New Categoria() With {
                            .IdCategoria = rs.GetInt32(rs.GetOrdinal("id_categoria")),
                            .NombreCategoria = rs.GetString(rs.GetOrdinal("nombre_categoria"))
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
        Return objCategoria
    End Function

    Public Function buscarPorNombre(nombre As String) As Categoria
        Dim objCategoria As Categoria = Nothing
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT id_categoria, nombre_categoria FROM Categoria WHERE nombre_categoria = @nombre"
            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@nombre", nombre)
                Using rs As SqlDataReader = cmd.ExecuteReader()
                    If rs.Read() Then
                        objCategoria = New Categoria() With {
                            .IdCategoria = rs.GetInt32(rs.GetOrdinal("id_categoria")),
                            .NombreCategoria = rs.GetString(rs.GetOrdinal("nombre_categoria"))
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
        Return objCategoria
    End Function
End Class