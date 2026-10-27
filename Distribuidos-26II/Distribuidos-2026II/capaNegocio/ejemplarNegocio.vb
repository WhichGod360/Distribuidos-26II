Imports capaDatos

Public Class ejemplarNegocio
    Private ReadOnly dao As New ejemplarDAO()
    Private ReadOnly reglas As IReglasLibro = New reglasLibroNegocio()

    Public Function obtenerDisponible(idLibro As Integer) As Ejemplar
        Try
            seguridadNegocio.ExigirPersonal()
            Dim ejemplar As Ejemplar = dao.obtenerDisponible(idLibro)
            If ejemplar Is Nothing Then
                Throw New Exception("No existen ejemplares disponibles para este libro.")
            End If
            Return ejemplar
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar los ejemplares.", ex)
        End Try
    End Function

    Public Function listarDisponiblesPorLibro(idLibro As Integer, Optional idLector As Integer = 0) As List(Of Ejemplar)
        Try
            seguridadNegocio.ExigirPersonal()
            Return dao.listarDisponiblesPorLibro(idLibro, idLector)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar los ejemplares.", ex)
        End Try
    End Function

    Public Function listarPorLibro(idLibro As Integer) As Global.System.Data.DataTable
        Try
            If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
            seguridadNegocio.ExigirPersonal()
            Return dao.listarPorLibro(idLibro)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar los ejemplares.", ex)
        End Try
    End Function

    Public Function agregar(idLibro As Integer) As Boolean
        Try
            If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
            seguridadNegocio.ExigirPersonal()
            Return dao.agregar(idLibro, reglas)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al registrar los ejemplares.", ex)
        End Try
    End Function

    Public Function cambiarEstado(idLibro As Integer, idEjemplar As Integer, activo As Boolean) As Boolean
        Try
            If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
            If idEjemplar <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idEjemplar))
            seguridadNegocio.ExigirPersonal()
            Return dao.cambiarEstado(idLibro, idEjemplar, activo, reglas)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al actualizar los ejemplares.", ex)
        End Try
    End Function
End Class
