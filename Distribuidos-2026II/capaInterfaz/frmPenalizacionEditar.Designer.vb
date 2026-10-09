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
        Me.components = New System.ComponentModel.Container()
        Me.encabezado = New System.Windows.Forms.TableLayoutPanel()
        Me.imagenModulo = New System.Windows.Forms.PictureBox()
        Me.textoEncabezado = New System.Windows.Forms.Panel()
        Me.lblTituloVista = New System.Windows.Forms.Label()
        Me.lblDescripcionVista = New System.Windows.Forms.Label()
        Me.layoutEditor = New System.Windows.Forms.TableLayoutPanel()
        Me.cuerpoEditor = New System.Windows.Forms.Panel()
        Me.camposEditor = New System.Windows.Forms.TableLayoutPanel()
        Me.tipo = New System.Windows.Forms.TextBox()
        Me.bloque_tipo = New System.Windows.Forms.Panel()
        Me.etiqueta_tipo = New System.Windows.Forms.Label()
        Me.monto = New System.Windows.Forms.NumericUpDown()
        Me.bloque_monto = New System.Windows.Forms.Panel()
        Me.etiqueta_monto = New System.Windows.Forms.Label()
        Me.descripcion = New System.Windows.Forms.TextBox()
        Me.bloque_descripcion = New System.Windows.Forms.Panel()
        Me.etiqueta_descripcion = New System.Windows.Forms.Label()
        Me.activo = New System.Windows.Forms.CheckBox()
        Me.bloque_activo = New System.Windows.Forms.Panel()
        Me.etiqueta_activo = New System.Windows.Forms.Label()
        Me.accionesEditor = New System.Windows.Forms.FlowLayoutPanel()
        Me.guardar = New System.Windows.Forms.Button()
        Me.cancelar = New System.Windows.Forms.Button()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.monto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutEditor.SuspendLayout()
        Me.cuerpoEditor.SuspendLayout()
        Me.camposEditor.SuspendLayout()
        Me.bloque_tipo.SuspendLayout()
        Me.bloque_monto.SuspendLayout()
        Me.bloque_descripcion.SuspendLayout()
        Me.bloque_activo.SuspendLayout()
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
        Me.lblTituloVista.Text = "Agregar penalización"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Define el tipo de sanción y su monto en soles."
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
        Me.camposEditor.RowCount = 4
        Me.camposEditor.ColumnCount = 1
        Me.camposEditor.Margin = New System.Windows.Forms.Padding(0)
        Me.camposEditor.AutoSize = True
        Me.camposEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.tipo.Name = "tipo"
        Me.tipo.MaxLength = 30
        Me.bloque_tipo.Name = "bloque_tipo"
        Me.bloque_tipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_tipo.Size = New System.Drawing.Size(550, 58)
        Me.bloque_tipo.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_tipo.Name = "etiqueta_tipo"
        Me.etiqueta_tipo.Text = "Tipo"
        Me.etiqueta_tipo.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_tipo.AutoSize = False
        Me.etiqueta_tipo.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_tipo.Height = 24
        Me.etiqueta_tipo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.tipo.Dock = System.Windows.Forms.DockStyle.Top
        Me.tipo.Height = 30
        Me.bloque_tipo.Controls.Add(Me.tipo)
        Me.bloque_tipo.Controls.Add(Me.etiqueta_tipo)
        Me.camposEditor.Controls.Add(Me.bloque_tipo)
        Me.monto.Name = "monto"
        Me.monto.DecimalPlaces = 2
        Me.monto.Maximum = 99999.99D
        Me.monto.Minimum = 0D
        Me.monto.ThousandsSeparator = True
        Me.bloque_monto.Name = "bloque_monto"
        Me.bloque_monto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_monto.Size = New System.Drawing.Size(550, 58)
        Me.bloque_monto.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_monto.Name = "etiqueta_monto"
        Me.etiqueta_monto.Text = "Monto (S/)"
        Me.etiqueta_monto.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_monto.AutoSize = False
        Me.etiqueta_monto.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_monto.Height = 24
        Me.etiqueta_monto.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.monto.Dock = System.Windows.Forms.DockStyle.Top
        Me.monto.Height = 30
        Me.bloque_monto.Controls.Add(Me.monto)
        Me.bloque_monto.Controls.Add(Me.etiqueta_monto)
        Me.camposEditor.Controls.Add(Me.bloque_monto)
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Multiline = True
        Me.descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.bloque_descripcion.Name = "bloque_descripcion"
        Me.bloque_descripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_descripcion.Size = New System.Drawing.Size(550, 104)
        Me.bloque_descripcion.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_descripcion.Name = "etiqueta_descripcion"
        Me.etiqueta_descripcion.Text = "Descripción"
        Me.etiqueta_descripcion.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_descripcion.AutoSize = False
        Me.etiqueta_descripcion.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_descripcion.Height = 24
        Me.etiqueta_descripcion.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.descripcion.Dock = System.Windows.Forms.DockStyle.Top
        Me.descripcion.Height = 76
        Me.bloque_descripcion.Controls.Add(Me.descripcion)
        Me.bloque_descripcion.Controls.Add(Me.etiqueta_descripcion)
        Me.camposEditor.Controls.Add(Me.bloque_descripcion)
        Me.activo.Name = "activo"
        Me.activo.Text = "Activo"
        Me.activo.Checked = True
        Me.bloque_activo.Name = "bloque_activo"
        Me.bloque_activo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_activo.Size = New System.Drawing.Size(550, 58)
        Me.bloque_activo.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_activo.Name = "etiqueta_activo"
        Me.etiqueta_activo.Text = "Estado"
        Me.etiqueta_activo.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_activo.AutoSize = False
        Me.etiqueta_activo.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_activo.Height = 24
        Me.etiqueta_activo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.activo.Dock = System.Windows.Forms.DockStyle.Top
        Me.activo.Height = 30
        Me.bloque_activo.Controls.Add(Me.activo)
        Me.bloque_activo.Controls.Add(Me.etiqueta_activo)
        Me.camposEditor.Controls.Add(Me.bloque_activo)
        Me.accionesEditor.Name = "accionesEditor"
        Me.accionesEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.accionesEditor.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.accionesEditor.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.guardar.Name = "guardar"
        Me.guardar.Text = "Guardar"
        Me.guardar.Size = New System.Drawing.Size(170, 38)
        Me.guardar.AutoSize = False
        Me.guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.guardar.FlatAppearance.BorderSize = 0
        Me.guardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.guardar.BackColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.guardar.ForeColor = System.Drawing.Color.White
        Me.guardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.guardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.guardar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.guardar.UseVisualStyleBackColor = False
        Me.guardar.Width = 155
        Me.cancelar.Name = "cancelar"
        Me.cancelar.Text = "Cancelar"
        Me.cancelar.Size = New System.Drawing.Size(170, 38)
        Me.cancelar.AutoSize = False
        Me.cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelar.FlatAppearance.BorderSize = 1
        Me.cancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.cancelar.BackColor = System.Drawing.Color.White
        Me.cancelar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.cancelar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cancelar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.cancelar.UseVisualStyleBackColor = False
        Me.cancelar.Width = 140
        Me.cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.accionesEditor.Controls.Add(Me.guardar)
        Me.accionesEditor.Controls.Add(Me.cancelar)
        Me.cuerpoEditor.Controls.Add(Me.camposEditor)
        Me.layoutEditor.Controls.Add(Me.encabezado, 0, 0)
        Me.layoutEditor.Controls.Add(Me.cuerpoEditor, 0, 1)
        Me.layoutEditor.Controls.Add(Me.accionesEditor, 0, 2)
        Me.Controls.Add(Me.layoutEditor)
        Me.AcceptButton = Me.guardar
        Me.CancelButton = Me.cancelar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(660, 492)
        Me.Name = "frmPenalizacionEditar"
        Me.Text = Me.lblTituloVista.Text
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.MinimumSize = New System.Drawing.Size(500, 360)
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.monto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accionesEditor.ResumeLayout(False)
        Me.accionesEditor.PerformLayout()
        Me.bloque_activo.ResumeLayout(False)
        Me.bloque_activo.PerformLayout()
        Me.bloque_descripcion.ResumeLayout(False)
        Me.bloque_descripcion.PerformLayout()
        Me.bloque_monto.ResumeLayout(False)
        Me.bloque_monto.PerformLayout()
        Me.bloque_tipo.ResumeLayout(False)
        Me.bloque_tipo.PerformLayout()
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
    Friend WithEvents tipo As System.Windows.Forms.TextBox
    Friend WithEvents bloque_tipo As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_tipo As System.Windows.Forms.Label
    Friend WithEvents monto As System.Windows.Forms.NumericUpDown
    Friend WithEvents bloque_monto As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_monto As System.Windows.Forms.Label
    Friend WithEvents descripcion As System.Windows.Forms.TextBox
    Friend WithEvents bloque_descripcion As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_descripcion As System.Windows.Forms.Label
    Friend WithEvents activo As System.Windows.Forms.CheckBox
    Friend WithEvents bloque_activo As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_activo As System.Windows.Forms.Label
    Friend WithEvents accionesEditor As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents cancelar As System.Windows.Forms.Button
End Class
