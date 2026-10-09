Public Class Penalizacion
    Public Property IdPenalizacion As Integer
    Public Property TipoPenalizacion As String
    Public Property DescripcionPenalizacion As String
    Public Property MontoPenalizacion As Decimal
    Public Property EstadoPenalizacion As Boolean
    Public Property DiasDesde As Integer?

    Public ReadOnly Property TramoTexto As String
        Get
            Return If(DiasDesde.HasValue, "Desde " & DiasDesde.GetValueOrDefault() & " día(s)", "Otro motivo")
        End Get
    End Property

    Public ReadOnly Property EstadoTexto As String
        Get
            Return If(EstadoPenalizacion, "Activo", "Inactivo")
        End Get
    End Property

    ' Texto para ComboBox: "ID - Tipo - S/ monto"
    Public ReadOnly Property DescripcionCombo As String
        Get
            Return $"{IdPenalizacion} - {TipoPenalizacion} - S/ {MontoPenalizacion:N2} · {TramoTexto}"
        End Get
    End Property
End Class
