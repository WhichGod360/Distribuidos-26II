Imports capaDatos

Public Class autorNegocio
    Private ReadOnly dao As New autorDAO()

    Public Function listarTodos() As List(Of Autor)
        Try
            Return dao.listarTodos()
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar los autores.", ex)
        End Try
    End Function

    Public Function buscarPorId(idAutor As Integer) As Autor
        Try
            Return dao.buscarPorId(idAutor)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar los autores.", ex)
        End Try
    End Function

    Public Function buscarPorNombre(nombre As String) As Autor
        Try
            Return dao.buscarPorNombre(nombre)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar los autores.", ex)
        End Try
    End Function

    ' NUEVO: Método para listar autores filtrados por nacionalidad
    Public Function listarPorNacionalidad(nacionalidad As String) As List(Of Autor)
        Try
            If String.IsNullOrWhiteSpace(nacionalidad) Then
                Throw New ArgumentException("La nacionalidad es obligatoria para filtrar.")
            End If
            Return dao.listarPorNacionalidad(nacionalidad.Trim())
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar los autores.", ex)
        End Try
    End Function

    Public Function agregar(nombre As String, nacionalidad As String, fechaNacimiento As Date?, fechaFallecimiento As Date?, biografia As String) As Boolean
        Try
            ValidarNombre(nombre)
            ValidarCamposOpcionales(nacionalidad, fechaNacimiento, fechaFallecimiento, biografia)

            If dao.buscarPorNombre(nombre.Trim()) IsNot Nothing Then
                Throw New InvalidOperationException("Ya existe un autor con ese nombre.")
            End If
            seguridadNegocio.ExigirPersonal()
            Return dao.insertar(nombre.Trim(), nacionalidad, fechaNacimiento, fechaFallecimiento, biografia)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al registrar los autores.", ex)
        End Try
    End Function

    Public Function actualizar(idAutor As Integer, nombre As String, nacionalidad As String, fechaNacimiento As Date?, fechaFallecimiento As Date?, biografia As String) As Boolean
        Try
            If idAutor <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idAutor))
            ValidarNombre(nombre)
            ValidarCamposOpcionales(nacionalidad, fechaNacimiento, fechaFallecimiento, biografia)

            Dim existente As Autor = dao.buscarPorNombre(nombre.Trim())
            If existente IsNot Nothing AndAlso existente.IdAutor <> idAutor Then
                Throw New InvalidOperationException("Ya existe un autor con ese nombre.")
            End If
            seguridadNegocio.ExigirPersonal()
            Return dao.actualizar(idAutor, nombre.Trim(), nacionalidad, fechaNacimiento, fechaFallecimiento, biografia)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al actualizar los autores.", ex)
        End Try
    End Function

    Public Function eliminar(idAutor As Integer) As Boolean
        Try
            If idAutor <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idAutor))
            seguridadNegocio.ExigirPersonal()
            Return dao.eliminar(idAutor, AddressOf ValidarEliminacion)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al eliminar los autores.", ex)
        End Try
    End Function

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
