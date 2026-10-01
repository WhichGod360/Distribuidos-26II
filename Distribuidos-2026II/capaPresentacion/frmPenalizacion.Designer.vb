<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPenalizacion
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        lblRuta = New Label()
        pnlCabecera = New Panel()
        lblLogo = New Label()
        lblRol = New Label()
        lblUsuario = New Label()
        lblMenu = New Label()
        lblTitulo = New Label()
        pnlBuscar = New Panel()
        txtBuscar = New TextBox()
        cboFiltroEstado = New ComboBox()
        pnlNuevo = New Panel()
        btnNuevo = New Button()
        DataGridView1 = New DataGridView()
        colId = New DataGridViewTextBoxColumn()
        colTipo = New DataGridViewTextBoxColumn()
        colMonto = New DataGridViewTextBoxColumn()
        colDescripcion = New DataGridViewTextBoxColumn()
        colEstado = New DataGridViewTextBoxColumn()
        grpDatos = New GroupBox()
        lblId = New Label()
        txtId = New TextBox()
        lblTipo = New Label()
        txtTipo = New TextBox()
        lblMonto = New Label()
        txtMonto = New TextBox()
        lblEstado = New Label()
        cboEstadoReg = New ComboBox()
        lblDescripcion = New Label()
        txtDescripcion = New TextBox()
        btnGuardar = New Button()
        btnLimpiar = New Button()
        btnCambiarEstado = New Button()
        btnVerDetalles = New Button()
        pnlCabecera.SuspendLayout()
        pnlBuscar.SuspendLayout()
        pnlNuevo.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        grpDatos.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblRuta
        ' 
        lblRuta.AutoSize = True
        lblRuta.Font = New Font("Franklin Gothic Demi", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRuta.ForeColor = SystemColors.ControlDarkDark
        lblRuta.Location = New Point(196, 66)
        lblRuta.Name = "lblRuta"
        lblRuta.TabIndex = 0
        lblRuta.Text = "Mantenimiento / Sanciones"
        ' 
        ' pnlCabecera
        ' 
        pnlCabecera.BorderStyle = BorderStyle.Fixed3D
        pnlCabecera.Controls.Add(lblLogo)
        pnlCabecera.Controls.Add(lblRol)
        pnlCabecera.Controls.Add(lblUsuario)
        pnlCabecera.Location = New Point(-1, 0)
        pnlCabecera.Name = "pnlCabecera"
        pnlCabecera.Size = New Size(1014, 60)
        pnlCabecera.TabIndex = 1
        ' 
        ' lblLogo
        ' 
        lblLogo.AutoSize = True
        lblLogo.BackColor = Color.LightSlateGray
        lblLogo.BorderStyle = BorderStyle.FixedSingle
        lblLogo.Font = New Font("Franklin Gothic Demi", 8.25F)
        lblLogo.ForeColor = Color.Navy
        lblLogo.Location = New Point(20, 16)
        lblLogo.Name = "lblLogo"
        lblLogo.TabIndex = 4
        lblLogo.Text = "LOGO"
        ' 
        ' lblRol
        ' 
        lblRol.AutoSize = True
        lblRol.BackColor = Color.SlateGray
        lblRol.BorderStyle = BorderStyle.FixedSingle
        lblRol.Font = New Font("Franklin Gothic Demi", 8.25F)
        lblRol.ForeColor = Color.Navy
        lblRol.Location = New Point(892, 17)
        lblRol.Name = "lblRol"
        lblRol.TabIndex = 3
        lblRol.Text = "Bibliotecario"
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.Font = New Font("Franklin Gothic Demi", 8.25F)
        lblUsuario.ForeColor = SystemColors.ControlDarkDark
        lblUsuario.Location = New Point(801, 18)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.TabIndex = 2
        lblUsuario.Text = "Nombre Usuario"
        ' 
        ' lblMenu
        ' 
        lblMenu.AutoSize = True
        lblMenu.BackColor = Color.LightSlateGray
        lblMenu.BorderStyle = BorderStyle.FixedSingle
        lblMenu.Font = New Font("Franklin Gothic Demi", 8.25F)
        lblMenu.ForeColor = Color.Navy
        lblMenu.Location = New Point(18, 87)
        lblMenu.Name = "lblMenu"
        lblMenu.TabIndex = 5
        lblMenu.Text = "MENÚ"
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Franklin Gothic Demi", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitulo.ForeColor = SystemColors.ActiveCaptionText
        lblTitulo.Location = New Point(196, 87)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.TabIndex = 6
        lblTitulo.Text = "Mantenimiento de Sanciones"
        ' 
        ' pnlBuscar
        ' 
        pnlBuscar.BorderStyle = BorderStyle.FixedSingle
        pnlBuscar.Controls.Add(txtBuscar)
        pnlBuscar.Location = New Point(196, 125)
        pnlBuscar.Name = "pnlBuscar"
        pnlBuscar.Size = New Size(498, 31)
        pnlBuscar.TabIndex = 8
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(43, 3)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.PlaceholderText = "Buscar por tipo o descripción"
        txtBuscar.Size = New Size(450, 23)
        txtBuscar.TabIndex = 7
        ' 
        ' cboFiltroEstado
        ' 
        cboFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList
        cboFiltroEstado.FormattingEnabled = True
        cboFiltroEstado.Location = New Point(716, 129)
        cboFiltroEstado.Name = "cboFiltroEstado"
        cboFiltroEstado.Size = New Size(121, 23)
        cboFiltroEstado.TabIndex = 9
        ' 
        ' pnlNuevo
        ' 
        pnlNuevo.Controls.Add(btnNuevo)
        pnlNuevo.Location = New Point(840, 73)
        pnlNuevo.Name = "pnlNuevo"
        pnlNuevo.Size = New Size(150, 31)
        pnlNuevo.TabIndex = 13
        ' 
        ' btnNuevo
        ' 
        btnNuevo.BackColor = Color.RoyalBlue
        btnNuevo.FlatStyle = FlatStyle.Popup
        btnNuevo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNuevo.ForeColor = Color.White
        btnNuevo.Location = New Point(0, 0)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(150, 31)
        btnNuevo.TabIndex = 14
        btnNuevo.Text = "+ Nueva sanción"
        btnNuevo.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle1.SelectionForeColor = Color.MediumBlue
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeight = 42
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {colId, colTipo, colMonto, colDescripcion, colEstado})
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = Color.SlateGray
        DataGridView1.Location = New Point(193, 170)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue
        DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black
        DataGridView1.RowTemplate.Height = 32
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(797, 200)
        DataGridView1.TabIndex = 15
        ' 
        ' Columnas
        ' 
        colId.HeaderText = "ID"
        colId.Name = "colId"
        colId.ReadOnly = True
        colId.Width = 60
        colTipo.HeaderText = "Tipo"
        colTipo.Name = "colTipo"
        colTipo.ReadOnly = True
        colTipo.Width = 150
        colMonto.HeaderText = "Monto"
        colMonto.Name = "colMonto"
        colMonto.ReadOnly = True
        colMonto.Width = 100
        colDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colDescripcion.HeaderText = "Descripción"
        colDescripcion.Name = "colDescripcion"
        colDescripcion.ReadOnly = True
        colEstado.HeaderText = "Estado"
        colEstado.Name = "colEstado"
        colEstado.ReadOnly = True
        colEstado.Width = 90
        ' 
        ' grpDatos
        ' 
        grpDatos.Controls.Add(lblId)
        grpDatos.Controls.Add(txtId)
        grpDatos.Controls.Add(lblTipo)
        grpDatos.Controls.Add(txtTipo)
        grpDatos.Controls.Add(lblMonto)
        grpDatos.Controls.Add(txtMonto)
        grpDatos.Controls.Add(lblEstado)
        grpDatos.Controls.Add(cboEstadoReg)
        grpDatos.Controls.Add(lblDescripcion)
        grpDatos.Controls.Add(txtDescripcion)
        grpDatos.Controls.Add(btnGuardar)
        grpDatos.Controls.Add(btnLimpiar)
        grpDatos.Controls.Add(btnCambiarEstado)
        grpDatos.Controls.Add(btnVerDetalles)
        grpDatos.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpDatos.Location = New Point(196, 385)
        grpDatos.Name = "grpDatos"
        grpDatos.Size = New Size(794, 185)
        grpDatos.TabIndex = 16
        grpDatos.TabStop = False
        grpDatos.Text = "Datos de la sanción"
        ' 
        ' Campos
        ' 
        lblId.AutoSize = True
        lblId.Font = New Font("Segoe UI", 9F)
        lblId.Location = New Point(15, 26)
        lblId.Name = "lblId"
        lblId.Text = "ID"
        txtId.Font = New Font("Segoe UI", 9F)
        txtId.Location = New Point(15, 44)
        txtId.Name = "txtId"
        txtId.ReadOnly = True
        txtId.Size = New Size(80, 23)
        txtId.TabStop = False
        lblTipo.AutoSize = True
        lblTipo.Font = New Font("Segoe UI", 9F)
        lblTipo.Location = New Point(115, 26)
        lblTipo.Name = "lblTipo"
        lblTipo.Text = "Tipo"
        txtTipo.Font = New Font("Segoe UI", 9F)
        txtTipo.Location = New Point(115, 44)
        txtTipo.MaxLength = 30
        txtTipo.Name = "txtTipo"
        txtTipo.Size = New Size(220, 23)
        txtTipo.TabIndex = 0
        lblMonto.AutoSize = True
        lblMonto.Font = New Font("Segoe UI", 9F)
        lblMonto.Location = New Point(355, 26)
        lblMonto.Name = "lblMonto"
        lblMonto.Text = "Monto (S/)"
        txtMonto.Font = New Font("Segoe UI", 9F)
        txtMonto.Location = New Point(355, 44)
        txtMonto.Name = "txtMonto"
        txtMonto.Size = New Size(100, 23)
        txtMonto.TabIndex = 1
        txtMonto.TextAlign = HorizontalAlignment.Right
        lblEstado.AutoSize = True
        lblEstado.Font = New Font("Segoe UI", 9F)
        lblEstado.Location = New Point(475, 26)
        lblEstado.Name = "lblEstado"
        lblEstado.Text = "Estado"
        cboEstadoReg.DropDownStyle = ComboBoxStyle.DropDownList
        cboEstadoReg.Font = New Font("Segoe UI", 9F)
        cboEstadoReg.FormattingEnabled = True
        cboEstadoReg.Location = New Point(475, 44)
        cboEstadoReg.Name = "cboEstadoReg"
        cboEstadoReg.Size = New Size(120, 23)
        cboEstadoReg.TabIndex = 2
        lblDescripcion.AutoSize = True
        lblDescripcion.Font = New Font("Segoe UI", 9F)
        lblDescripcion.Location = New Point(15, 80)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Text = "Descripción"
        txtDescripcion.Font = New Font("Segoe UI", 9F)
        txtDescripcion.Location = New Point(15, 98)
        txtDescripcion.Multiline = True
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.ScrollBars = ScrollBars.Vertical
        txtDescripcion.Size = New Size(580, 70)
        txtDescripcion.TabIndex = 3
        ' 
        ' Botones
        ' 
        btnGuardar.BackColor = Color.RoyalBlue
        btnGuardar.FlatStyle = FlatStyle.Popup
        btnGuardar.ForeColor = Color.White
        btnGuardar.Location = New Point(620, 26)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(155, 31)
        btnGuardar.TabIndex = 4
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        btnLimpiar.BackColor = Color.RoyalBlue
        btnLimpiar.FlatStyle = FlatStyle.Popup
        btnLimpiar.ForeColor = Color.White
        btnLimpiar.Location = New Point(620, 62)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(155, 31)
        btnLimpiar.TabIndex = 5
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = False
        btnCambiarEstado.BackColor = Color.RoyalBlue
        btnCambiarEstado.FlatStyle = FlatStyle.Popup
        btnCambiarEstado.ForeColor = Color.White
        btnCambiarEstado.Location = New Point(620, 98)
        btnCambiarEstado.Name = "btnCambiarEstado"
        btnCambiarEstado.Size = New Size(155, 31)
        btnCambiarEstado.TabIndex = 6
        btnCambiarEstado.Text = "Desactivar"
        btnCambiarEstado.UseVisualStyleBackColor = False
        btnVerDetalles.BackColor = Color.RoyalBlue
        btnVerDetalles.FlatStyle = FlatStyle.Popup
        btnVerDetalles.ForeColor = Color.White
        btnVerDetalles.Location = New Point(620, 134)
        btnVerDetalles.Name = "btnVerDetalles"
        btnVerDetalles.Size = New Size(155, 31)
        btnVerDetalles.TabIndex = 7
        btnVerDetalles.Text = "Ver detalles"
        btnVerDetalles.UseVisualStyleBackColor = False
        ' 
        ' frmPenalizacion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1013, 585)
        Controls.Add(grpDatos)
        Controls.Add(DataGridView1)
        Controls.Add(pnlNuevo)
        Controls.Add(cboFiltroEstado)
        Controls.Add(pnlBuscar)
        Controls.Add(lblTitulo)
        Controls.Add(lblMenu)
        Controls.Add(pnlCabecera)
        Controls.Add(lblRuta)
        Name = "frmPenalizacion"
        StartPosition = FormStartPosition.CenterParent
        Text = "Mantenimiento de Sanciones"
        pnlCabecera.ResumeLayout(False)
        pnlCabecera.PerformLayout()
        pnlBuscar.ResumeLayout(False)
        pnlBuscar.PerformLayout()
        pnlNuevo.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        grpDatos.ResumeLayout(False)
        grpDatos.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblRuta As Label
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents lblLogo As Label
    Friend WithEvents lblRol As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblMenu As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlBuscar As Panel
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents cboFiltroEstado As ComboBox
    Friend WithEvents pnlNuevo As Panel
    Friend WithEvents btnNuevo As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents colId As DataGridViewTextBoxColumn
    Friend WithEvents colTipo As DataGridViewTextBoxColumn
    Friend WithEvents colMonto As DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents colEstado As DataGridViewTextBoxColumn
    Friend WithEvents grpDatos As GroupBox
    Friend WithEvents lblId As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents txtTipo As TextBox
    Friend WithEvents lblMonto As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents cboEstadoReg As ComboBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnCambiarEstado As Button
    Friend WithEvents btnVerDetalles As Button
End Class