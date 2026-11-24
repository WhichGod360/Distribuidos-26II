Imports System.Data
Imports capaDatos

Public Class libroNegocio
    Private ReadOnly dao As New libroDAO()
    Private ReadOnly reglas As IReglasLibro = New reglasLibroNegocio()

    Public Function listarDisponibles(Optional idLector As Integer = 0) As List(Of Libro)
        Try
            If idLector < 0 Then Throw New ArgumentException("El lector seleccionado no es válido.")
            Return dao.listarDisponibles(idLector)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar los libros.", ex)
        End Try
    End Function

    Public Function buscar(titulo As String, autor As String, categoria As String) As List(Of Libro)
        Try
            Return dao.buscar(titulo, autor, categoria)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar los libros.", ex)
        End Try
    End Function

    Public Function listarTodos() As List(Of Libro)
        Try
            Return dao.listarTodos()
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo listar los libros.", ex)
        End Try
    End Function

    Public Function eliminarLibro(idLibro As Integer) As Boolean
        Try
            If idLibro <= 0 Then Throw New ArgumentException("Selecciona un libro válido.")
            Dim operador = seguridadNegocio.ExigirPersonal()
            Return dao.eliminarLibro(idLibro, reglas, operador)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo desactivar el libro.", ex)
        End Try
    End Function

    Public Function agregarLibro(titulo As String, editorial As String, anoPublicacion As Short, publico As String, estado As Boolean, idAutor As Integer, idCategoria As Integer) As Boolean
        Try
            seguridadNegocio.ExigirPersonal()
            Return agregarLibroCompleto(titulo, editorial, anoPublicacion, publico, estado, New List(Of Integer) From {idAutor}, New List(Of Integer) From {idCategoria}, 0)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo registrar el libro.", ex)
        End Try
    End Function

    Public Function actualizarLibro(idLibro As Integer, titulo As String, editorial As String, anoPublicacion As Short, publico As String, estado As Boolean, idAutor As Integer, idCategoria As Integer) As Boolean
        Try
            seguridadNegocio.ExigirPersonal()
            Return actualizarLibroCompleto(idLibro, titulo, editorial, anoPublicacion, publico, estado, New List(Of Integer) From {idAutor}, New List(Of Integer) From {idCategoria})
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo actualizar el libro.", ex)
        End Try
    End Function

    Public Function agregarLibroCompleto(titulo As String, editorial As String, anoPublicacion As Short, publico As String,
                                         estado As Boolean, idsAutores As IList(Of Integer), idsCategorias As IList(Of Integer),
                                         cantidadEjemplares As Integer) As Boolean
        Try
            ValidarLibro(titulo, editorial, anoPublicacion, publico, idsAutores, idsCategorias)
            If cantidadEjemplares < 0 OrElse cantidadEjemplares > 500 Then
                Throw New ArgumentOutOfRangeException(NameOf(cantidadEjemplares), "La cantidad de ejemplares debe estar entre 0 y 500.")
            End If
            Dim operador = seguridadNegocio.ExigirPersonal()
            Return dao.agregarLibroCompleto(titulo, editorial, anoPublicacion, publico.Trim(), estado, idsAutores, idsCategorias, cantidadEjemplares, reglas, operador)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo registrar el libro.", ex)
        End Try
    End Function

    Public Function actualizarLibroCompleto(idLibro As Integer, titulo As String, editorial As String, anoPublicacion As Short,
                                            publico As String, estado As Boolean, idsAutores As IList(Of Integer),
                                            idsCategorias As IList(Of Integer)) As Boolean
        Try
            If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
            ValidarLibro(titulo, editorial, anoPublicacion, publico, idsAutores, idsCategorias)
            Dim operador = seguridadNegocio.ExigirPersonal()
            If Not dao.actualizarLibroCompleto(idLibro, titulo, editorial, anoPublicacion, publico.Trim(), estado, idsAutores, idsCategorias, reglas, operador) Then
                Throw New InvalidOperationException("No se encontró el libro seleccionado.")
            End If
            Return True
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo actualizar el libro.", ex)
        End Try
    End Function

    Public Function ResolverAutores(nombres As IEnumerable(Of String)) As List(Of Integer)
        Try
            Dim seleccion = ValidarSeleccion(nombres, "Selecciona al menos un autor.")
            Dim autores As List(Of Autor) = New autorNegocio().listarTodos()
            Dim ids As New List(Of Integer)()
            For Each nombre As String In seleccion
                Dim autor As Autor = autores.FirstOrDefault(Function(x) String.Equals(x.NombreAutor.Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase))
                If autor Is Nothing Then Throw New InvalidOperationException("No existe el autor '" & nombre & "'. Regístralo primero en el mantenimiento de autores.")
                ids.Add(autor.IdAutor)
            Next
            Return ids.Distinct().ToList()
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo consultar los autores del libro.", ex)
        End Try
    End Function

    Public Function ResolverCategorias(nombres As IEnumerable(Of String)) As List(Of Integer)
        Try
            Dim seleccion = ValidarSeleccion(nombres, "Selecciona al menos una categoría.")
            Dim tabla As DataTable = New categoriaNegocio().listarCategoria()
            Dim ids As New List(Of Integer)()
            For Each nombre As String In seleccion
                Dim fila As DataRow = tabla.AsEnumerable().FirstOrDefault(Function(x) String.Equals(x("nombre_categoria").ToString().Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase) AndAlso
                                                                           String.Equals(x("estado").ToString(), "Activo", StringComparison.OrdinalIgnoreCase))
                If fila Is Nothing Then Throw New InvalidOperationException("No existe una categoría activa llamada '" & nombre & "'. Regístrala o actívala primero.")
                ids.Add(CInt(fila("id_categoria")))
            Next
            Return ids.Distinct().ToList()
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo consultar las categorías del libro.", ex)
        End Try
    End Function

    Private Shared Function ValidarSeleccion(nombres As IEnumerable(Of String), mensaje As String) As List(Of String)
        If nombres Is Nothing Then Throw New ArgumentException(mensaje)
        Dim seleccion = nombres.ToList()
        If seleccion.Count = 0 OrElse seleccion.Any(AddressOf String.IsNullOrWhiteSpace) Then Throw New ArgumentException(mensaje)
        Return seleccion
    End Function

    Private Shared Sub ValidarLibro(titulo As String, editorial As String, anoPublicacion As Short, publico As String,
                                   idsAutores As IList(Of Integer), idsCategorias As IList(Of Integer))
        If String.IsNullOrWhiteSpace(titulo) Then Throw New ArgumentException("El título es obligatorio.")
        If String.IsNullOrWhiteSpace(editorial) Then Throw New ArgumentException("La editorial es obligatoria.")
        If titulo.Trim().Length > 255 Then Throw New ArgumentException("El título admite hasta 255 caracteres.")
        If editorial.Trim().Length > 255 Then Throw New ArgumentException("La editorial admite hasta 255 caracteres.")
        If anoPublicacion < 1 OrElse anoPublicacion > 9999 Then Throw New ArgumentException("El año de publicación debe estar entre 1 y 9999.")
        If String.IsNullOrWhiteSpace(publico) Then Throw New ArgumentException("Selecciona el público objetivo.")
        If publico.Trim().Length > 30 Then Throw New ArgumentException("El público objetivo admite hasta 30 caracteres.")
        If idsAutores Is Nothing OrElse idsAutores.Count = 0 Then Throw New ArgumentException("Selecciona al menos un autor.")
        If idsCategorias Is Nothing OrElse idsCategorias.Count = 0 Then Throw New ArgumentException("Selecciona al menos una categoría.")
        If idsAutores.Any(Function(id) id <= 0) OrElse idsCategorias.Any(Function(id) id <= 0) Then
            Throw New ArgumentException("La selección de autores y categorías no es válida.")
        End If
    End Sub
End Class
