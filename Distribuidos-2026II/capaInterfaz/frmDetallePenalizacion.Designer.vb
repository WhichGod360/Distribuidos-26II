<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDetallePenalizacion
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
        Me.cboFiltroSancion = New System.Windows.Forms.ComboBox()
        Me.bloque_cboFiltroSancion = New System.Windows.Forms.Panel()
        Me.etiqueta_cboFiltroSancion = New System.Windows.Forms.Label()
        Me.barraAcciones = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSancion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIdPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLibro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRetorno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstadoPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblResumen = New System.Windows.Forms.Label()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutVista.SuspendLayout()
        Me.barraFiltros.SuspendLayout()
        Me.bloque_buscar.SuspendLayout()
        Me.bloque_cboFiltroSancion.SuspendLayout()
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
        Me.lblTituloVista.Text = "Detalle de penalizaciones"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Consulta las sanciones asociadas a los préstamos."
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
        Me.cboFiltroSancion.Name = "cboFiltroSancion"
        Me.cboFiltroSancion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.bloque_cboFiltroSancion.Name = "bloque_cboFiltroSancion"
        Me.bloque_cboFiltroSancion.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_cboFiltroSancion.Size = New System.Drawing.Size(180, 58)
        Me.bloque_cboFiltroSancion.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_cboFiltroSancion.Name = "etiqueta_cboFiltroSancion"
        Me.etiqueta_cboFiltroSancion.Text = "Penalización"
        Me.etiqueta_cboFiltroSancion.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_cboFiltroSancion.AutoSize = False
        Me.etiqueta_cboFiltroSancion.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_cboFiltroSancion.Height = 24
        Me.etiqueta_cboFiltroSancion.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.cboFiltroSancion.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboFiltroSancion.Height = 30
        Me.bloque_cboFiltroSancion.Controls.Add(Me.cboFiltroSancion)
        Me.bloque_cboFiltroSancion.Controls.Add(Me.etiqueta_cboFiltroSancion)
        Me.barraFiltros.Controls.Add(Me.bloque_cboFiltroSancion)
        Me.barraAcciones.Name = "barraAcciones"
        Me.barraAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barraAcciones.AutoSize = True
        Me.barraAcciones.WrapContents = True
        Me.barraAcciones.Margin = New System.Windows.Forms.Padding(0, 4, 0, 10)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "Agregar detalle"
        Me.btnAgregar.Size = New System.Drawing.Size(170, 38)
        Me.btnAgregar.AutoSize = False
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnAgregar.BackColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnAgregar.UseVisualStyleBackColor = False
        Me.btnAgregar.Enabled = True
        Me.barraAcciones.Controls.Add(Me.btnAgregar)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.Size = New System.Drawing.Size(170, 38)
        Me.btnEditar.AutoSize = False
        Me.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditar.FlatAppearance.BorderSize = 1
        Me.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnEditar.BackColor = System.Drawing.Color.White
        Me.btnEditar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnEditar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnEditar.UseVisualStyleBackColor = False
        Me.btnEditar.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnEditar)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Text = "Volver a penalizaciones"
        Me.btnVolver.Size = New System.Drawing.Size(170, 38)
        Me.btnVolver.AutoSize = False
        Me.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolver.FlatAppearance.BorderSize = 1
        Me.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnVolver.BackColor = System.Drawing.Color.White
        Me.btnVolver.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnVolver.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolver.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnVolver.UseVisualStyleBackColor = False
        Me.btnVolver.Enabled = True
        Me.barraAcciones.Controls.Add(Me.btnVolver)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.GridColor = System.Drawing.Color.FromArgb(231, 235, 246)
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.ColumnHeadersHeight = 40
        Me.DataGridView1.RowTemplate.Height = 36
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(0)
        Me.DataGridView1.AccessibleName = "Tabla de resultados"
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(234, 239, 255), .ForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)}
        Me.DataGridView1.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.SelectionBackColor = System.Drawing.Color.FromArgb(222, 229, 255), .SelectionForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .NullValue = "—"}
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(248, 250, 255)}
        Me.colId.Name = "colId"
        Me.colId.HeaderText = "ID"
        Me.colId.DataPropertyName = ""
        Me.colId.Width = 55
        Me.colId.FillWeight = 55
        Me.colId.ReadOnly = True
        Me.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colId)
        Me.colSancion.Name = "colSancion"
        Me.colSancion.HeaderText = "Penalización"
        Me.colSancion.DataPropertyName = ""
        Me.colSancion.Width = 160
        Me.colSancion.FillWeight = 160
        Me.colSancion.ReadOnly = True
        Me.colSancion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colSancion)
        Me.colMonto.Name = "colMonto"
        Me.colMonto.HeaderText = "Monto"
        Me.colMonto.DataPropertyName = ""
        Me.colMonto.Width = 85
        Me.colMonto.FillWeight = 85
        Me.colMonto.ReadOnly = True
        Me.colMonto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colMonto)
        Me.colIdPrestamo.Name = "colIdPrestamo"
        Me.colIdPrestamo.HeaderText = "Préstamo"
        Me.colIdPrestamo.DataPropertyName = ""
        Me.colIdPrestamo.Width = 85
        Me.colIdPrestamo.FillWeight = 85
        Me.colIdPrestamo.ReadOnly = True
        Me.colIdPrestamo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colIdPrestamo)
        Me.colUsuario.Name = "colUsuario"
        Me.colUsuario.HeaderText = "Lector"
        Me.colUsuario.DataPropertyName = ""
        Me.colUsuario.Width = 180
        Me.colUsuario.FillWeight = 180
        Me.colUsuario.ReadOnly = True
        Me.colUsuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colUsuario)
        Me.colLibro.Name = "colLibro"
        Me.colLibro.HeaderText = "Libro"
        Me.colLibro.DataPropertyName = ""
        Me.colLibro.Width = 180
        Me.colLibro.FillWeight = 180
        Me.colLibro.ReadOnly = True
        Me.colLibro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colLibro)
        Me.colInicio.Name = "colInicio"
        Me.colInicio.HeaderText = "Inicio"
        Me.colInicio.DataPropertyName = ""
        Me.colInicio.Width = 100
        Me.colInicio.FillWeight = 100
        Me.colInicio.ReadOnly = True
        Me.colInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colInicio)
        Me.colVence.Name = "colVence"
        Me.colVence.HeaderText = "Vence"
        Me.colVence.DataPropertyName = ""
        Me.colVence.Width = 100
        Me.colVence.FillWeight = 100
        Me.colVence.ReadOnly = True
        Me.colVence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colVence)
        Me.colRetorno.Name = "colRetorno"
        Me.colRetorno.HeaderText = "Retorno"
        Me.colRetorno.DataPropertyName = ""
        Me.colRetorno.Width = 100
        Me.colRetorno.FillWeight = 100
        Me.colRetorno.ReadOnly = True
        Me.colRetorno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colRetorno)
        Me.colDias.Name = "colDias"
        Me.colDias.HeaderText = "Retraso"
        Me.colDias.DataPropertyName = ""
        Me.colDias.Width = 80
        Me.colDias.FillWeight = 80
        Me.colDias.ReadOnly = True
        Me.colDias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colDias)
        Me.colEstadoPrestamo.Name = "colEstadoPrestamo"
        Me.colEstadoPrestamo.HeaderText = "Estado"
        Me.colEstadoPrestamo.DataPropertyName = ""
        Me.colEstadoPrestamo.Width = 95
        Me.colEstadoPrestamo.FillWeight = 95
        Me.colEstadoPrestamo.ReadOnly = True
        Me.colEstadoPrestamo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colEstadoPrestamo)
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.DataPropertyName = ""
        Me.colDescripcion.Width = 220
        Me.colDescripcion.FillWeight = 220
        Me.colDescripcion.ReadOnly = True
        Me.colDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colDescripcion)
        Me.lblResumen.Name = "lblResumen"
        Me.lblResumen.Text = "Sin datos cargados. Abre la pantalla para consultar."
        Me.lblResumen.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblResumen.AutoSize = False
        Me.lblResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblResumen.AutoEllipsis = True
        Me.layoutVista.Controls.Add(Me.encabezado, 0, 0)
        Me.layoutVista.Controls.Add(Me.barraFiltros, 0, 1)
        Me.layoutVista.Controls.Add(Me.barraAcciones, 0, 2)
        Me.layoutVista.Controls.Add(Me.DataGridView1, 0, 3)
        Me.layoutVista.Controls.Add(Me.lblResumen, 0, 4)
        Me.Controls.Add(Me.layoutVista)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Name = "frmDetallePenalizacion"
        Me.Text = Me.lblTituloVista.Text
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barraAcciones.ResumeLayout(False)
        Me.barraAcciones.PerformLayout()
        Me.bloque_cboFiltroSancion.ResumeLayout(False)
        Me.bloque_cboFiltroSancion.PerformLayout()
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
    Friend WithEvents cboFiltroSancion As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_cboFiltroSancion As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_cboFiltroSancion As System.Windows.Forms.Label
    Friend WithEvents barraAcciones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSancion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIdPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLibro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRetorno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstadoPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblResumen As System.Windows.Forms.Label
End Class
