Imports capaDatos

Public Class ejemplarNegocio
    Private ReadOnly dao As New ejemplarDAO()
    Private ReadOnly reglas As IReglasLibro = New reglasLibroNegocio()

    Public Function obtenerDisponible(idLibro As Integer) As Ejemplar
        seguridadNegocio.ExigirPersonal()
        Dim ejemplar As Ejemplar = dao.obtenerDisponible(idLibro)
        If ejemplar Is Nothing Then
            Throw New Exception("No existen ejemplares disponibles para este libro.")
        End If
        Return ejemplar
    End Function

    Public Function listarDisponiblesPorLibro(idLibro As Integer, Optional idLector As Integer = 0) As List(Of Ejemplar)
        seguridadNegocio.ExigirPersonal()
        Return dao.listarDisponiblesPorLibro(idLibro, idLector)
    End Function

    Public Function listarPorLibro(idLibro As Integer) As Global.System.Data.DataTable
        If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
        seguridadNegocio.ExigirPersonal()
        Return dao.listarPorLibro(idLibro)
    End Function

    Public Function agregar(idLibro As Integer) As Boolean
        If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
        seguridadNegocio.ExigirPersonal()
        Return dao.agregar(idLibro,reglas)
    End Function

    Public Function cambiarEstado(idLibro As Integer, idEjemplar As Integer, activo As Boolean) As Boolean
        If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
        If idEjemplar <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idEjemplar))
        seguridadNegocio.ExigirPersonal()
        Return dao.cambiarEstado(idLibro, idEjemplar, activo,reglas)
    End Function
End Class
