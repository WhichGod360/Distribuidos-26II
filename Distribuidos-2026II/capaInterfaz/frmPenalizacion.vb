Imports System.Globalization
Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmPenalizacion
    Implements IMantenimientoVista

    Public Event SolicitarDetalles(idPenalizacion As Integer)
    Private ReadOnly negocio As New penalizacionNegocio()
    Private listaActual As New List(Of Penalizacion)()
    Private inicializado As Boolean

    Public Sub New()
        InitializeComponent()
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn With {.Name="colTramo",.HeaderText="Aplicación",.FillWeight=20})
        btnNuevo.Text = "Agregar penalización"
        btnGuardar.Text = "Editar"

        cboFiltroEstado.SelectedIndex = 0

        colId.FillWeight = 10
        colTipo.FillWeight = 23
        colMonto.FillWeight = 12
        colDescripcion.FillWeight = 37
        colEstado.FillWeight = 18
        AddHandler DataGridView1.SelectionChanged, AddressOf SeleccionChanged
        inicializado = True
        SeleccionChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub frmPenalizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        ActualizarDatos()
    End Sub

    Private Function Seleccionada() As Penalizacion
        If DataGridView1.SelectedRows.Count = 0 Then Return Nothing
        Dim id = CInt(DataGridView1.SelectedRows(0).Cells("colId").Value)
        Return listaActual.FirstOrDefault(Function(p) p.IdPenalizacion = id)
    End Function

    Public Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        If Not inicializado Then Return
        Try
            Dim estado As Boolean? = Nothing
            If cboFiltroEstado.SelectedIndex > 0 Then estado = cboFiltroEstado.SelectedIndex = 1
            listaActual = negocio.buscar(txtBuscar.Text.Trim(), estado)
            DataGridView1.Rows.Clear()
            For Each p In listaActual
                DataGridView1.Rows.Add(p.IdPenalizacion, p.TipoPenalizacion, "S/ " & p.MontoPenalizacion.ToString("N2"), p.DescripcionPenalizacion, p.EstadoTexto,p.TramoTexto)
            Next
            DataGridView1.ClearSelection()
            lblResumen.Text = listaActual.Count & " penalización(es)"
            SeleccionChanged(Me, EventArgs.Empty)
        Catch ex As Exception
            MessageBox.Show("No se pudieron cargar las penalizaciones: " & ex.Message, "Penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SeleccionChanged(sender As Object, e As EventArgs)
        Dim p = Seleccionada()
        btnGuardar.Enabled = p IsNot Nothing
        btnCambiarEstado.Enabled = p IsNot Nothing
        btnVerDetalles.Enabled = p IsNot Nothing
        btnCambiarEstado.Text = If(p IsNot Nothing AndAlso Not p.EstadoPenalizacion, "Activar", "Desactivar")
    End Sub

    Private Sub BuscarChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged, cboFiltroEstado.SelectedIndexChanged
        ActualizarDatos()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        AbrirEditor(Nothing)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim p = Seleccionada()
        If p IsNot Nothing Then AbrirEditor(p)
    End Sub

    Private Sub AbrirEditor(p As Penalizacion)
        Using editor As New frmPenalizacionEditar(p)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ActualizarDatos()
        End Using
    End Sub

    Private Sub btnCambiarEstado_Click(sender As Object, e As EventArgs) Handles btnCambiarEstado.Click
        Dim p = Seleccionada()
        If p Is Nothing Then Return
        Dim accion = If(p.EstadoPenalizacion, "desactivar", "activar")
        If MessageBox.Show("¿Deseas " & accion & " la penalización seleccionada?", "Penalizaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            If Not negocio.cambiarEstado(p.IdPenalizacion, Not p.EstadoPenalizacion) Then Throw New InvalidOperationException("No se pudo cambiar el estado.")
            ActualizarDatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        Dim p = Seleccionada()
        If p IsNot Nothing Then RaiseEvent SolicitarDetalles(p.IdPenalizacion)
    End Sub
End Class
