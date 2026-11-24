Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmPenalizacion
    Implements IMantenimientoVista

    Public Event SolicitarDetalles(idPenalizacion As Integer)
    Private ReadOnly negocio As New penalizacionNegocio()
    Private textoBuscado As String = ""
    Private estadoBuscado As Boolean?

    Public Sub New()
        InitializeComponent()
        cboFiltroEstado.SelectedIndex = 0
    End Sub

    Private Sub frmPenalizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarPenalizaciones()
    End Sub

    Public Sub ListarPenalizaciones() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        Try
            Dim lista = negocio.buscar(textoBuscado, estadoBuscado)
            tablaPenalizaciones.DataSource = lista
            tablaPenalizaciones.ClearSelection()
            lblResumen.Text = lista.Count & " penalización(es)"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        textoBuscado = txtBuscar.Text.Trim()
        estadoBuscado = Nothing
        If cboFiltroEstado.SelectedIndex > 0 Then estadoBuscado = (cboFiltroEstado.SelectedIndex = 1)
        ListarPenalizaciones()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AbrirEditor(Nothing)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim penalizacion = PenalizacionSeleccionada()
        If penalizacion IsNot Nothing Then AbrirEditor(penalizacion)
    End Sub

    Private Sub btnCambiarEstado_Click(sender As Object, e As EventArgs) Handles btnCambiarEstado.Click
        Dim penalizacion = PenalizacionSeleccionada()
        If penalizacion Is Nothing Then Return
        Dim accion = If(penalizacion.EstadoPenalizacion, "desactivar", "activar")
        If MessageBox.Show("¿Deseas " & accion & " la penalización seleccionada?", "Penalizaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            If Not negocio.cambiarEstado(penalizacion.IdPenalizacion, Not penalizacion.EstadoPenalizacion) Then Throw New InvalidOperationException("No se pudo cambiar el estado.")
            ListarPenalizaciones()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        Dim penalizacion = PenalizacionSeleccionada()
        If penalizacion IsNot Nothing Then RaiseEvent SolicitarDetalles(penalizacion.IdPenalizacion)
    End Sub

    Private Sub AbrirEditor(penalizacion As Penalizacion)
        Using editor As New frmPenalizacionEditar(penalizacion)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ListarPenalizaciones()
        End Using
    End Sub

    Private Function PenalizacionSeleccionada() As Penalizacion
        If tablaPenalizaciones.SelectedRows.Count = 0 Then Return Nothing
        Return TryCast(tablaPenalizaciones.SelectedRows(0).DataBoundItem, Penalizacion)
    End Function

    Private Sub tablaPenalizaciones_SelectionChanged(sender As Object, e As EventArgs) Handles tablaPenalizaciones.SelectionChanged
        Dim penalizacion = PenalizacionSeleccionada()
        btnEditar.Enabled = penalizacion IsNot Nothing
        btnCambiarEstado.Enabled = penalizacion IsNot Nothing
        btnVerDetalles.Enabled = penalizacion IsNot Nothing
        btnCambiarEstado.Text = If(penalizacion IsNot Nothing AndAlso Not penalizacion.EstadoPenalizacion, "Activar", "Desactivar")
    End Sub
End Class
