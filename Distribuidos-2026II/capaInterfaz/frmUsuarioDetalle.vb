Imports System.Threading.Tasks
Imports capaDatos
Imports capaNegocio

Public Class frmUsuarioDetalle
    Private ReadOnly negocio As New usuarioNegocio()
    Private ReadOnly idUsuario As Integer
    Private guardando As Boolean

    Public Sub New()
        Me.New(Nothing)
    End Sub

    Public Sub New(usuario As Usuario)
        idUsuario = If(usuario Is Nothing, 0, usuario.IdUsuario)
        InitializeComponent()
    End Sub

    Private Sub Cargar(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        Try
            seguridadNegocio.ExigirAdministrador()
            cboRol.DisplayMember = "NombreRolUsuario"
            cboRol.ValueMember = "IdRolUsuario"
            cboRol.DataSource = negocio.ListarRoles()
            cboRol.SelectedIndex = -1
            cboGenero.SelectedIndex = 0
            cboEstado.SelectedItem = "Activo"
            dtNacimiento.Checked = False
            If idUsuario > 0 Then
                Dim usuario As Usuario = negocio.ObtenerUsuario(idUsuario)
                txtNombre.Text = usuario.NombreUsuario
                txtPaterno.Text = usuario.ApPaterno
                txtMaterno.Text = usuario.ApMaterno
                txtCorreo.Text = usuario.EmailUsuario
                txtDni.Text = usuario.NumeroDniUsuario
                cboRol.SelectedValue = usuario.IdRolUsuario
                cboEstado.SelectedItem = If(String.Equals(usuario.EstadoUsuario.Trim(), "Activo", StringComparison.OrdinalIgnoreCase), "Activo", "Inactivo")
                cboGenero.SelectedIndex = If(usuario.GeneroUsuario.HasValue, If(usuario.GeneroUsuario.GetValueOrDefault(), 2, 1), 0)
                If usuario.FechaNacimientoUsuario.HasValue Then
                    dtNacimiento.Value = usuario.FechaNacimientoUsuario.Value
                    dtNacimiento.Checked = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
        End Try
    End Sub

    Private Async Sub Guardar(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If guardando Then Return
        Dim usuario As New Usuario With {.IdUsuario = idUsuario, .NombreUsuario = txtNombre.Text,
            .ApPaterno = txtPaterno.Text, .ApMaterno = txtMaterno.Text, .EmailUsuario = txtCorreo.Text,
            .NumeroDniUsuario = txtDni.Text, .IdRolUsuario = If(cboRol.SelectedValue Is Nothing, 0, CInt(cboRol.SelectedValue)),
            .EstadoUsuario = TryCast(cboEstado.SelectedItem, String),
            .FechaNacimientoUsuario = If(dtNacimiento.Checked, CType(dtNacimiento.Value.Date, Date?), Nothing),
            .GeneroUsuario = If(cboGenero.SelectedIndex = 0, CType(Nothing, Boolean?), CType(cboGenero.SelectedIndex = 2, Boolean?)),
            .Contrasena = txtClave.Text, .PreguntaSegura = txtPregunta.Text, .RptaSegura = txtRespuesta.Text}
        Dim confirmacion As String = txtConfirmar.Text
        guardando = True
        Enabled = False
        UseWaitCursor = True
        Try
            Await Task.Run(Sub()
                               If idUsuario = 0 Then
                                   negocio.CrearUsuario(usuario, confirmacion)
                               Else
                                   negocio.ActualizarUsuario(usuario)
                               End If
                           End Sub)
            guardando = False
            DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Guardar usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            guardando = False
            If Not IsDisposed Then
                Enabled = True
                UseWaitCursor = False
            End If
        End Try
    End Sub

    Private Sub Cerrando(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If guardando Then e.Cancel = True
    End Sub

    Private Sub Cerrado(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        txtClave.Clear()
        txtConfirmar.Clear()
        txtRespuesta.Clear()
    End Sub
End Class
