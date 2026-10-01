Imports capaDatos
Imports capaNegocio

Public Class frmDetallePenalizacion
    Private ReadOnly negocio As New detallePenalizacionNegocio()
    Private ReadOnly negocioPen As New penalizacionNegocio()
    Private listaActual As New List(Of DetallePenalizacion)()
    Private cargando As Boolean = False
    Private idPenalizacionInicial As Integer = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    ' Abre el formulario filtrado por la sanción seleccionada en frmPenalizacion
    Public Sub New(idPenalizacion As Integer)
        Me.New()
        idPenalizacionInicial = idPenalizacion
    End Sub

    Private Sub frmDetallePenalizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargando = True
        Try
            Dim sanciones As List(Of Penalizacion) = negocioPen.listarTodos()

            cboPenalizacion.DisplayMember = "DescripcionCombo"
            cboPenalizacion.ValueMember = "IdPenalizacion"
            cboPenalizacion.DataSource = sanciones

            Dim filtro As New List(Of KeyValuePair(Of Integer, String))()
            filtro.Add(New KeyValuePair(Of Integer, String)(0, "(Todas las sanciones)"))
            For Each s As Penalizacion In sanciones
                filtro.Add(New KeyValuePair(Of Integer, String)(s.IdPenalizacion, s.DescripcionCombo))
            Next
            cboFiltroSancion.DisplayMember = "Value"
            cboFiltroSancion.ValueMember = "Key"
            cboFiltroSancion.DataSource = filtro

            cboPrestamo.DisplayMember = "Texto"
            cboPrestamo.ValueMember = "IdPrestamo"
            cboPrestamo.DataSource = negocio.listarPrestamos()

            If idPenalizacionInicial > 0 Then cboFiltroSancion.SelectedValue = idPenalizacionInicial
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos: " & ex.Message, "Detalle de sanciones",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cargando = False

        cargarGrilla()
        limpiarFormulario()
    End Sub

    Private Function idFiltro() As Integer
        If cboFiltroSancion.SelectedValue Is Nothing Then Return 0
        Return CInt(cboFiltroSancion.SelectedValue)
    End Function

    Private Sub cargarGrilla()
        If cargando Then Return
        Try
            listaActual = negocio.listar(idFiltro())
            DataGridView1.Rows.Clear()
            For Each d As DetallePenalizacion In listaActual
                DataGridView1.Rows.Add(
                    d.IdDetallePenalizacion,
                    d.TipoPenalizacion,
                    "S/ " & d.MontoPenalizacion.ToString("N2"),
                    d.IdPrestamo,
                    d.NombreUsuario,
                    d.TituloLibro,
                    d.FechaInicio.ToString("dd/MM/yyyy"),
                    d.FechaFin.ToString("dd/MM/yyyy"),
                    If(d.FechaRetorno.HasValue, d.FechaRetorno.Value.ToString("dd/MM/yyyy"), "-"),
                    d.DiasRetraso,
                    d.EstadoPrestamo,
                    d.DescripcionDetallePenalizacion)
            Next
        Catch ex As Exception
            MessageBox.Show("Error al cargar los detalles: " & ex.Message, "Detalle de sanciones",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub limpiarFormulario()
        txtId.Clear()
        txtDescripcion.Clear()
        If idFiltro() > 0 Then
            cboPenalizacion.SelectedValue = idFiltro()
        Else
            cboPenalizacion.SelectedIndex = -1
        End If
        cboPrestamo.SelectedIndex = -1
        DataGridView1.ClearSelection()
    End Sub

    Private Sub cboFiltroSancion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFiltroSancion.SelectedIndexChanged
        cargarGrilla()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Return
        Dim id As Integer = CInt(DataGridView1.Rows(e.RowIndex).Cells("colId").Value)
        Dim d As DetallePenalizacion = listaActual.FirstOrDefault(Function(x) x.IdDetallePenalizacion = id)
        If d Is Nothing Then Return

        txtId.Text = d.IdDetallePenalizacion.ToString()
        cboPenalizacion.SelectedValue = d.IdPenalizacion
        cboPrestamo.SelectedValue = d.IdPrestamo
        txtDescripcion.Text = d.DescripcionDetallePenalizacion
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarFormulario()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cboPenalizacion.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione una sanción.", "Detalle de sanciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPenalizacion.Focus()
            Return
        End If
        If cboPrestamo.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione un préstamo.", "Detalle de sanciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPrestamo.Focus()
            Return
        End If

        Dim sancion As Penalizacion = TryCast(cboPenalizacion.SelectedItem, Penalizacion)
        If txtId.Text = "" AndAlso sancion IsNot Nothing AndAlso Not sancion.EstadoPenalizacion Then
            MessageBox.Show("No se puede registrar un detalle con una sanción inactiva.", "Detalle de sanciones",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim idPen As Integer = CInt(cboPenalizacion.SelectedValue)
        Dim idPrestamo As Integer = CInt(cboPrestamo.SelectedValue)
        Dim descripcion As String = txtDescripcion.Text.Trim()

        Try
            Dim ok As Boolean
            If txtId.Text = "" Then
                ok = negocio.agregarDetalle(descripcion, idPen, idPrestamo)
            Else
                ok = negocio.actualizarDetalle(CInt(txtId.Text), descripcion, idPen, idPrestamo)
            End If

            If ok Then
                MessageBox.Show("Detalle guardado correctamente.", "Detalle de sanciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cargarGrilla()
                limpiarFormulario()
            Else
                MessageBox.Show("No se pudo guardar el detalle.", "Detalle de sanciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al guardar el detalle: " & ex.Message, "Detalle de sanciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class