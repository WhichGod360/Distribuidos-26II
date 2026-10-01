Imports System.Globalization
Imports capaDatos
Imports capaNegocio

Public Class frmPenalizacion
    Private ReadOnly negocio As New penalizacionNegocio()
    Private listaActual As New List(Of Penalizacion)()
    Private cargando As Boolean = False
    Private estadoSeleccionado As Boolean = True

    Private Sub frmPenalizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargando = True
        cboFiltroEstado.Items.AddRange(New Object() {"Todos", "Activo", "Inactivo"})
        cboFiltroEstado.SelectedIndex = 0
        cboEstadoReg.Items.AddRange(New Object() {"Activo", "Inactivo"})
        cboEstadoReg.SelectedIndex = 0
        cargando = False

        cargarGrilla()
        limpiarFormulario()
    End Sub

    Private Function obtenerFiltroEstado() As Boolean?
        Select Case cboFiltroEstado.SelectedIndex
            Case 1 : Return True
            Case 2 : Return False
            Case Else : Return Nothing
        End Select
    End Function

    Private Sub cargarGrilla()
        If cargando Then Return
        Try
            listaActual = negocio.buscar(txtBuscar.Text.Trim(), obtenerFiltroEstado())
            DataGridView1.Rows.Clear()
            For Each p As Penalizacion In listaActual
                DataGridView1.Rows.Add(p.IdPenalizacion, p.TipoPenalizacion,
                                       "S/ " & p.MontoPenalizacion.ToString("N2"),
                                       p.DescripcionPenalizacion, p.EstadoTexto)
            Next
        Catch ex As Exception
            MessageBox.Show("Error al cargar las sanciones: " & ex.Message, "Sanciones",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub limpiarFormulario()
        txtId.Clear()
        txtTipo.Clear()
        txtMonto.Text = "0.00"
        txtDescripcion.Clear()
        cboEstadoReg.SelectedIndex = 0
        estadoSeleccionado = True
        DataGridView1.ClearSelection()
        actualizarBotones()
        txtTipo.Focus()
    End Sub

    Private Sub actualizarBotones()
        Dim haySeleccion As Boolean = txtId.Text <> ""
        btnCambiarEstado.Enabled = haySeleccion
        btnVerDetalles.Enabled = haySeleccion
        btnCambiarEstado.Text = If(estadoSeleccionado, "Desactivar", "Activar")
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        cargarGrilla()
    End Sub

    Private Sub cboFiltroEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFiltroEstado.SelectedIndexChanged
        cargarGrilla()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Return
        Dim id As Integer = CInt(DataGridView1.Rows(e.RowIndex).Cells("colId").Value)
        Dim p As Penalizacion = listaActual.FirstOrDefault(Function(x) x.IdPenalizacion = id)
        If p Is Nothing Then Return

        txtId.Text = p.IdPenalizacion.ToString()
        txtTipo.Text = p.TipoPenalizacion
        txtMonto.Text = p.MontoPenalizacion.ToString("0.00", CultureInfo.CurrentCulture)
        txtDescripcion.Text = p.DescripcionPenalizacion
        cboEstadoReg.SelectedIndex = If(p.EstadoPenalizacion, 0, 1)
        estadoSeleccionado = p.EstadoPenalizacion
        actualizarBotones()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiarFormulario()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarFormulario()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim tipo As String = txtTipo.Text.Trim()
        If tipo = "" Then
            MessageBox.Show("Ingrese el tipo de sanción.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTipo.Focus()
            Return
        End If

        Dim monto As Decimal
        If Not Decimal.TryParse(txtMonto.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, monto) Then
            MessageBox.Show("El monto debe ser un número válido.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMonto.Focus()
            Return
        End If
        If monto < 0 OrElse monto > 99999.99D Then
            MessageBox.Show("El monto debe estar entre 0 y 99999.99.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMonto.Focus()
            Return
        End If

        Dim estado As Boolean = (cboEstadoReg.SelectedIndex = 0)
        Dim descripcion As String = txtDescripcion.Text.Trim()

        Try
            Dim ok As Boolean
            If txtId.Text = "" Then
                ok = negocio.agregarPenalizacion(tipo, descripcion, monto, estado)
            Else
                ok = negocio.actualizarPenalizacion(CInt(txtId.Text), tipo, descripcion, monto, estado)
            End If

            If ok Then
                MessageBox.Show("Sanción guardada correctamente.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cargarGrilla()
                limpiarFormulario()
            Else
                MessageBox.Show("No se pudo guardar la sanción.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al guardar la sanción: " & ex.Message, "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCambiarEstado_Click(sender As Object, e As EventArgs) Handles btnCambiarEstado.Click
        If txtId.Text = "" Then Return
        Dim nuevoEstado As Boolean = Not estadoSeleccionado
        Dim accion As String = If(nuevoEstado, "activar", "desactivar")

        If MessageBox.Show($"¿Desea {accion} la sanción seleccionada?", "Sanciones",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            If negocio.cambiarEstado(CInt(txtId.Text), nuevoEstado) Then
                cargarGrilla()
                limpiarFormulario()
            Else
                MessageBox.Show("No se pudo cambiar el estado.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cambiar el estado: " & ex.Message, "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        If txtId.Text = "" Then Return
        Using f As New frmDetallePenalizacion(CInt(txtId.Text))
            f.ShowDialog(Me)
        End Using
    End Sub
End Class