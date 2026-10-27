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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        encabezado = New TableLayoutPanel()
        imagenModulo = New PictureBox()
        textoEncabezado = New Panel()
        lblDescripcionVista = New Label()
        lblTituloVista = New Label()
        layoutVista = New TableLayoutPanel()
        barraFiltros = New FlowLayoutPanel()
        bloque_buscar = New Panel()
        buscar = New TextBox()
        etiqueta_buscar = New Label()
        bloque_filtroEstado = New Panel()
        filtroEstado = New ComboBox()
        etiqueta_filtroEstado = New Label()
        barraAcciones = New FlowLayoutPanel()
        btnNuevo = New Button()
        btnDevolver = New Button()
        btnActualizar = New Button()
        tabla = New DataGridView()
        resumen = New Label()
        encabezado.SuspendLayout()
        CType(imagenModulo, ISupportInitialize).BeginInit()
        textoEncabezado.SuspendLayout()
        layoutVista.SuspendLayout()
        barraFiltros.SuspendLayout()
        bloque_buscar.SuspendLayout()
        bloque_filtroEstado.SuspendLayout()
        barraAcciones.SuspendLayout()
        CType(tabla, ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' encabezado
        ' 
        encabezado.ColumnCount = 2
        encabezado.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 72F))
        encabezado.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        encabezado.Controls.Add(imagenModulo, 0, 0)
        encabezado.Controls.Add(textoEncabezado, 1, 0)
        encabezado.Dock = DockStyle.Fill
        encabezado.Location = New Point(24, 18)
        encabezado.Margin = New Padding(0)
        encabezado.Name = "encabezado"
        encabezado.RowCount = 1
        encabezado.RowStyles.Add(New RowStyle(SizeType.Absolute, 80F))
        encabezado.Size = New Size(1052, 84)
        encabezado.TabIndex = 0
        ' 
        ' imagenModulo
        ' 
        imagenModulo.AccessibleName = "Lecturae, biblioteca y comunidad"
        imagenModulo.Dock = DockStyle.Fill
        imagenModulo.Image = My.Resources.Resources.no
        imagenModulo.Location = New Point(0, 0)
        imagenModulo.Margin = New Padding(0, 0, 16, 10)
        imagenModulo.Name = "imagenModulo"
        imagenModulo.Size = New Size(56, 74)
        imagenModulo.SizeMode = PictureBoxSizeMode.Zoom
        imagenModulo.TabIndex = 0
        imagenModulo.TabStop = False
        ' 
        ' textoEncabezado
        ' 
        textoEncabezado.Controls.Add(lblDescripcionVista)
        textoEncabezado.Controls.Add(lblTituloVista)
        textoEncabezado.Dock = DockStyle.Fill
        textoEncabezado.Location = New Point(75, 3)
        textoEncabezado.Name = "textoEncabezado"
        textoEncabezado.Size = New Size(974, 78)
        textoEncabezado.TabIndex = 1
        ' 
        ' lblDescripcionVista
        ' 
        lblDescripcionVista.Dock = DockStyle.Fill
        lblDescripcionVista.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        lblDescripcionVista.Location = New Point(0, 38)
        lblDescripcionVista.Name = "lblDescripcionVista"
        lblDescripcionVista.Size = New Size(974, 40)
        lblDescripcionVista.TabIndex = 0
        lblDescripcionVista.Text = "Préstamos y devoluciones de copias físicas."
        ' 
        ' lblTituloVista
        ' 
        lblTituloVista.Dock = DockStyle.Top
        lblTituloVista.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblTituloVista.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        lblTituloVista.Location = New Point(0, 0)
        lblTituloVista.Name = "lblTituloVista"
        lblTituloVista.Size = New Size(974, 38)
        lblTituloVista.TabIndex = 1
        lblTituloVista.Text = "Préstamos"
        ' 
        ' layoutVista
        ' 
        layoutVista.ColumnCount = 1
        layoutVista.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layoutVista.Controls.Add(encabezado, 0, 0)
        layoutVista.Controls.Add(barraFiltros, 0, 1)
        layoutVista.Controls.Add(barraAcciones, 0, 2)
        layoutVista.Controls.Add(tabla, 0, 3)
        layoutVista.Controls.Add(resumen, 0, 4)
        layoutVista.Dock = DockStyle.Fill
        layoutVista.Location = New Point(0, 0)
        layoutVista.Margin = New Padding(0)
        layoutVista.Name = "layoutVista"
        layoutVista.Padding = New Padding(24, 18, 24, 12)
        layoutVista.RowCount = 5
        layoutVista.RowStyles.Add(New RowStyle(SizeType.Absolute, 84F))
        layoutVista.RowStyles.Add(New RowStyle())
        layoutVista.RowStyles.Add(New RowStyle())
        layoutVista.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        layoutVista.RowStyles.Add(New RowStyle(SizeType.Absolute, 52F))
        layoutVista.Size = New Size(1100, 680)
        layoutVista.TabIndex = 0
        ' 
        ' barraFiltros
        ' 
        barraFiltros.AutoSize = True
        barraFiltros.Controls.Add(bloque_buscar)
        barraFiltros.Controls.Add(bloque_filtroEstado)
        barraFiltros.Dock = DockStyle.Fill
        barraFiltros.Location = New Point(27, 105)
        barraFiltros.Name = "barraFiltros"
        barraFiltros.Size = New Size(1046, 64)
        barraFiltros.TabIndex = 1
        ' 
        ' bloque_buscar
        ' 
        bloque_buscar.Controls.Add(buscar)
        bloque_buscar.Controls.Add(etiqueta_buscar)
        bloque_buscar.Location = New Point(0, 0)
        bloque_buscar.Margin = New Padding(0, 0, 12, 6)
        bloque_buscar.Name = "bloque_buscar"
        bloque_buscar.Size = New Size(320, 58)
        bloque_buscar.TabIndex = 0
        ' 
        ' buscar
        ' 
        buscar.Dock = DockStyle.Top
        buscar.Location = New Point(0, 24)
        buscar.Name = "buscar"
        buscar.PlaceholderText = "Buscar..."
        buscar.Size = New Size(320, 30)
        buscar.TabIndex = 0
        ' 
        ' etiqueta_buscar
        ' 
        etiqueta_buscar.Dock = DockStyle.Top
        etiqueta_buscar.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular)
        etiqueta_buscar.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        etiqueta_buscar.Location = New Point(0, 0)
        etiqueta_buscar.Name = "etiqueta_buscar"
        etiqueta_buscar.Size = New Size(320, 24)
        etiqueta_buscar.TabIndex = 1
        etiqueta_buscar.Text = "Buscar"
        ' 
        ' bloque_filtroEstado
        ' 
        bloque_filtroEstado.Controls.Add(filtroEstado)
        bloque_filtroEstado.Controls.Add(etiqueta_filtroEstado)
        bloque_filtroEstado.Location = New Point(332, 0)
        bloque_filtroEstado.Margin = New Padding(0, 0, 12, 6)
        bloque_filtroEstado.Name = "bloque_filtroEstado"
        bloque_filtroEstado.Size = New Size(180, 58)
        bloque_filtroEstado.TabIndex = 1
        ' 
        ' filtroEstado
        ' 
        filtroEstado.Dock = DockStyle.Top
        filtroEstado.DropDownStyle = ComboBoxStyle.DropDownList
        filtroEstado.Items.AddRange(New Object() {"Todos", "Activos", "Vencidos", "Devueltos"})
        filtroEstado.Location = New Point(0, 24)
        filtroEstado.Name = "filtroEstado"
        filtroEstado.Size = New Size(180, 31)
        filtroEstado.TabIndex = 0
        ' 
        ' etiqueta_filtroEstado
        ' 
        etiqueta_filtroEstado.Dock = DockStyle.Top
        etiqueta_filtroEstado.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular)
        etiqueta_filtroEstado.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        etiqueta_filtroEstado.Location = New Point(0, 0)
        etiqueta_filtroEstado.Name = "etiqueta_filtroEstado"
        etiqueta_filtroEstado.Size = New Size(180, 24)
        etiqueta_filtroEstado.TabIndex = 1
        etiqueta_filtroEstado.Text = "Estado"
        ' 
        ' barraAcciones
        ' 
        barraAcciones.AutoSize = True
        barraAcciones.Controls.Add(btnNuevo)
        barraAcciones.Controls.Add(btnDevolver)
        barraAcciones.Controls.Add(btnActualizar)
        barraAcciones.Dock = DockStyle.Fill
        barraAcciones.Location = New Point(24, 176)
        barraAcciones.Margin = New Padding(0, 4, 0, 10)
        barraAcciones.Name = "barraAcciones"
        barraAcciones.Size = New Size(1052, 42)
        barraAcciones.TabIndex = 2
        ' 
        ' btnNuevo
        ' 
        btnNuevo.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnNuevo.Cursor = Cursors.Hand
        btnNuevo.Enabled = False
        btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(CByte(222), CByte(226), CByte(231))
        btnNuevo.FlatAppearance.BorderSize = 0
        btnNuevo.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btnNuevo.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btnNuevo.FlatStyle = FlatStyle.Flat
        btnNuevo.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Regular)
        btnNuevo.ForeColor = Color.White
        btnNuevo.Location = New Point(0, 0)
        btnNuevo.Margin = New Padding(0, 0, 10, 4)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(170, 38)
        btnNuevo.TabIndex = 0
        btnNuevo.Text = "Nuevo préstamo"
        btnNuevo.UseVisualStyleBackColor = False
        ' 
        ' btnDevolver
        ' 
        btnDevolver.BackColor = Color.White
        btnDevolver.Cursor = Cursors.Hand
        btnDevolver.Enabled = False
        btnDevolver.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnDevolver.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnDevolver.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnDevolver.FlatStyle = FlatStyle.Flat
        btnDevolver.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Regular)
        btnDevolver.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnDevolver.Location = New Point(180, 0)
        btnDevolver.Margin = New Padding(0, 0, 10, 4)
        btnDevolver.Name = "btnDevolver"
        btnDevolver.Size = New Size(170, 38)
        btnDevolver.TabIndex = 1
        btnDevolver.Text = "Registrar devolución"
        btnDevolver.UseVisualStyleBackColor = False
        ' 
        ' btnActualizar
        ' 
        btnActualizar.BackColor = Color.White
        btnActualizar.Cursor = Cursors.Hand
        btnActualizar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnActualizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnActualizar.FlatStyle = FlatStyle.Flat
        btnActualizar.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Regular)
        btnActualizar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnActualizar.Location = New Point(360, 0)
        btnActualizar.Margin = New Padding(0, 0, 10, 4)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(170, 38)
        btnActualizar.TabIndex = 2
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = False
        ' 
        ' tabla
        ' 
        tabla.AccessibleName = "Tabla de resultados"
        tabla.AllowUserToAddRows = False
        tabla.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        tabla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        tabla.BackgroundColor = Color.White
        tabla.BorderStyle = BorderStyle.None
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        tabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        tabla.ColumnHeadersHeight = 40
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 10F)
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = "—"
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        tabla.DefaultCellStyle = DataGridViewCellStyle3
        tabla.Dock = DockStyle.Fill
        tabla.EnableHeadersVisualStyles = False
        tabla.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        tabla.Location = New Point(24, 228)
        tabla.Margin = New Padding(0)
        tabla.MultiSelect = False
        tabla.Name = "tabla"
        tabla.ReadOnly = True
        tabla.RowHeadersVisible = False
        tabla.RowHeadersWidth = 51
        tabla.RowTemplate.Height = 36
        tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        tabla.Size = New Size(1052, 388)
        tabla.TabIndex = 3
        ' 
        ' resumen
        ' 
        resumen.AutoEllipsis = True
        resumen.Dock = DockStyle.Fill
        resumen.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        resumen.Location = New Point(27, 616)
        resumen.Name = "resumen"
        resumen.Size = New Size(1046, 52)
        resumen.TabIndex = 4
        resumen.Text = "Sin datos cargados. Abre la pantalla para consultar."
        resumen.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' frmPrestamos
        ' 
        AutoScaleDimensions = New SizeF(120F, 120F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.White
        ClientSize = New Size(1100, 680)
        Controls.Add(layoutVista)
        Font = New Font("Segoe UI", 10F)
        Name = "frmPrestamos"
        Text = "Préstamos"
        encabezado.ResumeLayout(False)
        CType(imagenModulo, ISupportInitialize).EndInit()
        textoEncabezado.ResumeLayout(False)
        layoutVista.ResumeLayout(False)
        layoutVista.PerformLayout()
        barraFiltros.ResumeLayout(False)
        bloque_buscar.ResumeLayout(False)
        bloque_buscar.PerformLayout()
        bloque_filtroEstado.ResumeLayout(False)
        barraAcciones.ResumeLayout(False)
        CType(tabla, ISupportInitialize).EndInit()
        ResumeLayout(False)
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
    Friend WithEvents tablaCabecera As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents tablaCeldas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents tablaAlternas As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents colPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEjemplar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLibro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFinFormato As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRetorno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRetornoFormato As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents colDias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInicioFormato As System.Windows.Forms.DataGridViewCellStyle
    Friend WithEvents colDni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCorreo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBibliotecario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents resumen As System.Windows.Forms.Label
End Class
