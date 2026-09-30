Imports capaNegocio
Imports capaDatos
Public Class Login
    Private ReadOnly negocioUsuario As New usuarioNegocio()
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCorreo.Text = "bibliotecaria@biblioteca.usat.edu.pe"
        txtContraseña.Text = "luchos"
    End Sub

    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        Try
            Dim email As String = txtCorreo.Text.Trim()
            Dim password As String = txtContraseña.Text

            Dim usuarioValido As Usuario = negocioUsuario.IniciarSesion(email, password)

            MessageBox.Show($"¡Bienvenido al sistema, {usuarioValido.NombreCompleto}!" & vbCrLf & $"Rol: {usuarioValido.NombreRol}", "Acceso Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim principal As New frmPrincipal()
            principal.Show()
            Me.Hide()

        Catch ex As ArgumentException
            MessageBox.Show(ex.Message, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lblOlvide_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblOlvide.LinkClicked
        Dim email As String = txtCorreo.Text.Trim()

        ' Paso 3: Solicitar correo si está vacío
        If String.IsNullOrWhiteSpace(email) Then
            MessageBox.Show("Por favor, ingresa tu correo electrónico en el campo correspondiente para recuperar tu contraseña.", "Correo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCorreo.Focus()
            Return
        End If

        Try
            ' Validar que el correo exista antes de abrir la ventana
            Dim pregunta As String = negocioUsuario.ObtenerPregunta(email)

            ' Paso 4 y 5: Abrir formulario pasando el correo y la pregunta
            Dim frmRecuperar As New RecuperarContraseña(email, pregunta)
            frmRecuperar.StartPosition = FormStartPosition.CenterScreen
            frmRecuperar.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub checkMostrar_CheckedChanged(sender As Object, e As EventArgs) Handles checkMostrar.CheckedChanged
        txtContraseña.UseSystemPasswordChar = Not checkMostrar.Checked
    End Sub

    Private Sub lblRegistrate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRegistrate.LinkClicked
        Dim frm As New RegistrarLector()
        frm.Show()
        Me.Hide()
    End Sub
End Class
