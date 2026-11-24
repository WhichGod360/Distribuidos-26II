<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPagosYape
    Inherits System.Windows.Forms.Form

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
        Me.encabezado = New Panel()
        Me.lblTitulo = New Label()
        Me.lblDescripcion = New Label()
        Me.filtros = New Panel()
        Me.lblBuscar = New Label()
        Me.txtBuscar = New TextBox()
        Me.btnBuscar = New Button()
        Me.lblEstado = New Label()
        Me.cboEstado = New ComboBox()
        Me.acciones = New FlowLayoutPanel()
        Me.btnAbrirReporte = New Button()
        Me.btnActualizar = New Button()
        Me.btnCerrar = New Button()
        Me.tablaReportes = New DataGridView()
        Me.colReporte = New DataGridViewTextBoxColumn()
        Me.colCargo = New DataGridViewTextBoxColumn()
        Me.colLector = New DataGridViewTextBoxColumn()
        Me.colImporte = New DataGridViewTextBoxColumn()
        Me.colFecha = New DataGridViewTextBoxColumn()
        Me.colEstado = New DataGridViewTextBoxColumn()
        Me.lblResumen = New Label()
        Me.encabezado.SuspendLayout()
        Me.filtros.SuspendLayout()
        Me.acciones.SuspendLayout()
        CType(Me.tablaReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' encabezado
        Me.encabezado.Name = "encabezado"
        Me.encabezado.Dock = DockStyle.Top
        Me.encabezado.Height = 70
        Me.encabezado.Margin = Padding.Empty
        Me.encabezado.Controls.Add(Me.lblTitulo)
        Me.encabezado.Controls.Add(Me.lblDescripcion)

        ' lblTitulo
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Text = "Revisar pagos por Yape"
        Me.lblTitulo.ForeColor = Color.FromArgb(47, 72, 92)
        Me.lblTitulo.Location = New Point(0, 0)
        Me.lblTitulo.Size = New Size(880, 36)
        Me.lblTitulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Me.lblTitulo.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)

        ' lblDescripcion
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Text = "Abre un reporte para consultar el comprobante o registrar una decisión."
        Me.lblDescripcion.ForeColor = Color.FromArgb(120, 120, 120)
        Me.lblDescripcion.Location = New Point(0, 38)
        Me.lblDescripcion.Size = New Size(880, 25)
        Me.lblDescripcion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' filtros
        Me.filtros.Name = "filtros"
        Me.filtros.Dock = DockStyle.Top
        Me.filtros.Height = 60
        Me.filtros.Margin = Padding.Empty
        Me.filtros.Controls.Add(Me.lblBuscar)
        Me.filtros.Controls.Add(Me.txtBuscar)
        Me.filtros.Controls.Add(Me.lblEstado)
        Me.filtros.Controls.Add(Me.cboEstado)
        Me.filtros.Controls.Add(Me.btnBuscar)

        ' lblBuscar
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Text = "Buscar"
        Me.lblBuscar.ForeColor = Color.FromArgb(47, 72, 92)
        Me.lblBuscar.Location = New Point(0, 0)
        Me.lblBuscar.Size = New Size(295, 21)

        ' txtBuscar
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Location = New Point(0, 22)
        Me.txtBuscar.Size = New Size(295, 26)
        Me.txtBuscar.TabIndex = 0
        Me.txtBuscar.PlaceholderText = "Buscar..."
        Me.txtBuscar.AccessibleName = "Buscar reporte, cargo o lector"

        ' lblEstado
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Text = "Estado del reporte"
        Me.lblEstado.ForeColor = Color.FromArgb(47, 72, 92)
        Me.lblEstado.Location = New Point(311, 0)
        Me.lblEstado.Size = New Size(160, 21)

        ' cboEstado
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Location = New Point(311, 22)
        Me.cboEstado.Size = New Size(160, 26)
        Me.cboEstado.TabIndex = 1
        Me.cboEstado.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboEstado.AccessibleName = "Estado del reporte"
        Me.cboEstado.Items.AddRange(New Object() {"En revisión", "Confirmados", "Denegados", "Todos"})

        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Location = New Point(486, 18)
        Me.btnBuscar.Size = New Size(92, 32)
        Me.btnBuscar.TabIndex = 2

        ' acciones
        Me.acciones.Name = "acciones"
        Me.acciones.Dock = DockStyle.Top
        Me.acciones.Height = 49
        Me.acciones.WrapContents = False
        Me.acciones.Controls.Add(Me.btnAbrirReporte)
        Me.acciones.Controls.Add(Me.btnActualizar)
        Me.acciones.Controls.Add(Me.btnCerrar)

        ' btnAbrirReporte
        Me.btnAbrirReporte.Name = "btnAbrirReporte"
        Me.btnAbrirReporte.Text = "Abrir reporte"
        Me.btnAbrirReporte.Size = New Size(126, 36)
        Me.btnAbrirReporte.Margin = New Padding(0, 0, 10, 0)
        Me.btnAbrirReporte.FlatStyle = FlatStyle.Flat
        Me.btnAbrirReporte.FlatAppearance.BorderSize = 1
        Me.btnAbrirReporte.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        Me.btnAbrirReporte.BackColor = Color.White
        Me.btnAbrirReporte.ForeColor = Color.FromArgb(59, 91, 115)
        Me.btnAbrirReporte.Font = New Font("Segoe UI Semibold", 10.0F)
        Me.btnAbrirReporte.Cursor = Cursors.Hand
        Me.btnAbrirReporte.UseVisualStyleBackColor = False
        Me.btnAbrirReporte.TabIndex = 0
        Me.btnAbrirReporte.Enabled = False

        ' btnActualizar
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.Size = New Size(112, 36)
        Me.btnActualizar.Margin = New Padding(0, 0, 10, 0)
        Me.btnActualizar.FlatStyle = FlatStyle.Flat
        Me.btnActualizar.FlatAppearance.BorderSize = 1
        Me.btnActualizar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        Me.btnActualizar.BackColor = Color.White
        Me.btnActualizar.ForeColor = Color.FromArgb(59, 91, 115)
        Me.btnActualizar.Font = New Font("Segoe UI Semibold", 10.0F)
        Me.btnActualizar.Cursor = Cursors.Hand
        Me.btnActualizar.UseVisualStyleBackColor = False
        Me.btnActualizar.TabIndex = 1

        ' btnCerrar
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.Size = New Size(112, 36)
        Me.btnCerrar.Margin = New Padding(0, 0, 10, 0)
        Me.btnCerrar.FlatStyle = FlatStyle.Flat
        Me.btnCerrar.FlatAppearance.BorderSize = 1
        Me.btnCerrar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        Me.btnCerrar.BackColor = Color.White
        Me.btnCerrar.ForeColor = Color.FromArgb(59, 91, 115)
        Me.btnCerrar.Font = New Font("Segoe UI Semibold", 10.0F)
        Me.btnCerrar.Cursor = Cursors.Hand
        Me.btnCerrar.UseVisualStyleBackColor = False
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.DialogResult = DialogResult.Cancel

        ' tablaReportes
        Me.tablaReportes.Name = "tablaReportes"
        Me.tablaReportes.AccessibleName = "Reportes de Yape"
        Me.tablaReportes.AutoGenerateColumns = False
        Me.tablaReportes.ReadOnly = True
        Me.tablaReportes.MultiSelect = False
        Me.tablaReportes.AllowUserToAddRows = False
        Me.tablaReportes.AllowUserToDeleteRows = False
        Me.tablaReportes.RowHeadersVisible = False
        Me.tablaReportes.EnableHeadersVisualStyles = False
        Me.tablaReportes.BackgroundColor = Color.White
        Me.tablaReportes.BorderStyle = BorderStyle.None
        Me.tablaReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.tablaReportes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.tablaReportes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        Me.tablaReportes.GridColor = Color.FromArgb(222, 225, 236)
        Me.tablaReportes.ColumnHeadersHeight = 40
        Me.tablaReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.tablaReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.tablaReportes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 238, 255)
        Me.tablaReportes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(20, 20, 30)
        Me.tablaReportes.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Me.tablaReportes.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Me.tablaReportes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 255)
        Me.tablaReportes.Dock = DockStyle.Fill
        Me.tablaReportes.TabIndex = 0
        Me.tablaReportes.Columns.AddRange(New DataGridViewColumn() {Me.colReporte, Me.colCargo, Me.colLector, Me.colImporte, Me.colFecha, Me.colEstado})

        ' colReporte
        Me.colReporte.Name = "colReporte"
        Me.colReporte.HeaderText = "Reporte"
        Me.colReporte.FillWeight = 65.0F
        Me.colReporte.SortMode = DataGridViewColumnSortMode.NotSortable

        ' colCargo
        Me.colCargo.Name = "colCargo"
        Me.colCargo.HeaderText = "Cargo"
        Me.colCargo.FillWeight = 55.0F
        Me.colCargo.SortMode = DataGridViewColumnSortMode.NotSortable

        ' colLector
        Me.colLector.Name = "colLector"
        Me.colLector.HeaderText = "Lector"
        Me.colLector.FillWeight = 180.0F
        Me.colLector.SortMode = DataGridViewColumnSortMode.NotSortable

        ' colImporte
        Me.colImporte.Name = "colImporte"
        Me.colImporte.HeaderText = "Importe (S/)"
        Me.colImporte.FillWeight = 85.0F
        Me.colImporte.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.colImporte.DefaultCellStyle.Format = "N2"

        ' colFecha
        Me.colFecha.Name = "colFecha"
        Me.colFecha.HeaderText = "Fecha (Lima)"
        Me.colFecha.FillWeight = 120.0F
        Me.colFecha.SortMode = DataGridViewColumnSortMode.NotSortable
        Me.colFecha.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

        ' colEstado
        Me.colEstado.Name = "colEstado"
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.FillWeight = 105.0F
        Me.colEstado.SortMode = DataGridViewColumnSortMode.NotSortable

        ' lblResumen
        Me.lblResumen.Name = "lblResumen"
        Me.lblResumen.Text = ""
        Me.lblResumen.ForeColor = Color.FromArgb(120, 120, 120)
        Me.lblResumen.Dock = DockStyle.Bottom
        Me.lblResumen.Height = 34
        Me.lblResumen.TextAlign = ContentAlignment.MiddleLeft

        ' frmPagosYape
        Me.Name = "frmPagosYape"
        Me.Text = "Revisar pagos por Yape"
        Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9.0F)
        Me.ClientSize = New Size(930, 520)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ShowInTaskbar = False
        Me.MinimizeBox = False
        Me.Padding = New Padding(24, 18, 24, 14)
        Me.CancelButton = Me.btnCerrar
        Me.Controls.Add(Me.tablaReportes)
        Me.Controls.Add(Me.lblResumen)
        Me.Controls.Add(Me.acciones)
        Me.Controls.Add(Me.filtros)
        Me.Controls.Add(Me.encabezado)
        CType(Me.tablaReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.acciones.ResumeLayout(False)
        Me.filtros.ResumeLayout(False)
        Me.encabezado.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Private components As System.ComponentModel.IContainer
    Friend WithEvents encabezado As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents filtros As Panel
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblEstado As Label
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents acciones As FlowLayoutPanel
    Friend WithEvents btnAbrirReporte As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents tablaReportes As DataGridView
    Friend WithEvents colReporte As DataGridViewTextBoxColumn
    Friend WithEvents colCargo As DataGridViewTextBoxColumn
    Friend WithEvents colLector As DataGridViewTextBoxColumn
    Friend WithEvents colImporte As DataGridViewTextBoxColumn
    Friend WithEvents colFecha As DataGridViewTextBoxColumn
    Friend WithEvents colEstado As DataGridViewTextBoxColumn
    Friend WithEvents lblResumen As Label
End Class
