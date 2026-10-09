<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCategoria
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
        Me.barraAcciones = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.tbCategoria = New System.Windows.Forms.DataGridView()
        Me.colIdCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombreCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstadoCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblResumen = New System.Windows.Forms.Label()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutVista.SuspendLayout()
        Me.barraFiltros.SuspendLayout()
        Me.bloque_txtBuscar.SuspendLayout()
        Me.bloque_cboEstado.SuspendLayout()
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
        Me.lblTituloVista.Text = "Categorías"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Clasifica los libros de la biblioteca."
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
        Me.barraAcciones.Name = "barraAcciones"
        Me.barraAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barraAcciones.AutoSize = True
        Me.barraAcciones.WrapContents = True
        Me.barraAcciones.Margin = New System.Windows.Forms.Padding(0, 4, 0, 10)
        Me.Button10.Name = "Button10"
        Me.Button10.Text = "Agregar categoría"
        Me.Button10.Size = New System.Drawing.Size(170, 38)
        Me.Button10.AutoSize = False
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.Button10.ForeColor = System.Drawing.Color.White
        Me.Button10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.Button10.UseVisualStyleBackColor = False
        Me.Button10.Enabled = True
        Me.barraAcciones.Controls.Add(Me.Button10)
        Me.Button11.Name = "Button11"
        Me.Button11.Text = "Editar"
        Me.Button11.Size = New System.Drawing.Size(170, 38)
        Me.Button11.AutoSize = False
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.FlatAppearance.BorderSize = 1
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.Button11.BackColor = System.Drawing.Color.White
        Me.Button11.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.Button11.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.Button11.UseVisualStyleBackColor = False
        Me.Button11.Enabled = False
        Me.barraAcciones.Controls.Add(Me.Button11)
        Me.tbCategoria.Name = "tbCategoria"
        Me.tbCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbCategoria.ReadOnly = True
        Me.tbCategoria.AllowUserToAddRows = False
        Me.tbCategoria.AllowUserToDeleteRows = False
        Me.tbCategoria.MultiSelect = False
        Me.tbCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tbCategoria.RowHeadersVisible = False
        Me.tbCategoria.AutoGenerateColumns = False
        Me.tbCategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tbCategoria.BackgroundColor = System.Drawing.Color.White
        Me.tbCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCategoria.GridColor = System.Drawing.Color.FromArgb(231, 235, 246)
        Me.tbCategoria.EnableHeadersVisualStyles = False
        Me.tbCategoria.ColumnHeadersHeight = 40
        Me.tbCategoria.RowTemplate.Height = 36
        Me.tbCategoria.Margin = New System.Windows.Forms.Padding(0)
        Me.tbCategoria.AccessibleName = "Tabla de resultados"
        Me.tbCategoria.ColumnHeadersDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(234, 239, 255), .ForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)}
        Me.tbCategoria.DefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.SelectionBackColor = System.Drawing.Color.FromArgb(222, 229, 255), .SelectionForeColor = System.Drawing.Color.FromArgb(28, 36, 55), .NullValue = "—"}
        Me.tbCategoria.AlternatingRowsDefaultCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {.BackColor = System.Drawing.Color.FromArgb(248, 250, 255)}
        Me.colIdCategoria.Name = "id_categoria"
        Me.colIdCategoria.HeaderText = "ID"
        Me.colIdCategoria.DataPropertyName = "id_categoria"
        Me.colIdCategoria.Width = 15
        Me.colIdCategoria.FillWeight = 15
        Me.colIdCategoria.ReadOnly = True
        Me.colIdCategoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tbCategoria.Columns.Add(Me.colIdCategoria)
        Me.colNombreCategoria.Name = "nombre_categoria"
        Me.colNombreCategoria.HeaderText = "Nombre de la categoría"
        Me.colNombreCategoria.DataPropertyName = "nombre_categoria"
        Me.colNombreCategoria.Width = 60
        Me.colNombreCategoria.FillWeight = 60
        Me.colNombreCategoria.ReadOnly = True
        Me.colNombreCategoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tbCategoria.Columns.Add(Me.colNombreCategoria)
        Me.colEstadoCategoria.Name = "estado"
        Me.colEstadoCategoria.HeaderText = "Estado"
        Me.colEstadoCategoria.DataPropertyName = "estado"
        Me.colEstadoCategoria.Width = 25
        Me.colEstadoCategoria.FillWeight = 25
        Me.colEstadoCategoria.ReadOnly = True
        Me.colEstadoCategoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tbCategoria.Columns.Add(Me.colEstadoCategoria)
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
        Me.layoutVista.Controls.Add(Me.tbCategoria, 0, 3)
        Me.layoutVista.Controls.Add(Me.lblResumen, 0, 4)
        Me.Controls.Add(Me.layoutVista)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Name = "FrmCategoria"
        Me.Text = Me.lblTituloVista.Text
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barraAcciones.ResumeLayout(False)
        Me.barraAcciones.PerformLayout()
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
    Friend WithEvents barraAcciones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents tbCategoria As System.Windows.Forms.DataGridView
    Friend WithEvents colIdCategoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombreCategoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstadoCategoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblResumen As System.Windows.Forms.Label
End Class
