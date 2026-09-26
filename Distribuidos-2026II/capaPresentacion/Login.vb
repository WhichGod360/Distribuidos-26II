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
            ' Obtenemos los valores de tus cajas de texto
            Dim email As String = txtCorreo.Text.Trim()
            Dim password As String = txtContraseña.Text

            ' Llamamos a la lógica de negocio
            Dim usuarioValido As Usuario = negocioUsuario.IniciarSesion(email, password)

            ' Mensaje de éxito si las credenciales coinciden
            MessageBox.Show($"¡Bienvenido al sistema, {usuarioValido.NombreCompleto}!" & vbCrLf &
                            $"Rol: {usuarioValido.NombreRol}",
                            "Acceso Correcto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            ' Abrir la pantalla principal y ocultar el login
            Dim principal As New frmPrincipal()
            principal.Show()
            Me.Hide()

        Catch ex As ArgumentException
            ' Avisos de validación (por ejemplo, si dejan cajas vacías)
            MessageBox.Show(ex.Message, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            ' Errores de credenciales incorrectas o problemas de conexión a SQL Server
            MessageBox.Show(ex.Message, "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
