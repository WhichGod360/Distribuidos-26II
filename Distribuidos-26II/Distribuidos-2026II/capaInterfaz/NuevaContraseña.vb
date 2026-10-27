Imports capaNegocio

Public Class NuevaContraseña
    Private ReadOnly _email As String
    Private ReadOnly _autorizacion As String
    Private ReadOnly negocioUsuario As New usuarioNegocio()

    Public Sub New(email As String, autorizacion As String)
        InitializeComponent()
        _email = email
        _autorizacion = autorizacion
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub NuevaContraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        TextBox1.MaxLength = 128
        TextBox1.UseSystemPasswordChar = True
        txtRpta.MaxLength = 128
        txtRpta.UseSystemPasswordChar = True
        ActualizarRequisitosVisuales(TextBox1.Text)
    End Sub

    ' Evento cuando el usuario escribe en la caja de "Nueva Contraseña"
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ActualizarRequisitosVisuales(TextBox1.Text)
    End Sub

    ' Paso 8: Cambiar a verde cuando cumple el parámetro individual en tiempo real
    Private Sub ActualizarRequisitosVisuales(password As String)
        Dim requisitos = usuarioNegocio.EvaluarClave(password)
        lblCaracteres.ForeColor = If(requisitos.LongitudValida, Color.ForestGreen, Color.Gray)
        lblMayuscula.ForeColor = If(requisitos.TieneMayuscula, Color.ForestGreen, Color.Gray)
        lblNumero.ForeColor = If(requisitos.TieneNumero, Color.ForestGreen, Color.Gray)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim frm As New Login()
        frm.Show()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim pass As String = TextBox1.Text
        Dim confirmPass As String = txtRpta.Text

        ' Negocio valida los requisitos y la confirmación antes de guardar. y actualizar en la base de datos
        Try
            negocioUsuario.CambiarContrasena(_email, pass, confirmPass, _autorizacion)
            MessageBox.Show("¡Contraseña actualizada con éxito! Ahora puede iniciar sesión con su nueva clave.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim frmLogin As New Login()
            frmLogin.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CerrarRecuperacion(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        negocioUsuario.CancelarRecuperacion(_autorizacion)
        TextBox1.Clear()
        txtRpta.Clear()
    End Sub
End Class
