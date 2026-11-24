Imports capaDatos

Public Class detallePenalizacionNegocio
    Private ReadOnly dao As New detallePenalizacionDAO()
    Private ReadOnly reglas As IReglasPenalizacion = New reglasPenalizacionNegocio()

    Public Function ConsultarMias() As ResumenPenalizaciones
        Try
            Dim lector As Integer = seguridadNegocio.ExigirLector()
            Return Resumir(dao.ListarPorLector(lector))
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar los cargos.", ex)
        End Try
    End Function

    Public Shared Function Resumir(detalles As List(Of DetallePenalizacion)) As ResumenPenalizaciones
        Dim resumen As New ResumenPenalizaciones With {.Detalles = detalles,
            .Total = detalles.Sum(Function(d) d.MontoPenalizacion),
            .Pendiente = detalles.Where(Function(d) d.EstadoPago = DetallePenalizacion.PagoPendiente).Sum(Function(d) d.MontoPenalizacion),
            .PorRevisar = detalles.Where(Function(d) d.EstadoPago = DetallePenalizacion.PagoPorRevisar).Sum(Function(d) d.MontoPenalizacion),
            .Pagado = detalles.Where(Function(d) d.EstadoPago = DetallePenalizacion.PagoPagada).Sum(Function(d) d.MontoPenalizacion),
            .BloqueaPrestamos = detalles.Any(Function(d) d.EstadoPago <> DetallePenalizacion.PagoPagada)}
        resumen.TotalPorRegularizar = resumen.Pendiente + resumen.PorRevisar
        Return resumen
    End Function

    Public Function listar(idPenalizacion As Integer) As List(Of DetallePenalizacion)
        Try
            seguridadNegocio.ExigirPersonal()
            If idPenalizacion < 0 Then Throw New ArgumentException("Selecciona un tipo de penalización válido.")
            Return dao.listar(idPenalizacion)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar los cargos.", ex)
        End Try
    End Function

    Public Function listarPrestamos() As List(Of PrestamoResumen)
        Try
            seguridadNegocio.ExigirPersonal()
            Return dao.listarPrestamos()
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar los cargos.", ex)
        End Try
    End Function

    Public Function agregarDetalle(descripcion As String, idPenalizacion As Integer, idPrestamo As Integer, Optional estadoPago As String = DetallePenalizacion.PagoPendiente) As Boolean
        Try
            If estadoPago Is Nothing Then Throw New ArgumentException("Selecciona el estado del pago.")
            Dim operador = seguridadNegocio.ExigirPersonal()
            If idPenalizacion <= 0 OrElse idPrestamo <= 0 Then Throw New ArgumentException("Selecciona el préstamo y el tipo de penalización.")
            ValidarDatos(descripcion, estadoPago)
            Return dao.agregarDetalle(descripcion, idPenalizacion, idPrestamo, operador, reglas, estadoPago)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al registrar los cargos.", ex)
        End Try
    End Function

    Public Function actualizarDetalle(idDetalle As Integer, descripcion As String, idPenalizacion As Integer, idPrestamo As Integer, Optional estadoPago As String = Nothing) As Boolean
        Try
            If idDetalle <= 0 Then Throw New ArgumentException("Selecciona el cargo que deseas editar.")
            Dim operador = seguridadNegocio.ExigirPersonal()
            If idPenalizacion <= 0 OrElse idPrestamo <= 0 Then Throw New ArgumentException("Selecciona el préstamo y el tipo de penalización.")
            ValidarDatos(descripcion, estadoPago)
            Return dao.actualizarDetalle(idDetalle, descripcion, idPenalizacion, idPrestamo, operador, reglas, estadoPago)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al actualizar los cargos.", ex)
        End Try
    End Function

    Public Shared Sub ValidarDatos(descripcion As String, pago As String)
        If String.IsNullOrWhiteSpace(descripcion) Then Throw New ArgumentException("Escribe el motivo del cargo.")
        If pago IsNot Nothing Then ValidarEstadoPago(pago)
    End Sub

    Private Shared Sub ValidarEstadoPago(estado As String)
        If Not {DetallePenalizacion.PagoPendiente, DetallePenalizacion.PagoPagada, DetallePenalizacion.PagoPorRevisar}.Contains(estado) Then
            Throw New ArgumentException("Selecciona un estado de pago válido: Pendiente, Pagada o Por revisar.")
        End If
    End Sub
End Class
