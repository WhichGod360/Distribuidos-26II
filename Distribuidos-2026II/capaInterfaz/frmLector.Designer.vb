<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLector
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As DataGridViewCellStyle = New DataGridViewCellStyle()
        layoutPrincipal = New TableLayoutPanel()
        cabecera = New TableLayoutPanel()
        lblBienvenida = New Label()
        btnSalir = New Button()
        pestanas = New TabControl()
        tabCatalogo = New TabPage()
        tabCarrito = New TabPage()
        tabReservas = New TabPage()
        tabPrestamos = New TabPage()
        tabPenalizaciones = New TabPage()
        tabAvisos = New TabPage()
        barraCatalogo = New FlowLayoutPanel()
        txtBuscar = New TextBox()
        cboCategoria = New ComboBox()
        btnActualizar = New Button()
        panelCatalogo = New FlowLayoutPanel()
        tablaCarrito = New DataGridView()
        colCarritoIdLibro = New DataGridViewTextBoxColumn()
        colCarritoTitulo = New DataGridViewTextBoxColumn()
        colCarritoAutor = New DataGridViewTextBoxColumn()
        accionesCarrito = New FlowLayoutPanel()
        btnQuitar = New Button()
        btnVaciar = New Button()
        btnSolicitar = New Button()
        lblNotaCarrito = New Label()
        tablaReservas = New DataGridView()
        accionesReservas = New FlowLayoutPanel()
        btnCancelar = New Button()
        tablaPrestamos = New DataGridView()
        tablaPenalizaciones = New DataGridView()
        resumenPenalizaciones = New TableLayoutPanel()
        lblTotalPenalizaciones = New Label()
        lblPendientePenalizaciones = New Label()
        lblPorRevisarPenalizaciones = New Label()
        lblPagadoPenalizaciones = New Label()
        filtrosPenalizaciones = New FlowLayoutPanel()
        lblFiltroPago = New Label()
        cboPagoPenalizaciones = New ComboBox()
        btnActualizarPenalizaciones = New Button()
        lblAvisoPenalizaciones = New Label()
        tablaAvisos = New DataGridView()
        btnActualizarAvisos = New Button()
        lblEstado = New Label()
        layoutPrincipal.SuspendLayout()
        cabecera.SuspendLayout()
        pestanas.SuspendLayout()
        tabCatalogo.SuspendLayout()
        tabCarrito.SuspendLayout()
        tabReservas.SuspendLayout()
        tabPrestamos.SuspendLayout()
        tabPenalizaciones.SuspendLayout()
        tabAvisos.SuspendLayout()
        barraCatalogo.SuspendLayout()
        panelCatalogo.SuspendLayout()
        accionesCarrito.SuspendLayout()
        accionesReservas.SuspendLayout()
        resumenPenalizaciones.SuspendLayout()
        filtrosPenalizaciones.SuspendLayout()
        CType(tablaCarrito, ISupportInitialize).BeginInit()
        CType(tablaReservas, ISupportInitialize).BeginInit()
        CType(tablaPrestamos, ISupportInitialize).BeginInit()
        CType(tablaPenalizaciones, ISupportInitialize).BeginInit()
        CType(tablaAvisos, ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' layoutPrincipal
        ' 
        layoutPrincipal.ColumnCount = 1
        layoutPrincipal.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        layoutPrincipal.Controls.Add(cabecera, 0, 0)
        layoutPrincipal.Controls.Add(pestanas, 0, 1)
        layoutPrincipal.Controls.Add(lblEstado, 0, 2)
        layoutPrincipal.Dock = DockStyle.Fill
        layoutPrincipal.Location = New Point(0, 0)
        layoutPrincipal.Name = "layoutPrincipal"
        layoutPrincipal.Padding = New Padding(24, 18, 24, 14)
        layoutPrincipal.RowCount = 3
        layoutPrincipal.RowStyles.Add(New RowStyle(SizeType.Absolute, 70.0F))
        layoutPrincipal.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        layoutPrincipal.RowStyles.Add(New RowStyle(SizeType.Absolute, 40.0F))
        layoutPrincipal.Size = New Size(1180, 720)
        layoutPrincipal.TabIndex = 0
        ' 
        ' cabecera
        ' 
        cabecera.ColumnCount = 2
        cabecera.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        cabecera.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 160.0F))
        cabecera.Controls.Add(lblBienvenida, 0, 0)
        cabecera.Controls.Add(btnSalir, 1, 0)
        cabecera.Dock = DockStyle.Fill
        cabecera.Location = New Point(24, 18)
        cabecera.Margin = New Padding(0)
        cabecera.Name = "cabecera"
        cabecera.RowCount = 1
        cabecera.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        cabecera.Size = New Size(1132, 70)
        cabecera.TabIndex = 0
        ' 
        ' lblBienvenida  (título)
        ' 
        lblBienvenida.Dock = DockStyle.Fill
        lblBienvenida.Font = New Font("Segoe UI", 17.0F, FontStyle.Bold)
        lblBienvenida.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblBienvenida.Location = New Point(0, 0)
        lblBienvenida.Margin = New Padding(0)
        lblBienvenida.Name = "lblBienvenida"
        lblBienvenida.Size = New Size(972, 70)
        lblBienvenida.TabIndex = 0
        lblBienvenida.Text = "Mi biblioteca"
        lblBienvenida.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' btnSalir  (secundario)
        ' 
        btnSalir.BackColor = Color.White
        btnSalir.Cursor = Cursors.Hand
        btnSalir.Dock = DockStyle.Fill
        btnSalir.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnSalir.FlatAppearance.BorderSize = 1
        btnSalir.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnSalir.FlatStyle = FlatStyle.Flat
        btnSalir.Font = New Font("Segoe UI Semibold", 10.0F)
        btnSalir.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnSalir.Location = New Point(972, 0)
        btnSalir.Margin = New Padding(0, 15, 0, 15)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(160, 40)
        btnSalir.TabIndex = 1
        btnSalir.Text = "Cerrar sesión"
        btnSalir.UseVisualStyleBackColor = False
        ' 
        ' pestanas
        ' 
        pestanas.Controls.Add(tabCatalogo)
        pestanas.Controls.Add(tabCarrito)
        pestanas.Controls.Add(tabReservas)
        pestanas.Controls.Add(tabPrestamos)
        pestanas.Controls.Add(tabPenalizaciones)
        pestanas.Controls.Add(tabAvisos)
        pestanas.Dock = DockStyle.Fill
        pestanas.Location = New Point(24, 88)
        pestanas.Margin = New Padding(0)
        pestanas.Name = "pestanas"
        pestanas.SelectedIndex = 0
        pestanas.Size = New Size(1132, 578)
        pestanas.TabIndex = 1
        ' 
        ' tabCatalogo  (pestaña)
        ' 
        tabCatalogo.BackColor = Color.White
        tabCatalogo.Location = New Point(4, 32)
        tabCatalogo.Name = "tabCatalogo"
        tabCatalogo.Padding = New Padding(12)
        tabCatalogo.Size = New Size(1100, 560)
        tabCatalogo.TabIndex = 0
        tabCatalogo.Text = "Catálogo"
        tabCatalogo.UseVisualStyleBackColor = False
        tabCatalogo.Controls.Add(panelCatalogo)
        tabCatalogo.Controls.Add(barraCatalogo)
        ' 
        ' tabCarrito  (pestaña)
        ' 
        tabCarrito.BackColor = Color.White
        tabCarrito.Location = New Point(4, 32)
        tabCarrito.Name = "tabCarrito"
        tabCarrito.Padding = New Padding(12)
        tabCarrito.Size = New Size(1100, 560)
        tabCarrito.TabIndex = 1
        tabCarrito.Text = "Carrito"
        tabCarrito.UseVisualStyleBackColor = False
        tabCarrito.Controls.Add(tablaCarrito)
        tabCarrito.Controls.Add(accionesCarrito)
        ' 
        ' tabReservas  (pestaña)
        ' 
        tabReservas.BackColor = Color.White
        tabReservas.Location = New Point(4, 32)
        tabReservas.Name = "tabReservas"
        tabReservas.Padding = New Padding(12)
        tabReservas.Size = New Size(1100, 560)
        tabReservas.TabIndex = 2
        tabReservas.Text = "Mis reservas"
        tabReservas.UseVisualStyleBackColor = False
        tabReservas.Controls.Add(tablaReservas)
        tabReservas.Controls.Add(accionesReservas)
        ' 
        ' tabPrestamos  (pestaña)
        ' 
        tabPrestamos.BackColor = Color.White
        tabPrestamos.Location = New Point(4, 32)
        tabPrestamos.Name = "tabPrestamos"
        tabPrestamos.Padding = New Padding(12)
        tabPrestamos.Size = New Size(1100, 560)
        tabPrestamos.TabIndex = 3
        tabPrestamos.Text = "Mis préstamos"
        tabPrestamos.UseVisualStyleBackColor = False
        tabPrestamos.Controls.Add(tablaPrestamos)
        ' 
        ' tabPenalizaciones  (pestaña)
        ' 
        tabPenalizaciones.BackColor = Color.White
        tabPenalizaciones.Location = New Point(4, 32)
        tabPenalizaciones.Name = "tabPenalizaciones"
        tabPenalizaciones.Padding = New Padding(12)
        tabPenalizaciones.Size = New Size(1100, 560)
        tabPenalizaciones.TabIndex = 4
        tabPenalizaciones.Text = "Mis penalizaciones"
        tabPenalizaciones.UseVisualStyleBackColor = False
        tabPenalizaciones.Controls.Add(tablaPenalizaciones)
        tabPenalizaciones.Controls.Add(filtrosPenalizaciones)
        tabPenalizaciones.Controls.Add(resumenPenalizaciones)
        tabPenalizaciones.Controls.Add(lblAvisoPenalizaciones)
        ' 
        ' tabAvisos  (pestaña)
        ' 
        tabAvisos.BackColor = Color.White
        tabAvisos.Location = New Point(4, 32)
        tabAvisos.Name = "tabAvisos"
        tabAvisos.Padding = New Padding(12)
        tabAvisos.Size = New Size(1100, 560)
        tabAvisos.TabIndex = 5
        tabAvisos.Text = "Avisos"
        tabAvisos.UseVisualStyleBackColor = False
        tabAvisos.Controls.Add(tablaAvisos)
        tabAvisos.Controls.Add(btnActualizarAvisos)
        ' 
        ' barraCatalogo  (búsqueda)
        ' 
        barraCatalogo.Controls.Add(txtBuscar)
        barraCatalogo.Controls.Add(cboCategoria)
        barraCatalogo.Controls.Add(btnActualizar)
        barraCatalogo.Dock = DockStyle.Top
        barraCatalogo.Location = New Point(12, 12)
        barraCatalogo.Margin = New Padding(0)
        barraCatalogo.Name = "barraCatalogo"
        barraCatalogo.Size = New Size(1076, 44)
        barraCatalogo.TabIndex = 1
        barraCatalogo.WrapContents = False
        ' 
        ' txtBuscar
        ' 
        txtBuscar.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtBuscar.BorderStyle = BorderStyle.FixedSingle
        txtBuscar.Font = New Font("Segoe UI", 11.0F)
        txtBuscar.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtBuscar.Location = New Point(0, 6)
        txtBuscar.Margin = New Padding(0, 6, 12, 0)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.PlaceholderText = "Buscar título, autor o editorial"
        txtBuscar.Size = New Size(290, 27)
        txtBuscar.TabIndex = 0
        ' 
        ' cboCategoria
        ' 
        cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategoria.Font = New Font("Segoe UI", 11.0F)
        cboCategoria.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        cboCategoria.FormattingEnabled = True
        cboCategoria.Location = New Point(302, 6)
        cboCategoria.Margin = New Padding(0, 6, 12, 0)
        cboCategoria.Name = "cboCategoria"
        cboCategoria.Size = New Size(210, 28)
        cboCategoria.TabIndex = 1
        ' 
        ' btnActualizar  (secundario)
        ' 
        btnActualizar.BackColor = Color.White
        btnActualizar.Cursor = Cursors.Hand
        btnActualizar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizar.FlatAppearance.BorderSize = 1
        btnActualizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnActualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnActualizar.FlatStyle = FlatStyle.Flat
        btnActualizar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnActualizar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizar.Location = New Point(524, 6)
        btnActualizar.Margin = New Padding(0, 5, 0, 0)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(120, 32)
        btnActualizar.TabIndex = 2
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = False
        ' 
        ' panelCatalogo
        ' 
        panelCatalogo.AutoScroll = True
        panelCatalogo.Dock = DockStyle.Fill
        panelCatalogo.Location = New Point(12, 12)
        panelCatalogo.Name = "panelCatalogo"
        panelCatalogo.Padding = New Padding(0, 8, 0, 0)
        panelCatalogo.Size = New Size(1076, 536)
        panelCatalogo.TabIndex = 0
        ' 
        ' tablaCarrito  (tabla)
        ' 
        tablaCarrito.AllowUserToAddRows = False
        tablaCarrito.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        tablaCarrito.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        tablaCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaCarrito.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        tablaCarrito.BackgroundColor = Color.White
        tablaCarrito.BorderStyle = BorderStyle.None
        tablaCarrito.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        tablaCarrito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle2.Font = New Font("Segoe UI Semibold", 9.0F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        tablaCarrito.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        tablaCarrito.ColumnHeadersHeight = 40
        tablaCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        tablaCarrito.Columns.AddRange(New DataGridViewColumn() {colCarritoIdLibro, colCarritoTitulo, colCarritoAutor})
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        tablaCarrito.DefaultCellStyle = DataGridViewCellStyle3
        tablaCarrito.Dock = DockStyle.Fill
        tablaCarrito.EnableHeadersVisualStyles = False
        tablaCarrito.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tablaCarrito.Location = New Point(0, 0)
        tablaCarrito.MultiSelect = False
        tablaCarrito.Name = "tablaCarrito"
        tablaCarrito.ReadOnly = True
        tablaCarrito.RowHeadersVisible = False
        tablaCarrito.RowHeadersWidth = 51
        tablaCarrito.RowTemplate.Height = 36
        tablaCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaCarrito.Size = New Size(400, 200)
        tablaCarrito.TabIndex = 0
        ' 
        ' colCarritoIdLibro  (columna)
        ' 
        colCarritoIdLibro.HeaderText = "ID"
        colCarritoIdLibro.MinimumWidth = 6
        colCarritoIdLibro.Name = "IdLibro"
        colCarritoIdLibro.Visible = False
        ' 
        ' colCarritoTitulo  (columna)
        ' 
        colCarritoTitulo.HeaderText = "Libro"
        colCarritoTitulo.MinimumWidth = 6
        colCarritoTitulo.Name = "Titulo"
        ' 
        ' colCarritoAutor  (columna)
        ' 
        colCarritoAutor.HeaderText = "Autor"
        colCarritoAutor.MinimumWidth = 6
        colCarritoAutor.Name = "Autor"
        ' 
        ' accionesCarrito
        ' 
        accionesCarrito.Controls.Add(btnQuitar)
        accionesCarrito.Controls.Add(btnVaciar)
        accionesCarrito.Controls.Add(btnSolicitar)
        accionesCarrito.Controls.Add(lblNotaCarrito)
        accionesCarrito.Dock = DockStyle.Bottom
        accionesCarrito.Location = New Point(12, 448)
        accionesCarrito.Margin = New Padding(0)
        accionesCarrito.Name = "accionesCarrito"
        accionesCarrito.Padding = New Padding(0, 8, 0, 0)
        accionesCarrito.Size = New Size(1076, 100)
        accionesCarrito.TabIndex = 1
        accionesCarrito.SetFlowBreak(btnSolicitar, True)
        ' 
        ' btnQuitar  (secundario)
        ' 
        btnQuitar.BackColor = Color.White
        btnQuitar.Cursor = Cursors.Hand
        btnQuitar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnQuitar.FlatAppearance.BorderSize = 1
        btnQuitar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnQuitar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnQuitar.FlatStyle = FlatStyle.Flat
        btnQuitar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnQuitar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnQuitar.Location = New Point(0, 8)
        btnQuitar.Margin = New Padding(0, 0, 10, 0)
        btnQuitar.Name = "btnQuitar"
        btnQuitar.Size = New Size(170, 36)
        btnQuitar.TabIndex = 0
        btnQuitar.Text = "Quitar seleccionado"
        btnQuitar.UseVisualStyleBackColor = False
        ' 
        ' btnVaciar  (secundario)
        ' 
        btnVaciar.BackColor = Color.White
        btnVaciar.Cursor = Cursors.Hand
        btnVaciar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnVaciar.FlatAppearance.BorderSize = 1
        btnVaciar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnVaciar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnVaciar.FlatStyle = FlatStyle.Flat
        btnVaciar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnVaciar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnVaciar.Location = New Point(180, 8)
        btnVaciar.Margin = New Padding(0, 0, 10, 0)
        btnVaciar.Name = "btnVaciar"
        btnVaciar.Size = New Size(140, 36)
        btnVaciar.TabIndex = 1
        btnVaciar.Text = "Vaciar carrito"
        btnVaciar.UseVisualStyleBackColor = False
        ' 
        ' btnSolicitar  (principal)
        ' 
        btnSolicitar.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnSolicitar.Cursor = Cursors.Hand
        btnSolicitar.FlatAppearance.BorderSize = 0
        btnSolicitar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btnSolicitar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btnSolicitar.FlatStyle = FlatStyle.Flat
        btnSolicitar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnSolicitar.ForeColor = Color.White
        btnSolicitar.Location = New Point(330, 8)
        btnSolicitar.Margin = New Padding(0, 0, 10, 0)
        btnSolicitar.Name = "btnSolicitar"
        btnSolicitar.Size = New Size(170, 36)
        btnSolicitar.TabIndex = 2
        btnSolicitar.Text = "Solicitar reserva"
        btnSolicitar.UseVisualStyleBackColor = False
        ' 
        ' lblNotaCarrito  (nota)
        ' 
        lblNotaCarrito.AutoSize = True
        lblNotaCarrito.Font = New Font("Segoe UI", 9.0F)
        lblNotaCarrito.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblNotaCarrito.Location = New Point(0, 52)
        lblNotaCarrito.Margin = New Padding(0, 8, 0, 0)
        lblNotaCarrito.MaximumSize = New Size(820, 0)
        lblNotaCarrito.Name = "lblNotaCarrito"
        lblNotaCarrito.Size = New Size(815, 32)
        lblNotaCarrito.TabIndex = 3
        lblNotaCarrito.Text = "Una copia por título. Máximo cinco libros pendientes de devolución en total. El recojo vence cinco días después de solicitar; necesitas aprobación previa."
        ' 
        ' tablaReservas  (tabla)
        ' 
        tablaReservas.AllowUserToAddRows = False
        tablaReservas.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        tablaReservas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        tablaReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaReservas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        tablaReservas.BackgroundColor = Color.White
        tablaReservas.BorderStyle = BorderStyle.None
        tablaReservas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        tablaReservas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle5.Font = New Font("Segoe UI Semibold", 9.0F)
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        tablaReservas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        tablaReservas.ColumnHeadersHeight = 40
        tablaReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = Color.White
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        tablaReservas.DefaultCellStyle = DataGridViewCellStyle6
        tablaReservas.Dock = DockStyle.Fill
        tablaReservas.EnableHeadersVisualStyles = False
        tablaReservas.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tablaReservas.Location = New Point(0, 0)
        tablaReservas.MultiSelect = False
        tablaReservas.Name = "tablaReservas"
        tablaReservas.ReadOnly = True
        tablaReservas.RowHeadersVisible = False
        tablaReservas.RowHeadersWidth = 51
        tablaReservas.RowTemplate.Height = 36
        tablaReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaReservas.Size = New Size(400, 200)
        tablaReservas.TabIndex = 0
        ' 
        ' accionesReservas
        ' 
        accionesReservas.Controls.Add(btnCancelar)
        accionesReservas.Dock = DockStyle.Bottom
        accionesReservas.Location = New Point(12, 502)
        accionesReservas.Margin = New Padding(0)
        accionesReservas.Name = "accionesReservas"
        accionesReservas.Padding = New Padding(0, 8, 0, 0)
        accionesReservas.Size = New Size(1076, 46)
        accionesReservas.TabIndex = 1
        ' 
        ' btnCancelar  (secundario)
        ' 
        btnCancelar.BackColor = Color.White
        btnCancelar.Cursor = Cursors.Hand
        btnCancelar.Enabled = False
        btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnCancelar.FlatAppearance.BorderSize = 1
        btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnCancelar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnCancelar.Location = New Point(0, 8)
        btnCancelar.Margin = New Padding(0)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(170, 36)
        btnCancelar.TabIndex = 0
        btnCancelar.Text = "Cancelar reserva"
        btnCancelar.UseVisualStyleBackColor = False
        ' 
        ' tablaPrestamos  (tabla)
        ' 
        tablaPrestamos.AllowUserToAddRows = False
        tablaPrestamos.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        tablaPrestamos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        tablaPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaPrestamos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        tablaPrestamos.BackgroundColor = Color.White
        tablaPrestamos.BorderStyle = BorderStyle.None
        tablaPrestamos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        tablaPrestamos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle8.Font = New Font("Segoe UI Semibold", 9.0F)
        DataGridViewCellStyle8.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True
        tablaPrestamos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        tablaPrestamos.ColumnHeadersHeight = 40
        tablaPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = Color.White
        DataGridViewCellStyle9.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle9.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.False
        tablaPrestamos.DefaultCellStyle = DataGridViewCellStyle9
        tablaPrestamos.Dock = DockStyle.Fill
        tablaPrestamos.EnableHeadersVisualStyles = False
        tablaPrestamos.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tablaPrestamos.Location = New Point(0, 0)
        tablaPrestamos.MultiSelect = False
        tablaPrestamos.Name = "tablaPrestamos"
        tablaPrestamos.ReadOnly = True
        tablaPrestamos.RowHeadersVisible = False
        tablaPrestamos.RowHeadersWidth = 51
        tablaPrestamos.RowTemplate.Height = 36
        tablaPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaPrestamos.Size = New Size(400, 200)
        tablaPrestamos.TabIndex = 0
        ' 
        ' tablaPenalizaciones  (tabla)
        ' 
        tablaPenalizaciones.AllowUserToAddRows = False
        tablaPenalizaciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        tablaPenalizaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        tablaPenalizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaPenalizaciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        tablaPenalizaciones.BackgroundColor = Color.White
        tablaPenalizaciones.BorderStyle = BorderStyle.None
        tablaPenalizaciones.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        tablaPenalizaciones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle11.Font = New Font("Segoe UI Semibold", 9.0F)
        DataGridViewCellStyle11.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.True
        tablaPenalizaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        tablaPenalizaciones.ColumnHeadersHeight = 40
        tablaPenalizaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = Color.White
        DataGridViewCellStyle12.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle12.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle12.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle12.WrapMode = DataGridViewTriState.False
        tablaPenalizaciones.DefaultCellStyle = DataGridViewCellStyle12
        tablaPenalizaciones.Dock = DockStyle.Fill
        tablaPenalizaciones.EnableHeadersVisualStyles = False
        tablaPenalizaciones.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tablaPenalizaciones.Location = New Point(0, 0)
        tablaPenalizaciones.MultiSelect = False
        tablaPenalizaciones.Name = "tablaPenalizaciones"
        tablaPenalizaciones.ReadOnly = True
        tablaPenalizaciones.RowHeadersVisible = False
        tablaPenalizaciones.RowHeadersWidth = 51
        tablaPenalizaciones.RowTemplate.Height = 36
        tablaPenalizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaPenalizaciones.Size = New Size(400, 200)
        tablaPenalizaciones.TabIndex = 0
        ' 
        ' resumenPenalizaciones  (tarjetas de resumen)
        ' 
        resumenPenalizaciones.ColumnCount = 4
        resumenPenalizaciones.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        resumenPenalizaciones.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        resumenPenalizaciones.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        resumenPenalizaciones.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        resumenPenalizaciones.Controls.Add(lblTotalPenalizaciones, 0, 0)
        resumenPenalizaciones.Controls.Add(lblPendientePenalizaciones, 1, 0)
        resumenPenalizaciones.Controls.Add(lblPorRevisarPenalizaciones, 2, 0)
        resumenPenalizaciones.Controls.Add(lblPagadoPenalizaciones, 3, 0)
        resumenPenalizaciones.Dock = DockStyle.Top
        resumenPenalizaciones.Location = New Point(12, 56)
        resumenPenalizaciones.Margin = New Padding(0)
        resumenPenalizaciones.Name = "resumenPenalizaciones"
        resumenPenalizaciones.RowCount = 1
        resumenPenalizaciones.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        resumenPenalizaciones.Size = New Size(1076, 70)
        resumenPenalizaciones.TabIndex = 2
        ' 
        ' lblTotalPenalizaciones  (tarjeta de resumen)
        ' 
        lblTotalPenalizaciones.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        lblTotalPenalizaciones.Dock = DockStyle.Fill
        lblTotalPenalizaciones.Font = New Font("Segoe UI Semibold", 11.0F)
        lblTotalPenalizaciones.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblTotalPenalizaciones.Location = New Point(0, 0)
        lblTotalPenalizaciones.Margin = New Padding(0, 4, 10, 8)
        lblTotalPenalizaciones.Name = "lblTotalPenalizaciones"
        lblTotalPenalizaciones.Padding = New Padding(14, 0, 0, 0)
        lblTotalPenalizaciones.Size = New Size(240, 58)
        lblTotalPenalizaciones.TabIndex = 0
        lblTotalPenalizaciones.Text = "Total registrado"
        lblTotalPenalizaciones.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblPendientePenalizaciones  (tarjeta de resumen)
        ' 
        lblPendientePenalizaciones.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        lblPendientePenalizaciones.Dock = DockStyle.Fill
        lblPendientePenalizaciones.Font = New Font("Segoe UI Semibold", 11.0F)
        lblPendientePenalizaciones.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblPendientePenalizaciones.Location = New Point(250, 0)
        lblPendientePenalizaciones.Margin = New Padding(0, 4, 10, 8)
        lblPendientePenalizaciones.Name = "lblPendientePenalizaciones"
        lblPendientePenalizaciones.Padding = New Padding(14, 0, 0, 0)
        lblPendientePenalizaciones.Size = New Size(240, 58)
        lblPendientePenalizaciones.TabIndex = 1
        lblPendientePenalizaciones.Text = "Pendiente"
        lblPendientePenalizaciones.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblPorRevisarPenalizaciones  (tarjeta de resumen)
        ' 
        lblPorRevisarPenalizaciones.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        lblPorRevisarPenalizaciones.Dock = DockStyle.Fill
        lblPorRevisarPenalizaciones.Font = New Font("Segoe UI Semibold", 11.0F)
        lblPorRevisarPenalizaciones.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblPorRevisarPenalizaciones.Location = New Point(500, 0)
        lblPorRevisarPenalizaciones.Margin = New Padding(0, 4, 10, 8)
        lblPorRevisarPenalizaciones.Name = "lblPorRevisarPenalizaciones"
        lblPorRevisarPenalizaciones.Padding = New Padding(14, 0, 0, 0)
        lblPorRevisarPenalizaciones.Size = New Size(240, 58)
        lblPorRevisarPenalizaciones.TabIndex = 2
        lblPorRevisarPenalizaciones.Text = "Por revisar"
        lblPorRevisarPenalizaciones.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblPagadoPenalizaciones  (tarjeta de resumen)
        ' 
        lblPagadoPenalizaciones.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        lblPagadoPenalizaciones.Dock = DockStyle.Fill
        lblPagadoPenalizaciones.Font = New Font("Segoe UI Semibold", 11.0F)
        lblPagadoPenalizaciones.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblPagadoPenalizaciones.Location = New Point(750, 0)
        lblPagadoPenalizaciones.Margin = New Padding(0, 4, 10, 8)
        lblPagadoPenalizaciones.Name = "lblPagadoPenalizaciones"
        lblPagadoPenalizaciones.Padding = New Padding(14, 0, 0, 0)
        lblPagadoPenalizaciones.Size = New Size(240, 58)
        lblPagadoPenalizaciones.TabIndex = 3
        lblPagadoPenalizaciones.Text = "Pagado"
        lblPagadoPenalizaciones.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' filtrosPenalizaciones  (filtro)
        ' 
        filtrosPenalizaciones.Controls.Add(lblFiltroPago)
        filtrosPenalizaciones.Controls.Add(cboPagoPenalizaciones)
        filtrosPenalizaciones.Controls.Add(btnActualizarPenalizaciones)
        filtrosPenalizaciones.Dock = DockStyle.Top
        filtrosPenalizaciones.Location = New Point(12, 12)
        filtrosPenalizaciones.Margin = New Padding(0)
        filtrosPenalizaciones.Name = "filtrosPenalizaciones"
        filtrosPenalizaciones.Size = New Size(1076, 44)
        filtrosPenalizaciones.TabIndex = 1
        filtrosPenalizaciones.WrapContents = False
        ' 
        ' lblFiltroPago
        ' 
        lblFiltroPago.AutoSize = True
        lblFiltroPago.Font = New Font("Segoe UI Semibold", 9.0F)
        lblFiltroPago.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblFiltroPago.Location = New Point(0, 9)
        lblFiltroPago.Margin = New Padding(0, 9, 10, 0)
        lblFiltroPago.Name = "lblFiltroPago"
        lblFiltroPago.Size = New Size(92, 20)
        lblFiltroPago.TabIndex = 0
        lblFiltroPago.Text = "Estado de pago"
        ' 
        ' cboPagoPenalizaciones
        ' 
        cboPagoPenalizaciones.DropDownStyle = ComboBoxStyle.DropDownList
        cboPagoPenalizaciones.Font = New Font("Segoe UI", 11.0F)
        cboPagoPenalizaciones.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        cboPagoPenalizaciones.FormattingEnabled = True
        cboPagoPenalizaciones.Items.AddRange(New Object() {"Todos", "Pendiente", "Por revisar", "Pagada"})
        cboPagoPenalizaciones.Location = New Point(102, 6)
        cboPagoPenalizaciones.Margin = New Padding(0, 6, 12, 0)
        cboPagoPenalizaciones.Name = "cboPagoPenalizaciones"
        cboPagoPenalizaciones.Size = New Size(150, 28)
        cboPagoPenalizaciones.TabIndex = 1
        ' 
        ' btnActualizarPenalizaciones  (secundario)
        ' 
        btnActualizarPenalizaciones.BackColor = Color.White
        btnActualizarPenalizaciones.Cursor = Cursors.Hand
        btnActualizarPenalizaciones.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizarPenalizaciones.FlatAppearance.BorderSize = 1
        btnActualizarPenalizaciones.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnActualizarPenalizaciones.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnActualizarPenalizaciones.FlatStyle = FlatStyle.Flat
        btnActualizarPenalizaciones.Font = New Font("Segoe UI Semibold", 10.0F)
        btnActualizarPenalizaciones.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizarPenalizaciones.Location = New Point(264, 6)
        btnActualizarPenalizaciones.Margin = New Padding(0, 5, 0, 0)
        btnActualizarPenalizaciones.Name = "btnActualizarPenalizaciones"
        btnActualizarPenalizaciones.Size = New Size(120, 32)
        btnActualizarPenalizaciones.TabIndex = 2
        btnActualizarPenalizaciones.Text = "Actualizar"
        btnActualizarPenalizaciones.UseVisualStyleBackColor = False
        ' 
        ' lblAvisoPenalizaciones  (aviso)
        ' 
        lblAvisoPenalizaciones.Dock = DockStyle.Bottom
        lblAvisoPenalizaciones.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblAvisoPenalizaciones.Location = New Point(12, 486)
        lblAvisoPenalizaciones.Name = "lblAvisoPenalizaciones"
        lblAvisoPenalizaciones.Size = New Size(1076, 62)
        lblAvisoPenalizaciones.TabIndex = 3
        ' 
        ' tablaAvisos  (tabla)
        ' 
        tablaAvisos.AllowUserToAddRows = False
        tablaAvisos.AllowUserToDeleteRows = False
        DataGridViewCellStyle13.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        tablaAvisos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        tablaAvisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaAvisos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        tablaAvisos.BackgroundColor = Color.White
        tablaAvisos.BorderStyle = BorderStyle.None
        tablaAvisos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        tablaAvisos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle14.Font = New Font("Segoe UI Semibold", 9.0F)
        DataGridViewCellStyle14.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle14.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle14.WrapMode = DataGridViewTriState.True
        tablaAvisos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        tablaAvisos.ColumnHeadersHeight = 40
        tablaAvisos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = Color.White
        DataGridViewCellStyle15.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle15.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle15.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle15.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle15.WrapMode = DataGridViewTriState.False
        tablaAvisos.DefaultCellStyle = DataGridViewCellStyle15
        tablaAvisos.Dock = DockStyle.Fill
        tablaAvisos.EnableHeadersVisualStyles = False
        tablaAvisos.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tablaAvisos.Location = New Point(0, 0)
        tablaAvisos.MultiSelect = False
        tablaAvisos.Name = "tablaAvisos"
        tablaAvisos.ReadOnly = True
        tablaAvisos.RowHeadersVisible = False
        tablaAvisos.RowHeadersWidth = 51
        tablaAvisos.RowTemplate.Height = 36
        tablaAvisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaAvisos.Size = New Size(400, 200)
        tablaAvisos.TabIndex = 0
        ' 
        ' btnActualizarAvisos  (secundario)
        ' 
        btnActualizarAvisos.BackColor = Color.White
        btnActualizarAvisos.Cursor = Cursors.Hand
        btnActualizarAvisos.Dock = DockStyle.Bottom
        btnActualizarAvisos.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizarAvisos.FlatAppearance.BorderSize = 1
        btnActualizarAvisos.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnActualizarAvisos.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnActualizarAvisos.FlatStyle = FlatStyle.Flat
        btnActualizarAvisos.Font = New Font("Segoe UI Semibold", 10.0F)
        btnActualizarAvisos.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizarAvisos.Location = New Point(12, 510)
        btnActualizarAvisos.Name = "btnActualizarAvisos"
        btnActualizarAvisos.Size = New Size(160, 38)
        btnActualizarAvisos.TabIndex = 1
        btnActualizarAvisos.Text = "Actualizar avisos"
        btnActualizarAvisos.UseVisualStyleBackColor = False
        ' 
        ' lblEstado  (barra de estado)
        ' 
        lblEstado.AutoEllipsis = True
        lblEstado.Dock = DockStyle.Fill
        lblEstado.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblEstado.Location = New Point(24, 666)
        lblEstado.Margin = New Padding(0)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(1132, 40)
        lblEstado.TabIndex = 2
        lblEstado.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' frmLector
        ' 
        AutoScaleDimensions = New SizeF(96.0F, 96.0F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.White
        ClientSize = New Size(1180, 720)
        Controls.Add(layoutPrincipal)
        Font = New Font("Segoe UI", 10.0F)
        MinimumSize = New Size(900, 600)
        Name = "frmLector"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Mi biblioteca"
        layoutPrincipal.ResumeLayout(False)
        cabecera.ResumeLayout(False)
        pestanas.ResumeLayout(False)
        tabCatalogo.ResumeLayout(False)
        tabCarrito.ResumeLayout(False)
        tabReservas.ResumeLayout(False)
        tabPrestamos.ResumeLayout(False)
        tabPenalizaciones.ResumeLayout(False)
        tabAvisos.ResumeLayout(False)
        barraCatalogo.ResumeLayout(False)
        panelCatalogo.ResumeLayout(False)
        accionesCarrito.ResumeLayout(False)
        accionesReservas.ResumeLayout(False)
        resumenPenalizaciones.ResumeLayout(False)
        filtrosPenalizaciones.ResumeLayout(False)
        barraCatalogo.PerformLayout()
        accionesCarrito.PerformLayout()
        accionesReservas.PerformLayout()
        filtrosPenalizaciones.PerformLayout()
        cabecera.PerformLayout()
        layoutPrincipal.PerformLayout()
        CType(tablaCarrito, ISupportInitialize).EndInit()
        CType(tablaReservas, ISupportInitialize).EndInit()
        CType(tablaPrestamos, ISupportInitialize).EndInit()
        CType(tablaPenalizaciones, ISupportInitialize).EndInit()
        CType(tablaAvisos, ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents layoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cabecera As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblBienvenida As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pestanas As System.Windows.Forms.TabControl
    Friend WithEvents tabCatalogo As System.Windows.Forms.TabPage
    Friend WithEvents tabCarrito As System.Windows.Forms.TabPage
    Friend WithEvents tabReservas As System.Windows.Forms.TabPage
    Friend WithEvents tabPrestamos As System.Windows.Forms.TabPage
    Friend WithEvents tabPenalizaciones As System.Windows.Forms.TabPage
    Friend WithEvents tabAvisos As System.Windows.Forms.TabPage
    Friend WithEvents barraCatalogo As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents panelCatalogo As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tablaCarrito As System.Windows.Forms.DataGridView
    Friend WithEvents colCarritoIdLibro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCarritoTitulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCarritoAutor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents accionesCarrito As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents btnVaciar As System.Windows.Forms.Button
    Friend WithEvents btnSolicitar As System.Windows.Forms.Button
    Friend WithEvents lblNotaCarrito As System.Windows.Forms.Label
    Friend WithEvents tablaReservas As System.Windows.Forms.DataGridView
    Friend WithEvents accionesReservas As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents tablaPrestamos As System.Windows.Forms.DataGridView
    Friend WithEvents tablaPenalizaciones As System.Windows.Forms.DataGridView
    Friend WithEvents resumenPenalizaciones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTotalPenalizaciones As System.Windows.Forms.Label
    Friend WithEvents lblPendientePenalizaciones As System.Windows.Forms.Label
    Friend WithEvents lblPorRevisarPenalizaciones As System.Windows.Forms.Label
    Friend WithEvents lblPagadoPenalizaciones As System.Windows.Forms.Label
    Friend WithEvents filtrosPenalizaciones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblFiltroPago As System.Windows.Forms.Label
    Friend WithEvents cboPagoPenalizaciones As System.Windows.Forms.ComboBox
    Friend WithEvents btnActualizarPenalizaciones As System.Windows.Forms.Button
    Friend WithEvents lblAvisoPenalizaciones As System.Windows.Forms.Label
    Friend WithEvents tablaAvisos As System.Windows.Forms.DataGridView
    Friend WithEvents btnActualizarAvisos As System.Windows.Forms.Button
    Friend WithEvents lblEstado As System.Windows.Forms.Label
End Class
