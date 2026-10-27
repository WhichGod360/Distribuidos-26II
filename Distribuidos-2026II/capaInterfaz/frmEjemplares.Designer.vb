<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEjemplares
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
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEstado = New System.Windows.Forms.Button()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.tabla = New System.Windows.Forms.DataGridView()
        Me.tablaCabecera = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tablaCeldas = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tablaAlternas = New System.Windows.Forms.DataGridViewCellStyle()
        Me.colIdEjemplar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colActivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstadoEjemplar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblResumen = New System.Windows.Forms.Label()
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
        Me.lblTituloVista.Text = "Ejemplares"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Selecciona un libro desde el catálogo para consultar sus copias."
        Me.lblDescripcionVista.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120)
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
        Me.layoutVista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52!))
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
        Me.etiqueta_buscar.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.etiqueta_buscar.AutoSize = False
        Me.etiqueta_buscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_buscar.Height = 24
        Me.etiqueta_buscar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.buscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.buscar.Height = 30
        Me.bloque_buscar.Controls.Add(Me.buscar)
        Me.bloque_buscar.Controls.Add(Me.etiqueta_buscar)
        Me.barraFiltros.Controls.Add(Me.bloque_buscar)
        Me.filtroEstado.Name = "filtroEstado"
        Me.filtroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.filtroEstado.Items.AddRange(New Object() {"Todos", "Disponible", "Prestado", "Inactivo"})
        Me.bloque_filtroEstado.Name = "bloque_filtroEstado"
        Me.bloque_filtroEstado.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_filtroEstado.Size = New System.Drawing.Size(180, 58)
        Me.bloque_filtroEstado.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_filtroEstado.Name = "etiqueta_filtroEstado"
        Me.etiqueta_filtroEstado.Text = "Estado"
        Me.etiqueta_filtroEstado.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.etiqueta_filtroEstado.AutoSize = False
        Me.etiqueta_filtroEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_filtroEstado.Height = 24
        Me.etiqueta_filtroEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
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
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "Agregar ejemplar"
        Me.btnAgregar.Size = New System.Drawing.Size(170, 38)
        Me.btnAgregar.AutoSize = False
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(35, 56, 72)
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 231)
        Me.btnAgregar.BackColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnAgregar.UseVisualStyleBackColor = False
        Me.btnAgregar.Enabled = True
        Me.barraAcciones.Controls.Add(Me.btnAgregar)
        Me.btnEstado.Name = "btnEstado"
        Me.btnEstado.Text = "Desactivar"
        Me.btnEstado.Size = New System.Drawing.Size(170, 38)
        Me.btnEstado.AutoSize = False
        Me.btnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEstado.FlatAppearance.BorderSize = 1
        Me.btnEstado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnEstado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 244, 247)
        Me.btnEstado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(225, 232, 238)
        Me.btnEstado.BackColor = System.Drawing.Color.White
        Me.btnEstado.ForeColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
        Me.btnEstado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEstado.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnEstado.UseVisualStyleBackColor = False
        Me.btnEstado.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnEstado)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Text = "Volver a libros"
        Me.btnVolver.Size = New System.Drawing.Size(170, 38)
        Me.btnVolver.AutoSize = False
        Me.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolver.FlatAppearance.BorderSize = 1
        Me.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 244, 247)
        Me.btnVolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(225, 232, 238)
        Me.btnVolver.BackColor = System.Drawing.Color.White
        Me.btnVolver.ForeColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnVolver.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
        Me.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVolver.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnVolver.UseVisualStyleBackColor = False
        Me.btnVolver.Enabled = True
        Me.barraAcciones.Controls.Add(Me.btnVolver)
        Me.tabla.Name = "tabla"
        Me.tabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabla.ReadOnly = True
        Me.tabla.AllowUserToAddRows = False
        Me.tabla.AllowUserToDeleteRows = False
        Me.tabla.MultiSelect = False
        Me.tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tabla.RowHeadersVisible = False
        Me.tabla.AutoGenerateColumns = False
        Me.tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tabla.BackgroundColor = System.Drawing.Color.White
        Me.tabla.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tabla.GridColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.tabla.EnableHeadersVisualStyles = False
        Me.tabla.ColumnHeadersHeight = 40
        Me.tabla.RowTemplate.Height = 36
        Me.tabla.Margin = New System.Windows.Forms.Padding(0)
        Me.tabla.AccessibleName = "Tabla de resultados"
        Me.tablaCabecera.BackColor = System.Drawing.Color.FromArgb(226, 234, 240)
        Me.tablaCabecera.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.tablaCabecera.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.tablaCeldas.SelectionBackColor = System.Drawing.Color.FromArgb(212, 226, 236)
        Me.tablaCeldas.SelectionForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.tablaCeldas.NullValue = "—"
        Me.tablaAlternas.BackColor = System.Drawing.Color.FromArgb(247, 249, 250)
        Me.tabla.ColumnHeadersDefaultCellStyle = Me.tablaCabecera
        Me.tabla.DefaultCellStyle = Me.tablaCeldas
        Me.tabla.AlternatingRowsDefaultCellStyle = Me.tablaAlternas
        Me.colIdEjemplar.Name = "id_ejemplar"
        Me.colIdEjemplar.HeaderText = "ID del ejemplar"
        Me.colIdEjemplar.DataPropertyName = "id_ejemplar"
        Me.colIdEjemplar.Width = 30
        Me.colIdEjemplar.FillWeight = 30
        Me.colIdEjemplar.ReadOnly = True
        Me.colIdEjemplar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colIdEjemplar)
        Me.colActivo.Name = "activo"
        Me.colActivo.HeaderText = "Habilitado"
        Me.colActivo.DataPropertyName = "activo"
        Me.colActivo.Width = 20
        Me.colActivo.FillWeight = 20
        Me.colActivo.ReadOnly = True
        Me.colActivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colActivo)
        Me.colEstadoEjemplar.Name = "estado"
        Me.colEstadoEjemplar.HeaderText = "Estado"
        Me.colEstadoEjemplar.DataPropertyName = "estado"
        Me.colEstadoEjemplar.Width = 50
        Me.colEstadoEjemplar.FillWeight = 50
        Me.colEstadoEjemplar.ReadOnly = True
        Me.colEstadoEjemplar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tabla.Columns.Add(Me.colEstadoEjemplar)
        Me.lblResumen.Name = "lblResumen"
        Me.lblResumen.Text = "Sin datos cargados. Abre la pantalla para consultar."
        Me.lblResumen.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120)
        Me.lblResumen.AutoSize = False
        Me.lblResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblResumen.AutoEllipsis = True
        Me.layoutVista.Controls.Add(Me.encabezado, 0, 0)
        Me.layoutVista.Controls.Add(Me.barraFiltros, 0, 1)
        Me.layoutVista.Controls.Add(Me.barraAcciones, 0, 2)
        Me.layoutVista.Controls.Add(Me.tabla, 0, 3)
        Me.layoutVista.Controls.Add(Me.lblResumen, 0, 4)
        Me.colActivo.Visible = False
        Me.Controls.Add(Me.layoutVista)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Name = "frmEjemplares"
        Me.Text = "Ejemplares"
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
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEstado As System.Windows.Forms.Button
    Friend WithEvents btnVolver As System.Windows.Forms.Button
    Friend WithEvents tabla As System.Windows.Forms.DataGridView
    Friend WithEvents tablaCabecera As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents tablaCeldas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents tablaAlternas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents colIdEjemplar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstadoEjemplar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblResumen As System.Windows.Forms.Label
End Class
