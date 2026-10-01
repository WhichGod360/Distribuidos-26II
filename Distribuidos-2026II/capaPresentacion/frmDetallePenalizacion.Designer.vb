<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetallePenalizacion
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
        lblFiltro = New Label()
        cboFiltroSancion = New ComboBox()
        DataGridView1 = New DataGridView()
        colId = New DataGridViewTextBoxColumn()
        colSancion = New DataGridViewTextBoxColumn()
        colMonto = New DataGridViewTextBoxColumn()
        colIdPrestamo = New DataGridViewTextBoxColumn()
        colUsuario = New DataGridViewTextBoxColumn()
        colLibro = New DataGridViewTextBoxColumn()
        colInicio = New DataGridViewTextBoxColumn()
        colVence = New DataGridViewTextBoxColumn()
        colRetorno = New DataGridViewTextBoxColumn()
        colDias = New DataGridViewTextBoxColumn()
        colEstadoPrestamo = New DataGridViewTextBoxColumn()
        colDescripcion = New DataGridViewTextBoxColumn()
        grpDatos = New GroupBox()
        lblId = New Label()
        txtId = New TextBox()
        lblSancion = New Label()
        cboPenalizacion = New ComboBox()
        lblPrestamo = New Label()
        cboPrestamo = New ComboBox()
        lblDescripcion = New Label()
        txtDescripcion = New TextBox()
        btnGuardar = New Button()
        btnLimpiar = New Button()
        pnlCabecera.SuspendLayout()
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
        lblRuta.Text = "Mantenimiento / Sanciones / Detalle"
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
        lblRol.AutoSize = True
        lblRol.BackColor = Color.SlateGray
        lblRol.BorderStyle = BorderStyle.FixedSingle
        lblRol.Font = New Font("Franklin Gothic Demi", 8.25F)
        lblRol.ForeColor = Color.Navy
        lblRol.Location = New Point(892, 17)
        lblRol.Name = "lblRol"
        lblRol.TabIndex = 3
        lblRol.Text = "Bibliotecario"
        lblUsuario.AutoSize = True
        lblUsuario.Font = New Font("Franklin Gothic Demi", 8.25F)
        lblUsuario.ForeColor = SystemColors.ControlDarkDark
        lblUsuario.Location = New Point(801, 18)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.TabIndex = 2
        lblUsuario.Text = "Nombre Usuario"
        ' 
        ' lblMenu / lblTitulo
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
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Franklin Gothic Demi", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitulo.ForeColor = SystemColors.ActiveCaptionText
        lblTitulo.Location = New Point(196, 87)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.TabIndex = 6
        lblTitulo.Text = "Detalle de Sanciones"
        ' 
        ' Filtro
        ' 
        lblFiltro.AutoSize = True
        lblFiltro.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFiltro.Location = New Point(196, 130)
        lblFiltro.Name = "lblFiltro"
        lblFiltro.Text = "Sanción:"
        cboFiltroSancion.DropDownStyle = ComboBoxStyle.DropDownList
        cboFiltroSancion.FormattingEnabled = True
        cboFiltroSancion.Location = New Point(260, 126)
        cboFiltroSancion.Name = "cboFiltroSancion"
        cboFiltroSancion.Size = New Size(380, 23)
        cboFiltroSancion.TabIndex = 7
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
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {colId, colSancion, colMonto, colIdPrestamo, colUsuario, colLibro, colInicio, colVence, colRetorno, colDias, colEstadoPrestamo, colDescripcion})
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = Color.SlateGray
        DataGridView1.Location = New Point(193, 160)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue
        DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black
        DataGridView1.RowTemplate.Height = 32
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(797, 225)
        DataGridView1.TabIndex = 8
        ' 
        ' Columnas
        ' 
        colId.HeaderText = "ID"
        colId.Name = "colId"
        colId.ReadOnly = True
        colId.Width = 45
        colSancion.HeaderText = "Sanción"
        colSancion.Name = "colSancion"
        colSancion.ReadOnly = True
        colSancion.Width = 90
        colMonto.HeaderText = "Monto"
        colMonto.Name = "colMonto"
        colMonto.ReadOnly = True
        colMonto.Width = 75
        colIdPrestamo.HeaderText = "ID Préstamo"
        colIdPrestamo.Name = "colIdPrestamo"
        colIdPrestamo.ReadOnly = True
        colIdPrestamo.Width = 85
        colUsuario.HeaderText = "Usuario"
        colUsuario.Name = "colUsuario"
        colUsuario.ReadOnly = True
        colUsuario.Width = 140
        colLibro.HeaderText = "Libro"
        colLibro.Name = "colLibro"
        colLibro.ReadOnly = True
        colLibro.Width = 170
        colInicio.HeaderText = "Inicio"
        colInicio.Name = "colInicio"
        colInicio.ReadOnly = True
        colInicio.Width = 85
        colVence.HeaderText = "Vencimiento"
        colVence.Name = "colVence"
        colVence.ReadOnly = True
        colVence.Width = 90
        colRetorno.HeaderText = "Retorno"
        colRetorno.Name = "colRetorno"
        colRetorno.ReadOnly = True
        colRetorno.Width = 85
        colDias.HeaderText = "Días retraso"
        colDias.Name = "colDias"
        colDias.ReadOnly = True
        colDias.Width = 85
        colEstadoPrestamo.HeaderText = "Estado préstamo"
        colEstadoPrestamo.Name = "colEstadoPrestamo"
        colEstadoPrestamo.ReadOnly = True
        colEstadoPrestamo.Width = 110
        colDescripcion.HeaderText = "Descripción"
        colDescripcion.Name = "colDescripcion"
        colDescripcion.ReadOnly = True
        colDescripcion.Width = 250
        ' 
        ' grpDatos
        ' 
        grpDatos.Controls.Add(lblId)
        grpDatos.Controls.Add(txtId)
        grpDatos.Controls.Add(lblSancion)
        grpDatos.Controls.Add(cboPenalizacion)
        grpDatos.Controls.Add(lblPrestamo)
        grpDatos.Controls.Add(cboPrestamo)
        grpDatos.Controls.Add(lblDescripcion)
        grpDatos.Controls.Add(txtDescripcion)
        grpDatos.Controls.Add(btnGuardar)
        grpDatos.Controls.Add(btnLimpiar)
        grpDatos.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpDatos.Location = New Point(196, 395)
        grpDatos.Name = "grpDatos"
        grpDatos.Size = New Size(794, 185)
        grpDatos.TabIndex = 9
        grpDatos.TabStop = False
        grpDatos.Text = "Datos del detalle"
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
        lblSancion.AutoSize = True
        lblSancion.Font = New Font("Segoe UI", 9F)
        lblSancion.Location = New Point(115, 26)
        lblSancion.Name = "lblSancion"
        lblSancion.Text = "Sanción"
        cboPenalizacion.DropDownStyle = ComboBoxStyle.DropDownList
        cboPenalizacion.Font = New Font("Segoe UI", 9F)
        cboPenalizacion.FormattingEnabled = True
        cboPenalizacion.Location = New Point(115, 44)
        cboPenalizacion.Name = "cboPenalizacion"
        cboPenalizacion.Size = New Size(300, 23)
        cboPenalizacion.TabIndex = 0
        lblPrestamo.AutoSize = True
        lblPrestamo.Font = New Font("Segoe UI", 9F)
        lblPrestamo.Location = New Point(435, 26)
        lblPrestamo.Name = "lblPrestamo"
        lblPrestamo.Text = "Préstamo (ID - Usuario - Libro)"
        cboPrestamo.DropDownStyle = ComboBoxStyle.DropDownList
        cboPrestamo.Font = New Font("Segoe UI", 9F)
        cboPrestamo.FormattingEnabled = True
        cboPrestamo.Location = New Point(435, 44)
        cboPrestamo.Name = "cboPrestamo"
        cboPrestamo.Size = New Size(340, 23)
        cboPrestamo.TabIndex = 1
        lblDescripcion.AutoSize = True
        lblDescripcion.Font = New Font("Segoe UI", 9F)
        lblDescripcion.Location = New Point(15, 80)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Text = "Descripción del detalle"
        txtDescripcion.Font = New Font("Segoe UI", 9F)
        txtDescripcion.Location = New Point(15, 98)
        txtDescripcion.Multiline = True
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.ScrollBars = ScrollBars.Vertical
        txtDescripcion.Size = New Size(560, 70)
        txtDescripcion.TabIndex = 2
        btnGuardar.BackColor = Color.RoyalBlue
        btnGuardar.FlatStyle = FlatStyle.Popup
        btnGuardar.ForeColor = Color.White
        btnGuardar.Location = New Point(600, 98)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(175, 31)
        btnGuardar.TabIndex = 3
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        btnLimpiar.BackColor = Color.RoyalBlue
        btnLimpiar.FlatStyle = FlatStyle.Popup
        btnLimpiar.ForeColor = Color.White
        btnLimpiar.Location = New Point(600, 137)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(175, 31)
        btnLimpiar.TabIndex = 4
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = False
        ' 
        ' frmDetallePenalizacion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1013, 595)
        Controls.Add(grpDatos)
        Controls.Add(DataGridView1)
        Controls.Add(cboFiltroSancion)
        Controls.Add(lblFiltro)
        Controls.Add(lblTitulo)
        Controls.Add(lblMenu)
        Controls.Add(pnlCabecera)
        Controls.Add(lblRuta)
        Name = "frmDetallePenalizacion"
        StartPosition = FormStartPosition.CenterParent
        Text = "Detalle de Sanciones"
        pnlCabecera.ResumeLayout(False)
        pnlCabecera.PerformLayout()
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
    Friend WithEvents lblFiltro As Label
    Friend WithEvents cboFiltroSancion As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents colId As DataGridViewTextBoxColumn
    Friend WithEvents colSancion As DataGridViewTextBoxColumn
    Friend WithEvents colMonto As DataGridViewTextBoxColumn
    Friend WithEvents colIdPrestamo As DataGridViewTextBoxColumn
    Friend WithEvents colUsuario As DataGridViewTextBoxColumn
    Friend WithEvents colLibro As DataGridViewTextBoxColumn
    Friend WithEvents colInicio As DataGridViewTextBoxColumn
    Friend WithEvents colVence As DataGridViewTextBoxColumn
    Friend WithEvents colRetorno As DataGridViewTextBoxColumn
    Friend WithEvents colDias As DataGridViewTextBoxColumn
    Friend WithEvents colEstadoPrestamo As DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents grpDatos As GroupBox
    Friend WithEvents lblId As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents lblSancion As Label
    Friend WithEvents cboPenalizacion As ComboBox
    Friend WithEvents lblPrestamo As Label
    Friend WithEvents cboPrestamo As ComboBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnLimpiar As Button
End Class