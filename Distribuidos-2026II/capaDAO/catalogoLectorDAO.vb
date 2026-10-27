Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class catalogoLectorDAO
    Public Function listar() As List(Of Libro)
        Try
            Dim libros As New List(Of Libro)()
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                DisponibilidadReserva.ExigirEsquema(cn)
                Dim query As String = "SELECT l.*,v.disponibles," &
                    "(SELECT STRING_AGG(a.nombre_autor,', ') FROM DetalleLibro d JOIN Autor a ON a.id_autor=d.id_autor WHERE d.id_libro=l.id_libro) AS autores," &
                    "(SELECT STRING_AGG(c.nombre_categoria,', ') FROM DetalleCategoria d JOIN Categoria c ON c.id_categoria=d.id_categoria WHERE d.id_libro=l.id_libro AND c.estado=1) AS categorias " &
                    "FROM Libro l JOIN vw_DisponibilidadLibro v ON v.id_libro=l.id_libro WHERE l.estado_libro=1 ORDER BY l.titulo_libro"
                Using cmd As New SqlCommand(query, cn)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            libros.Add(New Libro With {.IdLibro = CInt(dr("id_libro")), .TituloLibro = CStr(dr("titulo_libro")),
                                .EditorialLibro = If(IsDBNull(dr("editorial_libro")), "", CStr(dr("editorial_libro"))),
                                .AnoPublicacion = If(IsDBNull(dr("ano_publicacion")), CType(Nothing, Integer?), CInt(dr("ano_publicacion"))),
                                .Autor = If(IsDBNull(dr("autores")), "", CStr(dr("autores"))),
                                .Categoria = If(IsDBNull(dr("categorias")), "", CStr(dr("categorias"))),
                                .Disponibles = CInt(dr("disponibles")), .EstadoLibro = True})
                        End While
                    End Using
                End Using
            End Using
            Return libros
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "catalogoLectorDAO.listar")
        End Try
    End Function
End Class
