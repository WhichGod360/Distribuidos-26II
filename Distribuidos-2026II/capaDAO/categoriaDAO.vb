Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class categoriaDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    Public Function listarTabla() As DataTable
        Return ejecutarTabla("SELECT id_categoria, nombre_categoria, CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado FROM Categoria ORDER BY nombre_categoria", Nothing)
    End Function

    Public Function insertar(nombre As String, estado As Integer) As Boolean
        Return ejecutarAccion("INSERT INTO Categoria (nombre_categoria, estado) VALUES (@nombre, @estado)",
                              Sub(cmd)
                                  cmd.Parameters.AddWithValue("@nombre", nombre)
                                  cmd.Parameters.AddWithValue("@estado", estado)
                              End Sub)
    End Function

    Public Function actualizar(id As Integer, nombre As String, estado As Integer) As Boolean
        Return ejecutarAccion("UPDATE Categoria SET nombre_categoria = @nombre, estado = @estado WHERE id_categoria = @id",
                              Sub(cmd)
                                  cmd.Parameters.AddWithValue("@nombre", nombre)
                                  cmd.Parameters.AddWithValue("@estado", estado)
                                  cmd.Parameters.AddWithValue("@id", id)
                              End Sub)
    End Function

    Public Function desactivar(id As Integer) As Boolean
        Return ejecutarAccion("UPDATE Categoria SET estado = 0 WHERE id_categoria = @id",
                              Sub(cmd) cmd.Parameters.AddWithValue("@id", id))
    End Function

    Public Function buscarTabla(nombre As String) As DataTable
        Return ejecutarTabla("SELECT id_categoria, nombre_categoria, CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado FROM Categoria WHERE nombre_categoria LIKE @nombre ORDER BY nombre_categoria",
                             Sub(cmd) cmd.Parameters.AddWithValue("@nombre", "%" & nombre & "%"))
    End Function

    Public Function obtenerTablaPorId(id As Integer) As DataTable
        Return ejecutarTabla("SELECT id_categoria, nombre_categoria, estado FROM Categoria WHERE id_categoria = @id",
                             Sub(cmd) cmd.Parameters.AddWithValue("@id", id))
    End Function

    Private Function ejecutarTabla(sql As String, configurar As Action(Of SqlCommand)) As DataTable
        Dim tabla As New DataTable()
        Dim cn As SqlConnection = con.ObtenerConexion()
        Try
            Using cmd As New SqlCommand(sql, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                If configurar IsNot Nothing Then configurar(cmd)
                Using adaptador As New SqlDataAdapter(cmd)
                    adaptador.Fill(tabla)
                End Using
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
        Return tabla
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
