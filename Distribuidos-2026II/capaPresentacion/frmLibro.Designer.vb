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
        PictureBox2 = New PictureBox()
        cboEstado = New ComboBox()
        Panel3 = New Panel()
        Panel4 = New Panel()
        cboOrdenarLetra = New ComboBox()
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
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel6.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Franklin Gothic Demi", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlDarkDark
        Label1.Location = New Point(196, 66)
        Label1.Name = "Label1"
        Label1.Size = New Size(181, 21)
        Label1.TabIndex = 0
        Label1.Text = "Mantenimiento / Libros"
        ' 
        ' Panel1
        ' 
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(-1, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1014, 60)
        Panel1.TabIndex = 1
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
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.LightSlateGray
        Label5.BorderStyle = BorderStyle.FixedSingle
        Label5.Font = New Font("Franklin Gothic Demi", 8.25F)
        Label5.ForeColor = Color.Navy
        Label5.Location = New Point(18, 87)
        Label5.Name = "Label5"
        Label5.Size = New Size(38, 17)
        Label5.TabIndex = 5
        Label5.Text = "MENÚ"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Franklin Gothic Demi", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.ActiveCaptionText
        Label6.Location = New Point(196, 87)
        Label6.Name = "Label6"
        Label6.Size = New Size(274, 30)
        Label6.TabIndex = 6
        Label6.Text = "Mantenimiento de Libros"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(43, 3)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(450, 23)
        TextBox1.TabIndex = 7
        ' 
        ' Panel2
        ' 
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(PictureBox2)
        Panel2.Controls.Add(TextBox1)
        Panel2.Location = New Point(196, 120)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(498, 31)
        Panel2.TabIndex = 8

        cboEstado.DrawMode = DrawMode.OwnerDrawFixed
        cboEstado.DropDownStyle = ComboBoxStyle.DropDownList
        cboEstado.FormattingEnabled = True
        cboEstado.Location = New Point(716, 124)
        cboEstado.Name = "cboEstado"
        cboEstado.Size = New Size(121, 24)
        cboEstado.TabIndex = 9
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(cboOrdenarLetra)
        Panel3.Location = New Point(866, 120)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(127, 31)
        Panel3.TabIndex = 11
        ' 
        ' Panel4
        ' 
        Panel4.Location = New Point(713, 120)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(127, 31)
        Panel4.TabIndex = 11
        ' 
        ' cboOrdenarLetra
        ' 
        cboOrdenarLetra.DrawMode = DrawMode.OwnerDrawFixed
        cboOrdenarLetra.DropDownStyle = ComboBoxStyle.DropDownList
        cboOrdenarLetra.FormattingEnabled = True
        cboOrdenarLetra.Location = New Point(3, 3)
        cboOrdenarLetra.Name = "cboOrdenarLetra"
        cboOrdenarLetra.Size = New Size(121, 24)
        cboOrdenarLetra.TabIndex = 12
        ' 
        ' Panel5
        ' 
        Panel5.Location = New Point(36, 115)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(127, 31)
        Panel5.TabIndex = 12
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(Button1)
        Panel6.Location = New Point(866, 73)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(127, 31)
        Panel6.TabIndex = 13
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.RoyalBlue
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(0, 0)
        Button1.Name = "Button1"
        Button1.Size = New Size(127, 31)
        Button1.TabIndex = 14
        Button1.Text = "+ Agregar libro"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle1.SelectionForeColor = Color.MediumBlue
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeight = 42
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {colId, colTitulo, colEditorial, colAnio, colStock, colEstado, colEditar, colEliminar})
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = Color.SlateGray
        DataGridView1.Location = New Point(193, 170)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowTemplate.DefaultCellStyle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue
        DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black
        DataGridView1.RowTemplate.Height = 48
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(797, 315)
        DataGridView1.TabIndex = 14
        ' 
        ' colId
        ' 
        colId.HeaderText = "ID"
        colId.Name = "colId"
        colId.ReadOnly = True
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
        ' 
        ' colAnio
        ' 
        colAnio.HeaderText = "Año"
        colAnio.Name = "colAnio"
        colAnio.ReadOnly = True
        ' 
        ' colStock
        ' 
        colStock.HeaderText = "Stock"
        colStock.Name = "colStock"
        colStock.ReadOnly = True
        ' 
        ' colEstado
        ' 
        colEstado.HeaderText = "Estado"
        colEstado.Name = "colEstado"
        colEstado.ReadOnly = True
        ' 
        ' colEditar
        ' 
        colEditar.FlatStyle = FlatStyle.Flat
        colEditar.HeaderText = "Acciones"
        colEditar.Name = "colEditar"
        colEditar.Text = "Editar"
        colEditar.UseColumnTextForButtonValue = True
        ' 
        ' colEliminar
        ' 
        colEliminar.FlatStyle = FlatStyle.Flat
        colEliminar.HeaderText = ""
        colEliminar.Name = "colEliminar"
        colEliminar.Text = "Eliminar"
        colEliminar.UseColumnTextForButtonValue = True
        ' 
        ' frmLibro
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1013, 497)
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
        Name = "frmLibro"
        Text = "Form1"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PictureBox2 As PictureBox
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
