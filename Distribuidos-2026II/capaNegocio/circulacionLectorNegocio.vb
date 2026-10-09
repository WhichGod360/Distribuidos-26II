Imports capaDatos

Public NotInheritable Class circulacionLectorNegocio
    Public Shared Function Evaluar(prestamos As IEnumerable(Of Prestamo), solicitudes As IEnumerable(Of SolicitudPrestamo), penalizaciones As ResumenPenalizaciones) As EstadoCirculacionLector
        Dim pendientes = prestamos.Count(Function(p) Not p.FechaRetorno.HasValue OrElse
            Not String.Equals(If(p.EstadoPrestamo, "").Trim(), Prestamo.EstadoDevuelto, StringComparison.OrdinalIgnoreCase))
        Return New EstadoCirculacionLector With {.LibrosPendientes = pendientes,
            .CupoDisponible = Math.Max(0, PoliticaPrestamo.MaximoEjemplares - pendientes),
            .TieneSolicitudVigente = solicitudes.Any(Function(s) PuedeCancelar(s)),
            .TienePagosPorRegularizar = penalizaciones.BloqueaPrestamos}
    End Function

    Public Shared Function PuedeCancelar(solicitud As SolicitudPrestamo) As Boolean
        Return solicitud IsNot Nothing AndAlso {"Pendiente", "Aprobada"}.Contains(solicitud.EstadoActual) AndAlso solicitud.FechaLimiteRetiro > Date.UtcNow
    End Function

    Public Shared Function PuedeAgregar(libro As Libro, carrito As IList(Of Libro), estado As EstadoCirculacionLector) As Boolean
        Return libro IsNot Nothing AndAlso libro.Disponibles > 0 AndAlso Not carrito.Any(Function(l) l.IdLibro = libro.IdLibro) AndAlso
            Not estado.TieneSolicitudVigente AndAlso Not estado.TienePagosPorRegularizar AndAlso carrito.Count < estado.CupoDisponible
    End Function

    Public Shared Sub Agregar(libro As Libro, carrito As IList(Of Libro), estado As EstadoCirculacionLector)
        If Not PuedeAgregar(libro, carrito, estado) Then Throw New InvalidOperationException("No puedes agregar este libro. Revisa disponibilidad, cupo, reservas y pagos.")
        carrito.Add(libro)
    End Sub

    Public Shared Function PuedeSolicitar(carrito As IList(Of Libro), estado As EstadoCirculacionLector) As Boolean
        Return carrito.Count > 0 AndAlso carrito.Count <= estado.CupoDisponible AndAlso Not estado.TieneSolicitudVigente AndAlso Not estado.TienePagosPorRegularizar
    End Function
End Class
