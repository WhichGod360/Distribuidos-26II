Imports capaNegocio
Imports capaDatos
Imports System.Threading.Tasks

Public Class Login
    Private ReadOnly negocioUsuario As New usuarioNegocio()
    ' Usa las mismas capas para actualizar respuestas existentes sin abrir una sesión.
    Private ReadOnly soloMigracion As Boolean = Environment.GetCommandLineArgs().Any(
        Function(a) String.Equals(a, "--migrar-seguridad", StringComparison.OrdinalIgnoreCase))

    Public Sub New()
        InitializeComponent()
        If soloMigracion Then
            Opacity = 0
            ShowInTaskbar = False
        End If
    End Sub

    Private Async Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        Me.AcceptButton = btnIniciarSesion
        txtContraseña.UseSystemPasswordChar = True
        txtCorreo.Focus()
        btnIniciarSesion.Enabled = False
        lblOlvide.Enabled = False
        lblRegistrate.Enabled = False
        UseWaitCursor = True
        Try
            Await Task.Run(Sub() negocioUsuario.PrepararSeguridad())
            If soloMigracion Then Console.WriteLine("Respuestas de seguridad actualizadas con PBKDF2-SHA256.")
        Catch ex As Exception
            If soloMigracion Then
                Environment.ExitCode = 1
                Console.Error.WriteLine(ex.Message)
            Else
                MessageBox.Show(ex.Message, "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            If soloMigracion Then
                Application.Exit()
            ElseIf Not IsDisposed Then
                btnIniciarSesion.Enabled = True
                lblOlvide.Enabled = True
                lblRegistrate.Enabled = True
                UseWaitCursor = False
            End If
        End Try
    End Sub

    Private Async Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        If Not btnIniciarSesion.Enabled Then Return
        Dim email As String = txtCorreo.Text.Trim()
        Dim password As String = txtContraseña.Text

        btnIniciarSesion.Enabled = False
        lblOlvide.Enabled = False
        lblRegistrate.Enabled = False
        UseWaitCursor = True
        Try
            Dim usuarioValido As Usuario = Await Task.Run(Function() negocioUsuario.IniciarSesion(email, password))

            ' Validamos si las credenciales fueron incorrectas (retornó Nothing)
            If usuarioValido Is Nothing Then
                MessageBox.Show("Correo o contraseña incorrectos, o la cuenta está inactiva.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            MessageBox.Show($"¡Bienvenido al sistema, {usuarioValido.NombreCompleto}!" & vbCrLf & $"Rol: {usuarioValido.NombreRol}", "Acceso Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim principal As Form
            If seguridadNegocio.EsRolLector(usuarioValido.NombreRol) Then
                principal = New frmLector()
            ElseIf seguridadNegocio.EsRolPersonal(usuarioValido.NombreRol) Then
                principal = New frmPrincipal With {.IdUsuario = usuarioValido.IdUsuario,
                    .Usuario = usuarioValido.NombreCompleto, .Rol = usuarioValido.NombreRol}
            Else
                SesionUsuario.Cerrar()
                Throw New UnauthorizedAccessException("El rol de esta cuenta no tiene una interfaz habilitada.")
            End If

            principal.Show()
            Me.Hide()
        Catch ex As UnauthorizedAccessException
            MessageBox.Show(ex.Message, "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
