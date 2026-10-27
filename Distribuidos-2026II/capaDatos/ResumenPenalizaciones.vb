Public Class ResumenPenalizaciones
    Public Property Detalles As New List(Of DetallePenalizacion)()
    Public Property Total As Decimal
    Public Property Pendiente As Decimal
    Public Property PorRevisar As Decimal
    Public Property Pagado As Decimal
    Public Property BloqueaPrestamos As Boolean
    Public Property TotalPorRegularizar As Decimal
End Class
