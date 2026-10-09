Imports System.Data
Imports capaDatos

Public Class libroNegocio
    Private ReadOnly dao As New libroDAO()
    Private ReadOnly reglas As IReglasLibro = New reglasLibroNegocio()

    Public Function listarDisponibles(Optional idLector As Integer = 0) As List(Of Libro)
        Return dao.listarDisponibles(idLector)
    End Function

    Public Function buscar(titulo As String, autor As String, categoria As String) As List(Of Libro)
        Return dao.buscar(titulo, autor, categoria)
    End Function

    Public Function listarTodos() As List(Of Libro)
        Return dao.listarTodos()
    End Function

    Public Function eliminarLibro(idLibro As Integer) As Boolean
        seguridadNegocio.ExigirPersonal()
        Return dao.eliminarLibro(idLibro, reglas)
    End Function

    Public Function agregarLibro(titulo As String, editorial As String, anoPublicacion As Short, publico As String, estado As Boolean, idAutor As Integer, idCategoria As Integer) As Boolean
        seguridadNegocio.ExigirPersonal()
        Return agregarLibroCompleto(titulo, editorial, anoPublicacion, publico, estado, New List(Of Integer) From {idAutor}, New List(Of Integer) From {idCategoria}, 0)
    End Function

    Public Function actualizarLibro(idLibro As Integer, titulo As String, editorial As String, anoPublicacion As Short, publico As String, estado As Boolean, idAutor As Integer, idCategoria As Integer) As Boolean
        seguridadNegocio.ExigirPersonal()
        Return actualizarLibroCompleto(idLibro, titulo, editorial, anoPublicacion, publico, estado, New List(Of Integer) From {idAutor}, New List(Of Integer) From {idCategoria})
    End Function

    Public Function agregarLibroCompleto(titulo As String, editorial As String, anoPublicacion As Short, publico As String,
                                         estado As Boolean, idsAutores As IList(Of Integer), idsCategorias As IList(Of Integer),
                                         cantidadEjemplares As Integer) As Boolean
        ValidarLibro(titulo, editorial, idsAutores, idsCategorias)
        If String.IsNullOrWhiteSpace(publico) Then Throw New ArgumentException("Selecciona el público objetivo.")
        If cantidadEjemplares < 0 OrElse cantidadEjemplares > 500 Then
            Throw New ArgumentOutOfRangeException(NameOf(cantidadEjemplares), "La cantidad de ejemplares debe estar entre 0 y 500.")
        End If
        seguridadNegocio.ExigirPersonal()
        Return dao.agregarLibroCompleto(titulo, editorial, anoPublicacion, publico, estado, idsAutores, idsCategorias, cantidadEjemplares, reglas)
    End Function

    Public Function actualizarLibroCompleto(idLibro As Integer, titulo As String, editorial As String, anoPublicacion As Short,
                                            publico As String, estado As Boolean, idsAutores As IList(Of Integer),
                                            idsCategorias As IList(Of Integer)) As Boolean
        If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
        ValidarLibro(titulo, editorial, idsAutores, idsCategorias)
        seguridadNegocio.ExigirPersonal()
        Return dao.actualizarLibroCompleto(idLibro, titulo, editorial, anoPublicacion, publico, estado, idsAutores, idsCategorias, reglas)
    End Function

    Public Function ResolverAutores(nombres As IEnumerable(Of String)) As List(Of Integer)
        Dim autores As List(Of Autor) = New autorNegocio().listarTodos()
        Dim ids As New List(Of Integer)()
        For Each nombre As String In nombres
            Dim autor As Autor = autores.FirstOrDefault(Function(x) String.Equals(x.NombreAutor.Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase))
            If autor Is Nothing Then Throw New InvalidOperationException("No existe el autor '" & nombre & "'. Regístralo primero en el mantenimiento de autores.")
            ids.Add(autor.IdAutor)
        Next
        Return ids.Distinct().ToList()
    End Function

    Public Function ResolverCategorias(nombres As IEnumerable(Of String)) As List(Of Integer)
        Dim tabla As DataTable = New categoriaNegocio().listarCategoria()
        Dim ids As New List(Of Integer)()
        For Each nombre As String In nombres
            Dim fila As DataRow = tabla.AsEnumerable().FirstOrDefault(Function(x) String.Equals(x("nombre_categoria").ToString().Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase) AndAlso
                                                                       String.Equals(x("estado").ToString(), "Activo", StringComparison.OrdinalIgnoreCase))
            If fila Is Nothing Then Throw New InvalidOperationException("No existe una categoría activa llamada '" & nombre & "'. Regístrala o actívala primero.")
            ids.Add(CInt(fila("id_categoria")))
        Next
        Return ids.Distinct().ToList()
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
