Public Class DetallePenalizacion
    ' Campos propios de la tabla
    Public Property IdDetallePenalizacion As Integer
    Public Property DescripcionDetallePenalizacion As String
    Public Property IdPenalizacion As Integer
    Public Property IdPrestamo As Integer

    ' Propiedades auxiliares traídas por JOIN
    Public Property TipoPenalizacion As String
    Public Property MontoPenalizacion As Decimal
    Public Property NombreUsuario As String
    Public Property TituloLibro As String
    Public Property FechaInicio As Date
    Public Property FechaFin As Date
    Public Property FechaRetorno As Date?
    Public Property DiasRetraso As Integer
    Public Property EstadoPrestamo As String
End Class

' Resumen de un préstamo para mostrar en ComboBox (el valor almacenado es IdPrestamo)
Public Class PrestamoResumen
    Public Property IdPrestamo As Integer
    Public Property NombreUsuario As String
    Public Property TituloLibro As String

    Public ReadOnly Property Texto As String
        Get
            Return $"{IdPrestamo} - {NombreUsuario} - {TituloLibro}"
        End Get
    End Property
End Class