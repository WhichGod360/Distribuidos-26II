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
End Class