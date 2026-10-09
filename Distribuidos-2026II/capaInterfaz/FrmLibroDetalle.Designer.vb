<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLibroDetalle
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
        Me.layoutEditor = New System.Windows.Forms.TableLayoutPanel()
        Me.cuerpoEditor = New System.Windows.Forms.Panel()
        Me.camposEditor = New System.Windows.Forms.TableLayoutPanel()
        Me.txtTitulo = New System.Windows.Forms.TextBox()
        Me.bloque_txtTitulo = New System.Windows.Forms.Panel()
        Me.etiqueta_txtTitulo = New System.Windows.Forms.Label()
        Me.txtEditorial = New System.Windows.Forms.TextBox()
        Me.bloque_txtEditorial = New System.Windows.Forms.Panel()
        Me.etiqueta_txtEditorial = New System.Windows.Forms.Label()
        Me.dtpAnio = New System.Windows.Forms.DateTimePicker()
        Me.bloque_dtpAnio = New System.Windows.Forms.Panel()
        Me.etiqueta_dtpAnio = New System.Windows.Forms.Label()
        Me.flpAutores = New System.Windows.Forms.FlowLayoutPanel()
        Me.bloque_flpAutores = New System.Windows.Forms.Panel()
        Me.etiqueta_flpAutores = New System.Windows.Forms.Label()
        Me.flpCategorias = New System.Windows.Forms.FlowLayoutPanel()
        Me.bloque_flpCategorias = New System.Windows.Forms.Panel()
        Me.etiqueta_flpCategorias = New System.Windows.Forms.Label()
        Me.cboPublico = New System.Windows.Forms.ComboBox()
        Me.bloque_cboPublico = New System.Windows.Forms.Panel()
        Me.etiqueta_cboPublico = New System.Windows.Forms.Label()
        Me.nudCantidad = New System.Windows.Forms.NumericUpDown()
        Me.bloque_nudCantidad = New System.Windows.Forms.Panel()
        Me.etiqueta_nudCantidad = New System.Windows.Forms.Label()
        Me.pnlEjemplares = New System.Windows.Forms.Panel()
        Me.bloque_pnlEjemplares = New System.Windows.Forms.Panel()
        Me.etiqueta_pnlEjemplares = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.bloque_chkActivo = New System.Windows.Forms.Panel()
        Me.etiqueta_chkActivo = New System.Windows.Forms.Label()
        Me.accionesEditor = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAddAutor = New System.Windows.Forms.Button()
        Me.btnAddCategoria = New System.Windows.Forms.Button()
        Me.lblEjemplaresInfo = New System.Windows.Forms.Label()
        Me.lnkGestionar = New System.Windows.Forms.LinkLabel()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutEditor.SuspendLayout()
        Me.cuerpoEditor.SuspendLayout()
        Me.camposEditor.SuspendLayout()
        Me.bloque_txtTitulo.SuspendLayout()
        Me.bloque_txtEditorial.SuspendLayout()
        Me.bloque_dtpAnio.SuspendLayout()
        Me.flpAutores.SuspendLayout()
        Me.bloque_flpAutores.SuspendLayout()
        Me.flpCategorias.SuspendLayout()
        Me.bloque_flpCategorias.SuspendLayout()
        Me.bloque_cboPublico.SuspendLayout()
        Me.bloque_nudCantidad.SuspendLayout()
        Me.pnlEjemplares.SuspendLayout()
        Me.bloque_pnlEjemplares.SuspendLayout()
        Me.bloque_chkActivo.SuspendLayout()
        Me.accionesEditor.SuspendLayout()
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
        Me.lblTituloVista.Text = "Agregar libro"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Completa los datos del catálogo y sus relaciones."
        Me.lblDescripcionVista.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblDescripcionVista.AutoSize = False
        Me.lblDescripcionVista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textoEncabezado.Controls.Add(Me.lblDescripcionVista)
        Me.textoEncabezado.Controls.Add(Me.lblTituloVista)
        Me.encabezado.Controls.Add(Me.imagenModulo, 0, 0)
        Me.encabezado.Controls.Add(Me.textoEncabezado, 1, 0)
        Me.layoutEditor.Name = "layoutEditor"
        Me.layoutEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutEditor.RowCount = 3
        Me.layoutEditor.ColumnCount = 1
        Me.layoutEditor.Margin = New System.Windows.Forms.Padding(0)
        Me.layoutEditor.Padding = New System.Windows.Forms.Padding(24, 18, 24, 12)
        Me.layoutEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.layoutEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84!))
        Me.layoutEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.layoutEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58!))
        Me.cuerpoEditor.Name = "cuerpoEditor"
        Me.cuerpoEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cuerpoEditor.AutoScroll = True
        Me.camposEditor.Name = "camposEditor"
        Me.camposEditor.Dock = System.Windows.Forms.DockStyle.Top
        Me.camposEditor.RowCount = 9
        Me.camposEditor.ColumnCount = 1
        Me.camposEditor.Margin = New System.Windows.Forms.Padding(0)
        Me.camposEditor.AutoSize = True
        Me.camposEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.MaxLength = 255
        Me.bloque_txtTitulo.Name = "bloque_txtTitulo"
        Me.bloque_txtTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_txtTitulo.Size = New System.Drawing.Size(550, 58)
        Me.bloque_txtTitulo.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_txtTitulo.Name = "etiqueta_txtTitulo"
        Me.etiqueta_txtTitulo.Text = "Título"
        Me.etiqueta_txtTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_txtTitulo.AutoSize = False
        Me.etiqueta_txtTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_txtTitulo.Height = 24
        Me.etiqueta_txtTitulo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtTitulo.Height = 30
        Me.bloque_txtTitulo.Controls.Add(Me.txtTitulo)
        Me.bloque_txtTitulo.Controls.Add(Me.etiqueta_txtTitulo)
        Me.camposEditor.Controls.Add(Me.bloque_txtTitulo)
        Me.txtEditorial.Name = "txtEditorial"
        Me.txtEditorial.MaxLength = 255
        Me.bloque_txtEditorial.Name = "bloque_txtEditorial"
        Me.bloque_txtEditorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_txtEditorial.Size = New System.Drawing.Size(550, 58)
        Me.bloque_txtEditorial.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_txtEditorial.Name = "etiqueta_txtEditorial"
        Me.etiqueta_txtEditorial.Text = "Editorial"
        Me.etiqueta_txtEditorial.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_txtEditorial.AutoSize = False
        Me.etiqueta_txtEditorial.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_txtEditorial.Height = 24
        Me.etiqueta_txtEditorial.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtEditorial.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtEditorial.Height = 30
        Me.bloque_txtEditorial.Controls.Add(Me.txtEditorial)
        Me.bloque_txtEditorial.Controls.Add(Me.etiqueta_txtEditorial)
        Me.camposEditor.Controls.Add(Me.bloque_txtEditorial)
        Me.dtpAnio.Name = "dtpAnio"
        Me.dtpAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAnio.CustomFormat = "yyyy"
        Me.dtpAnio.ShowUpDown = True
        Me.bloque_dtpAnio.Name = "bloque_dtpAnio"
        Me.bloque_dtpAnio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_dtpAnio.Size = New System.Drawing.Size(550, 58)
        Me.bloque_dtpAnio.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_dtpAnio.Name = "etiqueta_dtpAnio"
        Me.etiqueta_dtpAnio.Text = "Año de publicación"
        Me.etiqueta_dtpAnio.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_dtpAnio.AutoSize = False
        Me.etiqueta_dtpAnio.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_dtpAnio.Height = 24
        Me.etiqueta_dtpAnio.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.dtpAnio.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpAnio.Height = 30
        Me.bloque_dtpAnio.Controls.Add(Me.dtpAnio)
        Me.bloque_dtpAnio.Controls.Add(Me.etiqueta_dtpAnio)
        Me.camposEditor.Controls.Add(Me.bloque_dtpAnio)
        Me.flpAutores.Name = "flpAutores"
        Me.flpAutores.AutoScroll = True
        Me.bloque_flpAutores.Name = "bloque_flpAutores"
        Me.bloque_flpAutores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_flpAutores.Size = New System.Drawing.Size(550, 88)
        Me.bloque_flpAutores.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_flpAutores.Name = "etiqueta_flpAutores"
        Me.etiqueta_flpAutores.Text = "Autores"
        Me.etiqueta_flpAutores.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_flpAutores.AutoSize = False
        Me.etiqueta_flpAutores.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_flpAutores.Height = 24
        Me.etiqueta_flpAutores.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.flpAutores.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpAutores.Height = 60
        Me.bloque_flpAutores.Controls.Add(Me.flpAutores)
        Me.bloque_flpAutores.Controls.Add(Me.etiqueta_flpAutores)
        Me.camposEditor.Controls.Add(Me.bloque_flpAutores)
        Me.flpCategorias.Name = "flpCategorias"
        Me.flpCategorias.AutoScroll = True
        Me.bloque_flpCategorias.Name = "bloque_flpCategorias"
        Me.bloque_flpCategorias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_flpCategorias.Size = New System.Drawing.Size(550, 88)
        Me.bloque_flpCategorias.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_flpCategorias.Name = "etiqueta_flpCategorias"
        Me.etiqueta_flpCategorias.Text = "Categorías"
        Me.etiqueta_flpCategorias.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_flpCategorias.AutoSize = False
        Me.etiqueta_flpCategorias.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_flpCategorias.Height = 24
        Me.etiqueta_flpCategorias.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.flpCategorias.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpCategorias.Height = 60
        Me.bloque_flpCategorias.Controls.Add(Me.flpCategorias)
        Me.bloque_flpCategorias.Controls.Add(Me.etiqueta_flpCategorias)
        Me.camposEditor.Controls.Add(Me.bloque_flpCategorias)
        Me.cboPublico.Name = "cboPublico"
        Me.cboPublico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPublico.Items.AddRange(New Object() {"General", "Universitario", "Infantil", "Juvenil"})
        Me.bloque_cboPublico.Name = "bloque_cboPublico"
        Me.bloque_cboPublico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_cboPublico.Size = New System.Drawing.Size(550, 58)
        Me.bloque_cboPublico.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_cboPublico.Name = "etiqueta_cboPublico"
        Me.etiqueta_cboPublico.Text = "Público objetivo"
        Me.etiqueta_cboPublico.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_cboPublico.AutoSize = False
        Me.etiqueta_cboPublico.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_cboPublico.Height = 24
        Me.etiqueta_cboPublico.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.cboPublico.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboPublico.Height = 30
        Me.bloque_cboPublico.Controls.Add(Me.cboPublico)
        Me.bloque_cboPublico.Controls.Add(Me.etiqueta_cboPublico)
        Me.camposEditor.Controls.Add(Me.bloque_cboPublico)
        Me.nudCantidad.Name = "nudCantidad"
        Me.nudCantidad.Maximum = 500D
        Me.nudCantidad.Minimum = 0D
        Me.bloque_nudCantidad.Name = "bloque_nudCantidad"
        Me.bloque_nudCantidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_nudCantidad.Size = New System.Drawing.Size(550, 58)
        Me.bloque_nudCantidad.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_nudCantidad.Name = "etiqueta_nudCantidad"
        Me.etiqueta_nudCantidad.Text = "Cantidad inicial de ejemplares"
        Me.etiqueta_nudCantidad.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_nudCantidad.AutoSize = False
        Me.etiqueta_nudCantidad.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_nudCantidad.Height = 24
        Me.etiqueta_nudCantidad.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.nudCantidad.Dock = System.Windows.Forms.DockStyle.Top
        Me.nudCantidad.Height = 30
        Me.bloque_nudCantidad.Controls.Add(Me.nudCantidad)
        Me.bloque_nudCantidad.Controls.Add(Me.etiqueta_nudCantidad)
        Me.camposEditor.Controls.Add(Me.bloque_nudCantidad)
        Me.pnlEjemplares.Name = "pnlEjemplares"
        Me.bloque_pnlEjemplares.Name = "bloque_pnlEjemplares"
        Me.bloque_pnlEjemplares.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_pnlEjemplares.Size = New System.Drawing.Size(550, 58)
        Me.bloque_pnlEjemplares.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_pnlEjemplares.Name = "etiqueta_pnlEjemplares"
        Me.etiqueta_pnlEjemplares.Text = "Ejemplares del libro"
        Me.etiqueta_pnlEjemplares.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_pnlEjemplares.AutoSize = False
        Me.etiqueta_pnlEjemplares.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_pnlEjemplares.Height = 24
        Me.etiqueta_pnlEjemplares.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.pnlEjemplares.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEjemplares.Height = 30
        Me.bloque_pnlEjemplares.Controls.Add(Me.pnlEjemplares)
        Me.bloque_pnlEjemplares.Controls.Add(Me.etiqueta_pnlEjemplares)
        Me.camposEditor.Controls.Add(Me.bloque_pnlEjemplares)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Text = "Habilitado"
        Me.chkActivo.Checked = True
        Me.bloque_chkActivo.Name = "bloque_chkActivo"
        Me.bloque_chkActivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_chkActivo.Size = New System.Drawing.Size(550, 58)
        Me.bloque_chkActivo.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_chkActivo.Name = "etiqueta_chkActivo"
        Me.etiqueta_chkActivo.Text = "Estado"
        Me.etiqueta_chkActivo.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_chkActivo.AutoSize = False
        Me.etiqueta_chkActivo.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_chkActivo.Height = 24
        Me.etiqueta_chkActivo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.chkActivo.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkActivo.Height = 30
        Me.bloque_chkActivo.Controls.Add(Me.chkActivo)
        Me.bloque_chkActivo.Controls.Add(Me.etiqueta_chkActivo)
        Me.camposEditor.Controls.Add(Me.bloque_chkActivo)
        Me.accionesEditor.Name = "accionesEditor"
        Me.accionesEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.accionesEditor.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.accionesEditor.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.Size = New System.Drawing.Size(170, 38)
        Me.btnGuardar.AutoSize = False
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnGuardar.UseVisualStyleBackColor = False
        Me.btnGuardar.Width = 155
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(170, 38)
        Me.btnCancelar.AutoSize = False
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.FlatAppearance.BorderSize = 1
        Me.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnCancelar.UseVisualStyleBackColor = False
        Me.btnCancelar.Width = 140
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.accionesEditor.Controls.Add(Me.btnGuardar)
        Me.accionesEditor.Controls.Add(Me.btnCancelar)
        Me.cuerpoEditor.Controls.Add(Me.camposEditor)
        Me.layoutEditor.Controls.Add(Me.encabezado, 0, 0)
        Me.layoutEditor.Controls.Add(Me.cuerpoEditor, 0, 1)
        Me.layoutEditor.Controls.Add(Me.accionesEditor, 0, 2)
        Me.Controls.Add(Me.layoutEditor)
        Me.AcceptButton = Me.btnGuardar
        Me.CancelButton = Me.btnCancelar
        Me.btnAddAutor.Name = "btnAddAutor"
        Me.btnAddAutor.Text = "Añadir autor"
        Me.btnAddAutor.Size = New System.Drawing.Size(155, 32)
        Me.btnAddAutor.AutoSize = False
        Me.btnAddAutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddAutor.FlatAppearance.BorderSize = 1
        Me.btnAddAutor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnAddAutor.BackColor = System.Drawing.Color.White
        Me.btnAddAutor.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnAddAutor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddAutor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddAutor.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnAddAutor.UseVisualStyleBackColor = False
        Me.btnAddCategoria.Name = "btnAddCategoria"
        Me.btnAddCategoria.Text = "Añadir categoría"
        Me.btnAddCategoria.Size = New System.Drawing.Size(175, 32)
        Me.btnAddCategoria.AutoSize = False
        Me.btnAddCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddCategoria.FlatAppearance.BorderSize = 1
        Me.btnAddCategoria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnAddCategoria.BackColor = System.Drawing.Color.White
        Me.btnAddCategoria.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnAddCategoria.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddCategoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddCategoria.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnAddCategoria.UseVisualStyleBackColor = False
        Me.flpAutores.Controls.Add(Me.btnAddAutor)
        Me.flpCategorias.Controls.Add(Me.btnAddCategoria)
        Me.lblEjemplaresInfo.Name = "lblEjemplaresInfo"
        Me.lblEjemplaresInfo.Text = "Se mostrará el total al editar un libro."
        Me.lblEjemplaresInfo.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblEjemplaresInfo.AutoSize = False
        Me.lblEjemplaresInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lnkGestionar.Name = "lnkGestionar"
        Me.lnkGestionar.Text = "Gestionar"
        Me.lnkGestionar.Dock = System.Windows.Forms.DockStyle.Right
        Me.lnkGestionar.Width = 100
        Me.pnlEjemplares.Controls.Add(Me.lblEjemplaresInfo)
        Me.pnlEjemplares.Controls.Add(Me.lnkGestionar)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.None
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(660, 730)
        Me.Name = "FrmLibroDetalle"
        Me.Text = Me.lblTituloVista.Text
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.MinimumSize = New System.Drawing.Size(500, 360)
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accionesEditor.ResumeLayout(False)
        Me.accionesEditor.PerformLayout()
        Me.bloque_chkActivo.ResumeLayout(False)
        Me.bloque_chkActivo.PerformLayout()
        Me.bloque_pnlEjemplares.ResumeLayout(False)
        Me.bloque_pnlEjemplares.PerformLayout()
        Me.pnlEjemplares.ResumeLayout(False)
        Me.pnlEjemplares.PerformLayout()
        Me.bloque_nudCantidad.ResumeLayout(False)
        Me.bloque_nudCantidad.PerformLayout()
        Me.bloque_cboPublico.ResumeLayout(False)
        Me.bloque_cboPublico.PerformLayout()
        Me.bloque_flpCategorias.ResumeLayout(False)
        Me.bloque_flpCategorias.PerformLayout()
        Me.flpCategorias.ResumeLayout(False)
        Me.flpCategorias.PerformLayout()
        Me.bloque_flpAutores.ResumeLayout(False)
        Me.bloque_flpAutores.PerformLayout()
        Me.flpAutores.ResumeLayout(False)
        Me.flpAutores.PerformLayout()
        Me.bloque_dtpAnio.ResumeLayout(False)
        Me.bloque_dtpAnio.PerformLayout()
        Me.bloque_txtEditorial.ResumeLayout(False)
        Me.bloque_txtEditorial.PerformLayout()
        Me.bloque_txtTitulo.ResumeLayout(False)
        Me.bloque_txtTitulo.PerformLayout()
        Me.camposEditor.ResumeLayout(False)
        Me.camposEditor.PerformLayout()
        Me.cuerpoEditor.ResumeLayout(False)
        Me.cuerpoEditor.PerformLayout()
        Me.layoutEditor.ResumeLayout(False)
        Me.layoutEditor.PerformLayout()
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
    Friend WithEvents layoutEditor As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cuerpoEditor As System.Windows.Forms.Panel
    Friend WithEvents camposEditor As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtTitulo As System.Windows.Forms.TextBox
    Friend WithEvents bloque_txtTitulo As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_txtTitulo As System.Windows.Forms.Label
    Friend WithEvents txtEditorial As System.Windows.Forms.TextBox
    Friend WithEvents bloque_txtEditorial As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_txtEditorial As System.Windows.Forms.Label
    Friend WithEvents dtpAnio As System.Windows.Forms.DateTimePicker
    Friend WithEvents bloque_dtpAnio As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_dtpAnio As System.Windows.Forms.Label
    Friend WithEvents flpAutores As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents bloque_flpAutores As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_flpAutores As System.Windows.Forms.Label
    Friend WithEvents flpCategorias As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents bloque_flpCategorias As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_flpCategorias As System.Windows.Forms.Label
    Friend WithEvents cboPublico As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_cboPublico As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_cboPublico As System.Windows.Forms.Label
    Friend WithEvents nudCantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents bloque_nudCantidad As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_nudCantidad As System.Windows.Forms.Label
    Friend WithEvents pnlEjemplares As System.Windows.Forms.Panel
    Friend WithEvents bloque_pnlEjemplares As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_pnlEjemplares As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents bloque_chkActivo As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_chkActivo As System.Windows.Forms.Label
    Friend WithEvents accionesEditor As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAddAutor As System.Windows.Forms.Button
    Friend WithEvents btnAddCategoria As System.Windows.Forms.Button
    Friend WithEvents lblEjemplaresInfo As System.Windows.Forms.Label
    Friend WithEvents lnkGestionar As System.Windows.Forms.LinkLabel
End Class
