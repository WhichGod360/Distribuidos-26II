<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEjemplarDetalle
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
        Me.libro = New System.Windows.Forms.TextBox()
        Me.bloque_libro = New System.Windows.Forms.Panel()
        Me.etiqueta_libro = New System.Windows.Forms.Label()
        Me.estado = New System.Windows.Forms.Label()
        Me.bloque_estado = New System.Windows.Forms.Panel()
        Me.etiqueta_estado = New System.Windows.Forms.Label()
        Me.accionesEditor = New System.Windows.Forms.FlowLayoutPanel()
        Me.guardar = New System.Windows.Forms.Button()
        Me.cancelar = New System.Windows.Forms.Button()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutEditor.SuspendLayout()
        Me.cuerpoEditor.SuspendLayout()
        Me.camposEditor.SuspendLayout()
        Me.bloque_libro.SuspendLayout()
        Me.bloque_estado.SuspendLayout()
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
        Me.lblTituloVista.Text = "Agregar ejemplar"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Registra una nueva copia física del libro."
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
        Me.libro.Name = "libro"
        Me.libro.ReadOnly = True
        Me.libro.PlaceholderText = "Libro seleccionado en el catálogo"
        Me.bloque_libro.Name = "bloque_libro"
        Me.bloque_libro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_libro.Size = New System.Drawing.Size(550, 58)
        Me.bloque_libro.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_libro.Name = "etiqueta_libro"
        Me.etiqueta_libro.Text = "Libro"
        Me.etiqueta_libro.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.etiqueta_libro.AutoSize = False
        Me.etiqueta_libro.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_libro.Height = 24
        Me.etiqueta_libro.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.libro.Dock = System.Windows.Forms.DockStyle.Top
        Me.libro.Height = 30
        Me.bloque_libro.Controls.Add(Me.libro)
        Me.bloque_libro.Controls.Add(Me.etiqueta_libro)
        Me.camposEditor.Controls.Add(Me.bloque_libro)
        Me.estado.Name = "estado"
        Me.estado.Text = "Se registrará un ejemplar habilitado."
        Me.bloque_estado.Name = "bloque_estado"
        Me.bloque_estado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_estado.Size = New System.Drawing.Size(550, 58)
        Me.bloque_estado.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_estado.Name = "etiqueta_estado"
        Me.etiqueta_estado.Text = "Estado inicial"
        Me.etiqueta_estado.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.etiqueta_estado.AutoSize = False
        Me.etiqueta_estado.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_estado.Height = 24
        Me.etiqueta_estado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.estado.Dock = System.Windows.Forms.DockStyle.Top
        Me.estado.Height = 30
        Me.bloque_estado.Controls.Add(Me.estado)
        Me.bloque_estado.Controls.Add(Me.etiqueta_estado)
        Me.camposEditor.Controls.Add(Me.bloque_estado)
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
        Me.guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.guardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(35, 56, 72)
        Me.guardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 231)
        Me.guardar.BackColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.guardar.ForeColor = System.Drawing.Color.White
        Me.guardar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
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
        Me.cancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 244, 247)
        Me.cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(225, 232, 238)
        Me.cancelar.BackColor = System.Drawing.Color.White
        Me.cancelar.ForeColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.cancelar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(660, 318)
        Me.Name = "frmEjemplarDetalle"
        Me.Text = "Agregar ejemplar"
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.MinimumSize = New System.Drawing.Size(500, 360)
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accionesEditor.ResumeLayout(False)
        Me.accionesEditor.PerformLayout()
        Me.bloque_estado.ResumeLayout(False)
        Me.bloque_estado.PerformLayout()
        Me.bloque_libro.ResumeLayout(False)
        Me.bloque_libro.PerformLayout()
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
    Friend WithEvents libro As System.Windows.Forms.TextBox
    Friend WithEvents bloque_libro As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_libro As System.Windows.Forms.Label
    Friend WithEvents estado As System.Windows.Forms.Label
    Friend WithEvents bloque_estado As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_estado As System.Windows.Forms.Label
    Friend WithEvents accionesEditor As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents cancelar As System.Windows.Forms.Button
End Class
