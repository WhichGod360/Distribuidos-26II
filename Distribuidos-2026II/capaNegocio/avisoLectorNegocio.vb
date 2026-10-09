Imports capaDatos

Public Class avisoLectorNegocio
    Public Function ConsultarMios() As List(Of AvisoLector)
        Dim lector=seguridadNegocio.ExigirLector()
        Dim reservas=New solicitudPrestamoNegocio().listarMias()
        Dim prestamos=New prestamoNegocio().listarPorLector(lector)
        Dim penalizaciones=New detallePenalizacionNegocio().ConsultarMias()
        Dim avisos As New List(Of AvisoLector)
        For Each reserva In reservas.Where(Function(s) circulacionLectorNegocio.PuedeCancelar(s))
            Dim aprobada=reserva.EstadoActual="Aprobada"
            avisos.Add(New AvisoLector With {.Asunto=If(aprobada,"Reserva aprobada","Reserva pendiente"),
                .Detalle=$"Solicitud {reserva.IdSolicitud}: {reserva.Libros}. Recoger hasta {reserva.LimiteLocal:dd/MM/yyyy HH:mm} (Lima). " &
                If(aprobada,"Acércate a ventanilla antes del vencimiento.","Espera la aprobación; el plazo de cinco días ya está corriendo.")})
        Next
        For Each prestamo In prestamos.Where(Function(p) prestamoNegocio.PuedeDevolver(p))
            Dim faltan=(prestamo.FechaFin-Date.Today).Days
            If faltan>1 Then Continue For
            avisos.Add(New AvisoLector With {.Asunto=If(faltan<0,"Préstamo vencido","Devolución próxima"),
                .Detalle=$"Préstamo {prestamo.IdPrestamo}: {prestamo.TituloLibro}. Fecha límite {prestamo.FechaFin:dd/MM/yyyy}. " &
                If(faltan<0,$"{-faltan} día(s) de retraso. La mora fija se confirma al devolver.","Devuelve a tiempo para evitar mora.")})
        Next
        If penalizaciones.BloqueaPrestamos Then avisos.Add(New AvisoLector With {.Asunto="Penalizaciones por regularizar",
            .Detalle=$"Pendiente o por revisar: S/ {penalizaciones.TotalPorRegularizar:0.00}. Consulta los motivos en Mis penalizaciones y regulariza en ventanilla."})
        If avisos.Count=0 Then avisos.Add(New AvisoLector With {.Asunto="Sin avisos pendientes",.Detalle="Tus reservas y préstamos no requieren una acción próxima."})
        Return avisos
    End Function
End Class
