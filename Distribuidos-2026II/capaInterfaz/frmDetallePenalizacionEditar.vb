Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmDetallePenalizacionEditar

    Private ReadOnly detalle As DetallePenalizacion
    Private ReadOnly idInicial As Integer
    Private ReadOnly negocio As New detallePenalizacionNegocio()

    Public Sub New()
        InitializeComponent()
        cboPago.SelectedIndex = 0
        AddHandler Load, AddressOf Cargar
        AddHandler guardar.Click, AddressOf Guardar_Click
    End Sub

    Public Sub New(detalle As DetallePenalizacion, idPenalizacion As Integer)
        Me.New()
        Me.detalle = detalle
        idInicial = idPenalizacion
        If detalle IsNot Nothing Then lblTituloVista.Text = "Editar detalle"
        Text = lblTituloVista.Text
    End Sub

    Private Sub Cargar(sender As Object, e As EventArgs)
        If ContextoDiseno.Activo(Me) Then Return
        Try
            sancion.DisplayMember = "DescripcionCombo"
            sancion.ValueMember = "IdPenalizacion"
            sancion.DataSource = New penalizacionNegocio().listarTodos()
            prestamo.DisplayMember = "Texto"
            prestamo.ValueMember = "IdPrestamo"
            prestamo.DataSource = negocio.listarPrestamos()
            sancion.SelectedIndex = -1
            prestamo.SelectedIndex = -1
            If detalle IsNot Nothing Then
                sancion.SelectedValue = detalle.IdPenalizacion
                prestamo.SelectedValue = detalle.IdPrestamo
                descripcion.Text = detalle.DescripcionDetallePenalizacion
                cboPago.SelectedItem = detalle.EstadoPagoTexto
            ElseIf idInicial > 0 Then
                sancion.SelectedValue = idInicial
            End If
        Catch ex As Exception
            guardar.Enabled = False
            MessageBox.Show(ex.Message, "Detalle de penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs)
        If sancion.SelectedValue Is Nothing OrElse prestamo.SelectedValue Is Nothing Then
            MessageBox.Show("Selecciona una penalización y un préstamo.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim p = TryCast(sancion.SelectedItem, Penalizacion)
        If detalle Is Nothing AndAlso p IsNot Nothing AndAlso Not p.EstadoPenalizacion Then
            MessageBox.Show("No se puede registrar un detalle con una penalización inactiva.", "Penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            Dim estadoPago = If(CStr(cboPago.SelectedItem) = "Por revisar", DetallePenalizacion.PagoPorRevisar, CStr(cboPago.SelectedItem))
            Dim ok = If(detalle Is Nothing,
                negocio.agregarDetalle(descripcion.Text.Trim(), CInt(sancion.SelectedValue), CInt(prestamo.SelectedValue), estadoPago),
                negocio.actualizarDetalle(detalle.IdDetallePenalizacion, descripcion.Text.Trim(), CInt(sancion.SelectedValue), CInt(prestamo.SelectedValue), estadoPago))
            If Not ok Then Throw New InvalidOperationException("No se pudo guardar el detalle.")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Detalle de penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
