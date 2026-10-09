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
        Me.components = New System.ComponentModel.Container()
        Me.layoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.imagenMarca = New System.Windows.Forms.PictureBox()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.pnlSesion = New System.Windows.Forms.Panel()
        Me.imagenUsuario = New System.Windows.Forms.PictureBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblRol = New System.Windows.Forms.Label()
        Me.pnlSide = New System.Windows.Forms.Panel()
        Me.flpMenu = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblNavegacion = New System.Windows.Forms.Label()
        Me.btnInicio = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnPrestamos = New System.Windows.Forms.Button()
        Me.btnLibros = New System.Windows.Forms.Button()
        Me.btnAutores = New System.Windows.Forms.Button()
        Me.btnCategorias = New System.Windows.Forms.Button()
        Me.btnPenalizaciones = New System.Windows.Forms.Button()
        Me.lblAyudaMenu = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.panelDashboard = New System.Windows.Forms.Panel()
        Me.layoutDashboard = New System.Windows.Forms.TableLayoutPanel()
        Me.encabezado = New System.Windows.Forms.TableLayoutPanel()
        Me.imagenModulo = New System.Windows.Forms.PictureBox()
        Me.textoEncabezado = New System.Windows.Forms.Panel()
        Me.lblTituloVista = New System.Windows.Forms.Label()
        Me.lblDescripcionVista = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.FlowLayoutPanel()
        Me.dtDesde = New System.Windows.Forms.DateTimePicker()
        Me.bloque_dtDesde = New System.Windows.Forms.Panel()
        Me.etiqueta_dtDesde = New System.Windows.Forms.Label()
        Me.dtHasta = New System.Windows.Forms.DateTimePicker()
        Me.bloque_dtHasta = New System.Windows.Forms.Panel()
        Me.etiqueta_dtHasta = New System.Windows.Forms.Label()
        Me.cboCat = New System.Windows.Forms.ComboBox()
        Me.bloque_cboCat = New System.Windows.Forms.Panel()
        Me.etiqueta_cboCat = New System.Windows.Forms.Label()
        Me.cboEst = New System.Windows.Forms.ComboBox()
        Me.bloque_cboEst = New System.Windows.Forms.Panel()
        Me.etiqueta_cboEst = New System.Windows.Forms.Label()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.accesosRapidos = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNuevoRapido = New System.Windows.Forms.Button()
        Me.btnDevolverRapido = New System.Windows.Forms.Button()
        Me.btnLectorRapido = New System.Windows.Forms.Button()
        Me.btnCatalogoRapido = New System.Windows.Forms.Button()
        Me.tlpStats = New System.Windows.Forms.TableLayoutPanel()
        Me.cardStat0 = New System.Windows.Forms.Panel()
        Me.lblCap0 = New System.Windows.Forms.Label()
        Me.lblNum0 = New System.Windows.Forms.Label()
        Me.lblNota0 = New System.Windows.Forms.Label()
        Me.cardStat1 = New System.Windows.Forms.Panel()
        Me.lblCap1 = New System.Windows.Forms.Label()
        Me.lblNum1 = New System.Windows.Forms.Label()
        Me.lblNota1 = New System.Windows.Forms.Label()
        Me.cardStat2 = New System.Windows.Forms.Panel()
        Me.lblCap2 = New System.Windows.Forms.Label()
        Me.lblNum2 = New System.Windows.Forms.Label()
        Me.lblNota2 = New System.Windows.Forms.Label()
        Me.cardStat3 = New System.Windows.Forms.Panel()
        Me.lblCap3 = New System.Windows.Forms.Label()
        Me.lblNum3 = New System.Windows.Forms.Label()
        Me.lblNota3 = New System.Windows.Forms.Label()
        Me.lblActualidad = New System.Windows.Forms.Label()
        Me.tlpGraficos = New System.Windows.Forms.TableLayoutPanel()
        Me.cardBarras = New System.Windows.Forms.Panel()
        Me.titulo_pnlBarras = New System.Windows.Forms.Label()
        Me.pnlBarras = New System.Windows.Forms.Panel()
        Me.vista_pnlBarras = New System.Windows.Forms.Label()
        Me.cardDona = New System.Windows.Forms.Panel()
        Me.titulo_pnlDona = New System.Windows.Forms.Label()
        Me.pnlDona = New System.Windows.Forms.Panel()
        Me.vista_pnlDona = New System.Windows.Forms.Label()
        Me.tlpDetalle = New System.Windows.Forms.TableLayoutPanel()
        Me.cardPendientes = New System.Windows.Forms.Panel()
        Me.lblPendientes = New System.Windows.Forms.Label()
        Me.tablaPendientes = New System.Windows.Forms.DataGridView()
        Me.tablaPendientesCabecera = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tablaPendientesCeldas = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tablaPendientesAlternas = New System.Windows.Forms.DataGridViewCellStyle()
        Me.colPendienteId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendienteLector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendienteFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendienteFinFormato = New System.Windows.Forms.DataGridViewCellStyle()
        Me.colPendienteEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblSinPendientes = New System.Windows.Forms.Label()
        Me.cardCategorias = New System.Windows.Forms.Panel()
        Me.lblCategorias = New System.Windows.Forms.Label()
        Me.tablaCategorias = New System.Windows.Forms.DataGridView()
        Me.tablaCategoriasCabecera = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tablaCategoriasCeldas = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tablaCategoriasAlternas = New System.Windows.Forms.DataGridViewCellStyle()
        Me.colCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblNotaCategorias = New System.Windows.Forms.Label()
        Me.lblEstadoCarga = New System.Windows.Forms.Label()
        Me.lblFooter = New System.Windows.Forms.Label()
        CType(Me.imagenMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imagenUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tablaPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tablaCategorias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutPrincipal.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlSesion.SuspendLayout()
        Me.pnlSide.SuspendLayout()
        Me.flpMenu.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.panelDashboard.SuspendLayout()
        Me.layoutDashboard.SuspendLayout()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.bloque_dtDesde.SuspendLayout()
        Me.bloque_dtHasta.SuspendLayout()
        Me.bloque_cboCat.SuspendLayout()
        Me.bloque_cboEst.SuspendLayout()
        Me.accesosRapidos.SuspendLayout()
        Me.tlpStats.SuspendLayout()
        Me.cardStat0.SuspendLayout()
        Me.cardStat1.SuspendLayout()
        Me.cardStat2.SuspendLayout()
        Me.cardStat3.SuspendLayout()
        Me.tlpGraficos.SuspendLayout()
        Me.cardBarras.SuspendLayout()
        Me.pnlBarras.SuspendLayout()
        Me.cardDona.SuspendLayout()
        Me.pnlDona.SuspendLayout()
        Me.tlpDetalle.SuspendLayout()
        Me.cardPendientes.SuspendLayout()
        Me.cardCategorias.SuspendLayout()
        Me.SuspendLayout()
        Me.layoutPrincipal.Name = "layoutPrincipal"
        Me.layoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutPrincipal.RowCount = 3
        Me.layoutPrincipal.ColumnCount = 2
        Me.layoutPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.layoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212!))
        Me.layoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(22, 8, 22, 8)
        Me.imagenMarca.Name = "imagenMarca"
        Me.imagenMarca.Image = Global.capaInterfaz.My.Resources.Resources.no
        Me.imagenMarca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imagenMarca.Dock = System.Windows.Forms.DockStyle.Left
        Me.imagenMarca.Width = 54
        Me.imagenMarca.TabStop = False
        Me.imagenMarca.AccessibleName = "Lecturae biblioteca y comunidad"
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Text = "LECTURAE  /  Biblioteca"
        Me.lblMarca.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblMarca.AutoSize = False
        Me.lblMarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMarca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMarca.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.lblMarca.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.pnlSesion.Name = "pnlSesion"
        Me.pnlSesion.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSesion.Width = 345
        Me.imagenUsuario.Name = "imagenUsuario"
        Me.imagenUsuario.Image = Global.capaInterfaz.My.Resources.Resources.usuario
        Me.imagenUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imagenUsuario.Dock = System.Windows.Forms.DockStyle.Right
        Me.imagenUsuario.Width = 48
        Me.imagenUsuario.TabStop = False
        Me.imagenUsuario.AccessibleName = "Usuario autenticado"
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Text = "Nombre del usuario"
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblNombre.AutoSize = False
        Me.lblNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNombre.Height = 26
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblNombre.Padding = New System.Windows.Forms.Padding(0, 0, 58, 0)
        Me.lblRol.Name = "lblRol"
        Me.lblRol.Text = "Rol e ID de la sesión"
        Me.lblRol.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblRol.AutoSize = False
        Me.lblRol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRol.Padding = New System.Windows.Forms.Padding(0, 0, 58, 0)
        Me.pnlSesion.Controls.Add(Me.lblRol)
        Me.pnlSesion.Controls.Add(Me.lblNombre)
        Me.pnlSesion.Controls.Add(Me.imagenUsuario)
        Me.pnlHeader.Controls.Add(Me.lblMarca)
        Me.pnlHeader.Controls.Add(Me.imagenMarca)
        Me.pnlHeader.Controls.Add(Me.pnlSesion)
        Me.layoutPrincipal.Controls.Add(Me.pnlHeader, 0, 0)
        Me.layoutPrincipal.SetColumnSpan(Me.pnlHeader, 2)
        Me.pnlSide.Name = "pnlSide"
        Me.pnlSide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSide.BackColor = System.Drawing.Color.FromArgb(244, 246, 253)
        Me.pnlSide.Padding = New System.Windows.Forms.Padding(14, 20, 10, 12)
        Me.flpMenu.Name = "flpMenu"
        Me.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpMenu.WrapContents = False
        Me.flpMenu.AutoScroll = True
        Me.lblNavegacion.Name = "lblNavegacion"
        Me.lblNavegacion.Text = "TU BIBLIOTECA"
        Me.lblNavegacion.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblNavegacion.AutoSize = False
        Me.lblNavegacion.Size = New System.Drawing.Size(175, 32)
        Me.lblNavegacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.flpMenu.Controls.Add(Me.lblNavegacion)
        Me.btnInicio.Name = "btnInicio"
        Me.btnInicio.Text = "Inicio"
        Me.btnInicio.Size = New System.Drawing.Size(170, 43)
        Me.btnInicio.AutoSize = False
        Me.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInicio.FlatAppearance.BorderSize = 0
        Me.btnInicio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnInicio.BackColor = System.Drawing.Color.FromArgb(244, 246, 253)
        Me.btnInicio.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnInicio.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInicio.Margin = New System.Windows.Forms.Padding(0, 0, 0, 7)
        Me.btnInicio.UseVisualStyleBackColor = False
        Me.btnInicio.Tag = "inicio"
        Me.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInicio.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.flpMenu.Controls.Add(Me.btnInicio)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar lectores"
        Me.btnBuscar.Size = New System.Drawing.Size(170, 43)
        Me.btnBuscar.AutoSize = False
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(244, 246, 253)
        Me.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(0, 0, 0, 7)
        Me.btnBuscar.UseVisualStyleBackColor = False
        Me.btnBuscar.Tag = "lectores"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.flpMenu.Controls.Add(Me.btnBuscar)
        Me.btnPrestamos.Name = "btnPrestamos"
        Me.btnPrestamos.Text = "Préstamos"
        Me.btnPrestamos.Size = New System.Drawing.Size(170, 43)
        Me.btnPrestamos.AutoSize = False
        Me.btnPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrestamos.FlatAppearance.BorderSize = 0
        Me.btnPrestamos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnPrestamos.BackColor = System.Drawing.Color.FromArgb(244, 246, 253)
        Me.btnPrestamos.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnPrestamos.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrestamos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrestamos.Margin = New System.Windows.Forms.Padding(0, 0, 0, 7)
        Me.btnPrestamos.UseVisualStyleBackColor = False
        Me.btnPrestamos.Tag = "prestamos"
        Me.btnPrestamos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrestamos.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.flpMenu.Controls.Add(Me.btnPrestamos)
        Me.btnLibros.Name = "btnLibros"
        Me.btnLibros.Text = "Libros y ejemplares"
        Me.btnLibros.Size = New System.Drawing.Size(170, 43)
        Me.btnLibros.AutoSize = False
        Me.btnLibros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLibros.FlatAppearance.BorderSize = 0
        Me.btnLibros.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnLibros.BackColor = System.Drawing.Color.FromArgb(244, 246, 253)
        Me.btnLibros.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnLibros.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLibros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLibros.Margin = New System.Windows.Forms.Padding(0, 0, 0, 7)
        Me.btnLibros.UseVisualStyleBackColor = False
        Me.btnLibros.Tag = "libros"
        Me.btnLibros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLibros.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.flpMenu.Controls.Add(Me.btnLibros)
        Me.btnAutores.Name = "btnAutores"
        Me.btnAutores.Text = "Autores"
        Me.btnAutores.Size = New System.Drawing.Size(170, 43)
        Me.btnAutores.AutoSize = False
        Me.btnAutores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutores.FlatAppearance.BorderSize = 0
        Me.btnAutores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnAutores.BackColor = System.Drawing.Color.FromArgb(244, 246, 253)
        Me.btnAutores.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnAutores.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAutores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutores.Margin = New System.Windows.Forms.Padding(0, 0, 0, 7)
        Me.btnAutores.UseVisualStyleBackColor = False
        Me.btnAutores.Tag = "autores"
        Me.btnAutores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAutores.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.flpMenu.Controls.Add(Me.btnAutores)
        Me.btnCategorias.Name = "btnCategorias"
        Me.btnCategorias.Text = "Categorías"
        Me.btnCategorias.Size = New System.Drawing.Size(170, 43)
        Me.btnCategorias.AutoSize = False
        Me.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategorias.FlatAppearance.BorderSize = 0
        Me.btnCategorias.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnCategorias.BackColor = System.Drawing.Color.FromArgb(244, 246, 253)
        Me.btnCategorias.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnCategorias.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCategorias.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCategorias.Margin = New System.Windows.Forms.Padding(0, 0, 0, 7)
        Me.btnCategorias.UseVisualStyleBackColor = False
        Me.btnCategorias.Tag = "categorias"
        Me.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCategorias.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.flpMenu.Controls.Add(Me.btnCategorias)
        Me.btnPenalizaciones.Name = "btnPenalizaciones"
        Me.btnPenalizaciones.Text = "Penalizaciones"
        Me.btnPenalizaciones.Size = New System.Drawing.Size(170, 43)
        Me.btnPenalizaciones.AutoSize = False
        Me.btnPenalizaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPenalizaciones.FlatAppearance.BorderSize = 0
        Me.btnPenalizaciones.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnPenalizaciones.BackColor = System.Drawing.Color.FromArgb(244, 246, 253)
        Me.btnPenalizaciones.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnPenalizaciones.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPenalizaciones.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPenalizaciones.Margin = New System.Windows.Forms.Padding(0, 0, 0, 7)
        Me.btnPenalizaciones.UseVisualStyleBackColor = False
        Me.btnPenalizaciones.Tag = "penalizaciones"
        Me.btnPenalizaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPenalizaciones.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.flpMenu.Controls.Add(Me.btnPenalizaciones)
        Me.lblAyudaMenu.Name = "lblAyudaMenu"
        Me.lblAyudaMenu.Text = "Cada préstamo corresponde a una copia física."
        Me.lblAyudaMenu.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblAyudaMenu.AutoSize = False
        Me.lblAyudaMenu.Size = New System.Drawing.Size(170, 74)
        Me.lblAyudaMenu.Margin = New System.Windows.Forms.Padding(8, 28, 0, 8)
        Me.flpMenu.Controls.Add(Me.lblAyudaMenu)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Cerrar sesión"
        Me.btnSalir.Size = New System.Drawing.Size(170, 38)
        Me.btnSalir.AutoSize = False
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.FlatAppearance.BorderSize = 1
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSalir.UseVisualStyleBackColor = False
        Me.flpMenu.Controls.Add(Me.btnSalir)
        Me.pnlSide.Controls.Add(Me.flpMenu)
        Me.layoutPrincipal.Controls.Add(Me.pnlSide, 0, 1)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(249, 250, 254)
        Me.panelDashboard.Name = "panelDashboard"
        Me.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelDashboard.AutoScroll = True
        Me.layoutDashboard.Name = "layoutDashboard"
        Me.layoutDashboard.Dock = System.Windows.Forms.DockStyle.Top
        Me.layoutDashboard.RowCount = 8
        Me.layoutDashboard.ColumnCount = 1
        Me.layoutDashboard.Margin = New System.Windows.Forms.Padding(0)
        Me.layoutDashboard.AutoSize = True
        Me.layoutDashboard.Padding = New System.Windows.Forms.Padding(22, 16, 22, 16)
        Me.layoutDashboard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.layoutDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76!))
        Me.layoutDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.layoutDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.layoutDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140!))
        Me.layoutDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42!))
        Me.layoutDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 236!))
        Me.layoutDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 228!))
        Me.layoutDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38!))
        Me.encabezado.Name = "encabezado"
        Me.encabezado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.encabezado.RowCount = 1
        Me.encabezado.ColumnCount = 2
        Me.encabezado.Margin = New System.Windows.Forms.Padding(0)
        Me.encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72!))
        Me.encabezado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.encabezado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80!))
        Me.imagenModulo.Name = "imagenModulo"
        Me.imagenModulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imagenModulo.Image = Global.capaInterfaz.My.Resources.Resources.no
        Me.imagenModulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imagenModulo.Margin = New System.Windows.Forms.Padding(0, 0, 16, 10)
        Me.imagenModulo.TabStop = False
        Me.imagenModulo.AccessibleName = "Lecturae, biblioteca y comunidad"
        Me.textoEncabezado.Name = "textoEncabezado"
        Me.textoEncabezado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTituloVista.Name = "lblTituloVista"
        Me.lblTituloVista.Text = "Panel de biblioteca"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Actividad, disponibilidad y accesos para la gestión diaria."
        Me.lblDescripcionVista.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblDescripcionVista.AutoSize = False
        Me.lblDescripcionVista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textoEncabezado.Controls.Add(Me.lblDescripcionVista)
        Me.textoEncabezado.Controls.Add(Me.lblTituloVista)
        Me.encabezado.Controls.Add(Me.imagenModulo, 0, 0)
        Me.encabezado.Controls.Add(Me.textoEncabezado, 1, 0)
        Me.layoutDashboard.Controls.Add(Me.encabezado, 0, 0)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFiltros.AutoSize = True
        Me.pnlFiltros.WrapContents = True
        Me.dtDesde.Name = "dtDesde"
        Me.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.bloque_dtDesde.Name = "bloque_dtDesde"
        Me.bloque_dtDesde.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_dtDesde.Size = New System.Drawing.Size(140, 58)
        Me.bloque_dtDesde.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_dtDesde.Name = "etiqueta_dtDesde"
        Me.etiqueta_dtDesde.Text = "Préstamos desde"
        Me.etiqueta_dtDesde.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_dtDesde.AutoSize = False
        Me.etiqueta_dtDesde.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_dtDesde.Height = 24
        Me.etiqueta_dtDesde.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dtDesde.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtDesde.Height = 30
        Me.bloque_dtDesde.Controls.Add(Me.dtDesde)
        Me.bloque_dtDesde.Controls.Add(Me.etiqueta_dtDesde)
        Me.pnlFiltros.Controls.Add(Me.bloque_dtDesde)
        Me.dtHasta.Name = "dtHasta"
        Me.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.bloque_dtHasta.Name = "bloque_dtHasta"
        Me.bloque_dtHasta.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_dtHasta.Size = New System.Drawing.Size(140, 58)
        Me.bloque_dtHasta.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_dtHasta.Name = "etiqueta_dtHasta"
        Me.etiqueta_dtHasta.Text = "Hasta"
        Me.etiqueta_dtHasta.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_dtHasta.AutoSize = False
        Me.etiqueta_dtHasta.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_dtHasta.Height = 24
        Me.etiqueta_dtHasta.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dtHasta.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtHasta.Height = 30
        Me.bloque_dtHasta.Controls.Add(Me.dtHasta)
        Me.bloque_dtHasta.Controls.Add(Me.etiqueta_dtHasta)
        Me.pnlFiltros.Controls.Add(Me.bloque_dtHasta)
        Me.cboCat.Name = "cboCat"
        Me.cboCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.bloque_cboCat.Name = "bloque_cboCat"
        Me.bloque_cboCat.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_cboCat.Size = New System.Drawing.Size(195, 58)
        Me.bloque_cboCat.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_cboCat.Name = "etiqueta_cboCat"
        Me.etiqueta_cboCat.Text = "Categoría"
        Me.etiqueta_cboCat.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_cboCat.AutoSize = False
        Me.etiqueta_cboCat.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_cboCat.Height = 24
        Me.etiqueta_cboCat.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.cboCat.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboCat.Height = 30
        Me.bloque_cboCat.Controls.Add(Me.cboCat)
        Me.bloque_cboCat.Controls.Add(Me.etiqueta_cboCat)
        Me.pnlFiltros.Controls.Add(Me.bloque_cboCat)
        Me.cboEst.Name = "cboEst"
        Me.cboEst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEst.Items.AddRange(New Object() {"Todos", "Activos", "Vencidos", "Devueltos"})
        Me.bloque_cboEst.Name = "bloque_cboEst"
        Me.bloque_cboEst.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_cboEst.Size = New System.Drawing.Size(120, 58)
        Me.bloque_cboEst.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_cboEst.Name = "etiqueta_cboEst"
        Me.etiqueta_cboEst.Text = "Estado"
        Me.etiqueta_cboEst.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_cboEst.AutoSize = False
        Me.etiqueta_cboEst.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_cboEst.Height = 24
        Me.etiqueta_cboEst.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.cboEst.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboEst.Height = 30
        Me.bloque_cboEst.Controls.Add(Me.cboEst)
        Me.bloque_cboEst.Controls.Add(Me.etiqueta_cboEst)
        Me.pnlFiltros.Controls.Add(Me.bloque_cboEst)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Text = "Actualizar"
        Me.btnAplicar.Size = New System.Drawing.Size(115, 35)
        Me.btnAplicar.AutoSize = False
        Me.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicar.FlatAppearance.BorderSize = 0
        Me.btnAplicar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnAplicar.BackColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnAplicar.ForeColor = System.Drawing.Color.White
        Me.btnAplicar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAplicar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAplicar.Margin = New System.Windows.Forms.Padding(0, 24, 8, 6)
        Me.btnAplicar.UseVisualStyleBackColor = False
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(92, 35)
        Me.btnLimpiar.AutoSize = False
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.FlatAppearance.BorderSize = 1
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnLimpiar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(0, 24, 0, 6)
        Me.btnLimpiar.UseVisualStyleBackColor = False
        Me.pnlFiltros.Controls.Add(Me.btnAplicar)
        Me.pnlFiltros.Controls.Add(Me.btnLimpiar)
        Me.layoutDashboard.Controls.Add(Me.pnlFiltros, 0, 1)
        Me.accesosRapidos.Name = "accesosRapidos"
        Me.accesosRapidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.accesosRapidos.AutoSize = True
        Me.accesosRapidos.WrapContents = True
        Me.accesosRapidos.Padding = New System.Windows.Forms.Padding(0, 6, 0, 10)
        Me.btnNuevoRapido.Name = "btnNuevoRapido"
        Me.btnNuevoRapido.Text = "Nuevo préstamo"
        Me.btnNuevoRapido.Size = New System.Drawing.Size(170, 38)
        Me.btnNuevoRapido.AutoSize = False
        Me.btnNuevoRapido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevoRapido.FlatAppearance.BorderSize = 0
        Me.btnNuevoRapido.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnNuevoRapido.BackColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnNuevoRapido.ForeColor = System.Drawing.Color.White
        Me.btnNuevoRapido.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNuevoRapido.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevoRapido.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnNuevoRapido.UseVisualStyleBackColor = False
        Me.btnNuevoRapido.Width = 172
        Me.accesosRapidos.Controls.Add(Me.btnNuevoRapido)
        Me.btnDevolverRapido.Name = "btnDevolverRapido"
        Me.btnDevolverRapido.Text = "Registrar devolución"
        Me.btnDevolverRapido.Size = New System.Drawing.Size(170, 38)
        Me.btnDevolverRapido.AutoSize = False
        Me.btnDevolverRapido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDevolverRapido.FlatAppearance.BorderSize = 1
        Me.btnDevolverRapido.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnDevolverRapido.BackColor = System.Drawing.Color.White
        Me.btnDevolverRapido.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnDevolverRapido.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDevolverRapido.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDevolverRapido.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnDevolverRapido.UseVisualStyleBackColor = False
        Me.btnDevolverRapido.Width = 195
        Me.accesosRapidos.Controls.Add(Me.btnDevolverRapido)
        Me.btnLectorRapido.Name = "btnLectorRapido"
        Me.btnLectorRapido.Text = "Buscar lector"
        Me.btnLectorRapido.Size = New System.Drawing.Size(170, 38)
        Me.btnLectorRapido.AutoSize = False
        Me.btnLectorRapido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLectorRapido.FlatAppearance.BorderSize = 1
        Me.btnLectorRapido.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnLectorRapido.BackColor = System.Drawing.Color.White
        Me.btnLectorRapido.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnLectorRapido.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLectorRapido.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLectorRapido.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnLectorRapido.UseVisualStyleBackColor = False
        Me.btnLectorRapido.Width = 172
        Me.accesosRapidos.Controls.Add(Me.btnLectorRapido)
        Me.btnCatalogoRapido.Name = "btnCatalogoRapido"
        Me.btnCatalogoRapido.Text = "Consultar libros"
        Me.btnCatalogoRapido.Size = New System.Drawing.Size(170, 38)
        Me.btnCatalogoRapido.AutoSize = False
        Me.btnCatalogoRapido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCatalogoRapido.FlatAppearance.BorderSize = 1
        Me.btnCatalogoRapido.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnCatalogoRapido.BackColor = System.Drawing.Color.White
        Me.btnCatalogoRapido.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnCatalogoRapido.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCatalogoRapido.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCatalogoRapido.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnCatalogoRapido.UseVisualStyleBackColor = False
        Me.btnCatalogoRapido.Width = 172
        Me.accesosRapidos.Controls.Add(Me.btnCatalogoRapido)
        Me.layoutDashboard.Controls.Add(Me.accesosRapidos, 0, 2)
        Me.tlpStats.Name = "tlpStats"
        Me.tlpStats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpStats.RowCount = 1
        Me.tlpStats.ColumnCount = 4
        Me.tlpStats.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.tlpStats.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140!))
        Me.cardStat0.Name = "cardStat0"
        Me.cardStat0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardStat0.BackColor = System.Drawing.Color.White
        Me.cardStat0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardStat0.Padding = New System.Windows.Forms.Padding(14, 10, 10, 8)
        Me.cardStat0.Margin = New System.Windows.Forms.Padding(0, 0, 12, 0)
        Me.cardStat0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCap0.Name = "lblCap0"
        Me.lblCap0.Text = "Activos en selección"
        Me.lblCap0.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblCap0.AutoSize = False
        Me.lblCap0.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCap0.Height = 28
        Me.lblCap0.AutoEllipsis = True
        Me.lblNum0.Name = "lblNum0"
        Me.lblNum0.Text = "—"
        Me.lblNum0.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.lblNum0.AutoSize = False
        Me.lblNum0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNum0.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblNota0.Name = "lblNota0"
        Me.lblNota0.Text = "Préstamos iniciados en el periodo"
        Me.lblNota0.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblNota0.AutoSize = False
        Me.lblNota0.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblNota0.Height = 23
        Me.lblNota0.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblNota0.AutoEllipsis = True
        Me.cardStat0.Controls.Add(Me.lblNum0)
        Me.cardStat0.Controls.Add(Me.lblCap0)
        Me.cardStat0.Controls.Add(Me.lblNota0)
        Me.tlpStats.Controls.Add(Me.cardStat0, 0, 0)
        Me.cardStat1.Name = "cardStat1"
        Me.cardStat1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardStat1.BackColor = System.Drawing.Color.White
        Me.cardStat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardStat1.Padding = New System.Windows.Forms.Padding(14, 10, 10, 8)
        Me.cardStat1.Margin = New System.Windows.Forms.Padding(0, 0, 12, 0)
        Me.cardStat1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCap1.Name = "lblCap1"
        Me.lblCap1.Text = "Vencidos en selección"
        Me.lblCap1.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblCap1.AutoSize = False
        Me.lblCap1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCap1.Height = 28
        Me.lblCap1.AutoEllipsis = True
        Me.lblNum1.Name = "lblNum1"
        Me.lblNum1.Text = "—"
        Me.lblNum1.ForeColor = System.Drawing.Color.FromArgb(188, 76, 49)
        Me.lblNum1.AutoSize = False
        Me.lblNum1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNum1.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblNota1.Name = "lblNota1"
        Me.lblNota1.Text = "Préstamos iniciados en el periodo"
        Me.lblNota1.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblNota1.AutoSize = False
        Me.lblNota1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblNota1.Height = 23
        Me.lblNota1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblNota1.AutoEllipsis = True
        Me.cardStat1.Controls.Add(Me.lblNum1)
        Me.cardStat1.Controls.Add(Me.lblCap1)
        Me.cardStat1.Controls.Add(Me.lblNota1)
        Me.tlpStats.Controls.Add(Me.cardStat1, 1, 0)
        Me.cardStat2.Name = "cardStat2"
        Me.cardStat2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardStat2.BackColor = System.Drawing.Color.White
        Me.cardStat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardStat2.Padding = New System.Windows.Forms.Padding(14, 10, 10, 8)
        Me.cardStat2.Margin = New System.Windows.Forms.Padding(0, 0, 12, 0)
        Me.cardStat2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCap2.Name = "lblCap2"
        Me.lblCap2.Text = "Devueltos en selección"
        Me.lblCap2.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblCap2.AutoSize = False
        Me.lblCap2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCap2.Height = 28
        Me.lblCap2.AutoEllipsis = True
        Me.lblNum2.Name = "lblNum2"
        Me.lblNum2.Text = "—"
        Me.lblNum2.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.lblNum2.AutoSize = False
        Me.lblNum2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNum2.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblNota2.Name = "lblNota2"
        Me.lblNota2.Text = "Préstamos iniciados en el periodo"
        Me.lblNota2.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblNota2.AutoSize = False
        Me.lblNota2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblNota2.Height = 23
        Me.lblNota2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblNota2.AutoEllipsis = True
        Me.cardStat2.Controls.Add(Me.lblNum2)
        Me.cardStat2.Controls.Add(Me.lblCap2)
        Me.cardStat2.Controls.Add(Me.lblNota2)
        Me.tlpStats.Controls.Add(Me.cardStat2, 2, 0)
        Me.cardStat3.Name = "cardStat3"
        Me.cardStat3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardStat3.BackColor = System.Drawing.Color.White
        Me.cardStat3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardStat3.Padding = New System.Windows.Forms.Padding(14, 10, 10, 8)
        Me.cardStat3.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.cardStat3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCap3.Name = "lblCap3"
        Me.lblCap3.Text = "Ejemplares disponibles"
        Me.lblCap3.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblCap3.AutoSize = False
        Me.lblCap3.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCap3.Height = 28
        Me.lblCap3.AutoEllipsis = True
        Me.lblNum3.Name = "lblNum3"
        Me.lblNum3.Text = "—"
        Me.lblNum3.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.lblNum3.AutoSize = False
        Me.lblNum3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNum3.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblNota3.Name = "lblNota3"
        Me.lblNota3.Text = "Ahora · categoría elegida"
        Me.lblNota3.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblNota3.AutoSize = False
        Me.lblNota3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblNota3.Height = 23
        Me.lblNota3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblNota3.AutoEllipsis = True
        Me.cardStat3.Controls.Add(Me.lblNum3)
        Me.cardStat3.Controls.Add(Me.lblCap3)
        Me.cardStat3.Controls.Add(Me.lblNota3)
        Me.tlpStats.Controls.Add(Me.cardStat3, 3, 0)
        Me.layoutDashboard.Controls.Add(Me.tlpStats, 0, 3)
        Me.lblActualidad.Name = "lblActualidad"
        Me.lblActualidad.Text = "La información se cargará al abrir la aplicación."
        Me.lblActualidad.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblActualidad.AutoSize = False
        Me.lblActualidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblActualidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblActualidad.AutoEllipsis = True
        Me.layoutDashboard.Controls.Add(Me.lblActualidad, 0, 4)
        Me.tlpGraficos.Name = "tlpGraficos"
        Me.tlpGraficos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpGraficos.RowCount = 1
        Me.tlpGraficos.ColumnCount = 2
        Me.tlpGraficos.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpGraficos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60!))
        Me.tlpGraficos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40!))
        Me.tlpGraficos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 236!))
        Me.cardBarras.Name = "cardBarras"
        Me.cardBarras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardBarras.BackColor = System.Drawing.Color.White
        Me.cardBarras.Padding = New System.Windows.Forms.Padding(14)
        Me.cardBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardBarras.Margin = New System.Windows.Forms.Padding(0, 8, 12, 8)
        Me.titulo_pnlBarras.Name = "titulo_pnlBarras"
        Me.titulo_pnlBarras.Text = "Préstamos por mes de inicio"
        Me.titulo_pnlBarras.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.titulo_pnlBarras.AutoSize = False
        Me.titulo_pnlBarras.Dock = System.Windows.Forms.DockStyle.Top
        Me.titulo_pnlBarras.Height = 32
        Me.titulo_pnlBarras.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.pnlBarras.Name = "pnlBarras"
        Me.pnlBarras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vista_pnlBarras.Name = "vista_pnlBarras"
        Me.vista_pnlBarras.Text = "Vista de diseño · actividad por mes"
        Me.vista_pnlBarras.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.vista_pnlBarras.AutoSize = False
        Me.vista_pnlBarras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vista_pnlBarras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.vista_pnlBarras.BackColor = System.Drawing.Color.FromArgb(247, 249, 254)
        Me.pnlBarras.Controls.Add(Me.vista_pnlBarras)
        Me.cardBarras.Controls.Add(Me.pnlBarras)
        Me.cardBarras.Controls.Add(Me.titulo_pnlBarras)
        Me.tlpGraficos.Controls.Add(Me.cardBarras, 0, 0)
        Me.cardDona.Name = "cardDona"
        Me.cardDona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardDona.BackColor = System.Drawing.Color.White
        Me.cardDona.Padding = New System.Windows.Forms.Padding(14)
        Me.cardDona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardDona.Margin = New System.Windows.Forms.Padding(0, 8, 0, 8)
        Me.titulo_pnlDona.Name = "titulo_pnlDona"
        Me.titulo_pnlDona.Text = "Estado de la selección"
        Me.titulo_pnlDona.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.titulo_pnlDona.AutoSize = False
        Me.titulo_pnlDona.Dock = System.Windows.Forms.DockStyle.Top
        Me.titulo_pnlDona.Height = 32
        Me.titulo_pnlDona.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.pnlDona.Name = "pnlDona"
        Me.pnlDona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vista_pnlDona.Name = "vista_pnlDona"
        Me.vista_pnlDona.Text = "Vista de diseño · distribución por estado"
        Me.vista_pnlDona.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.vista_pnlDona.AutoSize = False
        Me.vista_pnlDona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vista_pnlDona.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.vista_pnlDona.BackColor = System.Drawing.Color.FromArgb(247, 249, 254)
        Me.pnlDona.Controls.Add(Me.vista_pnlDona)
        Me.cardDona.Controls.Add(Me.pnlDona)
        Me.cardDona.Controls.Add(Me.titulo_pnlDona)
        Me.tlpGraficos.Controls.Add(Me.cardDona, 1, 0)
        Me.layoutDashboard.Controls.Add(Me.tlpGraficos, 0, 5)
        Me.tlpDetalle.Name = "tlpDetalle"
        Me.tlpDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDetalle.RowCount = 1
        Me.tlpDetalle.ColumnCount = 2
        Me.tlpDetalle.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpDetalle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58!))
        Me.tlpDetalle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42!))
        Me.tlpDetalle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 228!))
        Me.cardPendientes.Name = "cardPendientes"
        Me.cardPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardPendientes.BackColor = System.Drawing.Color.White
        Me.cardPendientes.Padding = New System.Windows.Forms.Padding(12)
        Me.cardPendientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardPendientes.Margin = New System.Windows.Forms.Padding(0, 6, 12, 0)
        Me.lblPendientes.Name = "lblPendientes"
        Me.lblPendientes.Text = "Próximas devoluciones de la selección"
        Me.lblPendientes.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblPendientes.AutoSize = False
        Me.lblPendientes.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPendientes.Height = 30
        Me.lblPendientes.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.tablaPendientes.Name = "tablaPendientes"
        Me.tablaPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablaPendientes.ReadOnly = True
        Me.tablaPendientes.AllowUserToAddRows = False
        Me.tablaPendientes.AllowUserToDeleteRows = False
        Me.tablaPendientes.MultiSelect = False
        Me.tablaPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tablaPendientes.RowHeadersVisible = False
        Me.tablaPendientes.AutoGenerateColumns = False
        Me.tablaPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tablaPendientes.BackgroundColor = System.Drawing.Color.White
        Me.tablaPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tablaPendientes.GridColor = System.Drawing.Color.FromArgb(231, 235, 246)
        Me.tablaPendientes.EnableHeadersVisualStyles = False
        Me.tablaPendientes.ColumnHeadersHeight = 40
        Me.tablaPendientes.RowTemplate.Height = 36
        Me.tablaPendientes.Margin = New System.Windows.Forms.Padding(0)
        Me.tablaPendientes.AccessibleName = "Tabla de resultados"
        Me.tablaPendientesCabecera.BackColor = System.Drawing.Color.FromArgb(234, 239, 255)
        Me.tablaPendientesCabecera.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.tablaPendientesCabecera.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.tablaPendientesCeldas.SelectionBackColor = System.Drawing.Color.FromArgb(222, 229, 255)
        Me.tablaPendientesCeldas.SelectionForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.tablaPendientesCeldas.NullValue = "—"
        Me.tablaPendientesAlternas.BackColor = System.Drawing.Color.FromArgb(248, 250, 255)
        Me.tablaPendientes.ColumnHeadersDefaultCellStyle = Me.tablaPendientesCabecera
        Me.tablaPendientes.DefaultCellStyle = Me.tablaPendientesCeldas
        Me.tablaPendientes.AlternatingRowsDefaultCellStyle = Me.tablaPendientesAlternas
        Me.colPendienteId.Name = "colPendienteId"
        Me.colPendienteId.HeaderText = "ID"
        Me.colPendienteId.DataPropertyName = "IdPrestamo"
        Me.colPendienteId.Width = 12
        Me.colPendienteId.FillWeight = 12
        Me.colPendienteId.ReadOnly = True
        Me.colPendienteId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPendientes.Columns.Add(Me.colPendienteId)
        Me.colPendienteLector.Name = "colPendienteLector"
        Me.colPendienteLector.HeaderText = "Lector"
        Me.colPendienteLector.DataPropertyName = "Lector"
        Me.colPendienteLector.Width = 44
        Me.colPendienteLector.FillWeight = 44
        Me.colPendienteLector.ReadOnly = True
        Me.colPendienteLector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPendientes.Columns.Add(Me.colPendienteLector)
        Me.colPendienteFin.Name = "colPendienteFin"
        Me.colPendienteFin.HeaderText = "Fecha límite"
        Me.colPendienteFin.DataPropertyName = "FechaLimite"
        Me.colPendienteFin.Width = 25
        Me.colPendienteFin.FillWeight = 25
        Me.colPendienteFin.ReadOnly = True
        Me.colPendienteFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colPendienteFinFormato.Format = "dd/MM/yyyy"
        Me.colPendienteFinFormato.NullValue = "—"
        Me.colPendienteFin.DefaultCellStyle = Me.colPendienteFinFormato
        Me.tablaPendientes.Columns.Add(Me.colPendienteFin)
        Me.colPendienteEstado.Name = "colPendienteEstado"
        Me.colPendienteEstado.HeaderText = "Estado"
        Me.colPendienteEstado.DataPropertyName = "Estado"
        Me.colPendienteEstado.Width = 22
        Me.colPendienteEstado.FillWeight = 22
        Me.colPendienteEstado.ReadOnly = True
        Me.colPendienteEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPendientes.Columns.Add(Me.colPendienteEstado)
        Me.lblSinPendientes.Name = "lblSinPendientes"
        Me.lblSinPendientes.Text = "Sin datos cargados"
        Me.lblSinPendientes.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblSinPendientes.AutoSize = False
        Me.lblSinPendientes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSinPendientes.Height = 24
        Me.cardPendientes.Controls.Add(Me.tablaPendientes)
        Me.cardPendientes.Controls.Add(Me.lblPendientes)
        Me.cardPendientes.Controls.Add(Me.lblSinPendientes)
        Me.tlpDetalle.Controls.Add(Me.cardPendientes, 0, 0)
        Me.cardCategorias.Name = "cardCategorias"
        Me.cardCategorias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cardCategorias.BackColor = System.Drawing.Color.White
        Me.cardCategorias.Padding = New System.Windows.Forms.Padding(12)
        Me.cardCategorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardCategorias.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.lblCategorias.Name = "lblCategorias"
        Me.lblCategorias.Text = "Préstamos por categoría"
        Me.lblCategorias.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblCategorias.AutoSize = False
        Me.lblCategorias.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCategorias.Height = 30
        Me.lblCategorias.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.tablaCategorias.Name = "tablaCategorias"
        Me.tablaCategorias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablaCategorias.ReadOnly = True
        Me.tablaCategorias.AllowUserToAddRows = False
        Me.tablaCategorias.AllowUserToDeleteRows = False
        Me.tablaCategorias.MultiSelect = False
        Me.tablaCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tablaCategorias.RowHeadersVisible = False
        Me.tablaCategorias.AutoGenerateColumns = False
        Me.tablaCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tablaCategorias.BackgroundColor = System.Drawing.Color.White
        Me.tablaCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tablaCategorias.GridColor = System.Drawing.Color.FromArgb(231, 235, 246)
        Me.tablaCategorias.EnableHeadersVisualStyles = False
        Me.tablaCategorias.ColumnHeadersHeight = 40
        Me.tablaCategorias.RowTemplate.Height = 36
        Me.tablaCategorias.Margin = New System.Windows.Forms.Padding(0)
        Me.tablaCategorias.AccessibleName = "Tabla de resultados"
        Me.tablaCategoriasCabecera.BackColor = System.Drawing.Color.FromArgb(234, 239, 255)
        Me.tablaCategoriasCabecera.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.tablaCategoriasCabecera.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.tablaCategoriasCeldas.SelectionBackColor = System.Drawing.Color.FromArgb(222, 229, 255)
        Me.tablaCategoriasCeldas.SelectionForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.tablaCategoriasCeldas.NullValue = "—"
        Me.tablaCategoriasAlternas.BackColor = System.Drawing.Color.FromArgb(248, 250, 255)
        Me.tablaCategorias.ColumnHeadersDefaultCellStyle = Me.tablaCategoriasCabecera
        Me.tablaCategorias.DefaultCellStyle = Me.tablaCategoriasCeldas
        Me.tablaCategorias.AlternatingRowsDefaultCellStyle = Me.tablaCategoriasAlternas
        Me.colCategoria.Name = "colCategoria"
        Me.colCategoria.HeaderText = "Categoría"
        Me.colCategoria.DataPropertyName = "Etiqueta"
        Me.colCategoria.Width = 70
        Me.colCategoria.FillWeight = 70
        Me.colCategoria.ReadOnly = True
        Me.colCategoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaCategorias.Columns.Add(Me.colCategoria)
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.HeaderText = "Préstamos"
        Me.colCantidad.DataPropertyName = "Cantidad"
        Me.colCantidad.Width = 30
        Me.colCantidad.FillWeight = 30
        Me.colCantidad.ReadOnly = True
        Me.colCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaCategorias.Columns.Add(Me.colCantidad)
        Me.lblNotaCategorias.Name = "lblNotaCategorias"
        Me.lblNotaCategorias.Text = "Un préstamo puede pertenecer a varias categorías."
        Me.lblNotaCategorias.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblNotaCategorias.AutoSize = False
        Me.lblNotaCategorias.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblNotaCategorias.Height = 24
        Me.lblNotaCategorias.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblNotaCategorias.AutoEllipsis = True
        Me.cardCategorias.Controls.Add(Me.tablaCategorias)
        Me.cardCategorias.Controls.Add(Me.lblCategorias)
        Me.cardCategorias.Controls.Add(Me.lblNotaCategorias)
        Me.tlpDetalle.Controls.Add(Me.cardCategorias, 1, 0)
        Me.layoutDashboard.Controls.Add(Me.tlpDetalle, 0, 6)
        Me.lblEstadoCarga.Name = "lblEstadoCarga"
        Me.lblEstadoCarga.Text = "Sin datos cargados · Pulsa Actualizar para consultar."
        Me.lblEstadoCarga.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblEstadoCarga.AutoSize = False
        Me.lblEstadoCarga.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEstadoCarga.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstadoCarga.AutoEllipsis = True
        Me.layoutDashboard.Controls.Add(Me.lblEstadoCarga, 0, 7)
        Me.panelDashboard.Controls.Add(Me.layoutDashboard)
        Me.pnlMain.Controls.Add(Me.panelDashboard)
        Me.layoutPrincipal.Controls.Add(Me.pnlMain, 1, 1)
        Me.lblFooter.Name = "lblFooter"
        Me.lblFooter.Text = "Lecturae · Sistema de biblioteca"
        Me.lblFooter.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblFooter.AutoSize = False
        Me.lblFooter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFooter.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.layoutPrincipal.Controls.Add(Me.lblFooter, 0, 2)
        Me.layoutPrincipal.SetColumnSpan(Me.lblFooter, 2)
        Me.Controls.Add(Me.layoutPrincipal)
        Me.MinimumSize = New System.Drawing.Size(1000, 650)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1280, 850)
        Me.Name = "frmPrincipal"
        Me.Text = "Panel de biblioteca"
        CType(Me.imagenMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imagenUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tablaPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tablaCategorias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardCategorias.ResumeLayout(False)
        Me.cardCategorias.PerformLayout()
        Me.cardPendientes.ResumeLayout(False)
        Me.cardPendientes.PerformLayout()
        Me.tlpDetalle.ResumeLayout(False)
        Me.tlpDetalle.PerformLayout()
        Me.pnlDona.ResumeLayout(False)
        Me.pnlDona.PerformLayout()
        Me.cardDona.ResumeLayout(False)
        Me.cardDona.PerformLayout()
        Me.pnlBarras.ResumeLayout(False)
        Me.pnlBarras.PerformLayout()
        Me.cardBarras.ResumeLayout(False)
        Me.cardBarras.PerformLayout()
        Me.tlpGraficos.ResumeLayout(False)
        Me.tlpGraficos.PerformLayout()
        Me.cardStat3.ResumeLayout(False)
        Me.cardStat3.PerformLayout()
        Me.cardStat2.ResumeLayout(False)
        Me.cardStat2.PerformLayout()
        Me.cardStat1.ResumeLayout(False)
        Me.cardStat1.PerformLayout()
        Me.cardStat0.ResumeLayout(False)
        Me.cardStat0.PerformLayout()
        Me.tlpStats.ResumeLayout(False)
        Me.tlpStats.PerformLayout()
        Me.accesosRapidos.ResumeLayout(False)
        Me.accesosRapidos.PerformLayout()
        Me.bloque_cboEst.ResumeLayout(False)
        Me.bloque_cboEst.PerformLayout()
        Me.bloque_cboCat.ResumeLayout(False)
        Me.bloque_cboCat.PerformLayout()
        Me.bloque_dtHasta.ResumeLayout(False)
        Me.bloque_dtHasta.PerformLayout()
        Me.bloque_dtDesde.ResumeLayout(False)
        Me.bloque_dtDesde.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.textoEncabezado.ResumeLayout(False)
        Me.textoEncabezado.PerformLayout()
        Me.encabezado.ResumeLayout(False)
        Me.encabezado.PerformLayout()
        Me.layoutDashboard.ResumeLayout(False)
        Me.layoutDashboard.PerformLayout()
        Me.panelDashboard.ResumeLayout(False)
        Me.panelDashboard.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.flpMenu.ResumeLayout(False)
        Me.flpMenu.PerformLayout()
        Me.pnlSide.ResumeLayout(False)
        Me.pnlSide.PerformLayout()
        Me.pnlSesion.ResumeLayout(False)
        Me.pnlSesion.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.layoutPrincipal.ResumeLayout(False)
        Me.layoutPrincipal.PerformLayout()
        Me.ResumeLayout(False)
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
End Class
