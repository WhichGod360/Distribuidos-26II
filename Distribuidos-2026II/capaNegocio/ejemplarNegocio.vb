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
End Class