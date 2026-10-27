<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUsuarios
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
        Dim estiloEncabezado As New DataGridViewCellStyle()
        Dim estiloCeldas As New DataGridViewCellStyle()
        Dim estiloAlternado As New DataGridViewCellStyle()
        components = New System.ComponentModel.Container()
        layoutMantenimiento = New TableLayoutPanel()
        encabezado = New Panel()
        lblTitulo = New Label()
        lblDescripcion = New Label()
        barraFiltros = New FlowLayoutPanel()
        panelBuscar = New Panel()
        lblBuscar = New Label()
        txtBuscar = New TextBox()
        panelRol = New Panel()
        lblRol = New Label()
        cboRol = New ComboBox()
        panelEstado = New Panel()
        lblEstado = New Label()
        cboEstado = New ComboBox()
        barraAcciones = New FlowLayoutPanel()
        btnAgregar = New Button()
        btnEditar = New Button()
        btnEstado = New Button()
        btnActualizar = New Button()
        tablaUsuarios = New DataGridView()
        colIdUsuario = New DataGridViewTextBoxColumn()
        colNombreCompleto = New DataGridViewTextBoxColumn()
        colEmailUsuario = New DataGridViewTextBoxColumn()
        colNumeroDniUsuario = New DataGridViewTextBoxColumn()
        colNombreRol = New DataGridViewTextBoxColumn()
        colEstadoUsuario = New DataGridViewTextBoxColumn()
        lblResumen = New Label()
        layoutMantenimiento.SuspendLayout()
        encabezado.SuspendLayout()
        barraFiltros.SuspendLayout()
        panelBuscar.SuspendLayout()
        panelRol.SuspendLayout()
        panelEstado.SuspendLayout()
        barraAcciones.SuspendLayout()
        CType(tablaUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        ' layoutMantenimiento
        '
        layoutMantenimiento.ColumnCount = 1
        layoutMantenimiento.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        layoutMantenimiento.Controls.Add(encabezado, 0, 0)
        layoutMantenimiento.Controls.Add(barraFiltros, 0, 1)
        layoutMantenimiento.Controls.Add(barraAcciones, 0, 2)
        layoutMantenimiento.Controls.Add(tablaUsuarios, 0, 3)
        layoutMantenimiento.Controls.Add(lblResumen, 0, 4)
        layoutMantenimiento.Dock = DockStyle.Fill
        layoutMantenimiento.Location = New Point(0, 0)
        layoutMantenimiento.Name = "layoutMantenimiento"
        layoutMantenimiento.Padding = New Padding(24, 18, 24, 14)
        layoutMantenimiento.RowCount = 5
        layoutMantenimiento.RowStyles.Add(New RowStyle(SizeType.Absolute, 78.0F))
        layoutMantenimiento.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        layoutMantenimiento.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        layoutMantenimiento.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        layoutMantenimiento.RowStyles.Add(New RowStyle(SizeType.Absolute, 40.0F))
        layoutMantenimiento.Size = New Size(1034, 641)
        layoutMantenimiento.TabIndex = 0
        '
        ' encabezado
        '
        encabezado.Controls.Add(lblDescripcion)
        encabezado.Controls.Add(lblTitulo)
        encabezado.Dock = DockStyle.Fill
        encabezado.Margin = New Padding(0)
        encabezado.Name = "encabezado"
        encabezado.TabIndex = 0
        '
        ' lblTitulo
        '
        lblTitulo.Dock = DockStyle.Top
        lblTitulo.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblTitulo.ForeColor = Color.FromArgb(47, 72, 92)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(986, 37)
        lblTitulo.Text = "Usuarios"
        '
        ' lblDescripcion
        '
        lblDescripcion.AutoEllipsis = True
        lblDescripcion.Dock = DockStyle.Fill
        lblDescripcion.ForeColor = Color.FromArgb(120, 120, 120)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Text = "Administra las cuentas y los permisos de la biblioteca."
        '
        ' barraFiltros
        '
        barraFiltros.AutoSize = True
        barraFiltros.Controls.Add(panelBuscar)
        barraFiltros.Controls.Add(panelRol)
        barraFiltros.Controls.Add(panelEstado)
        barraFiltros.Dock = DockStyle.Fill
        barraFiltros.Margin = New Padding(0, 0, 0, 10)
        barraFiltros.Name = "barraFiltros"
        barraFiltros.TabIndex = 1
        '
        ' panelBuscar
        '
        panelBuscar.Controls.Add(txtBuscar)
        panelBuscar.Controls.Add(lblBuscar)
        panelBuscar.Margin = New Padding(0, 0, 14, 0)
        panelBuscar.Name = "panelBuscar"
        panelBuscar.Size = New Size(310, 62)
        panelBuscar.TabIndex = 0
        '
        ' lblBuscar
        '
        lblBuscar.Dock = DockStyle.Top
        lblBuscar.Font = New Font("Segoe UI Semibold", 9.0F)
        lblBuscar.ForeColor = Color.FromArgb(47, 72, 92)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(310, 24)
        lblBuscar.Text = "Buscar"
        '
        ' txtBuscar
        '
        txtBuscar.Dock = DockStyle.Top
        txtBuscar.MaxLength = 100
        txtBuscar.PlaceholderText = "Nombre, correo o DNI"
        txtBuscar.Name = "txtBuscar"
        txtBuscar.TabIndex = 0
        '
        ' panelRol
        '
        panelRol.Controls.Add(cboRol)
        panelRol.Controls.Add(lblRol)
        panelRol.Margin = New Padding(0, 0, 14, 0)
        panelRol.Name = "panelRol"
        panelRol.Size = New Size(160, 62)
        panelRol.TabIndex = 1
        '
        ' lblRol
        '
        lblRol.Dock = DockStyle.Top
        lblRol.Font = New Font("Segoe UI Semibold", 9.0F)
        lblRol.ForeColor = Color.FromArgb(47, 72, 92)
        lblRol.Name = "lblRol"
        lblRol.Size = New Size(160, 24)
        lblRol.Text = "Rol"
        '
        ' cboRol
        '
        cboRol.Dock = DockStyle.Top
        cboRol.DropDownStyle = ComboBoxStyle.DropDownList
        cboRol.Name = "cboRol"
        cboRol.TabIndex = 0
        '
        ' panelEstado
        '
        panelEstado.Controls.Add(cboEstado)
        panelEstado.Controls.Add(lblEstado)
        panelEstado.Margin = New Padding(0, 0, 14, 0)
        panelEstado.Name = "panelEstado"
        panelEstado.Size = New Size(160, 62)
        panelEstado.TabIndex = 2
        '
        ' lblEstado
        '
        lblEstado.Dock = DockStyle.Top
        lblEstado.Font = New Font("Segoe UI Semibold", 9.0F)
        lblEstado.ForeColor = Color.FromArgb(47, 72, 92)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(160, 24)
        lblEstado.Text = "Estado"
        '
        ' cboEstado
        '
        cboEstado.Dock = DockStyle.Top
        cboEstado.DropDownStyle = ComboBoxStyle.DropDownList
        cboEstado.Items.AddRange(New Object() {"Todos", "Activo", "Inactivo"})
        cboEstado.Name = "cboEstado"
        cboEstado.TabIndex = 0
        '
        ' barraAcciones
        '
        barraAcciones.AutoSize = True
        barraAcciones.Controls.Add(btnAgregar)
        barraAcciones.Controls.Add(btnEditar)
        barraAcciones.Controls.Add(btnEstado)
        barraAcciones.Controls.Add(btnActualizar)
        barraAcciones.Dock = DockStyle.Fill
        barraAcciones.Margin = New Padding(0, 0, 0, 12)
        barraAcciones.Name = "barraAcciones"
        barraAcciones.TabIndex = 2
        '
        ' btnAgregar
        '
        btnAgregar.BackColor = Color.FromArgb(59, 91, 115)
        btnAgregar.Cursor = Cursors.Hand
        btnAgregar.FlatAppearance.BorderSize = 0
        btnAgregar.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 56, 72)
        btnAgregar.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 72, 92)
        btnAgregar.FlatStyle = FlatStyle.Flat
        btnAgregar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnAgregar.ForeColor = Color.White
        btnAgregar.Margin = New Padding(0, 0, 10, 4)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(150, 36)
        btnAgregar.TabIndex = 0
        btnAgregar.Text = "Agregar usuario"
        btnAgregar.UseVisualStyleBackColor = False
        '
        ' btnEditar
        '
        btnEditar.BackColor = Color.White
        btnEditar.Cursor = Cursors.Hand
        btnEditar.Enabled = False
        btnEditar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        btnEditar.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 232, 238)
        btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 244, 247)
        btnEditar.FlatStyle = FlatStyle.Flat
        btnEditar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnEditar.ForeColor = Color.FromArgb(59, 91, 115)
        btnEditar.Margin = New Padding(0, 0, 10, 4)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(110, 36)
        btnEditar.TabIndex = 1
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = False
        '
        ' btnEstado
        '
        btnEstado.BackColor = Color.White
        btnEstado.Cursor = Cursors.Hand
        btnEstado.Enabled = False
        btnEstado.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        btnEstado.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 232, 238)
        btnEstado.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 244, 247)
        btnEstado.FlatStyle = FlatStyle.Flat
        btnEstado.Font = New Font("Segoe UI Semibold", 10.0F)
        btnEstado.ForeColor = Color.FromArgb(59, 91, 115)
        btnEstado.Margin = New Padding(0, 0, 10, 4)
        btnEstado.Name = "btnEstado"
        btnEstado.Size = New Size(180, 36)
        btnEstado.TabIndex = 2
        btnEstado.Text = "Activar / desactivar"
        btnEstado.UseVisualStyleBackColor = False
        '
        ' btnActualizar
        '
        btnActualizar.BackColor = Color.White
        btnActualizar.Cursor = Cursors.Hand
        btnActualizar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        btnActualizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 232, 238)
        btnActualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 244, 247)
        btnActualizar.FlatStyle = FlatStyle.Flat
        btnActualizar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnActualizar.ForeColor = Color.FromArgb(59, 91, 115)
        btnActualizar.Margin = New Padding(0, 0, 10, 4)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(110, 36)
        btnActualizar.TabIndex = 3
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = False
        '
        ' estiloEncabezado
        '
        estiloEncabezado.BackColor = Color.FromArgb(235, 238, 255)
        estiloEncabezado.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        estiloEncabezado.ForeColor = Color.FromArgb(20, 20, 30)
        estiloEncabezado.SelectionBackColor = Color.FromArgb(235, 238, 255)
        estiloEncabezado.SelectionForeColor = Color.FromArgb(20, 20, 30)
        '
        ' estiloCeldas
        '
        estiloCeldas.BackColor = Color.White
        estiloCeldas.Font = New Font("Segoe UI", 10.0F)
        estiloCeldas.ForeColor = Color.FromArgb(20, 20, 30)
        estiloCeldas.SelectionBackColor = Color.FromArgb(220, 225, 255)
        estiloCeldas.SelectionForeColor = Color.FromArgb(20, 20, 30)
        '
        ' estiloAlternado
        '
        estiloAlternado.BackColor = Color.FromArgb(249, 250, 255)
        '
        ' tablaUsuarios
        '
        tablaUsuarios.AllowUserToAddRows = False
        tablaUsuarios.AllowUserToDeleteRows = False
        tablaUsuarios.AutoGenerateColumns = False
        tablaUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaUsuarios.BackgroundColor = Color.White
        tablaUsuarios.BorderStyle = BorderStyle.None
        tablaUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        tablaUsuarios.ColumnHeadersDefaultCellStyle = estiloEncabezado
        tablaUsuarios.ColumnHeadersHeight = 40
        tablaUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        tablaUsuarios.Columns.AddRange(New DataGridViewColumn() {colIdUsuario, colNombreCompleto, colEmailUsuario, colNumeroDniUsuario, colNombreRol, colEstadoUsuario})
        tablaUsuarios.DefaultCellStyle = estiloCeldas
        tablaUsuarios.AlternatingRowsDefaultCellStyle = estiloAlternado
        tablaUsuarios.Dock = DockStyle.Fill
        tablaUsuarios.EnableHeadersVisualStyles = False
        tablaUsuarios.GridColor = Color.FromArgb(222, 225, 236)
        tablaUsuarios.Margin = New Padding(0)
        tablaUsuarios.MultiSelect = False
        tablaUsuarios.Name = "tablaUsuarios"
        tablaUsuarios.ReadOnly = True
        tablaUsuarios.RowHeadersVisible = False
        tablaUsuarios.RowTemplate.Height = 36
        tablaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaUsuarios.TabIndex = 3
        '
        ' colIdUsuario
        '
        colIdUsuario.DataPropertyName = "IdUsuario"
        colIdUsuario.FillWeight = 35.0F
        colIdUsuario.HeaderText = "ID"
        colIdUsuario.Name = "IdUsuario"
        colIdUsuario.ReadOnly = True
        '
        ' colNombreCompleto
        '
        colNombreCompleto.DataPropertyName = "NombreCompleto"
        colNombreCompleto.FillWeight = 170.0F
        colNombreCompleto.HeaderText = "Usuario"
        colNombreCompleto.Name = "NombreCompleto"
        colNombreCompleto.ReadOnly = True
        '
        ' colEmailUsuario
        '
        colEmailUsuario.DataPropertyName = "EmailUsuario"
        colEmailUsuario.FillWeight = 160.0F
        colEmailUsuario.HeaderText = "Correo"
        colEmailUsuario.Name = "EmailUsuario"
        colEmailUsuario.ReadOnly = True
        '
        ' colNumeroDniUsuario
        '
        colNumeroDniUsuario.DataPropertyName = "NumeroDniUsuario"
        colNumeroDniUsuario.FillWeight = 100.0F
        colNumeroDniUsuario.HeaderText = "DNI"
        colNumeroDniUsuario.Name = "NumeroDniUsuario"
        colNumeroDniUsuario.ReadOnly = True
        '
        ' colNombreRol
        '
        colNombreRol.DataPropertyName = "NombreRol"
        colNombreRol.FillWeight = 100.0F
        colNombreRol.HeaderText = "Rol"
        colNombreRol.Name = "NombreRol"
        colNombreRol.ReadOnly = True
        '
        ' colEstadoUsuario
        '
        colEstadoUsuario.DataPropertyName = "EstadoUsuario"
        colEstadoUsuario.FillWeight = 100.0F
        colEstadoUsuario.HeaderText = "Estado"
        colEstadoUsuario.Name = "EstadoUsuario"
        colEstadoUsuario.ReadOnly = True
        '
        ' lblResumen
        '
        lblResumen.Dock = DockStyle.Fill
        lblResumen.Font = New Font("Segoe UI", 9.5F)
        lblResumen.ForeColor = Color.FromArgb(120, 120, 120)
        lblResumen.Margin = New Padding(0)
        lblResumen.Name = "lblResumen"
        lblResumen.TextAlign = ContentAlignment.MiddleLeft
        '
        ' frmUsuarios
        '
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1034, 641)
        Controls.Add(layoutMantenimiento)
        Font = New Font("Segoe UI", 10.0F)
        Name = "frmUsuarios"
        Text = "Usuarios"
        layoutMantenimiento.ResumeLayout(False)
        layoutMantenimiento.PerformLayout()
        encabezado.ResumeLayout(False)
        barraFiltros.ResumeLayout(False)
        panelBuscar.ResumeLayout(False)
        panelBuscar.PerformLayout()
        panelRol.ResumeLayout(False)
        panelEstado.ResumeLayout(False)
        barraAcciones.ResumeLayout(False)
        CType(tablaUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents layoutMantenimiento As TableLayoutPanel
    Friend WithEvents encabezado As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents barraFiltros As FlowLayoutPanel
    Friend WithEvents panelBuscar As Panel
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents panelRol As Panel
    Friend WithEvents lblRol As Label
    Friend WithEvents cboRol As ComboBox
    Friend WithEvents panelEstado As Panel
    Friend WithEvents lblEstado As Label
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents barraAcciones As FlowLayoutPanel
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnEstado As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents tablaUsuarios As DataGridView
    Friend WithEvents colIdUsuario As DataGridViewTextBoxColumn
    Friend WithEvents colNombreCompleto As DataGridViewTextBoxColumn
    Friend WithEvents colEmailUsuario As DataGridViewTextBoxColumn
    Friend WithEvents colNumeroDniUsuario As DataGridViewTextBoxColumn
    Friend WithEvents colNombreRol As DataGridViewTextBoxColumn
    Friend WithEvents colEstadoUsuario As DataGridViewTextBoxColumn
    Friend WithEvents lblResumen As Label
End Class
