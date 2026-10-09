Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class libroDAO
    ' Instancia única de tu clase de conexión
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    Public Function listarDisponibles() As List(Of Libro)
        Dim lista As New List(Of Libro)()
        Dim cn As SqlConnection = con.ObtenerConexion() ' Ya viene abierta

        Try
            Dim query As String = "SELECT l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.stock_total, l.estado_libro, l.publico_libro, " &
                                  "(SELECT STRING_AGG(a.nombre_autor, ', ') FROM DetalleLibro dl INNER JOIN Autor a ON a.id_autor = dl.id_autor WHERE dl.id_libro = l.id_libro) AS autores, " &
                                  "(SELECT STRING_AGG(c.nombre_categoria, ', ') FROM DetalleCategoria dc INNER JOIN Categoria c ON c.id_categoria = dc.id_categoria WHERE dc.id_libro = l.id_libro) AS categorias " &
                                  "FROM Libro l " &
                                  "WHERE l.estado_libro = 1 AND EXISTS (SELECT 1 FROM Ejemplar e " &
                                  "WHERE e.id_libro = l.id_libro AND e.estado_ejemplar = 1 " &
                                  "AND NOT EXISTS (SELECT 1 FROM Prestamo p WHERE p.id_ejemplar = e.id_ejemplar AND " & ejemplarDAO.PrestamoOcupaEjemplarSql & ")) " &
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
            Dim query As String = "SELECT l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.stock_total, l.publico_libro, l.estado_libro, " &
                                  "(SELECT STRING_AGG(a.nombre_autor, ', ') FROM DetalleLibro dl INNER JOIN Autor a ON dl.id_autor = a.id_autor WHERE dl.id_libro = l.id_libro) AS autores, " &
                                  "(SELECT STRING_AGG(c.nombre_categoria, ', ') FROM DetalleCategoria dc INNER JOIN Categoria c ON dc.id_categoria = c.id_categoria WHERE dc.id_libro = l.id_libro) AS categorias " &
                                  "FROM Libro l ORDER BY l.titulo_libro"

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
                            .Autor = If(rs.IsDBNull(rs.GetOrdinal("autores")), "", rs.GetString(rs.GetOrdinal("autores"))),
                            .Categoria = If(rs.IsDBNull(rs.GetOrdinal("categorias")), "", rs.GetString(rs.GetOrdinal("categorias")))
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
        Using cn = con.CrearConexionIndependiente(), tx = cn.BeginTransaction(IsolationLevel.Serializable)
            ValidarDesactivacionLibro(cn, tx, idLibro)

            Dim sqlUpdate As String = "UPDATE Libro SET estado_libro = 0 WHERE id_libro = @idLibro"
            Using cmdUpdate As New SqlCommand(sqlUpdate, cn, tx)
                cmdUpdate.Parameters.AddWithValue("@idLibro", idLibro)
                Dim actualizado = cmdUpdate.ExecuteNonQuery() > 0
                tx.Commit()
                Return actualizado
            End Using
        End Using
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
            If Not estado Then ValidarDesactivacionLibro(cn, tx, idLibro, True)
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

    Public Function agregarLibroCompleto(titulo As String, editorial As String, anoPublicacion As Short, publico As String,
                                         estado As Boolean, idsAutores As IList(Of Integer), idsCategorias As IList(Of Integer),
                                         cantidadEjemplares As Integer) As Boolean
        If idsAutores Is Nothing OrElse idsAutores.Count = 0 Then Throw New ArgumentException("El libro debe tener al menos un autor.")
        If idsCategorias Is Nothing OrElse idsCategorias.Count = 0 Then Throw New ArgumentException("El libro debe tener al menos una categoría.")
        If cantidadEjemplares < 0 Then Throw New ArgumentOutOfRangeException(NameOf(cantidadEjemplares))

        con.IniciarTransaccion()
        Dim cn As SqlConnection = con.ObtenerConexion()
        Dim tx As SqlTransaction = con.TransaccionActual
        Try
            Using cmd As New SqlCommand("SELECT COUNT(1) FROM Libro WHERE UPPER(LTRIM(RTRIM(titulo_libro))) = UPPER(LTRIM(RTRIM(@titulo)))", cn, tx)
                cmd.Parameters.AddWithValue("@titulo", titulo)
                If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then Throw New InvalidOperationException("Ya existe un libro con ese título.")
            End Using
            Dim idLibro As Integer
            Dim sqlLibro As String = "INSERT INTO Libro (titulo_libro, editorial_libro, ano_publicacion, stock_total, estado_libro, publico_libro) " &
                                     "OUTPUT INSERTED.id_libro VALUES (@titulo, @editorial, @ano, 0, @estado, @publico)"
            Using cmd As New SqlCommand(sqlLibro, cn, tx)
                cmd.Parameters.AddWithValue("@titulo", titulo.Trim())
                cmd.Parameters.AddWithValue("@editorial", editorial.Trim())
                cmd.Parameters.AddWithValue("@ano", anoPublicacion)
                cmd.Parameters.AddWithValue("@estado", estado)
                cmd.Parameters.AddWithValue("@publico", publico)
                idLibro = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            GuardarRelacionesLibro(cn, tx, idLibro, idsAutores, idsCategorias)
            For i As Integer = 1 To cantidadEjemplares
                Using cmd As New SqlCommand("INSERT INTO Ejemplar (estado_ejemplar, id_libro) VALUES (1, @idLibro)", cn, tx)
                    cmd.Parameters.AddWithValue("@idLibro", idLibro)
                    cmd.ExecuteNonQuery()
                End Using
            Next
            Using cmd As New SqlCommand("UPDATE Libro SET stock_total = @stock WHERE id_libro = @idLibro", cn, tx)
                cmd.Parameters.AddWithValue("@stock", cantidadEjemplares)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                cmd.ExecuteNonQuery()
            End Using

            con.ConfirmarTransaccion()
            Return True
        Catch
            con.CancelarTransaccion()
            Throw
        End Try
    End Function

    Public Function actualizarLibroCompleto(idLibro As Integer, titulo As String, editorial As String, anoPublicacion As Short,
                                            publico As String, estado As Boolean, idsAutores As IList(Of Integer),
                                            idsCategorias As IList(Of Integer)) As Boolean
        If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
        If idsAutores Is Nothing OrElse idsAutores.Count = 0 Then Throw New ArgumentException("El libro debe tener al menos un autor.")
        If idsCategorias Is Nothing OrElse idsCategorias.Count = 0 Then Throw New ArgumentException("El libro debe tener al menos una categoría.")

        con.IniciarTransaccion()
        Dim cn As SqlConnection = con.ObtenerConexion()
        Dim tx As SqlTransaction = con.TransaccionActual
        Try
            Using cmd As New SqlCommand("SELECT COUNT(1) FROM Libro WHERE id_libro <> @idLibro AND UPPER(LTRIM(RTRIM(titulo_libro))) = UPPER(LTRIM(RTRIM(@titulo)))", cn, tx)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                cmd.Parameters.AddWithValue("@titulo", titulo)
                If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then Throw New InvalidOperationException("Ya existe un libro con ese título.")
            End Using
            If Not estado Then ValidarDesactivacionLibro(cn, tx, idLibro, True)
            Using cmd As New SqlCommand("UPDATE Libro SET titulo_libro = @titulo, editorial_libro = @editorial, ano_publicacion = @ano, " &
                                        "publico_libro = @publico, estado_libro = @estado WHERE id_libro = @idLibro", cn, tx)
                cmd.Parameters.AddWithValue("@titulo", titulo.Trim())
                cmd.Parameters.AddWithValue("@editorial", editorial.Trim())
                cmd.Parameters.AddWithValue("@ano", anoPublicacion)
                cmd.Parameters.AddWithValue("@publico", publico)
                cmd.Parameters.AddWithValue("@estado", estado)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                If cmd.ExecuteNonQuery() = 0 Then Throw New InvalidOperationException("No se encontró el libro seleccionado.")
            End Using

            Using cmd As New SqlCommand("DELETE FROM DetalleLibro WHERE id_libro = @idLibro", cn, tx)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                cmd.ExecuteNonQuery()
            End Using
            Using cmd As New SqlCommand("DELETE FROM DetalleCategoria WHERE id_libro = @idLibro", cn, tx)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                cmd.ExecuteNonQuery()
            End Using
            GuardarRelacionesLibro(cn, tx, idLibro, idsAutores, idsCategorias)
            con.ConfirmarTransaccion()
            Return True
        Catch
            con.CancelarTransaccion()
            Throw
        End Try
    End Function

    Private Shared Sub ValidarDesactivacionLibro(cn As SqlConnection, tx As SqlTransaction, idLibro As Integer,
                                                  Optional soloLibroActivo As Boolean = False)
        Using cmd As New SqlCommand("SELECT estado_libro FROM Libro WITH (UPDLOCK, HOLDLOCK) WHERE id_libro = @idLibro", cn, tx)
            cmd.Parameters.AddWithValue("@idLibro", idLibro)
            Dim estado = cmd.ExecuteScalar()
            If soloLibroActivo AndAlso (estado Is Nothing OrElse Not CBool(estado)) Then Return
        End Using
        Dim sql As String = "SELECT COUNT(*) FROM Prestamo p INNER JOIN Ejemplar e ON p.id_ejemplar = e.id_ejemplar WHERE e.id_libro = @idLibro"
        If soloLibroActivo Then sql &= " AND EXISTS (SELECT 1 FROM Libro l WHERE l.id_libro = @idLibro AND l.estado_libro = 1)"
        Using cmd As New SqlCommand(sql, cn, tx)
            cmd.Parameters.AddWithValue("@idLibro", idLibro)
            If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                Throw New InvalidOperationException("No se puede desactivar el libro porque tiene préstamos registrados.")
            End If
        End Using
    End Sub

    Private Shared Sub GuardarRelacionesLibro(cn As SqlConnection, tx As SqlTransaction, idLibro As Integer,
                                               idsAutores As IList(Of Integer), idsCategorias As IList(Of Integer))
        For Each idAutor As Integer In idsAutores.Distinct()
            Using cmd As New SqlCommand("INSERT INTO DetalleLibro (id_libro, id_autor) VALUES (@idLibro, @idAutor)", cn, tx)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                cmd.Parameters.AddWithValue("@idAutor", idAutor)
                cmd.ExecuteNonQuery()
            End Using
        Next
        For Each idCategoria As Integer In idsCategorias.Distinct()
            Using cmd As New SqlCommand("INSERT INTO DetalleCategoria (id_libro, id_categoria) VALUES (@idLibro, @idCategoria)", cn, tx)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub
End Class
