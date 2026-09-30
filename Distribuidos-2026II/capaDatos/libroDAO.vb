Imports System.Data
Imports System.Data.SqlClient

Public Class libroDAO
    ' Instancia única de tu clase de conexión
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    Public Function listarDisponibles() As List(Of Libro)
        Dim lista As New List(Of Libro)()
        Dim cn As SqlConnection = con.ObtenerConexion() ' Ya viene abierta

        Try
            Dim query As String = "SELECT l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.stock_total, l.estado_libro, l.publico_libro, " &
                                  "STRING_AGG(a.nombre_autor, ', ') AS autores, " &
                                  "STRING_AGG(c.nombre_categoria, ', ') AS categorias " &
                                  "FROM Libro l " &
                                  "INNER JOIN DetalleLibro dl ON l.id_libro = dl.id_libro " &
                                  "INNER JOIN Autor a ON dl.id_autor = a.id_autor " &
                                  "INNER JOIN DetalleCategoria dc ON l.id_libro = dc.id_libro " &
                                  "INNER JOIN Categoria c ON dc.id_categoria = c.id_categoria " &
                                  "WHERE l.estado_libro = 1 AND l.stock_total > 0 " &
                                  "GROUP BY l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.stock_total, l.estado_libro, l.publico_libro " &
                                  "ORDER BY l.titulo_libro"

            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual

                Using rs As SqlDataReader = cmd.ExecuteReader()
                    While rs.Read()
                        Dim objLibro As New Libro() With {
                            .IdLibro = rs.GetInt32(rs.GetOrdinal("id_libro")),
                            .TituloLibro = rs.GetString(rs.GetOrdinal("titulo_libro")),
                            .EditorialLibro = If(rs.IsDBNull(rs.GetOrdinal("editorial_libro")), Nothing, rs.GetString(rs.GetOrdinal("editorial_libro"))),
                            .StockTotal = rs.GetInt32(rs.GetOrdinal("stock_total")),
                            .EstadoLibro = rs.GetBoolean(rs.GetOrdinal("estado_libro")),
                            .PublicoLibro = If(rs.IsDBNull(rs.GetOrdinal("publico_libro")), Nothing, rs.GetString(rs.GetOrdinal("publico_libro"))),
                            .Autor = If(rs.IsDBNull(rs.GetOrdinal("autores")), Nothing, rs.GetString(rs.GetOrdinal("autores"))),
                            .Categoria = If(rs.IsDBNull(rs.GetOrdinal("categorias")), Nothing, rs.GetString(rs.GetOrdinal("categorias")))
                        }

                        If Not rs.IsDBNull(rs.GetOrdinal("ano_publicacion")) Then
                            objLibro.AnoPublicacion = rs.GetInt16(rs.GetOrdinal("ano_publicacion"))
                        End If

                        lista.Add(objLibro)
                    End While
                End Using
            End Using
        Finally
            ' Liberar la conexión solo si no estamos dentro de una transacción global
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
        Return lista
    End Function

    Public Function buscar(titulo As String, autor As String, categoria As String) As List(Of Libro)
        Dim lista As New List(Of Libro)()
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim sql As String = "SELECT l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.stock_total, l.estado_libro, l.publico_libro, " &
                                "STRING_AGG(a.nombre_autor, ', ') AS autores, " &
                                "STRING_AGG(c.nombre_categoria, ', ') AS categorias " &
                                "FROM Libro l " &
                                "INNER JOIN DetalleLibro dl ON l.id_libro = dl.id_libro " &
                                "INNER JOIN Autor a ON dl.id_autor = a.id_autor " &
                                "INNER JOIN DetalleCategoria dc ON l.id_libro = dc.id_libro " &
                                "INNER JOIN Categoria c ON dc.id_categoria = c.id_categoria " &
                                "WHERE l.estado_libro = 1 AND l.stock_total > 0 AND UPPER(l.titulo_libro) LIKE UPPER(@titulo) "

            If autor <> "Todos" Then sql &= " AND a.nombre_autor = @autor "
            If categoria <> "Todas" Then sql &= " AND c.nombre_categoria = @categoria "

            sql &= "GROUP BY l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.stock_total, l.estado_libro, l.publico_libro ORDER BY l.titulo_libro"

            Using cmd As New SqlCommand(sql, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual

                cmd.Parameters.AddWithValue("@titulo", "%" & titulo & "%")
                If autor <> "Todos" Then cmd.Parameters.AddWithValue("@autor", autor)
                If categoria <> "Todas" Then cmd.Parameters.AddWithValue("@categoria", categoria)

                Using rs As SqlDataReader = cmd.ExecuteReader()
                    While rs.Read()
                        Dim objLibro As New Libro() With {
                            .IdLibro = rs.GetInt32(rs.GetOrdinal("id_libro")),
                            .TituloLibro = rs.GetString(rs.GetOrdinal("titulo_libro")),
                            .EditorialLibro = If(rs.IsDBNull(rs.GetOrdinal("editorial_libro")), Nothing, rs.GetString(rs.GetOrdinal("editorial_libro"))),
                            .StockTotal = rs.GetInt32(rs.GetOrdinal("stock_total")),
                            .EstadoLibro = rs.GetBoolean(rs.GetOrdinal("estado_libro")),
                            .PublicoLibro = If(rs.IsDBNull(rs.GetOrdinal("publico_libro")), Nothing, rs.GetString(rs.GetOrdinal("publico_libro"))),
                            .Autor = If(rs.IsDBNull(rs.GetOrdinal("autores")), Nothing, rs.GetString(rs.GetOrdinal("autores"))),
                            .Categoria = If(rs.IsDBNull(rs.GetOrdinal("categorias")), Nothing, rs.GetString(rs.GetOrdinal("categorias")))
                        }

                        If Not rs.IsDBNull(rs.GetOrdinal("ano_publicacion")) Then
                            objLibro.AnoPublicacion = rs.GetInt16(rs.GetOrdinal("ano_publicacion"))
                        End If

                        lista.Add(objLibro)
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

    Public Function listarTodos() As List(Of Libro)
        Dim lista As New List(Of Libro)()
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.publico_libro, l.estado_libro, a.nombre_autor, c.nombre_categoria " &
                                  "FROM Libro l " &
                                  "INNER JOIN DetalleLibro dl ON l.id_libro = dl.id_libro " &
                                  "INNER JOIN Autor a ON dl.id_autor = a.id_autor " &
                                  "INNER JOIN DetalleCategoria dc ON l.id_libro = dc.id_libro " &
                                  "INNER JOIN Categoria c ON dc.id_categoria = c.id_categoria ORDER BY l.id_libro"

            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual

                Using rs As SqlDataReader = cmd.ExecuteReader()
                    While rs.Read()
                        Dim objLibro As New Libro() With {
                            .IdLibro = rs.GetInt32(rs.GetOrdinal("id_libro")),
                            .TituloLibro = rs.GetString(rs.GetOrdinal("titulo_libro")),
                            .EditorialLibro = If(rs.IsDBNull(rs.GetOrdinal("editorial_libro")), Nothing, rs.GetString(rs.GetOrdinal("editorial_libro"))),
                            .EstadoLibro = rs.GetBoolean(rs.GetOrdinal("estado_libro")),
                            .PublicoLibro = If(rs.IsDBNull(rs.GetOrdinal("publico_libro")), Nothing, rs.GetString(rs.GetOrdinal("publico_libro"))),
                            .NombreAutor = rs.GetString(rs.GetOrdinal("nombre_autor")),
                            .NombreCategoria = rs.GetString(rs.GetOrdinal("nombre_categoria"))
                        }

                        If Not rs.IsDBNull(rs.GetOrdinal("ano_publicacion")) Then
                            objLibro.AnoPublicacion = rs.GetInt16(rs.GetOrdinal("ano_publicacion"))
                        End If

                        lista.Add(objLibro)
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

    Public Function eliminarLibro(idLibro As Integer) As Boolean
        Dim cn As SqlConnection = con.ObtenerConexion()
        Try
            Dim sqlValidar As String = "SELECT COUNT(*) FROM Prestamo p INNER JOIN Ejemplar e ON p.id_ejemplar = e.id_ejemplar WHERE e.id_libro = @idLibro"
            Using cmdValidar As New SqlCommand(sqlValidar, cn)
                If con.EnTransaccion Then cmdValidar.Transaction = con.TransaccionActual
                cmdValidar.Parameters.AddWithValue("@idLibro", idLibro)
                Dim count As Integer = Convert.ToInt32(cmdValidar.ExecuteScalar())
                If count > 0 Then Throw New Exception("No se puede eliminar el libro porque tiene préstamos registrados.")
            End Using

            Dim sqlUpdate As String = "UPDATE Libro SET estado_libro = 0 WHERE id_libro = @idLibro"
            Using cmdUpdate As New SqlCommand(sqlUpdate, cn)
                If con.EnTransaccion Then cmdUpdate.Transaction = con.TransaccionActual
                cmdUpdate.Parameters.AddWithValue("@idLibro", idLibro)
                Return cmdUpdate.ExecuteNonQuery() > 0
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
    End Function

    Public Function agregarLibro(titulo As String, editorial As String, anoPublicacion As Short, publico As String, estado As Boolean, idAutor As Integer, idCategoria As Integer) As Boolean
        ' Usamos los métodos transaccionales nativos de tu clase Conexion.vb
        con.IniciarTransaccion()
        Dim cn As SqlConnection = con.ObtenerConexion()
        Dim tx As SqlTransaction = con.TransaccionActual

        Try
            ' Validación de duplicado
            Dim sqlValidar As String = "SELECT COUNT(*) FROM Libro WHERE UPPER(titulo_libro) = UPPER(@titulo)"
            Using cmdValidar As New SqlCommand(sqlValidar, cn, tx)
                cmdValidar.Parameters.AddWithValue("@titulo", titulo)
                If Convert.ToInt32(cmdValidar.ExecuteScalar()) > 0 Then
                    Throw New Exception("Ya existe un libro con ese título.")
                End If
            End Using

            ' Insertar Libro
            Dim idNuevoLibro As Integer
            Dim sqlLibro As String = "INSERT INTO Libro (titulo_libro, editorial_libro, ano_publicacion, stock_total, estado_libro, publico_libro) " &
                                     "OUTPUT INSERTED.id_libro VALUES (@titulo, @editorial, @ano, 0, @estado, @publico)"

            Using cmdLibro As New SqlCommand(sqlLibro, cn, tx)
                cmdLibro.Parameters.AddWithValue("@titulo", titulo)
                cmdLibro.Parameters.AddWithValue("@editorial", editorial)
                cmdLibro.Parameters.AddWithValue("@ano", anoPublicacion)
                cmdLibro.Parameters.AddWithValue("@estado", estado)
                cmdLibro.Parameters.AddWithValue("@publico", publico)
                idNuevoLibro = Convert.ToInt32(cmdLibro.ExecuteScalar())
            End Using

            ' Insertar DetalleLibro (Autor)
            Dim sqlAutor As String = "INSERT INTO DetalleLibro (id_libro, id_autor) VALUES (@idLibro, @idAutor)"
            Using cmdAutor As New SqlCommand(sqlAutor, cn, tx)
                cmdAutor.Parameters.AddWithValue("@idLibro", idNuevoLibro)
                cmdAutor.Parameters.AddWithValue("@idAutor", idAutor)
                cmdAutor.ExecuteNonQuery()
            End Using

            ' Insertar DetalleCategoria
            Dim sqlCat As String = "INSERT INTO DetalleCategoria (id_libro, id_categoria) VALUES (@idLibro, @idCategoria)"
            Using cmdCat As New SqlCommand(sqlCat, cn, tx)
                cmdCat.Parameters.AddWithValue("@idLibro", idNuevoLibro)
                cmdCat.Parameters.AddWithValue("@idCategoria", idCategoria)
                cmdCat.ExecuteNonQuery()
            End Using

            con.ConfirmarTransaccion()
            Return True
        Catch ex As Exception
            con.CancelarTransaccion()
            Throw ex ' Propagamos el error para mostrarlo en el formulario
        End Try
    End Function

    Public Function actualizarLibro(idLibro As Integer, titulo As String, editorial As String, anoPublicacion As Short, publico As String, estado As Boolean, idAutor As Integer, idCategoria As Integer) As Boolean
        con.IniciarTransaccion()
        Dim cn As SqlConnection = con.ObtenerConexion()
        Dim tx As SqlTransaction = con.TransaccionActual

        Try
            ' Actualizar Libro
            Dim sqlLibro As String = "UPDATE Libro SET titulo_libro = @titulo, editorial_libro = @editorial, ano_publicacion = @ano, " &
                                     "publico_libro = @publico, estado_libro = @estado WHERE id_libro = @idLibro"
            Using cmdLibro As New SqlCommand(sqlLibro, cn, tx)
                cmdLibro.Parameters.AddWithValue("@titulo", titulo)
                cmdLibro.Parameters.AddWithValue("@editorial", editorial)
                cmdLibro.Parameters.AddWithValue("@ano", anoPublicacion)
                cmdLibro.Parameters.AddWithValue("@publico", publico)
                cmdLibro.Parameters.AddWithValue("@estado", estado)
                cmdLibro.Parameters.AddWithValue("@idLibro", idLibro)
                cmdLibro.ExecuteNonQuery()
            End Using

            ' Actualizar DetalleLibro (Autor)
            Dim sqlAutor As String = "UPDATE DetalleLibro SET id_autor = @idAutor WHERE id_libro = @idLibro"
            Using cmdAutor As New SqlCommand(sqlAutor, cn, tx)
                cmdAutor.Parameters.AddWithValue("@idAutor", idAutor)
                cmdAutor.Parameters.AddWithValue("@idLibro", idLibro)
                cmdAutor.ExecuteNonQuery()
            End Using

            ' Actualizar DetalleCategoria
            Dim sqlCat As String = "UPDATE DetalleCategoria SET id_categoria = @idCategoria WHERE id_libro = @idLibro"
            Using cmdCat As New SqlCommand(sqlCat, cn, tx)
                cmdCat.Parameters.AddWithValue("@idCategoria", idCategoria)
                cmdCat.Parameters.AddWithValue("@idLibro", idLibro)
                cmdCat.ExecuteNonQuery()
            End Using

            con.ConfirmarTransaccion()
            Return True
        Catch ex As Exception
            con.CancelarTransaccion()
            Throw ex
        End Try
    End Function
End Class