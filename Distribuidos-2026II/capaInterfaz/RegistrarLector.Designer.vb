<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistrarLector
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(RegistrarLector))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        cboFNacimiento = New DateTimePicker()
        cboSexo = New ComboBox()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Label14 = New Label()
        btnRegistrarse = New Button()
        txtNombres = New TextBox()
        txtDNI = New TextBox()
        txtApPaterno = New TextBox()
        txtApMaterno = New TextBox()
        txtCorreo = New TextBox()
        txtContraseña = New TextBox()
        txtConfirmar = New TextBox()
        txtPregunta = New TextBox()
        txtRpta = New TextBox()
        linkLogin = New LinkLabel()
        Label16 = New Label()
        Label18 = New Label()
        lblNumero = New Label()
        lblMayuscula = New Label()
        lblCaracteres = New Label()
        Label21 = New Label()
        PictureBox1 = New PictureBox()
        Label15 = New Label()
        Label22 = New Label()
        CType(PictureBox1, ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label1.Location = New Point(335, 104)
        Label1.Name = "Label1"
        Label1.Size = New Size(72, 20)
        Label1.TabIndex = 0
        Label1.Text = "Nombres"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label2.Location = New Point(50, 170)
        Label2.Name = "Label2"
        Label2.Size = New Size(124, 20)
        Label2.TabIndex = 1
        Label2.Text = "Apellido paterno"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label3.Location = New Point(335, 170)
        Label3.Name = "Label3"
        Label3.Size = New Size(128, 20)
        Label3.TabIndex = 2
        Label3.Text = "Apellido materno"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label4.Location = New Point(50, 104)
        Label4.Name = "Label4"
        Label4.Size = New Size(36, 20)
        Label4.TabIndex = 3
        Label4.Text = "DNI"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label5.Location = New Point(335, 236)
        Label5.Name = "Label5"
        Label5.Size = New Size(136, 20)
        Label5.TabIndex = 4
        Label5.Text = "Correo Electrónico"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label6.Location = New Point(50, 236)
        Label6.Name = "Label6"
        Label6.Size = New Size(132, 20)
        Label6.TabIndex = 5
        Label6.Text = "Fecha Nacimiento"
        ' 
        ' cboFNacimiento
        ' 
        cboFNacimiento.CustomFormat = "yyyy-MM-dd"
        cboFNacimiento.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cboFNacimiento.Format = DateTimePickerFormat.Custom
        cboFNacimiento.Location = New Point(50, 258)
        cboFNacimiento.Name = "cboFNacimiento"
        cboFNacimiento.Size = New Size(140, 34)
        cboFNacimiento.TabIndex = 4
        ' 
        ' cboSexo
        ' 
        cboSexo.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cboSexo.FormattingEnabled = True
        cboSexo.Items.AddRange(New Object() {"Masculino", "Femenino"})
        cboSexo.Location = New Point(200, 258)
        cboSexo.Name = "cboSexo"
        cboSexo.Size = New Size(105, 36)
        cboSexo.TabIndex = 5
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label7.Location = New Point(200, 236)
        Label7.Name = "Label7"
        Label7.Size = New Size(42, 20)
        Label7.TabIndex = 8
        Label7.Text = "Sexo"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label8.Location = New Point(50, 302)
        Label8.Name = "Label8"
        Label8.Size = New Size(86, 20)
        Label8.TabIndex = 9
        Label8.Text = "Contraseña"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label9.Location = New Point(335, 302)
        Label9.Name = "Label9"
        Label9.Size = New Size(157, 20)
        Label9.TabIndex = 10
        Label9.Text = "Confirmar contraseña"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label10.Location = New Point(50, 398)
        Label10.Name = "Label10"
        Label10.Size = New Size(165, 20)
        Label10.TabIndex = 11
        Label10.Text = "Pregunta de seguridad"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label11.Location = New Point(335, 398)
        Label11.Name = "Label11"
        Label11.Size = New Size(77, 20)
        Label11.TabIndex = 12
        Label11.Text = "Respuesta"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(665, 348)
        Label12.Name = "Label12"
        Label12.Size = New Size(0, 20)
        Label12.TabIndex = 13
        Label12.Visible = False
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label14.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        Label14.Location = New Point(50, 62)
        Label14.Name = "Label14"
        Label14.Size = New Size(203, 20)
        Label14.TabIndex = 15
        Label14.Text = "Marcianos que prestan libros."
        ' 
        ' btnRegistrarse
        ' 
        btnRegistrarse.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnRegistrarse.Cursor = Cursors.Hand
        btnRegistrarse.FlatAppearance.BorderSize = 0
        btnRegistrarse.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btnRegistrarse.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btnRegistrarse.FlatStyle = FlatStyle.Flat
        btnRegistrarse.Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRegistrarse.ForeColor = Color.White
        btnRegistrarse.Location = New Point(335, 494)
        btnRegistrarse.Name = "btnRegistrarse"
        btnRegistrarse.Size = New Size(255, 44)
        btnRegistrarse.TabIndex = 11
        btnRegistrarse.Text = "Registrarse"
        btnRegistrarse.UseVisualStyleBackColor = False
        ' 
        ' txtNombres
        ' 
        txtNombres.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtNombres.BorderStyle = BorderStyle.FixedSingle
        txtNombres.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNombres.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtNombres.Location = New Point(335, 126)
        txtNombres.Name = "txtNombres"
        txtNombres.Size = New Size(255, 34)
        txtNombres.TabIndex = 1
        ' 
        ' txtDNI
        ' 
        txtDNI.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtDNI.BorderStyle = BorderStyle.FixedSingle
        txtDNI.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtDNI.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtDNI.Location = New Point(50, 126)
        txtDNI.Name = "txtDNI"
        txtDNI.Size = New Size(255, 34)
        txtDNI.TabIndex = 0
        ' 
        ' txtApPaterno
        ' 
        txtApPaterno.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtApPaterno.BorderStyle = BorderStyle.FixedSingle
        txtApPaterno.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtApPaterno.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtApPaterno.Location = New Point(50, 192)
        txtApPaterno.Name = "txtApPaterno"
        txtApPaterno.Size = New Size(255, 34)
        txtApPaterno.TabIndex = 2
        ' 
        ' txtApMaterno
        ' 
        txtApMaterno.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtApMaterno.BorderStyle = BorderStyle.FixedSingle
        txtApMaterno.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtApMaterno.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtApMaterno.Location = New Point(335, 192)
        txtApMaterno.Name = "txtApMaterno"
        txtApMaterno.Size = New Size(255, 34)
        txtApMaterno.TabIndex = 3
        ' 
        ' txtCorreo
        ' 
        txtCorreo.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtCorreo.BorderStyle = BorderStyle.FixedSingle
        txtCorreo.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCorreo.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtCorreo.Location = New Point(335, 258)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(255, 34)
        txtCorreo.TabIndex = 6
        ' 
        ' txtContraseña
        ' 
        txtContraseña.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtContraseña.BorderStyle = BorderStyle.FixedSingle
        txtContraseña.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtContraseña.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtContraseña.Location = New Point(50, 324)
        txtContraseña.Name = "txtContraseña"
        txtContraseña.Size = New Size(255, 34)
        txtContraseña.TabIndex = 7
        ' 
        ' txtConfirmar
        ' 
        txtConfirmar.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtConfirmar.BorderStyle = BorderStyle.FixedSingle
        txtConfirmar.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtConfirmar.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtConfirmar.Location = New Point(335, 324)
        txtConfirmar.Name = "txtConfirmar"
        txtConfirmar.Size = New Size(255, 34)
        txtConfirmar.TabIndex = 8
        ' 
        ' txtPregunta
        ' 
        txtPregunta.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtPregunta.BorderStyle = BorderStyle.FixedSingle
        txtPregunta.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPregunta.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtPregunta.Location = New Point(50, 420)
        txtPregunta.Name = "txtPregunta"
        txtPregunta.Size = New Size(255, 34)
        txtPregunta.TabIndex = 9
        ' 
        ' txtRpta
        ' 
        txtRpta.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtRpta.BorderStyle = BorderStyle.FixedSingle
        txtRpta.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtRpta.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtRpta.Location = New Point(335, 420)
        txtRpta.Name = "txtRpta"
        txtRpta.Size = New Size(255, 34)
        txtRpta.TabIndex = 10
        ' 
        ' linkLogin
        ' 
        linkLogin.ActiveLinkColor = Color.FromArgb(CByte(217), CByte(113), CByte(74))
        linkLogin.BackColor = Color.Transparent
        linkLogin.DisabledLinkColor = Color.Silver
        linkLogin.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        linkLogin.LinkBehavior = LinkBehavior.HoverUnderline
        linkLogin.LinkColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        linkLogin.Location = New Point(50, 505)
        linkLogin.Name = "linkLogin"
        linkLogin.Size = New Size(150, 22)
        linkLogin.TabIndex = 27
        linkLogin.TabStop = True
        linkLogin.Text = "← Volver al login"
        linkLogin.TextAlign = ContentAlignment.MiddleLeft
        linkLogin.VisitedLinkColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.BackColor = Color.Transparent
        Label16.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label16.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        Label16.Location = New Point(50, 458)
        Label16.Name = "Label16"
        Label16.Size = New Size(417, 19)
        Label16.TabIndex = 28
        Label16.Text = "La pregunta de seguridad nos servirá para recuperar tu contraseña"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.Transparent
        Label18.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label18.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        Label18.Location = New Point(50, 366)
        Label18.Name = "Label18"
        Label18.Size = New Size(130, 19)
        Label18.TabIndex = 30
        Label18.Text = "Requisitos mínimos:"
        ' 
        ' lblNumero
        ' 
        lblNumero.AutoSize = True
        lblNumero.BackColor = Color.Transparent
        lblNumero.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNumero.ForeColor = Color.Gray
        lblNumero.Location = New Point(450, 364)
        lblNumero.Name = "lblNumero"
        lblNumero.Size = New Size(85, 20)
        lblNumero.TabIndex = 33
        lblNumero.Text = "un número"
        ' 
        ' lblMayuscula
        ' 
        lblMayuscula.AutoSize = True
        lblMayuscula.BackColor = Color.Transparent
        lblMayuscula.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMayuscula.ForeColor = Color.Gray
        lblMayuscula.Location = New Point(290, 364)
        lblMayuscula.Name = "lblMayuscula"
        lblMayuscula.Size = New Size(146, 20)
        lblMayuscula.TabIndex = 32
        lblMayuscula.Text = "una letra mayúscula"
        ' 
        ' lblCaracteres
        ' 
        lblCaracteres.AutoSize = True
        lblCaracteres.BackColor = Color.Transparent
        lblCaracteres.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCaracteres.ForeColor = Color.Gray
        lblCaracteres.Location = New Point(180, 364)
        lblCaracteres.Name = "lblCaracteres"
        lblCaracteres.Size = New Size(90, 20)
        lblCaracteres.TabIndex = 31
        lblCaracteres.Text = "8 caracteres"
        ' 
        ' Label21
        ' 
        Label21.BackColor = Color.Transparent
        Label21.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label21.ForeColor = Color.FromArgb(CByte(150), CByte(150), CByte(150))
        Label21.Location = New Point(0, 590)
        Label21.Name = "Label21"
        Label21.Size = New Size(640, 20)
        Label21.TabIndex = 34
        Label21.Text = "¿Eres colaborador? - Comunícate con nosotros +51 970 809 160"
        Label21.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(512, 10)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(78, 88)
        PictureBox1.TabIndex = 35
        PictureBox1.TabStop = False
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.Transparent
        Label15.Font = New Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label15.Location = New Point(46, 20)
        Label15.Name = "Label15"
        Label15.Size = New Size(396, 40)
        Label15.TabIndex = 36
        Label15.Text = "Registro de nuevos lectores"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.BackColor = Color.Transparent
        Label22.Font = New Font("Segoe UI", 7F)
        Label22.Location = New Point(59, 413)
        Label22.Name = "Label22"
        Label22.Size = New Size(0, 15)
        Label22.TabIndex = 37
        Label22.Visible = False
        ' 
        ' RegistrarLector
        ' 
        AcceptButton = btnRegistrarse
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.None
        CancelButton = linkLogin
        ClientSize = New Size(1052, 626)
        Controls.Add(Label22)
        Controls.Add(Label15)
        Controls.Add(PictureBox1)
        Controls.Add(Label21)
        Controls.Add(lblNumero)
        Controls.Add(lblMayuscula)
        Controls.Add(lblCaracteres)
        Controls.Add(Label18)
        Controls.Add(Label16)
        Controls.Add(linkLogin)
        Controls.Add(txtRpta)
        Controls.Add(txtPregunta)
        Controls.Add(txtConfirmar)
        Controls.Add(txtContraseña)
        Controls.Add(txtCorreo)
        Controls.Add(txtApMaterno)
        Controls.Add(txtApPaterno)
        Controls.Add(txtDNI)
        Controls.Add(txtNombres)
        Controls.Add(btnRegistrarse)
        Controls.Add(Label14)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(cboSexo)
        Controls.Add(cboFNacimiento)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "RegistrarLector"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Registrar Lector"
        CType(PictureBox1, ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cboFNacimiento As DateTimePicker
    Friend WithEvents cboSexo As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents btnRegistrarse As Button
    Friend WithEvents txtNombres As TextBox
    Friend WithEvents txtDNI As TextBox
    Friend WithEvents txtApPaterno As TextBox
    Friend WithEvents txtApMaterno As TextBox
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents txtContraseña As TextBox
    Friend WithEvents txtConfirmar As TextBox
    Friend WithEvents txtPregunta As TextBox
    Friend WithEvents txtRpta As TextBox
    Friend WithEvents linkLogin As LinkLabel
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblNumero As Label
    Friend WithEvents lblMayuscula As Label
    Friend WithEvents lblCaracteres As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label22 As Label
End Class
