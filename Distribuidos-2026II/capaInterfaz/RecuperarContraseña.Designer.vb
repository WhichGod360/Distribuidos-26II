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
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        Label1.Location = New Point(20, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(263, 32)
        Label1.TabIndex = 0
        Label1.Text = "Recuperar contraseña"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.ForeColor = Color.Gray
        Label2.Location = New Point(20, 46)
        Label2.Name = "Label2"
        Label2.Size = New Size(402, 23)
        Label2.TabIndex = 1
        Label2.Text = "Responde tu pregunta de seguridad para continuar"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label3.Location = New Point(24, 82)
        Label3.Name = "Label3"
        Label3.Size = New Size(243, 25)
        Label3.TabIndex = 2
        Label3.Text = "Tu pregunta de seguridad"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label4.Location = New Point(24, 154)
        Label4.Name = "Label4"
        Label4.Size = New Size(124, 25)
        Label4.TabIndex = 3
        Label4.Text = "Tu respuesta"
        ' 
        ' btonCancelar
        ' 
        btonCancelar.BackColor = Color.Transparent
        btonCancelar.FlatAppearance.BorderColor = Color.DodgerBlue
        btonCancelar.FlatAppearance.BorderSize = 2
        btonCancelar.FlatStyle = FlatStyle.Flat
        btonCancelar.Font = New Font("Segoe UI Black", 10F, FontStyle.Bold)
        btonCancelar.ForeColor = Color.DodgerBlue
        btonCancelar.Location = New Point(29, 240)
        btonCancelar.Name = "btonCancelar"
        btonCancelar.Size = New Size(123, 41)
        btonCancelar.TabIndex = 4
        btonCancelar.Text = "Cancelar"
        btonCancelar.UseVisualStyleBackColor = True
        ' 
        ' btonVerificar
        ' 
        btonVerificar.BackColor = Color.DodgerBlue
        btonVerificar.FlatAppearance.BorderSize = 2
        btonVerificar.FlatStyle = FlatStyle.Flat
        btonVerificar.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btonVerificar.ForeColor = Color.White
        btonVerificar.Location = New Point(289, 243)
        btonVerificar.Name = "btonVerificar"
        btonVerificar.Size = New Size(123, 41)
        btonVerificar.TabIndex = 1
        btonVerificar.Text = "Verificar"
        btonVerificar.UseVisualStyleBackColor = False
        ' 
        ' txtPregunta
        ' 
        txtPregunta.Anchor = AnchorStyles.Right
        txtPregunta.BackColor = Color.Gainsboro
        txtPregunta.BorderStyle = BorderStyle.None
        txtPregunta.Font = New Font("Segoe UI", 10F)
        txtPregunta.Location = New Point(55, 111)
        txtPregunta.Name = "txtPregunta"
        txtPregunta.ReadOnly = True
        txtPregunta.Size = New Size(331, 23)
        txtPregunta.TabIndex = 6
        ' 
        ' txtRpta
        ' 
        txtRpta.Anchor = AnchorStyles.Right
        txtRpta.BorderStyle = BorderStyle.FixedSingle
        txtRpta.Font = New Font("Segoe UI", 10F)
        txtRpta.Location = New Point(55, 181)
        txtRpta.Name = "txtRpta"
        txtRpta.Size = New Size(331, 30)
        txtRpta.TabIndex = 0
        ' 
        ' RecuperarContraseña
        ' 
        AcceptButton = btonVerificar
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btonCancelar
        ClientSize = New Size(437, 302)
        Controls.Add(txtRpta)
        Controls.Add(txtPregunta)
        Controls.Add(btonVerificar)
        Controls.Add(btonCancelar)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "RecuperarContraseña"
        StartPosition = FormStartPosition.CenterParent
        Text = "RecuperarContraseña"
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
