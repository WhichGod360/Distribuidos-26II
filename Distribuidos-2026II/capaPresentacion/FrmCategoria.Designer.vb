<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategoria
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
        Panel1 = New Panel()
        Panel2 = New Panel()
        Button8 = New Button()
        Button7 = New Button()
        Button6 = New Button()
        Button5 = New Button()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Label1 = New Label()
        TextBox1 = New TextBox()
        Button9 = New Button()
        tbCategoria = New DataGridView()
        Panel3 = New Panel()
        Label2 = New Label()
        Button10 = New Button()
        Button11 = New Button()
        Panel2.SuspendLayout()
        CType(tbCategoria, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ButtonHighlight
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Location = New Point(-3, -8)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1391, 72)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.InactiveBorder
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(Button8)
        Panel2.Controls.Add(Button7)
        Panel2.Controls.Add(Button6)
        Panel2.Controls.Add(Button5)
        Panel2.Controls.Add(Button4)
        Panel2.Controls.Add(Button3)
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(Button1)
        Panel2.Location = New Point(-4, 56)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(267, 752)
        Panel2.TabIndex = 1
        ' 
        ' Button8
        ' 
        Button8.BackColor = SystemColors.InactiveBorder
        Button8.FlatAppearance.BorderSize = 0
        Button8.FlatStyle = FlatStyle.Flat
        Button8.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button8.ForeColor = SystemColors.Highlight
        Button8.Location = New Point(19, 373)
        Button8.Name = "Button8"
        Button8.Size = New Size(227, 51)
        Button8.TabIndex = 9
        Button8.Text = "  Man. penalización"
        Button8.TextAlign = ContentAlignment.MiddleLeft
        Button8.UseVisualStyleBackColor = False
        ' 
        ' Button7
        ' 
        Button7.BackColor = SystemColors.InactiveBorder
        Button7.FlatAppearance.BorderSize = 0
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button7.ForeColor = SystemColors.Highlight
        Button7.Location = New Point(18, 374)
        Button7.Name = "Button7"
        Button7.Size = New Size(227, 51)
        Button7.TabIndex = 8
        Button7.Text = "  Man. categoría"
        Button7.TextAlign = ContentAlignment.MiddleLeft
        Button7.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.BackColor = SystemColors.InactiveBorder
        Button6.FlatAppearance.BorderSize = 0
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button6.ForeColor = SystemColors.Highlight
        Button6.Location = New Point(19, 316)
        Button6.Name = "Button6"
        Button6.Size = New Size(227, 51)
        Button6.TabIndex = 7
        Button6.Text = "  Man. libro"
        Button6.TextAlign = ContentAlignment.MiddleLeft
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = SystemColors.InactiveBorder
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button5.ForeColor = SystemColors.Highlight
        Button5.Location = New Point(19, 259)
        Button5.Name = "Button5"
        Button5.Size = New Size(227, 51)
        Button5.TabIndex = 6
        Button5.Text = "  Man. autor"
        Button5.TextAlign = ContentAlignment.MiddleLeft
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = SystemColors.Highlight
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = SystemColors.ControlLightLight
        Button4.Location = New Point(19, 202)
        Button4.Name = "Button4"
        Button4.Size = New Size(227, 51)
        Button4.TabIndex = 5
        Button4.Text = "  Man. categoría"
        Button4.TextAlign = ContentAlignment.MiddleLeft
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = SystemColors.InactiveBorder
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = SystemColors.Highlight
        Button3.Location = New Point(19, 145)
        Button3.Name = "Button3"
        Button3.Size = New Size(227, 51)
        Button3.TabIndex = 4
        Button3.Text = "  Buscar usuario"
        Button3.TextAlign = ContentAlignment.MiddleLeft
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.InactiveBorder
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = SystemColors.Highlight
        Button2.Location = New Point(19, 88)
        Button2.Name = "Button2"
        Button2.Size = New Size(227, 51)
        Button2.TabIndex = 3
        Button2.Text = "  Prestamos"
        Button2.TextAlign = ContentAlignment.MiddleLeft
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.InactiveBorder
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.Highlight
        Button1.Location = New Point(19, 31)
        Button1.Name = "Button1"
        Button1.Size = New Size(227, 51)
        Button1.TabIndex = 2
        Button1.Text = "  Inicio"
        Button1.TextAlign = ContentAlignment.MiddleLeft
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(298, 97)
        Label1.Name = "Label1"
        Label1.Size = New Size(287, 31)
        Label1.TabIndex = 2
        Label1.Text = "Mantenimiento categoría"
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Location = New Point(298, 160)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(853, 40)
        TextBox1.TabIndex = 3
        ' 
        ' Button9
        ' 
        Button9.BackColor = Color.Gray
        Button9.FlatAppearance.BorderSize = 0
        Button9.FlatStyle = FlatStyle.Flat
        Button9.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button9.ForeColor = SystemColors.ButtonHighlight
        Button9.Location = New Point(1171, 159)
        Button9.Name = "Button9"
        Button9.Size = New Size(175, 41)
        Button9.TabIndex = 5
        Button9.Text = "Buscar"
        Button9.UseVisualStyleBackColor = False
        ' 
        ' tbCategoria
        ' 
        tbCategoria.BackgroundColor = SystemColors.ButtonHighlight
        tbCategoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        tbCategoria.Location = New Point(298, 237)
        tbCategoria.Name = "tbCategoria"
        tbCategoria.RowHeadersWidth = 51
        tbCategoria.Size = New Size(1048, 443)
        tbCategoria.TabIndex = 6
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.ActiveCaptionText
        Panel3.Controls.Add(Label2)
        Panel3.Location = New Point(-4, 788)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1392, 61)
        Panel3.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = SystemColors.ButtonHighlight
        Label2.Location = New Point(552, 17)
        Label2.Name = "Label2"
        Label2.Size = New Size(346, 20)
        Label2.TabIndex = 0
        Label2.Text = "@Derechos reservados por la biblioteca marcianos"
        ' 
        ' Button10
        ' 
        Button10.BackColor = SystemColors.Highlight
        Button10.FlatAppearance.BorderSize = 0
        Button10.FlatStyle = FlatStyle.Flat
        Button10.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button10.ForeColor = SystemColors.ButtonHighlight
        Button10.Location = New Point(1171, 715)
        Button10.Name = "Button10"
        Button10.Size = New Size(175, 41)
        Button10.TabIndex = 8
        Button10.Text = "+ Aregar"
        Button10.UseVisualStyleBackColor = False
        ' 
        ' Button11
        ' 
        Button11.BackColor = SystemColors.ControlLightLight
        Button11.FlatAppearance.BorderColor = SystemColors.Highlight
        Button11.FlatAppearance.BorderSize = 2
        Button11.FlatStyle = FlatStyle.Flat
        Button11.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button11.ForeColor = SystemColors.Highlight
        Button11.Location = New Point(976, 715)
        Button11.Name = "Button11"
        Button11.Size = New Size(175, 41)
        Button11.TabIndex = 9
        Button11.Text = "Editar"
        Button11.UseVisualStyleBackColor = False
        ' 
        ' FrmCategoria
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1382, 843)
        Controls.Add(Button11)
        Controls.Add(Button10)
        Controls.Add(Panel3)
        Controls.Add(tbCategoria)
        Controls.Add(Button9)
        Controls.Add(TextBox1)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Controls.Add(Panel2)
        Name = "FrmCategoria"
        Text = "Gestionar categorías"
        Panel2.ResumeLayout(False)
        CType(tbCategoria, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button9 As Button
    Friend WithEvents tbCategoria As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
End Class
