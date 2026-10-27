Imports capaDatos
Imports capaNegocio

Public Class RegistrarLector
    Private ReadOnly negocioUsuario As New usuarioNegocio()

    Private Sub RegistrarLector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        txtDNI.MaxLength = 8
        txtPregunta.MaxLength = 255
        txtRpta.MaxLength = 200
        txtRpta.UseSystemPasswordChar = True
        txtContraseña.UseSystemPasswordChar = True
        txtConfirmar.UseSystemPasswordChar = True
        cboSexo.DropDownStyle = ComboBoxStyle.DropDownList
        cboFNacimiento.MaxDate = DateTime.Today
        ActualizarRequisitosVisuales(txtContraseña.Text)
    End Sub

    ' Restringir el DNI solo a dígitos
    Private Sub txtDNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDNI.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Actualizar indicadores de contraseña en tiempo real
    Private Sub txtContraseña_TextChanged(sender As Object, e As EventArgs) Handles txtContraseña.TextChanged
        ActualizarRequisitosVisuales(txtContraseña.Text)
    End Sub

    Private Sub ActualizarRequisitosVisuales(password As String)
        Dim requisitos = usuarioNegocio.EvaluarClave(password)
        lblCaracteres.ForeColor = If(requisitos.LongitudValida, Color.ForestGreen, Color.Gray)
        lblMayuscula.ForeColor = If(requisitos.TieneMayuscula, Color.ForestGreen, Color.Gray)
        lblNumero.ForeColor = If(requisitos.TieneNumero, Color.ForestGreen, Color.Gray)
    End Sub

    Private Sub linkLogin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLogin.LinkClicked
        Dim frm As New Login()
        frm.Show()
        Me.Close()
    End Sub

    Private Sub btnRegistrarse_Click(sender As Object, e As EventArgs) Handles btnRegistrarse.Click
        Dim pass As String = txtContraseña.Text
        Dim confirmPass As String = txtConfirmar.Text

        Try
            Dim nuevoLector As New Usuario() With {
                .NumeroDniUsuario = txtDNI.Text.Trim(),
                .NombreUsuario = txtNombres.Text.Trim(),
                .ApPaterno = txtApPaterno.Text.Trim(),
                .ApMaterno = txtApMaterno.Text.Trim(),
                .FechaNacimientoUsuario = cboFNacimiento.Value.Date,
                .EmailUsuario = txtCorreo.Text.Trim(),
                .Contrasena = pass,
                .PreguntaSegura = txtPregunta.Text.Trim(),
                .RptaSegura = txtRpta.Text.Trim()
            }

            ' Asignar género según selección: Masculino (True/1), Femenino (False/0)
            If cboSexo.SelectedIndex = 0 Then
                nuevoLector.GeneroUsuario = True
            ElseIf cboSexo.SelectedIndex = 1 Then
                nuevoLector.GeneroUsuario = False
            Else
                nuevoLector.GeneroUsuario = Nothing
            End If

            negocioUsuario.RegistrarNuevoLector(nuevoLector, confirmPass)

            MessageBox.Show("¡Registro exitoso! Ya puedes iniciar sesión con tu cuenta.", "Operación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim frmLogin As New Login()
            frmLogin.Show()
            Me.Close()
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs)
    End Sub
End Class
