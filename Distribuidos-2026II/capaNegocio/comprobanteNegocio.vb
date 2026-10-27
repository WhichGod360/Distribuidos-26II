Imports capaDatos

Public Class comprobanteNegocio
    Public Function PorPrestamo(id As Integer, devolucion As Boolean) As ComprobanteBiblioteca
        Try
            seguridadNegocio.ExigirPersonal()
            If id <= 0 Then Throw New ArgumentException("Selecciona un préstamo.")
            Dim prestamo = New prestamoDAO().listar("Todos", "", Date.Today, 0, id).FirstOrDefault()
            If prestamo Is Nothing Then Throw New InvalidOperationException("El préstamo no existe.")
            If devolucion AndAlso Not prestamo.FechaRetorno.HasValue Then Throw New InvalidOperationException("Confirma primero la devolución.")
            Dim comprobante As New ComprobanteBiblioteca With {
                .Tipo = If(devolucion, "Devolución", "Entrega"), .Referencia = "Préstamo N.º " & id,
                .EmitidoPor = SesionUsuario.NombreCompleto, .Prestamos = New List(Of Prestamo) From {prestamo}}
            If devolucion Then comprobante.Penalizaciones = New detallePenalizacionDAO().listar(0, id)
            comprobante.TotalCargos = comprobante.Penalizaciones.Sum(Function(d) d.MontoPenalizacion)
            Return comprobante
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar el comprobante.", ex)
        End Try
    End Function

    Public Function PorSolicitud(id As Integer) As ComprobanteBiblioteca
        Try
            seguridadNegocio.ExigirPersonal()
            Dim solicitud = New solicitudPrestamoNegocio().listarTodas().FirstOrDefault(Function(s) s.IdSolicitud = id)
            If solicitud Is Nothing OrElse solicitud.EstadoActual <> "Atendida" Then Throw New InvalidOperationException("La solicitud debe estar entregada.")
            Dim ids = solicitud.Detalles.Select(Function(d) d.IdPrestamo.GetValueOrDefault()).ToList()
            Dim prestamos As New List(Of Prestamo)
            Dim dao As New prestamoDAO
            For Each prestamo In ids
                prestamos.AddRange(dao.listar("Todos", "", Date.Today, 0, prestamo))
            Next
            If prestamos.Count <> ids.Count OrElse prestamos.Any(Function(p) p.IdUsuario <> solicitud.IdUsuario) Then Throw New InvalidOperationException("La entrega está incompleta. Revisa sus préstamos.")
            Return New ComprobanteBiblioteca With {.Tipo = "Entrega", .Referencia = "Solicitud N.º " & id,
                .EmitidoPor = SesionUsuario.NombreCompleto, .Prestamos = prestamos}
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar el comprobante.", ex)
        End Try
    End Function
End Class
