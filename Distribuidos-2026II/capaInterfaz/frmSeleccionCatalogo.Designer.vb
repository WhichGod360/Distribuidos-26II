<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSeleccionCatalogo
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
        Me.opciones = New System.Windows.Forms.ComboBox()
        Me.bloque_opciones = New System.Windows.Forms.Panel()
        Me.etiqueta_opciones = New System.Windows.Forms.Label()
        Me.accionesEditor = New System.Windows.Forms.FlowLayoutPanel()
        Me.aceptar = New System.Windows.Forms.Button()
        Me.cancelar = New System.Windows.Forms.Button()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutEditor.SuspendLayout()
        Me.cuerpoEditor.SuspendLayout()
        Me.camposEditor.SuspendLayout()
        Me.bloque_opciones.SuspendLayout()
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
        Me.lblTituloVista.Text = "Seleccionar registro"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Selecciona un registro existente del catálogo."
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
        Me.camposEditor.RowCount = 1
        Me.camposEditor.ColumnCount = 1
        Me.camposEditor.Margin = New System.Windows.Forms.Padding(0)
        Me.camposEditor.AutoSize = True
        Me.camposEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.opciones.Name = "opciones"
        Me.opciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.bloque_opciones.Name = "bloque_opciones"
        Me.bloque_opciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_opciones.Size = New System.Drawing.Size(550, 58)
        Me.bloque_opciones.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_opciones.Name = "etiqueta_opciones"
        Me.etiqueta_opciones.Text = "Registro"
        Me.etiqueta_opciones.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.etiqueta_opciones.AutoSize = False
        Me.etiqueta_opciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_opciones.Height = 24
        Me.etiqueta_opciones.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.opciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.opciones.Height = 30
        Me.bloque_opciones.Controls.Add(Me.opciones)
        Me.bloque_opciones.Controls.Add(Me.etiqueta_opciones)
        Me.camposEditor.Controls.Add(Me.bloque_opciones)
        Me.accionesEditor.Name = "accionesEditor"
        Me.accionesEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.accionesEditor.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.accionesEditor.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.aceptar.Name = "aceptar"
        Me.aceptar.Text = "Guardar"
        Me.aceptar.Size = New System.Drawing.Size(170, 38)
        Me.aceptar.AutoSize = False
        Me.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aceptar.FlatAppearance.BorderSize = 0
        Me.aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(35, 56, 72)
        Me.aceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 231)
        Me.aceptar.BackColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.aceptar.ForeColor = System.Drawing.Color.White
        Me.aceptar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
        Me.aceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.aceptar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.aceptar.UseVisualStyleBackColor = False
        Me.aceptar.Width = 155
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
        Me.accionesEditor.Controls.Add(Me.aceptar)
        Me.accionesEditor.Controls.Add(Me.cancelar)
        Me.cuerpoEditor.Controls.Add(Me.camposEditor)
        Me.layoutEditor.Controls.Add(Me.encabezado, 0, 0)
        Me.layoutEditor.Controls.Add(Me.cuerpoEditor, 0, 1)
        Me.layoutEditor.Controls.Add(Me.accionesEditor, 0, 2)
        Me.Controls.Add(Me.layoutEditor)
        Me.AcceptButton = Me.aceptar
        Me.CancelButton = Me.cancelar
        Me.aceptar.Text = "Seleccionar"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(660, 254)
        Me.Name = "frmSeleccionCatalogo"
        Me.Text = "Seleccionar registro"
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.MinimumSize = New System.Drawing.Size(500, 360)
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accionesEditor.ResumeLayout(False)
        Me.accionesEditor.PerformLayout()
        Me.bloque_opciones.ResumeLayout(False)
        Me.bloque_opciones.PerformLayout()
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
    Friend WithEvents opciones As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_opciones As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_opciones As System.Windows.Forms.Label
    Friend WithEvents accionesEditor As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents aceptar As System.Windows.Forms.Button
    Friend WithEvents cancelar As System.Windows.Forms.Button
End Class
