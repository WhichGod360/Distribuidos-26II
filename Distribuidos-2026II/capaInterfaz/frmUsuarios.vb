Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmUsuarios
    Implements IMantenimientoVista

    Private ReadOnly negocio As New usuarioNegocio()
    Private cargando As Boolean
    Public Event DatosCambiados As EventHandler

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Cargar(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        cargando = True
        Try
            seguridadNegocio.ExigirAdministrador()
            Dim roles As New List(Of RolUsuario) From {New RolUsuario With {.IdRolUsuario = 0, .NombreRolUsuario = "Todos los roles"}}
            roles.AddRange(negocio.ListarRoles())
            cboRol.DisplayMember = "NombreRolUsuario"
            cboRol.ValueMember = "IdRolUsuario"
            cboRol.DataSource = roles
            cboEstado.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
        Finally
            cargando = False
        End Try
        If Not IsDisposed Then ActualizarDatos()
    End Sub

    Public Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If cargando OrElse ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        Try
            Dim rol As Integer = If(cboRol.SelectedValue Is Nothing, 0, CInt(cboRol.SelectedValue))
            Dim estado As String = If(TryCast(cboEstado.SelectedItem, String), "Todos")
            Dim lista As List(Of Usuario) = negocio.ListarUsuarios(txtBuscar.Text, rol, estado)
            tablaUsuarios.DataSource = lista
            tablaUsuarios.ClearSelection()
            lblResumen.Text = $"{lista.Count} usuario(s) · Solo el administrador puede crear cuentas y modificar roles o estados."
            ActualizarSeleccion()
        Catch ex As Exception
            tablaUsuarios.DataSource = Nothing
            ActualizarSeleccion()
            lblResumen.Text = "No se pudo actualizar el listado."
            MessageBox.Show(ex.Message, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Function Seleccionado() As Usuario
        If tablaUsuarios.SelectedRows.Count = 0 Then Return Nothing
        Return TryCast(tablaUsuarios.SelectedRows(0).DataBoundItem, Usuario)
    End Function

    Private Sub ActualizarSeleccion()
        Dim usuario As Usuario = Seleccionado()
        btnEditar.Enabled = usuario IsNot Nothing
        btnEstado.Enabled = usuario IsNot Nothing
        btnEstado.Text = If(usuario IsNot Nothing AndAlso String.Equals(usuario.EstadoUsuario.Trim(), "Activo", StringComparison.OrdinalIgnoreCase), "Desactivar", "Activar")
    End Sub

    Private Sub AbrirEditor(usuario As Usuario)
        If usuario Is Nothing AndAlso Not btnAgregar.Enabled Then Return
        Try
            seguridadNegocio.ExigirAdministrador()
            Using editor As New frmUsuarioDetalle(usuario)
                If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then
                    ActualizarDatos()
                    RaiseEvent DatosCambiados(Me, EventArgs.Empty)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub CambiarEstado(sender As Object, e As EventArgs) Handles btnEstado.Click
        Dim usuario As Usuario = Seleccionado()
        If usuario Is Nothing Then Return
        Dim estado As String = If(String.Equals(usuario.EstadoUsuario.Trim(), "Activo", StringComparison.OrdinalIgnoreCase), "Inactivo", "Activo")
        If MessageBox.Show($"¿Cambiar la cuenta de {usuario.NombreCompleto} a {estado}?", "Estado de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            negocio.CambiarEstadoUsuario(usuario.IdUsuario, estado)
            ActualizarDatos()
            RaiseEvent DatosCambiados(Me, EventArgs.Empty)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Estado de usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If Not IsHandleCreated Then Return
        ActualizarDatos()
    End Sub

    Private Sub cboRol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRol.SelectedIndexChanged
        If Not IsHandleCreated Then Return
        ActualizarDatos()
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        If Not IsHandleCreated Then Return
        ActualizarDatos()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        ActualizarDatos()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AbrirEditor(Nothing)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        AbrirEditor(Seleccionado())
    End Sub

    Private Sub tablaUsuarios_SelectionChanged(sender As Object, e As EventArgs) Handles tablaUsuarios.SelectionChanged
        If Not IsHandleCreated Then Return
        ActualizarSeleccion()
    End Sub

    Private Sub tablaUsuarios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tablaUsuarios.CellDoubleClick
        If e.RowIndex >= 0 Then AbrirEditor(Seleccionado())
    End Sub
End Class
