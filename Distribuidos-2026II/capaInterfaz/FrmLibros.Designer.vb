<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLibros
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
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.bloque_txtBuscar = New System.Windows.Forms.Panel()
        Me.etiqueta_txtBuscar = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.bloque_cboEstado = New System.Windows.Forms.Panel()
        Me.etiqueta_cboEstado = New System.Windows.Forms.Label()
        Me.cboOrden = New System.Windows.Forms.ComboBox()
        Me.bloque_cboOrden = New System.Windows.Forms.Panel()
        Me.etiqueta_cboOrden = New System.Windows.Forms.Label()
        Me.barraAcciones = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnDesactivar = New System.Windows.Forms.Button()
        Me.btnEjemplares = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTitulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEditorial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAnio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlPaginacion = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPagPrev = New System.Windows.Forms.Button()
        Me.flpNumeros = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPagNext = New System.Windows.Forms.Button()
        Me.pieListado = New System.Windows.Forms.Panel()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutVista.SuspendLayout()
        Me.barraFiltros.SuspendLayout()
        Me.bloque_txtBuscar.SuspendLayout()
        Me.bloque_cboEstado.SuspendLayout()
        Me.bloque_cboOrden.SuspendLayout()
        Me.barraAcciones.SuspendLayout()
        Me.pnlPaginacion.SuspendLayout()
        Me.flpNumeros.SuspendLayout()
        Me.pieListado.SuspendLayout()
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
        Me.lblTituloVista.Text = "Libros"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Administra el catálogo y las copias de cada libro."
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
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.PlaceholderText = "Buscar..."
        Me.bloque_txtBuscar.Name = "bloque_txtBuscar"
        Me.bloque_txtBuscar.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_txtBuscar.Size = New System.Drawing.Size(320, 58)
        Me.bloque_txtBuscar.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_txtBuscar.Name = "etiqueta_txtBuscar"
        Me.etiqueta_txtBuscar.Text = "Buscar"
        Me.etiqueta_txtBuscar.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_txtBuscar.AutoSize = False
        Me.etiqueta_txtBuscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_txtBuscar.Height = 24
        Me.etiqueta_txtBuscar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtBuscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtBuscar.Height = 30
        Me.bloque_txtBuscar.Controls.Add(Me.txtBuscar)
        Me.bloque_txtBuscar.Controls.Add(Me.etiqueta_txtBuscar)
        Me.barraFiltros.Controls.Add(Me.bloque_txtBuscar)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.Items.AddRange(New Object() {"Todos", "Activo", "Inactivo"})
        Me.bloque_cboEstado.Name = "bloque_cboEstado"
        Me.bloque_cboEstado.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_cboEstado.Size = New System.Drawing.Size(180, 58)
        Me.bloque_cboEstado.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_cboEstado.Name = "etiqueta_cboEstado"
        Me.etiqueta_cboEstado.Text = "Estado"
        Me.etiqueta_cboEstado.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_cboEstado.AutoSize = False
        Me.etiqueta_cboEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_cboEstado.Height = 24
        Me.etiqueta_cboEstado.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.cboEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboEstado.Height = 30
        Me.bloque_cboEstado.Controls.Add(Me.cboEstado)
        Me.bloque_cboEstado.Controls.Add(Me.etiqueta_cboEstado)
        Me.barraFiltros.Controls.Add(Me.bloque_cboEstado)
        Me.cboOrden.Name = "cboOrden"
        Me.cboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrden.Items.AddRange(New Object() {"Título A–Z", "Título Z–A", "Año ascendente", "Año descendente"})
        Me.bloque_cboOrden.Name = "bloque_cboOrden"
        Me.bloque_cboOrden.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_cboOrden.Size = New System.Drawing.Size(180, 58)
        Me.bloque_cboOrden.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_cboOrden.Name = "etiqueta_cboOrden"
        Me.etiqueta_cboOrden.Text = "Ordenar"
        Me.etiqueta_cboOrden.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_cboOrden.AutoSize = False
        Me.etiqueta_cboOrden.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_cboOrden.Height = 24
        Me.etiqueta_cboOrden.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.cboOrden.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboOrden.Height = 30
        Me.bloque_cboOrden.Controls.Add(Me.cboOrden)
        Me.bloque_cboOrden.Controls.Add(Me.etiqueta_cboOrden)
        Me.barraFiltros.Controls.Add(Me.bloque_cboOrden)
        Me.barraAcciones.Name = "barraAcciones"
        Me.barraAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barraAcciones.AutoSize = True
        Me.barraAcciones.WrapContents = True
        Me.barraAcciones.Margin = New System.Windows.Forms.Padding(0, 4, 0, 10)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "Agregar libro"
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
        Me.btnDesactivar.Name = "btnDesactivar"
        Me.btnDesactivar.Text = "Desactivar"
        Me.btnDesactivar.Size = New System.Drawing.Size(170, 38)
        Me.btnDesactivar.AutoSize = False
        Me.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesactivar.FlatAppearance.BorderSize = 1
        Me.btnDesactivar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnDesactivar.BackColor = System.Drawing.Color.White
        Me.btnDesactivar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnDesactivar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDesactivar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDesactivar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnDesactivar.UseVisualStyleBackColor = False
        Me.btnDesactivar.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnDesactivar)
        Me.btnEjemplares.Name = "btnEjemplares"
        Me.btnEjemplares.Text = "Ver ejemplares"
        Me.btnEjemplares.Size = New System.Drawing.Size(170, 38)
        Me.btnEjemplares.AutoSize = False
        Me.btnEjemplares.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEjemplares.FlatAppearance.BorderSize = 1
        Me.btnEjemplares.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnEjemplares.BackColor = System.Drawing.Color.White
        Me.btnEjemplares.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnEjemplares.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEjemplares.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEjemplares.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnEjemplares.UseVisualStyleBackColor = False
        Me.btnEjemplares.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnEjemplares)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
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
        Me.colId.DataPropertyName = "id"
        Me.colId.Width = 10
        Me.colId.FillWeight = 10
        Me.colId.ReadOnly = True
        Me.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colId)
        Me.colTitulo.Name = "colTitulo"
        Me.colTitulo.HeaderText = "Título"
        Me.colTitulo.DataPropertyName = "titulo"
        Me.colTitulo.Width = 34
        Me.colTitulo.FillWeight = 34
        Me.colTitulo.ReadOnly = True
        Me.colTitulo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colTitulo)
        Me.colEditorial.Name = "colEditorial"
        Me.colEditorial.HeaderText = "Editorial"
        Me.colEditorial.DataPropertyName = "editorial"
        Me.colEditorial.Width = 20
        Me.colEditorial.FillWeight = 20
        Me.colEditorial.ReadOnly = True
        Me.colEditorial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colEditorial)
        Me.colAnio.Name = "colAnio"
        Me.colAnio.HeaderText = "Año"
        Me.colAnio.DataPropertyName = "anio"
        Me.colAnio.Width = 10
        Me.colAnio.FillWeight = 10
        Me.colAnio.ReadOnly = True
        Me.colAnio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colAnio)
        Me.colStock.Name = "colStock"
        Me.colStock.HeaderText = "Ejemplares"
        Me.colStock.DataPropertyName = "stock"
        Me.colStock.Width = 10
        Me.colStock.FillWeight = 10
        Me.colStock.ReadOnly = True
        Me.colStock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colStock)
        Me.colEstado.Name = "colEstado"
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.DataPropertyName = "estado"
        Me.colEstado.Width = 16
        Me.colEstado.FillWeight = 16
        Me.colEstado.ReadOnly = True
        Me.colEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colEstado)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Text = "Sin datos cargados. Abre la pantalla para consultar."
        Me.lblRegistros.ForeColor = System.Drawing.Color.FromArgb(105, 116, 140)
        Me.lblRegistros.AutoSize = False
        Me.lblRegistros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRegistros.AutoEllipsis = True
        Me.layoutVista.Controls.Add(Me.encabezado, 0, 0)
        Me.layoutVista.Controls.Add(Me.barraFiltros, 0, 1)
        Me.layoutVista.Controls.Add(Me.barraAcciones, 0, 2)
        Me.layoutVista.Controls.Add(Me.DataGridView1, 0, 3)
        Me.layoutVista.Controls.Add(Me.lblRegistros, 0, 4)
        Me.pnlPaginacion.Name = "pnlPaginacion"
        Me.pnlPaginacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlPaginacion.Width = 300
        Me.btnPagPrev.Name = "btnPagPrev"
        Me.btnPagPrev.Text = "‹"
        Me.btnPagPrev.Size = New System.Drawing.Size(170, 38)
        Me.btnPagPrev.AutoSize = False
        Me.btnPagPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPagPrev.FlatAppearance.BorderSize = 1
        Me.btnPagPrev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnPagPrev.BackColor = System.Drawing.Color.White
        Me.btnPagPrev.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnPagPrev.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPagPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPagPrev.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnPagPrev.UseVisualStyleBackColor = False
        Me.btnPagPrev.Width = 40
        Me.flpNumeros.Name = "flpNumeros"
        Me.flpNumeros.Width = 205
        Me.flpNumeros.Height = 40
        Me.btnPagNext.Name = "btnPagNext"
        Me.btnPagNext.Text = "›"
        Me.btnPagNext.Size = New System.Drawing.Size(170, 38)
        Me.btnPagNext.AutoSize = False
        Me.btnPagNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPagNext.FlatAppearance.BorderSize = 1
        Me.btnPagNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnPagNext.BackColor = System.Drawing.Color.White
        Me.btnPagNext.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnPagNext.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPagNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPagNext.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnPagNext.UseVisualStyleBackColor = False
        Me.btnPagNext.Width = 40
        Me.pnlPaginacion.Controls.Add(Me.btnPagPrev)
        Me.pnlPaginacion.Controls.Add(Me.flpNumeros)
        Me.pnlPaginacion.Controls.Add(Me.btnPagNext)
        Me.pieListado.Name = "pieListado"
        Me.pieListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutVista.Controls.Remove(Me.lblRegistros)
        Me.pieListado.Controls.Add(Me.lblRegistros)
        Me.pieListado.Controls.Add(Me.pnlPaginacion)
        Me.layoutVista.Controls.Add(Me.pieListado, 0, 4)
        Me.Controls.Add(Me.layoutVista)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Name = "FrmLibros"
        Me.Text = Me.lblTituloVista.Text
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pieListado.ResumeLayout(False)
        Me.pieListado.PerformLayout()
        Me.flpNumeros.ResumeLayout(False)
        Me.flpNumeros.PerformLayout()
        Me.pnlPaginacion.ResumeLayout(False)
        Me.pnlPaginacion.PerformLayout()
        Me.barraAcciones.ResumeLayout(False)
        Me.barraAcciones.PerformLayout()
        Me.bloque_cboOrden.ResumeLayout(False)
        Me.bloque_cboOrden.PerformLayout()
        Me.bloque_cboEstado.ResumeLayout(False)
        Me.bloque_cboEstado.PerformLayout()
        Me.bloque_txtBuscar.ResumeLayout(False)
        Me.bloque_txtBuscar.PerformLayout()
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
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents bloque_txtBuscar As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_txtBuscar As System.Windows.Forms.Label
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_cboEstado As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_cboEstado As System.Windows.Forms.Label
    Friend WithEvents cboOrden As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_cboOrden As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_cboOrden As System.Windows.Forms.Label
    Friend WithEvents barraAcciones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnDesactivar As System.Windows.Forms.Button
    Friend WithEvents btnEjemplares As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTitulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEditorial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAnio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents pnlPaginacion As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnPagPrev As System.Windows.Forms.Button
    Friend WithEvents flpNumeros As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnPagNext As System.Windows.Forms.Button
    Friend WithEvents pieListado As System.Windows.Forms.Panel
End Class
