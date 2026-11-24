Imports capaDatos

Public Class autorNegocio
    Private ReadOnly dao As New autorDAO()

    Public Function listarTodos() As List(Of Autor)
        Try
            Return dao.listarTodos()
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo listar los autores.", ex)
        End Try
    End Function

    Public Function buscarPorId(idAutor As Integer) As Autor
        Try
            If idAutor <= 0 Then Throw New ArgumentException("Selecciona un autor válido.")
            Return dao.buscarPorId(idAutor)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo obtener el autor.", ex)
        End Try
    End Function

    Public Function buscarPorNombre(nombre As String) As Autor
        Try
            ValidarNombre(nombre)
            Return dao.buscarPorNombre(nombre.Trim())
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo buscar el autor por nombre.", ex)
        End Try
    End Function

    Public Function listarPorNacionalidad(nacionalidad As String) As List(Of Autor)
        Try
            If String.IsNullOrWhiteSpace(nacionalidad) Then
                Throw New ArgumentException("La nacionalidad es obligatoria para filtrar.")
            End If
            If nacionalidad.Trim().Length > 100 Then Throw New ArgumentException("La nacionalidad admite hasta 100 caracteres.")
            Return dao.listarPorNacionalidad(nacionalidad.Trim())
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo listar los autores por nacionalidad.", ex)
        End Try
    End Function

    Public Function agregar(nombre As String, nacionalidad As String, fechaNacimiento As Date?, fechaFallecimiento As Date?, biografia As String) As Boolean
        Try
            ValidarAutor(nombre, nacionalidad, fechaNacimiento, fechaFallecimiento, biografia)
            Dim operador = seguridadNegocio.ExigirPersonal()
            Return dao.insertar(nombre.Trim(), If(nacionalidad, "").Trim(), fechaNacimiento, fechaFallecimiento, biografia, operador)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo registrar el autor.", ex)
        End Try
    End Function

    Public Function actualizar(idAutor As Integer, nombre As String, nacionalidad As String, fechaNacimiento As Date?, fechaFallecimiento As Date?, biografia As String) As Boolean
        Try
            If idAutor <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idAutor))
            ValidarAutor(nombre, nacionalidad, fechaNacimiento, fechaFallecimiento, biografia, idAutor)
            Dim operador = seguridadNegocio.ExigirPersonal()
            Return dao.actualizar(idAutor, nombre.Trim(), If(nacionalidad, "").Trim(), fechaNacimiento, fechaFallecimiento, biografia, operador)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo actualizar el autor.", ex)
        End Try
    End Function

    Public Function eliminar(idAutor As Integer) As Boolean
        Try
            If idAutor <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idAutor))
            Dim operador = seguridadNegocio.ExigirPersonal()
            Return dao.eliminar(idAutor, AddressOf ValidarEliminacion, operador)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo eliminar el autor.", ex)
        End Try
    End Function

    Private Sub ValidarAutor(nombre As String, nacionalidad As String, nacimiento As Date?, fallecimiento As Date?,
                             biografia As String, Optional idActual As Integer? = Nothing)
        Try
            ValidarNombre(nombre)
            ValidarCamposOpcionales(nacionalidad, nacimiento, fallecimiento, biografia)
            Dim existente = dao.buscarPorNombre(nombre.Trim())
            If existente Is Nothing Then Return
            If Not idActual.HasValue OrElse existente.IdAutor <> idActual.Value Then
                Throw New InvalidOperationException("Ya existe un autor con ese nombre.")
            End If
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo comprobar el nombre del autor.", ex)
        End Try
    End Sub

    Private Shared Sub ValidarEliminacion(libros As Integer)
        If libros > 0 Then Throw New InvalidOperationException("No se puede eliminar el autor porque está asociado a libros.")
    End Sub

    Private Shared Sub ValidarNombre(nombre As String)
        If String.IsNullOrWhiteSpace(nombre) Then
            Throw New ArgumentException("El nombre del autor es obligatorio.")
        End If
        If nombre.Trim().Length > 150 Then
            Throw New ArgumentException("El nombre del autor no puede superar los 150 caracteres.")
        End If
        If Not nombre.Any(AddressOf Char.IsLetter) Then Throw New ArgumentException("El nombre del autor debe contener al menos una letra.")
    End Sub

    Private Shared Sub ValidarCamposOpcionales(nacionalidad As String, fechaNacimiento As Date?, fechaFallecimiento As Date?, biografia As String)
        If Not String.IsNullOrEmpty(nacionalidad) AndAlso nacionalidad.Trim().Length > 100 Then
            Throw New ArgumentException("La nacionalidad no puede superar los 100 caracteres.")
        End If

        If fechaNacimiento.HasValue AndAlso fechaNacimiento.Value > DateTime.Today Then
            Throw New ArgumentException("La fecha de nacimiento no puede ser mayor a la fecha actual.")
        End If

        If fechaFallecimiento.HasValue AndAlso fechaFallecimiento.Value > DateTime.Today Then
            Throw New ArgumentException("La fecha de fallecimiento no puede ser mayor a la fecha actual.")
        End If

        If fechaNacimiento.HasValue AndAlso fechaFallecimiento.HasValue AndAlso fechaFallecimiento.Value < fechaNacimiento.Value Then
            Throw New ArgumentException("La fecha de fallecimiento no puede ser anterior a la fecha de nacimiento.")
        End If
    End Sub
End Class
