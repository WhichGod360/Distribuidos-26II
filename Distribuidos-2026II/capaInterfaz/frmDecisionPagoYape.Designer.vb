<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDecisionPagoYape
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.encabezado = New Panel()
        Me.lblTitulo = New Label()
        Me.lblDescripcion = New Label()
        Me.cuerpo = New Panel()
        Me.layoutDecision = New TableLayoutPanel()
        Me.panelComprobante = New Panel()
        Me.lblComprobante = New Label()
        Me.txtComprobante = New TextBox()
        Me.panelDecision = New Panel()
        Me.lblDecision = New Label()
        Me.cboDecision = New ComboBox()
        Me.lblVerificacion = New Label()
        Me.chkVerificado = New CheckBox()
        Me.lblMotivo = New Label()
        Me.txtMotivo = New TextBox()
        Me.lblMensaje = New Label()
        Me.acciones = New FlowLayoutPanel()
        Me.btnGuardarDecision = New Button()
        Me.btnCancelar = New Button()
        Me.encabezado.SuspendLayout()
        Me.cuerpo.SuspendLayout()
        Me.layoutDecision.SuspendLayout()
        Me.panelComprobante.SuspendLayout()
        Me.panelDecision.SuspendLayout()
        Me.acciones.SuspendLayout()
        Me.SuspendLayout()

        ' encabezado
        Me.encabezado.Name = "encabezado"
        Me.encabezado.Dock = DockStyle.Top
        Me.encabezado.Height = 71
        Me.encabezado.Margin = Padding.Empty
        Me.encabezado.Controls.Add(Me.lblTitulo)
        Me.encabezado.Controls.Add(Me.lblDescripcion)

        ' lblTitulo
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Text = "Reporte Yape"
        Me.lblTitulo.ForeColor = Color.FromArgb(47, 72, 92)
        Me.lblTitulo.Location = New Point(0, 0)
        Me.lblTitulo.Size = New Size(510, 36)
        Me.lblTitulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Me.lblTitulo.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)

        ' lblDescripcion
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Text = "Coteja el importe y el comprobante con los movimientos de la cuenta receptora."
        Me.lblDescripcion.ForeColor = Color.FromArgb(120, 120, 120)
        Me.lblDescripcion.Location = New Point(0, 37)
        Me.lblDescripcion.Size = New Size(510, 29)
        Me.lblDescripcion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' cuerpo
        Me.cuerpo.Name = "cuerpo"
        Me.cuerpo.Dock = DockStyle.Fill
        Me.cuerpo.AutoScroll = True
        Me.cuerpo.Controls.Add(Me.layoutDecision)

        ' layoutDecision
        Me.layoutDecision.Name = "layoutDecision"
        Me.layoutDecision.ColumnCount = 1
        Me.layoutDecision.RowCount = 2
        Me.layoutDecision.Dock = DockStyle.Top
        Me.layoutDecision.AutoSize = True
        Me.layoutDecision.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.layoutDecision.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        Me.layoutDecision.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        Me.layoutDecision.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        Me.layoutDecision.Controls.Add(Me.panelComprobante, 0, 0)
        Me.layoutDecision.Controls.Add(Me.panelDecision, 0, 1)

        ' panelComprobante
        Me.panelComprobante.Name = "panelComprobante"
        Me.panelComprobante.Dock = DockStyle.Top
        Me.panelComprobante.Height = 154
        Me.panelComprobante.Margin = Padding.Empty
        Me.panelComprobante.Controls.Add(Me.txtComprobante)
        Me.panelComprobante.Controls.Add(Me.lblComprobante)

        ' lblComprobante
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Text = "Comprobante reportado"
        Me.lblComprobante.ForeColor = Color.FromArgb(47, 72, 92)
        Me.lblComprobante.Dock = DockStyle.Top
        Me.lblComprobante.Height = 25
        Me.lblComprobante.Font = New Font("Segoe UI Semibold", 10.0F)

        ' txtComprobante
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Dock = DockStyle.Fill
        Me.txtComprobante.Multiline = True
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.ScrollBars = ScrollBars.Vertical
        Me.txtComprobante.AccessibleName = "Datos reportados del comprobante"

        ' panelDecision
        Me.panelDecision.Name = "panelDecision"
        Me.panelDecision.Dock = DockStyle.Top
        Me.panelDecision.Height = 208
        Me.panelDecision.Margin = Padding.Empty
        Me.panelDecision.Controls.Add(Me.lblDecision)
        Me.panelDecision.Controls.Add(Me.cboDecision)
        Me.panelDecision.Controls.Add(Me.lblVerificacion)
        Me.panelDecision.Controls.Add(Me.chkVerificado)
        Me.panelDecision.Controls.Add(Me.lblMotivo)
        Me.panelDecision.Controls.Add(Me.txtMotivo)
        Me.panelDecision.Controls.Add(Me.lblMensaje)

        ' lblDecision
        Me.lblDecision.Name = "lblDecision"
        Me.lblDecision.Text = "Decisión"
        Me.lblDecision.ForeColor = Color.FromArgb(47, 72, 92)
        Me.lblDecision.Location = New Point(0, 10)
        Me.lblDecision.Size = New Size(510, 20)
        Me.lblDecision.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' cboDecision
        Me.cboDecision.Name = "cboDecision"
        Me.cboDecision.Location = New Point(0, 30)
        Me.cboDecision.Size = New Size(510, 27)
        Me.cboDecision.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Me.cboDecision.TabIndex = 0
        Me.cboDecision.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboDecision.AccessibleName = "Decisión sobre el reporte"
        Me.cboDecision.Items.AddRange(New Object() {"Elige una decisión", "Confirmar pago", "Denegar reporte"})

        ' lblVerificacion
        Me.lblVerificacion.Name = "lblVerificacion"
        Me.lblVerificacion.Text = "Verificación del pago"
        Me.lblVerificacion.ForeColor = Color.FromArgb(47, 72, 92)
        Me.lblVerificacion.Location = New Point(0, 62)
        Me.lblVerificacion.Size = New Size(510, 19)
        Me.lblVerificacion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' chkVerificado
        Me.chkVerificado.Name = "chkVerificado"
        Me.chkVerificado.Location = New Point(0, 81)
        Me.chkVerificado.Size = New Size(510, 25)
        Me.chkVerificado.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Me.chkVerificado.TabIndex = 1
        Me.chkVerificado.Text = "Verifiqué el ingreso en la cuenta receptora"

        ' lblMotivo
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Text = "Motivo de denegación · visible al lector"
        Me.lblMotivo.ForeColor = Color.FromArgb(47, 72, 92)
        Me.lblMotivo.Location = New Point(0, 110)
        Me.lblMotivo.Size = New Size(510, 19)
        Me.lblMotivo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' txtMotivo
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Location = New Point(0, 129)
        Me.txtMotivo.Size = New Size(510, 45)
        Me.txtMotivo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Me.txtMotivo.TabIndex = 2
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.MaxLength = 255
        Me.txtMotivo.AccessibleName = "Motivo de denegación"

        ' lblMensaje
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Text = ""
        Me.lblMensaje.ForeColor = Color.Firebrick
        Me.lblMensaje.Location = New Point(0, 178)
        Me.lblMensaje.Size = New Size(510, 30)
        Me.lblMensaje.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' acciones
        Me.acciones.Name = "acciones"
        Me.acciones.Dock = DockStyle.Bottom
        Me.acciones.Height = 52
        Me.acciones.FlowDirection = FlowDirection.RightToLeft
        Me.acciones.WrapContents = False
        Me.acciones.Padding = New Padding(0, 10, 0, 0)
        Me.acciones.Controls.Add(Me.btnGuardarDecision)
        Me.acciones.Controls.Add(Me.btnCancelar)

        ' btnGuardarDecision
        Me.btnGuardarDecision.Name = "btnGuardarDecision"
        Me.btnGuardarDecision.Text = "Guardar decisión"
        Me.btnGuardarDecision.Size = New Size(138, 36)
        Me.btnGuardarDecision.Margin = New Padding(0, 0, 10, 0)
        Me.btnGuardarDecision.FlatStyle = FlatStyle.Flat
        Me.btnGuardarDecision.FlatAppearance.BorderSize = 0
        Me.btnGuardarDecision.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        Me.btnGuardarDecision.BackColor = Color.FromArgb(59, 91, 115)
        Me.btnGuardarDecision.ForeColor = Color.White
        Me.btnGuardarDecision.Font = New Font("Segoe UI Semibold", 10.0F)
        Me.btnGuardarDecision.Cursor = Cursors.Hand
        Me.btnGuardarDecision.UseVisualStyleBackColor = False
        Me.btnGuardarDecision.TabIndex = 0

        ' btnCancelar
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.Size = New Size(138, 36)
        Me.btnCancelar.Margin = New Padding(0, 0, 10, 0)
        Me.btnCancelar.FlatStyle = FlatStyle.Flat
        Me.btnCancelar.FlatAppearance.BorderSize = 1
        Me.btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        Me.btnCancelar.BackColor = Color.White
        Me.btnCancelar.ForeColor = Color.FromArgb(59, 91, 115)
        Me.btnCancelar.Font = New Font("Segoe UI Semibold", 10.0F)
        Me.btnCancelar.Cursor = Cursors.Hand
        Me.btnCancelar.UseVisualStyleBackColor = False
        Me.btnCancelar.DialogResult = DialogResult.Cancel
        Me.btnCancelar.TabIndex = 1

        ' frmDecisionPagoYape
        Me.Name = "frmDecisionPagoYape"
        Me.Text = "Reporte Yape"
        Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9.0F)
        Me.ClientSize = New Size(560, 560)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ShowInTaskbar = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Padding = New Padding(24, 18, 24, 16)
        Me.CancelButton = Me.btnCancelar
        Me.Controls.Add(Me.cuerpo)
        Me.Controls.Add(Me.acciones)
        Me.Controls.Add(Me.encabezado)
        Me.acciones.ResumeLayout(False)
        Me.panelDecision.ResumeLayout(False)
        Me.panelComprobante.ResumeLayout(False)
        Me.layoutDecision.ResumeLayout(False)
        Me.cuerpo.ResumeLayout(False)
        Me.encabezado.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Private components As System.ComponentModel.IContainer
    Friend WithEvents encabezado As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents cuerpo As Panel
    Friend WithEvents layoutDecision As TableLayoutPanel
    Friend WithEvents panelComprobante As Panel
    Friend WithEvents lblComprobante As Label
    Friend WithEvents txtComprobante As TextBox
    Friend WithEvents panelDecision As Panel
    Friend WithEvents lblDecision As Label
    Friend WithEvents cboDecision As ComboBox
    Friend WithEvents lblVerificacion As Label
    Friend WithEvents chkVerificado As CheckBox
    Friend WithEvents lblMotivo As Label
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents lblMensaje As Label
    Friend WithEvents acciones As FlowLayoutPanel
    Friend WithEvents btnGuardarDecision As Button
    Friend WithEvents btnCancelar As Button
End Class
