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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(Login))
        txtCorreo = New TextBox()
        txtContraseña = New TextBox()
        Label1 = New Label()
        btnIniciarSesion = New Button()
        Label4 = New Label()
        PictureBox3 = New PictureBox()
        checkMostrar = New CheckBox()
        lblOlvide = New LinkLabel()
        lblRegistrate = New LinkLabel()
        Label3 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        CType(PictureBox3, ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Anchor = AnchorStyles.None
        txtCorreo.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtCorreo.BorderStyle = BorderStyle.FixedSingle
        txtCorreo.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCorreo.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtCorreo.Location = New Point(717, 287)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(260, 34)
        txtCorreo.TabIndex = 0
        ' 
        ' txtContraseña
        ' 
        txtContraseña.Anchor = AnchorStyles.None
        txtContraseña.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtContraseña.BorderStyle = BorderStyle.FixedSingle
        txtContraseña.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtContraseña.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtContraseña.Location = New Point(717, 353)
        txtContraseña.Name = "txtContraseña"
        txtContraseña.Size = New Size(260, 34)
        txtContraseña.TabIndex = 1
        txtContraseña.UseSystemPasswordChar = True
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        Label1.Location = New Point(717, 221)
        Label1.Name = "Label1"
        Label1.Size = New Size(260, 20)
        Label1.TabIndex = 6
        Label1.Text = "Ingresa a tu cuenta de biblioteca."
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnIniciarSesion
        ' 
        btnIniciarSesion.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnIniciarSesion.Cursor = Cursors.Hand
        btnIniciarSesion.FlatAppearance.BorderSize = 0
        btnIniciarSesion.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btnIniciarSesion.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btnIniciarSesion.FlatStyle = FlatStyle.Flat
        btnIniciarSesion.Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnIniciarSesion.ForeColor = Color.White
        btnIniciarSesion.Location = New Point(717, 430)
        btnIniciarSesion.Name = "btnIniciarSesion"
        btnIniciarSesion.Size = New Size(260, 44)
        btnIniciarSesion.TabIndex = 4
        btnIniciarSesion.Text = "Ingresar"
        btnIniciarSesion.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI", 17.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label4.Location = New Point(717, 186)
        Label4.Name = "Label4"
        Label4.Size = New Size(260, 34)
        Label4.TabIndex = 7
        Label4.Text = "Iniciar Sesión"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(792, 54)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(110, 124)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 8
        PictureBox3.TabStop = False
        ' 
        ' checkMostrar
        ' 
        checkMostrar.AutoSize = True
        checkMostrar.BackColor = Color.Transparent
        checkMostrar.Cursor = Cursors.Hand
        checkMostrar.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        checkMostrar.ForeColor = Color.FromArgb(CByte(110), CByte(110), CByte(110))
        checkMostrar.Location = New Point(717, 391)
        checkMostrar.Name = "checkMostrar"
        checkMostrar.Size = New Size(82, 24)
        checkMostrar.TabIndex = 2
        checkMostrar.Text = "Mostrar"
        checkMostrar.UseVisualStyleBackColor = False
        ' 
        ' lblOlvide
        ' 
        lblOlvide.ActiveLinkColor = Color.FromArgb(CByte(217), CByte(113), CByte(74))
        lblOlvide.BackColor = Color.Transparent
        lblOlvide.DisabledLinkColor = Color.Silver
        lblOlvide.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblOlvide.LinkBehavior = LinkBehavior.HoverUnderline
        lblOlvide.LinkColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        lblOlvide.Location = New Point(812, 392)
        lblOlvide.Name = "lblOlvide"
        lblOlvide.Size = New Size(165, 22)
        lblOlvide.TabIndex = 3
        lblOlvide.TabStop = True
        lblOlvide.Text = "¿Olvidaste tu contraseña?"
        lblOlvide.TextAlign = ContentAlignment.MiddleRight
        lblOlvide.VisitedLinkColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        ' 
        ' lblRegistrate
        ' 
        lblRegistrate.ActiveLinkColor = Color.FromArgb(CByte(190), CByte(90), CByte(55))
        lblRegistrate.BackColor = Color.Transparent
        lblRegistrate.DisabledLinkColor = Color.Silver
        lblRegistrate.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRegistrate.ForeColor = Color.FromArgb(CByte(110), CByte(110), CByte(110))
        lblRegistrate.LinkArea = New LinkArea(19, 10)
        lblRegistrate.LinkBehavior = LinkBehavior.HoverUnderline
        lblRegistrate.LinkColor = Color.FromArgb(CByte(217), CByte(113), CByte(74))
        lblRegistrate.Location = New Point(717, 488)
        lblRegistrate.Name = "lblRegistrate"
        lblRegistrate.Size = New Size(260, 22)
        lblRegistrate.TabIndex = 5
        lblRegistrate.TabStop = True
        lblRegistrate.Text = "¿No tienes cuenta? Regístrate"
        lblRegistrate.TextAlign = ContentAlignment.MiddleCenter
        lblRegistrate.UseCompatibleTextRendering = True
        lblRegistrate.VisitedLinkColor = Color.FromArgb(CByte(217), CByte(113), CByte(74))
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label3.Location = New Point(717, 265)
        Label3.Name = "Label3"
        Label3.Size = New Size(140, 20)
        Label3.TabIndex = 9
        Label3.Text = "Correo Electrónico:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label5.Location = New Point(717, 331)
        Label5.Name = "Label5"
        Label5.Size = New Size(90, 20)
        Label5.TabIndex = 10
        Label5.Text = "Contraseña:"
        ' 
        ' Label6
        ' 
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(150))
        Label6.Location = New Point(657, 549)
        Label6.Name = "Label6"
        Label6.Size = New Size(377, 20)
        Label6.TabIndex = 11
        Label6.Text = "Todos los derechos Reservados - @Grupo Marciano"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Login
        ' 
        AcceptButton = btnIniciarSesion
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(1034, 579)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(lblRegistrate)
        Controls.Add(lblOlvide)
        Controls.Add(checkMostrar)
        Controls.Add(PictureBox3)
        Controls.Add(Label4)
        Controls.Add(btnIniciarSesion)
        Controls.Add(Label1)
        Controls.Add(txtContraseña)
        Controls.Add(txtCorreo)
        Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inicio de sesión"
        CType(PictureBox3, ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents txtContraseña As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnIniciarSesion As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents checkMostrar As CheckBox
    Friend WithEvents lblOlvide As LinkLabel
    Friend WithEvents lblRegistrate As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label

End Class
