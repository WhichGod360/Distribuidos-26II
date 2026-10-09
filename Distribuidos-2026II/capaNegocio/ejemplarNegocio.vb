Imports capaDatos

Public Class ejemplarNegocio
    Private ReadOnly dao As New ejemplarDAO()

    Public Function obtenerDisponible(idLibro As Integer) As Ejemplar
        Dim ejemplar As Ejemplar = dao.obtenerDisponible(idLibro)
        If ejemplar Is Nothing Then
            Throw New Exception("No existen ejemplares disponibles para este libro.")
        End If
        Return ejemplar
    End Function

    Public Function listarDisponiblesPorLibro(idLibro As Integer) As List(Of Ejemplar)
        Return dao.listarDisponiblesPorLibro(idLibro)
    End Function

    Public Function listarPorLibro(idLibro As Integer) As Global.System.Data.DataTable
        If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
        Return dao.listarPorLibro(idLibro)
    End Function

    Public Function agregar(idLibro As Integer) As Boolean
        If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
        Return dao.agregar(idLibro)
    End Function

    Public Function cambiarEstado(idLibro As Integer, idEjemplar As Integer, activo As Boolean) As Boolean
        If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
        If idEjemplar <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idEjemplar))
        Return dao.cambiarEstado(idLibro, idEjemplar, activo)
    End Function
End Class
