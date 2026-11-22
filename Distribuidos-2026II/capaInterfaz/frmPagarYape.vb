Imports capaDatos
Imports capaNegocio

Public Class frmPagarYape
    Private ReadOnly negocio As New pagoYapeNegocio()
    Private ReadOnly idCargo As Integer
    Private ReadOnly importe As Decimal

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(id As Integer, cargo As DataRow, historial As DataTable)
        Me.New()
        idCargo = id
        importe = cargo.Field(Of Decimal)("Monto")
        Dim estado = cargo.Field(Of String)("Estado")
        Dim pendiente = estado = DetallePenalizacion.PagoPendiente AndAlso importe > 0D
        If pendiente AndAlso historial IsNot Nothing Then
            Using archivo = GetType(frmPagarYape).Assembly.GetManifestResourceStream("YapeQr.png")
                If archivo IsNot Nothing Then
                    imgQrYape.Image = RecorteQrYape.ParaMostrar(archivo)
                    imgQrYape.BorderStyle = BorderStyle.None
                End If
            End Using
        End If

        Dim mostrarPago = imgQrYape.Image IsNot Nothing
        Dim mostrarAviso = pendiente AndAlso Not mostrarPago
        Dim mostrarHistorial = historial IsNot Nothing
        Dim tieneReportes = mostrarHistorial AndAlso historial.Rows.Count > 0
        Dim estadoTexto = If(estado = DetallePenalizacion.PagoPorRevisar, "Por revisar", estado)
        lblCargo.Text = $"Cargo N.º {idCargo} · {cargo.Field(Of String)("Libro")} · S/ {importe:N2} · {estadoTexto}"
        panelPago.Visible = mostrarPago
        btnEnviar.Visible = mostrarPago
        lblDisponibilidad.Visible = mostrarAviso
        If mostrarAviso AndAlso mostrarHistorial Then
            lblDisponibilidad.Text = "El QR de Yape no está disponible en esta instalación. Consulta con la biblioteca."
        End If

        panelHistorial.Visible = mostrarHistorial
        tablaHistorial.Visible = tieneReportes
        tablaHistorial.DataSource = historial
        lblSinHistorial.Visible = mostrarHistorial AndAlso Not tieneReportes
        If Not tieneReportes Then panelHistorial.Height = lblHistorial.Height

        Dim altoContenido = If(mostrarPago, panelPago.Height, 0) + If(mostrarAviso, lblDisponibilidad.Height, 0) +
            If(mostrarHistorial, panelHistorial.Height + If(tieneReportes, 0, lblSinHistorial.Height), 0)
        ClientSize = New Size(ClientSize.Width, Math.Min(ClientSize.Height,
            Padding.Vertical + encabezado.Height + Math.Max(48, altoContenido) + acciones.Height))
    End Sub

    Private Sub EnviarReporte(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If idCargo <= 0 Then Return
        btnEnviar.Enabled = False
        lblMensaje.Text = ""
        Try
            negocio.Registrar(idCargo, importe, txtNombre.Text, txtCelular.Text, txtCodigo.Text)
            MessageBox.Show(Me, "Reporte enviado. La biblioteca verificará el pago.", "Pago por Yape", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        Finally
            btnEnviar.Enabled = True
        End Try
    End Sub

    Private Sub imgQrYape_Click(sender As Object, e As EventArgs) Handles imgQrYape.Click

    End Sub
End Class
