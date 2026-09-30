<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevaContraseña
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
        txtRpta = New TextBox()
        btnGuardar = New Button()
        btnCancelar = New Button()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        TextBox1 = New TextBox()
        lblCaracteres = New Label()
        lblMayuscula = New Label()
        Label7 = New Label()
        lblNumero = New Label()
        SuspendLayout()
        ' 
        ' txtRpta
        ' 
        txtRpta.Anchor = AnchorStyles.Right
        txtRpta.BorderStyle = BorderStyle.FixedSingle
        txtRpta.Font = New Font("Segoe UI", 10F)
        txtRpta.Location = New Point(41, 169)
        txtRpta.Name = "txtRpta"
        txtRpta.PasswordChar = "*"c
        txtRpta.Size = New Size(277, 30)
        txtRpta.TabIndex = 15
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Color.DodgerBlue
        btnGuardar.FlatAppearance.BorderSize = 2
        btnGuardar.FlatStyle = FlatStyle.Flat
        btnGuardar.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGuardar.ForeColor = Color.White
        btnGuardar.Location = New Point(225, 274)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(123, 41)
        btnGuardar.TabIndex = 13
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' btnCancelar
        ' 
        btnCancelar.BackColor = Color.Transparent
        btnCancelar.FlatAppearance.BorderColor = Color.DodgerBlue
        btnCancelar.FlatAppearance.BorderSize = 2
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Font = New Font("Segoe UI Black", 10F, FontStyle.Bold)
        btnCancelar.ForeColor = Color.DodgerBlue
        btnCancelar.Location = New Point(26, 274)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(123, 41)
        btnCancelar.TabIndex = 12
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label4.Location = New Point(16, 141)
        Label4.Name = "Label4"
        Label4.Size = New Size(201, 25)
        Label4.TabIndex = 11
        Label4.Text = "Confirma Contraseña"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label3.Location = New Point(16, 74)
        Label3.Name = "Label3"
        Label3.Size = New Size(175, 25)
        Label3.TabIndex = 10
        Label3.Text = "Nueva Contraseña"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.ForeColor = Color.Gray
        Label2.Location = New Point(16, 41)
        Label2.Name = "Label2"
        Label2.Size = New Size(336, 23)
        Label2.TabIndex = 9
        Label2.Text = "Crea una nueva contraseña para tu cuenta"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(242, 32)
        Label1.TabIndex = 8
        Label1.Text = "Cambiar contraseña"
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.Right
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Font = New Font("Segoe UI", 10F)
        TextBox1.Location = New Point(41, 102)
        TextBox1.Name = "TextBox1"
        TextBox1.PasswordChar = "*"c
        TextBox1.Size = New Size(277, 30)
        TextBox1.TabIndex = 16
        ' 
        ' lblCaracteres
        ' 
        lblCaracteres.AutoSize = True
        lblCaracteres.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold)
        lblCaracteres.ForeColor = Color.Gray
        lblCaracteres.Location = New Point(28, 234)
        lblCaracteres.Name = "lblCaracteres"
        lblCaracteres.Size = New Size(80, 17)
        lblCaracteres.TabIndex = 17
        lblCaracteres.Text = "8 caracteres"
        ' 
        ' lblMayuscula
        ' 
        lblMayuscula.AutoSize = True
        lblMayuscula.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold)
        lblMayuscula.ForeColor = Color.Gray
        lblMayuscula.Location = New Point(116, 234)
        lblMayuscula.Name = "lblMayuscula"
        lblMayuscula.Size = New Size(130, 17)
        lblMayuscula.TabIndex = 18
        lblMayuscula.Text = "una letra mayuscula"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 8F)
        Label7.ForeColor = Color.Black
        Label7.Location = New Point(26, 215)
        Label7.Name = "Label7"
        Label7.Size = New Size(127, 19)
        Label7.TabIndex = 19
        Label7.Text = "Requisitos minimos"
        ' 
        ' lblNumero
        ' 
        lblNumero.AutoSize = True
        lblNumero.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold)
        lblNumero.ForeColor = Color.Gray
        lblNumero.Location = New Point(253, 234)
        lblNumero.Name = "lblNumero"
        lblNumero.Size = New Size(76, 17)
        lblNumero.TabIndex = 20
        lblNumero.Text = "un numero"
        ' 
        ' NuevaContraseña
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(380, 327)
        Controls.Add(lblNumero)
        Controls.Add(Label7)
        Controls.Add(lblMayuscula)
        Controls.Add(lblCaracteres)
        Controls.Add(TextBox1)
        Controls.Add(txtRpta)
        Controls.Add(btnGuardar)
        Controls.Add(btnCancelar)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "NuevaContraseña"
        StartPosition = FormStartPosition.CenterScreen
        Text = "NuevaContraseña"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtRpta As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblCaracteres As Label
    Friend WithEvents lblMayuscula As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblNumero As Label
End Class
