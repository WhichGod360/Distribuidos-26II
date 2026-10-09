Imports capaDatos

Public Class catalogoLectorNegocio
    Public Function listar() As List(Of Libro)
        seguridadNegocio.ExigirLector()
        Return New catalogoLectorDAO().listar()
    End Function
End Class
