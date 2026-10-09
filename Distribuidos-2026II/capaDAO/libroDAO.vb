Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class libroDAO
    ' Instancia única de tu clase de conexión
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    Public Function listarDisponibles(Optional idLector As Integer = 0) As List(Of Libro)
        Try
            Dim lista As New List(Of Libro)()
            Dim cn As SqlConnection = con.ObtenerConexion() ' Ya viene abierta

            Try
                DisponibilidadReserva.ExigirEsquema(cn)
                Dim query As String = "SELECT l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.stock_total, l.estado_libro, l.publico_libro, " &
                                      "(SELECT STRING_AGG(a.nombre_autor, ', ') FROM DetalleLibro dl INNER JOIN Autor a ON a.id_autor = dl.id_autor WHERE dl.id_libro = l.id_libro) AS autores, " &
                                      "(SELECT STRING_AGG(c.nombre_categoria, ', ') FROM DetalleCategoria dc INNER JOIN Categoria c ON c.id_categoria = dc.id_categoria WHERE dc.id_libro = l.id_libro) AS categorias " &
                                      "FROM Libro l " &
                                      "INNER JOIN dbo.vw_DisponibilidadLibro d ON d.id_libro = l.id_libro " &
                                      "WHERE l.estado_libro = 1 AND d.ejemplares_libres > 0 AND (d.disponibles > 0 OR EXISTS " &
                                      "(SELECT 1 FROM SolicitudPrestamo s JOIN DetalleSolicitudPrestamo ds ON ds.id_solicitud=s.id_solicitud WHERE ds.id_libro=l.id_libro AND s.id_usuario=@lector AND " & DisponibilidadReserva.VigenteSql & ")) " &
                                      "ORDER BY l.titulo_libro"

                Using cmd As New SqlCommand(query, cn)
                    If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                    cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector

                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim objLibro As New Libro() With {
                                .IdLibro = dr.GetInt32(dr.GetOrdinal("id_libro")),
                                .TituloLibro = dr.GetString(dr.GetOrdinal("titulo_libro")),
                                .EditorialLibro = If(dr.IsDBNull(dr.GetOrdinal("editorial_libro")), Nothing, dr.GetString(dr.GetOrdinal("editorial_libro"))),
                                .StockTotal = dr.GetInt32(dr.GetOrdinal("stock_total")),
                                .EstadoLibro = dr.GetBoolean(dr.GetOrdinal("estado_libro")),
                                .PublicoLibro = If(dr.IsDBNull(dr.GetOrdinal("publico_libro")), Nothing, dr.GetString(dr.GetOrdinal("publico_libro"))),
                                .Autor = If(dr.IsDBNull(dr.GetOrdinal("autores")), Nothing, dr.GetString(dr.GetOrdinal("autores"))),
                                .Categoria = If(dr.IsDBNull(dr.GetOrdinal("categorias")), Nothing, dr.GetString(dr.GetOrdinal("categorias")))
                            }

                            If Not dr.IsDBNull(dr.GetOrdinal("ano_publicacion")) Then
                                objLibro.AnoPublicacion = dr.GetInt16(dr.GetOrdinal("ano_publicacion"))
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
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "libroDAO.listarDisponibles")
        End Try
    End Function

    Public Function buscar(titulo As String, autor As String, categoria As String) As List(Of Libro)
        Try
            Dim lista As New List(Of Libro)()
            Dim cn As SqlConnection = con.ObtenerConexion()

            Try
                Dim query As String = "SELECT l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.stock_total, l.estado_libro, l.publico_libro, " &
                                    "STRING_AGG(a.nombre_autor, ', ') AS autores, " &
                                    "STRING_AGG(c.nombre_categoria, ', ') AS categorias " &
                                    "FROM Libro l " &
                                    "INNER JOIN DetalleLibro dl ON l.id_libro = dl.id_libro " &
                                    "INNER JOIN Autor a ON dl.id_autor = a.id_autor " &
                                    "INNER JOIN DetalleCategoria dc ON l.id_libro = dc.id_libro " &
                                    "INNER JOIN Categoria c ON dc.id_categoria = c.id_categoria " &
                                    "WHERE l.estado_libro = 1 AND l.stock_total > 0 AND UPPER(l.titulo_libro) LIKE UPPER(@titulo) "

                If autor <> "Todos" Then query &= " AND a.nombre_autor = @autor "
                If categoria <> "Todas" Then query &= " AND c.nombre_categoria = @categoria "

                query &= "GROUP BY l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.stock_total, l.estado_libro, l.publico_libro ORDER BY l.titulo_libro"

                Using cmd As New SqlCommand(query, cn)
                    If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual

                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar, -1).Value = "%" & titulo & "%"
                    If autor <> "Todos" Then cmd.Parameters.Add("@autor", SqlDbType.VarChar, -1).Value = autor
                    If categoria <> "Todas" Then cmd.Parameters.Add("@categoria", SqlDbType.VarChar, -1).Value = categoria

                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim objLibro As New Libro() With {
                                .IdLibro = dr.GetInt32(dr.GetOrdinal("id_libro")),
                                .TituloLibro = dr.GetString(dr.GetOrdinal("titulo_libro")),
                                .EditorialLibro = If(dr.IsDBNull(dr.GetOrdinal("editorial_libro")), Nothing, dr.GetString(dr.GetOrdinal("editorial_libro"))),
                                .StockTotal = dr.GetInt32(dr.GetOrdinal("stock_total")),
                                .EstadoLibro = dr.GetBoolean(dr.GetOrdinal("estado_libro")),
                                .PublicoLibro = If(dr.IsDBNull(dr.GetOrdinal("publico_libro")), Nothing, dr.GetString(dr.GetOrdinal("publico_libro"))),
                                .Autor = If(dr.IsDBNull(dr.GetOrdinal("autores")), Nothing, dr.GetString(dr.GetOrdinal("autores"))),
                                .Categoria = If(dr.IsDBNull(dr.GetOrdinal("categorias")), Nothing, dr.GetString(dr.GetOrdinal("categorias")))
                            }

                            If Not dr.IsDBNull(dr.GetOrdinal("ano_publicacion")) Then
                                objLibro.AnoPublicacion = dr.GetInt16(dr.GetOrdinal("ano_publicacion"))
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
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "libroDAO.buscar")
        End Try
    End Function

    Public Function listarTodos() As List(Of Libro)
        Try
            Dim lista As New List(Of Libro)()
            Dim cn As SqlConnection = con.ObtenerConexion()

            Try
                Dim query As String = "SELECT l.id_libro, l.titulo_libro, l.editorial_libro, l.ano_publicacion, l.stock_total, l.publico_libro, l.estado_libro, " &
                                      "(SELECT STRING_AGG(a.nombre_autor, ', ') FROM DetalleLibro dl INNER JOIN Autor a ON dl.id_autor = a.id_autor WHERE dl.id_libro = l.id_libro) AS autores, " &
                                      "(SELECT STRING_AGG(c.nombre_categoria, ', ') FROM DetalleCategoria dc INNER JOIN Categoria c ON dc.id_categoria = c.id_categoria WHERE dc.id_libro = l.id_libro) AS categorias " &
                                      "FROM Libro l ORDER BY l.titulo_libro"

                Using cmd As New SqlCommand(query, cn)
                    If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual

                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim objLibro As New Libro() With {
                                .IdLibro = dr.GetInt32(dr.GetOrdinal("id_libro")),
                                .TituloLibro = dr.GetString(dr.GetOrdinal("titulo_libro")),
                                .EditorialLibro = If(dr.IsDBNull(dr.GetOrdinal("editorial_libro")), Nothing, dr.GetString(dr.GetOrdinal("editorial_libro"))),
                                .StockTotal = dr.GetInt32(dr.GetOrdinal("stock_total")),
                                .EstadoLibro = dr.GetBoolean(dr.GetOrdinal("estado_libro")),
                                .PublicoLibro = If(dr.IsDBNull(dr.GetOrdinal("publico_libro")), Nothing, dr.GetString(dr.GetOrdinal("publico_libro"))),
                                .Autor = If(dr.IsDBNull(dr.GetOrdinal("autores")), "", dr.GetString(dr.GetOrdinal("autores"))),
                                .Categoria = If(dr.IsDBNull(dr.GetOrdinal("categorias")), "", dr.GetString(dr.GetOrdinal("categorias")))
                            }

                            If Not dr.IsDBNull(dr.GetOrdinal("ano_publicacion")) Then
                                objLibro.AnoPublicacion = dr.GetInt16(dr.GetOrdinal("ano_publicacion"))
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
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "libroDAO.listarTodos")
        End Try
    End Function

    Public Function eliminarLibro(idLibro As Integer, reglas As IReglasLibro) As Boolean
        Try
            Using cn As SqlConnection = con.CrearConexionIndependiente(), tx = cn.BeginTransaction(IsolationLevel.Serializable)
                LeerDesactivacionLibro(cn, tx, idLibro, reglas)

                Dim sqlUpdate As String = "UPDATE Libro SET estado_libro = 0 WHERE id_libro = @idLibro"
                Using cmdUpdate As New SqlCommand(sqlUpdate, cn, tx)
                    cmdUpdate.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                    Dim actualizado = cmdUpdate.ExecuteNonQuery() > 0
                    tx.Commit()
                    Return actualizado
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "libroDAO.eliminarLibro")
        End Try
    End Function

    Public Function agregarLibroCompleto(titulo As String, editorial As String, anoPublicacion As Short, publico As String,
                                         estado As Boolean, idsAutores As IList(Of Integer), idsCategorias As IList(Of Integer),
                                         cantidadEjemplares As Integer, reglas As IReglasLibro) As Boolean
        Try

            con.IniciarTransaccion()
            Dim cn As SqlConnection = con.ObtenerConexion()
            Dim tx As SqlTransaction = con.TransaccionActual
            Try
                Dim queryConsulta1 As String = "SELECT COUNT(1) FROM Libro WHERE UPPER(LTRIM(RTRIM(titulo_libro))) = UPPER(LTRIM(RTRIM(@titulo)))"
                Using cmd As New SqlCommand(queryConsulta1, cn, tx)
                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar, -1).Value = titulo
                    reglas.ValidarTituloDuplicado(Convert.ToInt32(cmd.ExecuteScalar()))
                End Using
                Dim idLibro As Integer
                Dim sqlLibro As String = "INSERT INTO Libro (titulo_libro, editorial_libro, ano_publicacion, stock_total, estado_libro, publico_libro) " &
                                         "OUTPUT INSERTED.id_libro VALUES (@titulo, @editorial, @ano, 0, @estado, @publico)"
                Using cmd As New SqlCommand(sqlLibro, cn, tx)
                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar, -1).Value = titulo.Trim()
                    cmd.Parameters.Add("@editorial", SqlDbType.VarChar, -1).Value = editorial.Trim()
                    cmd.Parameters.Add("@ano", SqlDbType.SmallInt).Value = anoPublicacion
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado
                    cmd.Parameters.Add("@publico", SqlDbType.VarChar, -1).Value = publico
                    idLibro = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                GuardarRelacionesLibro(cn, tx, idLibro, idsAutores, idsCategorias)
                For i As Integer = 1 To cantidadEjemplares
                    Dim queryConsulta2 As String = "INSERT INTO Ejemplar (estado_ejemplar, id_libro) VALUES (1, @idLibro)"
                    Using cmd As New SqlCommand(queryConsulta2, cn, tx)
                        cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                        cmd.ExecuteNonQuery()
                    End Using
                Next
                Dim queryConsulta3 As String = "UPDATE Libro SET stock_total = @stock WHERE id_libro = @idLibro"
                Using cmd As New SqlCommand(queryConsulta3, cn, tx)
                    cmd.Parameters.Add("@stock", SqlDbType.Int).Value = cantidadEjemplares
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                    cmd.ExecuteNonQuery()
                End Using

                con.ConfirmarTransaccion()
                Return True
            Catch
                con.CancelarTransaccion()
                Throw
            End Try
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "libroDAO.agregarLibroCompleto")
        End Try
    End Function

    Public Function actualizarLibroCompleto(idLibro As Integer, titulo As String, editorial As String, anoPublicacion As Short,
                                            publico As String, estado As Boolean, idsAutores As IList(Of Integer),
                                            idsCategorias As IList(Of Integer), reglas As IReglasLibro) As Boolean
        Try

            con.IniciarTransaccion()
            Dim cn As SqlConnection = con.ObtenerConexion()
            Dim tx As SqlTransaction = con.TransaccionActual
            Try
                Dim queryConsulta4 As String = "SELECT COUNT(1) FROM Libro WHERE id_libro <> @idLibro AND UPPER(LTRIM(RTRIM(titulo_libro))) = UPPER(LTRIM(RTRIM(@titulo)))"
                Using cmd As New SqlCommand(queryConsulta4, cn, tx)
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar, -1).Value = titulo
                    reglas.ValidarTituloDuplicado(Convert.ToInt32(cmd.ExecuteScalar()))
                End Using
                If Not estado Then LeerDesactivacionLibro(cn, tx, idLibro, reglas, True)
                Dim queryConsulta5 As String = "UPDATE Libro SET titulo_libro = @titulo, editorial_libro = @editorial, ano_publicacion = @ano, " &
                                            "publico_libro = @publico, estado_libro = @estado WHERE id_libro = @idLibro"
                Using cmd As New SqlCommand(queryConsulta5, cn, tx)
                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar, -1).Value = titulo.Trim()
                    cmd.Parameters.Add("@editorial", SqlDbType.VarChar, -1).Value = editorial.Trim()
                    cmd.Parameters.Add("@ano", SqlDbType.SmallInt).Value = anoPublicacion
                    cmd.Parameters.Add("@publico", SqlDbType.VarChar, -1).Value = publico
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                    If cmd.ExecuteNonQuery() = 0 Then Throw New InvalidOperationException("No se encontró el libro seleccionado.")
                End Using

                Dim queryConsulta6 As String = "DELETE FROM DetalleLibro WHERE id_libro = @idLibro"
                Using cmd As New SqlCommand(queryConsulta6, cn, tx)
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                    cmd.ExecuteNonQuery()
                End Using
                Dim queryConsulta7 As String = "DELETE FROM DetalleCategoria WHERE id_libro = @idLibro"
                Using cmd As New SqlCommand(queryConsulta7, cn, tx)
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                    cmd.ExecuteNonQuery()
                End Using
                GuardarRelacionesLibro(cn, tx, idLibro, idsAutores, idsCategorias)
                con.ConfirmarTransaccion()
                Return True
            Catch
                con.CancelarTransaccion()
                Throw
            End Try
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "libroDAO.actualizarLibroCompleto")
        End Try
    End Function

    Private Shared Sub LeerDesactivacionLibro(cn As SqlConnection, tx As SqlTransaction, idLibro As Integer, reglas As IReglasLibro,
                                              Optional soloLibroActivo As Boolean = False)
        Try
            Dim query As String = "SELECT estado_libro FROM Libro WITH (UPDLOCK,HOLDLOCK) WHERE id_libro=@idLibro"
            Dim estado As Boolean? = Nothing
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value=idLibro
                Dim valor=cmd.ExecuteScalar()
                If valor IsNot Nothing Then estado=CBool(valor)
            End Using
            Dim prestamos, reservas As Integer
            query = "SELECT COUNT(*) FROM Prestamo p WITH (HOLDLOCK) JOIN Ejemplar e WITH (HOLDLOCK) ON p.id_ejemplar=e.id_ejemplar WHERE e.id_libro=@idLibro"
            Using cmd As New SqlCommand(query,cn,tx)
                cmd.Parameters.Add("@idLibro",SqlDbType.Int).Value=idLibro
                prestamos=CInt(cmd.ExecuteScalar())
            End Using
            query = "SELECT COUNT(*) FROM SolicitudPrestamo s WITH (HOLDLOCK) JOIN DetalleSolicitudPrestamo ds WITH (HOLDLOCK) ON ds.id_solicitud=s.id_solicitud WHERE ds.id_libro=@idLibro AND " & DisponibilidadReserva.VigenteSql
            Using cmd As New SqlCommand(query,cn,tx)
                cmd.Parameters.Add("@idLibro",SqlDbType.Int).Value=idLibro
                reservas=CInt(cmd.ExecuteScalar())
            End Using
            reglas.ValidarDesactivacion(estado,prestamos,reservas,soloLibroActivo)
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "libroDAO.LeerDesactivacionLibro")
        End Try
    End Sub

    Private Shared Sub GuardarRelacionesLibro(cn As SqlConnection, tx As SqlTransaction, idLibro As Integer,
                                               idsAutores As IList(Of Integer), idsCategorias As IList(Of Integer))
        Try
            For Each idAutor As Integer In idsAutores.Distinct()
                Dim queryConsulta8 As String = "INSERT INTO DetalleLibro (id_libro, id_autor) VALUES (@idLibro, @idAutor)"
                Using cmd As New SqlCommand(queryConsulta8, cn, tx)
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                    cmd.Parameters.Add("@idAutor", SqlDbType.Int).Value = idAutor
                    cmd.ExecuteNonQuery()
                End Using
            Next
            For Each idCategoria As Integer In idsCategorias.Distinct()
                Dim queryConsulta9 As String = "INSERT INTO DetalleCategoria (id_libro, id_categoria) VALUES (@idLibro, @idCategoria)"
                Using cmd As New SqlCommand(queryConsulta9, cn, tx)
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                    cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria
                    cmd.ExecuteNonQuery()
                End Using
            Next
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "libroDAO.GuardarRelacionesLibro")
        End Try
    End Sub
End Class
