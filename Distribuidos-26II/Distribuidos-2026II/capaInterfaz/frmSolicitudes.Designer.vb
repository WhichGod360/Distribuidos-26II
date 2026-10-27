<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSolicitudes
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        layoutVista = New TableLayoutPanel()
        encabezado = New Panel()
        lblDescripcionVista = New Label()
        lblTituloVista = New Label()
        barraFiltros = New FlowLayoutPanel()
        txtBuscar = New TextBox()
        cboEstado = New ComboBox()
        barraAcciones = New FlowLayoutPanel()
        btnAprobar = New Button()
        btnEntregar = New Button()
        btnRechazar = New Button()
        btnActualizar = New Button()
        btnComprobante = New Button()
        tabla = New DataGridView()
        tablaDetalle = New DataGridView()
        lblResumen = New Label()
        layoutVista.SuspendLayout()
        encabezado.SuspendLayout()
        barraFiltros.SuspendLayout()
        barraAcciones.SuspendLayout()
        CType(tabla, ISupportInitialize).BeginInit()
        CType(tablaDetalle, ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' layoutVista
        ' 
        layoutVista.ColumnCount = 1
        layoutVista.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layoutVista.Controls.Add(encabezado, 0, 0)
        layoutVista.Controls.Add(barraFiltros, 0, 1)
        layoutVista.Controls.Add(barraAcciones, 0, 2)
        layoutVista.Controls.Add(tabla, 0, 3)
        layoutVista.Controls.Add(tablaDetalle, 0, 4)
        layoutVista.Controls.Add(lblResumen, 0, 5)
        layoutVista.Dock = DockStyle.Fill
        layoutVista.Location = New Point(0, 0)
        layoutVista.Margin = New Padding(0)
        layoutVista.Name = "layoutVista"
        layoutVista.Padding = New Padding(24, 18, 24, 14)
        layoutVista.RowCount = 6
        layoutVista.RowStyles.Add(New RowStyle(SizeType.Absolute, 70F))
        layoutVista.RowStyles.Add(New RowStyle(SizeType.Absolute, 44F))
        layoutVista.RowStyles.Add(New RowStyle(SizeType.Absolute, 48F))
        layoutVista.RowStyles.Add(New RowStyle(SizeType.Percent, 65F))
        layoutVista.RowStyles.Add(New RowStyle(SizeType.Percent, 35F))
        layoutVista.RowStyles.Add(New RowStyle(SizeType.Absolute, 36F))
        layoutVista.Size = New Size(1100, 680)
        layoutVista.TabIndex = 0
        ' 
        ' encabezado
        ' 
        encabezado.Controls.Add(lblDescripcionVista)
        encabezado.Controls.Add(lblTituloVista)
        encabezado.Dock = DockStyle.Fill
        encabezado.Location = New Point(24, 18)
        encabezado.Margin = New Padding(0)
        encabezado.Name = "encabezado"
        encabezado.Size = New Size(1052, 70)
        encabezado.TabIndex = 0
        ' 
        ' lblDescripcionVista
        ' 
        lblDescripcionVista.Dock = DockStyle.Fill
        lblDescripcionVista.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblDescripcionVista.Location = New Point(0, 38)
        lblDescripcionVista.Name = "lblDescripcionVista"
        lblDescripcionVista.Size = New Size(1052, 32)
        lblDescripcionVista.TabIndex = 0
        lblDescripcionVista.Text = "Aprueba primero. Registra los préstamos cuando entregues los ejemplares."
        ' 
        ' lblTituloVista
        ' 
        lblTituloVista.Dock = DockStyle.Top
        lblTituloVista.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblTituloVista.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblTituloVista.Location = New Point(0, 0)
        lblTituloVista.Name = "lblTituloVista"
        lblTituloVista.Size = New Size(1052, 38)
        lblTituloVista.TabIndex = 1
        lblTituloVista.Text = "Solicitudes y reservas"
        ' 
        ' barraFiltros
        ' 
        barraFiltros.Controls.Add(txtBuscar)
        barraFiltros.Controls.Add(cboEstado)
        barraFiltros.Dock = DockStyle.Fill
        barraFiltros.Location = New Point(24, 88)
        barraFiltros.Margin = New Padding(0)
        barraFiltros.Name = "barraFiltros"
        barraFiltros.Size = New Size(1052, 44)
        barraFiltros.TabIndex = 1
        barraFiltros.WrapContents = False
        ' 
        ' txtBuscar
        ' 
        txtBuscar.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtBuscar.BorderStyle = BorderStyle.FixedSingle
        txtBuscar.Font = New Font("Segoe UI", 11F)
        txtBuscar.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtBuscar.Location = New Point(0, 6)
        txtBuscar.Margin = New Padding(0, 6, 12, 0)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.PlaceholderText = "Buscar lector, DNI, libro o solicitud"
        txtBuscar.Size = New Size(330, 32)
        txtBuscar.TabIndex = 0
        ' 
        ' cboEstado
        ' 
        cboEstado.DropDownStyle = ComboBoxStyle.DropDownList
        cboEstado.Font = New Font("Segoe UI", 11F)
        cboEstado.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        cboEstado.FormattingEnabled = True
        cboEstado.Items.AddRange(New Object() {"Todos", "Pendiente", "Aprobada", "Atendida", "Rechazada", "Cancelada", "Vencida"})
        cboEstado.Location = New Point(342, 6)
        cboEstado.Margin = New Padding(0, 6, 12, 0)
        cboEstado.Name = "cboEstado"
        cboEstado.Size = New Size(190, 33)
        cboEstado.TabIndex = 1
        ' 
        ' barraAcciones
        ' 
        barraAcciones.Controls.Add(btnAprobar)
        barraAcciones.Controls.Add(btnEntregar)
        barraAcciones.Controls.Add(btnRechazar)
        barraAcciones.Controls.Add(btnActualizar)
        barraAcciones.Controls.Add(btnComprobante)
        barraAcciones.Dock = DockStyle.Fill
        barraAcciones.Location = New Point(24, 132)
        barraAcciones.Margin = New Padding(0)
        barraAcciones.Name = "barraAcciones"
        barraAcciones.Size = New Size(1052, 48)
        barraAcciones.TabIndex = 2
        barraAcciones.WrapContents = False
        ' 
        ' btnAprobar
        ' 
        btnAprobar.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnAprobar.Cursor = Cursors.Hand
        btnAprobar.Enabled = False
        btnAprobar.FlatAppearance.BorderSize = 0
        btnAprobar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btnAprobar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btnAprobar.FlatStyle = FlatStyle.Flat
        btnAprobar.Font = New Font("Segoe UI Semibold", 10F)
        btnAprobar.ForeColor = Color.White
        btnAprobar.Location = New Point(0, 0)
        btnAprobar.Margin = New Padding(0, 0, 10, 0)
        btnAprobar.Name = "btnAprobar"
        btnAprobar.Size = New Size(160, 36)
        btnAprobar.TabIndex = 0
        btnAprobar.Text = "Aprobar solicitud"
        btnAprobar.UseVisualStyleBackColor = False
        ' 
        ' btnEntregar
        ' 
        btnEntregar.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnEntregar.Cursor = Cursors.Hand
        btnEntregar.Enabled = False
        btnEntregar.FlatAppearance.BorderSize = 0
        btnEntregar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btnEntregar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btnEntregar.FlatStyle = FlatStyle.Flat
        btnEntregar.Font = New Font("Segoe UI Semibold", 10F)
        btnEntregar.ForeColor = Color.White
        btnEntregar.Location = New Point(170, 0)
        btnEntregar.Margin = New Padding(0, 0, 10, 0)
        btnEntregar.Name = "btnEntregar"
        btnEntregar.Size = New Size(160, 36)
        btnEntregar.TabIndex = 1
        btnEntregar.Text = "Entregar libros"
        btnEntregar.UseVisualStyleBackColor = False
        ' 
        ' btnRechazar
        ' 
        btnRechazar.BackColor = Color.White
        btnRechazar.Cursor = Cursors.Hand
        btnRechazar.Enabled = False
        btnRechazar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnRechazar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnRechazar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnRechazar.FlatStyle = FlatStyle.Flat
        btnRechazar.Font = New Font("Segoe UI Semibold", 10F)
        btnRechazar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnRechazar.Location = New Point(340, 0)
        btnRechazar.Margin = New Padding(0, 0, 10, 0)
        btnRechazar.Name = "btnRechazar"
        btnRechazar.Size = New Size(170, 36)
        btnRechazar.TabIndex = 2
        btnRechazar.Text = "Rechazar solicitud"
        btnRechazar.UseVisualStyleBackColor = False
        ' 
        ' btnActualizar
        ' 
        btnActualizar.BackColor = Color.White
        btnActualizar.Cursor = Cursors.Hand
        btnActualizar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnActualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnActualizar.FlatStyle = FlatStyle.Flat
        btnActualizar.Font = New Font("Segoe UI Semibold", 10F)
        btnActualizar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizar.Location = New Point(520, 0)
        btnActualizar.Margin = New Padding(0, 0, 10, 0)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(120, 36)
        btnActualizar.TabIndex = 3
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = False
        ' 
        ' btnComprobante
        ' 
        btnComprobante.BackColor = Color.White
        btnComprobante.Cursor = Cursors.Hand
        btnComprobante.Enabled = False
        btnComprobante.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnComprobante.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnComprobante.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnComprobante.FlatStyle = FlatStyle.Flat
        btnComprobante.Font = New Font("Segoe UI Semibold", 10F)
        btnComprobante.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnComprobante.Location = New Point(650, 0)
        btnComprobante.Margin = New Padding(0, 0, 10, 0)
        btnComprobante.Name = "btnComprobante"
        btnComprobante.Size = New Size(195, 36)
        btnComprobante.TabIndex = 4
        btnComprobante.Text = "Comprobante entrega"
        btnComprobante.UseVisualStyleBackColor = False
        ' 
        ' tabla
        ' 
        tabla.AllowUserToAddRows = False
        tabla.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        tabla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        tabla.BackgroundColor = Color.White
        tabla.BorderStyle = BorderStyle.None
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle2.Font = New Font("Segoe UI Semibold", 9F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        tabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        tabla.ColumnHeadersHeight = 40
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 10F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        tabla.DefaultCellStyle = DataGridViewCellStyle3
        tabla.Dock = DockStyle.Fill
        tabla.EnableHeadersVisualStyles = False
        tabla.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tabla.Location = New Point(24, 180)
        tabla.Margin = New Padding(0, 0, 0, 10)
        tabla.MultiSelect = False
        tabla.Name = "tabla"
        tabla.ReadOnly = True
        tabla.RowHeadersVisible = False
        tabla.RowHeadersWidth = 51
        tabla.RowTemplate.Height = 36
        tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tabla.Size = New Size(1052, 282)
        tabla.TabIndex = 3
        ' 
        ' tablaDetalle
        ' 
        tablaDetalle.AllowUserToAddRows = False
        tablaDetalle.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        tablaDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        tablaDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        tablaDetalle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        tablaDetalle.BackgroundColor = Color.White
        tablaDetalle.BorderStyle = BorderStyle.None
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle5.Font = New Font("Segoe UI Semibold", 9F)
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        tablaDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        tablaDetalle.ColumnHeadersHeight = 40
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = Color.White
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 10F)
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        tablaDetalle.DefaultCellStyle = DataGridViewCellStyle6
        tablaDetalle.Dock = DockStyle.Fill
        tablaDetalle.EnableHeadersVisualStyles = False
        tablaDetalle.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tablaDetalle.Location = New Point(24, 472)
        tablaDetalle.Margin = New Padding(0)
        tablaDetalle.MultiSelect = False
        tablaDetalle.Name = "tablaDetalle"
        tablaDetalle.ReadOnly = True
        tablaDetalle.RowHeadersVisible = False
        tablaDetalle.RowHeadersWidth = 51
        tablaDetalle.RowTemplate.Height = 36
        tablaDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tablaDetalle.Size = New Size(1052, 157)
        tablaDetalle.TabIndex = 4
        ' 
        ' lblResumen
        ' 
        lblResumen.AutoEllipsis = True
        lblResumen.Dock = DockStyle.Fill
        lblResumen.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblResumen.Location = New Point(24, 629)
        lblResumen.Margin = New Padding(0)
        lblResumen.Name = "lblResumen"
        lblResumen.Size = New Size(1052, 37)
        lblResumen.TabIndex = 5
        lblResumen.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' frmSolicitudes
        ' 
        AutoScaleDimensions = New SizeF(120F, 120F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.White
        ClientSize = New Size(1100, 680)
        Controls.Add(layoutVista)
        Font = New Font("Segoe UI", 10F)
        Name = "frmSolicitudes"
        Text = "Solicitudes y reservas"
        layoutVista.ResumeLayout(False)
        encabezado.ResumeLayout(False)
        barraFiltros.ResumeLayout(False)
        barraFiltros.PerformLayout()
        barraAcciones.ResumeLayout(False)
        CType(tabla, ISupportInitialize).EndInit()
        CType(tablaDetalle, ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents layoutVista As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents encabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTituloVista As System.Windows.Forms.Label
    Friend WithEvents lblDescripcionVista As System.Windows.Forms.Label
    Friend WithEvents barraFiltros As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents barraAcciones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
    Friend WithEvents btnEntregar As System.Windows.Forms.Button
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnComprobante As System.Windows.Forms.Button
    Friend WithEvents tabla As System.Windows.Forms.DataGridView
    Friend WithEvents tablaDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents lblResumen As System.Windows.Forms.Label
End Class
