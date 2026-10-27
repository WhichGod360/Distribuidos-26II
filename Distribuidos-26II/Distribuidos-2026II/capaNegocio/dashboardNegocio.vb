Imports capaDatos

Public Class dashboardNegocio
    Public Function consultar(desde As Date, hasta As Date, idCategoria As Integer, estado As String) As DashboardResumen
        Try
            If desde.Date > hasta.Date Then Throw New ArgumentException("La fecha Desde debe ser anterior o igual a Hasta.")
            If idCategoria < 0 Then Throw New ArgumentException("La categoría no es válida.")
            If Not {"Todos", "Activos", "Vencidos", "Devueltos"}.Contains(estado) Then Throw New ArgumentException("Selecciona un estado válido.")
            seguridadNegocio.ExigirPersonal()
            Return New dashboardDAO().consultar(desde.Date, hasta.Date, idCategoria, estado, Date.Today)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar el resumen de la biblioteca.", ex)
        End Try
    End Function

    Public Function categorias() As List(Of Categoria)
        Try
            seguridadNegocio.ExigirPersonal()
            Dim resultado As New List(Of Categoria) From {New Categoria With {.IdCategoria = 0, .NombreCategoria = "Todas las categorías"}}
            resultado.AddRange(New dashboardDAO().listarCategorias())
            Return resultado
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar el resumen de la biblioteca.", ex)
        End Try
    End Function
End Class
