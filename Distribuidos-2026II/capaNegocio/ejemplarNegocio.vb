Imports capaDatos

Public Class ejemplarNegocio
    Private ReadOnly dao As New ejemplarDAO()
    Private ReadOnly reglas As IReglasLibro = New reglasLibroNegocio()

    Public Function obtenerDisponible(idLibro As Integer) As Ejemplar
        Try
            If idLibro <= 0 Then Throw New ArgumentException("Selecciona un libro válido.")
            seguridadNegocio.ExigirPersonal()
            Dim ejemplar As Ejemplar = dao.obtenerDisponible(idLibro)
            If ejemplar Is Nothing Then
                Throw New InvalidOperationException("No existen ejemplares disponibles para este libro.")
            End If
            Return ejemplar
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar los ejemplares.", ex)
        End Try
    End Function

    Public Function listarDisponiblesPorLibro(idLibro As Integer, Optional idLector As Integer = 0) As List(Of Ejemplar)
        Try
            If idLibro <= 0 Then Throw New ArgumentException("Selecciona un libro válido.")
            If idLector < 0 Then Throw New ArgumentException("El lector seleccionado no es válido.")
            seguridadNegocio.ExigirPersonal()
            Return dao.listarDisponiblesPorLibro(idLibro, idLector)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar los ejemplares.", ex)
        End Try
    End Function

    Public Function listarPorLibro(idLibro As Integer) As Global.System.Data.DataTable
        Try
            If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
            seguridadNegocio.ExigirPersonal()
            Return dao.listarPorLibro(idLibro)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo listar los ejemplares del libro.", ex)
        End Try
    End Function

    Public Function agregar(idLibro As Integer) As Boolean
        Try
            If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
            Dim operador = seguridadNegocio.ExigirPersonal()
            Return dao.agregar(idLibro, reglas, operador)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo registrar el ejemplar.", ex)
        End Try
    End Function

    Public Function cambiarEstado(idLibro As Integer, idEjemplar As Integer, activo As Boolean) As Boolean
        Try
            If idLibro <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idLibro))
            If idEjemplar <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(idEjemplar))
            Dim operador = seguridadNegocio.ExigirPersonal()
            Return dao.cambiarEstado(idLibro, idEjemplar, activo, reglas, operador)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo cambiar el estado del ejemplar.", ex)
        End Try
    End Function
End Class
