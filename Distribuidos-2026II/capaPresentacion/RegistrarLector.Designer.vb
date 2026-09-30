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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistrarLector))
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
        Label13 = New Label()
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
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label1.Location = New Point(459, 112)
        Label1.Name = "Label1"
        Label1.Size = New Size(104, 28)
        Label1.TabIndex = 0
        Label1.Text = "Nombres "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label2.Location = New Point(62, 214)
        Label2.Name = "Label2"
        Label2.Size = New Size(171, 28)
        Label2.TabIndex = 1
        Label2.Text = "Apellido paterno"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label3.Location = New Point(457, 214)
        Label3.Name = "Label3"
        Label3.Size = New Size(177, 28)
        Label3.TabIndex = 2
        Label3.Text = "Apellido materno"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label4.Location = New Point(62, 112)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 28)
        Label4.TabIndex = 3
        Label4.Text = "DNI"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label5.Location = New Point(454, 307)
        Label5.Name = "Label5"
        Label5.Size = New Size(187, 28)
        Label5.TabIndex = 4
        Label5.Text = "Correo Electronico"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label6.Location = New Point(62, 307)
        Label6.Name = "Label6"
        Label6.Size = New Size(182, 28)
        Label6.TabIndex = 5
        Label6.Text = "Fecha Nacimiento"
        ' 
        ' cboFNacimiento
        ' 
        cboFNacimiento.CustomFormat = "yyyy-MM-dd"
        cboFNacimiento.Font = New Font("Segoe UI", 12F)
        cboFNacimiento.Format = DateTimePickerFormat.Custom
        cboFNacimiento.Location = New Point(62, 338)
        cboFNacimiento.Name = "cboFNacimiento"
        cboFNacimiento.Size = New Size(150, 34)
        cboFNacimiento.TabIndex = 6
        ' 
        ' cboSexo
        ' 
        cboSexo.Font = New Font("Segoe UI", 12F)
        cboSexo.FormattingEnabled = True
        cboSexo.Items.AddRange(New Object() {"Masculino", "Femenino"})
        cboSexo.Location = New Point(263, 342)
        cboSexo.Name = "cboSexo"
        cboSexo.Size = New Size(161, 36)
        cboSexo.TabIndex = 7
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label7.Location = New Point(263, 307)
        Label7.Name = "Label7"
        Label7.Size = New Size(57, 28)
        Label7.TabIndex = 8
        Label7.Text = "Sexo"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label8.Location = New Point(62, 400)
        Label8.Name = "Label8"
        Label8.Size = New Size(118, 28)
        Label8.TabIndex = 9
        Label8.Text = "Contraseña"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label9.Location = New Point(457, 400)
        Label9.Name = "Label9"
        Label9.Size = New Size(217, 28)
        Label9.TabIndex = 10
        Label9.Text = "Confirmar contraseña"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label10.Location = New Point(62, 543)
        Label10.Name = "Label10"
        Label10.Size = New Size(226, 28)
        Label10.TabIndex = 11
        Label10.Text = "Pregunta de seguridad"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label11.Location = New Point(454, 543)
        Label11.Name = "Label11"
        Label11.Size = New Size(108, 28)
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
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        Label13.Location = New Point(563, 16)
        Label13.Name = "Label13"
        Label13.Size = New Size(137, 37)
        Label13.TabIndex = 14
        Label13.Text = "LectuRAE"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold Or FontStyle.Italic)
        Label14.ForeColor = Color.Gray
        Label14.Location = New Point(477, 53)
        Label14.Name = "Label14"
        Label14.Size = New Size(237, 23)
        Label14.TabIndex = 15
        Label14.Text = "Marcianos que prestan libros."
        ' 
        ' btnRegistrarse
        ' 
        btnRegistrarse.BackColor = Color.DodgerBlue
        btnRegistrarse.FlatAppearance.BorderColor = Color.DodgerBlue
        btnRegistrarse.FlatAppearance.BorderSize = 2
        btnRegistrarse.FlatStyle = FlatStyle.Flat
        btnRegistrarse.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold)
        btnRegistrarse.ForeColor = Color.White
        btnRegistrarse.Location = New Point(513, 667)
        btnRegistrarse.Name = "btnRegistrarse"
        btnRegistrarse.Size = New Size(170, 52)
        btnRegistrarse.TabIndex = 17
        btnRegistrarse.Text = "Registrarse"
        btnRegistrarse.UseVisualStyleBackColor = False
        ' 
        ' txtNombres
        ' 
        txtNombres.BorderStyle = BorderStyle.FixedSingle
        txtNombres.Font = New Font("Segoe UI", 12F)
        txtNombres.Location = New Point(454, 143)
        txtNombres.Name = "txtNombres"
        txtNombres.Size = New Size(232, 34)
        txtNombres.TabIndex = 18
        ' 
        ' txtDNI
        ' 
        txtDNI.BorderStyle = BorderStyle.FixedSingle
        txtDNI.Font = New Font("Segoe UI", 12F)
        txtDNI.Location = New Point(60, 143)
        txtDNI.Name = "txtDNI"
        txtDNI.Size = New Size(237, 34)
        txtDNI.TabIndex = 19
        ' 
        ' txtApPaterno
        ' 
        txtApPaterno.BorderStyle = BorderStyle.FixedSingle
        txtApPaterno.Font = New Font("Segoe UI", 12F)
        txtApPaterno.Location = New Point(62, 245)
        txtApPaterno.Name = "txtApPaterno"
        txtApPaterno.Size = New Size(235, 34)
        txtApPaterno.TabIndex = 20
        ' 
        ' txtApMaterno
        ' 
        txtApMaterno.BorderStyle = BorderStyle.FixedSingle
        txtApMaterno.Font = New Font("Segoe UI", 12F)
        txtApMaterno.Location = New Point(454, 245)
        txtApMaterno.Name = "txtApMaterno"
        txtApMaterno.Size = New Size(232, 34)
        txtApMaterno.TabIndex = 21
        ' 
        ' txtCorreo
        ' 
        txtCorreo.BorderStyle = BorderStyle.FixedSingle
        txtCorreo.Font = New Font("Segoe UI", 12F)
        txtCorreo.Location = New Point(457, 340)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(229, 34)
        txtCorreo.TabIndex = 22
        ' 
        ' txtContraseña
        ' 
        txtContraseña.BorderStyle = BorderStyle.FixedSingle
        txtContraseña.Font = New Font("Segoe UI", 12F)
        txtContraseña.Location = New Point(62, 431)
        txtContraseña.Name = "txtContraseña"
        txtContraseña.Size = New Size(235, 34)
        txtContraseña.TabIndex = 23
        ' 
        ' txtConfirmar
        ' 
        txtConfirmar.BorderStyle = BorderStyle.FixedSingle
        txtConfirmar.Font = New Font("Segoe UI", 12F)
        txtConfirmar.Location = New Point(459, 431)
        txtConfirmar.Name = "txtConfirmar"
        txtConfirmar.Size = New Size(227, 34)
        txtConfirmar.TabIndex = 24
        ' 
        ' txtPregunta
        ' 
        txtPregunta.BorderStyle = BorderStyle.FixedSingle
        txtPregunta.Font = New Font("Segoe UI", 12F)
        txtPregunta.Location = New Point(62, 574)
        txtPregunta.Name = "txtPregunta"
        txtPregunta.Size = New Size(235, 34)
        txtPregunta.TabIndex = 25
        ' 
        ' txtRpta
        ' 
        txtRpta.BorderStyle = BorderStyle.FixedSingle
        txtRpta.Font = New Font("Segoe UI", 12F)
        txtRpta.Location = New Point(457, 574)
        txtRpta.Name = "txtRpta"
        txtRpta.Size = New Size(232, 34)
        txtRpta.TabIndex = 26
        ' 
        ' linkLogin
        ' 
        linkLogin.AutoSize = True
        linkLogin.BackColor = Color.Transparent
        linkLogin.Font = New Font("Segoe UI", 10F)
        linkLogin.Location = New Point(50, 688)
        linkLogin.Name = "linkLogin"
        linkLogin.Size = New Size(154, 23)
        linkLogin.TabIndex = 27
        linkLogin.TabStop = True
        linkLogin.Text = "<-- Volver al login "
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.BackColor = Color.Transparent
        Label16.Font = New Font("Segoe UI", 9F)
        Label16.Location = New Point(62, 613)
        Label16.Name = "Label16"
        Label16.Size = New Size(447, 20)
        Label16.TabIndex = 28
        Label16.Text = "La pregunta de seguridad nos servira para recuperar tu contraseña"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.Transparent
        Label18.Font = New Font("Segoe UI", 9F)
        Label18.Location = New Point(62, 470)
        Label18.Name = "Label18"
        Label18.Size = New Size(214, 20)
        Label18.TabIndex = 30
        Label18.Text = "Requisitos minimos contraseña"
        ' 
        ' lblNumero
        ' 
        lblNumero.AutoSize = True
        lblNumero.BackColor = Color.Transparent
        lblNumero.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblNumero.ForeColor = Color.Gray
        lblNumero.Location = New Point(468, 502)
        lblNumero.Name = "lblNumero"
        lblNumero.Size = New Size(97, 23)
        lblNumero.TabIndex = 33
        lblNumero.Text = "un numero"
        ' 
        ' lblMayuscula
        ' 
        lblMayuscula.AutoSize = True
        lblMayuscula.BackColor = Color.Transparent
        lblMayuscula.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblMayuscula.ForeColor = Color.Gray
        lblMayuscula.Location = New Point(293, 502)
        lblMayuscula.Name = "lblMayuscula"
        lblMayuscula.Size = New Size(169, 23)
        lblMayuscula.TabIndex = 32
        lblMayuscula.Text = "una letra mayúscula"
        ' 
        ' lblCaracteres
        ' 
        lblCaracteres.AutoSize = True
        lblCaracteres.BackColor = Color.Transparent
        lblCaracteres.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblCaracteres.ForeColor = Color.Gray
        lblCaracteres.Location = New Point(179, 502)
        lblCaracteres.Name = "lblCaracteres"
        lblCaracteres.Size = New Size(105, 23)
        lblCaracteres.TabIndex = 31
        lblCaracteres.Text = "8 caracteres"
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.BackColor = Color.Transparent
        Label21.Font = New Font("Segoe UI", 8F)
        Label21.Location = New Point(50, 716)
        Label21.Name = "Label21"
        Label21.Size = New Size(412, 19)
        Label21.TabIndex = 34
        Label21.Text = "¿Eres colaborador ? - Comunicate con nosotros +51 970 809 160"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(298, 138)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(154, 145)
        PictureBox1.TabIndex = 35
        PictureBox1.TabStop = False
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.Transparent
        Label15.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        Label15.Location = New Point(29, 25)
        Label15.Name = "Label15"
        Label15.Size = New Size(330, 32)
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
        ' 
        ' RegistrarLector
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(1205, 754)
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
        Controls.Add(Label13)
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
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "RegistrarLector"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Registrar Lector"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label13 As Label
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
