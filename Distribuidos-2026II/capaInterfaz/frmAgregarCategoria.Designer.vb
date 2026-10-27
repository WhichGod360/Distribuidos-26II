<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAgregarCategoria
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
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.bloque_txtNombre = New System.Windows.Forms.Panel()
        Me.etiqueta_txtNombre = New System.Windows.Forms.Label()
        Me.chkEstado = New System.Windows.Forms.CheckBox()
        Me.bloque_chkEstado = New System.Windows.Forms.Panel()
        Me.etiqueta_chkEstado = New System.Windows.Forms.Label()
        Me.accionesEditor = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutEditor.SuspendLayout()
        Me.cuerpoEditor.SuspendLayout()
        Me.camposEditor.SuspendLayout()
        Me.bloque_txtNombre.SuspendLayout()
        Me.bloque_chkEstado.SuspendLayout()
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
        Me.lblTituloVista.Text = "Agregar categoría"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Completa el nombre y el estado de la categoría."
        Me.lblDescripcionVista.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120)
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
        Me.camposEditor.RowCount = 2
        Me.camposEditor.ColumnCount = 1
        Me.camposEditor.Margin = New System.Windows.Forms.Padding(0)
        Me.camposEditor.AutoSize = True
        Me.camposEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.MaxLength = 30
        Me.bloque_txtNombre.Name = "bloque_txtNombre"
        Me.bloque_txtNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_txtNombre.Size = New System.Drawing.Size(550, 58)
        Me.bloque_txtNombre.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_txtNombre.Name = "etiqueta_txtNombre"
        Me.etiqueta_txtNombre.Text = "Nombre"
        Me.etiqueta_txtNombre.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.etiqueta_txtNombre.AutoSize = False
        Me.etiqueta_txtNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_txtNombre.Height = 24
        Me.etiqueta_txtNombre.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.txtNombre.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtNombre.Height = 30
        Me.bloque_txtNombre.Controls.Add(Me.txtNombre)
        Me.bloque_txtNombre.Controls.Add(Me.etiqueta_txtNombre)
        Me.camposEditor.Controls.Add(Me.bloque_txtNombre)
        Me.chkEstado.Name = "chkEstado"
        Me.chkEstado.Text = "Activo"
        Me.chkEstado.Checked = True
        Me.bloque_chkEstado.Name = "bloque_chkEstado"
        Me.bloque_chkEstado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_chkEstado.Size = New System.Drawing.Size(550, 58)
        Me.bloque_chkEstado.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_chkEstado.Name = "etiqueta_chkEstado"
        Me.etiqueta_chkEstado.Text = "Estado"
        Me.etiqueta_chkEstado.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.etiqueta_chkEstado.AutoSize = False
        Me.etiqueta_chkEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_chkEstado.Height = 24
        Me.etiqueta_chkEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.chkEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkEstado.Height = 30
        Me.bloque_chkEstado.Controls.Add(Me.chkEstado)
        Me.bloque_chkEstado.Controls.Add(Me.etiqueta_chkEstado)
        Me.camposEditor.Controls.Add(Me.bloque_chkEstado)
        Me.accionesEditor.Name = "accionesEditor"
        Me.accionesEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.accionesEditor.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.accionesEditor.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.Button10.Name = "Button10"
        Me.Button10.Text = "Guardar"
        Me.Button10.Size = New System.Drawing.Size(170, 38)
        Me.Button10.AutoSize = False
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.Button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(35, 56, 72)
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 231)
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.Button10.ForeColor = System.Drawing.Color.White
        Me.Button10.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.Button10.UseVisualStyleBackColor = False
        Me.Button10.Width = 155
        Me.Button11.Name = "Button11"
        Me.Button11.Text = "Cancelar"
        Me.Button11.Size = New System.Drawing.Size(170, 38)
        Me.Button11.AutoSize = False
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.FlatAppearance.BorderSize = 1
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.Button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 244, 247)
        Me.Button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(225, 232, 238)
        Me.Button11.BackColor = System.Drawing.Color.White
        Me.Button11.ForeColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.Button11.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.Button11.UseVisualStyleBackColor = False
        Me.Button11.Width = 140
        Me.Button11.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.accionesEditor.Controls.Add(Me.Button10)
        Me.accionesEditor.Controls.Add(Me.Button11)
        Me.cuerpoEditor.Controls.Add(Me.camposEditor)
        Me.layoutEditor.Controls.Add(Me.encabezado, 0, 0)
        Me.layoutEditor.Controls.Add(Me.cuerpoEditor, 0, 1)
        Me.layoutEditor.Controls.Add(Me.accionesEditor, 0, 2)
        Me.Controls.Add(Me.layoutEditor)
        Me.AcceptButton = Me.Button10
        Me.CancelButton = Me.Button11
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(660, 318)
        Me.Name = "frmAgregarCategoria"
        Me.Text = "Agregar categoría"
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.MinimumSize = New System.Drawing.Size(500, 360)
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accionesEditor.ResumeLayout(False)
        Me.accionesEditor.PerformLayout()
        Me.bloque_chkEstado.ResumeLayout(False)
        Me.bloque_chkEstado.PerformLayout()
        Me.bloque_txtNombre.ResumeLayout(False)
        Me.bloque_txtNombre.PerformLayout()
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
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents bloque_txtNombre As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_txtNombre As System.Windows.Forms.Label
    Friend WithEvents chkEstado As System.Windows.Forms.CheckBox
    Friend WithEvents bloque_chkEstado As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_chkEstado As System.Windows.Forms.Label
    Friend WithEvents accionesEditor As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
End Class
