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
End Class