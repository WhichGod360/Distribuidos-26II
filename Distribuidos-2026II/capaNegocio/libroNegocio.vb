Imports capaDatos

Public Class libroNegocio
    Private ReadOnly dao As New libroDAO()

    Public Function listarDisponibles() As List(Of Libro)
        Return dao.listarDisponibles()
    End Function

    Public Function buscar(titulo As String, autor As String, categoria As String) As List(Of Libro)
        Return dao.buscar(titulo, autor, categoria)
    End Function

    Public Function listarTodos() As List(Of Libro)
        Return dao.listarTodos()
    End Function

    Public Function eliminarLibro(idLibro As Integer) As Boolean
        Return dao.eliminarLibro(idLibro)
    End Function

    Public Function agregarLibro(titulo As String, editorial As String, anoPublicacion As Short, publico As String, estado As Boolean, idAutor As Integer, idCategoria As Integer) As Boolean
        Return dao.agregarLibro(titulo, editorial, anoPublicacion, publico, estado, idAutor, idCategoria)
    End Function

    Public Function actualizarLibro(idLibro As Integer, titulo As String, editorial As String, anoPublicacion As Short, publico As String, estado As Boolean, idAutor As Integer, idCategoria As Integer) As Boolean
        Return dao.actualizarLibro(idLibro, titulo, editorial, anoPublicacion, publico, estado, idAutor, idCategoria)
    End Function

    Public Function agregarLibroCompleto(titulo As String, editorial As String, anoPublicacion As Short, publico As String,
                                         estado As Boolean, idsAutores As IList(Of Integer), idsCategorias As IList(Of Integer),
                                         cantidadEjemplares As Integer) As Boolean
        ValidarLibro(titulo, editorial, idsAutores, idsCategorias)
        If cantidadEjemplares < 0 OrElse cantidadEjemplares > 500 Then
            Throw New ArgumentOutOfRangeException(NameOf(cantidadEjemplares), "La cantidad de ejemplares debe estar entre 0 y 500.")
        End If
        Return dao.agregarLibroCompleto(titulo, editorial, anoPublicacion, publico, estado, idsAutores, idsCategorias, cantidadEjemplares)
    End Function

    Public Function actualizarLibroCompleto(idLibro As Integer, titulo As String, editorial As String, anoPublicacion As Short,
                                            publico As String, estado As Boolean, idsAutores As IList(Of Integer),
                                            idsCategorias As IList(Of Integer)) As Boolean
        If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
        ValidarLibro(titulo, editorial, idsAutores, idsCategorias)
        Return dao.actualizarLibroCompleto(idLibro, titulo, editorial, anoPublicacion, publico, estado, idsAutores, idsCategorias)
    End Function

    Private Shared Sub ValidarLibro(titulo As String, editorial As String, idsAutores As IList(Of Integer), idsCategorias As IList(Of Integer))
        If String.IsNullOrWhiteSpace(titulo) Then Throw New ArgumentException("El título es obligatorio.")
        If String.IsNullOrWhiteSpace(editorial) Then Throw New ArgumentException("La editorial es obligatoria.")
        If idsAutores Is Nothing OrElse idsAutores.Count = 0 Then Throw New ArgumentException("Selecciona al menos un autor.")
        If idsCategorias Is Nothing OrElse idsCategorias.Count = 0 Then Throw New ArgumentException("Selecciona al menos una categoría.")
        If idsAutores.Any(Function(id) id <= 0) OrElse idsCategorias.Any(Function(id) id <= 0) Then
            Throw New ArgumentException("La selección de autores y categorías no es válida.")
        End If
    End Sub
End Class
