<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtCorreo = New TextBox()
        txtContraseña = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        btnIniciarSesion = New Button()
        SuspendLayout()
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Location = New Point(140, 133)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(245, 27)
        txtCorreo.TabIndex = 0
        ' 
        ' txtContraseña
        ' 
        txtContraseña.Location = New Point(140, 181)
        txtContraseña.Name = "txtContraseña"
        txtContraseña.Size = New Size(245, 27)
        txtContraseña.TabIndex = 1
        txtContraseña.UseSystemPasswordChar = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(40, 34)
        Label1.Name = "Label1"
        Label1.Size = New Size(117, 20)
        Label1.TabIndex = 2
        Label1.Text = "INICIAR SESION:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(41, 136)
        Label2.Name = "Label2"
        Label2.Size = New Size(54, 20)
        Label2.TabIndex = 3
        Label2.Text = "Correo"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(41, 184)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 20)
        Label3.TabIndex = 4
        Label3.Text = "Contraseña"
        ' 
        ' btnIniciarSesion
        ' 
        btnIniciarSesion.Location = New Point(140, 292)
        btnIniciarSesion.Name = "btnIniciarSesion"
        btnIniciarSesion.Size = New Size(129, 29)
        btnIniciarSesion.TabIndex = 5
        btnIniciarSesion.Text = "Iniciar Sesion"
        btnIniciarSesion.UseVisualStyleBackColor = True
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(411, 492)
        Controls.Add(btnIniciarSesion)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtContraseña)
        Controls.Add(txtCorreo)
        Name = "Login"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents txtContraseña As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnIniciarSesion As Button

End Class
