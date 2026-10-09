Imports capaDatos

Public Class dashboardNegocio
    Public Function consultar(desde As Date, hasta As Date, idCategoria As Integer, estado As String) As DashboardResumen
        If desde.Date > hasta.Date Then Throw New ArgumentException("La fecha Desde debe ser anterior o igual a Hasta.")
        If idCategoria < 0 Then Throw New ArgumentException("La categoría no es válida.")
        If Not {"Todos", "Activos", "Vencidos", "Devueltos"}.Contains(estado) Then Throw New ArgumentException("Selecciona un estado válido.")
        seguridadNegocio.ExigirPersonal()
        Return New dashboardDAO().consultar(desde.Date, hasta.Date, idCategoria, estado, Date.Today)
    End Function

    Public Function categorias() As List(Of Categoria)
        seguridadNegocio.ExigirPersonal()
        Dim resultado As New List(Of Categoria) From {New Categoria With {.IdCategoria = 0, .NombreCategoria = "Todas las categorías"}}
        resultado.AddRange(New dashboardDAO().listarCategorias())
        Return resultado
    End Function
End Class
