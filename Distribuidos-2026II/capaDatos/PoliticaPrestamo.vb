Public NotInheritable Class PoliticaPrestamo
    Public Const PlazoDias As Integer = 5
    Public Const MaximoEjemplares As Integer = 1

    Private Sub New()
    End Sub

    Public Shared Function FechaLimite(inicio As Date) As Date
        Try
            Return inicio.Date.AddDays(PlazoDias)
        Catch ex As ArgumentOutOfRangeException
            Throw New ArgumentException("La fecha de inicio no permite calcular un plazo de cinco días.", NameOf(inicio), ex)
        End Try
    End Function
End Class
