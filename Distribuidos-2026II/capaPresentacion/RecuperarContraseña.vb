Imports capaNegocio

Public Class RecuperarContraseña
    Private ReadOnly _email As String
    Private ReadOnly _pregunta As String
    Private ReadOnly negocioUsuario As New usuarioNegocio()

    ' Constructor que recibe el email y la pregunta desde Login
    Public Sub New(email As String, pregunta As String)
        InitializeComponent()
        _email = email
        _pregunta = pregunta
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub RecuperarContraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        txtPregunta.Text = _pregunta
        txtRpta.Focus()
    End Sub

    Private Sub btonCancelar_Click(sender As Object, e As EventArgs) Handles btonCancelar.Click
        Dim frm As New Login()
        frm.Show()
        Me.Close()
    End Sub

    Private Sub btonVerificar_Click(sender As Object, e As EventArgs) Handles btonVerificar.Click
        Try
            Dim rptaIngresada As String = txtRpta.Text.Trim()

            ' Paso 6: Si la respuesta es igual a la de la BD
            If negocioUsuario.ValidarRespuesta(_email, rptaIngresada) Then
                MessageBox.Show("Respuesta correcta. Ahora puedes cambiar tu contraseña.", "Identidad confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Abrir ventana de Nueva Contraseña enviando el correo del usuario
                Dim frmNueva As New NuevaContraseña(_email)
                frmNueva.StartPosition = FormStartPosition.CenterScreen
                frmNueva.Show()
                Me.Close()
            End If

        Catch ex As ArgumentException
            MessageBox.Show(ex.Message, "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRpta.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error de verificación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRpta.SelectAll()
            txtRpta.Focus()
        End Try
    End Sub
End Class