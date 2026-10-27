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
        ' txtRpta  (confirmar contraseña)
        ' 
        txtRpta.Anchor = AnchorStyles.None
        txtRpta.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtRpta.BorderStyle = BorderStyle.FixedSingle
        txtRpta.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtRpta.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtRpta.Location = New Point(40, 196)
        txtRpta.Name = "txtRpta"
        txtRpta.PasswordChar = "*"c
        txtRpta.Size = New Size(360, 34)
        txtRpta.TabIndex = 1
        ' 
        ' btnGuardar  (botón principal)
        ' 
        btnGuardar.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnGuardar.Cursor = Cursors.Hand
        btnGuardar.FlatAppearance.BorderSize = 0
        btnGuardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btnGuardar.FlatStyle = FlatStyle.Flat
        btnGuardar.Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnGuardar.ForeColor = Color.White
        btnGuardar.Location = New Point(230, 300)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(170, 44)
        btnGuardar.TabIndex = 13
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' btnCancelar  (botón secundario)
        ' 
        btnCancelar.BackColor = Color.White
        btnCancelar.Cursor = Cursors.Hand
        btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnCancelar.FlatAppearance.BorderSize = 1
        btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCancelar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btnCancelar.Location = New Point(40, 300)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(170, 44)
        btnCancelar.TabIndex = 12
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = False
        ' 
        ' Label4  (Confirmar contraseña)
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label4.Location = New Point(40, 174)
        Label4.Name = "Label4"
        Label4.Size = New Size(138, 20)
        Label4.TabIndex = 11
        Label4.Text = "Confirmar contraseña"
        ' 
        ' Label3  (Nueva contraseña)
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label3.Location = New Point(40, 108)
        Label3.Name = "Label3"
        Label3.Size = New Size(108, 20)
        Label3.TabIndex = 10
        Label3.Text = "Nueva contraseña"
        ' 
        ' Label2  (subtítulo)
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        Label2.Location = New Point(40, 66)
        Label2.Name = "Label2"
        Label2.Size = New Size(276, 20)
        Label2.TabIndex = 9
        Label2.Text = "Crea una nueva contraseña para tu cuenta"
        ' 
        ' Label1  (título)
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 17.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label1.Location = New Point(36, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(253, 38)
        Label1.TabIndex = 8
        Label1.Text = "Cambiar contraseña"
        ' 
        ' TextBox1  (nueva contraseña)
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        TextBox1.Location = New Point(40, 130)
        TextBox1.Name = "TextBox1"
        TextBox1.PasswordChar = "*"c
        TextBox1.Size = New Size(360, 34)
        TextBox1.TabIndex = 0
        ' 
        ' lblCaracteres
        ' 
        lblCaracteres.AutoSize = True
        lblCaracteres.BackColor = Color.Transparent
        lblCaracteres.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCaracteres.ForeColor = Color.Gray
        lblCaracteres.Location = New Point(40, 258)
        lblCaracteres.Name = "lblCaracteres"
        lblCaracteres.Size = New Size(90, 20)
        lblCaracteres.TabIndex = 17
        lblCaracteres.Text = "8 caracteres"
        ' 
        ' lblMayuscula
        ' 
        lblMayuscula.AutoSize = True
        lblMayuscula.BackColor = Color.Transparent
        lblMayuscula.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMayuscula.ForeColor = Color.Gray
        lblMayuscula.Location = New Point(146, 258)
        lblMayuscula.Name = "lblMayuscula"
        lblMayuscula.Size = New Size(142, 20)
        lblMayuscula.TabIndex = 18
        lblMayuscula.Text = "una letra mayúscula"
        ' 
        ' Label7  (título de requisitos)
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        Label7.Location = New Point(40, 238)
        Label7.Name = "Label7"
        Label7.Size = New Size(119, 19)
        Label7.TabIndex = 19
        Label7.Text = "Requisitos mínimos:"
        ' 
        ' lblNumero
        ' 
        lblNumero.AutoSize = True
        lblNumero.BackColor = Color.Transparent
        lblNumero.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNumero.ForeColor = Color.Gray
        lblNumero.Location = New Point(304, 258)
        lblNumero.Name = "lblNumero"
        lblNumero.Size = New Size(72, 20)
        lblNumero.TabIndex = 20
        lblNumero.Text = "un número"
        ' 
        ' NuevaContraseña
        ' 
        AcceptButton = btnGuardar
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        CancelButton = btnCancelar
        ClientSize = New Size(440, 380)
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
        Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "NuevaContraseña"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Cambiar contraseña"
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
