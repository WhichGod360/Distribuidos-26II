<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPenalizacionEditar
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
        components = New System.ComponentModel.Container()
        layoutEditor = New TableLayoutPanel()
        encabezado = New Panel()
        lblTituloVista = New Label()
        lblDescripcionVista = New Label()
        cuerpoEditor = New Panel()
        accionesEditor = New FlowLayoutPanel()
        cancelar = New Button()
        guardar = New Button()
        camposEditor = New TableLayoutPanel()
        bloque_tipo = New Panel()
        etiqueta_tipo = New Label()
        tipo = New TextBox()
        bloque_monto = New Panel()
        etiqueta_monto = New Label()
        monto = New NumericUpDown()
        bloque_descripcion = New Panel()
        etiqueta_descripcion = New Label()
        descripcion = New TextBox()
        bloque_activo = New Panel()
        etiqueta_activo = New Label()
        activo = New CheckBox()
        bloque_esMora = New Panel()
        etiqueta_esMora = New Label()
        esMora = New CheckBox()
        bloque_diasDesde = New Panel()
        etiqueta_diasDesde = New Label()
        diasDesde = New NumericUpDown()
        layoutEditor.SuspendLayout()
        encabezado.SuspendLayout()
        cuerpoEditor.SuspendLayout()
        accionesEditor.SuspendLayout()
        camposEditor.SuspendLayout()
        bloque_tipo.SuspendLayout()
        bloque_monto.SuspendLayout()
        bloque_descripcion.SuspendLayout()
        bloque_activo.SuspendLayout()
        bloque_esMora.SuspendLayout()
        bloque_diasDesde.SuspendLayout()
        CType(monto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(diasDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        ' layoutEditor
        '
        layoutEditor.Name = "layoutEditor"
        layoutEditor.ColumnCount = 1
        layoutEditor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        layoutEditor.RowCount = 3
        layoutEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 80.0F))
        layoutEditor.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        layoutEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 54.0F))
        layoutEditor.Dock = DockStyle.Fill
        layoutEditor.Padding = New Padding(24, 18, 24, 16)
        layoutEditor.Size = New Size(580, 610)
        layoutEditor.Controls.Add(encabezado, 0, 0)
        layoutEditor.Controls.Add(cuerpoEditor, 0, 1)
        layoutEditor.Controls.Add(accionesEditor, 0, 2)
        layoutEditor.TabIndex = 0
        '
        ' encabezado
        '
        encabezado.Name = "encabezado"
        encabezado.Dock = DockStyle.Fill
        encabezado.Margin = New Padding(0)
        encabezado.Controls.Add(lblDescripcionVista)
        encabezado.Controls.Add(lblTituloVista)
        '
        ' lblTituloVista
        '
        lblTituloVista.Name = "lblTituloVista"
        lblTituloVista.Text = "Agregar penalización"
        lblTituloVista.Dock = DockStyle.Top
        lblTituloVista.Height = 37
        lblTituloVista.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblTituloVista.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' lblDescripcionVista
        '
        lblDescripcionVista.Name = "lblDescripcionVista"
        lblDescripcionVista.Text = "Configura el monto fijo y, si corresponde, el tramo de retraso."
        lblDescripcionVista.Dock = DockStyle.Fill
        lblDescripcionVista.AutoEllipsis = True
        lblDescripcionVista.ForeColor = Color.FromArgb(120, 120, 120)
        '
        ' cuerpoEditor
        '
        cuerpoEditor.Name = "cuerpoEditor"
        cuerpoEditor.Dock = DockStyle.Fill
        cuerpoEditor.AutoScroll = True
        cuerpoEditor.Margin = New Padding(0)
        cuerpoEditor.TabIndex = 1
        '
        ' accionesEditor
        '
        accionesEditor.Name = "accionesEditor"
        accionesEditor.Dock = DockStyle.Fill
        accionesEditor.Margin = New Padding(0)
        accionesEditor.Padding = New Padding(0, 12, 0, 0)
        accionesEditor.FlowDirection = FlowDirection.RightToLeft
        accionesEditor.WrapContents = False
        accionesEditor.Controls.Add(cancelar)
        accionesEditor.Controls.Add(guardar)
        accionesEditor.TabIndex = 2
        '
        ' cancelar
        '
        cancelar.Name = "cancelar"
        cancelar.Text = "Cancelar"
        cancelar.Size = New Size(138, 36)
        cancelar.Margin = New Padding(10, 0, 0, 0)
        cancelar.TabIndex = 1
        cancelar.Cursor = Cursors.Hand
        cancelar.Font = New Font("Segoe UI Semibold", 10.0F)
        cancelar.FlatStyle = FlatStyle.Flat
        cancelar.UseVisualStyleBackColor = False
        cancelar.BackColor = Color.White
        cancelar.ForeColor = Color.FromArgb(59, 91, 115)
        cancelar.FlatAppearance.BorderSize = 1
        cancelar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        cancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 244, 247)
        cancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 232, 238)
        cancelar.DialogResult = DialogResult.Cancel
        '
        ' guardar
        '
        guardar.Name = "guardar"
        guardar.Text = "Guardar"
        guardar.Size = New Size(138, 36)
        guardar.Margin = New Padding(10, 0, 0, 0)
        guardar.TabIndex = 0
        guardar.Cursor = Cursors.Hand
        guardar.Font = New Font("Segoe UI Semibold", 10.0F)
        guardar.FlatStyle = FlatStyle.Flat
        guardar.UseVisualStyleBackColor = False
        guardar.BackColor = Color.FromArgb(59, 91, 115)
        guardar.ForeColor = Color.White
        guardar.FlatAppearance.BorderSize = 0
        guardar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        guardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 72, 92)
        guardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 56, 72)
        '
        ' Me
        '
        Me.AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 10.0F)
        Me.ClientSize = New Size(580, 610)
        Me.Text = "Agregar penalización"
        Me.Name = "frmPenalizacionEditar"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.AcceptButton = guardar
        Me.CancelButton = cancelar
        Me.Controls.Add(layoutEditor)
        '
        ' camposEditor
        '
        camposEditor.Name = "camposEditor"
        camposEditor.Dock = DockStyle.Top
        camposEditor.AutoSize = True
        camposEditor.AutoSizeMode = AutoSizeMode.GrowAndShrink
        camposEditor.Margin = New Padding(0)
        camposEditor.ColumnCount = 1
        camposEditor.RowCount = 6
        camposEditor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 62.0F))
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 62.0F))
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 116.0F))
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 62.0F))
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 62.0F))
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 62.0F))
        '
        ' cuerpoEditor
        '
        cuerpoEditor.Controls.Add(camposEditor)
        '
        ' bloque_tipo
        '
        bloque_tipo.Name = "bloque_tipo"
        bloque_tipo.Dock = DockStyle.Fill
        bloque_tipo.Margin = New Padding(0, 0, 14, 0)
        bloque_tipo.Size = New Size(360, 62)
        bloque_tipo.TabIndex = 0
        bloque_tipo.Controls.Add(tipo)
        bloque_tipo.Controls.Add(etiqueta_tipo)
        '
        ' etiqueta_tipo
        '
        etiqueta_tipo.Name = "etiqueta_tipo"
        etiqueta_tipo.Text = "Tipo de penalización"
        etiqueta_tipo.Dock = DockStyle.Top
        etiqueta_tipo.Height = 24
        etiqueta_tipo.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_tipo.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' tipo
        '
        tipo.Name = "tipo"
        tipo.Dock = DockStyle.Top
        tipo.TabIndex = 0
        tipo.MaxLength = 30
        '
        ' camposEditor
        '
        camposEditor.Controls.Add(bloque_tipo, 0, 0)
        '
        ' bloque_monto
        '
        bloque_monto.Name = "bloque_monto"
        bloque_monto.Dock = DockStyle.Fill
        bloque_monto.Margin = New Padding(0, 0, 14, 0)
        bloque_monto.Size = New Size(360, 62)
        bloque_monto.TabIndex = 2
        bloque_monto.Controls.Add(monto)
        bloque_monto.Controls.Add(etiqueta_monto)
        '
        ' etiqueta_monto
        '
        etiqueta_monto.Name = "etiqueta_monto"
        etiqueta_monto.Text = "Monto fijo (S/)"
        etiqueta_monto.Dock = DockStyle.Top
        etiqueta_monto.Height = 24
        etiqueta_monto.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_monto.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' monto
        '
        monto.Name = "monto"
        monto.Dock = DockStyle.Top
        monto.TabIndex = 0
        monto.DecimalPlaces = 2
        monto.Maximum = 99999.99D
        monto.Increment = 0.5D
        monto.ThousandsSeparator = True
        '
        ' camposEditor
        '
        camposEditor.Controls.Add(bloque_monto, 0, 1)
        '
        ' bloque_descripcion
        '
        bloque_descripcion.Name = "bloque_descripcion"
        bloque_descripcion.Dock = DockStyle.Fill
        bloque_descripcion.Margin = New Padding(0, 0, 14, 0)
        bloque_descripcion.Size = New Size(360, 116)
        bloque_descripcion.TabIndex = 4
        bloque_descripcion.Controls.Add(descripcion)
        bloque_descripcion.Controls.Add(etiqueta_descripcion)
        '
        ' etiqueta_descripcion
        '
        etiqueta_descripcion.Name = "etiqueta_descripcion"
        etiqueta_descripcion.Text = "Descripción"
        etiqueta_descripcion.Dock = DockStyle.Top
        etiqueta_descripcion.Height = 24
        etiqueta_descripcion.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_descripcion.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' descripcion
        '
        descripcion.Name = "descripcion"
        descripcion.Dock = DockStyle.Top
        descripcion.TabIndex = 0
        descripcion.Multiline = True
        descripcion.ScrollBars = ScrollBars.Vertical
        descripcion.Height = 80
        '
        ' camposEditor
        '
        camposEditor.Controls.Add(bloque_descripcion, 0, 2)
        '
        ' bloque_activo
        '
        bloque_activo.Name = "bloque_activo"
        bloque_activo.Dock = DockStyle.Fill
        bloque_activo.Margin = New Padding(0, 0, 14, 0)
        bloque_activo.Size = New Size(360, 62)
        bloque_activo.TabIndex = 6
        bloque_activo.Controls.Add(activo)
        bloque_activo.Controls.Add(etiqueta_activo)
        '
        ' etiqueta_activo
        '
        etiqueta_activo.Name = "etiqueta_activo"
        etiqueta_activo.Text = "Estado"
        etiqueta_activo.Dock = DockStyle.Top
        etiqueta_activo.Height = 24
        etiqueta_activo.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_activo.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' activo
        '
        activo.Name = "activo"
        activo.Dock = DockStyle.Top
        activo.TabIndex = 0
        activo.Text = "Penalización activa"
        activo.Checked = True
        activo.Height = 28
        '
        ' camposEditor
        '
        camposEditor.Controls.Add(bloque_activo, 0, 3)
        '
        ' bloque_esMora
        '
        bloque_esMora.Name = "bloque_esMora"
        bloque_esMora.Dock = DockStyle.Fill
        bloque_esMora.Margin = New Padding(0, 0, 14, 0)
        bloque_esMora.Size = New Size(360, 62)
        bloque_esMora.TabIndex = 8
        bloque_esMora.Controls.Add(esMora)
        bloque_esMora.Controls.Add(etiqueta_esMora)
        '
        ' etiqueta_esMora
        '
        etiqueta_esMora.Name = "etiqueta_esMora"
        etiqueta_esMora.Text = "Aplicación"
        etiqueta_esMora.Dock = DockStyle.Top
        etiqueta_esMora.Height = 24
        etiqueta_esMora.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_esMora.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' esMora
        '
        esMora.Name = "esMora"
        esMora.Dock = DockStyle.Top
        esMora.TabIndex = 0
        esMora.Text = "Aplicar automáticamente por retraso"
        esMora.Height = 28
        '
        ' camposEditor
        '
        camposEditor.Controls.Add(bloque_esMora, 0, 4)
        '
        ' bloque_diasDesde
        '
        bloque_diasDesde.Name = "bloque_diasDesde"
        bloque_diasDesde.Dock = DockStyle.Fill
        bloque_diasDesde.Margin = New Padding(0, 0, 14, 0)
        bloque_diasDesde.Size = New Size(360, 62)
        bloque_diasDesde.TabIndex = 10
        bloque_diasDesde.Controls.Add(diasDesde)
        bloque_diasDesde.Controls.Add(etiqueta_diasDesde)
        '
        ' etiqueta_diasDesde
        '
        etiqueta_diasDesde.Name = "etiqueta_diasDesde"
        etiqueta_diasDesde.Text = "Aplicar desde este día de retraso"
        etiqueta_diasDesde.Dock = DockStyle.Top
        etiqueta_diasDesde.Height = 24
        etiqueta_diasDesde.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_diasDesde.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' diasDesde
        '
        diasDesde.Name = "diasDesde"
        diasDesde.Dock = DockStyle.Top
        diasDesde.TabIndex = 0
        diasDesde.Minimum = 1D
        diasDesde.Maximum = 2147483647D
        diasDesde.Value = 1D
        diasDesde.Enabled = False
        '
        ' camposEditor
        '
        camposEditor.Controls.Add(bloque_diasDesde, 0, 5)
        layoutEditor.ResumeLayout(False)
        layoutEditor.PerformLayout()
        encabezado.ResumeLayout(False)
        encabezado.PerformLayout()
        cuerpoEditor.ResumeLayout(False)
        cuerpoEditor.PerformLayout()
        accionesEditor.ResumeLayout(False)
        accionesEditor.PerformLayout()
        camposEditor.ResumeLayout(False)
        camposEditor.PerformLayout()
        bloque_tipo.ResumeLayout(False)
        bloque_tipo.PerformLayout()
        bloque_monto.ResumeLayout(False)
        bloque_monto.PerformLayout()
        bloque_descripcion.ResumeLayout(False)
        bloque_descripcion.PerformLayout()
        bloque_activo.ResumeLayout(False)
        bloque_activo.PerformLayout()
        bloque_esMora.ResumeLayout(False)
        bloque_esMora.PerformLayout()
        bloque_diasDesde.ResumeLayout(False)
        bloque_diasDesde.PerformLayout()
        CType(monto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(diasDesde, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents layoutEditor As TableLayoutPanel
    Friend WithEvents encabezado As Panel
    Friend WithEvents lblTituloVista As Label
    Friend WithEvents lblDescripcionVista As Label
    Friend WithEvents cuerpoEditor As Panel
    Friend WithEvents accionesEditor As FlowLayoutPanel
    Friend WithEvents cancelar As Button
    Friend WithEvents guardar As Button
    Friend WithEvents camposEditor As TableLayoutPanel
    Friend WithEvents bloque_tipo As Panel
    Friend WithEvents etiqueta_tipo As Label
    Friend WithEvents tipo As TextBox
    Friend WithEvents bloque_monto As Panel
    Friend WithEvents etiqueta_monto As Label
    Friend WithEvents monto As NumericUpDown
    Friend WithEvents bloque_descripcion As Panel
    Friend WithEvents etiqueta_descripcion As Label
    Friend WithEvents descripcion As TextBox
    Friend WithEvents bloque_activo As Panel
    Friend WithEvents etiqueta_activo As Label
    Friend WithEvents activo As CheckBox
    Friend WithEvents bloque_esMora As Panel
    Friend WithEvents etiqueta_esMora As Label
    Friend WithEvents esMora As CheckBox
    Friend WithEvents bloque_diasDesde As Panel
    Friend WithEvents etiqueta_diasDesde As Label
    Friend WithEvents diasDesde As NumericUpDown
End Class
