<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrestamoDetalle
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
        Me.busqueda = New System.Windows.Forms.Panel()
        Me.bloque_busqueda = New System.Windows.Forms.Panel()
        Me.etiqueta_busqueda = New System.Windows.Forms.Label()
        Me.lector = New System.Windows.Forms.ComboBox()
        Me.bloque_lector = New System.Windows.Forms.Panel()
        Me.etiqueta_lector = New System.Windows.Forms.Label()
        Me.libro = New System.Windows.Forms.ComboBox()
        Me.bloque_libro = New System.Windows.Forms.Panel()
        Me.etiqueta_libro = New System.Windows.Forms.Label()
        Me.ejemplar = New System.Windows.Forms.ComboBox()
        Me.bloque_ejemplar = New System.Windows.Forms.Panel()
        Me.etiqueta_ejemplar = New System.Windows.Forms.Label()
        Me.inicio = New System.Windows.Forms.DateTimePicker()
        Me.bloque_inicio = New System.Windows.Forms.Panel()
        Me.etiqueta_inicio = New System.Windows.Forms.Label()
        Me.limite = New System.Windows.Forms.DateTimePicker()
        Me.bloque_limite = New System.Windows.Forms.Panel()
        Me.etiqueta_limite = New System.Windows.Forms.Label()
        Me.lblPlazo = New System.Windows.Forms.Label()
        Me.bloque_lblPlazo = New System.Windows.Forms.Panel()
        Me.etiqueta_lblPlazo = New System.Windows.Forms.Label()
        Me.accionesEditor = New System.Windows.Forms.FlowLayoutPanel()
        Me.guardar = New System.Windows.Forms.Button()
        Me.cancelar = New System.Windows.Forms.Button()
        Me.buscar = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutEditor.SuspendLayout()
        Me.cuerpoEditor.SuspendLayout()
        Me.camposEditor.SuspendLayout()
        Me.bloque_txtBibliotecario.SuspendLayout()
        Me.busqueda.SuspendLayout()
        Me.bloque_busqueda.SuspendLayout()
        Me.bloque_lector.SuspendLayout()
        Me.bloque_libro.SuspendLayout()
        Me.bloque_ejemplar.SuspendLayout()
        Me.bloque_inicio.SuspendLayout()
        Me.bloque_limite.SuspendLayout()
        Me.bloque_lblPlazo.SuspendLayout()
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
        Me.lblTituloVista.Text = "Nuevo préstamo"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Selecciona al lector y una copia física disponible."
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
        Me.camposEditor.RowCount = 8
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
        Me.etiqueta_txtBibliotecario.Text = "Bibliotecario"
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
        Me.busqueda.Name = "busqueda"
        Me.bloque_busqueda.Name = "bloque_busqueda"
        Me.bloque_busqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_busqueda.Size = New System.Drawing.Size(550, 58)
        Me.bloque_busqueda.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_busqueda.Name = "etiqueta_busqueda"
        Me.etiqueta_busqueda.Text = "Buscar lector activo (rol Estudiante)"
        Me.etiqueta_busqueda.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_busqueda.AutoSize = False
        Me.etiqueta_busqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_busqueda.Height = 24
        Me.etiqueta_busqueda.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.busqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.busqueda.Height = 30
        Me.bloque_busqueda.Controls.Add(Me.busqueda)
        Me.bloque_busqueda.Controls.Add(Me.etiqueta_busqueda)
        Me.camposEditor.Controls.Add(Me.bloque_busqueda)
        Me.lector.Name = "lector"
        Me.lector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lector.DropDownWidth = 850
        Me.bloque_lector.Name = "bloque_lector"
        Me.bloque_lector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_lector.Size = New System.Drawing.Size(550, 58)
        Me.bloque_lector.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_lector.Name = "etiqueta_lector"
        Me.etiqueta_lector.Text = "Lector · DNI · correo"
        Me.etiqueta_lector.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_lector.AutoSize = False
        Me.etiqueta_lector.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_lector.Height = 24
        Me.etiqueta_lector.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lector.Dock = System.Windows.Forms.DockStyle.Top
        Me.lector.Height = 30
        Me.bloque_lector.Controls.Add(Me.lector)
        Me.bloque_lector.Controls.Add(Me.etiqueta_lector)
        Me.camposEditor.Controls.Add(Me.bloque_lector)
        Me.libro.Name = "libro"
        Me.libro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.libro.DropDownWidth = 850
        Me.bloque_libro.Name = "bloque_libro"
        Me.bloque_libro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_libro.Size = New System.Drawing.Size(550, 58)
        Me.bloque_libro.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_libro.Name = "etiqueta_libro"
        Me.etiqueta_libro.Text = "Libro habilitado"
        Me.etiqueta_libro.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_libro.AutoSize = False
        Me.etiqueta_libro.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_libro.Height = 24
        Me.etiqueta_libro.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.libro.Dock = System.Windows.Forms.DockStyle.Top
        Me.libro.Height = 30
        Me.bloque_libro.Controls.Add(Me.libro)
        Me.bloque_libro.Controls.Add(Me.etiqueta_libro)
        Me.camposEditor.Controls.Add(Me.bloque_libro)
        Me.ejemplar.Name = "ejemplar"
        Me.ejemplar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.bloque_ejemplar.Name = "bloque_ejemplar"
        Me.bloque_ejemplar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_ejemplar.Size = New System.Drawing.Size(550, 58)
        Me.bloque_ejemplar.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_ejemplar.Name = "etiqueta_ejemplar"
        Me.etiqueta_ejemplar.Text = "Ejemplar disponible"
        Me.etiqueta_ejemplar.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_ejemplar.AutoSize = False
        Me.etiqueta_ejemplar.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_ejemplar.Height = 24
        Me.etiqueta_ejemplar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.ejemplar.Dock = System.Windows.Forms.DockStyle.Top
        Me.ejemplar.Height = 30
        Me.bloque_ejemplar.Controls.Add(Me.ejemplar)
        Me.bloque_ejemplar.Controls.Add(Me.etiqueta_ejemplar)
        Me.camposEditor.Controls.Add(Me.bloque_ejemplar)
        Me.inicio.Name = "inicio"
        Me.inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.bloque_inicio.Name = "bloque_inicio"
        Me.bloque_inicio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_inicio.Size = New System.Drawing.Size(550, 58)
        Me.bloque_inicio.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_inicio.Name = "etiqueta_inicio"
        Me.etiqueta_inicio.Text = "Fecha de inicio"
        Me.etiqueta_inicio.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_inicio.AutoSize = False
        Me.etiqueta_inicio.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_inicio.Height = 24
        Me.etiqueta_inicio.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.inicio.Dock = System.Windows.Forms.DockStyle.Top
        Me.inicio.Height = 30
        Me.bloque_inicio.Controls.Add(Me.inicio)
        Me.bloque_inicio.Controls.Add(Me.etiqueta_inicio)
        Me.camposEditor.Controls.Add(Me.bloque_inicio)
        Me.limite.Name = "limite"
        Me.limite.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.limite.ShowCheckBox = False
        Me.limite.Enabled = False
        Me.bloque_limite.Name = "bloque_limite"
        Me.bloque_limite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_limite.Size = New System.Drawing.Size(550, 58)
        Me.bloque_limite.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_limite.Name = "etiqueta_limite"
        Me.etiqueta_limite.Text = "Fecha límite automática: inicio + 5 días"
        Me.etiqueta_limite.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_limite.AutoSize = False
        Me.etiqueta_limite.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_limite.Height = 24
        Me.etiqueta_limite.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.limite.Dock = System.Windows.Forms.DockStyle.Top
        Me.limite.Height = 30
        Me.bloque_limite.Controls.Add(Me.limite)
        Me.bloque_limite.Controls.Add(Me.etiqueta_limite)
        Me.camposEditor.Controls.Add(Me.bloque_limite)
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Text = "5 días · Máximo 1 ejemplar por lector · Sin penalizaciones pendientes"
        Me.lblPlazo.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.bloque_lblPlazo.Name = "bloque_lblPlazo"
        Me.bloque_lblPlazo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bloque_lblPlazo.Size = New System.Drawing.Size(550, 58)
        Me.bloque_lblPlazo.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_lblPlazo.Name = "etiqueta_lblPlazo"
        Me.etiqueta_lblPlazo.Text = "Plazo"
        Me.etiqueta_lblPlazo.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_lblPlazo.AutoSize = False
        Me.etiqueta_lblPlazo.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_lblPlazo.Height = 24
        Me.etiqueta_lblPlazo.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.lblPlazo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPlazo.Height = 30
        Me.bloque_lblPlazo.Controls.Add(Me.lblPlazo)
        Me.bloque_lblPlazo.Controls.Add(Me.etiqueta_lblPlazo)
        Me.camposEditor.Controls.Add(Me.bloque_lblPlazo)
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
        Me.buscar.Name = "buscar"
        Me.buscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buscar.PlaceholderText = "Nombre, apellido, DNI o correo"
        Me.buscar.MaxLength = 300
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar lectores"
        Me.btnBuscar.Size = New System.Drawing.Size(170, 38)
        Me.btnBuscar.AutoSize = False
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.FlatAppearance.BorderSize = 1
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnBuscar.BackColor = System.Drawing.Color.White
        Me.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnBuscar.UseVisualStyleBackColor = False
        Me.btnBuscar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnBuscar.Width = 155
        Me.busqueda.Controls.Add(Me.buscar)
        Me.busqueda.Controls.Add(Me.btnBuscar)
        Me.guardar.Text = "Registrar"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(660, 702)
        Me.Name = "frmPrestamoDetalle"
        Me.Text = "Nuevo préstamo"
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.MinimumSize = New System.Drawing.Size(500, 360)
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accionesEditor.ResumeLayout(False)
        Me.accionesEditor.PerformLayout()
        Me.bloque_lblPlazo.ResumeLayout(False)
        Me.bloque_lblPlazo.PerformLayout()
        Me.bloque_limite.ResumeLayout(False)
        Me.bloque_limite.PerformLayout()
        Me.bloque_inicio.ResumeLayout(False)
        Me.bloque_inicio.PerformLayout()
        Me.bloque_ejemplar.ResumeLayout(False)
        Me.bloque_ejemplar.PerformLayout()
        Me.bloque_libro.ResumeLayout(False)
        Me.bloque_libro.PerformLayout()
        Me.bloque_lector.ResumeLayout(False)
        Me.bloque_lector.PerformLayout()
        Me.bloque_busqueda.ResumeLayout(False)
        Me.bloque_busqueda.PerformLayout()
        Me.busqueda.ResumeLayout(False)
        Me.busqueda.PerformLayout()
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
    Friend WithEvents busqueda As System.Windows.Forms.Panel
    Friend WithEvents bloque_busqueda As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_busqueda As System.Windows.Forms.Label
    Friend WithEvents lector As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_lector As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_lector As System.Windows.Forms.Label
    Friend WithEvents libro As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_libro As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_libro As System.Windows.Forms.Label
    Friend WithEvents ejemplar As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_ejemplar As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_ejemplar As System.Windows.Forms.Label
    Friend WithEvents inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents bloque_inicio As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_inicio As System.Windows.Forms.Label
    Friend WithEvents limite As System.Windows.Forms.DateTimePicker
    Friend WithEvents bloque_limite As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_limite As System.Windows.Forms.Label
    Friend WithEvents lblPlazo As System.Windows.Forms.Label
    Friend WithEvents bloque_lblPlazo As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_lblPlazo As System.Windows.Forms.Label
    Friend WithEvents accionesEditor As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents cancelar As System.Windows.Forms.Button
    Friend WithEvents buscar As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
