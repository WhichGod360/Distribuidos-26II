<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBuscarLector
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
        Me.encabezado = New System.Windows.Forms.TableLayoutPanel()
        Me.imagenModulo = New System.Windows.Forms.PictureBox()
        Me.textoEncabezado = New System.Windows.Forms.Panel()
        Me.lblTituloVista = New System.Windows.Forms.Label()
        Me.lblDescripcionVista = New System.Windows.Forms.Label()
        Me.layoutLectores = New System.Windows.Forms.TableLayoutPanel()
        Me.barraBusqueda = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.bloque_txtBuscar = New System.Windows.Forms.Panel()
        Me.etiqueta_txtBuscar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.tablaLectores = New System.Windows.Forms.DataGridView()
        Me.colLectorId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLectorNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLectorDni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLectorCorreo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.accionesLector = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnVerPrestamos = New System.Windows.Forms.Button()
        Me.btnDevolver = New System.Windows.Forms.Button()
        Me.lblLector = New System.Windows.Forms.Label()
        Me.tablaPrestamos = New System.Windows.Forms.DataGridView()
        Me.colPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEjemplar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLibro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRetorno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBibliotecario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblResumen = New System.Windows.Forms.Label()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tablaLectores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tablaPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutLectores.SuspendLayout()
        Me.barraBusqueda.SuspendLayout()
        Me.bloque_txtBuscar.SuspendLayout()
        Me.accionesLector.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lblTituloVista.Text = "Buscar lectores"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Estudiantes activos y su historial de préstamos."
        Me.lblDescripcionVista.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblDescripcionVista.AutoSize = False
        Me.lblDescripcionVista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textoEncabezado.Controls.Add(Me.lblDescripcionVista)
        Me.textoEncabezado.Controls.Add(Me.lblTituloVista)
        Me.encabezado.Controls.Add(Me.imagenModulo, 0, 0)
        Me.encabezado.Controls.Add(Me.textoEncabezado, 1, 0)
        Me.imagenModulo.Image = Global.capaInterfaz.My.Resources.Resources.usuario
        Me.layoutLectores.Name = "layoutLectores"
        Me.layoutLectores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutLectores.RowCount = 7
        Me.layoutLectores.ColumnCount = 1
        Me.layoutLectores.Margin = New System.Windows.Forms.Padding(0)
        Me.layoutLectores.Padding = New System.Windows.Forms.Padding(24, 18, 24, 12)
        Me.layoutLectores.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.layoutLectores.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84!))
        Me.layoutLectores.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.layoutLectores.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200!))
        Me.layoutLectores.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.layoutLectores.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40!))
        Me.layoutLectores.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.layoutLectores.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32!))
        Me.barraBusqueda.Name = "barraBusqueda"
        Me.barraBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barraBusqueda.AutoSize = True
        Me.barraBusqueda.WrapContents = True
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.PlaceholderText = "Escribe los datos del lector"
        Me.txtBuscar.MaxLength = 300
        Me.bloque_txtBuscar.Name = "bloque_txtBuscar"
        Me.bloque_txtBuscar.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_txtBuscar.Size = New System.Drawing.Size(390, 58)
        Me.bloque_txtBuscar.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_txtBuscar.Name = "etiqueta_txtBuscar"
        Me.etiqueta_txtBuscar.Text = "Nombre, apellido, DNI o correo"
        Me.etiqueta_txtBuscar.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_txtBuscar.AutoSize = False
        Me.etiqueta_txtBuscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_txtBuscar.Height = 24
        Me.etiqueta_txtBuscar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtBuscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtBuscar.Height = 30
        Me.bloque_txtBuscar.Controls.Add(Me.txtBuscar)
        Me.bloque_txtBuscar.Controls.Add(Me.etiqueta_txtBuscar)
        Me.barraBusqueda.Controls.Add(Me.bloque_txtBuscar)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Size = New System.Drawing.Size(170, 38)
        Me.btnBuscar.AutoSize = False
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnBuscar.ForeColor = System.Drawing.Color.White
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(0, 24, 8, 0)
        Me.btnBuscar.UseVisualStyleBackColor = False
        Me.btnBuscar.Width = 130
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(170, 38)
        Me.btnLimpiar.AutoSize = False
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.FlatAppearance.BorderSize = 1
        Me.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnLimpiar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(0, 24, 0, 0)
        Me.btnLimpiar.UseVisualStyleBackColor = False
        Me.btnLimpiar.Width = 110
        Me.barraBusqueda.Controls.Add(Me.btnBuscar)
        Me.barraBusqueda.Controls.Add(Me.btnLimpiar)
        Me.tablaLectores.Name = "tablaLectores"
        Me.tablaLectores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablaLectores.ReadOnly = True
        Me.tablaLectores.AllowUserToAddRows = False
        Me.tablaLectores.AllowUserToDeleteRows = False
        Me.tablaLectores.MultiSelect = False
        Me.tablaLectores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tablaLectores.RowHeadersVisible = False
        Me.tablaLectores.AutoGenerateColumns = False
        Me.tablaLectores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tablaLectores.BackgroundColor = System.Drawing.Color.White
        Me.tablaLectores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tablaLectores.GridColor = System.Drawing.Color.FromArgb(231, 235, 246)
        Me.tablaLectores.EnableHeadersVisualStyles = False
        Me.tablaLectores.ColumnHeadersHeight = 40
        Me.tablaLectores.RowTemplate.Height = 36
        Me.tablaLectores.Margin = New System.Windows.Forms.Padding(0)
        Me.tablaLectores.AccessibleName = "Tabla de resultados"
        Me.tablaLectores.ColumnHeadersDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(234, 239, 255), .ForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)}
        Me.tablaLectores.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.SelectionBackColor = System.Drawing.Color.FromArgb(222, 229, 255), .SelectionForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .NullValue = "—"}
        Me.tablaLectores.AlternatingRowsDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(248, 250, 255)}
        Me.colLectorId.Name = "colLectorId"
        Me.colLectorId.HeaderText = "ID"
        Me.colLectorId.DataPropertyName = "IdUsuario"
        Me.colLectorId.Width = 10
        Me.colLectorId.FillWeight = 10
        Me.colLectorId.ReadOnly = True
        Me.colLectorId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaLectores.Columns.Add(Me.colLectorId)
        Me.colLectorNombre.Name = "colLectorNombre"
        Me.colLectorNombre.HeaderText = "Nombre completo"
        Me.colLectorNombre.DataPropertyName = "NombreCompleto"
        Me.colLectorNombre.Width = 36
        Me.colLectorNombre.FillWeight = 36
        Me.colLectorNombre.ReadOnly = True
        Me.colLectorNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaLectores.Columns.Add(Me.colLectorNombre)
        Me.colLectorDni.Name = "colLectorDni"
        Me.colLectorDni.HeaderText = "DNI"
        Me.colLectorDni.DataPropertyName = "NumeroDniUsuario"
        Me.colLectorDni.Width = 15
        Me.colLectorDni.FillWeight = 15
        Me.colLectorDni.ReadOnly = True
        Me.colLectorDni.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaLectores.Columns.Add(Me.colLectorDni)
        Me.colLectorCorreo.Name = "colLectorCorreo"
        Me.colLectorCorreo.HeaderText = "Correo"
        Me.colLectorCorreo.DataPropertyName = "EmailUsuario"
        Me.colLectorCorreo.Width = 39
        Me.colLectorCorreo.FillWeight = 39
        Me.colLectorCorreo.ReadOnly = True
        Me.colLectorCorreo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaLectores.Columns.Add(Me.colLectorCorreo)
        Me.accionesLector.Name = "accionesLector"
        Me.accionesLector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.accionesLector.AutoSize = True
        Me.accionesLector.WrapContents = True
        Me.accionesLector.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Text = "Nuevo préstamo"
        Me.btnNuevo.Size = New System.Drawing.Size(170, 38)
        Me.btnNuevo.AutoSize = False
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.FlatAppearance.BorderSize = 0
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnNuevo.ForeColor = System.Drawing.Color.White
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnNuevo.UseVisualStyleBackColor = False
        Me.btnNuevo.Enabled = False
        Me.btnVerPrestamos.Name = "btnVerPrestamos"
        Me.btnVerPrestamos.Text = "Ver en préstamos"
        Me.btnVerPrestamos.Size = New System.Drawing.Size(170, 38)
        Me.btnVerPrestamos.AutoSize = False
        Me.btnVerPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerPrestamos.FlatAppearance.BorderSize = 1
        Me.btnVerPrestamos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnVerPrestamos.BackColor = System.Drawing.Color.White
        Me.btnVerPrestamos.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnVerPrestamos.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnVerPrestamos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerPrestamos.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnVerPrestamos.UseVisualStyleBackColor = False
        Me.btnVerPrestamos.Enabled = False
        Me.btnDevolver.Name = "btnDevolver"
        Me.btnDevolver.Text = "Registrar devolución"
        Me.btnDevolver.Size = New System.Drawing.Size(170, 38)
        Me.btnDevolver.AutoSize = False
        Me.btnDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDevolver.FlatAppearance.BorderSize = 1
        Me.btnDevolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnDevolver.BackColor = System.Drawing.Color.White
        Me.btnDevolver.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnDevolver.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDevolver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDevolver.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnDevolver.UseVisualStyleBackColor = False
        Me.btnDevolver.Enabled = False
        Me.btnDevolver.Width = 190
        Me.accionesLector.Controls.Add(Me.btnNuevo)
        Me.accionesLector.Controls.Add(Me.btnVerPrestamos)
        Me.accionesLector.Controls.Add(Me.btnDevolver)
        Me.lblLector.Name = "lblLector"
        Me.lblLector.Text = "Selecciona un lector para consultar su historial."
        Me.lblLector.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblLector.AutoSize = False
        Me.lblLector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLector.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblLector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLector.AutoEllipsis = True
        Me.tablaPrestamos.Name = "tablaPrestamos"
        Me.tablaPrestamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablaPrestamos.ReadOnly = True
        Me.tablaPrestamos.AllowUserToAddRows = False
        Me.tablaPrestamos.AllowUserToDeleteRows = False
        Me.tablaPrestamos.MultiSelect = False
        Me.tablaPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tablaPrestamos.RowHeadersVisible = False
        Me.tablaPrestamos.AutoGenerateColumns = False
        Me.tablaPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.tablaPrestamos.BackgroundColor = System.Drawing.Color.White
        Me.tablaPrestamos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tablaPrestamos.GridColor = System.Drawing.Color.FromArgb(231, 235, 246)
        Me.tablaPrestamos.EnableHeadersVisualStyles = False
        Me.tablaPrestamos.ColumnHeadersHeight = 40
        Me.tablaPrestamos.RowTemplate.Height = 36
        Me.tablaPrestamos.Margin = New System.Windows.Forms.Padding(0)
        Me.tablaPrestamos.AccessibleName = "Tabla de resultados"
        Me.tablaPrestamos.ColumnHeadersDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(234, 239, 255), .ForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)}
        Me.tablaPrestamos.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.SelectionBackColor = System.Drawing.Color.FromArgb(222, 229, 255), .SelectionForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .NullValue = "—"}
        Me.tablaPrestamos.AlternatingRowsDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(248, 250, 255)}
        Me.colPrestamo.Name = "IdPrestamo"
        Me.colPrestamo.HeaderText = "Préstamo"
        Me.colPrestamo.DataPropertyName = "IdPrestamo"
        Me.colPrestamo.Width = 75
        Me.colPrestamo.FillWeight = 75
        Me.colPrestamo.ReadOnly = True
        Me.colPrestamo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPrestamos.Columns.Add(Me.colPrestamo)
        Me.colEjemplar.Name = "IdEjemplar"
        Me.colEjemplar.HeaderText = "Ejemplar"
        Me.colEjemplar.DataPropertyName = "IdEjemplar"
        Me.colEjemplar.Width = 75
        Me.colEjemplar.FillWeight = 75
        Me.colEjemplar.ReadOnly = True
        Me.colEjemplar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPrestamos.Columns.Add(Me.colEjemplar)
        Me.colLibro.Name = "TituloLibro"
        Me.colLibro.HeaderText = "Libro"
        Me.colLibro.DataPropertyName = "TituloLibro"
        Me.colLibro.Width = 200
        Me.colLibro.FillWeight = 200
        Me.colLibro.ReadOnly = True
        Me.colLibro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPrestamos.Columns.Add(Me.colLibro)
        Me.colFin.Name = "FechaFin"
        Me.colFin.HeaderText = "Fecha límite"
        Me.colFin.DataPropertyName = "FechaFin"
        Me.colFin.Width = 100
        Me.colFin.FillWeight = 100
        Me.colFin.ReadOnly = True
        Me.colFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colFin.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.Format = "dd/MM/yyyy", .NullValue = "—"}
        Me.tablaPrestamos.Columns.Add(Me.colFin)
        Me.colEstado.Name = "EstadoPrestamo"
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.DataPropertyName = "EstadoPrestamo"
        Me.colEstado.Width = 95
        Me.colEstado.FillWeight = 95
        Me.colEstado.ReadOnly = True
        Me.colEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPrestamos.Columns.Add(Me.colEstado)
        Me.colRetorno.Name = "FechaRetorno"
        Me.colRetorno.HeaderText = "Devolución"
        Me.colRetorno.DataPropertyName = "FechaRetorno"
        Me.colRetorno.Width = 100
        Me.colRetorno.FillWeight = 100
        Me.colRetorno.ReadOnly = True
        Me.colRetorno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colRetorno.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.Format = "dd/MM/yyyy", .NullValue = "—"}
        Me.tablaPrestamos.Columns.Add(Me.colRetorno)
        Me.colDias.Name = "DiasRetraso"
        Me.colDias.HeaderText = "Días de retraso"
        Me.colDias.DataPropertyName = "DiasRetraso"
        Me.colDias.Width = 90
        Me.colDias.FillWeight = 90
        Me.colDias.ReadOnly = True
        Me.colDias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPrestamos.Columns.Add(Me.colDias)
        Me.colInicio.Name = "FechaInicio"
        Me.colInicio.HeaderText = "Inicio"
        Me.colInicio.DataPropertyName = "FechaInicio"
        Me.colInicio.Width = 100
        Me.colInicio.FillWeight = 100
        Me.colInicio.ReadOnly = True
        Me.colInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colInicio.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.Format = "dd/MM/yyyy", .NullValue = "—"}
        Me.tablaPrestamos.Columns.Add(Me.colInicio)
        Me.colBibliotecario.Name = "NombreBibliotecario"
        Me.colBibliotecario.HeaderText = "Bibliotecario"
        Me.colBibliotecario.DataPropertyName = "NombreBibliotecario"
        Me.colBibliotecario.Width = 210
        Me.colBibliotecario.FillWeight = 210
        Me.colBibliotecario.ReadOnly = True
        Me.colBibliotecario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPrestamos.Columns.Add(Me.colBibliotecario)
        Me.lblResumen.Name = "lblResumen"
        Me.lblResumen.Text = "Ingresa un criterio y pulsa Buscar."
        Me.lblResumen.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblResumen.AutoSize = False
        Me.lblResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblResumen.AutoEllipsis = True
        Me.layoutLectores.Controls.Add(Me.encabezado, 0, 0)
        Me.layoutLectores.Controls.Add(Me.barraBusqueda, 0, 1)
        Me.layoutLectores.Controls.Add(Me.tablaLectores, 0, 2)
        Me.layoutLectores.Controls.Add(Me.accionesLector, 0, 3)
        Me.layoutLectores.Controls.Add(Me.lblLector, 0, 4)
        Me.layoutLectores.Controls.Add(Me.tablaPrestamos, 0, 5)
        Me.layoutLectores.Controls.Add(Me.lblResumen, 0, 6)
        Me.Controls.Add(Me.layoutLectores)
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 760)
        Me.Name = "frmBuscarLector"
        Me.Text = Me.lblTituloVista.Text
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tablaLectores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tablaPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accionesLector.ResumeLayout(False)
        Me.accionesLector.PerformLayout()
        Me.bloque_txtBuscar.ResumeLayout(False)
        Me.bloque_txtBuscar.PerformLayout()
        Me.barraBusqueda.ResumeLayout(False)
        Me.barraBusqueda.PerformLayout()
        Me.layoutLectores.ResumeLayout(False)
        Me.layoutLectores.PerformLayout()
        Me.textoEncabezado.ResumeLayout(False)
        Me.textoEncabezado.PerformLayout()
        Me.encabezado.ResumeLayout(False)
        Me.encabezado.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents encabezado As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents imagenModulo As System.Windows.Forms.PictureBox
    Friend WithEvents textoEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTituloVista As System.Windows.Forms.Label
    Friend WithEvents lblDescripcionVista As System.Windows.Forms.Label
    Friend WithEvents layoutLectores As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents barraBusqueda As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents bloque_txtBuscar As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_txtBuscar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents tablaLectores As System.Windows.Forms.DataGridView
    Friend WithEvents colLectorId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLectorNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLectorDni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLectorCorreo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents accionesLector As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnVerPrestamos As System.Windows.Forms.Button
    Friend WithEvents btnDevolver As System.Windows.Forms.Button
    Friend WithEvents lblLector As System.Windows.Forms.Label
    Friend WithEvents tablaPrestamos As System.Windows.Forms.DataGridView
    Friend WithEvents colPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEjemplar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLibro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRetorno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBibliotecario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblResumen As System.Windows.Forms.Label
End Class
