\xEF\xBB\xBFImports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLibroDetalle
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
        Me.lblTituloForm = New Label()
        Me.lblSubtitulo = New Label()
        Me.btnCerrar = New Button()
        Me.lblTitulo = New Label()
        Me.txtTitulo = New TextBox()
        Me.lblEditorial = New Label()
        Me.txtEditorial = New TextBox()
        Me.lblAnio = New Label()
        Me.dtpAnio = New DateTimePicker()
        Me.lblAutores = New Label()
        Me.flpAutores = New FlowLayoutPanel()
        Me.btnAddAutor = New Button()
        Me.lblCategorias = New Label()
        Me.flpCategorias = New FlowLayoutPanel()
        Me.btnAddCategoria = New Button()
        Me.lblPublico = New Label()
        Me.cboPublico = New ComboBox()
        Me.lblCantidad = New Label()
        Me.nudCantidad = New NumericUpDown()
        Me.lblCantidadAyuda = New Label()
        Me.lblEjemplares = New Label()
        Me.pnlEjemplares = New Panel()
        Me.lblEjemplaresInfo = New Label()
        Me.lnkGestionar = New LinkLabel()
        Me.lblEstado = New Label()
        Me.chkActivo = New CheckBox()
        Me.btnCancelar = New Button()
        Me.btnGuardar = New Button()
        Me.flpAutores.SuspendLayout()
        Me.flpCategorias.SuspendLayout()
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEjemplares.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTituloForm
        '
        Me.lblTituloForm.AutoSize = True
        Me.lblTituloForm.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
        Me.lblTituloForm.Location = New Point(26, 18)
        Me.lblTituloForm.Name = "lblTituloForm"
        Me.lblTituloForm.Size = New Size(130, 25)
        Me.lblTituloForm.TabIndex = 0
        Me.lblTituloForm.Text = "Agregar libro"
        '
        'lblSubtitulo
        '
        Me.lblSubtitulo.AutoSize = True
        Me.lblSubtitulo.Font = New Font("Segoe UI", 9.0!)
        Me.lblSubtitulo.ForeColor = Color.FromArgb(90, 90, 100)
        Me.lblSubtitulo.Location = New Point(30, 52)
        Me.lblSubtitulo.Name = "lblSubtitulo"
        Me.lblSubtitulo.Size = New Size(370, 15)
        Me.lblSubtitulo.TabIndex = 1
        Me.lblSubtitulo.Text = "Completa los datos del nuevo libro. Los campos con * son obligatorios."
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = Color.Transparent
        Me.btnCerrar.Cursor = Cursors.Hand
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatStyle = FlatStyle.Flat
        Me.btnCerrar.Location = New Point(480, 14)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New Size(30, 30)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.TabStop = False
        Me.btnCerrar.Text = "✕"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.lblTitulo.Location = New Point(30, 90)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New Size(46, 15)
        Me.lblTitulo.TabIndex = 3
        Me.lblTitulo.Text = "Título *"
        '
        'txtTitulo
        '
        Me.txtTitulo.BorderStyle = BorderStyle.FixedSingle
        Me.txtTitulo.Location = New Point(30, 112)
        Me.txtTitulo.MaxLength = 200
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New Size(460, 25)
        Me.txtTitulo.TabIndex = 0
        '
        'lblEditorial
        '
        Me.lblEditorial.AutoSize = True
        Me.lblEditorial.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.lblEditorial.Location = New Point(30, 152)
        Me.lblEditorial.Name = "lblEditorial"
        Me.lblEditorial.Size = New Size(59, 15)
        Me.lblEditorial.TabIndex = 5
        Me.lblEditorial.Text = "Editorial *"
        '
        'txtEditorial
        '
        Me.txtEditorial.BorderStyle = BorderStyle.FixedSingle
        Me.txtEditorial.Location = New Point(30, 174)
        Me.txtEditorial.MaxLength = 100
        Me.txtEditorial.Name = "txtEditorial"
        Me.txtEditorial.Size = New Size(222, 25)
        Me.txtEditorial.TabIndex = 1
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.lblAnio.Location = New Point(268, 152)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New Size(122, 15)
        Me.lblAnio.TabIndex = 7
        Me.lblAnio.Text = "Año de publicación *"
        '
        'dtpAnio
        '
        Me.dtpAnio.CustomFormat = "dd/MM/yyyy"
        Me.dtpAnio.Format = DateTimePickerFormat.Custom
        Me.dtpAnio.Location = New Point(268, 174)
        Me.dtpAnio.Name = "dtpAnio"
        Me.dtpAnio.Size = New Size(222, 25)
        Me.dtpAnio.TabIndex = 2
        '
        'lblAutores
        '
        Me.lblAutores.AutoSize = True
        Me.lblAutores.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.lblAutores.Location = New Point(30, 214)
        Me.lblAutores.Name = "lblAutores"
        Me.lblAutores.Size = New Size(56, 15)
        Me.lblAutores.TabIndex = 9
        Me.lblAutores.Text = "Autores *"
        '
        'flpAutores
        '
        Me.flpAutores.AutoScroll = True
        Me.flpAutores.BorderStyle = BorderStyle.FixedSingle
        Me.flpAutores.Controls.Add(Me.btnAddAutor)
        Me.flpAutores.Location = New Point(30, 236)
        Me.flpAutores.Name = "flpAutores"
        Me.flpAutores.Padding = New Padding(3, 2, 0, 0)
        Me.flpAutores.Size = New Size(460, 44)
        Me.flpAutores.TabIndex = 3
        '
        'btnAddAutor
        '
        Me.btnAddAutor.BackColor = Color.White
        Me.btnAddAutor.Cursor = Cursors.Hand
        Me.btnAddAutor.FlatAppearance.BorderColor = Color.FromArgb(74, 108, 247)
        Me.btnAddAutor.FlatStyle = FlatStyle.Flat
        Me.btnAddAutor.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.btnAddAutor.ForeColor = Color.FromArgb(74, 108, 247)
        Me.btnAddAutor.Location = New Point(6, 4)
        Me.btnAddAutor.Margin = New Padding(3, 2, 3, 3)
        Me.btnAddAutor.Name = "btnAddAutor"
        Me.btnAddAutor.Size = New Size(125, 26)
        Me.btnAddAutor.TabIndex = 0
        Me.btnAddAutor.Text = "+ Añadir autor"
        Me.btnAddAutor.UseVisualStyleBackColor = False
        '
        'lblCategorias
        '
        Me.lblCategorias.AutoSize = True
        Me.lblCategorias.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.lblCategorias.Location = New Point(30, 296)
        Me.lblCategorias.Name = "lblCategorias"
        Me.lblCategorias.Size = New Size(72, 15)
        Me.lblCategorias.TabIndex = 11
        Me.lblCategorias.Text = "Categorías *"
        '
        'flpCategorias
        '
        Me.flpCategorias.AutoScroll = True
        Me.flpCategorias.BorderStyle = BorderStyle.FixedSingle
        Me.flpCategorias.Controls.Add(Me.btnAddCategoria)
        Me.flpCategorias.Location = New Point(30, 318)
        Me.flpCategorias.Name = "flpCategorias"
        Me.flpCategorias.Padding = New Padding(3, 2, 0, 0)
        Me.flpCategorias.Size = New Size(460, 44)
        Me.flpCategorias.TabIndex = 4
        '
        'btnAddCategoria
        '
        Me.btnAddCategoria.BackColor = Color.White
        Me.btnAddCategoria.Cursor = Cursors.Hand
        Me.btnAddCategoria.FlatAppearance.BorderColor = Color.FromArgb(74, 108, 247)
        Me.btnAddCategoria.FlatStyle = FlatStyle.Flat
        Me.btnAddCategoria.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.btnAddCategoria.ForeColor = Color.FromArgb(74, 108, 247)
        Me.btnAddCategoria.Location = New Point(6, 4)
        Me.btnAddCategoria.Margin = New Padding(3, 2, 3, 3)
        Me.btnAddCategoria.Name = "btnAddCategoria"
        Me.btnAddCategoria.Size = New Size(140, 26)
        Me.btnAddCategoria.TabIndex = 0
        Me.btnAddCategoria.Text = "+ Añadir categoría"
        Me.btnAddCategoria.UseVisualStyleBackColor = False
        '
        'lblPublico
        '
        Me.lblPublico.AutoSize = True
        Me.lblPublico.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.lblPublico.Location = New Point(30, 378)
        Me.lblPublico.Name = "lblPublico"
        Me.lblPublico.Size = New Size(105, 15)
        Me.lblPublico.TabIndex = 13
        Me.lblPublico.Text = "Público objetivo *"
        '
        'cboPublico
        '
        Me.cboPublico.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboPublico.FormattingEnabled = True
        Me.cboPublico.Items.AddRange(New Object() {"Niños", "Jóvenes", "Adultos", "Público general"})
        Me.cboPublico.Location = New Point(30, 400)
        Me.cboPublico.Name = "cboPublico"
        Me.cboPublico.Size = New Size(222, 25)
        Me.cboPublico.TabIndex = 5
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.lblCantidad.Location = New Point(268, 378)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New Size(148, 15)
        Me.lblCantidad.TabIndex = 15
        Me.lblCantidad.Text = "Cantidad de ejemplares *"
        '
        'nudCantidad
        '
        Me.nudCantidad.Location = New Point(268, 400)
        Me.nudCantidad.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.nudCantidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCantidad.Name = "nudCantidad"
        Me.nudCantidad.Size = New Size(222, 25)
        Me.nudCantidad.TabIndex = 6
        Me.nudCantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblCantidadAyuda
        '
        Me.lblCantidadAyuda.AutoSize = True
        Me.lblCantidadAyuda.Font = New Font("Segoe UI", 8.0!)
        Me.lblCantidadAyuda.ForeColor = Color.FromArgb(90, 90, 100)
        Me.lblCantidadAyuda.Location = New Point(268, 428)
        Me.lblCantidadAyuda.Name = "lblCantidadAyuda"
        Me.lblCantidadAyuda.Size = New Size(214, 13)
        Me.lblCantidadAyuda.TabIndex = 17
        Me.lblCantidadAyuda.Text = "Se crearán tantos ejemplares como indiques."
        '
        'lblEjemplares
        '
        Me.lblEjemplares.AutoSize = True
        Me.lblEjemplares.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.lblEjemplares.Location = New Point(268, 378)
        Me.lblEjemplares.Name = "lblEjemplares"
        Me.lblEjemplares.Size = New Size(131, 15)
        Me.lblEjemplares.TabIndex = 18
        Me.lblEjemplares.Text = "Ejemplares registrados"
        Me.lblEjemplares.Visible = False
        '
        'pnlEjemplares
        '
        Me.pnlEjemplares.BackColor = Color.FromArgb(244, 246, 252)
        Me.pnlEjemplares.BorderStyle = BorderStyle.FixedSingle
        Me.pnlEjemplares.Controls.Add(Me.lblEjemplaresInfo)
        Me.pnlEjemplares.Controls.Add(Me.lnkGestionar)
        Me.pnlEjemplares.Location = New Point(268, 400)
        Me.pnlEjemplares.Name = "pnlEjemplares"
        Me.pnlEjemplares.Size = New Size(222, 30)
        Me.pnlEjemplares.TabIndex = 19
        Me.pnlEjemplares.Visible = False
        '
        'lblEjemplaresInfo
        '
        Me.lblEjemplaresInfo.AutoSize = True
        Me.lblEjemplaresInfo.Location = New Point(8, 4)
        Me.lblEjemplaresInfo.Name = "lblEjemplaresInfo"
        Me.lblEjemplaresInfo.Size = New Size(108, 19)
        Me.lblEjemplaresInfo.TabIndex = 0
        Me.lblEjemplaresInfo.Text = "0 (0 disponibles)"
        '
        'lnkGestionar
        '
        Me.lnkGestionar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Me.lnkGestionar.AutoSize = True
        Me.lnkGestionar.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.lnkGestionar.LinkColor = Color.FromArgb(74, 108, 247)
        Me.lnkGestionar.Location = New Point(155, 6)
        Me.lnkGestionar.Name = "lnkGestionar"
        Me.lnkGestionar.Size = New Size(58, 15)
        Me.lnkGestionar.TabIndex = 1
        Me.lnkGestionar.TabStop = True
        Me.lnkGestionar.Text = "Gestionar"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        Me.lblEstado.Location = New Point(30, 456)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New Size(45, 15)
        Me.lblEstado.TabIndex = 20
        Me.lblEstado.Text = "Estado"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = CheckState.Checked
        Me.chkActivo.Cursor = Cursors.Hand
        Me.chkActivo.Location = New Point(30, 478)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New Size(66, 23)
        Me.chkActivo.TabIndex = 7
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = Color.White
        Me.btnCancelar.Cursor = Cursors.Hand
        Me.btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(74, 108, 247)
        Me.btnCancelar.FlatStyle = FlatStyle.Flat
        Me.btnCancelar.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
        Me.btnCancelar.ForeColor = Color.FromArgb(74, 108, 247)
        Me.btnCancelar.Location = New Point(220, 525)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New Size(130, 40)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = Color.FromArgb(74, 108, 247)
        Me.btnGuardar.Cursor = Cursors.Hand
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatStyle = FlatStyle.Flat
        Me.btnGuardar.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
        Me.btnGuardar.ForeColor = Color.White
        Me.btnGuardar.Location = New Point(360, 525)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New Size(130, 40)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'FrmLibroDetalle
        '
        Me.AcceptButton = Me.btnGuardar
        Me.AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.White
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New Size(520, 590)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.pnlEjemplares)
        Me.Controls.Add(Me.lblEjemplares)
        Me.Controls.Add(Me.lblCantidadAyuda)
        Me.Controls.Add(Me.nudCantidad)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.cboPublico)
        Me.Controls.Add(Me.lblPublico)
        Me.Controls.Add(Me.flpCategorias)
        Me.Controls.Add(Me.lblCategorias)
        Me.Controls.Add(Me.flpAutores)
        Me.Controls.Add(Me.lblAutores)
        Me.Controls.Add(Me.dtpAnio)
        Me.Controls.Add(Me.lblAnio)
        Me.Controls.Add(Me.txtEditorial)
        Me.Controls.Add(Me.lblEditorial)
        Me.Controls.Add(Me.txtTitulo)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.lblSubtitulo)
        Me.Controls.Add(Me.lblTituloForm)
        Me.Font = New Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Name = "FrmLibroDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "Libro"
        Me.flpAutores.ResumeLayout(False)
        Me.flpCategorias.ResumeLayout(False)
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEjemplares.ResumeLayout(False)
        Me.pnlEjemplares.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTituloForm As Label
    Friend WithEvents lblSubtitulo As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents txtTitulo As TextBox
    Friend WithEvents lblEditorial As Label
    Friend WithEvents txtEditorial As TextBox
    Friend WithEvents lblAnio As Label
    Friend WithEvents dtpAnio As DateTimePicker
    Friend WithEvents lblAutores As Label
    Friend WithEvents flpAutores As FlowLayoutPanel
    Friend WithEvents btnAddAutor As Button
    Friend WithEvents lblCategorias As Label
    Friend WithEvents flpCategorias As FlowLayoutPanel
    Friend WithEvents btnAddCategoria As Button
    Friend WithEvents lblPublico As Label
    Friend WithEvents cboPublico As ComboBox
    Friend WithEvents lblCantidad As Label
    Friend WithEvents nudCantidad As NumericUpDown
    Friend WithEvents lblCantidadAyuda As Label
    Friend WithEvents lblEjemplares As Label
    Friend WithEvents pnlEjemplares As Panel
    Friend WithEvents lblEjemplaresInfo As Label
    Friend WithEvents lnkGestionar As LinkLabel
    Friend WithEvents lblEstado As Label
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button

End Class
