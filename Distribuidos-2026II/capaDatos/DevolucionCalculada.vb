Public Class DevolucionCalculada
    Public Property IdPrestamo As Integer
    Public Property CantidadEjemplares As Integer = 1
    Public Property FechaRetorno As Date
    Public Property DiasRetraso As Integer
    Public Property IdPenalizacion As Integer?
    Public Property Monto As Decimal
    Public Property Motivo As String
    Public Property YaRegistrada As Boolean
    Public Property RegistrarCargo As Boolean

    Public ReadOnly Property Resumen As String
        Get
            Dim detalle = If(CantidadEjemplares > 1, $"{CantidadEjemplares} ejemplares en una devolución. ", "")
            If DiasRetraso = 0 Then Return detalle & "Devolución a tiempo. Sin mora."
            Return detalle & $"{DiasRetraso} día(s) de retraso · S/ {Monto:0.00} · {Motivo}" &
                If(YaRegistrada, " (ya registrada; no se cobrará otra vez)", " (monto fijo, sin acumulación)")
        End Get
    End Property
End Class
