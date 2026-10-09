Imports capaNegocio
Imports capaDatos
Imports System.Data.SqlClient
Imports System.Threading.Tasks
Public Class Login
    Private ReadOnly negocioUsuario As New usuarioNegocio()
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnIniciarSesion
        txtContraseña.UseSystemPasswordChar = True
        txtCorreo.Focus()
    End Sub

    Private Async Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        If Not btnIniciarSesion.Enabled Then Return
        Dim email As String = txtCorreo.Text.Trim()
        Dim password As String = txtContraseña.Text
        If String.IsNullOrWhiteSpace(email) Then
            MessageBox.Show("Debe ingresar su correo electrónico.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCorreo.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Debe ingresar su contraseña.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContraseña.Focus()
            Return
        End If

        btnIniciarSesion.Enabled = False
        lblOlvide.Enabled = False
        lblRegistrate.Enabled = False
        UseWaitCursor = True
        Try
            Dim usuarioValido As Usuario = Await Task.Run(Function() negocioUsuario.IniciarSesion(email, password))

            MessageBox.Show($"¡Bienvenido al sistema, {usuarioValido.NombreCompleto}!" & vbCrLf & $"Rol: {usuarioValido.NombreRol}", "Acceso Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim principal As New frmPrincipal()
            principal.Show()
            Me.Hide()

        Catch ex As UnauthorizedAccessException
            MessageBox.Show(ex.Message, "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As SqlException
            MessageBox.Show("No se pudo conectar con la base de datos. Intente nuevamente.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("No se pudo iniciar sesión. Intente nuevamente.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            txtContraseña.Clear()
            checkMostrar.Checked = False
            txtContraseña.UseSystemPasswordChar = True
            UseWaitCursor = False
            btnIniciarSesion.Enabled = True
            lblOlvide.Enabled = True
            lblRegistrate.Enabled = True
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
