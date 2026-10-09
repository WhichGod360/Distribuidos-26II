Imports capaDatos

Public Class autorNegocio
    Private ReadOnly dao As New autorDAO()

    Public Function listarTodos() As List(Of Autor)
        Return dao.listarTodos()
    End Function

    Public Function buscarPorId(idAutor As Integer) As Autor
        Return dao.buscarPorId(idAutor)
    End Function

    Public Function buscarPorNombre(nombre As String) As Autor
        Return dao.buscarPorNombre(nombre)
    End Function

    Public Function agregar(nombre As String) As Boolean
        ValidarNombre(nombre)
        If dao.buscarPorNombre(nombre.Trim()) IsNot Nothing Then
            Throw New InvalidOperationException("Ya existe un autor con ese nombre.")
        End If
        Return dao.insertar(nombre.Trim())
    End Function

    Public Function actualizar(idAutor As Integer, nombre As String) As Boolean
        If idAutor <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idAutor))
        ValidarNombre(nombre)
        Dim existente As Autor = dao.buscarPorNombre(nombre.Trim())
        If existente IsNot Nothing AndAlso existente.IdAutor <> idAutor Then
            Throw New InvalidOperationException("Ya existe un autor con ese nombre.")
        End If
        Return dao.actualizar(idAutor, nombre.Trim())
    End Function

    Public Function eliminar(idAutor As Integer) As Boolean
        If idAutor <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idAutor))
        Return dao.eliminar(idAutor)
    End Function

    Private Shared Sub ValidarNombre(nombre As String)
        If String.IsNullOrWhiteSpace(nombre) Then
            Throw New ArgumentException("El nombre del autor es obligatorio.")
        End If
        If nombre.Trim().Length > 150 Then
            Throw New ArgumentException("El nombre del autor no puede superar los 150 caracteres.")
        End If
    End Sub
End Class
