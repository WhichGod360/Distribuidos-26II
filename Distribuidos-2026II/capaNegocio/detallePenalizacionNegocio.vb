Imports capaDatos

Public Class detallePenalizacionNegocio
    Private ReadOnly dao As New detallePenalizacionDAO()

    Public Function listar(idPenalizacion As Integer) As List(Of DetallePenalizacion)
        Return dao.listar(idPenalizacion)
    End Function

    Public Function listarPrestamos() As List(Of PrestamoResumen)
        Return dao.listarPrestamos()
    End Function

    Public Function agregarDetalle(descripcion As String, idPenalizacion As Integer, idPrestamo As Integer) As Boolean
        Return dao.agregarDetalle(descripcion, idPenalizacion, idPrestamo)
    End Function

    Public Function actualizarDetalle(idDetalle As Integer, descripcion As String, idPenalizacion As Integer, idPrestamo As Integer) As Boolean
        Return dao.actualizarDetalle(idDetalle, descripcion, idPenalizacion, idPrestamo)
    End Function
End Class