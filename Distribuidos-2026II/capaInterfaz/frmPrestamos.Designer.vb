<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrestamos
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
        Me.layoutVista = New System.Windows.Forms.TableLayoutPanel()
        Me.barraFiltros = New System.Windows.Forms.FlowLayoutPanel()
        Me.buscar = New System.Windows.Forms.TextBox()
        Me.bloque_buscar = New System.Windows.Forms.Panel()
        Me.etiqueta_buscar = New System.Windows.Forms.Label()
        Me.filtroEstado = New System.Windows.Forms.ComboBox()
        Me.bloque_filtroEstado = New System.Windows.Forms.Panel()
        Me.etiqueta_filtroEstado = New System.Windows.Forms.Label()
        Me.barraAcciones = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnDevolver = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.tabla = New System.Windows.Forms.DataGridView()
        Me.colPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEjemplar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLibro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRetorno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCorreo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBibliotecario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.resumen = New System.Windows.Forms.Label()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutVista.SuspendLayout()
        Me.barraFiltros.SuspendLayout()
        Me.bloque_buscar.SuspendLayout()
        Me.bloque_filtroEstado.SuspendLayout()
        Me.barraAcciones.SuspendLayout()
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
        Me.lblTituloVista.Text = "Préstamos"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Préstamos y devoluciones de copias físicas."
        Me.lblDescripcionVista.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblDescripcionVista.AutoSize = False
        Me.lblDescripcionVista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textoEncabezado.Controls.Add(Me.lblDescripcionVista)
        Me.textoEncabezado.Controls.Add(Me.lblTituloVista)
        Me.encabezado.Controls.Add(Me.imagenModulo, 0, 0)
        Me.encabezado.Controls.Add(Me.textoEncabezado, 1, 0)
        Me.layoutVista.Name = "layoutVista"
        Me.layoutVista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutVista.RowCount = 5
        Me.layoutVista.ColumnCount = 1
        Me.layoutVista.Margin = New System.Windows.Forms.Padding(0)
        Me.layoutVista.Padding = New System.Windows.Forms.Padding(24, 18, 24, 12)
        Me.layoutVista.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.layoutVista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84!))
        Me.layoutVista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.layoutVista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.layoutVista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.layoutVista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36!))
        Me.barraFiltros.Name = "barraFiltros"
        Me.barraFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barraFiltros.AutoSize = True
        Me.barraFiltros.WrapContents = True
        Me.buscar.Name = "buscar"
        Me.buscar.PlaceholderText = "Buscar..."
        Me.bloque_buscar.Name = "bloque_buscar"
        Me.bloque_buscar.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_buscar.Size = New System.Drawing.Size(320, 58)
        Me.bloque_buscar.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_buscar.Name = "etiqueta_buscar"
        Me.etiqueta_buscar.Text = "Buscar"
        Me.etiqueta_buscar.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_buscar.AutoSize = False
        Me.etiqueta_buscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_buscar.Height = 24
        Me.etiqueta_buscar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.buscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.buscar.Height = 30
        Me.bloque_buscar.Controls.Add(Me.buscar)
        Me.bloque_buscar.Controls.Add(Me.etiqueta_buscar)
        Me.barraFiltros.Controls.Add(Me.bloque_buscar)
        Me.filtroEstado.Name = "filtroEstado"
        Me.filtroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.filtroEstado.Items.AddRange(New Object() {"Todos", "Activos", "Vencidos", "Devueltos"})
        Me.bloque_filtroEstado.Name = "bloque_filtroEstado"
        Me.bloque_filtroEstado.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_filtroEstado.Size = New System.Drawing.Size(180, 58)
        Me.bloque_filtroEstado.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_filtroEstado.Name = "etiqueta_filtroEstado"
        Me.etiqueta_filtroEstado.Text = "Estado"
        Me.etiqueta_filtroEstado.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_filtroEstado.AutoSize = False
        Me.etiqueta_filtroEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_filtroEstado.Height = 24
        Me.etiqueta_filtroEstado.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.filtroEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.filtroEstado.Height = 30
        Me.bloque_filtroEstado.Controls.Add(Me.filtroEstado)
        Me.bloque_filtroEstado.Controls.Add(Me.etiqueta_filtroEstado)
        Me.barraFiltros.Controls.Add(Me.bloque_filtroEstado)
        Me.barraAcciones.Name = "barraAcciones"
        Me.barraAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barraAcciones.AutoSize = True
        Me.barraAcciones.WrapContents = True
        Me.barraAcciones.Margin = New System.Windows.Forms.Padding(0, 4, 0, 10)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Text = "Nuevo préstamo"
        Me.btnNuevo.Size = New System.Drawing.Size(170, 38)
        Me.btnNuevo.AutoSize = False
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.FlatAppearance.BorderSize = 0
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnNuevo.ForeColor = System.Drawing.Color.White
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnNuevo.UseVisualStyleBackColor = False
        Me.btnNuevo.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnNuevo)
        Me.btnDevolver.Name = "btnDevolver"
        Me.btnDevolver.Text = "Registrar devolución"
        Me.btnDevolver.Size = New System.Drawing.Size(170, 38)
        Me.btnDevolver.AutoSize = False
        Me.btnDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDevolver.FlatAppearance.BorderSize = 1
        Me.btnDevolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnDevolver.BackColor = System.Drawing.Color.White
        Me.btnDevolver.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnDevolver.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDevolver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDevolver.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnDevolver.UseVisualStyleBackColor = False
        Me.btnDevolver.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnDevolver)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(170, 38)
        Me.btnActualizar.AutoSize = False
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.FlatAppearance.BorderSize = 1
        Me.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnActualizar.BackColor = System.Drawing.Color.White
        Me.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnActualizar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnActualizar.UseVisualStyleBackColor = False
        Me.btnActualizar.Enabled = True
        Me.barraAcciones.Controls.Add(Me.btnActualizar)
        Me.tabla.Name = "tabla"
        Me.tabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabla.ReadOnly = True
        Me.tabla.AllowUserToAddRows = False
        Me.tabla.AllowUserToDeleteRows = False
        Me.tabla.MultiSelect = False
        Me.tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tabla.RowHeadersVisible = False
        Me.tabla.AutoGenerateColumns = False
        Me.tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.tabla.BackgroundColor = System.Drawing.Color.White
        Me.tabla.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tabla.GridColor = System.Drawing.Color.FromArgb(231, 235, 246)
        Me.tabla.EnableHeadersVisualStyles = False
        Me.tabla.ColumnHeadersHeight = 40
        Me.tabla.RowTemplate.Height = 36
        Me.tabla.Margin = New System.Windows.Forms.Padding(0)
        Me.tabla.AccessibleName = "Tabla de resultados"
        Me.tabla.ColumnHeadersDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(234, 239, 255), .ForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)}
        Me.tabla.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.SelectionBackColor = System.Drawing.Color.FromArgb(222, 229, 255), .SelectionForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .NullValue = "—"}
        Me.tabla.AlternatingRowsDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(248, 250, 255)}
        Me.colPrestamo.Name = "IdPrestamo"
        Me.colPrestamo.HeaderText = "Préstamo"
        Me.colPrestamo.DataPropertyName = "IdPrestamo"
        Me.colPrestamo.Width = 75
        Me.colPrestamo.FillWeight = 75
        Me.colPrestamo.ReadOnly = True
        Me.colPrestamo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colPrestamo)
        Me.colLector.Name = "NombreLector"
        Me.colLector.HeaderText = "Lector"
        Me.colLector.DataPropertyName = "NombreLector"
        Me.colLector.Width = 190
        Me.colLector.FillWeight = 190
        Me.colLector.ReadOnly = True
        Me.colLector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colLector)
        Me.colEjemplar.Name = "IdEjemplar"
        Me.colEjemplar.HeaderText = "Ejemplar"
        Me.colEjemplar.DataPropertyName = "IdEjemplar"
        Me.colEjemplar.Width = 75
        Me.colEjemplar.FillWeight = 75
        Me.colEjemplar.ReadOnly = True
        Me.colEjemplar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colEjemplar)
        Me.colLibro.Name = "TituloLibro"
        Me.colLibro.HeaderText = "Libro"
        Me.colLibro.DataPropertyName = "TituloLibro"
        Me.colLibro.Width = 200
        Me.colLibro.FillWeight = 200
        Me.colLibro.ReadOnly = True
        Me.colLibro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colLibro)
        Me.colFin.Name = "FechaFin"
        Me.colFin.HeaderText = "Fecha límite"
        Me.colFin.DataPropertyName = "FechaFin"
        Me.colFin.Width = 100
        Me.colFin.FillWeight = 100
        Me.colFin.ReadOnly = True
        Me.colFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colFin.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.Format = "dd/MM/yyyy", .NullValue = "—"}
        Me.tabla.Columns.Add(Me.colFin)
        Me.colEstado.Name = "EstadoPrestamo"
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.DataPropertyName = "EstadoPrestamo"
        Me.colEstado.Width = 95
        Me.colEstado.FillWeight = 95
        Me.colEstado.ReadOnly = True
        Me.colEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colEstado)
        Me.colRetorno.Name = "FechaRetorno"
        Me.colRetorno.HeaderText = "Devolución"
        Me.colRetorno.DataPropertyName = "FechaRetorno"
        Me.colRetorno.Width = 100
        Me.colRetorno.FillWeight = 100
        Me.colRetorno.ReadOnly = True
        Me.colRetorno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colRetorno.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.Format = "dd/MM/yyyy", .NullValue = "—"}
        Me.tabla.Columns.Add(Me.colRetorno)
        Me.colDias.Name = "DiasRetraso"
        Me.colDias.HeaderText = "Días de retraso"
        Me.colDias.DataPropertyName = "DiasRetraso"
        Me.colDias.Width = 90
        Me.colDias.FillWeight = 90
        Me.colDias.ReadOnly = True
        Me.colDias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colDias)
        Me.colInicio.Name = "FechaInicio"
        Me.colInicio.HeaderText = "Inicio"
        Me.colInicio.DataPropertyName = "FechaInicio"
        Me.colInicio.Width = 100
        Me.colInicio.FillWeight = 100
        Me.colInicio.ReadOnly = True
        Me.colInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colInicio.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.Format = "dd/MM/yyyy", .NullValue = "—"}
        Me.tabla.Columns.Add(Me.colInicio)
        Me.colDni.Name = "DniLector"
        Me.colDni.HeaderText = "DNI"
        Me.colDni.DataPropertyName = "DniLector"
        Me.colDni.Width = 90
        Me.colDni.FillWeight = 90
        Me.colDni.ReadOnly = True
        Me.colDni.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colDni)
        Me.colCorreo.Name = "CorreoLector"
        Me.colCorreo.HeaderText = "Correo"
        Me.colCorreo.DataPropertyName = "CorreoLector"
        Me.colCorreo.Width = 220
        Me.colCorreo.FillWeight = 220
        Me.colCorreo.ReadOnly = True
        Me.colCorreo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colCorreo)
        Me.colBibliotecario.Name = "NombreBibliotecario"
        Me.colBibliotecario.HeaderText = "Bibliotecario"
        Me.colBibliotecario.DataPropertyName = "NombreBibliotecario"
        Me.colBibliotecario.Width = 210
        Me.colBibliotecario.FillWeight = 210
        Me.colBibliotecario.ReadOnly = True
        Me.colBibliotecario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colBibliotecario)
        Me.resumen.Name = "resumen"
        Me.resumen.Text = "Sin datos cargados. Abre la pantalla para consultar."
        Me.resumen.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.resumen.AutoSize = False
        Me.resumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.resumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.resumen.AutoEllipsis = True
        Me.layoutVista.Controls.Add(Me.encabezado, 0, 0)
        Me.layoutVista.Controls.Add(Me.barraFiltros, 0, 1)
        Me.layoutVista.Controls.Add(Me.barraAcciones, 0, 2)
        Me.layoutVista.Controls.Add(Me.tabla, 0, 3)
        Me.layoutVista.Controls.Add(Me.resumen, 0, 4)
        Me.Controls.Add(Me.layoutVista)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Name = "frmPrestamos"
        Me.Text = Me.lblTituloVista.Text
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barraAcciones.ResumeLayout(False)
        Me.barraAcciones.PerformLayout()
        Me.bloque_filtroEstado.ResumeLayout(False)
        Me.bloque_filtroEstado.PerformLayout()
        Me.bloque_buscar.ResumeLayout(False)
        Me.bloque_buscar.PerformLayout()
        Me.barraFiltros.ResumeLayout(False)
        Me.barraFiltros.PerformLayout()
        Me.layoutVista.ResumeLayout(False)
        Me.layoutVista.PerformLayout()
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
    Friend WithEvents layoutVista As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents barraFiltros As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents buscar As System.Windows.Forms.TextBox
    Friend WithEvents bloque_buscar As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_buscar As System.Windows.Forms.Label
    Friend WithEvents filtroEstado As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_filtroEstado As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_filtroEstado As System.Windows.Forms.Label
    Friend WithEvents barraAcciones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnDevolver As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents tabla As System.Windows.Forms.DataGridView
    Friend WithEvents colPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEjemplar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLibro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRetorno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCorreo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBibliotecario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents resumen As System.Windows.Forms.Label
End Class
