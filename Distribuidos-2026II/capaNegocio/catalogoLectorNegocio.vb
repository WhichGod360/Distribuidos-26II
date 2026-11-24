Imports capaDatos

Public Class catalogoLectorNegocio
    Public Function listar() As List(Of Libro)
        Try
            seguridadNegocio.ExigirLector()
            Return New catalogoLectorDAO().listar()
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar el catálogo.", ex)
        End Try
    End Function
End Class
