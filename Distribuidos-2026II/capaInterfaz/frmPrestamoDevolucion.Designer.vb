<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrestamoDevolucion
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
        Me.txtBibliotecario = New System.Windows.Forms.TextBox()
        Me.bloque_txtBibliotecario = New System.Windows.Forms.Panel()
        Me.etiqueta_txtBibliotecario = New System.Windows.Forms.Label()
        Me.txtPrestamo = New System.Windows.Forms.TextBox()
        Me.bloque_txtPrestamo = New System.Windows.Forms.Panel()
        Me.etiqueta_txtPrestamo = New System.Windows.Forms.Label()
        Me.txtEjemplar = New System.Windows.Forms.TextBox()
        Me.bloque_txtEjemplar = New System.Windows.Forms.Panel()
        Me.etiqueta_txtEjemplar = New System.Windows.Forms.Label()
        Me.lblFechas = New System.Windows.Forms.Label()
        Me.bloque_lblFechas = New System.Windows.Forms.Panel()
        Me.etiqueta_lblFechas = New System.Windows.Forms.Label()
        Me.retorno = New System.Windows.Forms.DateTimePicker()
        Me.bloque_retorno = New System.Windows.Forms.Panel()
        Me.etiqueta_retorno = New System.Windows.Forms.Label()
        Me.retraso = New System.Windows.Forms.Label()
        Me.bloque_retraso = New System.Windows.Forms.Panel()
        Me.etiqueta_retraso = New System.Windows.Forms.Label()
        Me.accionesEditor = New System.Windows.Forms.FlowLayoutPanel()
        Me.guardar = New System.Windows.Forms.Button()
        Me.cancelar = New System.Windows.Forms.Button()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutEditor.SuspendLayout()
        Me.cuerpoEditor.SuspendLayout()
        Me.camposEditor.SuspendLayout()
        Me.bloque_txtBibliotecario.SuspendLayout()
        Me.bloque_txtPrestamo.SuspendLayout()
        Me.bloque_txtEjemplar.SuspendLayout()
        Me.bloque_lblFechas.SuspendLayout()
        Me.bloque_retorno.SuspendLayout()
        Me.bloque_retraso.SuspendLayout()
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
        Me.lblTituloVista.Text = "Registrar devolución"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Confirma la fecha real de devolución de la copia."
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
        Me.camposEditor.RowCount = 6
        Me.camposEditor.ColumnCount = 1
        Me.camposEditor.Margin = New System.Windows.Forms.Padding(0)
        Me.camposEditor.AutoSize = True
        Me.camposEditor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.camposEditor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.txtBibliotecario.Name = "txtBibliotecario"
        Me.txtBibliotecario.ReadOnly = True
        Me.txtBibliotecario.PlaceholderText = "Cuenta autenticada"
        Me.bloque_txtBibliotecario.Name = "bloque_txtBibliotecario"
        Me.bloque_txtBibliotecario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_txtBibliotecario.Size = New System.Drawing.Size(550, 58)
        Me.bloque_txtBibliotecario.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_txtBibliotecario.Name = "etiqueta_txtBibliotecario"
        Me.etiqueta_txtBibliotecario.Text = "Bibliotecario que realiza la operación"
        Me.etiqueta_txtBibliotecario.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_txtBibliotecario.AutoSize = False
        Me.etiqueta_txtBibliotecario.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_txtBibliotecario.Height = 24
        Me.etiqueta_txtBibliotecario.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtBibliotecario.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtBibliotecario.Height = 30
        Me.bloque_txtBibliotecario.Controls.Add(Me.txtBibliotecario)
        Me.bloque_txtBibliotecario.Controls.Add(Me.etiqueta_txtBibliotecario)
        Me.camposEditor.Controls.Add(Me.bloque_txtBibliotecario)
        Me.txtPrestamo.Name = "txtPrestamo"
        Me.txtPrestamo.ReadOnly = True
        Me.txtPrestamo.PlaceholderText = "Selecciona un préstamo en el listado"
        Me.bloque_txtPrestamo.Name = "bloque_txtPrestamo"
        Me.bloque_txtPrestamo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_txtPrestamo.Size = New System.Drawing.Size(550, 58)
        Me.bloque_txtPrestamo.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_txtPrestamo.Name = "etiqueta_txtPrestamo"
        Me.etiqueta_txtPrestamo.Text = "Préstamo y lector"
        Me.etiqueta_txtPrestamo.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_txtPrestamo.AutoSize = False
        Me.etiqueta_txtPrestamo.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_txtPrestamo.Height = 24
        Me.etiqueta_txtPrestamo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtPrestamo.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtPrestamo.Height = 30
        Me.bloque_txtPrestamo.Controls.Add(Me.txtPrestamo)
        Me.bloque_txtPrestamo.Controls.Add(Me.etiqueta_txtPrestamo)
        Me.camposEditor.Controls.Add(Me.bloque_txtPrestamo)
        Me.txtEjemplar.Name = "txtEjemplar"
        Me.txtEjemplar.ReadOnly = True
        Me.bloque_txtEjemplar.Name = "bloque_txtEjemplar"
        Me.bloque_txtEjemplar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_txtEjemplar.Size = New System.Drawing.Size(550, 58)
        Me.bloque_txtEjemplar.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_txtEjemplar.Name = "etiqueta_txtEjemplar"
        Me.etiqueta_txtEjemplar.Text = "Ejemplar y libro"
        Me.etiqueta_txtEjemplar.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_txtEjemplar.AutoSize = False
        Me.etiqueta_txtEjemplar.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_txtEjemplar.Height = 24
        Me.etiqueta_txtEjemplar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtEjemplar.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtEjemplar.Height = 30
        Me.bloque_txtEjemplar.Controls.Add(Me.txtEjemplar)
        Me.bloque_txtEjemplar.Controls.Add(Me.etiqueta_txtEjemplar)
        Me.camposEditor.Controls.Add(Me.bloque_txtEjemplar)
        Me.lblFechas.Name = "lblFechas"
        Me.bloque_lblFechas.Name = "bloque_lblFechas"
        Me.bloque_lblFechas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_lblFechas.Size = New System.Drawing.Size(550, 58)
        Me.bloque_lblFechas.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_lblFechas.Name = "etiqueta_lblFechas"
        Me.etiqueta_lblFechas.Text = "Inicio y fecha límite"
        Me.etiqueta_lblFechas.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_lblFechas.AutoSize = False
        Me.etiqueta_lblFechas.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_lblFechas.Height = 24
        Me.etiqueta_lblFechas.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblFechas.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFechas.Height = 30
        Me.bloque_lblFechas.Controls.Add(Me.lblFechas)
        Me.bloque_lblFechas.Controls.Add(Me.etiqueta_lblFechas)
        Me.camposEditor.Controls.Add(Me.bloque_lblFechas)
        Me.retorno.Name = "retorno"
        Me.retorno.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.bloque_retorno.Name = "bloque_retorno"
        Me.bloque_retorno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_retorno.Size = New System.Drawing.Size(550, 58)
        Me.bloque_retorno.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_retorno.Name = "etiqueta_retorno"
        Me.etiqueta_retorno.Text = "Fecha real de devolución"
        Me.etiqueta_retorno.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_retorno.AutoSize = False
        Me.etiqueta_retorno.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_retorno.Height = 24
        Me.etiqueta_retorno.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.retorno.Dock = System.Windows.Forms.DockStyle.Top
        Me.retorno.Height = 30
        Me.bloque_retorno.Controls.Add(Me.retorno)
        Me.bloque_retorno.Controls.Add(Me.etiqueta_retorno)
        Me.camposEditor.Controls.Add(Me.bloque_retorno)
        Me.retraso.Name = "retraso"
        Me.retraso.Text = "—"
        Me.bloque_retraso.Name = "bloque_retraso"
        Me.bloque_retraso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_retraso.Size = New System.Drawing.Size(550, 58)
        Me.bloque_retraso.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_retraso.Name = "etiqueta_retraso"
        Me.etiqueta_retraso.Text = "Días de retraso"
        Me.etiqueta_retraso.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_retraso.AutoSize = False
        Me.etiqueta_retraso.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_retraso.Height = 24
        Me.etiqueta_retraso.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.retraso.Dock = System.Windows.Forms.DockStyle.Top
        Me.retraso.Height = 30
        Me.bloque_retraso.Controls.Add(Me.retraso)
        Me.bloque_retraso.Controls.Add(Me.etiqueta_retraso)
        Me.camposEditor.Controls.Add(Me.bloque_retraso)
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
        Me.guardar.Text = "Devolver"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(660, 574)
        Me.Name = "frmPrestamoDevolucion"
        Me.Text = Me.lblTituloVista.Text
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.MinimumSize = New System.Drawing.Size(500, 360)
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accionesEditor.ResumeLayout(False)
        Me.accionesEditor.PerformLayout()
        Me.bloque_retraso.ResumeLayout(False)
        Me.bloque_retraso.PerformLayout()
        Me.bloque_retorno.ResumeLayout(False)
        Me.bloque_retorno.PerformLayout()
        Me.bloque_lblFechas.ResumeLayout(False)
        Me.bloque_lblFechas.PerformLayout()
        Me.bloque_txtEjemplar.ResumeLayout(False)
        Me.bloque_txtEjemplar.PerformLayout()
        Me.bloque_txtPrestamo.ResumeLayout(False)
        Me.bloque_txtPrestamo.PerformLayout()
        Me.bloque_txtBibliotecario.ResumeLayout(False)
        Me.bloque_txtBibliotecario.PerformLayout()
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
    Friend WithEvents txtBibliotecario As System.Windows.Forms.TextBox
    Friend WithEvents bloque_txtBibliotecario As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_txtBibliotecario As System.Windows.Forms.Label
    Friend WithEvents txtPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents bloque_txtPrestamo As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_txtPrestamo As System.Windows.Forms.Label
    Friend WithEvents txtEjemplar As System.Windows.Forms.TextBox
    Friend WithEvents bloque_txtEjemplar As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_txtEjemplar As System.Windows.Forms.Label
    Friend WithEvents lblFechas As System.Windows.Forms.Label
    Friend WithEvents bloque_lblFechas As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_lblFechas As System.Windows.Forms.Label
    Friend WithEvents retorno As System.Windows.Forms.DateTimePicker
    Friend WithEvents bloque_retorno As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_retorno As System.Windows.Forms.Label
    Friend WithEvents retraso As System.Windows.Forms.Label
    Friend WithEvents bloque_retraso As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_retraso As System.Windows.Forms.Label
    Friend WithEvents accionesEditor As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents cancelar As System.Windows.Forms.Button
End Class
