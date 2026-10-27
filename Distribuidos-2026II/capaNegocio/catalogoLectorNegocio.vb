Imports capaDatos

Public Class catalogoLectorNegocio
    Public Function listar() As List(Of Libro)
        Try
            seguridadNegocio.ExigirLector()
            Return New catalogoLectorDAO().listar()
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar el catálogo.", ex)
        End Try
    End Function
End Class
