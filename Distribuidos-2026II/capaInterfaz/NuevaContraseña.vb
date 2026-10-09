Imports capaNegocio

Public Class NuevaContraseña
    Private ReadOnly _email As String
    Private ReadOnly negocioUsuario As New usuarioNegocio()

    Public Sub New(email As String)
        InitializeComponent()
        _email = email
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub NuevaContraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        ActualizarRequisitosVisuales(TextBox1.Text)
    End Sub

    ' Evento cuando el usuario escribe en la caja de "Nueva Contraseña"
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ActualizarRequisitosVisuales(TextBox1.Text)
    End Sub

    ' Paso 8: Cambiar a verde cuando cumple el parámetro individual en tiempo real
    Private Sub ActualizarRequisitosVisuales(password As String)
        ' 1. Requisito 8 caracteres
        If password.Length >= 8 Then
            lblCaracteres.ForeColor = Color.ForestGreen
        Else
            lblCaracteres.ForeColor = Color.Gray
        End If

        ' 2. Requisito una letra mayúscula
        If password.Any(AddressOf Char.IsUpper) Then
            lblMayuscula.ForeColor = Color.ForestGreen
        Else
            lblMayuscula.ForeColor = Color.Gray
        End If

        ' 3. Requisito un número
        If password.Any(AddressOf Char.IsDigit) Then
            lblNumero.ForeColor = Color.ForestGreen
        Else
            lblNumero.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim frm As New Login()
        frm.Show()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim pass As String = TextBox1.Text
        Dim confirmPass As String = txtRpta.Text

        ' Resaltar en rojo los parámetros que faltan si intenta guardar sin cumplirlos
        Dim tieneLongitud As Boolean = (pass.Length >= 8)
        Dim tieneMayuscula As Boolean = pass.Any(AddressOf Char.IsUpper)
        Dim tieneNumero As Boolean = pass.Any(AddressOf Char.IsDigit)

        If Not tieneLongitud Then lblCaracteres.ForeColor = Color.Red
        If Not tieneMayuscula Then lblMayuscula.ForeColor = Color.Red
        If Not tieneNumero Then lblNumero.ForeColor = Color.Red

        If Not (tieneLongitud AndAlso tieneMayuscula AndAlso tieneNumero) Then
            MessageBox.Show("Asegúrese de cumplir con los requisitos mínimos de seguridad en rojo.", "Requisitos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox1.Focus()
            Return
        End If

        ' Validar coincidencia de ambas contraseñas
        If pass <> confirmPass Then
            MessageBox.Show("Las contraseñas no coinciden. Verifíquelas.", "Error de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRpta.SelectAll()
            txtRpta.Focus()
            Return
        End If

        ' Paso 9: Guardar y actualizar en la base de datos
        Try
            negocioUsuario.CambiarContrasena(_email, pass, confirmPass)
            MessageBox.Show("¡Contraseña actualizada con éxito! Ahora puede iniciar sesión con su nueva clave.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim frmLogin As New Login()
            frmLogin.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class