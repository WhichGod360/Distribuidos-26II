Public Class ComprobanteBiblioteca
    Public Property Tipo As String
    Public Property Referencia As String
    Public Property EmitidoPor As String
    Public Property FechaEmision As Date=Date.Now
    Public Property Prestamos As New List(Of Prestamo)
    Public Property TotalCargos As Decimal
    Public Property Penalizaciones As New List(Of DetallePenalizacion)
End Class
