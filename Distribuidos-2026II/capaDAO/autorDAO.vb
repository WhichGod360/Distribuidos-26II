Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class autorDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    Public Function listarTodos() As List(Of Autor)
        Try
            Dim lista As New List(Of Autor)()
            Dim cn As SqlConnection = con.ObtenerConexion()

            Try
                Dim query As String = "SELECT id_autor, nombre_autor FROM Autor ORDER BY nombre_autor"
                Using cmd As New SqlCommand(query, cn)
                    If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Autor() With {
                                .IdAutor = dr.GetInt32(dr.GetOrdinal("id_autor")),
                                .NombreAutor = dr.GetString(dr.GetOrdinal("nombre_autor"))
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
            Throw ErroresDAO.Traducir(ex, "autorDAO.listarTodos")
        End Try
    End Function

    Public Function buscarPorId(idAutor As Integer) As Autor
        Try
            Dim objAutor As Autor = Nothing
            Dim cn As SqlConnection = con.ObtenerConexion()

            Try
                Dim query As String = "SELECT id_autor, nombre_autor FROM Autor WHERE id_autor = @idAutor"
                Using cmd As New SqlCommand(query, cn)
                    If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                    cmd.Parameters.Add("@idAutor", SqlDbType.Int).Value = idAutor
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            objAutor = New Autor() With {
                                .IdAutor = dr.GetInt32(dr.GetOrdinal("id_autor")),
                                .NombreAutor = dr.GetString(dr.GetOrdinal("nombre_autor"))
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
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "autorDAO.buscarPorId")
        End Try
    End Function

    Public Function buscarPorNombre(nombre As String) As Autor
        Try
            Dim objAutor As Autor = Nothing
            Dim cn As SqlConnection = con.ObtenerConexion()

            Try
                Dim query As String = "SELECT id_autor, nombre_autor FROM Autor WHERE nombre_autor = @nombre"
                Using cmd As New SqlCommand(query, cn)
                    If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            objAutor = New Autor() With {
                                .IdAutor = dr.GetInt32(dr.GetOrdinal("id_autor")),
                                .NombreAutor = dr.GetString(dr.GetOrdinal("nombre_autor"))
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
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "autorDAO.buscarPorNombre")
        End Try
    End Function

    Public Function insertar(nombre As String) As Boolean
        Return ejecutarAccion("INSERT INTO Autor (nombre_autor) " &
                              "SELECT @nombre WHERE NOT EXISTS (SELECT 1 FROM Autor WHERE UPPER(LTRIM(RTRIM(nombre_autor))) = UPPER(LTRIM(RTRIM(@nombre))))",
                              Sub(cmd) cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre)
    End Function

    Public Function actualizar(idAutor As Integer, nombre As String) As Boolean
        Return ejecutarAccion("UPDATE Autor SET nombre_autor = @nombre WHERE id_autor = @id " &
                              "AND NOT EXISTS (SELECT 1 FROM Autor WHERE id_autor <> @id AND UPPER(LTRIM(RTRIM(nombre_autor))) = UPPER(LTRIM(RTRIM(@nombre))))",
                              Sub(cmd)
                                  cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                                  cmd.Parameters.Add("@id", SqlDbType.Int).Value = idAutor
                              End Sub)
    End Function

    Public Function eliminar(idAutor As Integer, validar As Action(Of Integer)) As Boolean
        Try
            Using cn As SqlConnection = con.CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    Dim query As String = "SELECT COUNT(*) FROM DetalleLibro WITH (UPDLOCK,HOLDLOCK) WHERE id_autor=@id"
                    Using cmd As New SqlCommand(query,cn,tx)
                        cmd.Parameters.Add("@id",SqlDbType.Int).Value=idAutor
                        validar(CInt(cmd.ExecuteScalar()))
                    End Using
                    query="DELETE FROM Autor WHERE id_autor=@id"
                    Using cmd As New SqlCommand(query,cn,tx)
                        cmd.Parameters.Add("@id",SqlDbType.Int).Value=idAutor
                        Dim resultado=cmd.ExecuteNonQuery()>0
                        tx.Commit()
                        Return resultado
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex,"autorDAO.eliminar")
        End Try
    End Function

    Private Function ejecutarAccion(query As String, configurar As Action(Of SqlCommand)) As Boolean
        Try
            Dim cn As SqlConnection = con.ObtenerConexion()
            Try
                Using cmd As New SqlCommand(query, cn)
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
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "autorDAO.ejecutarAccion")
        End Try
    End Function
End Class
