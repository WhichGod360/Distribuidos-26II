<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarCategoria
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
        Label1 = New Label()
        Panel1 = New Panel()
        Label2 = New Label()
        txtNombre = New TextBox()
        Label3 = New Label()
        chkEstado = New CheckBox()
        Button11 = New Button()
        Button10 = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlText
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(193, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(206, 31)
        Label1.TabIndex = 3
        Label1.Text = "Agregar categoría"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.HighlightText
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(-8, -2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(598, 72)
        Panel1.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ControlText
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(34, 106)
        Label2.Name = "Label2"
        Label2.Size = New Size(181, 25)
        Label2.TabIndex = 4
        Label2.Text = "Nombre de categoría"
        ' 
        ' txtNombre
        ' 
        txtNombre.BorderStyle = BorderStyle.FixedSingle
        txtNombre.Location = New Point(34, 141)
        txtNombre.Multiline = True
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(513, 40)
        txtNombre.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ControlText
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(34, 202)
        Label3.Name = "Label3"
        Label3.Size = New Size(66, 25)
        Label3.TabIndex = 6
        Label3.Text = "Estado"
        ' 
        ' chkEstado
        ' 
        chkEstado.AutoSize = True
        chkEstado.Location = New Point(34, 234)
        chkEstado.Name = "chkEstado"
        chkEstado.Size = New Size(73, 24)
        chkEstado.TabIndex = 7
        chkEstado.Text = "Activo"
        chkEstado.UseVisualStyleBackColor = True
        ' 
        ' Button11
        ' 
        Button11.BackColor = SystemColors.ControlLightLight
        Button11.FlatAppearance.BorderColor = SystemColors.Highlight
        Button11.FlatAppearance.BorderSize = 2
        Button11.FlatStyle = FlatStyle.Flat
        Button11.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button11.ForeColor = SystemColors.Highlight
        Button11.Location = New Point(177, 478)
        Button11.Name = "Button11"
        Button11.Size = New Size(175, 41)
        Button11.TabIndex = 11
        Button11.Text = "Cancelar"
        Button11.UseVisualStyleBackColor = False
        ' 
        ' Button10
        ' 
        Button10.BackColor = SystemColors.Highlight
        Button10.FlatAppearance.BorderSize = 0
        Button10.FlatStyle = FlatStyle.Flat
        Button10.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button10.ForeColor = SystemColors.ButtonHighlight
        Button10.Location = New Point(372, 478)
        Button10.Name = "Button10"
        Button10.Size = New Size(175, 41)
        Button10.TabIndex = 10
        Button10.Text = "+ Aregar"
        Button10.UseVisualStyleBackColor = False
        ' 
        ' frmAgregarCategoria
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.HighlightText
        ClientSize = New Size(582, 553)
        Controls.Add(Button11)
        Controls.Add(Button10)
        Controls.Add(chkEstado)
        Controls.Add(Label3)
        Controls.Add(txtNombre)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        Name = "frmAgregarCategoria"
        Text = "frmAgregarCategoria"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkEstado As CheckBox
    Friend WithEvents Button11 As Button
    Friend WithEvents Button10 As Button
End Class
