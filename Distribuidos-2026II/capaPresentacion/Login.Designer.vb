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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        txtCorreo = New TextBox()
        txtContraseña = New TextBox()
        Label1 = New Label()
        btnIniciarSesion = New Button()
        Label4 = New Label()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        checkMostrar = New CheckBox()
        lblOlvide = New LinkLabel()
        Label2 = New Label()
        lblRegistrate = New LinkLabel()
        Label3 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Anchor = AnchorStyles.Right
        txtCorreo.BorderStyle = BorderStyle.FixedSingle
        txtCorreo.Font = New Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCorreo.Location = New Point(760, 255)
        txtCorreo.MaximumSize = New Size(200, 25)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(200, 25)
        txtCorreo.TabIndex = 0
        ' 
        ' txtContraseña
        ' 
        txtContraseña.Anchor = AnchorStyles.Right
        txtContraseña.BorderStyle = BorderStyle.FixedSingle
        txtContraseña.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtContraseña.Location = New Point(760, 318)
        txtContraseña.MaximumSize = New Size(200, 25)
        txtContraseña.Name = "txtContraseña"
        txtContraseña.Size = New Size(200, 25)
        txtContraseña.TabIndex = 1
        txtContraseña.UseSystemPasswordChar = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Gray
        Label1.Location = New Point(695, 182)
        Label1.Name = "Label1"
        Label1.Size = New Size(265, 23)
        Label1.TabIndex = 2
        Label1.Text = "Ingresa a tu cuenta de biblioteca."
        ' 
        ' btnIniciarSesion
        ' 
        btnIniciarSesion.BackColor = Color.DodgerBlue
        btnIniciarSesion.FlatAppearance.BorderColor = Color.DodgerBlue
        btnIniciarSesion.FlatAppearance.BorderSize = 2
        btnIniciarSesion.FlatStyle = FlatStyle.Flat
        btnIniciarSesion.Font = New Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnIniciarSesion.ForeColor = Color.White
        btnIniciarSesion.Location = New Point(695, 400)
        btnIniciarSesion.Name = "btnIniciarSesion"
        btnIniciarSesion.Size = New Size(302, 47)
        btnIniciarSesion.TabIndex = 5
        btnIniciarSesion.Text = "Ingresar"
        btnIniciarSesion.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(695, 151)
        Label4.Name = "Label4"
        Label4.Size = New Size(157, 31)
        Label4.TabIndex = 6
        Label4.Text = "Iniciar Sesión"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(731, 255)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(23, 25)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImageLayout = ImageLayout.None
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(731, 318)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(23, 25)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 8
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(779, 15)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(137, 136)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 9
        PictureBox3.TabStop = False
        ' 
        ' checkMostrar
        ' 
        checkMostrar.AutoSize = True
        checkMostrar.BackColor = Color.Transparent
        checkMostrar.Font = New Font("Segoe UI", 10F)
        checkMostrar.Location = New Point(895, 343)
        checkMostrar.Name = "checkMostrar"
        checkMostrar.Size = New Size(91, 27)
        checkMostrar.TabIndex = 10
        checkMostrar.Text = "mostrar"
        checkMostrar.UseVisualStyleBackColor = False
        ' 
        ' lblOlvide
        ' 
        lblOlvide.AutoSize = True
        lblOlvide.BackColor = Color.Transparent
        lblOlvide.Font = New Font("Segoe UI", 9F)
        lblOlvide.Location = New Point(695, 378)
        lblOlvide.Name = "lblOlvide"
        lblOlvide.Size = New Size(178, 20)
        lblOlvide.TabIndex = 11
        lblOlvide.TabStop = True
        lblOlvide.Text = "¿Olvidaste tu contraseña?"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.Location = New Point(790, 447)
        Label2.Name = "Label2"
        Label2.Size = New Size(193, 23)
        Label2.TabIndex = 12
        Label2.Text = "Aun no tienes cuenta? -"
        ' 
        ' lblRegistrate
        ' 
        lblRegistrate.AutoSize = True
        lblRegistrate.BackColor = Color.Transparent
        lblRegistrate.Font = New Font("Segoe UI", 10F)
        lblRegistrate.Location = New Point(933, 447)
        lblRegistrate.Name = "lblRegistrate"
        lblRegistrate.Size = New Size(82, 23)
        lblRegistrate.TabIndex = 13
        lblRegistrate.TabStop = True
        lblRegistrate.Text = "registrate"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label3.Location = New Point(699, 222)
        Label3.Name = "Label3"
        Label3.Size = New Size(189, 28)
        Label3.TabIndex = 15
        Label3.Text = "Correo Electrónico: "
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label5.Location = New Point(699, 287)
        Label5.Name = "Label5"
        Label5.Size = New Size(125, 28)
        Label5.TabIndex = 16
        Label5.Text = "Contraseña: "
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Location = New Point(714, 540)
        Label6.Name = "Label6"
        Label6.Size = New Size(348, 20)
        Label6.TabIndex = 17
        Label6.Text = "TotOs los derechos Reservados - @Grupo Marciano"
        ' 
        ' Login
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(1034, 579)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(lblRegistrate)
        Controls.Add(Label2)
        Controls.Add(lblOlvide)
        Controls.Add(checkMostrar)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(Label4)
        Controls.Add(btnIniciarSesion)
        Controls.Add(Label1)
        Controls.Add(txtContraseña)
        Controls.Add(txtCorreo)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inicio  de sesion"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents txtContraseña As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnIniciarSesion As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents checkMostrar As CheckBox
    Friend WithEvents lblOlvide As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblRegistrate As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label

End Class
