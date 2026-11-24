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
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.barraFiltros = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.bloque_txtBuscar = New System.Windows.Forms.Panel()
        Me.etiqueta_txtBuscar = New System.Windows.Forms.Label()
        Me.cboFiltroEstado = New System.Windows.Forms.ComboBox()
        Me.bloque_cboFiltroEstado = New System.Windows.Forms.Panel()
        Me.etiqueta_cboFiltroEstado = New System.Windows.Forms.Label()
        Me.barraAcciones = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnCambiarEstado = New System.Windows.Forms.Button()
        Me.btnVerDetalles = New System.Windows.Forms.Button()
        Me.tablaPenalizaciones = New System.Windows.Forms.DataGridView()
        Me.DataGridView1Cabecera = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1Celdas = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1Alternas = New System.Windows.Forms.DataGridViewCellStyle()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTramo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblResumen = New System.Windows.Forms.Label()
        CType(Me.imagenModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tablaPenalizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.lblTituloVista.AutoSize = False
        Me.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloVista.Height = 38
        Me.lblTituloVista.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcionVista.Name = "lblDescripcionVista"
        Me.lblDescripcionVista.Text = "Administra las sanciones, sus montos y su estado."
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
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.PlaceholderText = "Buscar..."
        Me.bloque_txtBuscar.Name = "bloque_txtBuscar"
        Me.bloque_txtBuscar.Dock = System.Windows.Forms.DockStyle.None
        Me.bloque_txtBuscar.Size = New System.Drawing.Size(320, 58)
        Me.bloque_txtBuscar.Margin = New System.Windows.Forms.Padding(0, 0, 12, 6)
        Me.etiqueta_txtBuscar.Name = "etiqueta_txtBuscar"
        Me.etiqueta_txtBuscar.Text = "Buscar"
        Me.etiqueta_txtBuscar.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.etiqueta_txtBuscar.AutoSize = False
        Me.etiqueta_txtBuscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_txtBuscar.Height = 24
        Me.etiqueta_txtBuscar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
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
        Me.etiqueta_cboFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.etiqueta_cboFiltroEstado.AutoSize = False
        Me.etiqueta_cboFiltroEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.etiqueta_cboFiltroEstado.Height = 24
        Me.etiqueta_cboFiltroEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.cboFiltroEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboFiltroEstado.Height = 30
        Me.bloque_cboFiltroEstado.Controls.Add(Me.cboFiltroEstado)
        Me.bloque_cboFiltroEstado.Controls.Add(Me.etiqueta_cboFiltroEstado)
        Me.barraFiltros.Controls.Add(Me.bloque_cboFiltroEstado)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Size = New System.Drawing.Size(96, 32)
        Me.btnBuscar.AutoSize = False
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.FlatAppearance.BorderSize = 1
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 244, 247)
        Me.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(225, 232, 238)
        Me.btnBuscar.BackColor = System.Drawing.Color.White
        Me.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(0, 20, 10, 6)
        Me.btnBuscar.UseVisualStyleBackColor = False
        Me.barraFiltros.Controls.Add(Me.btnBuscar)
        Me.barraAcciones.Name = "barraAcciones"
        Me.barraAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barraAcciones.AutoSize = True
        Me.barraAcciones.WrapContents = True
        Me.barraAcciones.Margin = New System.Windows.Forms.Padding(0, 4, 0, 10)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "Agregar penalización"
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
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.Size = New System.Drawing.Size(170, 38)
        Me.btnEditar.AutoSize = False
        Me.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditar.FlatAppearance.BorderSize = 1
        Me.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 244, 247)
        Me.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(225, 232, 238)
        Me.btnEditar.BackColor = System.Drawing.Color.White
        Me.btnEditar.ForeColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnEditar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
        Me.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditar.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnEditar.UseVisualStyleBackColor = False
        Me.btnEditar.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnEditar)
        Me.btnCambiarEstado.Name = "btnCambiarEstado"
        Me.btnCambiarEstado.Text = "Desactivar"
        Me.btnCambiarEstado.Size = New System.Drawing.Size(170, 38)
        Me.btnCambiarEstado.AutoSize = False
        Me.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCambiarEstado.FlatAppearance.BorderSize = 1
        Me.btnCambiarEstado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnCambiarEstado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 244, 247)
        Me.btnCambiarEstado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(225, 232, 238)
        Me.btnCambiarEstado.BackColor = System.Drawing.Color.White
        Me.btnCambiarEstado.ForeColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnCambiarEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
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
        Me.btnVerDetalles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnVerDetalles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 244, 247)
        Me.btnVerDetalles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(225, 232, 238)
        Me.btnVerDetalles.BackColor = System.Drawing.Color.White
        Me.btnVerDetalles.ForeColor = System.Drawing.Color.FromArgb(59, 91, 115)
        Me.btnVerDetalles.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular)
        Me.btnVerDetalles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerDetalles.Margin = New System.Windows.Forms.Padding(0, 0, 10, 4)
        Me.btnVerDetalles.UseVisualStyleBackColor = False
        Me.btnVerDetalles.Enabled = False
        Me.barraAcciones.Controls.Add(Me.btnVerDetalles)
        Me.tablaPenalizaciones.Name = "tablaPenalizaciones"
        Me.tablaPenalizaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablaPenalizaciones.ReadOnly = True
        Me.tablaPenalizaciones.AllowUserToAddRows = False
        Me.tablaPenalizaciones.AllowUserToDeleteRows = False
        Me.tablaPenalizaciones.MultiSelect = False
        Me.tablaPenalizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tablaPenalizaciones.RowHeadersVisible = False
        Me.tablaPenalizaciones.AutoGenerateColumns = False
        Me.tablaPenalizaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tablaPenalizaciones.BackgroundColor = System.Drawing.Color.White
        Me.tablaPenalizaciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tablaPenalizaciones.GridColor = System.Drawing.Color.FromArgb(232, 236, 240)
        Me.tablaPenalizaciones.EnableHeadersVisualStyles = False
        Me.tablaPenalizaciones.ColumnHeadersHeight = 40
        Me.tablaPenalizaciones.RowTemplate.Height = 36
        Me.tablaPenalizaciones.Margin = New System.Windows.Forms.Padding(0)
        Me.tablaPenalizaciones.AccessibleName = "Tabla de resultados"
        Me.DataGridView1Cabecera.BackColor = System.Drawing.Color.FromArgb(226, 234, 240)
        Me.DataGridView1Cabecera.ForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.DataGridView1Cabecera.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular)
        Me.DataGridView1Celdas.SelectionBackColor = System.Drawing.Color.FromArgb(212, 226, 236)
        Me.DataGridView1Celdas.SelectionForeColor = System.Drawing.Color.FromArgb(47, 72, 92)
        Me.DataGridView1Celdas.NullValue = "—"
        Me.DataGridView1Alternas.BackColor = System.Drawing.Color.FromArgb(247, 249, 250)
        Me.tablaPenalizaciones.ColumnHeadersDefaultCellStyle = Me.DataGridView1Cabecera
        Me.tablaPenalizaciones.DefaultCellStyle = Me.DataGridView1Celdas
        Me.tablaPenalizaciones.AlternatingRowsDefaultCellStyle = Me.DataGridView1Alternas
        Me.colId.Name = "colId"
        Me.colId.HeaderText = "ID"
        Me.colId.DataPropertyName = "IdPenalizacion"
        Me.colId.Width = 10
        Me.colId.FillWeight = 10
        Me.colId.ReadOnly = True
        Me.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPenalizaciones.Columns.Add(Me.colId)
        Me.colTipo.Name = "colTipo"
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.DataPropertyName = "TipoPenalizacion"
        Me.colTipo.Width = 23
        Me.colTipo.FillWeight = 23
        Me.colTipo.ReadOnly = True
        Me.colTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPenalizaciones.Columns.Add(Me.colTipo)
        Me.colMonto.Name = "colMonto"
        Me.colMonto.HeaderText = "Monto"
        Me.colMonto.DataPropertyName = "MontoPenalizacion"
        Me.colMonto.Width = 12
        Me.colMonto.FillWeight = 12
        Me.colMonto.DefaultCellStyle.Format = "'S/ '#,##0.00"
        Me.colMonto.ReadOnly = True
        Me.colMonto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPenalizaciones.Columns.Add(Me.colMonto)
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.DataPropertyName = "DescripcionPenalizacion"
        Me.colDescripcion.Width = 37
        Me.colDescripcion.FillWeight = 37
        Me.colDescripcion.ReadOnly = True
        Me.colDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPenalizaciones.Columns.Add(Me.colDescripcion)
        Me.colEstado.Name = "colEstado"
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.DataPropertyName = "EstadoTexto"
        Me.colEstado.Width = 18
        Me.colEstado.FillWeight = 18
        Me.colEstado.ReadOnly = True
        Me.colEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPenalizaciones.Columns.Add(Me.colEstado)
        Me.colTramo.Name = "colTramo"
        Me.colTramo.HeaderText = "Aplicación"
        Me.colTramo.DataPropertyName = "TramoTexto"
        Me.colTramo.FillWeight = 20
        Me.colTramo.ReadOnly = True
        Me.colTramo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tablaPenalizaciones.Columns.Add(Me.colTramo)
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
        Me.layoutVista.Controls.Add(Me.tablaPenalizaciones, 0, 3)
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
        CType(Me.tablaPenalizaciones, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents barraFiltros As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents bloque_txtBuscar As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_txtBuscar As System.Windows.Forms.Label
    Friend WithEvents cboFiltroEstado As System.Windows.Forms.ComboBox
    Friend WithEvents bloque_cboFiltroEstado As System.Windows.Forms.Panel
    Friend WithEvents etiqueta_cboFiltroEstado As System.Windows.Forms.Label
    Friend WithEvents barraAcciones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnCambiarEstado As System.Windows.Forms.Button
    Friend WithEvents btnVerDetalles As System.Windows.Forms.Button
    Friend WithEvents tablaPenalizaciones As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1Cabecera As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents DataGridView1Celdas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents DataGridView1Alternas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTramo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblResumen As System.Windows.Forms.Label
End Class
