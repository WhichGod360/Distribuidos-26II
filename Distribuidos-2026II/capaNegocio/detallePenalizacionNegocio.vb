Imports capaDatos

Public Class detallePenalizacionNegocio
    Private ReadOnly dao As New detallePenalizacionDAO()

    Public Function listar(idPenalizacion As Integer) As List(Of DetallePenalizacion)
        Return dao.listar(idPenalizacion)
    End Function

    Public Function listarPrestamos() As List(Of PrestamoResumen)
        Return dao.listarPrestamos()
    End Function

    Public Function agregarDetalle(descripcion As String, idPenalizacion As Integer, idPrestamo As Integer, Optional estadoPago As String = DetallePenalizacion.PagoPendiente) As Boolean
        ValidarEstadoPago(estadoPago)
        Return dao.agregarDetalle(descripcion, idPenalizacion, idPrestamo, estadoPago)
    End Function

    Public Function actualizarDetalle(idDetalle As Integer, descripcion As String, idPenalizacion As Integer, idPrestamo As Integer, Optional estadoPago As String = Nothing) As Boolean
        If estadoPago IsNot Nothing Then ValidarEstadoPago(estadoPago)
        Return dao.actualizarDetalle(idDetalle, descripcion, idPenalizacion, idPrestamo, estadoPago)
    End Function

    Private Shared Sub ValidarEstadoPago(estado As String)
        If Not {DetallePenalizacion.PagoPendiente, DetallePenalizacion.PagoPagada, DetallePenalizacion.PagoPorRevisar}.Contains(estado) Then
            Throw New ArgumentException("Selecciona un estado de pago válido: Pendiente, Pagada o Por revisar.")
        End If
    End Sub
End Class
