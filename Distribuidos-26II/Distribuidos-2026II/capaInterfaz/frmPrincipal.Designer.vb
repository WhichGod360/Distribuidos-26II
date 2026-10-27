<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
        layoutPrincipal = New TableLayoutPanel()
        pnlHeader = New Panel()
        lblMarca = New Label()
        imagenMarca = New PictureBox()
        pnlSesion = New Panel()
        lblRol = New Label()
        lblNombre = New Label()
        imagenUsuario = New PictureBox()
        pnlSide = New Panel()
        flpMenu = New FlowLayoutPanel()
        lblNavegacion = New Label()
        btnInicio = New Button()
        btnBuscar = New Button()
        btnPrestamos = New Button()
        btnSolicitudes = New Button()
        btnLibros = New Button()
        btnAutores = New Button()
        btnCategorias = New Button()
        btnPenalizaciones = New Button()
        btnUsuarios = New Button()
        btnBitacora = New Button()
        lblAyudaMenu = New Label()
        btnSalir = New Button()
        pnlMain = New Panel()
        panelDashboard = New Panel()
        layoutDashboard = New TableLayoutPanel()
        encabezado = New TableLayoutPanel()
        imagenModulo = New PictureBox()
        textoEncabezado = New Panel()
        lblDescripcionVista = New Label()
        lblTituloVista = New Label()
        pnlFiltros = New FlowLayoutPanel()
        bloque_dtDesde = New Panel()
        dtDesde = New DateTimePicker()
        etiqueta_dtDesde = New Label()
        bloque_dtHasta = New Panel()
        dtHasta = New DateTimePicker()
        etiqueta_dtHasta = New Label()
        bloque_cboCat = New Panel()
        cboCat = New ComboBox()
        etiqueta_cboCat = New Label()
        bloque_cboEst = New Panel()
        cboEst = New ComboBox()
        etiqueta_cboEst = New Label()
        btnAplicar = New Button()
        btnLimpiar = New Button()
        accesosRapidos = New FlowLayoutPanel()
        btnNuevoRapido = New Button()
        btnDevolverRapido = New Button()
        btnLectorRapido = New Button()
        btnCatalogoRapido = New Button()
        tlpStats = New TableLayoutPanel()
        cardStat0 = New Panel()
        lblNum0 = New Label()
        lblCap0 = New Label()
        lblNota0 = New Label()
        cardStat1 = New Panel()
        lblNum1 = New Label()
        lblCap1 = New Label()
        lblNota1 = New Label()
        cardStat2 = New Panel()
        lblNum2 = New Label()
        lblCap2 = New Label()
        lblNota2 = New Label()
        cardStat3 = New Panel()
        lblNum3 = New Label()
        lblCap3 = New Label()
        lblNota3 = New Label()
        lblActualidad = New Label()
        tlpGraficos = New TableLayoutPanel()
        cardBarras = New Panel()
        pnlBarras = New Panel()
        vista_pnlBarras = New Label()
        titulo_pnlBarras = New Label()
        cardDona = New Panel()
        pnlDona = New Panel()
        vista_pnlDona = New Label()
        titulo_pnlDona = New Label()
        tlpDetalle = New TableLayoutPanel()
        cardPendientes = New Panel()
        tablaPendientes = New DataGridView()
        lblPendientes = New Label()
        lblSinPendientes = New Label()
        cardCategorias = New Panel()
        tablaCategorias = New DataGridView()
        lblCategorias = New Label()
        lblNotaCategorias = New Label()
        lblEstadoCarga = New Label()
        lblFooter = New Label()
        layoutPrincipal.SuspendLayout()
        pnlHeader.SuspendLayout()
        CType(imagenMarca, ISupportInitialize).BeginInit()
        pnlSesion.SuspendLayout()
        CType(imagenUsuario, ISupportInitialize).BeginInit()
        pnlSide.SuspendLayout()
        flpMenu.SuspendLayout()
        pnlMain.SuspendLayout()
        panelDashboard.SuspendLayout()
        layoutDashboard.SuspendLayout()
        encabezado.SuspendLayout()
        CType(imagenModulo, ISupportInitialize).BeginInit()
        textoEncabezado.SuspendLayout()
        pnlFiltros.SuspendLayout()
        bloque_dtDesde.SuspendLayout()
        bloque_dtHasta.SuspendLayout()
        bloque_cboCat.SuspendLayout()
        bloque_cboEst.SuspendLayout()
        accesosRapidos.SuspendLayout()
        tlpStats.SuspendLayout()
        cardStat0.SuspendLayout()
        cardStat1.SuspendLayout()
        cardStat2.SuspendLayout()
        cardStat3.SuspendLayout()
        tlpGraficos.SuspendLayout()
        cardBarras.SuspendLayout()
        pnlBarras.SuspendLayout()
        cardDona.SuspendLayout()
        pnlDona.SuspendLayout()
        tlpDetalle.SuspendLayout()
        cardPendientes.SuspendLayout()
        CType(tablaPendientes, ISupportInitialize).BeginInit()
        cardCategorias.SuspendLayout()
        CType(tablaCategorias, ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' layoutPrincipal
        ' 
        layoutPrincipal.ColumnCount = 2
        layoutPrincipal.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 212F))
        layoutPrincipal.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layoutPrincipal.Controls.Add(pnlHeader, 0, 0)
        layoutPrincipal.Controls.Add(pnlSide, 0, 1)
        layoutPrincipal.Controls.Add(pnlMain, 1, 1)
        layoutPrincipal.Controls.Add(lblFooter, 0, 2)
        layoutPrincipal.Dock = DockStyle.Fill
        layoutPrincipal.Location = New Point(0, 0)
        layoutPrincipal.Margin = New Padding(0)
        layoutPrincipal.Name = "layoutPrincipal"
        layoutPrincipal.RowCount = 3
        layoutPrincipal.RowStyles.Add(New RowStyle(SizeType.Absolute, 72F))
        layoutPrincipal.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        layoutPrincipal.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        layoutPrincipal.Size = New Size(1280, 850)
        layoutPrincipal.TabIndex = 0
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        layoutPrincipal.SetColumnSpan(pnlHeader, 2)
        pnlHeader.Controls.Add(lblMarca)
        pnlHeader.Controls.Add(imagenMarca)
        pnlHeader.Controls.Add(pnlSesion)
        pnlHeader.Dock = DockStyle.Fill
        pnlHeader.Location = New Point(3, 3)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(22, 8, 22, 8)
        pnlHeader.Size = New Size(1274, 66)
        pnlHeader.TabIndex = 0
        ' 
        ' lblMarca
        ' 
        lblMarca.Dock = DockStyle.Fill
        lblMarca.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblMarca.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblMarca.Location = New Point(76, 8)
        lblMarca.Name = "lblMarca"
        lblMarca.Padding = New Padding(16, 0, 0, 0)
        lblMarca.Size = New Size(831, 50)
        lblMarca.TabIndex = 0
        lblMarca.Text = "LECTURAE  /  Biblioteca"
        lblMarca.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' imagenMarca
        ' 
        imagenMarca.AccessibleName = "Lecturae biblioteca y comunidad"
        imagenMarca.Dock = DockStyle.Left
        imagenMarca.Image = My.Resources.Resources.no
        imagenMarca.Location = New Point(22, 8)
        imagenMarca.Name = "imagenMarca"
        imagenMarca.Size = New Size(54, 50)
        imagenMarca.SizeMode = PictureBoxSizeMode.Zoom
        imagenMarca.TabIndex = 1
        imagenMarca.TabStop = False
        ' 
        ' pnlSesion
        ' 
        pnlSesion.Controls.Add(lblRol)
        pnlSesion.Controls.Add(lblNombre)
        pnlSesion.Controls.Add(imagenUsuario)
        pnlSesion.Dock = DockStyle.Right
        pnlSesion.Location = New Point(907, 8)
        pnlSesion.Name = "pnlSesion"
        pnlSesion.Size = New Size(345, 50)
        pnlSesion.TabIndex = 2
        ' 
        ' lblRol
        ' 
        lblRol.Dock = DockStyle.Fill
        lblRol.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblRol.Location = New Point(0, 26)
        lblRol.Name = "lblRol"
        lblRol.Padding = New Padding(0, 0, 58, 0)
        lblRol.Size = New Size(297, 24)
        lblRol.TabIndex = 0
        lblRol.Text = "Rol de la sesión"
        lblRol.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblNombre
        ' 
        lblNombre.Dock = DockStyle.Top
        lblNombre.Font = New Font("Segoe UI Semibold", 10.5F)
        lblNombre.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblNombre.Location = New Point(0, 0)
        lblNombre.Name = "lblNombre"
        lblNombre.Padding = New Padding(0, 0, 58, 0)
        lblNombre.Size = New Size(297, 26)
        lblNombre.TabIndex = 1
        lblNombre.Text = "Nombre del usuario"
        lblNombre.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' imagenUsuario
        ' 
        imagenUsuario.AccessibleName = "Usuario autenticado"
        imagenUsuario.Dock = DockStyle.Right
        imagenUsuario.Image = My.Resources.Resources.usuario
        imagenUsuario.Location = New Point(297, 0)
        imagenUsuario.Name = "imagenUsuario"
        imagenUsuario.Size = New Size(48, 50)
        imagenUsuario.SizeMode = PictureBoxSizeMode.Zoom
        imagenUsuario.TabIndex = 2
        imagenUsuario.TabStop = False
        ' 
        ' pnlSide
        ' 
        pnlSide.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        pnlSide.Controls.Add(flpMenu)
        pnlSide.Dock = DockStyle.Fill
        pnlSide.Location = New Point(3, 75)
        pnlSide.Name = "pnlSide"
        pnlSide.Padding = New Padding(14, 20, 10, 12)
        pnlSide.Size = New Size(206, 742)
        pnlSide.TabIndex = 1
        ' 
        ' flpMenu
        ' 
        flpMenu.AutoScroll = True
        flpMenu.Controls.Add(lblNavegacion)
        flpMenu.Controls.Add(btnInicio)
        flpMenu.Controls.Add(btnBuscar)
        flpMenu.Controls.Add(btnPrestamos)
        flpMenu.Controls.Add(btnSolicitudes)
        flpMenu.Controls.Add(btnLibros)
        flpMenu.Controls.Add(btnAutores)
        flpMenu.Controls.Add(btnCategorias)
        flpMenu.Controls.Add(btnPenalizaciones)
        flpMenu.Controls.Add(btnUsuarios)
        flpMenu.Controls.Add(btnBitacora)
        flpMenu.Controls.Add(lblAyudaMenu)
        flpMenu.Controls.Add(btnSalir)
        flpMenu.Dock = DockStyle.Fill
        flpMenu.FlowDirection = FlowDirection.TopDown
        flpMenu.Location = New Point(14, 20)
        flpMenu.Name = "flpMenu"
        flpMenu.Size = New Size(182, 710)
        flpMenu.TabIndex = 0
        flpMenu.WrapContents = False
        ' 
        ' lblNavegacion
        ' 
        lblNavegacion.Font = New Font("Segoe UI Semibold", 9F)
        lblNavegacion.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblNavegacion.Location = New Point(3, 0)
        lblNavegacion.Name = "lblNavegacion"
        lblNavegacion.Size = New Size(175, 32)
        lblNavegacion.TabIndex = 0
        lblNavegacion.Text = "TU BIBLIOTECA"
        ' 
        ' btnInicio
        ' 
        btnInicio.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        btnInicio.Cursor = Cursors.Hand
        btnInicio.FlatAppearance.BorderColor = Color.FromArgb(CByte(222), CByte(226), CByte(231))
        btnInicio.FlatAppearance.BorderSize = 0
        btnInicio.FlatStyle = FlatStyle.Flat
        btnInicio.Font = New Font("Segoe UI Semibold", 10F)
        btnInicio.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnInicio.Location = New Point(0, 32)
        btnInicio.Margin = New Padding(0, 0, 0, 7)
        btnInicio.Name = "btnInicio"
        btnInicio.Padding = New Padding(8, 0, 0, 0)
        btnInicio.Size = New Size(170, 43)
        btnInicio.TabIndex = 1
        btnInicio.Tag = "inicio"
        btnInicio.Text = "Inicio"
        btnInicio.TextAlign = ContentAlignment.MiddleLeft
        btnInicio.UseVisualStyleBackColor = False
        ' 
        ' btnBuscar
        ' 
        btnBuscar.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        btnBuscar.Cursor = Cursors.Hand
        btnBuscar.FlatAppearance.BorderColor = Color.FromArgb(CByte(222), CByte(226), CByte(231))
        btnBuscar.FlatAppearance.BorderSize = 0
        btnBuscar.FlatStyle = FlatStyle.Flat
        btnBuscar.Font = New Font("Segoe UI Semibold", 10F)
        btnBuscar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnBuscar.Location = New Point(0, 82)
        btnBuscar.Margin = New Padding(0, 0, 0, 7)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Padding = New Padding(8, 0, 0, 0)
        btnBuscar.Size = New Size(170, 43)
        btnBuscar.TabIndex = 2
        btnBuscar.Tag = "lectores"
        btnBuscar.Text = "Buscar lectores"
        btnBuscar.TextAlign = ContentAlignment.MiddleLeft
        btnBuscar.UseVisualStyleBackColor = False
        ' 
        ' btnPrestamos
        ' 
        btnPrestamos.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        btnPrestamos.Cursor = Cursors.Hand
        btnPrestamos.FlatAppearance.BorderColor = Color.FromArgb(CByte(222), CByte(226), CByte(231))
        btnPrestamos.FlatAppearance.BorderSize = 0
        btnPrestamos.FlatStyle = FlatStyle.Flat
        btnPrestamos.Font = New Font("Segoe UI Semibold", 10F)
        btnPrestamos.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnPrestamos.Location = New Point(0, 132)
        btnPrestamos.Margin = New Padding(0, 0, 0, 7)
        btnPrestamos.Name = "btnPrestamos"
        btnPrestamos.Padding = New Padding(8, 0, 0, 0)
        btnPrestamos.Size = New Size(170, 43)
        btnPrestamos.TabIndex = 3
        btnPrestamos.Tag = "prestamos"
        btnPrestamos.Text = "Préstamos"
        btnPrestamos.TextAlign = ContentAlignment.MiddleLeft
        btnPrestamos.UseVisualStyleBackColor = False
        ' 
        ' btnSolicitudes
        ' 
        btnSolicitudes.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        btnSolicitudes.FlatAppearance.BorderSize = 0
        btnSolicitudes.FlatStyle = FlatStyle.Flat
        btnSolicitudes.Font = New Font("Segoe UI Semibold", 10F)
        btnSolicitudes.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnSolicitudes.Location = New Point(0, 182)
        btnSolicitudes.Margin = New Padding(0, 0, 0, 7)
        btnSolicitudes.Name = "btnSolicitudes"
        btnSolicitudes.Padding = New Padding(8, 0, 0, 0)
        btnSolicitudes.Size = New Size(170, 43)
        btnSolicitudes.TabIndex = 4
        btnSolicitudes.Tag = "solicitudes"
        btnSolicitudes.Text = "Solicitudes y reservas"
        btnSolicitudes.TextAlign = ContentAlignment.MiddleLeft
        btnSolicitudes.UseVisualStyleBackColor = False
        ' 
        ' btnLibros
        ' 
        btnLibros.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        btnLibros.Cursor = Cursors.Hand
        btnLibros.FlatAppearance.BorderColor = Color.FromArgb(CByte(222), CByte(226), CByte(231))
        btnLibros.FlatAppearance.BorderSize = 0
        btnLibros.FlatStyle = FlatStyle.Flat
        btnLibros.Font = New Font("Segoe UI Semibold", 10F)
        btnLibros.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnLibros.Location = New Point(0, 232)
        btnLibros.Margin = New Padding(0, 0, 0, 7)
        btnLibros.Name = "btnLibros"
        btnLibros.Padding = New Padding(8, 0, 0, 0)
        btnLibros.Size = New Size(170, 43)
        btnLibros.TabIndex = 5
        btnLibros.Tag = "libros"
        btnLibros.Text = "Libros y ejemplares"
        btnLibros.TextAlign = ContentAlignment.MiddleLeft
        btnLibros.UseVisualStyleBackColor = False
        ' 
        ' btnAutores
        ' 
        btnAutores.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        btnAutores.Cursor = Cursors.Hand
        btnAutores.FlatAppearance.BorderColor = Color.FromArgb(CByte(222), CByte(226), CByte(231))
        btnAutores.FlatAppearance.BorderSize = 0
        btnAutores.FlatStyle = FlatStyle.Flat
        btnAutores.Font = New Font("Segoe UI Semibold", 10F)
        btnAutores.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnAutores.Location = New Point(0, 282)
        btnAutores.Margin = New Padding(0, 0, 0, 7)
        btnAutores.Name = "btnAutores"
        btnAutores.Padding = New Padding(8, 0, 0, 0)
        btnAutores.Size = New Size(170, 43)
        btnAutores.TabIndex = 6
        btnAutores.Tag = "autores"
        btnAutores.Text = "Autores"
        btnAutores.TextAlign = ContentAlignment.MiddleLeft
        btnAutores.UseVisualStyleBackColor = False
        ' 
        ' btnCategorias
        ' 
        btnCategorias.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        btnCategorias.Cursor = Cursors.Hand
        btnCategorias.FlatAppearance.BorderColor = Color.FromArgb(CByte(222), CByte(226), CByte(231))
        btnCategorias.FlatAppearance.BorderSize = 0
        btnCategorias.FlatStyle = FlatStyle.Flat
        btnCategorias.Font = New Font("Segoe UI Semibold", 10F)
        btnCategorias.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnCategorias.Location = New Point(0, 332)
        btnCategorias.Margin = New Padding(0, 0, 0, 7)
        btnCategorias.Name = "btnCategorias"
        btnCategorias.Padding = New Padding(8, 0, 0, 0)
        btnCategorias.Size = New Size(170, 43)
        btnCategorias.TabIndex = 7
        btnCategorias.Tag = "categorias"
        btnCategorias.Text = "Categorías"
        btnCategorias.TextAlign = ContentAlignment.MiddleLeft
        btnCategorias.UseVisualStyleBackColor = False
        ' 
        ' btnPenalizaciones
        ' 
        btnPenalizaciones.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        btnPenalizaciones.Cursor = Cursors.Hand
        btnPenalizaciones.FlatAppearance.BorderColor = Color.FromArgb(CByte(222), CByte(226), CByte(231))
        btnPenalizaciones.FlatAppearance.BorderSize = 0
        btnPenalizaciones.FlatStyle = FlatStyle.Flat
        btnPenalizaciones.Font = New Font("Segoe UI Semibold", 10F)
        btnPenalizaciones.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnPenalizaciones.Location = New Point(0, 382)
        btnPenalizaciones.Margin = New Padding(0, 0, 0, 7)
        btnPenalizaciones.Name = "btnPenalizaciones"
        btnPenalizaciones.Padding = New Padding(8, 0, 0, 0)
        btnPenalizaciones.Size = New Size(170, 43)
        btnPenalizaciones.TabIndex = 8
        btnPenalizaciones.Tag = "penalizaciones"
        btnPenalizaciones.Text = "Penalizaciones"
        btnPenalizaciones.TextAlign = ContentAlignment.MiddleLeft
        btnPenalizaciones.UseVisualStyleBackColor = False
        ' 
        ' btnUsuarios
        ' 
        btnUsuarios.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        btnUsuarios.FlatAppearance.BorderSize = 0
        btnUsuarios.FlatStyle = FlatStyle.Flat
        btnUsuarios.Font = New Font("Segoe UI Semibold", 10F)
        btnUsuarios.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnUsuarios.Location = New Point(0, 432)
        btnUsuarios.Margin = New Padding(0, 0, 0, 7)
        btnUsuarios.Name = "btnUsuarios"
        btnUsuarios.Padding = New Padding(8, 0, 0, 0)
        btnUsuarios.Size = New Size(170, 43)
        btnUsuarios.TabIndex = 9
        btnUsuarios.Tag = "usuarios"
        btnUsuarios.Text = "Gestión de usuarios"
        btnUsuarios.TextAlign = ContentAlignment.MiddleLeft
        btnUsuarios.UseVisualStyleBackColor = False
        btnUsuarios.Visible = False
        ' 
        ' btnBitacora
        ' 
        btnBitacora.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(253))
        btnBitacora.Cursor = Cursors.Hand
        btnBitacora.FlatAppearance.BorderSize = 0
        btnBitacora.FlatStyle = FlatStyle.Flat
        btnBitacora.Font = New Font("Segoe UI Semibold", 10F)
        btnBitacora.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnBitacora.Location = New Point(0, 482)
        btnBitacora.Margin = New Padding(0, 0, 0, 7)
        btnBitacora.Name = "btnBitacora"
        btnBitacora.Padding = New Padding(8, 0, 0, 0)
        btnBitacora.Size = New Size(170, 43)
        btnBitacora.TabIndex = 12
        btnBitacora.Tag = "bitacora"
        btnBitacora.Text = "Bitácora "
        btnBitacora.TextAlign = ContentAlignment.MiddleLeft
        btnBitacora.UseVisualStyleBackColor = False
        ' 
        ' lblAyudaMenu
        ' 
        lblAyudaMenu.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblAyudaMenu.Location = New Point(8, 560)
        lblAyudaMenu.Margin = New Padding(8, 28, 0, 8)
        lblAyudaMenu.Name = "lblAyudaMenu"
        lblAyudaMenu.Size = New Size(170, 74)
        lblAyudaMenu.TabIndex = 10
        lblAyudaMenu.Text = "Cada préstamo corresponde a una copia física."
        ' 
        ' btnSalir
        ' 
        btnSalir.BackColor = Color.White
        btnSalir.Cursor = Cursors.Hand
        btnSalir.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnSalir.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnSalir.FlatStyle = FlatStyle.Flat
        btnSalir.Font = New Font("Segoe UI Semibold", 10F)
        btnSalir.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnSalir.Location = New Point(0, 642)
        btnSalir.Margin = New Padding(0)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(170, 38)
        btnSalir.TabIndex = 11
        btnSalir.Text = "Cerrar sesión"
        btnSalir.UseVisualStyleBackColor = False
        ' 
        ' pnlMain
        ' 
        pnlMain.BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(254))
        pnlMain.Controls.Add(panelDashboard)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(215, 75)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(1062, 742)
        pnlMain.TabIndex = 2
        ' 
        ' panelDashboard
        ' 
        panelDashboard.AutoScroll = True
        panelDashboard.Controls.Add(layoutDashboard)
        panelDashboard.Dock = DockStyle.Fill
        panelDashboard.Location = New Point(0, 0)
        panelDashboard.Name = "panelDashboard"
        panelDashboard.Size = New Size(1062, 742)
        panelDashboard.TabIndex = 0
        ' 
        ' layoutDashboard
        ' 
        layoutDashboard.AutoSize = True
        layoutDashboard.ColumnCount = 1
        layoutDashboard.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layoutDashboard.Controls.Add(encabezado, 0, 0)
        layoutDashboard.Controls.Add(pnlFiltros, 0, 1)
        layoutDashboard.Controls.Add(accesosRapidos, 0, 2)
        layoutDashboard.Controls.Add(tlpStats, 0, 3)
        layoutDashboard.Controls.Add(lblActualidad, 0, 4)
        layoutDashboard.Controls.Add(tlpGraficos, 0, 5)
        layoutDashboard.Controls.Add(tlpDetalle, 0, 6)
        layoutDashboard.Controls.Add(lblEstadoCarga, 0, 7)
        layoutDashboard.Dock = DockStyle.Top
        layoutDashboard.Location = New Point(0, 0)
        layoutDashboard.Margin = New Padding(0)
        layoutDashboard.Name = "layoutDashboard"
        layoutDashboard.Padding = New Padding(22, 16, 22, 16)
        layoutDashboard.RowCount = 8
        layoutDashboard.RowStyles.Add(New RowStyle(SizeType.Absolute, 76F))
        layoutDashboard.RowStyles.Add(New RowStyle())
        layoutDashboard.RowStyles.Add(New RowStyle())
        layoutDashboard.RowStyles.Add(New RowStyle(SizeType.Absolute, 140F))
        layoutDashboard.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        layoutDashboard.RowStyles.Add(New RowStyle(SizeType.Absolute, 236F))
        layoutDashboard.RowStyles.Add(New RowStyle(SizeType.Absolute, 228F))
        layoutDashboard.RowStyles.Add(New RowStyle(SizeType.Absolute, 38F))
        layoutDashboard.Size = New Size(1041, 927)
        layoutDashboard.TabIndex = 0
        ' 
        ' encabezado
        ' 
        encabezado.ColumnCount = 2
        encabezado.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 72F))
        encabezado.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        encabezado.Controls.Add(imagenModulo, 0, 0)
        encabezado.Controls.Add(textoEncabezado, 1, 0)
        encabezado.Dock = DockStyle.Fill
        encabezado.Location = New Point(22, 16)
        encabezado.Margin = New Padding(0)
        encabezado.Name = "encabezado"
        encabezado.RowCount = 1
        encabezado.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        encabezado.Size = New Size(997, 76)
        encabezado.TabIndex = 0
        ' 
        ' imagenModulo
        ' 
        imagenModulo.AccessibleName = "Lecturae, biblioteca y comunidad"
        imagenModulo.Dock = DockStyle.Fill
        imagenModulo.Image = My.Resources.Resources.no
        imagenModulo.Location = New Point(0, 0)
        imagenModulo.Margin = New Padding(0, 0, 16, 10)
        imagenModulo.Name = "imagenModulo"
        imagenModulo.Size = New Size(56, 70)
        imagenModulo.SizeMode = PictureBoxSizeMode.Zoom
        imagenModulo.TabIndex = 0
        imagenModulo.TabStop = False
        ' 
        ' textoEncabezado
        ' 
        textoEncabezado.Controls.Add(lblDescripcionVista)
        textoEncabezado.Controls.Add(lblTituloVista)
        textoEncabezado.Dock = DockStyle.Fill
        textoEncabezado.Location = New Point(75, 3)
        textoEncabezado.Name = "textoEncabezado"
        textoEncabezado.Size = New Size(919, 74)
        textoEncabezado.TabIndex = 1
        ' 
        ' lblDescripcionVista
        ' 
        lblDescripcionVista.Dock = DockStyle.Fill
        lblDescripcionVista.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblDescripcionVista.Location = New Point(0, 38)
        lblDescripcionVista.Name = "lblDescripcionVista"
        lblDescripcionVista.Size = New Size(919, 36)
        lblDescripcionVista.TabIndex = 0
        lblDescripcionVista.Text = "Actividad, disponibilidad y accesos para la gestión diaria."
        ' 
        ' lblTituloVista
        ' 
        lblTituloVista.Dock = DockStyle.Top
        lblTituloVista.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblTituloVista.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblTituloVista.Location = New Point(0, 0)
        lblTituloVista.Name = "lblTituloVista"
        lblTituloVista.Size = New Size(919, 38)
        lblTituloVista.TabIndex = 1
        lblTituloVista.Text = "Panel de biblioteca"
        ' 
        ' pnlFiltros
        ' 
        pnlFiltros.AutoSize = True
        pnlFiltros.Controls.Add(bloque_dtDesde)
        pnlFiltros.Controls.Add(bloque_dtHasta)
        pnlFiltros.Controls.Add(bloque_cboCat)
        pnlFiltros.Controls.Add(bloque_cboEst)
        pnlFiltros.Controls.Add(btnAplicar)
        pnlFiltros.Controls.Add(btnLimpiar)
        pnlFiltros.Dock = DockStyle.Fill
        pnlFiltros.Location = New Point(25, 95)
        pnlFiltros.Name = "pnlFiltros"
        pnlFiltros.Size = New Size(991, 65)
        pnlFiltros.TabIndex = 1
        ' 
        ' bloque_dtDesde
        ' 
        bloque_dtDesde.Controls.Add(dtDesde)
        bloque_dtDesde.Controls.Add(etiqueta_dtDesde)
        bloque_dtDesde.Location = New Point(0, 0)
        bloque_dtDesde.Margin = New Padding(0, 0, 12, 6)
        bloque_dtDesde.Name = "bloque_dtDesde"
        bloque_dtDesde.Size = New Size(140, 58)
        bloque_dtDesde.TabIndex = 0
        ' 
        ' dtDesde
        ' 
        dtDesde.Dock = DockStyle.Top
        dtDesde.Format = DateTimePickerFormat.Short
        dtDesde.Location = New Point(0, 24)
        dtDesde.Name = "dtDesde"
        dtDesde.Size = New Size(140, 30)
        dtDesde.TabIndex = 0
        ' 
        ' etiqueta_dtDesde
        ' 
        etiqueta_dtDesde.Dock = DockStyle.Top
        etiqueta_dtDesde.Font = New Font("Segoe UI Semibold", 9F)
        etiqueta_dtDesde.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        etiqueta_dtDesde.Location = New Point(0, 0)
        etiqueta_dtDesde.Name = "etiqueta_dtDesde"
        etiqueta_dtDesde.Size = New Size(140, 24)
        etiqueta_dtDesde.TabIndex = 1
        etiqueta_dtDesde.Text = "Préstamos desde"
        ' 
        ' bloque_dtHasta
        ' 
        bloque_dtHasta.Controls.Add(dtHasta)
        bloque_dtHasta.Controls.Add(etiqueta_dtHasta)
        bloque_dtHasta.Location = New Point(152, 0)
        bloque_dtHasta.Margin = New Padding(0, 0, 12, 6)
        bloque_dtHasta.Name = "bloque_dtHasta"
        bloque_dtHasta.Size = New Size(140, 58)
        bloque_dtHasta.TabIndex = 1
        ' 
        ' dtHasta
        ' 
        dtHasta.Dock = DockStyle.Top
        dtHasta.Format = DateTimePickerFormat.Short
        dtHasta.Location = New Point(0, 24)
        dtHasta.Name = "dtHasta"
        dtHasta.Size = New Size(140, 30)
        dtHasta.TabIndex = 0
        ' 
        ' etiqueta_dtHasta
        ' 
        etiqueta_dtHasta.Dock = DockStyle.Top
        etiqueta_dtHasta.Font = New Font("Segoe UI Semibold", 9F)
        etiqueta_dtHasta.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        etiqueta_dtHasta.Location = New Point(0, 0)
        etiqueta_dtHasta.Name = "etiqueta_dtHasta"
        etiqueta_dtHasta.Size = New Size(140, 24)
        etiqueta_dtHasta.TabIndex = 1
        etiqueta_dtHasta.Text = "Hasta"
        ' 
        ' bloque_cboCat
        ' 
        bloque_cboCat.Controls.Add(cboCat)
        bloque_cboCat.Controls.Add(etiqueta_cboCat)
        bloque_cboCat.Location = New Point(304, 0)
        bloque_cboCat.Margin = New Padding(0, 0, 12, 6)
        bloque_cboCat.Name = "bloque_cboCat"
        bloque_cboCat.Size = New Size(195, 58)
        bloque_cboCat.TabIndex = 2
        ' 
        ' cboCat
        ' 
        cboCat.Dock = DockStyle.Top
        cboCat.DropDownStyle = ComboBoxStyle.DropDownList
        cboCat.Location = New Point(0, 24)
        cboCat.Name = "cboCat"
        cboCat.Size = New Size(195, 31)
        cboCat.TabIndex = 0
        ' 
        ' etiqueta_cboCat
        ' 
        etiqueta_cboCat.Dock = DockStyle.Top
        etiqueta_cboCat.Font = New Font("Segoe UI Semibold", 9F)
        etiqueta_cboCat.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        etiqueta_cboCat.Location = New Point(0, 0)
        etiqueta_cboCat.Name = "etiqueta_cboCat"
        etiqueta_cboCat.Size = New Size(195, 24)
        etiqueta_cboCat.TabIndex = 1
        etiqueta_cboCat.Text = "Categoría"
        ' 
        ' bloque_cboEst
        ' 
        bloque_cboEst.Controls.Add(cboEst)
        bloque_cboEst.Controls.Add(etiqueta_cboEst)
        bloque_cboEst.Location = New Point(511, 0)
        bloque_cboEst.Margin = New Padding(0, 0, 12, 6)
        bloque_cboEst.Name = "bloque_cboEst"
        bloque_cboEst.Size = New Size(120, 58)
        bloque_cboEst.TabIndex = 3
        ' 
        ' cboEst
        ' 
        cboEst.Dock = DockStyle.Top
        cboEst.DropDownStyle = ComboBoxStyle.DropDownList
        cboEst.Items.AddRange(New Object() {"Todos", "Activos", "Vencidos", "Devueltos"})
        cboEst.Location = New Point(0, 24)
        cboEst.Name = "cboEst"
        cboEst.Size = New Size(120, 31)
        cboEst.TabIndex = 0
        ' 
        ' etiqueta_cboEst
        ' 
        etiqueta_cboEst.Dock = DockStyle.Top
        etiqueta_cboEst.Font = New Font("Segoe UI Semibold", 9F)
        etiqueta_cboEst.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        etiqueta_cboEst.Location = New Point(0, 0)
        etiqueta_cboEst.Name = "etiqueta_cboEst"
        etiqueta_cboEst.Size = New Size(120, 24)
        etiqueta_cboEst.TabIndex = 1
        etiqueta_cboEst.Text = "Estado"
        ' 
        ' btnAplicar
        ' 
        btnAplicar.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnAplicar.Cursor = Cursors.Hand
        btnAplicar.FlatAppearance.BorderColor = Color.FromArgb(CByte(222), CByte(226), CByte(231))
        btnAplicar.FlatAppearance.BorderSize = 0
        btnAplicar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btnAplicar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btnAplicar.FlatStyle = FlatStyle.Flat
        btnAplicar.Font = New Font("Segoe UI Semibold", 10F)
        btnAplicar.ForeColor = Color.White
        btnAplicar.Location = New Point(643, 24)
        btnAplicar.Margin = New Padding(0, 24, 8, 6)
        btnAplicar.Name = "btnAplicar"
        btnAplicar.Size = New Size(115, 35)
        btnAplicar.TabIndex = 4
        btnAplicar.Text = "Actualizar"
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
        btnLimpiar.Font = New Font("Segoe UI Semibold", 10F)
        btnLimpiar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnLimpiar.Location = New Point(766, 24)
        btnLimpiar.Margin = New Padding(0, 24, 0, 6)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Size = New Size(92, 35)
        btnLimpiar.TabIndex = 5
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.UseVisualStyleBackColor = False
        ' 
        ' accesosRapidos
        ' 
        accesosRapidos.AutoSize = True
        accesosRapidos.Controls.Add(btnNuevoRapido)
        accesosRapidos.Controls.Add(btnDevolverRapido)
        accesosRapidos.Controls.Add(btnLectorRapido)
        accesosRapidos.Controls.Add(btnCatalogoRapido)
        accesosRapidos.Dock = DockStyle.Fill
        accesosRapidos.Location = New Point(25, 166)
        accesosRapidos.Name = "accesosRapidos"
        accesosRapidos.Padding = New Padding(0, 6, 0, 10)
        accesosRapidos.Size = New Size(991, 58)
        accesosRapidos.TabIndex = 2
        ' 
        ' btnNuevoRapido
        ' 
        btnNuevoRapido.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnNuevoRapido.Cursor = Cursors.Hand
        btnNuevoRapido.FlatAppearance.BorderColor = Color.FromArgb(CByte(222), CByte(226), CByte(231))
        btnNuevoRapido.FlatAppearance.BorderSize = 0
        btnNuevoRapido.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btnNuevoRapido.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btnNuevoRapido.FlatStyle = FlatStyle.Flat
        btnNuevoRapido.Font = New Font("Segoe UI Semibold", 10F)
        btnNuevoRapido.ForeColor = Color.White
        btnNuevoRapido.Location = New Point(0, 6)
        btnNuevoRapido.Margin = New Padding(0, 0, 10, 4)
        btnNuevoRapido.Name = "btnNuevoRapido"
        btnNuevoRapido.Size = New Size(172, 38)
        btnNuevoRapido.TabIndex = 0
        btnNuevoRapido.Text = "Nuevo préstamo"
        btnNuevoRapido.UseVisualStyleBackColor = False
        ' 
        ' btnDevolverRapido
        ' 
        btnDevolverRapido.BackColor = Color.White
        btnDevolverRapido.Cursor = Cursors.Hand
        btnDevolverRapido.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnDevolverRapido.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnDevolverRapido.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnDevolverRapido.FlatStyle = FlatStyle.Flat
        btnDevolverRapido.Font = New Font("Segoe UI Semibold", 10F)
        btnDevolverRapido.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnDevolverRapido.Location = New Point(182, 6)
        btnDevolverRapido.Margin = New Padding(0, 0, 10, 4)
        btnDevolverRapido.Name = "btnDevolverRapido"
        btnDevolverRapido.Size = New Size(195, 38)
        btnDevolverRapido.TabIndex = 1
        btnDevolverRapido.Text = "Registrar devolución"
        btnDevolverRapido.UseVisualStyleBackColor = False
        ' 
        ' btnLectorRapido
        ' 
        btnLectorRapido.BackColor = Color.White
        btnLectorRapido.Cursor = Cursors.Hand
        btnLectorRapido.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnLectorRapido.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnLectorRapido.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnLectorRapido.FlatStyle = FlatStyle.Flat
        btnLectorRapido.Font = New Font("Segoe UI Semibold", 10F)
        btnLectorRapido.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnLectorRapido.Location = New Point(387, 6)
        btnLectorRapido.Margin = New Padding(0, 0, 10, 4)
        btnLectorRapido.Name = "btnLectorRapido"
        btnLectorRapido.Size = New Size(172, 38)
        btnLectorRapido.TabIndex = 2
        btnLectorRapido.Text = "Buscar lector"
        btnLectorRapido.UseVisualStyleBackColor = False
        ' 
        ' btnCatalogoRapido
        ' 
        btnCatalogoRapido.BackColor = Color.White
        btnCatalogoRapido.Cursor = Cursors.Hand
        btnCatalogoRapido.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnCatalogoRapido.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnCatalogoRapido.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnCatalogoRapido.FlatStyle = FlatStyle.Flat
        btnCatalogoRapido.Font = New Font("Segoe UI Semibold", 10F)
        btnCatalogoRapido.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnCatalogoRapido.Location = New Point(569, 6)
        btnCatalogoRapido.Margin = New Padding(0, 0, 10, 4)
        btnCatalogoRapido.Name = "btnCatalogoRapido"
        btnCatalogoRapido.Size = New Size(172, 38)
        btnCatalogoRapido.TabIndex = 3
        btnCatalogoRapido.Text = "Consultar libros"
        btnCatalogoRapido.UseVisualStyleBackColor = False
        ' 
        ' tlpStats
        ' 
        tlpStats.ColumnCount = 4
        tlpStats.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpStats.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpStats.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpStats.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpStats.Controls.Add(cardStat0, 0, 0)
        tlpStats.Controls.Add(cardStat1, 1, 0)
        tlpStats.Controls.Add(cardStat2, 2, 0)
        tlpStats.Controls.Add(cardStat3, 3, 0)
        tlpStats.Dock = DockStyle.Fill
        tlpStats.Location = New Point(22, 227)
        tlpStats.Margin = New Padding(0)
        tlpStats.Name = "tlpStats"
        tlpStats.RowCount = 1
        tlpStats.RowStyles.Add(New RowStyle(SizeType.Absolute, 140F))
        tlpStats.Size = New Size(997, 140)
        tlpStats.TabIndex = 3
        ' 
        ' cardStat0
        ' 
        cardStat0.BackColor = Color.White
        cardStat0.BorderStyle = BorderStyle.FixedSingle
        cardStat0.Controls.Add(lblNum0)
        cardStat0.Controls.Add(lblCap0)
        cardStat0.Controls.Add(lblNota0)
        cardStat0.Cursor = Cursors.Hand
        cardStat0.Dock = DockStyle.Fill
        cardStat0.Location = New Point(0, 0)
        cardStat0.Margin = New Padding(0, 0, 12, 0)
        cardStat0.Name = "cardStat0"
        cardStat0.Padding = New Padding(14, 10, 10, 8)
        cardStat0.Size = New Size(237, 140)
        cardStat0.TabIndex = 0
        ' 
        ' lblNum0
        ' 
        lblNum0.Dock = DockStyle.Fill
        lblNum0.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        lblNum0.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        lblNum0.Location = New Point(14, 38)
        lblNum0.Name = "lblNum0"
        lblNum0.Size = New Size(211, 69)
        lblNum0.TabIndex = 0
        lblNum0.Text = "—"
        ' 
        ' lblCap0
        ' 
        lblCap0.AutoEllipsis = True
        lblCap0.Dock = DockStyle.Top
        lblCap0.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblCap0.Location = New Point(14, 10)
        lblCap0.Name = "lblCap0"
        lblCap0.Size = New Size(211, 28)
        lblCap0.TabIndex = 1
        lblCap0.Text = "Activos en selección"
        ' 
        ' lblNota0
        ' 
        lblNota0.AutoEllipsis = True
        lblNota0.Dock = DockStyle.Bottom
        lblNota0.Font = New Font("Segoe UI", 8F)
        lblNota0.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblNota0.Location = New Point(14, 107)
        lblNota0.Name = "lblNota0"
        lblNota0.Size = New Size(211, 23)
        lblNota0.TabIndex = 2
        lblNota0.Text = "Préstamos iniciados en el periodo"
        ' 
        ' cardStat1
        ' 
        cardStat1.BackColor = Color.White
        cardStat1.BorderStyle = BorderStyle.FixedSingle
        cardStat1.Controls.Add(lblNum1)
        cardStat1.Controls.Add(lblCap1)
        cardStat1.Controls.Add(lblNota1)
        cardStat1.Cursor = Cursors.Hand
        cardStat1.Dock = DockStyle.Fill
        cardStat1.Location = New Point(249, 0)
        cardStat1.Margin = New Padding(0, 0, 12, 0)
        cardStat1.Name = "cardStat1"
        cardStat1.Padding = New Padding(14, 10, 10, 8)
        cardStat1.Size = New Size(237, 140)
        cardStat1.TabIndex = 1
        ' 
        ' lblNum1
        ' 
        lblNum1.Dock = DockStyle.Fill
        lblNum1.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        lblNum1.ForeColor = Color.FromArgb(CByte(217), CByte(113), CByte(74))
        lblNum1.Location = New Point(14, 38)
        lblNum1.Name = "lblNum1"
        lblNum1.Size = New Size(211, 69)
        lblNum1.TabIndex = 0
        lblNum1.Text = "—"
        ' 
        ' lblCap1
        ' 
        lblCap1.AutoEllipsis = True
        lblCap1.Dock = DockStyle.Top
        lblCap1.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblCap1.Location = New Point(14, 10)
        lblCap1.Name = "lblCap1"
        lblCap1.Size = New Size(211, 28)
        lblCap1.TabIndex = 1
        lblCap1.Text = "Vencidos en selección"
        ' 
        ' lblNota1
        ' 
        lblNota1.AutoEllipsis = True
        lblNota1.Dock = DockStyle.Bottom
        lblNota1.Font = New Font("Segoe UI", 8F)
        lblNota1.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblNota1.Location = New Point(14, 107)
        lblNota1.Name = "lblNota1"
        lblNota1.Size = New Size(211, 23)
        lblNota1.TabIndex = 2
        lblNota1.Text = "Préstamos iniciados en el periodo"
        ' 
        ' cardStat2
        ' 
        cardStat2.BackColor = Color.White
        cardStat2.BorderStyle = BorderStyle.FixedSingle
        cardStat2.Controls.Add(lblNum2)
        cardStat2.Controls.Add(lblCap2)
        cardStat2.Controls.Add(lblNota2)
        cardStat2.Cursor = Cursors.Hand
        cardStat2.Dock = DockStyle.Fill
        cardStat2.Location = New Point(498, 0)
        cardStat2.Margin = New Padding(0, 0, 12, 0)
        cardStat2.Name = "cardStat2"
        cardStat2.Padding = New Padding(14, 10, 10, 8)
        cardStat2.Size = New Size(237, 140)
        cardStat2.TabIndex = 2
        ' 
        ' lblNum2
        ' 
        lblNum2.Dock = DockStyle.Fill
        lblNum2.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        lblNum2.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        lblNum2.Location = New Point(14, 38)
        lblNum2.Name = "lblNum2"
        lblNum2.Size = New Size(211, 69)
        lblNum2.TabIndex = 0
        lblNum2.Text = "—"
        ' 
        ' lblCap2
        ' 
        lblCap2.AutoEllipsis = True
        lblCap2.Dock = DockStyle.Top
        lblCap2.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblCap2.Location = New Point(14, 10)
        lblCap2.Name = "lblCap2"
        lblCap2.Size = New Size(211, 28)
        lblCap2.TabIndex = 1
        lblCap2.Text = "Devueltos en selección"
        ' 
        ' lblNota2
        ' 
        lblNota2.AutoEllipsis = True
        lblNota2.Dock = DockStyle.Bottom
        lblNota2.Font = New Font("Segoe UI", 8F)
        lblNota2.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblNota2.Location = New Point(14, 107)
        lblNota2.Name = "lblNota2"
        lblNota2.Size = New Size(211, 23)
        lblNota2.TabIndex = 2
        lblNota2.Text = "Préstamos iniciados en el periodo"
        ' 
        ' cardStat3
        ' 
        cardStat3.BackColor = Color.White
        cardStat3.BorderStyle = BorderStyle.FixedSingle
        cardStat3.Controls.Add(lblNum3)
        cardStat3.Controls.Add(lblCap3)
        cardStat3.Controls.Add(lblNota3)
        cardStat3.Cursor = Cursors.Hand
        cardStat3.Dock = DockStyle.Fill
        cardStat3.Location = New Point(747, 0)
        cardStat3.Margin = New Padding(0)
        cardStat3.Name = "cardStat3"
        cardStat3.Padding = New Padding(14, 10, 10, 8)
        cardStat3.Size = New Size(250, 140)
        cardStat3.TabIndex = 3
        ' 
        ' lblNum3
        ' 
        lblNum3.Dock = DockStyle.Fill
        lblNum3.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        lblNum3.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        lblNum3.Location = New Point(14, 38)
        lblNum3.Name = "lblNum3"
        lblNum3.Size = New Size(224, 69)
        lblNum3.TabIndex = 0
        lblNum3.Text = "—"
        ' 
        ' lblCap3
        ' 
        lblCap3.AutoEllipsis = True
        lblCap3.Dock = DockStyle.Top
        lblCap3.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblCap3.Location = New Point(14, 10)
        lblCap3.Name = "lblCap3"
        lblCap3.Size = New Size(224, 28)
        lblCap3.TabIndex = 1
        lblCap3.Text = "Ejemplares disponibles"
        ' 
        ' lblNota3
        ' 
        lblNota3.AutoEllipsis = True
        lblNota3.Dock = DockStyle.Bottom
        lblNota3.Font = New Font("Segoe UI", 8F)
        lblNota3.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblNota3.Location = New Point(14, 107)
        lblNota3.Name = "lblNota3"
        lblNota3.Size = New Size(224, 23)
        lblNota3.TabIndex = 2
        lblNota3.Text = "Ahora · categoría elegida"
        ' 
        ' lblActualidad
        ' 
        lblActualidad.AutoEllipsis = True
        lblActualidad.Dock = DockStyle.Fill
        lblActualidad.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblActualidad.Location = New Point(25, 367)
        lblActualidad.Name = "lblActualidad"
        lblActualidad.Size = New Size(991, 42)
        lblActualidad.TabIndex = 4
        lblActualidad.Text = "La información se cargará al abrir la aplicación."
        lblActualidad.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' tlpGraficos
        ' 
        tlpGraficos.ColumnCount = 2
        tlpGraficos.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60F))
        tlpGraficos.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40F))
        tlpGraficos.Controls.Add(cardBarras, 0, 0)
        tlpGraficos.Controls.Add(cardDona, 1, 0)
        tlpGraficos.Dock = DockStyle.Fill
        tlpGraficos.Location = New Point(22, 409)
        tlpGraficos.Margin = New Padding(0)
        tlpGraficos.Name = "tlpGraficos"
        tlpGraficos.RowCount = 1
        tlpGraficos.RowStyles.Add(New RowStyle(SizeType.Absolute, 236F))
        tlpGraficos.Size = New Size(997, 236)
        tlpGraficos.TabIndex = 5
        ' 
        ' cardBarras
        ' 
        cardBarras.BackColor = Color.White
        cardBarras.BorderStyle = BorderStyle.FixedSingle
        cardBarras.Controls.Add(pnlBarras)
        cardBarras.Controls.Add(titulo_pnlBarras)
        cardBarras.Dock = DockStyle.Fill
        cardBarras.Location = New Point(0, 8)
        cardBarras.Margin = New Padding(0, 8, 12, 8)
        cardBarras.Name = "cardBarras"
        cardBarras.Padding = New Padding(14)
        cardBarras.Size = New Size(586, 220)
        cardBarras.TabIndex = 0
        ' 
        ' pnlBarras
        ' 
        pnlBarras.Controls.Add(vista_pnlBarras)
        pnlBarras.Dock = DockStyle.Fill
        pnlBarras.Location = New Point(14, 46)
        pnlBarras.Name = "pnlBarras"
        pnlBarras.Size = New Size(556, 158)
        pnlBarras.TabIndex = 0
        ' 
        ' vista_pnlBarras
        ' 
        vista_pnlBarras.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        vista_pnlBarras.Dock = DockStyle.Fill
        vista_pnlBarras.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        vista_pnlBarras.Location = New Point(0, 0)
        vista_pnlBarras.Name = "vista_pnlBarras"
        vista_pnlBarras.Size = New Size(556, 158)
        vista_pnlBarras.TabIndex = 0
        vista_pnlBarras.Text = "Vista de diseño · actividad por mes"
        vista_pnlBarras.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' titulo_pnlBarras
        ' 
        titulo_pnlBarras.Dock = DockStyle.Top
        titulo_pnlBarras.Font = New Font("Segoe UI Semibold", 11F)
        titulo_pnlBarras.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        titulo_pnlBarras.Location = New Point(14, 14)
        titulo_pnlBarras.Name = "titulo_pnlBarras"
        titulo_pnlBarras.Size = New Size(556, 32)
        titulo_pnlBarras.TabIndex = 1
        titulo_pnlBarras.Text = "Préstamos por mes de inicio"
        ' 
        ' cardDona
        ' 
        cardDona.BackColor = Color.White
        cardDona.BorderStyle = BorderStyle.FixedSingle
        cardDona.Controls.Add(pnlDona)
        cardDona.Controls.Add(titulo_pnlDona)
        cardDona.Dock = DockStyle.Fill
        cardDona.Location = New Point(598, 8)
        cardDona.Margin = New Padding(0, 8, 0, 8)
        cardDona.Name = "cardDona"
        cardDona.Padding = New Padding(14)
        cardDona.Size = New Size(399, 220)
        cardDona.TabIndex = 1
        ' 
        ' pnlDona
        ' 
        pnlDona.Controls.Add(vista_pnlDona)
        pnlDona.Dock = DockStyle.Fill
        pnlDona.Location = New Point(14, 46)
        pnlDona.Name = "pnlDona"
        pnlDona.Size = New Size(369, 158)
        pnlDona.TabIndex = 0
        ' 
        ' vista_pnlDona
        ' 
        vista_pnlDona.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        vista_pnlDona.Dock = DockStyle.Fill
        vista_pnlDona.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        vista_pnlDona.Location = New Point(0, 0)
        vista_pnlDona.Name = "vista_pnlDona"
        vista_pnlDona.Size = New Size(369, 158)
        vista_pnlDona.TabIndex = 0
        vista_pnlDona.Text = "Vista de diseño · distribución por estado"
        vista_pnlDona.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' titulo_pnlDona
        ' 
        titulo_pnlDona.Dock = DockStyle.Top
        titulo_pnlDona.Font = New Font("Segoe UI Semibold", 11F)
        titulo_pnlDona.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        titulo_pnlDona.Location = New Point(14, 14)
        titulo_pnlDona.Name = "titulo_pnlDona"
        titulo_pnlDona.Size = New Size(369, 32)
        titulo_pnlDona.TabIndex = 1
        titulo_pnlDona.Text = "Estado de la selección"
        ' 
        ' tlpDetalle
        ' 
        tlpDetalle.ColumnCount = 2
        tlpDetalle.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 58F))
        tlpDetalle.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 42F))
        tlpDetalle.Controls.Add(cardPendientes, 0, 0)
        tlpDetalle.Controls.Add(cardCategorias, 1, 0)
        tlpDetalle.Dock = DockStyle.Fill
        tlpDetalle.Location = New Point(22, 645)
        tlpDetalle.Margin = New Padding(0)
        tlpDetalle.Name = "tlpDetalle"
        tlpDetalle.RowCount = 1
        tlpDetalle.RowStyles.Add(New RowStyle(SizeType.Absolute, 228F))
        tlpDetalle.Size = New Size(997, 228)
        tlpDetalle.TabIndex = 6
        ' 
        ' cardPendientes
        ' 
        cardPendientes.BackColor = Color.White
        cardPendientes.BorderStyle = BorderStyle.FixedSingle
        cardPendientes.Controls.Add(tablaPendientes)
        cardPendientes.Controls.Add(lblPendientes)
        cardPendientes.Controls.Add(lblSinPendientes)
        cardPendientes.Dock = DockStyle.Fill
        cardPendientes.Location = New Point(0, 6)
        cardPendientes.Margin = New Padding(0, 6, 12, 0)
        cardPendientes.Name = "cardPendientes"
        cardPendientes.Padding = New Padding(12)
        cardPendientes.Size = New Size(566, 222)
        cardPendientes.TabIndex = 0
        ' 
        ' tablaPendientes
        ' 
        tablaPendientes.AccessibleName = "Tabla de resultados"
        tablaPendientes.AllowUserToAddRows = False
        tablaPendientes.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        tablaPendientes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        tablaPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaPendientes.BackgroundColor = Color.White
        tablaPendientes.BorderStyle = BorderStyle.None
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle2.Font = New Font("Segoe UI Semibold", 9F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        tablaPendientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        tablaPendientes.ColumnHeadersHeight = 40
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 10F)
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = "—"
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        tablaPendientes.DefaultCellStyle = DataGridViewCellStyle3
        tablaPendientes.Dock = DockStyle.Fill
        tablaPendientes.EnableHeadersVisualStyles = False
        tablaPendientes.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tablaPendientes.Location = New Point(12, 42)
        tablaPendientes.Margin = New Padding(0)
        tablaPendientes.MultiSelect = False
        tablaPendientes.Name = "tablaPendientes"
        tablaPendientes.ReadOnly = True
        tablaPendientes.RowHeadersVisible = False
        tablaPendientes.RowHeadersWidth = 51
        tablaPendientes.RowTemplate.Height = 36
        tablaPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaPendientes.Size = New Size(540, 142)
        tablaPendientes.TabIndex = 0
        ' 
        ' lblPendientes
        ' 
        lblPendientes.Dock = DockStyle.Top
        lblPendientes.Font = New Font("Segoe UI Semibold", 11F)
        lblPendientes.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblPendientes.Location = New Point(12, 12)
        lblPendientes.Name = "lblPendientes"
        lblPendientes.Size = New Size(540, 30)
        lblPendientes.TabIndex = 1
        lblPendientes.Text = "Próximas devoluciones de la selección"
        ' 
        ' lblSinPendientes
        ' 
        lblSinPendientes.Dock = DockStyle.Bottom
        lblSinPendientes.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblSinPendientes.Location = New Point(12, 184)
        lblSinPendientes.Name = "lblSinPendientes"
        lblSinPendientes.Size = New Size(540, 24)
        lblSinPendientes.TabIndex = 2
        lblSinPendientes.Text = "Sin datos cargados"
        ' 
        ' cardCategorias
        ' 
        cardCategorias.BackColor = Color.White
        cardCategorias.BorderStyle = BorderStyle.FixedSingle
        cardCategorias.Controls.Add(tablaCategorias)
        cardCategorias.Controls.Add(lblCategorias)
        cardCategorias.Controls.Add(lblNotaCategorias)
        cardCategorias.Dock = DockStyle.Fill
        cardCategorias.Location = New Point(578, 6)
        cardCategorias.Margin = New Padding(0, 6, 0, 0)
        cardCategorias.Name = "cardCategorias"
        cardCategorias.Padding = New Padding(12)
        cardCategorias.Size = New Size(419, 222)
        cardCategorias.TabIndex = 1
        ' 
        ' tablaCategorias
        ' 
        tablaCategorias.AccessibleName = "Tabla de resultados"
        tablaCategorias.AllowUserToAddRows = False
        tablaCategorias.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        tablaCategorias.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        tablaCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaCategorias.BackgroundColor = Color.White
        tablaCategorias.BorderStyle = BorderStyle.None
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle5.Font = New Font("Segoe UI Semibold", 9F)
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        tablaCategorias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        tablaCategorias.ColumnHeadersHeight = 40
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = SystemColors.Window
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 10F)
        DataGridViewCellStyle6.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle6.NullValue = "—"
        DataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        tablaCategorias.DefaultCellStyle = DataGridViewCellStyle6
        tablaCategorias.Dock = DockStyle.Fill
        tablaCategorias.EnableHeadersVisualStyles = False
        tablaCategorias.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tablaCategorias.Location = New Point(12, 42)
        tablaCategorias.Margin = New Padding(0)
        tablaCategorias.MultiSelect = False
        tablaCategorias.Name = "tablaCategorias"
        tablaCategorias.ReadOnly = True
        tablaCategorias.RowHeadersVisible = False
        tablaCategorias.RowHeadersWidth = 51
        tablaCategorias.RowTemplate.Height = 36
        tablaCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaCategorias.Size = New Size(393, 142)
        tablaCategorias.TabIndex = 0
        ' 
        ' lblCategorias
        ' 
        lblCategorias.Dock = DockStyle.Top
        lblCategorias.Font = New Font("Segoe UI Semibold", 11F)
        lblCategorias.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblCategorias.Location = New Point(12, 12)
        lblCategorias.Name = "lblCategorias"
        lblCategorias.Size = New Size(393, 30)
        lblCategorias.TabIndex = 1
        lblCategorias.Text = "Préstamos por categoría"
        ' 
        ' lblNotaCategorias
        ' 
        lblNotaCategorias.AutoEllipsis = True
        lblNotaCategorias.Dock = DockStyle.Bottom
        lblNotaCategorias.Font = New Font("Segoe UI", 8F)
        lblNotaCategorias.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblNotaCategorias.Location = New Point(12, 184)
        lblNotaCategorias.Name = "lblNotaCategorias"
        lblNotaCategorias.Size = New Size(393, 24)
        lblNotaCategorias.TabIndex = 2
        lblNotaCategorias.Text = "Un préstamo puede pertenecer a varias categorías."
        ' 
        ' lblEstadoCarga
        ' 
        lblEstadoCarga.AutoEllipsis = True
        lblEstadoCarga.Dock = DockStyle.Fill
        lblEstadoCarga.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblEstadoCarga.Location = New Point(25, 873)
        lblEstadoCarga.Name = "lblEstadoCarga"
        lblEstadoCarga.Size = New Size(991, 38)
        lblEstadoCarga.TabIndex = 7
        lblEstadoCarga.Text = "Sin datos cargados · Pulsa Actualizar para consultar."
        lblEstadoCarga.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblFooter
        ' 
        layoutPrincipal.SetColumnSpan(lblFooter, 2)
        lblFooter.Dock = DockStyle.Fill
        lblFooter.Font = New Font("Segoe UI", 8F)
        lblFooter.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblFooter.Location = New Point(3, 820)
        lblFooter.Name = "lblFooter"
        lblFooter.Size = New Size(1274, 30)
        lblFooter.TabIndex = 3
        lblFooter.Text = "Lecturae · Sistema de biblioteca"
        lblFooter.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(120F, 120F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.White
        ClientSize = New Size(1280, 850)
        Controls.Add(layoutPrincipal)
        Font = New Font("Segoe UI", 10F)
        MinimumSize = New Size(1000, 650)
        Name = "frmPrincipal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Panel de biblioteca"
        layoutPrincipal.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        CType(imagenMarca, ISupportInitialize).EndInit()
        pnlSesion.ResumeLayout(False)
        CType(imagenUsuario, ISupportInitialize).EndInit()
        pnlSide.ResumeLayout(False)
        flpMenu.ResumeLayout(False)
        pnlMain.ResumeLayout(False)
        panelDashboard.ResumeLayout(False)
        panelDashboard.PerformLayout()
        layoutDashboard.ResumeLayout(False)
        layoutDashboard.PerformLayout()
        encabezado.ResumeLayout(False)
        CType(imagenModulo, ISupportInitialize).EndInit()
        textoEncabezado.ResumeLayout(False)
        pnlFiltros.ResumeLayout(False)
        bloque_dtDesde.ResumeLayout(False)
        bloque_dtHasta.ResumeLayout(False)
        bloque_cboCat.ResumeLayout(False)
        bloque_cboEst.ResumeLayout(False)
        accesosRapidos.ResumeLayout(False)
        tlpStats.ResumeLayout(False)
        cardStat0.ResumeLayout(False)
        cardStat1.ResumeLayout(False)
        cardStat2.ResumeLayout(False)
        cardStat3.ResumeLayout(False)
        tlpGraficos.ResumeLayout(False)
        cardBarras.ResumeLayout(False)
        pnlBarras.ResumeLayout(False)
        cardDona.ResumeLayout(False)
        pnlDona.ResumeLayout(False)
        tlpDetalle.ResumeLayout(False)
        cardPendientes.ResumeLayout(False)
        CType(tablaPendientes, ISupportInitialize).EndInit()
        cardCategorias.ResumeLayout(False)
        CType(tablaCategorias, ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents layoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents imagenMarca As System.Windows.Forms.PictureBox
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents pnlSesion As System.Windows.Forms.Panel
    Friend WithEvents imagenUsuario As System.Windows.Forms.PictureBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblRol As System.Windows.Forms.Label
    Friend WithEvents pnlSide As System.Windows.Forms.Panel
    Friend WithEvents flpMenu As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblNavegacion As System.Windows.Forms.Label
    Friend WithEvents btnInicio As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnPrestamos As System.Windows.Forms.Button
    Friend WithEvents btnSolicitudes As System.Windows.Forms.Button
    Friend WithEvents btnLibros As System.Windows.Forms.Button
    Friend WithEvents btnAutores As System.Windows.Forms.Button
    Friend WithEvents btnCategorias As System.Windows.Forms.Button
    Friend WithEvents btnPenalizaciones As System.Windows.Forms.Button
    Friend WithEvents lblAyudaMenu As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents panelDashboard As System.Windows.Forms.Panel
    Friend WithEvents layoutDashboard As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents encabezado As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents imagenModulo As System.Windows.Forms.PictureBox
    Friend WithEvents textoEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTituloVista As System.Windows.Forms.Label
    Friend WithEvents lblDescripcionVista As System.Windows.Forms.Label
    Friend WithEvents pnlFiltros As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents dtDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents bloque_dtDesde As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_dtDesde As System.Windows.Forms.Label
    Friend WithEvents dtHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents bloque_dtHasta As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_dtHasta As System.Windows.Forms.Label
    Friend WithEvents cboCat As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_cboCat As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_cboCat As System.Windows.Forms.Label
    Friend WithEvents cboEst As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_cboEst As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_cboEst As System.Windows.Forms.Label
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents accesosRapidos As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnNuevoRapido As System.Windows.Forms.Button
    Friend WithEvents btnDevolverRapido As System.Windows.Forms.Button
    Friend WithEvents btnLectorRapido As System.Windows.Forms.Button
    Friend WithEvents btnCatalogoRapido As System.Windows.Forms.Button
    Friend WithEvents tlpStats As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cardStat0 As System.Windows.Forms.Panel
    Friend WithEvents lblCap0 As System.Windows.Forms.Label
    Friend WithEvents lblNum0 As System.Windows.Forms.Label
    Friend WithEvents lblNota0 As System.Windows.Forms.Label
    Friend WithEvents cardStat1 As System.Windows.Forms.Panel
    Friend WithEvents lblCap1 As System.Windows.Forms.Label
    Friend WithEvents lblNum1 As System.Windows.Forms.Label
    Friend WithEvents lblNota1 As System.Windows.Forms.Label
    Friend WithEvents cardStat2 As System.Windows.Forms.Panel
    Friend WithEvents lblCap2 As System.Windows.Forms.Label
    Friend WithEvents lblNum2 As System.Windows.Forms.Label
    Friend WithEvents lblNota2 As System.Windows.Forms.Label
    Friend WithEvents cardStat3 As System.Windows.Forms.Panel
    Friend WithEvents lblCap3 As System.Windows.Forms.Label
    Friend WithEvents lblNum3 As System.Windows.Forms.Label
    Friend WithEvents lblNota3 As System.Windows.Forms.Label
    Friend WithEvents lblActualidad As System.Windows.Forms.Label
    Friend WithEvents tlpGraficos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cardBarras As System.Windows.Forms.Panel
    Friend WithEvents titulo_pnlBarras As System.Windows.Forms.Label
    Friend WithEvents pnlBarras As System.Windows.Forms.Panel
    Friend WithEvents vista_pnlBarras As System.Windows.Forms.Label
    Friend WithEvents cardDona As System.Windows.Forms.Panel
    Friend WithEvents titulo_pnlDona As System.Windows.Forms.Label
    Friend WithEvents pnlDona As System.Windows.Forms.Panel
    Friend WithEvents vista_pnlDona As System.Windows.Forms.Label
    Friend WithEvents tlpDetalle As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cardPendientes As System.Windows.Forms.Panel
    Friend WithEvents lblPendientes As System.Windows.Forms.Label
    Friend WithEvents tablaPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents tablaPendientesCabecera As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents tablaPendientesCeldas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents tablaPendientesAlternas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents colPendienteId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendienteLector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendienteFin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendienteFinFormato As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents colPendienteEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblSinPendientes As System.Windows.Forms.Label
    Friend WithEvents cardCategorias As System.Windows.Forms.Panel
    Friend WithEvents lblCategorias As System.Windows.Forms.Label
    Friend WithEvents tablaCategorias As System.Windows.Forms.DataGridView
    Friend WithEvents tablaCategoriasCabecera As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents tablaCategoriasCeldas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents tablaCategoriasAlternas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents colCategoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNotaCategorias As System.Windows.Forms.Label
    Friend WithEvents lblEstadoCarga As System.Windows.Forms.Label
    Friend WithEvents lblFooter As System.Windows.Forms.Label
    Friend WithEvents btnUsuarios As System.Windows.Forms.Button
    Friend WithEvents btnBitacora As Button
End Class
