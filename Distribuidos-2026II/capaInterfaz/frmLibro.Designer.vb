<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLibro
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Label1 = New Label()
        Panel1 = New Panel()
        Label4 = New Label()
        PictureBox1 = New PictureBox()
        Label3 = New Label()
        Label2 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        TextBox1 = New TextBox()
        Panel2 = New Panel()
        pboxBuscar = New PictureBox()
        cboEstado = New ComboBox()
        Panel3 = New Panel()
        cboOrdenarLetra = New ComboBox()
        Panel4 = New Panel()
        Panel5 = New Panel()
        Panel6 = New Panel()
        Button1 = New Button()
        DataGridView1 = New DataGridView()
        colId = New DataGridViewTextBoxColumn()
        colTitulo = New DataGridViewTextBoxColumn()
        colEditorial = New DataGridViewTextBoxColumn()
        colAnio = New DataGridViewTextBoxColumn()
        colStock = New DataGridViewTextBoxColumn()
        colEstado = New DataGridViewTextBoxColumn()
        colEditar = New DataGridViewButtonColumn()
        colEliminar = New DataGridViewButtonColumn()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(pboxBuscar, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel6.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1  (ruta de navegación)
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        Label1.Location = New Point(24, 14)
        Label1.Name = "Label1"
        Label1.Size = New Size(142, 15)
        Label1.TabIndex = 5
        Label1.Text = "Mantenimiento / Libros"
        ' 
        ' Panel1  (cabecera de maqueta; la cabecera real la da frmPrincipal)
        ' 
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(-1, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1014, 60)
        Panel1.TabIndex = 6
        Panel1.Visible = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.LightSlateGray
        Label4.BorderStyle = BorderStyle.FixedSingle
        Label4.Font = New Font("Franklin Gothic Demi", 8.25F)
        Label4.ForeColor = Color.Navy
        Label4.Location = New Point(20, 16)
        Label4.Name = "Label4"
        Label4.Size = New Size(36, 17)
        Label4.TabIndex = 4
        Label4.Text = "LOGO"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(100, 50)
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.SlateGray
        Label3.BorderStyle = BorderStyle.FixedSingle
        Label3.Font = New Font("Franklin Gothic Demi", 8.25F)
        Label3.ForeColor = Color.Navy
        Label3.Location = New Point(892, 17)
        Label3.Name = "Label3"
        Label3.Size = New Size(72, 17)
        Label3.TabIndex = 3
        Label3.Text = "Bibliotecario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Franklin Gothic Demi", 8.25F)
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(801, 18)
        Label2.Name = "Label2"
        Label2.Size = New Size(85, 15)
        Label2.TabIndex = 2
        Label2.Text = "Nombre Usuario"
        ' 
        ' Label5  (MENÚ de maqueta, oculto)
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.LightSlateGray
        Label5.BorderStyle = BorderStyle.FixedSingle
        Label5.Font = New Font("Franklin Gothic Demi", 8.25F)
        Label5.ForeColor = Color.Navy
        Label5.Location = New Point(18, 87)
        Label5.Name = "Label5"
        Label5.Size = New Size(38, 17)
        Label5.TabIndex = 7
        Label5.Text = "MENÚ"
        Label5.Visible = False
        ' 
        ' Label6  (título)
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label6.Location = New Point(20, 32)
        Label6.Name = "Label6"
        Label6.Size = New Size(298, 32)
        Label6.TabIndex = 8
        Label6.Text = "Mantenimiento de Libros"
        ' 
        ' TextBox1  (búsqueda)
        ' 
        TextBox1.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right, AnchorStyles)
        TextBox1.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        TextBox1.BorderStyle = BorderStyle.None
        TextBox1.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        TextBox1.Location = New Point(44, 6)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(472, 20)
        TextBox1.TabIndex = 0
        ' 
        ' Panel2  (contenedor de búsqueda)
        ' 
        Panel2.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right, AnchorStyles)
        Panel2.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(pboxBuscar)
        Panel2.Controls.Add(TextBox1)
        Panel2.Location = New Point(24, 86)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(528, 34)
        Panel2.TabIndex = 9
        ' 
        ' pboxBuscar
        ' 
        pboxBuscar.BackColor = Color.Transparent
        pboxBuscar.Image = My.Resources.Resources.search
        pboxBuscar.Location = New Point(12, 6)
        pboxBuscar.Name = "pboxBuscar"
        pboxBuscar.Size = New Size(22, 22)
        pboxBuscar.SizeMode = PictureBoxSizeMode.Zoom
        pboxBuscar.TabIndex = 0
        pboxBuscar.TabStop = False
        ' 
        ' cboEstado
        ' 
        cboEstado.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
        cboEstado.DropDownStyle = ComboBoxStyle.DropDownList
        cboEstado.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cboEstado.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        cboEstado.FormattingEnabled = True
        cboEstado.Location = New Point(564, 89)
        cboEstado.Name = "cboEstado"
        cboEstado.Size = New Size(150, 28)
        cboEstado.TabIndex = 1
        ' 
        ' Panel3  (contenedor de orden)
        ' 
        Panel3.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
        Panel3.BackColor = Color.Transparent
        Panel3.Controls.Add(cboOrdenarLetra)
        Panel3.Location = New Point(726, 86)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(150, 34)
        Panel3.TabIndex = 10
        ' 
        ' cboOrdenarLetra
        ' 
        cboOrdenarLetra.DropDownStyle = ComboBoxStyle.DropDownList
        cboOrdenarLetra.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cboOrdenarLetra.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        cboOrdenarLetra.FormattingEnabled = True
        cboOrdenarLetra.Location = New Point(0, 3)
        cboOrdenarLetra.Name = "cboOrdenarLetra"
        cboOrdenarLetra.Size = New Size(150, 28)
        cboOrdenarLetra.TabIndex = 2
        ' 
        ' Panel4  (vacío, oculto)
        ' 
        Panel4.Location = New Point(713, 120)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(127, 31)
        Panel4.TabIndex = 11
        Panel4.Visible = False
        ' 
        ' Panel5  (vacío, oculto)
        ' 
        Panel5.Location = New Point(36, 115)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(127, 31)
        Panel5.TabIndex = 12
        Panel5.Visible = False
        ' 
        ' Panel6  (contenedor del botón principal)
        ' 
        Panel6.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
        Panel6.BackColor = Color.Transparent
        Panel6.Controls.Add(Button1)
        Panel6.Location = New Point(888, 86)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(160, 34)
        Panel6.TabIndex = 13
        ' 
        ' Button1  (botón principal)
        ' 
        Button1.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        Button1.Cursor = Cursors.Hand
        Button1.Dock = DockStyle.Fill
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        Button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(0, 0)
        Button1.Name = "Button1"
        Button1.Size = New Size(160, 34)
        Button1.TabIndex = 3
        Button1.Text = "+ Agregar libro"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        DataGridView1.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right, AnchorStyles)
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle1.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(226), CByte(234), CByte(240))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeight = 40
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {colId, colTitulo, colEditorial, colAnio, colStock, colEstado, colEditar, colEliminar})
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(212), CByte(226), CByte(236))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridView1.Location = New Point(24, 136)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowTemplate.Height = 44
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(1024, 450)
        DataGridView1.TabIndex = 4
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(250))
        ' 
        ' colId
        ' 
        colId.HeaderText = "ID"
        colId.Name = "colId"
        colId.ReadOnly = True
        colId.Width = 70
        ' 
        ' colTitulo
        ' 
        colTitulo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colTitulo.HeaderText = "Título"
        colTitulo.Name = "colTitulo"
        colTitulo.ReadOnly = True
        ' 
        ' colEditorial
        ' 
        colEditorial.HeaderText = "Editorial"
        colEditorial.Name = "colEditorial"
        colEditorial.ReadOnly = True
        colEditorial.Width = 170
        ' 
        ' colAnio
        ' 
        colAnio.HeaderText = "Año"
        colAnio.Name = "colAnio"
        colAnio.ReadOnly = True
        colAnio.Width = 80
        ' 
        ' colStock
        ' 
        colStock.HeaderText = "Stock"
        colStock.Name = "colStock"
        colStock.ReadOnly = True
        colStock.Width = 80
        ' 
        ' colEstado
        ' 
        colEstado.HeaderText = "Estado"
        colEstado.Name = "colEstado"
        colEstado.ReadOnly = True
        colEstado.Width = 110
        ' 
        ' colEditar
        ' 
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = Color.White
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        DataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        colEditar.DefaultCellStyle = DataGridViewCellStyle4
        colEditar.FlatStyle = FlatStyle.Flat
        colEditar.HeaderText = "Acciones"
        colEditar.Name = "colEditar"
        colEditar.Text = "Editar"
        colEditar.UseColumnTextForButtonValue = True
        colEditar.Width = 90
        ' 
        ' colEliminar
        ' 
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = Color.White
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(190), CByte(80), CByte(55))
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(252), CByte(240), CByte(235))
        DataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(CByte(190), CByte(80), CByte(55))
        colEliminar.DefaultCellStyle = DataGridViewCellStyle5
        colEliminar.FlatStyle = FlatStyle.Flat
        colEliminar.HeaderText = ""
        colEliminar.Name = "colEliminar"
        colEliminar.Text = "Eliminar"
        colEliminar.UseColumnTextForButtonValue = True
        colEliminar.Width = 90
        ' 
        ' frmLibro
        ' 
        AutoScaleDimensions = New SizeF(96.0F, 96.0F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(249), CByte(250), CByte(254))
        ClientSize = New Size(1072, 620)
        Controls.Add(DataGridView1)
        Controls.Add(Panel6)
        Controls.Add(Panel5)
        Controls.Add(Panel3)
        Controls.Add(cboEstado)
        Controls.Add(Panel2)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        Controls.Add(Panel4)
        Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "frmLibro"
        Text = "Mantenimiento de Libros"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(pboxBuscar, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pboxBuscar As PictureBox
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cboOrdenarLetra As ComboBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents colId As DataGridViewTextBoxColumn
    Friend WithEvents colTitulo As DataGridViewTextBoxColumn
    Friend WithEvents colEditorial As DataGridViewTextBoxColumn
    Friend WithEvents colAnio As DataGridViewTextBoxColumn
    Friend WithEvents colStock As DataGridViewTextBoxColumn
    Friend WithEvents colEstado As DataGridViewTextBoxColumn
    Friend WithEvents colEditar As DataGridViewButtonColumn
    Friend WithEvents colEliminar As DataGridViewButtonColumn
End Class
