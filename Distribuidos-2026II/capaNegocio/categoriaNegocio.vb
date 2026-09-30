Imports capaDatos

Public Class categoriaNegocio
    Private ReadOnly dao As New categoriaDAO()

    Public Function listarTodos() As List(Of Categoria)
        Return dao.listarTodos()
    End Function

    Public Function buscarPorId(idCategoria As Integer) As Categoria
        Return dao.buscarPorId(idCategoria)
    End Function

    Public Function buscarPorNombre(nombre As String) As Categoria
        Return dao.buscarPorNombre(nombre)
    End Function
End Class