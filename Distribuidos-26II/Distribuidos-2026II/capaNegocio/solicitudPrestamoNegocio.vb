Imports capaDatos

Public Class solicitudPrestamoNegocio
    Private ReadOnly dao As New solicitudPrestamoDAO()
    Private ReadOnly reglas As IReglasCirculacion = New reglasCirculacionNegocio()

    Public Function solicitar(idsLibros As IList(Of Integer)) As Integer
        Try
            ValidarCarrito(idsLibros)
            Return dao.solicitar(seguridadNegocio.ExigirLector(), idsLibros.ToList(), reglas)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al registrar las solicitudes.", ex)
        End Try
    End Function

    Public Function listarMias() As List(Of SolicitudPrestamo)
        Try
            Return PrepararConsulta(dao.listar(seguridadNegocio.ExigirLector()))
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar las solicitudes.", ex)
        End Try
    End Function

    Public Function listarPorLector(idLector As Integer) As List(Of SolicitudPrestamo)
        Try
            seguridadNegocio.ExigirAccesoLector(idLector)
            Return PrepararConsulta(dao.listar(idLector))
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar las solicitudes.", ex)
        End Try
    End Function

    Public Function listarTodas() As List(Of SolicitudPrestamo)
        Try
            seguridadNegocio.ExigirPersonal()
            Return PrepararConsulta(dao.listar())
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar las solicitudes.", ex)
        End Try
    End Function

    Public Sub cancelar(idSolicitud As Integer)
        Try
            ValidarId(idSolicitud)
            dao.cancelar(idSolicitud, seguridadNegocio.ExigirLector(), reglas)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al cancelar las solicitudes.", ex)
        End Try
    End Sub

    Public Sub aprobar(idSolicitud As Integer)
        Try
            ValidarId(idSolicitud)
            dao.aprobar(idSolicitud, seguridadNegocio.ExigirPersonal(), reglas)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al aprobar las solicitudes.", ex)
        End Try
    End Sub

    Public Sub rechazar(idSolicitud As Integer)
        Try
            ValidarId(idSolicitud)
            dao.rechazar(idSolicitud, seguridadNegocio.ExigirPersonal(), reglas)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al rechazar las solicitudes.", ex)
        End Try
    End Sub

    Public Function entregar(idSolicitud As Integer, ejemplares As IDictionary(Of Integer, Integer)) As List(Of Integer)
        Try
            ValidarId(idSolicitud)
            If ejemplares Is Nothing OrElse ejemplares.Count = 0 OrElse ejemplares.Keys.Any(Function(id) id <= 0) OrElse
                ejemplares.Values.Any(Function(id) id <= 0) OrElse ejemplares.Values.Distinct().Count() <> ejemplares.Count Then Throw New ArgumentException("Selecciona una copia distinta y válida para cada título.")
            Dim inicio = Date.Today
            Return dao.entregar(idSolicitud, seguridadNegocio.ExigirPersonal(), New Dictionary(Of Integer, Integer)(ejemplares), inicio, prestamoNegocio.FechaLimite(inicio), reglas)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al entregar las solicitudes.", ex)
        End Try
    End Function

    Private Shared Function PrepararConsulta(solicitudes As List(Of SolicitudPrestamo)) As List(Of SolicitudPrestamo)
        For Each solicitud In solicitudes
            solicitud.EstaVigente = circulacionLectorNegocio.PuedeCancelar(solicitud)
        Next
        Return solicitudes
    End Function

    Public Shared Function PuedeAprobar(solicitud As SolicitudPrestamo) As Boolean
        Return circulacionLectorNegocio.PuedeCancelar(solicitud) AndAlso solicitud.EstadoActual = "Pendiente"
    End Function

    Public Shared Function PuedeEntregar(solicitud As SolicitudPrestamo) As Boolean
        Return circulacionLectorNegocio.PuedeCancelar(solicitud) AndAlso solicitud.EstadoActual = "Aprobada"
    End Function

    Public Shared Function PuedeEmitirComprobante(solicitud As SolicitudPrestamo) As Boolean
        Return solicitud IsNot Nothing AndAlso solicitud.EstadoActual = "Atendida"
    End Function

    Public Shared Sub ValidarCarrito(idsLibros As IList(Of Integer))
        If idsLibros Is Nothing OrElse idsLibros.Count = 0 Then Throw New ArgumentException("Agrega al menos un libro al carrito.")
        If idsLibros.Count > PoliticaPrestamo.MaximoEjemplares Then Throw New ArgumentException("El carrito admite como máximo cinco libros.")
        If idsLibros.Any(Function(id) id <= 0) OrElse idsLibros.Distinct().Count() <> idsLibros.Count Then Throw New ArgumentException("El carrito debe contener títulos distintos y válidos.")
    End Sub

    Private Shared Sub ValidarId(id As Integer)
        If id <= 0 Then Throw New ArgumentException("Selecciona una solicitud válida.")
    End Sub
End Class
