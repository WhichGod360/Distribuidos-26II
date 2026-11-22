<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPagarYape
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso Me.imgQrYape IsNot Nothing AndAlso Me.imgQrYape.Image IsNot Nothing Then Me.imgQrYape.Image.Dispose()
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        encabezado = New Panel()
        lblTitulo = New Label()
        lblCargo = New Label()
        cuerpo = New Panel()
        layoutPago = New TableLayoutPanel()
        panelPago = New Panel()
        lblPagoYape = New Label()
        imgQrYape = New PictureBox()
        lblDatos = New Label()
        lblNombre = New Label()
        txtNombre = New TextBox()
        lblCelular = New Label()
        txtCelular = New TextBox()
        lblCodigo = New Label()
        txtCodigo = New TextBox()
        lblMensaje = New Label()
        lblDisponibilidad = New Label()
        panelHistorial = New Panel()
        tablaHistorial = New DataGridView()
        lblHistorial = New Label()
        lblSinHistorial = New Label()
        acciones = New FlowLayoutPanel()
        btnEnviar = New Button()
        btnCerrar = New Button()
        encabezado.SuspendLayout()
        cuerpo.SuspendLayout()
        layoutPago.SuspendLayout()
        panelPago.SuspendLayout()
        CType(imgQrYape, ISupportInitialize).BeginInit()
        panelHistorial.SuspendLayout()
        CType(tablaHistorial, ISupportInitialize).BeginInit()
        acciones.SuspendLayout()
        SuspendLayout()
        ' 
        ' encabezado
        ' 
        encabezado.Controls.Add(lblTitulo)
        encabezado.Controls.Add(lblCargo)
        encabezado.Dock = DockStyle.Top
        encabezado.Location = New Point(27, 24)
        encabezado.Margin = New Padding(0)
        encabezado.Name = "encabezado"
        encabezado.Size = New Size(712, 91)
        encabezado.TabIndex = 2
        ' 
        ' lblTitulo
        ' 
        lblTitulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblTitulo.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblTitulo.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblTitulo.Location = New Point(0, 0)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(1194, 48)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "Pagar penalización"
        ' 
        ' lblCargo
        ' 
        lblCargo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblCargo.AutoEllipsis = True
        lblCargo.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblCargo.Location = New Point(0, 49)
        lblCargo.Name = "lblCargo"
        lblCargo.Size = New Size(1194, 33)
        lblCargo.TabIndex = 1
        lblCargo.Text = "Detalle de la penalización"
        ' 
        ' cuerpo
        ' 
        cuerpo.AutoScroll = True
        cuerpo.Controls.Add(layoutPago)
        cuerpo.Dock = DockStyle.Fill
        cuerpo.Location = New Point(27, 115)
        cuerpo.Margin = New Padding(3, 4, 3, 4)
        cuerpo.Name = "cuerpo"
        cuerpo.Size = New Size(712, 608)
        cuerpo.TabIndex = 0
        ' 
        ' layoutPago
        ' 
        layoutPago.AutoSize = True
        layoutPago.AutoSizeMode = AutoSizeMode.GrowAndShrink
        layoutPago.ColumnCount = 1
        layoutPago.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layoutPago.Controls.Add(panelPago, 0, 0)
        layoutPago.Controls.Add(lblDisponibilidad, 0, 1)
        layoutPago.Controls.Add(panelHistorial, 0, 2)
        layoutPago.Controls.Add(lblSinHistorial, 0, 3)
        layoutPago.Dock = DockStyle.Top
        layoutPago.Location = New Point(0, 0)
        layoutPago.Margin = New Padding(3, 4, 3, 4)
        layoutPago.Name = "layoutPago"
        layoutPago.RowCount = 4
        layoutPago.RowStyles.Add(New RowStyle())
        layoutPago.RowStyles.Add(New RowStyle())
        layoutPago.RowStyles.Add(New RowStyle())
        layoutPago.RowStyles.Add(New RowStyle())
        layoutPago.Size = New Size(691, 686)
        layoutPago.TabIndex = 0
        ' 
        ' panelPago
        ' 
        panelPago.Controls.Add(lblPagoYape)
        panelPago.Controls.Add(imgQrYape)
        panelPago.Controls.Add(lblDatos)
        panelPago.Controls.Add(lblNombre)
        panelPago.Controls.Add(txtNombre)
        panelPago.Controls.Add(lblCelular)
        panelPago.Controls.Add(txtCelular)
        panelPago.Controls.Add(lblCodigo)
        panelPago.Controls.Add(txtCodigo)
        panelPago.Controls.Add(lblMensaje)
        panelPago.Dock = DockStyle.Top
        panelPago.Location = New Point(0, 0)
        panelPago.Margin = New Padding(0)
        panelPago.Name = "panelPago"
        panelPago.Size = New Size(691, 380)
        panelPago.TabIndex = 0
        ' 
        ' lblPagoYape
        ' 
        lblPagoYape.Font = New Font("Segoe UI Semibold", 11F)
        lblPagoYape.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblPagoYape.Location = New Point(0, 3)
        lblPagoYape.Name = "lblPagoYape"
        lblPagoYape.Size = New Size(238, 33)
        lblPagoYape.TabIndex = 0
        lblPagoYape.Text = "Pago en Yape"
        ' 
        ' imgQrYape
        ' 
        imgQrYape.AccessibleName = "Código QR de Yape"
        imgQrYape.BackColor = Color.White
        imgQrYape.BorderStyle = BorderStyle.FixedSingle
        imgQrYape.Location = New Point(0, 40)
        imgQrYape.Margin = New Padding(3, 4, 3, 4)
        imgQrYape.Name = "imgQrYape"
        imgQrYape.Size = New Size(237, 277)
        imgQrYape.SizeMode = PictureBoxSizeMode.Zoom
        imgQrYape.TabIndex = 1
        imgQrYape.TabStop = False
        ' 
        ' lblDatos
        ' 
        lblDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblDatos.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblDatos.Location = New Point(277, 5)
        lblDatos.Name = "lblDatos"
        lblDatos.Size = New Size(892, 32)
        lblDatos.TabIndex = 2
        lblDatos.Text = "Después de pagar, ingresa los datos del comprobante."
        ' 
        ' lblNombre
        ' 
        lblNombre.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblNombre.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblNombre.Location = New Point(277, 49)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New Size(892, 28)
        lblNombre.TabIndex = 3
        lblNombre.Text = "Nombre que aparece en el comprobante"
        ' 
        ' txtNombre
        ' 
        txtNombre.AccessibleName = "Nombre que aparece en el comprobante"
        txtNombre.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtNombre.Location = New Point(277, 77)
        txtNombre.Margin = New Padding(3, 4, 3, 4)
        txtNombre.MaxLength = 120
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(891, 27)
        txtNombre.TabIndex = 0
        ' 
        ' lblCelular
        ' 
        lblCelular.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblCelular.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblCelular.Location = New Point(277, 131)
        lblCelular.Name = "lblCelular"
        lblCelular.Size = New Size(892, 28)
        lblCelular.TabIndex = 4
        lblCelular.Text = "Celular de quien envió el Yape"
        ' 
        ' txtCelular
        ' 
        txtCelular.AccessibleName = "Celular de quien envió el Yape"
        txtCelular.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtCelular.Location = New Point(277, 159)
        txtCelular.Margin = New Padding(3, 4, 3, 4)
        txtCelular.MaxLength = 9
        txtCelular.Name = "txtCelular"
        txtCelular.Size = New Size(891, 27)
        txtCelular.TabIndex = 1
        ' 
        ' lblCodigo
        ' 
        lblCodigo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblCodigo.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblCodigo.Location = New Point(277, 212)
        lblCodigo.Name = "lblCodigo"
        lblCodigo.Size = New Size(892, 28)
        lblCodigo.TabIndex = 5
        lblCodigo.Text = "Código de seguridad del comprobante (3 dígitos)"
        ' 
        ' txtCodigo
        ' 
        txtCodigo.AccessibleName = "Código de seguridad del comprobante"
        txtCodigo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtCodigo.Location = New Point(277, 240)
        txtCodigo.Margin = New Padding(3, 4, 3, 4)
        txtCodigo.MaxLength = 3
        txtCodigo.Name = "txtCodigo"
        txtCodigo.Size = New Size(891, 27)
        txtCodigo.TabIndex = 2
        ' 
        ' lblMensaje
        ' 
        lblMensaje.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblMensaje.ForeColor = Color.Firebrick
        lblMensaje.Location = New Point(277, 288)
        lblMensaje.Name = "lblMensaje"
        lblMensaje.Size = New Size(892, 77)
        lblMensaje.TabIndex = 6
        ' 
        ' lblDisponibilidad
        ' 
        lblDisponibilidad.Dock = DockStyle.Top
        lblDisponibilidad.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblDisponibilidad.Location = New Point(0, 380)
        lblDisponibilidad.Margin = New Padding(0)
        lblDisponibilidad.Name = "lblDisponibilidad"
        lblDisponibilidad.Size = New Size(691, 64)
        lblDisponibilidad.TabIndex = 1
        lblDisponibilidad.Text = "El pago por Yape aún no está disponible. Consulta con la biblioteca."
        lblDisponibilidad.Visible = False
        ' 
        ' panelHistorial
        ' 
        panelHistorial.Controls.Add(tablaHistorial)
        panelHistorial.Controls.Add(lblHistorial)
        panelHistorial.Dock = DockStyle.Top
        panelHistorial.Location = New Point(0, 444)
        panelHistorial.Margin = New Padding(0)
        panelHistorial.Name = "panelHistorial"
        panelHistorial.Size = New Size(691, 205)
        panelHistorial.TabIndex = 2
        ' 
        ' tablaHistorial
        ' 
        tablaHistorial.AccessibleName = "Historial de reportes de Yape"
        tablaHistorial.AllowUserToAddRows = False
        tablaHistorial.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(255))
        tablaHistorial.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        tablaHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        tablaHistorial.BackgroundColor = Color.White
        tablaHistorial.BorderStyle = BorderStyle.None
        tablaHistorial.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(235), CByte(238), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(20), CByte(20), CByte(30))
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        tablaHistorial.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        tablaHistorial.ColumnHeadersHeight = 40
        tablaHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        tablaHistorial.DefaultCellStyle = DataGridViewCellStyle3
        tablaHistorial.Dock = DockStyle.Fill
        tablaHistorial.EnableHeadersVisualStyles = False
        tablaHistorial.GridColor = Color.FromArgb(CByte(222), CByte(225), CByte(236))
        tablaHistorial.Location = New Point(0, 35)
        tablaHistorial.Margin = New Padding(3, 4, 3, 4)
        tablaHistorial.MultiSelect = False
        tablaHistorial.Name = "tablaHistorial"
        tablaHistorial.ReadOnly = True
        tablaHistorial.RowHeadersVisible = False
        tablaHistorial.RowHeadersWidth = 51
        tablaHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaHistorial.Size = New Size(691, 170)
        tablaHistorial.TabIndex = 0
        ' 
        ' lblHistorial
        ' 
        lblHistorial.Dock = DockStyle.Top
        lblHistorial.Font = New Font("Segoe UI Semibold", 10F)
        lblHistorial.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblHistorial.Location = New Point(0, 0)
        lblHistorial.Name = "lblHistorial"
        lblHistorial.Size = New Size(691, 35)
        lblHistorial.TabIndex = 1
        lblHistorial.Text = "Historial de reportes"
        ' 
        ' lblSinHistorial
        ' 
        lblSinHistorial.Dock = DockStyle.Top
        lblSinHistorial.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblSinHistorial.Location = New Point(0, 649)
        lblSinHistorial.Margin = New Padding(0)
        lblSinHistorial.Name = "lblSinHistorial"
        lblSinHistorial.Size = New Size(691, 37)
        lblSinHistorial.TabIndex = 3
        lblSinHistorial.Text = "Aún no has reportado un pago para este cargo."
        ' 
        ' acciones
        ' 
        acciones.Controls.Add(btnEnviar)
        acciones.Controls.Add(btnCerrar)
        acciones.Dock = DockStyle.Bottom
        acciones.FlowDirection = FlowDirection.RightToLeft
        acciones.Location = New Point(27, 723)
        acciones.Margin = New Padding(3, 4, 3, 4)
        acciones.Name = "acciones"
        acciones.Padding = New Padding(0, 13, 0, 0)
        acciones.Size = New Size(712, 69)
        acciones.TabIndex = 1
        acciones.WrapContents = False
        ' 
        ' btnEnviar
        ' 
        btnEnviar.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnEnviar.Cursor = Cursors.Hand
        btnEnviar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnEnviar.FlatAppearance.BorderSize = 0
        btnEnviar.FlatStyle = FlatStyle.Flat
        btnEnviar.Font = New Font("Segoe UI Semibold", 10F)
        btnEnviar.ForeColor = Color.White
        btnEnviar.Location = New Point(543, 13)
        btnEnviar.Margin = New Padding(0, 0, 11, 0)
        btnEnviar.Name = "btnEnviar"
        btnEnviar.Size = New Size(158, 48)
        btnEnviar.TabIndex = 0
        btnEnviar.Text = "Enviar reporte"
        btnEnviar.UseVisualStyleBackColor = False
        ' 
        ' btnCerrar
        ' 
        btnCerrar.BackColor = Color.White
        btnCerrar.Cursor = Cursors.Hand
        btnCerrar.DialogResult = DialogResult.Cancel
        btnCerrar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnCerrar.FlatStyle = FlatStyle.Flat
        btnCerrar.Font = New Font("Segoe UI Semibold", 10F)
        btnCerrar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnCerrar.Location = New Point(374, 13)
        btnCerrar.Margin = New Padding(0, 0, 11, 0)
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Size = New Size(158, 48)
        btnCerrar.TabIndex = 1
        btnCerrar.Text = "Cerrar"
        btnCerrar.UseVisualStyleBackColor = False
        ' 
        ' frmPagarYape
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        CancelButton = btnCerrar
        ClientSize = New Size(766, 813)
        Controls.Add(cuerpo)
        Controls.Add(acciones)
        Controls.Add(encabezado)
        Font = New Font("Segoe UI", 9F)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmPagarYape"
        Padding = New Padding(27, 24, 27, 21)
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Pagar penalización"
        encabezado.ResumeLayout(False)
        cuerpo.ResumeLayout(False)
        cuerpo.PerformLayout()
        layoutPago.ResumeLayout(False)
        panelPago.ResumeLayout(False)
        panelPago.PerformLayout()
        CType(imgQrYape, ISupportInitialize).EndInit()
        panelHistorial.ResumeLayout(False)
        CType(tablaHistorial, ISupportInitialize).EndInit()
        acciones.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Private components As System.ComponentModel.IContainer
    Friend WithEvents encabezado As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblCargo As Label
    Friend WithEvents cuerpo As Panel
    Friend WithEvents layoutPago As TableLayoutPanel
    Friend WithEvents panelPago As Panel
    Friend WithEvents lblPagoYape As Label
    Friend WithEvents imgQrYape As PictureBox
    Friend WithEvents lblDatos As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblCelular As Label
    Friend WithEvents txtCelular As TextBox
    Friend WithEvents lblCodigo As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents lblMensaje As Label
    Friend WithEvents lblDisponibilidad As Label
    Friend WithEvents panelHistorial As Panel
    Friend WithEvents lblHistorial As Label
    Friend WithEvents tablaHistorial As DataGridView
    Friend WithEvents colReporte As DataGridViewTextBoxColumn
    Friend WithEvents colFecha As DataGridViewTextBoxColumn
    Friend WithEvents colMonto As DataGridViewTextBoxColumn
    Friend WithEvents colEstado As DataGridViewTextBoxColumn
    Friend WithEvents colMotivo As DataGridViewTextBoxColumn
    Friend WithEvents lblSinHistorial As Label
    Friend WithEvents acciones As FlowLayoutPanel
    Friend WithEvents btnEnviar As Button
    Friend WithEvents btnCerrar As Button
End Class
