Imports capaDatos

Public Class avisoLectorNegocio
    Public Function ConsultarMios() As List(Of AvisoLector)
        Try
            Dim lector = seguridadNegocio.ExigirLector()
            Dim reservas = New solicitudPrestamoNegocio().listarMias()
            Dim prestamos = New prestamoNegocio().listarPorLector(lector)
            Dim penalizaciones = New detallePenalizacionNegocio().ConsultarMias()
            Return CrearAvisos(reservas, prestamos, penalizaciones, ConsultarDecisionesPago())
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar los avisos.", ex)
        End Try
    End Function
    Public Shared Function ConsultarDecisionesPago() As List(Of AvisoLector)
        Try
            Dim pagos As New pagoYapeNegocio()
            If Not pagos.Disponible() Then Return New List(Of AvisoLector)()
            Return pagos.AvisosMios()
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudieron consultar los avisos de pago.", ex)
        End Try
    End Function

    Public Shared Function CrearAvisos(reservas As List(Of SolicitudPrestamo), prestamos As List(Of Prestamo),
                                       penalizaciones As ResumenPenalizaciones, decisionesPago As List(Of AvisoLector)) As List(Of AvisoLector)
        Dim avisos As New List(Of AvisoLector)(decisionesPago)
        For Each reserva In reservas.Where(Function(s) circulacionLectorNegocio.PuedeCancelar(s))
            Dim aprobada = reserva.EstadoActual = "Aprobada"
            avisos.Add(New AvisoLector With {.Asunto = If(aprobada, "Reserva aprobada", "Reserva pendiente"),
                .Detalle = $"Solicitud {reserva.IdSolicitud}: {reserva.Libros}. Recoger hasta {reserva.LimiteLocal:dd/MM/yyyy HH:mm} (Lima). " &
                If(aprobada, "Acércate a ventanilla antes del vencimiento.", "Espera la aprobación; el plazo de cinco días ya está corriendo.")})
        Next
        For Each prestamo In prestamos.Where(Function(p) prestamoNegocio.PuedeDevolver(p))
            Dim faltan = (prestamo.FechaFin - Date.Today).Days
            If faltan > 1 Then Continue For
            avisos.Add(New AvisoLector With {.Asunto = If(faltan < 0, "Préstamo vencido", "Devolución próxima"),
                .Detalle = $"Préstamo {prestamo.IdPrestamo}: {prestamo.TituloLibro}. Fecha límite {prestamo.FechaFin:dd/MM/yyyy}. " &
                If(faltan < 0, $"{-faltan} día(s) de retraso. La mora fija se confirma al devolver.", "Devuelve a tiempo para evitar mora.")})
        Next
        If penalizaciones.BloqueaPrestamos Then avisos.Add(New AvisoLector With {.Asunto = "Penalizaciones por regularizar",
            .Detalle = $"Pendiente o por revisar: S/ {penalizaciones.TotalPorRegularizar:0.00}. Consulta los motivos en Mis penalizaciones y regulariza en ventanilla."})
        If avisos.Count = 0 Then avisos.Add(New AvisoLector With {.Asunto = "Sin avisos pendientes", .Detalle = "Tus reservas y préstamos no requieren una acción próxima."})
        Return avisos
    End Function
End Class
