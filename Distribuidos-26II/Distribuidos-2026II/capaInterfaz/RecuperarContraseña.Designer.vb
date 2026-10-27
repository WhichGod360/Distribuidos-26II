<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecuperarContraseña
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
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        btonCancelar = New Button()
        btonVerificar = New Button()
        txtPregunta = New TextBox()
        txtRpta = New TextBox()
        SuspendLayout()
        ' 
        ' Label1  (título)
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 17.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label1.Location = New Point(36, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(281, 38)
        Label1.TabIndex = 0
        Label1.Text = "Recuperar contraseña"
        ' 
        ' Label2  (subtítulo)
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
        Label2.Location = New Point(40, 66)
        Label2.Name = "Label2"
        Label2.Size = New Size(331, 20)
        Label2.TabIndex = 1
        Label2.Text = "Responde tu pregunta de seguridad para continuar"
        ' 
        ' Label3  (Tu pregunta de seguridad)
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label3.Location = New Point(40, 108)
        Label3.Name = "Label3"
        Label3.Size = New Size(160, 20)
        Label3.TabIndex = 2
        Label3.Text = "Tu pregunta de seguridad"
        ' 
        ' Label4  (Tu respuesta)
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        Label4.Location = New Point(40, 174)
        Label4.Name = "Label4"
        Label4.Size = New Size(86, 20)
        Label4.TabIndex = 3
        Label4.Text = "Tu respuesta"
        ' 
        ' btonCancelar  (botón secundario)
        ' 
        btonCancelar.BackColor = Color.White
        btonCancelar.Cursor = Cursors.Hand
        btonCancelar.FlatAppearance.BorderColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btonCancelar.FlatAppearance.BorderSize = 1
        btonCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(225), CByte(232), CByte(238))
        btonCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        btonCancelar.FlatStyle = FlatStyle.Flat
        btonCancelar.Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btonCancelar.ForeColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btonCancelar.Location = New Point(40, 262)
        btonCancelar.Name = "btonCancelar"
        btonCancelar.Size = New Size(170, 44)
        btonCancelar.TabIndex = 4
        btonCancelar.Text = "Cancelar"
        btonCancelar.UseVisualStyleBackColor = False
        ' 
        ' btonVerificar  (botón principal)
        ' 
        btonVerificar.BackColor = Color.FromArgb(CByte(59), CByte(91), CByte(115))
        btonVerificar.Cursor = Cursors.Hand
        btonVerificar.FlatAppearance.BorderSize = 0
        btonVerificar.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(35), CByte(56), CByte(72))
        btonVerificar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(47), CByte(72), CByte(92))
        btonVerificar.FlatStyle = FlatStyle.Flat
        btonVerificar.Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btonVerificar.ForeColor = Color.White
        btonVerificar.Location = New Point(230, 262)
        btonVerificar.Name = "btonVerificar"
        btonVerificar.Size = New Size(170, 44)
        btonVerificar.TabIndex = 1
        btonVerificar.Text = "Verificar"
        btonVerificar.UseVisualStyleBackColor = False
        ' 
        ' txtPregunta  (solo lectura)
        ' 
        txtPregunta.Anchor = AnchorStyles.None
        txtPregunta.BackColor = Color.FromArgb(CByte(240), CByte(237), CByte(232))
        txtPregunta.BorderStyle = BorderStyle.FixedSingle
        txtPregunta.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPregunta.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtPregunta.Location = New Point(40, 130)
        txtPregunta.Name = "txtPregunta"
        txtPregunta.ReadOnly = True
        txtPregunta.Size = New Size(360, 34)
        txtPregunta.TabIndex = 6
        txtPregunta.TabStop = False
        ' 
        ' txtRpta
        ' 
        txtRpta.Anchor = AnchorStyles.None
        txtRpta.BackColor = Color.FromArgb(CByte(250), CByte(248), CByte(245))
        txtRpta.BorderStyle = BorderStyle.FixedSingle
        txtRpta.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtRpta.ForeColor = Color.FromArgb(CByte(47), CByte(69), CByte(88))
        txtRpta.Location = New Point(40, 196)
        txtRpta.Name = "txtRpta"
        txtRpta.Size = New Size(360, 34)
        txtRpta.TabIndex = 0
        ' 
        ' RecuperarContraseña
        ' 
        AcceptButton = btonVerificar
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        CancelButton = btonCancelar
        ClientSize = New Size(440, 340)
        Controls.Add(txtRpta)
        Controls.Add(txtPregunta)
        Controls.Add(btonVerificar)
        Controls.Add(btonCancelar)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "RecuperarContraseña"
        StartPosition = FormStartPosition.CenterParent
        Text = "Recuperar contraseña"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btonCancelar As Button
    Friend WithEvents btonVerificar As Button
    Friend WithEvents txtPregunta As TextBox
    Friend WithEvents txtRpta As TextBox
End Class
