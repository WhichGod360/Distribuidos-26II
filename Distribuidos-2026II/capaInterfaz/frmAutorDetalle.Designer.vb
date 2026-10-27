<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAutorDetalle
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
        encabezado = New TableLayoutPanel()
        imagenModulo = New PictureBox()
        textoEncabezado = New Panel()
        lblDescripcionVista = New Label()
        lblTituloVista = New Label()
        layoutEditor = New TableLayoutPanel()
        cuerpoEditor = New Panel()
        camposEditor = New TableLayoutPanel()

        ' Controles existentes
        bloque_nombre = New Panel()
        nombre = New TextBox()
        etiqueta_nombre = New Label()

        ' --- Nuevos controles declarados ---
        bloque_nacionalidad = New Panel()
        txtNacionalidad = New TextBox()
        etiqueta_nacionalidad = New Label()

        bloque_fechaNacimiento = New Panel()
        dtpFechaNacimiento = New DateTimePicker()
        etiqueta_fechaNacimiento = New Label()

        bloque_fechaFallecimiento = New Panel()
        dtpFechaFallecimiento = New DateTimePicker()
        etiqueta_fechaFallecimiento = New Label()

        bloque_biografia = New Panel()
        txtBiografia = New TextBox()
        etiqueta_biografia = New Label()

        accionesEditor = New FlowLayoutPanel()
        guardar = New Button()
        cancelar = New Button()

        encabezado.SuspendLayout()
        CType(imagenModulo, ISupportInitialize).BeginInit()
        textoEncabezado.SuspendLayout()
        layoutEditor.SuspendLayout()
        cuerpoEditor.SuspendLayout()
        camposEditor.SuspendLayout()
        bloque_nombre.SuspendLayout()
        bloque_nacionalidad.SuspendLayout()
        bloque_fechaNacimiento.SuspendLayout()
        bloque_fechaFallecimiento.SuspendLayout()
        bloque_biografia.SuspendLayout()
        accionesEditor.SuspendLayout()
        SuspendLayout()
        ' 
        ' encabezado
        ' 
        encabezado.ColumnCount = 2
        encabezado.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 72.0F))
        encabezado.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        encabezado.Controls.Add(imagenModulo, 0, 0)
        encabezado.Controls.Add(textoEncabezado, 1, 0)
        encabezado.Dock = DockStyle.Fill
        encabezado.Location = New Point(24, 18)
        encabezado.Margin = New Padding(0)
        encabezado.Name = "encabezado"
        encabezado.RowCount = 1
        encabezado.RowStyles.Add(New RowStyle(SizeType.Absolute, 80.0F))
        encabezado.Size = New Size(612, 84)
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
        imagenModulo.Size = New Size(56, 74)
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
        textoEncabezado.Size = New Size(534, 78)
        textoEncabezado.TabIndex = 1
        ' 
        ' lblDescripcionVista
        ' 
        lblDescripcionVista.Dock = DockStyle.Fill
        lblDescripcionVista.ForeColor = Color.FromArgb(CByte(105), CByte(116), CByte(140))
        lblDescripcionVista.Location = New Point(0, 38)
        lblDescripcionVista.Name = "lblDescripcionVista"
        lblDescripcionVista.Size = New Size(534, 40)
        lblDescripcionVista.TabIndex = 0
        lblDescripcionVista.Text = "Completa los datos del autor del catálogo."
        ' 
        ' lblTituloVista
        ' 
        lblTituloVista.Dock = DockStyle.Top
        lblTituloVista.Font = New Font("Segoe UI", 21.0F, FontStyle.Bold)
        lblTituloVista.ForeColor = Color.FromArgb(CByte(28), CByte(36), CByte(55))
        lblTituloVista.Location = New Point(0, 0)
        lblTituloVista.Name = "lblTituloVista"
        lblTituloVista.Size = New Size(534, 38)
        lblTituloVista.TabIndex = 1
        lblTituloVista.Text = "Agregar autor"
        ' 
        ' layoutEditor
        ' 
        layoutEditor.ColumnCount = 1
        layoutEditor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        layoutEditor.Controls.Add(encabezado, 0, 0)
        layoutEditor.Controls.Add(cuerpoEditor, 0, 1)
        layoutEditor.Controls.Add(accionesEditor, 0, 2)
        layoutEditor.Dock = DockStyle.Fill
        layoutEditor.Location = New Point(0, 0)
        layoutEditor.Margin = New Padding(0)
        layoutEditor.Name = "layoutEditor"
        layoutEditor.Padding = New Padding(24, 18, 24, 12)
        layoutEditor.RowCount = 3
        layoutEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 84.0F))
        layoutEditor.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        layoutEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 58.0F))
        layoutEditor.Size = New Size(660, 560)
        layoutEditor.TabIndex = 0
        ' 
        ' cuerpoEditor
        ' 
        cuerpoEditor.AutoScroll = True
        cuerpoEditor.Controls.Add(camposEditor)
        cuerpoEditor.Dock = DockStyle.Fill
        cuerpoEditor.Location = New Point(27, 105)
        cuerpoEditor.Name = "cuerpoEditor"
        cuerpoEditor.Size = New Size(606, 382)
        cuerpoEditor.TabIndex = 1
        ' 
        ' camposEditor
        ' 
        camposEditor.AutoSize = True
        camposEditor.ColumnCount = 1
        camposEditor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        camposEditor.Controls.Add(bloque_nombre, 0, 0)
        camposEditor.Controls.Add(bloque_nacionalidad, 0, 1)
        camposEditor.Controls.Add(bloque_fechaNacimiento, 0, 2)
        camposEditor.Controls.Add(bloque_fechaFallecimiento, 0, 3)
        camposEditor.Controls.Add(bloque_biografia, 0, 4)
        camposEditor.Dock = DockStyle.Top
        camposEditor.Location = New Point(0, 0)
        camposEditor.Margin = New Padding(0)
        camposEditor.Name = "camposEditor"
        camposEditor.RowCount = 5
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 110.0F))
        camposEditor.Size = New Size(606, 366)
        camposEditor.TabIndex = 0
        ' 
        ' bloque_nombre
        ' 
        bloque_nombre.Controls.Add(nombre)
        bloque_nombre.Controls.Add(etiqueta_nombre)
        bloque_nombre.Dock = DockStyle.Fill
        bloque_nombre.Location = New Point(0, 0)
        bloque_nombre.Margin = New Padding(0, 0, 12, 6)
        bloque_nombre.Name = "bloque_nombre"
        bloque_nombre.Size = New Size(594, 58)
        bloque_nombre.TabIndex = 0
        ' 
        ' nombre
        ' 
        nombre.Dock = DockStyle.Top
        nombre.Location = New Point(0, 24)
        nombre.MaxLength = 255
        nombre.Name = "nombre"
        nombre.Size = New Size(594, 30)
        nombre.TabIndex = 0
        ' 
        ' etiqueta_nombre
        ' 
        etiqueta_nombre.Dock = DockStyle.Top
        etiqueta_nombre.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        etiqueta_nombre.ForeColor = Color.FromArgb(CByte(28), CByte(36), CByte(55))
        etiqueta_nombre.Location = New Point(0, 0)
        etiqueta_nombre.Name = "etiqueta_nombre"
        etiqueta_nombre.Size = New Size(594, 24)
        etiqueta_nombre.TabIndex = 1
        etiqueta_nombre.Text = "Nombre del autor"
        ' 
        ' bloque_nacionalidad
        ' 
        bloque_nacionalidad.Controls.Add(txtNacionalidad)
        bloque_nacionalidad.Controls.Add(etiqueta_nacionalidad)
        bloque_nacionalidad.Dock = DockStyle.Fill
        bloque_nacionalidad.Location = New Point(0, 64)
        bloque_nacionalidad.Margin = New Padding(0, 0, 12, 6)
        bloque_nacionalidad.Name = "bloque_nacionalidad"
        bloque_nacionalidad.Size = New Size(594, 58)
        bloque_nacionalidad.TabIndex = 1
        ' 
        ' txtNacionalidad
        ' 
        txtNacionalidad.Dock = DockStyle.Top
        txtNacionalidad.Location = New Point(0, 24)
        txtNacionalidad.MaxLength = 100
        txtNacionalidad.Name = "txtNacionalidad"
        txtNacionalidad.Size = New Size(594, 30)
        txtNacionalidad.TabIndex = 0
        ' 
        ' etiqueta_nacionalidad
        ' 
        etiqueta_nacionalidad.Dock = DockStyle.Top
        etiqueta_nacionalidad.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        etiqueta_nacionalidad.ForeColor = Color.FromArgb(CByte(28), CByte(36), CByte(55))
        etiqueta_nacionalidad.Location = New Point(0, 0)
        etiqueta_nacionalidad.Name = "etiqueta_nacionalidad"
        etiqueta_nacionalidad.Size = New Size(594, 24)
        etiqueta_nacionalidad.TabIndex = 1
        etiqueta_nacionalidad.Text = "Nacionalidad"
        ' 
        ' bloque_fechaNacimiento
        ' 
        bloque_fechaNacimiento.Controls.Add(dtpFechaNacimiento)
        bloque_fechaNacimiento.Controls.Add(etiqueta_fechaNacimiento)
        bloque_fechaNacimiento.Dock = DockStyle.Fill
        bloque_fechaNacimiento.Location = New Point(0, 128)
        bloque_fechaNacimiento.Margin = New Padding(0, 0, 12, 6)
        bloque_fechaNacimiento.Name = "bloque_fechaNacimiento"
        bloque_fechaNacimiento.Size = New Size(594, 58)
        bloque_fechaNacimiento.TabIndex = 2
        ' 
        ' dtpFechaNacimiento
        ' 
        dtpFechaNacimiento.Checked = False
        dtpFechaNacimiento.CustomFormat = "yyyy-MM-dd"
        dtpFechaNacimiento.Dock = DockStyle.Top
        dtpFechaNacimiento.Format = DateTimePickerFormat.Short
        dtpFechaNacimiento.Location = New Point(0, 24)
        dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        dtpFechaNacimiento.ShowCheckBox = True
        dtpFechaNacimiento.Size = New Size(594, 30)
        dtpFechaNacimiento.TabIndex = 0
        ' 
        ' etiqueta_fechaNacimiento
        ' 
        etiqueta_fechaNacimiento.Dock = DockStyle.Top
        etiqueta_fechaNacimiento.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        etiqueta_fechaNacimiento.ForeColor = Color.FromArgb(CByte(28), CByte(36), CByte(55))
        etiqueta_fechaNacimiento.Location = New Point(0, 0)
        etiqueta_fechaNacimiento.Name = "etiqueta_fechaNacimiento"
        etiqueta_fechaNacimiento.Size = New Size(594, 24)
        etiqueta_fechaNacimiento.TabIndex = 1
        etiqueta_fechaNacimiento.Text = "Fecha de nacimiento"
        ' 
        ' bloque_fechaFallecimiento
        ' 
        bloque_fechaFallecimiento.Controls.Add(dtpFechaFallecimiento)
        bloque_fechaFallecimiento.Controls.Add(etiqueta_fechaFallecimiento)
        bloque_fechaFallecimiento.Dock = DockStyle.Fill
        bloque_fechaFallecimiento.Location = New Point(0, 192)
        bloque_fechaFallecimiento.Margin = New Padding(0, 0, 12, 6)
        bloque_fechaFallecimiento.Name = "bloque_fechaFallecimiento"
        bloque_fechaFallecimiento.Size = New Size(594, 58)
        bloque_fechaFallecimiento.TabIndex = 3
        ' 
        ' dtpFechaFallecimiento
        ' 
        dtpFechaFallecimiento.Checked = False
        dtpFechaFallecimiento.CustomFormat = "yyyy-MM-dd"
        dtpFechaFallecimiento.Dock = DockStyle.Top
        dtpFechaFallecimiento.Format = DateTimePickerFormat.Short
        dtpFechaFallecimiento.Location = New Point(0, 24)
        dtpFechaFallecimiento.Name = "dtpFechaFallecimiento"
        dtpFechaFallecimiento.ShowCheckBox = True
        dtpFechaFallecimiento.Size = New Size(594, 30)
        dtpFechaFallecimiento.TabIndex = 0
        ' 
        ' etiqueta_fechaFallecimiento
        ' 
        etiqueta_fechaFallecimiento.Dock = DockStyle.Top
        etiqueta_fechaFallecimiento.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        etiqueta_fechaFallecimiento.ForeColor = Color.FromArgb(CByte(28), CByte(36), CByte(55))
        etiqueta_fechaFallecimiento.Location = New Point(0, 0)
        etiqueta_fechaFallecimiento.Name = "etiqueta_fechaFallecimiento"
        etiqueta_fechaFallecimiento.Size = New Size(594, 24)
        etiqueta_fechaFallecimiento.TabIndex = 1
        etiqueta_fechaFallecimiento.Text = "Fecha de fallecimiento (opcional)"
        ' 
        ' bloque_biografia
        ' 
        bloque_biografia.Controls.Add(txtBiografia)
        bloque_biografia.Controls.Add(etiqueta_biografia)
        bloque_biografia.Dock = DockStyle.Fill
        bloque_biografia.Location = New Point(0, 256)
        bloque_biografia.Margin = New Padding(0, 0, 12, 6)
        bloque_biografia.Name = "bloque_biografia"
        bloque_biografia.Size = New Size(594, 104)
        bloque_biografia.TabIndex = 4
        ' 
        ' txtBiografia
        ' 
        txtBiografia.Dock = DockStyle.Top
        txtBiografia.Location = New Point(0, 24)
        txtBiografia.Multiline = True
        txtBiografia.Name = "txtBiografia"
        txtBiografia.ScrollBars = ScrollBars.Vertical
        txtBiografia.Size = New Size(594, 75)
        txtBiografia.TabIndex = 0
        ' 
        ' etiqueta_biografia
        ' 
        etiqueta_biografia.Dock = DockStyle.Top
        etiqueta_biografia.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        etiqueta_biografia.ForeColor = Color.FromArgb(CByte(28), CByte(36), CByte(55))
        etiqueta_biografia.Location = New Point(0, 0)
        etiqueta_biografia.Name = "etiqueta_biografia"
        etiqueta_biografia.Size = New Size(594, 24)
        etiqueta_biografia.TabIndex = 1
        etiqueta_biografia.Text = "Biografía"
        ' 
        ' accionesEditor
        ' 
        accionesEditor.Controls.Add(guardar)
        accionesEditor.Controls.Add(cancelar)
        accionesEditor.Dock = DockStyle.Fill
        accionesEditor.FlowDirection = FlowDirection.RightToLeft
        accionesEditor.Location = New Point(27, 493)
        accionesEditor.Name = "accionesEditor"
        accionesEditor.Padding = New Padding(0, 12, 0, 0)
        accionesEditor.Size = New Size(606, 52)
        accionesEditor.TabIndex = 2
        ' 
        ' guardar
        ' 
        guardar.BackColor = Color.FromArgb(CByte(72), CByte(101), CByte(244))
        guardar.Cursor = Cursors.Hand
        guardar.FlatAppearance.BorderColor = Color.FromArgb(CByte(215), CByte(222), CByte(237))
        guardar.FlatAppearance.BorderSize = 0
        guardar.FlatStyle = FlatStyle.Flat
        guardar.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        guardar.ForeColor = Color.White
        guardar.Location = New Point(441, 12)
        guardar.Margin = New Padding(0, 0, 10, 4)
        guardar.Name = "guardar"
        guardar.Size = New Size(155, 38)
        guardar.TabIndex = 0
        guardar.Text = "Guardar"
        guardar.UseVisualStyleBackColor = False
        ' 
        ' cancelar
        ' 
        cancelar.BackColor = Color.White
        cancelar.Cursor = Cursors.Hand
        cancelar.DialogResult = DialogResult.Cancel
        cancelar.FlatAppearance.BorderColor = Color.FromArgb(CByte(215), CByte(222), CByte(237))
        cancelar.FlatStyle = FlatStyle.Flat
        cancelar.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        cancelar.ForeColor = Color.FromArgb(CByte(72), CByte(101), CByte(244))
        cancelar.Location = New Point(291, 12)
        cancelar.Margin = New Padding(0, 0, 10, 4)
        cancelar.Name = "cancelar"
        cancelar.Size = New Size(140, 38)
        cancelar.TabIndex = 1
        cancelar.Text = "Cancelar"
        cancelar.UseVisualStyleBackColor = False
        ' 
        ' frmAutorDetalle
        ' 
        AcceptButton = guardar
        AutoScaleDimensions = New SizeF(120.0F, 120.0F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.White
        CancelButton = cancelar
        ClientSize = New Size(660, 560)
        Controls.Add(layoutEditor)
        Font = New Font("Segoe UI", 10.0F)
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(500, 600)
        Name = "frmAutorDetalle"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Agregar autor"
        encabezado.ResumeLayout(False)
        CType(imagenModulo, ISupportInitialize).EndInit()
        textoEncabezado.ResumeLayout(False)
        layoutEditor.ResumeLayout(False)
        cuerpoEditor.ResumeLayout(False)
        cuerpoEditor.PerformLayout()
        camposEditor.ResumeLayout(False)
        bloque_nombre.ResumeLayout(False)
        bloque_nombre.PerformLayout()
        bloque_nacionalidad.ResumeLayout(False)
        bloque_nacionalidad.PerformLayout()
        bloque_fechaNacimiento.ResumeLayout(False)
        bloque_fechaNacimiento.PerformLayout()
        bloque_fechaFallecimiento.ResumeLayout(False)
        bloque_fechaFallecimiento.PerformLayout()
        bloque_biografia.ResumeLayout(False)
        bloque_biografia.PerformLayout()
        accionesEditor.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents encabezado As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents imagenModulo As System.Windows.Forms.PictureBox
    Friend WithEvents textoEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTituloVista As System.Windows.Forms.Label
    Friend WithEvents lblDescripcionVista As System.Windows.Forms.Label
    Friend WithEvents layoutEditor As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cuerpoEditor As System.Windows.Forms.Panel
    Friend WithEvents camposEditor As System.Windows.Forms.TableLayoutPanel

    Friend WithEvents bloque_nombre As System.Windows.Forms.Panel
    Friend WithEvents nombre As System.Windows.Forms.TextBox
    Friend WithEvents etiqueta_nombre As System.Windows.Forms.Label

    Friend WithEvents bloque_nacionalidad As System.Windows.Forms.Panel
    Friend WithEvents txtNacionalidad As System.Windows.Forms.TextBox
    Friend WithEvents etiqueta_nacionalidad As System.Windows.Forms.Label

    Friend WithEvents bloque_fechaNacimiento As System.Windows.Forms.Panel
    Friend WithEvents dtpFechaNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents etiqueta_fechaNacimiento As System.Windows.Forms.Label

    Friend WithEvents bloque_fechaFallecimiento As System.Windows.Forms.Panel
    Friend WithEvents dtpFechaFallecimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents etiqueta_fechaFallecimiento As System.Windows.Forms.Label

    Friend WithEvents bloque_biografia As System.Windows.Forms.Panel
    Friend WithEvents txtBiografia As System.Windows.Forms.TextBox
    Friend WithEvents etiqueta_biografia As System.Windows.Forms.Label

    Friend WithEvents accionesEditor As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents cancelar As System.Windows.Forms.Button
End Class