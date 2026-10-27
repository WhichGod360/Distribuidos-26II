Public Class DevolucionCalculada
    Public Property IdPrestamo As Integer
    Public Property FechaRetorno As Date
    Public Property DiasRetraso As Integer
    Public Property IdPenalizacion As Integer?
    Public Property Monto As Decimal
    Public Property Motivo As String
    Public Property YaRegistrada As Boolean
    Public Property RegistrarCargo As Boolean

    Public ReadOnly Property Resumen As String
        Get
            If DiasRetraso = 0 Then Return "Devolución a tiempo. Sin mora."
            Return $"{DiasRetraso} día(s) de retraso · S/ {Monto:0.00} · {Motivo}" &
                If(YaRegistrada, " (ya registrada; no se cobrará otra vez)", " (monto fijo, sin acumulación)")
        End Get
    End Property
End Class
