<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBitacora
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

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
        components = New Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        layoutBitacora = New TableLayoutPanel()
        encabezado = New Panel()
        lblDescripcion = New Label()
        lblTitulo = New Label()
        barraFiltros = New FlowLayoutPanel()
        panelDesde = New Panel()
        dtDesde = New DateTimePicker()
        lblDesde = New Label()
        panelHasta = New Panel()
        dtHasta = New DateTimePicker()
        lblHasta = New Label()
        panelUsuario = New Panel()
        numUsuario = New NumericUpDown()
        chkUsuario = New CheckBox()
        panelObjeto = New Panel()
        txtObjeto = New TextBox()
        lblObjeto = New Label()
        panelAccion = New Panel()
        cboAccion = New ComboBox()
        lblAccion = New Label()
        barraAcciones = New FlowLayoutPanel()
        btnAplicar = New Button()
        btnLimpiar = New Button()
        btnActualizar = New Button()
        chkAutomatico = New CheckBox()
        tablaBitacora = New DataGridView()
        panelCadena = New Panel()
        txtCadena = New TextBox()
        lblCadena = New Label()
        lblResumen = New Label()
        actualizador = New Timer(components)
        layoutBitacora.SuspendLayout()
        encabezado.SuspendLayout()
        barraFiltros.SuspendLayout()
        panelDesde.SuspendLayout()
        panelHasta.SuspendLayout()
        panelUsuario.SuspendLayout()
        CType(numUsuario, ISupportInitialize).BeginInit()
        panelObjeto.SuspendLayout()
        panelAccion.SuspendLayout()
        barraAcciones.SuspendLayout()
        CType(tablaBitacora, ISupportInitialize).BeginInit()
        panelCadena.SuspendLayout()
        SuspendLayout()
        ' 
        ' layoutBitacora
        ' 
        layoutBitacora.ColumnCount = 1
        layoutBitacora.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        layoutBitacora.Controls.Add(encabezado, 0, 0)
        layoutBitacora.Controls.Add(barraFiltros, 0, 1)
        layoutBitacora.Controls.Add(barraAcciones, 0, 2)
        layoutBitacora.Controls.Add(tablaBitacora, 0, 3)
        layoutBitacora.Controls.Add(panelCadena, 0, 4)
        layoutBitacora.Controls.Add(lblResumen, 0, 5)
        layoutBitacora.Dock = DockStyle.Fill
        layoutBitacora.Location = New Point(0, 0)
        layoutBitacora.Name = "layoutBitacora"
        layoutBitacora.Padding = New Padding(24, 18, 24, 14)
        layoutBitacora.RowCount = 6
        layoutBitacora.RowStyles.Add(New RowStyle(SizeType.Absolute, 72.0F))
        layoutBitacora.RowStyles.Add(New RowStyle())
        layoutBitacora.RowStyles.Add(New RowStyle())
        layoutBitacora.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        layoutBitacora.RowStyles.Add(New RowStyle(SizeType.Absolute, 110.0F))
        layoutBitacora.RowStyles.Add(New RowStyle(SizeType.Absolute, 40.0F))
        layoutBitacora.Size = New Size(1100, 700)
        layoutBitacora.TabIndex = 0
        ' 
        ' encabezado
        ' 
        encabezado.Controls.Add(lblDescripcion)
        encabezado.Controls.Add(lblTitulo)
        encabezado.Dock = DockStyle.Fill
        encabezado.Location = New Point(24, 18)
        encabezado.Margin = New Padding(0)
        encabezado.Name = "encabezado"
        encabezado.Size = New Size(1052, 72)
        encabezado.TabIndex = 0
        ' 
        ' lblDescripcion
        ' 
        lblDescripcion.AutoEllipsis = True
        lblDescripcion.Dock = DockStyle.Fill
        lblDescripcion.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblDescripcion.Location = New Point(0, 37)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Size = New Size(1052, 35)
        lblDescripcion.TabIndex = 0
        lblDescripcion.Text = "Consulta las acciones registradas en el sistema."
        ' 
        ' lblTitulo
        ' 
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblTitulo.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblTitulo.Location = New Point(0, 0)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(1052, 37)
        lblTitulo.TabIndex = 1
        lblTitulo.Text = "Bitácora de mantenimiento"
        ' 
        ' barraFiltros
        ' 
        barraFiltros.AutoSize = True
        barraFiltros.AutoSizeMode = AutoSizeMode.GrowAndShrink
        barraFiltros.Controls.Add(panelDesde)
        barraFiltros.Controls.Add(panelHasta)
        barraFiltros.Controls.Add(panelUsuario)
        barraFiltros.Controls.Add(panelObjeto)
        barraFiltros.Controls.Add(panelAccion)
        barraFiltros.Dock = DockStyle.Fill
        barraFiltros.Location = New Point(24, 90)
        barraFiltros.Margin = New Padding(0, 0, 0, 10)
        barraFiltros.Name = "barraFiltros"
        barraFiltros.Size = New Size(1052, 62)
        barraFiltros.TabIndex = 1
        ' 
        ' panelDesde
        ' 
        panelDesde.Controls.Add(dtDesde)
        panelDesde.Controls.Add(lblDesde)
        panelDesde.Location = New Point(0, 0)
        panelDesde.Margin = New Padding(0, 0, 14, 0)
        panelDesde.Name = "panelDesde"
        panelDesde.Size = New Size(160, 62)
        panelDesde.TabIndex = 0
        ' 
        ' dtDesde
        ' 
        dtDesde.Checked = False
        dtDesde.CustomFormat = "dd/MM/yyyy"
        dtDesde.Dock = DockStyle.Top
        dtDesde.Format = DateTimePickerFormat.Custom
        dtDesde.Location = New Point(0, 24)
        dtDesde.Name = "dtDesde"
        dtDesde.ShowCheckBox = True
        dtDesde.Size = New Size(160, 30)
        dtDesde.TabIndex = 0
        ' 
        ' lblDesde
        ' 
        lblDesde.Dock = DockStyle.Top
        lblDesde.Font = New Font("Segoe UI Semibold", 9.0F)
        lblDesde.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblDesde.Location = New Point(0, 0)
        lblDesde.Name = "lblDesde"
        lblDesde.Size = New Size(160, 24)
        lblDesde.TabIndex = 1
        lblDesde.Text = "Desde (opcional)"
        ' 
        ' panelHasta
        ' 
        panelHasta.Controls.Add(dtHasta)
        panelHasta.Controls.Add(lblHasta)
        panelHasta.Location = New Point(174, 0)
        panelHasta.Margin = New Padding(0, 0, 14, 0)
        panelHasta.Name = "panelHasta"
        panelHasta.Size = New Size(160, 62)
        panelHasta.TabIndex = 1
        ' 
        ' dtHasta
        ' 
        dtHasta.Checked = False
        dtHasta.CustomFormat = "dd/MM/yyyy"
        dtHasta.Dock = DockStyle.Top
        dtHasta.Format = DateTimePickerFormat.Custom
        dtHasta.Location = New Point(0, 24)
        dtHasta.Name = "dtHasta"
        dtHasta.ShowCheckBox = True
        dtHasta.Size = New Size(160, 30)
        dtHasta.TabIndex = 0
        ' 
        ' lblHasta
        ' 
        lblHasta.Dock = DockStyle.Top
        lblHasta.Font = New Font("Segoe UI Semibold", 9.0F)
        lblHasta.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblHasta.Location = New Point(0, 0)
        lblHasta.Name = "lblHasta"
        lblHasta.Size = New Size(160, 24)
        lblHasta.TabIndex = 1
        lblHasta.Text = "Hasta (opcional)"
        ' 
        ' panelUsuario
        ' 
        panelUsuario.Controls.Add(numUsuario)
        panelUsuario.Controls.Add(chkUsuario)
        panelUsuario.Location = New Point(348, 0)
        panelUsuario.Margin = New Padding(0, 0, 14, 0)
        panelUsuario.Name = "panelUsuario"
        panelUsuario.Size = New Size(180, 62)
        panelUsuario.TabIndex = 2
        ' 
        ' numUsuario
        ' 
        numUsuario.Dock = DockStyle.Top
        numUsuario.Enabled = False
        numUsuario.Location = New Point(0, 24)
        numUsuario.Maximum = New Decimal(New Integer() {Integer.MaxValue, 0, 0, 0})
        numUsuario.Name = "numUsuario"
        numUsuario.Size = New Size(180, 30)
        numUsuario.TabIndex = 1
        ' 
        ' chkUsuario
        ' 
        chkUsuario.Dock = DockStyle.Top
        chkUsuario.Font = New Font("Segoe UI Semibold", 9.0F)
        chkUsuario.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        chkUsuario.Location = New Point(0, 0)
        chkUsuario.Name = "chkUsuario"
        chkUsuario.Size = New Size(180, 24)
        chkUsuario.TabIndex = 0
        chkUsuario.Text = "Filtrar por ID de usuario"
        ' 
        ' panelObjeto
        ' 
        panelObjeto.Controls.Add(txtObjeto)
        panelObjeto.Controls.Add(lblObjeto)
        panelObjeto.Location = New Point(542, 0)
        panelObjeto.Margin = New Padding(0, 0, 14, 0)
        panelObjeto.Name = "panelObjeto"
        panelObjeto.Size = New Size(180, 62)
        panelObjeto.TabIndex = 3
        ' 
        ' txtObjeto
        ' 
        txtObjeto.Dock = DockStyle.Top
        txtObjeto.Location = New Point(0, 24)
        txtObjeto.MaxLength = 30
        txtObjeto.Name = "txtObjeto"
        txtObjeto.PlaceholderText = "Todos los objetos"
        txtObjeto.Size = New Size(180, 30)
        txtObjeto.TabIndex = 0
        ' 
        ' lblObjeto
        ' 
        lblObjeto.Dock = DockStyle.Top
        lblObjeto.Font = New Font("Segoe UI Semibold", 9.0F)
        lblObjeto.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblObjeto.Location = New Point(0, 0)
        lblObjeto.Name = "lblObjeto"
        lblObjeto.Size = New Size(180, 24)
        lblObjeto.TabIndex = 1
        lblObjeto.Text = "Objeto o mantenimiento"
        ' 
        ' panelAccion
        ' 
        panelAccion.Controls.Add(cboAccion)
        panelAccion.Controls.Add(lblAccion)
        panelAccion.Location = New Point(736, 0)
        panelAccion.Margin = New Padding(0, 0, 14, 0)
        panelAccion.Name = "panelAccion"
        panelAccion.Size = New Size(160, 62)
        panelAccion.TabIndex = 4
        ' 
        ' cboAccion
        ' 
        cboAccion.Dock = DockStyle.Top
        cboAccion.DropDownStyle = ComboBoxStyle.DropDownList
        cboAccion.Items.AddRange(New Object() {"Todas", "INSERT", "UPDATE", "DELETE", "SELECT", "BUSQUEDA", "LISTADO"})
        cboAccion.Location = New Point(0, 24)
        cboAccion.Name = "cboAccion"
        cboAccion.Size = New Size(160, 31)
        cboAccion.TabIndex = 0
        ' 
        ' lblAccion
        ' 
        lblAccion.Dock = DockStyle.Top
        lblAccion.Font = New Font("Segoe UI Semibold", 9.0F)
        lblAccion.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblAccion.Location = New Point(0, 0)
        lblAccion.Name = "lblAccion"
        lblAccion.Size = New Size(160, 24)
        lblAccion.TabIndex = 1
        lblAccion.Text = "Acción"
        ' 
        ' barraAcciones
        ' 
        barraAcciones.AutoSize = True
        barraAcciones.AutoSizeMode = AutoSizeMode.GrowAndShrink
        barraAcciones.Controls.Add(btnAplicar)
        barraAcciones.Controls.Add(btnLimpiar)
        barraAcciones.Controls.Add(btnActualizar)
        barraAcciones.Controls.Add(chkAutomatico)
        barraAcciones.Dock = DockStyle.Fill
        barraAcciones.Location = New Point(24, 162)
        barraAcciones.Margin = New Padding(0, 0, 0, 12)
        barraAcciones.Name = "barraAcciones"
        barraAcciones.Size = New Size(1052, 40)
        barraAcciones.TabIndex = 2
        ' 
        ' btnAplicar
        ' 
        btnAplicar.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnAplicar.Cursor = Cursors.Hand
        btnAplicar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnAplicar.FlatAppearance.BorderSize = 0
        btnAplicar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btnAplicar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btnAplicar.FlatStyle = FlatStyle.Flat
        btnAplicar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnAplicar.ForeColor = Color.White
        btnAplicar.Location = New Point(0, 0)
        btnAplicar.Margin = New Padding(0, 0, 10, 4)
        btnAplicar.Name = "btnAplicar"
        btnAplicar.Size = New Size(140, 36)
        btnAplicar.TabIndex = 0
        btnAplicar.Text = "Aplicar filtros"
        btnAplicar.UseVisualStyleBackColor = False
        ' 
        ' btnLimpiar
        ' 
        btnLimpiar.BackColor = Color.White
        btnLimpiar.Cursor = Cursors.Hand
        btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnLimpiar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnLimpiar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnLimpiar.FlatStyle = FlatStyle.Flat
        btnLimpiar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnLimpiar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnLimpiar.Location = New Point(150, 0)
        btnLimpiar.Margin = New Padding(0, 0, 10, 4)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(140, 36)
        btnLimpiar.TabIndex = 1
        btnLimpiar.Text = "Limpiar "
        btnLimpiar.UseVisualStyleBackColor = False
        ' 
        ' btnActualizar
        ' 
        btnActualizar.BackColor = Color.White
        btnActualizar.Cursor = Cursors.Hand
        btnActualizar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnActualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnActualizar.FlatStyle = FlatStyle.Flat
        btnActualizar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnActualizar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizar.Location = New Point(300, 0)
        btnActualizar.Margin = New Padding(0, 0, 10, 4)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(120, 36)
        btnActualizar.TabIndex = 2
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = False
        ' 
        ' chkAutomatico
        ' 
        chkAutomatico.Checked = True
        chkAutomatico.CheckState = CheckState.Checked
        chkAutomatico.Location = New Point(438, 0)
        chkAutomatico.Margin = New Padding(8, 0, 0, 4)
        chkAutomatico.Name = "chkAutomatico"
        chkAutomatico.Size = New Size(260, 36)
        chkAutomatico.TabIndex = 3
        chkAutomatico.Text = "Actualizar automáticamente (3 s)"
        ' 
        ' tablaBitacora
        ' 
        tablaBitacora.AllowUserToAddRows = False
        tablaBitacora.AllowUserToDeleteRows = False
        tablaBitacora.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(255))
        tablaBitacora.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        tablaBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaBitacora.BackgroundColor = Color.White
        tablaBitacora.BorderStyle = BorderStyle.None
        tablaBitacora.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(235), CByte(238), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(20), CByte(20), CByte(30))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(235), CByte(238), CByte(255))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(20), CByte(20), CByte(30))
        tablaBitacora.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        tablaBitacora.ColumnHeadersHeight = 40
        tablaBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(20), CByte(20), CByte(30))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(220), CByte(225), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(20), CByte(20), CByte(30))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        tablaBitacora.DefaultCellStyle = DataGridViewCellStyle3
        tablaBitacora.Dock = DockStyle.Fill
        tablaBitacora.EnableHeadersVisualStyles = False
        tablaBitacora.GridColor = Color.FromArgb(CByte(222), CByte(225), CByte(236))
        tablaBitacora.Location = New Point(24, 214)
        tablaBitacora.Margin = New Padding(0)
        tablaBitacora.MultiSelect = False
        tablaBitacora.Name = "tablaBitacora"
        tablaBitacora.ReadOnly = True
        tablaBitacora.RowHeadersVisible = False
        tablaBitacora.RowHeadersWidth = 51
        tablaBitacora.RowTemplate.Height = 36
        tablaBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaBitacora.Size = New Size(1052, 322)
        tablaBitacora.TabIndex = 3
        ' 
        ' panelCadena
        ' 
        panelCadena.Controls.Add(txtCadena)
        panelCadena.Controls.Add(lblCadena)
        panelCadena.Dock = DockStyle.Fill
        panelCadena.Location = New Point(24, 536)
        panelCadena.Margin = New Padding(0)
        panelCadena.Name = "panelCadena"
        panelCadena.Padding = New Padding(0, 8, 0, 0)
        panelCadena.Size = New Size(1052, 110)
        panelCadena.TabIndex = 4
        ' 
        ' txtCadena
        ' 
        txtCadena.BackColor = Color.White
        txtCadena.Dock = DockStyle.Fill
        txtCadena.Font = New Font("Consolas", 10.0F)
        txtCadena.Location = New Point(0, 32)
        txtCadena.Multiline = True
        txtCadena.Name = "txtCadena"
        txtCadena.ReadOnly = True
        txtCadena.ScrollBars = ScrollBars.Both
        txtCadena.Size = New Size(1052, 78)
        txtCadena.TabIndex = 0
        txtCadena.WordWrap = False
        ' 
        ' lblCadena
        ' 
        lblCadena.Dock = DockStyle.Top
        lblCadena.Font = New Font("Segoe UI Semibold", 9.0F)
        lblCadena.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblCadena.Location = New Point(0, 8)
        lblCadena.Name = "lblCadena"
        lblCadena.Size = New Size(1052, 24)
        lblCadena.TabIndex = 1
        lblCadena.Text = "Cadena del movimiento seleccionado"
        ' 
        ' lblResumen
        ' 
        lblResumen.Dock = DockStyle.Fill
        lblResumen.Font = New Font("Segoe UI", 9.5F)
        lblResumen.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblResumen.Location = New Point(24, 646)
        lblResumen.Margin = New Padding(0)
        lblResumen.Name = "lblResumen"
        lblResumen.Size = New Size(1052, 40)
        lblResumen.TabIndex = 5
        lblResumen.Text = "Sin movimientos cargados."
        lblResumen.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' actualizador
        ' 
        actualizador.Interval = 3000
        ' 
        ' frmBitacora
        ' 
        AutoScaleDimensions = New SizeF(9.0F, 23.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1100, 700)
        Controls.Add(layoutBitacora)
        Font = New Font("Segoe UI", 10.0F)
        Name = "frmBitacora"
        Text = "Bitácora · Reporte"
        layoutBitacora.ResumeLayout(False)
        layoutBitacora.PerformLayout()
        encabezado.ResumeLayout(False)
        barraFiltros.ResumeLayout(False)
        panelDesde.ResumeLayout(False)
        panelHasta.ResumeLayout(False)
        panelUsuario.ResumeLayout(False)
        CType(numUsuario, ISupportInitialize).EndInit()
        panelObjeto.ResumeLayout(False)
        panelObjeto.PerformLayout()
        panelAccion.ResumeLayout(False)
        barraAcciones.ResumeLayout(False)
        CType(tablaBitacora, ISupportInitialize).EndInit()
        panelCadena.ResumeLayout(False)
        panelCadena.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents layoutBitacora As TableLayoutPanel
    Friend WithEvents encabezado As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents barraFiltros As FlowLayoutPanel
    Friend WithEvents panelDesde As Panel
    Friend WithEvents lblDesde As Label
    Friend WithEvents dtDesde As DateTimePicker
    Friend WithEvents panelHasta As Panel
    Friend WithEvents lblHasta As Label
    Friend WithEvents dtHasta As DateTimePicker
    Friend WithEvents panelUsuario As Panel
    Friend WithEvents chkUsuario As CheckBox
    Friend WithEvents numUsuario As NumericUpDown
    Friend WithEvents panelObjeto As Panel
    Friend WithEvents lblObjeto As Label
    Friend WithEvents txtObjeto As TextBox
    Friend WithEvents panelAccion As Panel
    Friend WithEvents lblAccion As Label
    Friend WithEvents cboAccion As ComboBox
    Friend WithEvents barraAcciones As FlowLayoutPanel
    Friend WithEvents btnAplicar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents chkAutomatico As CheckBox
    Friend WithEvents tablaBitacora As DataGridView
    Friend WithEvents colIdMan As DataGridViewTextBoxColumn
    Friend WithEvents colFechaMan As DataGridViewTextBoxColumn
    Friend WithEvents colHoraMan As DataGridViewTextBoxColumn
    Friend WithEvents colIdUsuario As DataGridViewTextBoxColumn
    Friend WithEvents colObjeto As DataGridViewTextBoxColumn
    Friend WithEvents colAccion As DataGridViewTextBoxColumn
    Friend WithEvents colCadenaMan As DataGridViewTextBoxColumn
    Friend WithEvents panelCadena As Panel
    Friend WithEvents lblCadena As Label
    Friend WithEvents txtCadena As TextBox
    Friend WithEvents lblResumen As Label
    Friend WithEvents actualizador As System.Windows.Forms.Timer
End Class
