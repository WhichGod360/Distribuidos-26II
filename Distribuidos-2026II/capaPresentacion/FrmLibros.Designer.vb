\xEF\xBB\xBFImports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLibros
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        lblUsuario = New Label()
        lblRol = New Label()
        picUsuario = New PictureBox()
        pnlFooter = New Panel()
        lblFooter = New Label()
        pnlSidebar = New FlowLayoutPanel()
        btnInicio = New Button()
        btnBuscarUsuario = New Button()
        btnUsuarios = New Button()
        btnPrestamos = New Button()
        btnMantenimientos = New Button()
        pnlSubMant = New FlowLayoutPanel()
        btnSubLibros = New Button()
        btnSubEjemplares = New Button()
        btnSubAutores = New Button()
        btnSubCategorias = New Button()
        btnSubPenalizaciones = New Button()
        btnReportes = New Button()
        lblSoloAdmin = New Label()
        btnRoles = New Button()
        btnGestionarBibliotecarios = New Button()
        btnConfiguracion = New Button()
        pnlContent = New Panel()
        lblBreadcrumb = New Label()
        lblTitulo = New Label()
        btnAgregar = New Button()
        txtBuscar = New TextBox()
        cboEstado = New ComboBox()
        cboOrden = New ComboBox()
        lblRegistros = New Label()
        pnlPaginacion = New FlowLayoutPanel()
        btnPagPrev = New Button()
        flpNumeros = New FlowLayoutPanel()
        btnPagNext = New Button()
        DataGridView1 = New DataGridView()
        colId = New DataGridViewTextBoxColumn()
        colTitulo = New DataGridViewTextBoxColumn()
        colEditorial = New DataGridViewTextBoxColumn()
        colAnio = New DataGridViewTextBoxColumn()
        colStock = New DataGridViewTextBoxColumn()
        colEstado = New DataGridViewTextBoxColumn()
        DataGridViewButtonColumn1 = New DataGridViewButtonColumn()
        DataGridViewButtonColumn2 = New DataGridViewButtonColumn()
        picLogo = New PictureBox()
        btnLogo = New Button()
        pnlHeader.SuspendLayout()
        CType(picUsuario, ComponentModel.ISupportInitialize).BeginInit()
        pnlFooter.SuspendLayout()
        pnlSidebar.SuspendLayout()
        pnlSubMant.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlPaginacion.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(picLogo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(picLogo)
        pnlHeader.Controls.Add(btnLogo)
        pnlHeader.Controls.Add(lblUsuario)
        pnlHeader.Controls.Add(lblRol)
        pnlHeader.Controls.Add(picUsuario)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1100, 70)
        pnlHeader.TabIndex = 0
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.Location = New Point(800, 24)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(108, 19)
        lblUsuario.TabIndex = 1
        lblUsuario.Text = "Nombre usuario"
        ' 
        ' lblRol
        ' 
        lblRol.AutoSize = True
        lblRol.BackColor = Color.FromArgb(CByte(209), CByte(217), CByte(255))
        lblRol.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblRol.ForeColor = Color.FromArgb(CByte(25), CByte(35), CByte(140))
        lblRol.Location = New Point(925, 22)
        lblRol.Name = "lblRol"
        lblRol.Padding = New Padding(6, 3, 6, 3)
        lblRol.Size = New Size(89, 21)
        lblRol.TabIndex = 2
        lblRol.Text = "Bibliotecario"
        ' 
        ' picUsuario
        ' 
        picUsuario.BackColor = Color.FromArgb(CByte(191), CByte(201), CByte(255))
        picUsuario.Image = My.Resources.Resources.usuario
        picUsuario.Location = New Point(1033, 12)
        picUsuario.Name = "picUsuario"
        picUsuario.Size = New Size(55, 43)
        picUsuario.SizeMode = PictureBoxSizeMode.Zoom
        picUsuario.TabIndex = 3
        picUsuario.TabStop = False
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.FromArgb(CByte(12), CByte(12), CByte(12))
        pnlFooter.Controls.Add(lblFooter)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 640)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(1100, 60)
        pnlFooter.TabIndex = 1
        ' 
        ' lblFooter
        ' 
        lblFooter.Dock = DockStyle.Fill
        lblFooter.Font = New Font("Segoe UI", 9F)
        lblFooter.ForeColor = Color.White
        lblFooter.Location = New Point(0, 0)
        lblFooter.Name = "lblFooter"
        lblFooter.Size = New Size(1100, 60)
        lblFooter.TabIndex = 0
        lblFooter.Text = "Derechos reservados por la bibliotecaria marujita"
        lblFooter.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.AutoScroll = True
        pnlSidebar.BackColor = Color.FromArgb(CByte(240), CByte(243), CByte(255))
        pnlSidebar.Controls.Add(btnInicio)
        pnlSidebar.Controls.Add(btnBuscarUsuario)
        pnlSidebar.Controls.Add(btnUsuarios)
        pnlSidebar.Controls.Add(btnPrestamos)
        pnlSidebar.Controls.Add(btnMantenimientos)
        pnlSidebar.Controls.Add(pnlSubMant)
        pnlSidebar.Controls.Add(btnReportes)
        pnlSidebar.Controls.Add(lblSoloAdmin)
        pnlSidebar.Controls.Add(btnRoles)
        pnlSidebar.Controls.Add(btnGestionarBibliotecarios)
        pnlSidebar.Controls.Add(btnConfiguracion)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.FlowDirection = FlowDirection.TopDown
        pnlSidebar.Location = New Point(0, 70)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Padding = New Padding(10, 15, 0, 10)
        pnlSidebar.Size = New Size(210, 570)
        pnlSidebar.TabIndex = 2
        pnlSidebar.WrapContents = False
        ' 
        ' btnInicio
        ' 
        btnInicio.BackColor = Color.Transparent
        btnInicio.Cursor = Cursors.Hand
        btnInicio.FlatAppearance.BorderSize = 0
        btnInicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnInicio.FlatStyle = FlatStyle.Flat
        btnInicio.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnInicio.Location = New Point(10, 17)
        btnInicio.Margin = New Padding(0, 2, 0, 2)
        btnInicio.Name = "btnInicio"
        btnInicio.Padding = New Padding(6, 0, 0, 0)
        btnInicio.Size = New Size(190, 36)
        btnInicio.TabIndex = 0
        btnInicio.Text = "🏠 Inicio"
        btnInicio.TextAlign = ContentAlignment.MiddleLeft
        btnInicio.UseVisualStyleBackColor = False
        ' 
        ' btnBuscarUsuario
        ' 
        btnBuscarUsuario.BackColor = Color.Transparent
        btnBuscarUsuario.Cursor = Cursors.Hand
        btnBuscarUsuario.FlatAppearance.BorderSize = 0
        btnBuscarUsuario.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnBuscarUsuario.FlatStyle = FlatStyle.Flat
        btnBuscarUsuario.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnBuscarUsuario.Location = New Point(10, 57)
        btnBuscarUsuario.Margin = New Padding(0, 2, 0, 2)
        btnBuscarUsuario.Name = "btnBuscarUsuario"
        btnBuscarUsuario.Padding = New Padding(6, 0, 0, 0)
        btnBuscarUsuario.Size = New Size(190, 36)
        btnBuscarUsuario.TabIndex = 1
        btnBuscarUsuario.Text = "🔍 Buscar usuario"
        btnBuscarUsuario.TextAlign = ContentAlignment.MiddleLeft
        btnBuscarUsuario.UseVisualStyleBackColor = False
        ' 
        ' btnUsuarios
        ' 
        btnUsuarios.BackColor = Color.Transparent
        btnUsuarios.Cursor = Cursors.Hand
        btnUsuarios.FlatAppearance.BorderSize = 0
        btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnUsuarios.FlatStyle = FlatStyle.Flat
        btnUsuarios.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnUsuarios.Location = New Point(10, 97)
        btnUsuarios.Margin = New Padding(0, 2, 0, 2)
        btnUsuarios.Name = "btnUsuarios"
        btnUsuarios.Padding = New Padding(6, 0, 0, 0)
        btnUsuarios.Size = New Size(190, 36)
        btnUsuarios.TabIndex = 2
        btnUsuarios.Text = "👥 Usuarios"
        btnUsuarios.TextAlign = ContentAlignment.MiddleLeft
        btnUsuarios.UseVisualStyleBackColor = False
        ' 
        ' btnPrestamos
        ' 
        btnPrestamos.BackColor = Color.Transparent
        btnPrestamos.Cursor = Cursors.Hand
        btnPrestamos.FlatAppearance.BorderSize = 0
        btnPrestamos.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnPrestamos.FlatStyle = FlatStyle.Flat
        btnPrestamos.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnPrestamos.Location = New Point(10, 137)
        btnPrestamos.Margin = New Padding(0, 2, 0, 2)
        btnPrestamos.Name = "btnPrestamos"
        btnPrestamos.Padding = New Padding(6, 0, 0, 0)
        btnPrestamos.Size = New Size(190, 36)
        btnPrestamos.TabIndex = 3
        btnPrestamos.Text = "📖 Préstamos"
        btnPrestamos.TextAlign = ContentAlignment.MiddleLeft
        btnPrestamos.UseVisualStyleBackColor = False
        ' 
        ' btnMantenimientos
        ' 
        btnMantenimientos.BackColor = Color.FromArgb(CByte(74), CByte(108), CByte(247))
        btnMantenimientos.Cursor = Cursors.Hand
        btnMantenimientos.FlatAppearance.BorderSize = 0
        btnMantenimientos.FlatStyle = FlatStyle.Flat
        btnMantenimientos.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnMantenimientos.ForeColor = Color.White
        btnMantenimientos.Location = New Point(10, 177)
        btnMantenimientos.Margin = New Padding(0, 2, 0, 2)
        btnMantenimientos.Name = "btnMantenimientos"
        btnMantenimientos.Padding = New Padding(6, 0, 0, 0)
        btnMantenimientos.Size = New Size(190, 36)
        btnMantenimientos.TabIndex = 4
        btnMantenimientos.Text = "🛠 Mantenimientos ▾"
        btnMantenimientos.TextAlign = ContentAlignment.MiddleLeft
        btnMantenimientos.UseVisualStyleBackColor = False
        ' 
        ' pnlSubMant
        ' 
        pnlSubMant.AutoSize = True
        pnlSubMant.AutoSizeMode = AutoSizeMode.GrowAndShrink
        pnlSubMant.BackColor = Color.Transparent
        pnlSubMant.Controls.Add(btnSubLibros)
        pnlSubMant.Controls.Add(btnSubEjemplares)
        pnlSubMant.Controls.Add(btnSubAutores)
        pnlSubMant.Controls.Add(btnSubCategorias)
        pnlSubMant.Controls.Add(btnSubPenalizaciones)
        pnlSubMant.FlowDirection = FlowDirection.TopDown
        pnlSubMant.Location = New Point(10, 215)
        pnlSubMant.Margin = New Padding(0, 0, 0, 4)
        pnlSubMant.Name = "pnlSubMant"
        pnlSubMant.Padding = New Padding(20, 0, 0, 0)
        pnlSubMant.Size = New Size(185, 140)
        pnlSubMant.TabIndex = 5
        pnlSubMant.WrapContents = False
        ' 
        ' btnSubLibros
        ' 
        btnSubLibros.BackColor = Color.Transparent
        btnSubLibros.Cursor = Cursors.Hand
        btnSubLibros.FlatAppearance.BorderSize = 0
        btnSubLibros.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnSubLibros.FlatStyle = FlatStyle.Flat
        btnSubLibros.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnSubLibros.ForeColor = Color.FromArgb(CByte(74), CByte(108), CByte(247))
        btnSubLibros.Location = New Point(20, 0)
        btnSubLibros.Margin = New Padding(0)
        btnSubLibros.Name = "btnSubLibros"
        btnSubLibros.Size = New Size(165, 28)
        btnSubLibros.TabIndex = 0
        btnSubLibros.Text = "Libros"
        btnSubLibros.TextAlign = ContentAlignment.MiddleLeft
        btnSubLibros.UseVisualStyleBackColor = False
        ' 
        ' btnSubEjemplares
        ' 
        btnSubEjemplares.BackColor = Color.Transparent
        btnSubEjemplares.Cursor = Cursors.Hand
        btnSubEjemplares.FlatAppearance.BorderSize = 0
        btnSubEjemplares.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnSubEjemplares.FlatStyle = FlatStyle.Flat
        btnSubEjemplares.Font = New Font("Segoe UI", 9.5F)
        btnSubEjemplares.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(100))
        btnSubEjemplares.Location = New Point(20, 28)
        btnSubEjemplares.Margin = New Padding(0)
        btnSubEjemplares.Name = "btnSubEjemplares"
        btnSubEjemplares.Size = New Size(165, 28)
        btnSubEjemplares.TabIndex = 1
        btnSubEjemplares.Text = "Ejemplares"
        btnSubEjemplares.TextAlign = ContentAlignment.MiddleLeft
        btnSubEjemplares.UseVisualStyleBackColor = False
        ' 
        ' btnSubAutores
        ' 
        btnSubAutores.BackColor = Color.Transparent
        btnSubAutores.Cursor = Cursors.Hand
        btnSubAutores.FlatAppearance.BorderSize = 0
        btnSubAutores.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnSubAutores.FlatStyle = FlatStyle.Flat
        btnSubAutores.Font = New Font("Segoe UI", 9.5F)
        btnSubAutores.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(100))
        btnSubAutores.Location = New Point(20, 56)
        btnSubAutores.Margin = New Padding(0)
        btnSubAutores.Name = "btnSubAutores"
        btnSubAutores.Size = New Size(165, 28)
        btnSubAutores.TabIndex = 2
        btnSubAutores.Text = "Autores"
        btnSubAutores.TextAlign = ContentAlignment.MiddleLeft
        btnSubAutores.UseVisualStyleBackColor = False
        ' 
        ' btnSubCategorias
        ' 
        btnSubCategorias.BackColor = Color.Transparent
        btnSubCategorias.Cursor = Cursors.Hand
        btnSubCategorias.FlatAppearance.BorderSize = 0
        btnSubCategorias.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnSubCategorias.FlatStyle = FlatStyle.Flat
        btnSubCategorias.Font = New Font("Segoe UI", 9.5F)
        btnSubCategorias.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(100))
        btnSubCategorias.Location = New Point(20, 84)
        btnSubCategorias.Margin = New Padding(0)
        btnSubCategorias.Name = "btnSubCategorias"
        btnSubCategorias.Size = New Size(165, 28)
        btnSubCategorias.TabIndex = 3
        btnSubCategorias.Text = "Categorías"
        btnSubCategorias.TextAlign = ContentAlignment.MiddleLeft
        btnSubCategorias.UseVisualStyleBackColor = False
        ' 
        ' btnSubPenalizaciones
        ' 
        btnSubPenalizaciones.BackColor = Color.Transparent
        btnSubPenalizaciones.Cursor = Cursors.Hand
        btnSubPenalizaciones.FlatAppearance.BorderSize = 0
        btnSubPenalizaciones.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnSubPenalizaciones.FlatStyle = FlatStyle.Flat
        btnSubPenalizaciones.Font = New Font("Segoe UI", 9.5F)
        btnSubPenalizaciones.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(100))
        btnSubPenalizaciones.Location = New Point(20, 112)
        btnSubPenalizaciones.Margin = New Padding(0)
        btnSubPenalizaciones.Name = "btnSubPenalizaciones"
        btnSubPenalizaciones.Size = New Size(165, 28)
        btnSubPenalizaciones.TabIndex = 4
        btnSubPenalizaciones.Text = "Penalizaciones"
        btnSubPenalizaciones.TextAlign = ContentAlignment.MiddleLeft
        btnSubPenalizaciones.UseVisualStyleBackColor = False
        ' 
        ' btnReportes
        ' 
        btnReportes.BackColor = Color.Transparent
        btnReportes.Cursor = Cursors.Hand
        btnReportes.FlatAppearance.BorderSize = 0
        btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnReportes.FlatStyle = FlatStyle.Flat
        btnReportes.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnReportes.Location = New Point(10, 361)
        btnReportes.Margin = New Padding(0, 2, 0, 2)
        btnReportes.Name = "btnReportes"
        btnReportes.Padding = New Padding(6, 0, 0, 0)
        btnReportes.Size = New Size(190, 36)
        btnReportes.TabIndex = 6
        btnReportes.Text = "📊 Reportes"
        btnReportes.TextAlign = ContentAlignment.MiddleLeft
        btnReportes.UseVisualStyleBackColor = False
        ' 
        ' lblSoloAdmin
        ' 
        lblSoloAdmin.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblSoloAdmin.ForeColor = Color.FromArgb(CByte(110), CByte(115), CByte(130))
        lblSoloAdmin.Location = New Point(10, 411)
        lblSoloAdmin.Margin = New Padding(0, 12, 0, 2)
        lblSoloAdmin.Name = "lblSoloAdmin"
        lblSoloAdmin.Padding = New Padding(8, 0, 0, 0)
        lblSoloAdmin.Size = New Size(190, 22)
        lblSoloAdmin.TabIndex = 7
        lblSoloAdmin.Text = "SOLO ADMINISTRADOR"
        lblSoloAdmin.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' btnRoles
        ' 
        btnRoles.BackColor = Color.Transparent
        btnRoles.Cursor = Cursors.Hand
        btnRoles.FlatAppearance.BorderSize = 0
        btnRoles.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnRoles.FlatStyle = FlatStyle.Flat
        btnRoles.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnRoles.Location = New Point(10, 437)
        btnRoles.Margin = New Padding(0, 2, 0, 2)
        btnRoles.Name = "btnRoles"
        btnRoles.Padding = New Padding(6, 0, 0, 0)
        btnRoles.Size = New Size(190, 36)
        btnRoles.TabIndex = 8
        btnRoles.Text = "Roles y permisos  🔒"
        btnRoles.TextAlign = ContentAlignment.MiddleLeft
        btnRoles.UseVisualStyleBackColor = False
        ' 
        ' btnGestionarBibliotecarios
        ' 
        btnGestionarBibliotecarios.BackColor = Color.Transparent
        btnGestionarBibliotecarios.Cursor = Cursors.Hand
        btnGestionarBibliotecarios.FlatAppearance.BorderSize = 0
        btnGestionarBibliotecarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnGestionarBibliotecarios.FlatStyle = FlatStyle.Flat
        btnGestionarBibliotecarios.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnGestionarBibliotecarios.Location = New Point(10, 477)
        btnGestionarBibliotecarios.Margin = New Padding(0, 2, 0, 2)
        btnGestionarBibliotecarios.Name = "btnGestionarBibliotecarios"
        btnGestionarBibliotecarios.Padding = New Padding(6, 0, 0, 0)
        btnGestionarBibliotecarios.Size = New Size(190, 48)
        btnGestionarBibliotecarios.TabIndex = 9
        btnGestionarBibliotecarios.Text = "Gestionar bibliotecarios  🔒"
        btnGestionarBibliotecarios.TextAlign = ContentAlignment.MiddleLeft
        btnGestionarBibliotecarios.UseVisualStyleBackColor = False
        ' 
        ' btnConfiguracion
        ' 
        btnConfiguracion.BackColor = Color.Transparent
        btnConfiguracion.Cursor = Cursors.Hand
        btnConfiguracion.FlatAppearance.BorderSize = 0
        btnConfiguracion.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(225), CByte(231), CByte(255))
        btnConfiguracion.FlatStyle = FlatStyle.Flat
        btnConfiguracion.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnConfiguracion.Location = New Point(10, 529)
        btnConfiguracion.Margin = New Padding(0, 2, 0, 2)
        btnConfiguracion.Name = "btnConfiguracion"
        btnConfiguracion.Padding = New Padding(6, 0, 0, 0)
        btnConfiguracion.Size = New Size(190, 36)
        btnConfiguracion.TabIndex = 10
        btnConfiguracion.Text = "Configuración  🔒"
        btnConfiguracion.TextAlign = ContentAlignment.MiddleLeft
        btnConfiguracion.UseVisualStyleBackColor = False
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.White
        pnlContent.Controls.Add(DataGridView1)
        pnlContent.Controls.Add(lblBreadcrumb)
        pnlContent.Controls.Add(lblTitulo)
        pnlContent.Controls.Add(btnAgregar)
        pnlContent.Controls.Add(txtBuscar)
        pnlContent.Controls.Add(cboEstado)
        pnlContent.Controls.Add(cboOrden)
        pnlContent.Controls.Add(lblRegistros)
        pnlContent.Controls.Add(pnlPaginacion)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(210, 70)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(890, 570)
        pnlContent.TabIndex = 3
        ' 
        ' lblBreadcrumb
        ' 
        lblBreadcrumb.AutoSize = True
        lblBreadcrumb.Font = New Font("Segoe UI", 9F)
        lblBreadcrumb.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(100))
        lblBreadcrumb.Location = New Point(30, 22)
        lblBreadcrumb.Name = "lblBreadcrumb"
        lblBreadcrumb.Size = New Size(137, 15)
        lblBreadcrumb.TabIndex = 0
        lblBreadcrumb.Text = "Mantenimientos / Libros"
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblTitulo.Location = New Point(24, 40)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(302, 32)
        lblTitulo.TabIndex = 1
        lblTitulo.Text = "Mantenimiento de Libros"
        ' 
        ' btnAgregar
        ' 
        btnAgregar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAgregar.BackColor = Color.FromArgb(CByte(74), CByte(108), CByte(247))
        btnAgregar.Cursor = Cursors.Hand
        btnAgregar.FlatAppearance.BorderSize = 0
        btnAgregar.FlatStyle = FlatStyle.Flat
        btnAgregar.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnAgregar.ForeColor = Color.White
        btnAgregar.Location = New Point(700, 38)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(160, 40)
        btnAgregar.TabIndex = 2
        btnAgregar.Text = "+ Agregar libro"
        btnAgregar.UseVisualStyleBackColor = False
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtBuscar.BorderStyle = BorderStyle.FixedSingle
        txtBuscar.Font = New Font("Segoe UI", 11F)
        txtBuscar.Location = New Point(30, 87)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.Size = New Size(490, 27)
        txtBuscar.TabIndex = 3
        ' 
        ' cboEstado
        ' 
        cboEstado.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cboEstado.DropDownStyle = ComboBoxStyle.DropDownList
        cboEstado.Font = New Font("Segoe UI", 10F)
        cboEstado.FormattingEnabled = True
        cboEstado.Items.AddRange(New Object() {"Estado: Todos", "Estado: Activo", "Estado: Inactivo"})
        cboEstado.Location = New Point(531, 87)
        cboEstado.Name = "cboEstado"
        cboEstado.Size = New Size(160, 25)
        cboEstado.TabIndex = 4
        ' 
        ' cboOrden
        ' 
        cboOrden.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cboOrden.DropDownStyle = ComboBoxStyle.DropDownList
        cboOrden.Font = New Font("Segoe UI", 10F)
        cboOrden.FormattingEnabled = True
        cboOrden.Items.AddRange(New Object() {"Ordenar: A-Z", "Ordenar: Z-A", "Ordenar: Año ↑", "Ordenar: Año ↓"})
        cboOrden.Location = New Point(700, 87)
        cboOrden.Name = "cboOrden"
        cboOrden.Size = New Size(160, 25)
        cboOrden.TabIndex = 5
        ' 
        ' lblRegistros
        ' 
        lblRegistros.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblRegistros.AutoSize = True
        lblRegistros.Font = New Font("Segoe UI", 9F)
        lblRegistros.ForeColor = Color.FromArgb(CByte(90), CByte(90), CByte(100))
        lblRegistros.Location = New Point(30, 449)
        lblRegistros.Name = "lblRegistros"
        lblRegistros.Size = New Size(165, 15)
        lblRegistros.TabIndex = 7
        lblRegistros.Text = "Mostrando 1–5 de 48 registros"
        ' 
        ' pnlPaginacion
        ' 
        pnlPaginacion.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        pnlPaginacion.AutoSize = True
        pnlPaginacion.AutoSizeMode = AutoSizeMode.GrowAndShrink
        pnlPaginacion.Controls.Add(btnPagPrev)
        pnlPaginacion.Controls.Add(flpNumeros)
        pnlPaginacion.Controls.Add(btnPagNext)
        pnlPaginacion.Location = New Point(780, 446)
        pnlPaginacion.Margin = New Padding(0)
        pnlPaginacion.Name = "pnlPaginacion"
        pnlPaginacion.Size = New Size(80, 36)
        pnlPaginacion.TabIndex = 8
        pnlPaginacion.WrapContents = False
        ' 
        ' btnPagPrev
        ' 
        btnPagPrev.Cursor = Cursors.Hand
        btnPagPrev.FlatAppearance.BorderColor = Color.FromArgb(CByte(200), CByte(205), CByte(220))
        btnPagPrev.FlatStyle = FlatStyle.Flat
        btnPagPrev.Location = New Point(3, 3)
        btnPagPrev.Name = "btnPagPrev"
        btnPagPrev.Size = New Size(34, 30)
        btnPagPrev.TabIndex = 0
        btnPagPrev.Text = "‹"
        btnPagPrev.UseVisualStyleBackColor = True
        ' 
        ' flpNumeros
        ' 
        flpNumeros.AutoSize = True
        flpNumeros.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpNumeros.Location = New Point(40, 0)
        flpNumeros.Margin = New Padding(0)
        flpNumeros.Name = "flpNumeros"
        flpNumeros.Size = New Size(0, 0)
        flpNumeros.TabIndex = 1
        flpNumeros.WrapContents = False
        ' 
        ' btnPagNext
        ' 
        btnPagNext.Cursor = Cursors.Hand
        btnPagNext.FlatAppearance.BorderColor = Color.FromArgb(CByte(200), CByte(205), CByte(220))
        btnPagNext.FlatStyle = FlatStyle.Flat
        btnPagNext.Location = New Point(43, 3)
        btnPagNext.Name = "btnPagNext"
        btnPagNext.Size = New Size(34, 30)
        btnPagNext.TabIndex = 2
        btnPagNext.Text = "›"
        btnPagNext.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(74), CByte(108), CByte(247))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.White
        DataGridViewCellStyle1.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeight = 42
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {colId, colTitulo, colEditorial, colAnio, colStock, colEstado, DataGridViewButtonColumn1, DataGridViewButtonColumn2})
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = Color.SlateGray
        DataGridView1.Location = New Point(30, 130)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue
        DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black
        DataGridView1.RowTemplate.Height = 48
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(830, 303)
        DataGridView1.TabIndex = 15
        ' 
        ' colId
        ' 
        colId.HeaderText = "ID"
        colId.Name = "colId"
        colId.ReadOnly = True
        ' 
        ' colTitulo
        ' 
        colTitulo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colTitulo.HeaderText = "Título"
        colTitulo.Name = "colTitulo"
        colTitulo.ReadOnly = True
        ' 
        ' colEditorial
        ' 
        colEditorial.HeaderText = "Editorial"
        colEditorial.Name = "colEditorial"
        colEditorial.ReadOnly = True
        ' 
        ' colAnio
        ' 
        colAnio.HeaderText = "Año"
        colAnio.Name = "colAnio"
        colAnio.ReadOnly = True
        ' 
        ' colStock
        ' 
        colStock.HeaderText = "Stock"
        colStock.Name = "colStock"
        colStock.ReadOnly = True
        ' 
        ' colEstado
        ' 
        colEstado.HeaderText = "Estado"
        colEstado.Name = "colEstado"
        colEstado.ReadOnly = True
        ' 
        ' DataGridViewButtonColumn1
        ' 
        DataGridViewButtonColumn1.FlatStyle = FlatStyle.Flat
        DataGridViewButtonColumn1.HeaderText = "Acciones"
        DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        DataGridViewButtonColumn1.Text = "Editar"
        DataGridViewButtonColumn1.UseColumnTextForButtonValue = True
        ' 
        ' DataGridViewButtonColumn2
        ' 
        DataGridViewButtonColumn2.FlatStyle = FlatStyle.Flat
        DataGridViewButtonColumn2.HeaderText = ""
        DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        DataGridViewButtonColumn2.Text = "Eliminar"
        DataGridViewButtonColumn2.UseColumnTextForButtonValue = True
        ' 
        ' picLogo
        ' 
        picLogo.BackColor = Color.FromArgb(CByte(191), CByte(201), CByte(255))
        picLogo.Image = My.Resources.Resources.no
        picLogo.Location = New Point(0, 0)
        picLogo.Name = "picLogo"
        picLogo.Size = New Size(210, 70)
        picLogo.SizeMode = PictureBoxSizeMode.Zoom
        picLogo.TabIndex = 4
        picLogo.TabStop = False
        ' 
        ' btnLogo
        ' 
        btnLogo.BackColor = Color.FromArgb(CByte(74), CByte(108), CByte(247))
        btnLogo.Cursor = Cursors.Hand
        btnLogo.FlatAppearance.BorderSize = 0
        btnLogo.FlatStyle = FlatStyle.Flat
        btnLogo.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnLogo.ForeColor = Color.White
        btnLogo.Location = New Point(240, 12)
        btnLogo.Name = "btnLogo"
        btnLogo.Size = New Size(100, 40)
        btnLogo.TabIndex = 0
        btnLogo.Text = "LOGO"
        btnLogo.UseVisualStyleBackColor = False
        ' 
        ' FrmLibros
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1100, 700)
        Controls.Add(pnlContent)
        Controls.Add(pnlSidebar)
        Controls.Add(pnlFooter)
        Controls.Add(pnlHeader)
        Font = New Font("Segoe UI", 10F)
        MinimumSize = New Size(1000, 650)
        Name = "FrmLibros"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Mantenimiento de Libros"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(picUsuario, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        pnlSidebar.ResumeLayout(False)
        pnlSidebar.PerformLayout()
        pnlSubMant.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlContent.PerformLayout()
        pnlPaginacion.ResumeLayout(False)
        pnlPaginacion.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(picLogo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblRol As Label
    Friend WithEvents picUsuario As PictureBox
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents lblFooter As Label
    Friend WithEvents pnlSidebar As FlowLayoutPanel
    Friend WithEvents btnInicio As Button
    Friend WithEvents btnBuscarUsuario As Button
    Friend WithEvents btnUsuarios As Button
    Friend WithEvents btnPrestamos As Button
    Friend WithEvents btnMantenimientos As Button
    Friend WithEvents pnlSubMant As FlowLayoutPanel
    Friend WithEvents btnSubLibros As Button
    Friend WithEvents btnSubEjemplares As Button
    Friend WithEvents btnSubAutores As Button
    Friend WithEvents btnSubCategorias As Button
    Friend WithEvents btnSubPenalizaciones As Button
    Friend WithEvents btnReportes As Button
    Friend WithEvents lblSoloAdmin As Label
    Friend WithEvents btnRoles As Button
    Friend WithEvents btnGestionarBibliotecarios As Button
    Friend WithEvents btnConfiguracion As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents lblBreadcrumb As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents cboOrden As ComboBox
    Friend WithEvents colId As DataGridViewTextBoxColumn
    Friend WithEvents colTitulo As DataGridViewTextBoxColumn
    Friend WithEvents colEditorial As DataGridViewTextBoxColumn
    Friend WithEvents colAnio As DataGridViewTextBoxColumn
    Friend WithEvents colStock As DataGridViewTextBoxColumn
    Friend WithEvents colEstado As DataGridViewTextBoxColumn
    Friend WithEvents lblRegistros As Label
    Friend WithEvents pnlPaginacion As FlowLayoutPanel
    Friend WithEvents btnPagPrev As Button
    Friend WithEvents flpNumeros As FlowLayoutPanel
    Friend WithEvents btnPagNext As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn2 As DataGridViewButtonColumn
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents btnLogo As Button

End Class
