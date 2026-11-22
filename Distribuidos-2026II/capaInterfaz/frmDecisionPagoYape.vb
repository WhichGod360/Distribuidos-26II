Imports capaNegocio

Public Class frmDecisionPagoYape
    Private ReadOnly negocio As New pagoYapeNegocio()
    Private ReadOnly idReporte As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(id As Integer, reporte As DataRow)
        Me.New()
        idReporte = id
        Dim estado = reporte.Field(Of String)("Estado")
        Dim pendiente = estado = "EnRevision"
        Text = $"Reporte Yape N.º {id}"
        lblTitulo.Text = Text
        txtComprobante.Text = Resumir(reporte, estado)
        panelDecision.Visible = pendiente
        btnGuardarDecision.Visible = pendiente
        If pendiente Then
            cboDecision.SelectedIndex = 0
        Else
            lblDescripcion.Text = "Consulta la decisión registrada."
            btnCancelar.Text = "Cerrar"
            panelComprobante.Height = 200
            ClientSize = New Size(ClientSize.Width, Padding.Vertical + encabezado.Height + panelComprobante.Height + acciones.Height)
        End If
    End Sub

    Private Shared Function Resumir(reporte As DataRow, estado As String) As String
        Dim datos As New List(Of String) From {
            $"Cargo N.º {reporte.Field(Of Integer)("IdDetalle")} · Préstamo N.º {reporte.Field(Of Integer)("IdPrestamo")}",
            $"Lector: {reporte.Field(Of String)("Lector")} · S/ {reporte.Field(Of Decimal)("Monto"):N2}",
            $"Nombre en Yape: {reporte.Field(Of String)("NombreYape")}",
            $"Celular: {reporte.Field(Of String)("Celular")} · Código de comprobante: {reporte.Field(Of String)("Codigo")}",
            $"Estado: {If(estado = "EnRevision", "En revisión", estado)}"}
        Dim fecha = reporte.Field(Of Date?)("FechaRevision")
        If fecha.HasValue Then datos.Add($"Revisado por {reporte.Field(Of String)("Revisor")} · {fecha.Value:dd/MM/yyyy HH:mm} (Lima)")
        If estado = "Denegado" Then datos.Add($"Motivo: {reporte.Field(Of String)("Motivo")}")
        Return String.Join(Environment.NewLine, datos)
    End Function

    Private Sub ActualizarDecision(sender As Object, e As EventArgs) Handles cboDecision.SelectedIndexChanged
        chkVerificado.Enabled = cboDecision.SelectedIndex = 1
        txtMotivo.Enabled = cboDecision.SelectedIndex = 2
        If Not chkVerificado.Enabled Then chkVerificado.Checked = False
        btnGuardarDecision.Enabled = cboDecision.SelectedIndex > 0
        lblMensaje.Text = ""
    End Sub

    Private Sub GuardarDecision(sender As Object, e As EventArgs) Handles btnGuardarDecision.Click
        If idReporte <= 0 OrElse cboDecision.SelectedIndex < 1 Then Return
        Dim confirmar = cboDecision.SelectedIndex = 1
        If confirmar AndAlso Not chkVerificado.Checked Then
            lblMensaje.Text = "Marca la verificación del ingreso antes de confirmar el pago."
            chkVerificado.Focus()
            Return
        End If
        If Not confirmar AndAlso String.IsNullOrWhiteSpace(txtMotivo.Text) Then
            lblMensaje.Text = "Escribe un motivo para denegar el reporte."
            txtMotivo.Focus()
            Return
        End If
        btnGuardarDecision.Enabled = False
        Try
            negocio.Revisar(idReporte, confirmar, txtMotivo.Text)
            DialogResult = DialogResult.OK
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        Finally
            btnGuardarDecision.Enabled = True
        End Try
    End Sub
End Class
