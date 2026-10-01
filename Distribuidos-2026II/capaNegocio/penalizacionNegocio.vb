Imports capaDatos

Public Class penalizacionNegocio
    Private ReadOnly dao As New penalizacionDAO()

    Public Function listarTodos() As List(Of Penalizacion)
        Return dao.listarTodos()
    End Function

    Public Function buscar(texto As String, estado As Boolean?) As List(Of Penalizacion)
        Return dao.buscar(texto, estado)
    End Function

    Public Function buscarPorId(idPenalizacion As Integer) As Penalizacion
        Return dao.buscarPorId(idPenalizacion)
    End Function

    Public Function agregarPenalizacion(tipo As String, descripcion As String, monto As Decimal, estado As Boolean) As Boolean
        Return dao.agregarPenalizacion(tipo, descripcion, monto, estado)
    End Function

    Public Function actualizarPenalizacion(idPenalizacion As Integer, tipo As String, descripcion As String, monto As Decimal, estado As Boolean) As Boolean
        Return dao.actualizarPenalizacion(idPenalizacion, tipo, descripcion, monto, estado)
    End Function

    Public Function cambiarEstado(idPenalizacion As Integer, estado As Boolean) As Boolean
        Return dao.cambiarEstado(idPenalizacion, estado)
    End Function
End Class