<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAutor
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
        Me.txtBuscarAutor = New System.Windows.Forms.TextBox()
        Me.bloque_txtBuscarAutor = New System.Windows.Forms.Panel()
        Me.etiqueta_txtBuscarAutor = New System.Windows.Forms.Label()
        Me.barraAcciones = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.tablaAutores = New System.Windows.Forms.DataGridView()
        Me.colIdAutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombreAutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblResumen = New System.Windows.Forms.Label()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tablaAutores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutVista.SuspendLayout()
        Me.barraFiltros.SuspendLayout()
        Me.bloque_txtBuscarAutor.SuspendLayout()
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
        Me.lblTituloVista.Text = "Autores"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Organiza los autores del catálogo."
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
        Me.txtBuscarAutor.Name = "txtBuscarAutor"
        Me.txtBuscarAutor.PlaceholderText = "Buscar..."
        Me.bloque_txtBuscarAutor.Name = "bloque_txtBuscarAutor"
        Me.bloque_txtBuscarAutor.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_txtBuscarAutor.Size = New System.Drawing.Size(320, 58)
        Me.bloque_txtBuscarAutor.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_txtBuscarAutor.Name = "etiqueta_txtBuscarAutor"
        Me.etiqueta_txtBuscarAutor.Text = "Buscar"
        Me.etiqueta_txtBuscarAutor.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_txtBuscarAutor.AutoSize = False
        Me.etiqueta_txtBuscarAutor.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_txtBuscarAutor.Height = 24
        Me.etiqueta_txtBuscarAutor.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtBuscarAutor.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtBuscarAutor.Height = 30
        Me.bloque_txtBuscarAutor.Controls.Add(Me.txtBuscarAutor)
        Me.bloque_txtBuscarAutor.Controls.Add(Me.etiqueta_txtBuscarAutor)
        Me.barraFiltros.Controls.Add(Me.bloque_txtBuscarAutor)
        Me.barraAcciones.Name = "barraAcciones"
        Me.barraAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barraAcciones.AutoSize = True
        Me.barraAcciones.WrapContents = True
        Me.barraAcciones.Margin = New System.Windows.Forms.Padding(0, 4, 0, 10)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "Agregar autor"
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
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(170, 38)
        Me.btnEliminar.AutoSize = False
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.FlatAppearance.BorderSize = 1
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnEliminar.BackColor = System.Drawing.Color.White
        Me.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnEliminar.UseVisualStyleBackColor = False
        Me.btnEliminar.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnEliminar)
        Me.tablaAutores.Name = "tablaAutores"
        Me.tablaAutores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablaAutores.ReadOnly = True
        Me.tablaAutores.AllowUserToAddRows = False
        Me.tablaAutores.AllowUserToDeleteRows = False
        Me.tablaAutores.MultiSelect = False
        Me.tablaAutores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tablaAutores.RowHeadersVisible = False
        Me.tablaAutores.AutoGenerateColumns = False
        Me.tablaAutores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tablaAutores.BackgroundColor = System.Drawing.Color.White
        Me.tablaAutores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tablaAutores.GridColor = System.Drawing.Color.FromArgb(231, 235, 246)
        Me.tablaAutores.EnableHeadersVisualStyles = False
        Me.tablaAutores.ColumnHeadersHeight = 40
        Me.tablaAutores.RowTemplate.Height = 36
        Me.tablaAutores.Margin = New System.Windows.Forms.Padding(0)
        Me.tablaAutores.AccessibleName = "Tabla de resultados"
        Me.tablaAutores.ColumnHeadersDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(234, 239, 255), .ForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)}
        Me.tablaAutores.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.SelectionBackColor = System.Drawing.Color.FromArgb(222, 229, 255), .SelectionForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .NullValue = "—"}
        Me.tablaAutores.AlternatingRowsDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(248, 250, 255)}
        Me.colIdAutor.Name = "colIdAutor"
        Me.colIdAutor.HeaderText = "ID"
        Me.colIdAutor.DataPropertyName = "IdAutor"
        Me.colIdAutor.Width = 15
        Me.colIdAutor.FillWeight = 15
        Me.colIdAutor.ReadOnly = True
        Me.colIdAutor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaAutores.Columns.Add(Me.colIdAutor)
        Me.colNombreAutor.Name = "colNombreAutor"
        Me.colNombreAutor.HeaderText = "Nombre del autor"
        Me.colNombreAutor.DataPropertyName = "NombreAutor"
        Me.colNombreAutor.Width = 85
        Me.colNombreAutor.FillWeight = 85
        Me.colNombreAutor.ReadOnly = True
        Me.colNombreAutor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaAutores.Columns.Add(Me.colNombreAutor)
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
        Me.layoutVista.Controls.Add(Me.tablaAutores, 0, 3)
        Me.layoutVista.Controls.Add(Me.lblResumen, 0, 4)
        Me.Controls.Add(Me.layoutVista)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Name = "frmAutor"
        Me.Text = Me.lblTituloVista.Text
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tablaAutores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barraAcciones.ResumeLayout(False)
        Me.barraAcciones.PerformLayout()
        Me.bloque_txtBuscarAutor.ResumeLayout(False)
        Me.bloque_txtBuscarAutor.PerformLayout()
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
    Friend WithEvents txtBuscarAutor As System.Windows.Forms.TextBox
    Friend WithEvents bloque_txtBuscarAutor As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_txtBuscarAutor As System.Windows.Forms.Label
    Friend WithEvents barraAcciones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents tablaAutores As System.Windows.Forms.DataGridView
    Friend WithEvents colIdAutor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombreAutor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblResumen As System.Windows.Forms.Label
End Class
