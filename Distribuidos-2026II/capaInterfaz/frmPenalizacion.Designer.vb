<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPenalizacion
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
        Me.cboFiltroEstado = New System.Windows.Forms.ComboBox()
        Me.bloque_cboFiltroEstado = New System.Windows.Forms.Panel()
        Me.etiqueta_cboFiltroEstado = New System.Windows.Forms.Label()
        Me.barraAcciones = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCambiarEstado = New System.Windows.Forms.Button()
        Me.btnVerDetalles = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1Cabecera = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1Celdas = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1Alternas = New System.Windows.Forms.DataGridViewCellStyle()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblResumen = New System.Windows.Forms.Label()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.encabezado.SuspendLayout()
        Me.textoEncabezado.SuspendLayout()
        Me.layoutVista.SuspendLayout()
        Me.barraFiltros.SuspendLayout()
        Me.bloque_txtBuscar.SuspendLayout()
        Me.bloque_cboFiltroEstado.SuspendLayout()
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
        Me.lblTituloVista.Text = "Penalizaciones"
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Administra las sanciones, sus montos y su estado."
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
        Me.layoutVista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52!))
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
        Me.cboFiltroEstado.Name = "cboFiltroEstado"
        Me.cboFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFiltroEstado.Items.AddRange(New Object() {"Todos", "Activo", "Inactivo"})
        Me.bloque_cboFiltroEstado.Name = "bloque_cboFiltroEstado"
        Me.bloque_cboFiltroEstado.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_cboFiltroEstado.Size = New System.Drawing.Size(180, 58)
        Me.bloque_cboFiltroEstado.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_cboFiltroEstado.Name = "etiqueta_cboFiltroEstado"
        Me.etiqueta_cboFiltroEstado.Text = "Estado"
        Me.etiqueta_cboFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.etiqueta_cboFiltroEstado.AutoSize = False
        Me.etiqueta_cboFiltroEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_cboFiltroEstado.Height = 24
        Me.etiqueta_cboFiltroEstado.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.cboFiltroEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboFiltroEstado.Height = 30
        Me.bloque_cboFiltroEstado.Controls.Add(Me.cboFiltroEstado)
        Me.bloque_cboFiltroEstado.Controls.Add(Me.etiqueta_cboFiltroEstado)
        Me.barraFiltros.Controls.Add(Me.bloque_cboFiltroEstado)
        Me.barraAcciones.Name = "barraAcciones"
        Me.barraAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barraAcciones.AutoSize = True
        Me.barraAcciones.WrapContents = True
        Me.barraAcciones.Margin = New System.Windows.Forms.Padding(0, 4, 0, 10)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Text = "Agregar penalización"
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
        Me.btnNuevo.Enabled = True
        Me.barraAcciones.Controls.Add(Me.btnNuevo)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Text = "Editar"
        Me.btnGuardar.Size = New System.Drawing.Size(170, 38)
        Me.btnGuardar.AutoSize = False
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.FlatAppearance.BorderSize = 1
        Me.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnGuardar.BackColor = System.Drawing.Color.White
        Me.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnGuardar.UseVisualStyleBackColor = False
        Me.btnGuardar.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnGuardar)
        Me.btnCambiarEstado.Name = "btnCambiarEstado"
        Me.btnCambiarEstado.Text = "Desactivar"
        Me.btnCambiarEstado.Size = New System.Drawing.Size(170, 38)
        Me.btnCambiarEstado.AutoSize = False
        Me.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCambiarEstado.FlatAppearance.BorderSize = 1
        Me.btnCambiarEstado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnCambiarEstado.BackColor = System.Drawing.Color.White
        Me.btnCambiarEstado.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnCambiarEstado.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCambiarEstado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCambiarEstado.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnCambiarEstado.UseVisualStyleBackColor = False
        Me.btnCambiarEstado.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnCambiarEstado)
        Me.btnVerDetalles.Name = "btnVerDetalles"
        Me.btnVerDetalles.Text = "Ver detalles"
        Me.btnVerDetalles.Size = New System.Drawing.Size(170, 38)
        Me.btnVerDetalles.AutoSize = False
        Me.btnVerDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerDetalles.FlatAppearance.BorderSize = 1
        Me.btnVerDetalles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 222, 237)
        Me.btnVerDetalles.BackColor = System.Drawing.Color.White
        Me.btnVerDetalles.ForeColor = System.Drawing.Color.FromArgb(72, 101, 244)
        Me.btnVerDetalles.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnVerDetalles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerDetalles.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnVerDetalles.UseVisualStyleBackColor = False
        Me.btnVerDetalles.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnVerDetalles)
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
        Me.DataGridView1Cabecera.BackColor = System.Drawing.Color.FromArgb(234, 239, 255)
        Me.DataGridView1Cabecera.ForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.DataGridView1Cabecera.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.DataGridView1Celdas.SelectionBackColor = System.Drawing.Color.FromArgb(222, 229, 255)
        Me.DataGridView1Celdas.SelectionForeColor = System.Drawing.Color.FromArgb(28, 36, 55)
        Me.DataGridView1Celdas.NullValue = "—"
        Me.DataGridView1Alternas.BackColor = System.Drawing.Color.FromArgb(248, 250, 255)
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = Me.DataGridView1Cabecera
        Me.DataGridView1.DefaultCellStyle = Me.DataGridView1Celdas
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = Me.DataGridView1Alternas
        Me.colId.Name = "colId"
        Me.colId.HeaderText = "ID"
        Me.colId.DataPropertyName = ""
        Me.colId.Width = 10
        Me.colId.FillWeight = 10
        Me.colId.ReadOnly = True
        Me.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colId)
        Me.colTipo.Name = "colTipo"
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.DataPropertyName = ""
        Me.colTipo.Width = 23
        Me.colTipo.FillWeight = 23
        Me.colTipo.ReadOnly = True
        Me.colTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colTipo)
        Me.colMonto.Name = "colMonto"
        Me.colMonto.HeaderText = "Monto"
        Me.colMonto.DataPropertyName = ""
        Me.colMonto.Width = 12
        Me.colMonto.FillWeight = 12
        Me.colMonto.ReadOnly = True
        Me.colMonto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colMonto)
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.DataPropertyName = ""
        Me.colDescripcion.Width = 37
        Me.colDescripcion.FillWeight = 37
        Me.colDescripcion.ReadOnly = True
        Me.colDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colDescripcion)
        Me.colEstado.Name = "colEstado"
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.DataPropertyName = ""
        Me.colEstado.Width = 18
        Me.colEstado.FillWeight = 18
        Me.colEstado.ReadOnly = True
        Me.colEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridView1.Columns.Add(Me.colEstado)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Name = "frmPenalizacion"
        Me.Text = "Penalizaciones"
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barraAcciones.ResumeLayout(False)
        Me.barraAcciones.PerformLayout()
        Me.bloque_cboFiltroEstado.ResumeLayout(False)
        Me.bloque_cboFiltroEstado.PerformLayout()
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
    Friend WithEvents cboFiltroEstado As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_cboFiltroEstado As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_cboFiltroEstado As System.Windows.Forms.Label
    Friend WithEvents barraAcciones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCambiarEstado As System.Windows.Forms.Button
    Friend WithEvents btnVerDetalles As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1Cabecera As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents DataGridView1Celdas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents DataGridView1Alternas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblResumen As System.Windows.Forms.Label
End Class
