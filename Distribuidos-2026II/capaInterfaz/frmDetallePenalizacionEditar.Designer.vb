<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDetallePenalizacionEditar
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
        Me.sancion = New System.Windows.Forms.ComboBox()
        Me.bloque_sancion = New System.Windows.Forms.Panel()
        Me.etiqueta_sancion = New System.Windows.Forms.Label()
        Me.prestamo = New System.Windows.Forms.ComboBox()
        Me.bloque_prestamo = New System.Windows.Forms.Panel()
        Me.etiqueta_prestamo = New System.Windows.Forms.Label()
        Me.descripcion = New System.Windows.Forms.TextBox()
        Me.bloque_descripcion = New System.Windows.Forms.Panel()
        Me.etiqueta_descripcion = New System.Windows.Forms.Label()
        Me.accionesEditor = New System.Windows.Forms.FlowLayoutPanel()
        Me.guardar = New System.Windows.Forms.Button()
        Me.cancelar = New System.Windows.Forms.Button()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutEditor.SuspendLayout()
        Me.cuerpoEditor.SuspendLayout()
        Me.camposEditor.SuspendLayout()
        Me.bloque_sancion.SuspendLayout()
        Me.bloque_prestamo.SuspendLayout()
        Me.bloque_descripcion.SuspendLayout()
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
        Me.lblTituloVista.Text = "Agregar detalle"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Vincula una penalización con un préstamo."
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
        Me.camposEditor.RowCount = 3
        Me.camposEditor.ColumnCount = 1
        Me.camposEditor.Margin = New System.Windows.Forms.Padding(0)
        Me.camposEditor.AutoSize = True
        Me.camposEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110!))
        Me.sancion.Name = "sancion"
        Me.sancion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sancion.DropDownWidth = 520
        Me.bloque_sancion.Name = "bloque_sancion"
        Me.bloque_sancion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_sancion.Size = New System.Drawing.Size(550, 58)
        Me.bloque_sancion.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_sancion.Name = "etiqueta_sancion"
        Me.etiqueta_sancion.Text = "Penalización"
        Me.etiqueta_sancion.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_sancion.AutoSize = False
        Me.etiqueta_sancion.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_sancion.Height = 24
        Me.etiqueta_sancion.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.sancion.Dock = System.Windows.Forms.DockStyle.Top
        Me.sancion.Height = 30
        Me.bloque_sancion.Controls.Add(Me.sancion)
        Me.bloque_sancion.Controls.Add(Me.etiqueta_sancion)
        Me.camposEditor.Controls.Add(Me.bloque_sancion)
        Me.prestamo.Name = "prestamo"
        Me.prestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.prestamo.DropDownWidth = 800
        Me.bloque_prestamo.Name = "bloque_prestamo"
        Me.bloque_prestamo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_prestamo.Size = New System.Drawing.Size(550, 58)
        Me.bloque_prestamo.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_prestamo.Name = "etiqueta_prestamo"
        Me.etiqueta_prestamo.Text = "Préstamo"
        Me.etiqueta_prestamo.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_prestamo.AutoSize = False
        Me.etiqueta_prestamo.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_prestamo.Height = 24
        Me.etiqueta_prestamo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.prestamo.Dock = System.Windows.Forms.DockStyle.Top
        Me.prestamo.Height = 30
        Me.bloque_prestamo.Controls.Add(Me.prestamo)
        Me.bloque_prestamo.Controls.Add(Me.etiqueta_prestamo)
        Me.camposEditor.Controls.Add(Me.bloque_prestamo)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(660, 428)
        Me.Name = "frmDetallePenalizacionEditar"
        Me.Text = "Agregar detalle"
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.MinimumSize = New System.Drawing.Size(500, 360)
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accionesEditor.ResumeLayout(False)
        Me.accionesEditor.PerformLayout()
        Me.bloque_descripcion.ResumeLayout(False)
        Me.bloque_descripcion.PerformLayout()
        Me.bloque_prestamo.ResumeLayout(False)
        Me.bloque_prestamo.PerformLayout()
        Me.bloque_sancion.ResumeLayout(False)
        Me.bloque_sancion.PerformLayout()
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
    Friend WithEvents sancion As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_sancion As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_sancion As System.Windows.Forms.Label
    Friend WithEvents prestamo As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_prestamo As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_prestamo As System.Windows.Forms.Label
    Friend WithEvents descripcion As System.Windows.Forms.TextBox
    Friend WithEvents bloque_descripcion As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_descripcion As System.Windows.Forms.Label
    Friend WithEvents accionesEditor As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents cancelar As System.Windows.Forms.Button
End Class
