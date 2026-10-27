Imports capaDatos

Public NotInheritable Class reglasCirculacionNegocio
    Implements IReglasCirculacion

    Public Sub ValidarUsuario(usuario As Usuario, rol As String, mensaje As String) Implements IReglasCirculacion.ValidarUsuario
        Dim roles As String() = If(rol = "BIBLIOTECARIO", {"BIBLIOTECARIO", "ADMINISTRADOR"}, {"ESTUDIANTE", "LECTOR"})
        If usuario Is Nothing OrElse Not String.Equals(usuario.EstadoUsuario.Trim(), "Activo", StringComparison.OrdinalIgnoreCase) OrElse
            Not roles.Contains(usuario.NombreRol.Trim().ToUpperInvariant()) Then Throw New InvalidOperationException(mensaje)
    End Sub

    Public Sub ValidarLector(datos As DatosLectorPrestamo, cantidadNueva As Integer) Implements IReglasCirculacion.ValidarLector
        ValidarUsuario(datos.Usuario, "ESTUDIANTE", "El lector debe ser un estudiante activo.")
        If cantidadNueva < 1 OrElse cantidadNueva > PoliticaPrestamo.MaximoEjemplares Then Throw New ArgumentException("La solicitud debe contener entre uno y cinco libros.")
        If datos.PrestamosPendientes + cantidadNueva > PoliticaPrestamo.MaximoEjemplares Then
            Throw New InvalidOperationException($"El lector tiene {datos.PrestamosPendientes} libro(s) pendientes de devolución. Solo puede recibir o reservar {Math.Max(0, PoliticaPrestamo.MaximoEjemplares - datos.PrestamosPendientes)} más; el máximo es cinco en total.")
        End If
        If datos.EstadosPago.Contains(DetallePenalizacion.PagoPendiente) Then Throw New InvalidOperationException("El lector tiene una penalización pendiente de pago. Debe regularizarla antes de recibir otro préstamo.")
        If datos.EstadosPago.Any(Function(p) p <> DetallePenalizacion.PagoPagada) Then Throw New InvalidOperationException("El lector tiene una penalización con pago por revisar. Confirma su estado de pago antes de registrar otro préstamo.")
    End Sub

    Public Sub ValidarLibro(estado As Boolean?) Implements IReglasCirculacion.ValidarLibro
        If Not estado.GetValueOrDefault() Then Throw New InvalidOperationException("El libro no existe o está inactivo.")
    End Sub

    Public Sub ValidarEjemplar(estado As Boolean?, prestamosAbiertos As Integer) Implements IReglasCirculacion.ValidarEjemplar
        If Not estado.GetValueOrDefault() Then Throw New InvalidOperationException("El ejemplar no existe o está inactivo.")
        If prestamosAbiertos > 0 Then Throw New InvalidOperationException("El ejemplar ya tiene un préstamo sin cerrar. Actualiza la disponibilidad.")
    End Sub

    Public Sub ValidarVentanilla(solicitudesVigentes As Integer, capacidad As Integer) Implements IReglasCirculacion.ValidarVentanilla
        If solicitudesVigentes > 0 Then Throw New InvalidOperationException("El lector tiene una solicitud vigente. Aprueba y entrega el carrito desde Solicitudes, o cancela la solicitud primero.")
        If capacidad <= 0 Then Throw New InvalidOperationException("No hay disponibilidad libre de reservas para ventanilla.")
    End Sub

    Public Sub ValidarNuevaSolicitud(solicitudesVigentes As Integer) Implements IReglasCirculacion.ValidarNuevaSolicitud
        If solicitudesVigentes > 0 Then Throw New InvalidOperationException("Ya tienes una solicitud vigente. Cancélala o espera su atención antes de crear otra.")
    End Sub

    Public Sub ValidarDisponibilidad(capacidad As Integer) Implements IReglasCirculacion.ValidarDisponibilidad
        If capacidad <= 0 Then Throw New InvalidOperationException("Uno de los libros ya no tiene ejemplares libres: pueden estar prestados o reservados por otro lector. Actualiza el catálogo; no se registró ninguna reserva del carrito.")
    End Sub

    Public Sub ValidarCoberturaReserva(activo As Boolean, libres As Integer, reservas As Integer) Implements IReglasCirculacion.ValidarCoberturaReserva
        If Not activo OrElse libres < reservas Then Throw New InvalidOperationException("Revisa los ejemplares: no se puede garantizar toda la reserva.")
    End Sub

    Public Sub ValidarTitularSolicitud(lector As Integer, operador As Integer, personal As Boolean) Implements IReglasCirculacion.ValidarTitularSolicitud
        If Not personal AndAlso lector <> operador Then Throw New UnauthorizedAccessException("Solo el titular puede cancelar su solicitud.")
    End Sub

    Public Sub ValidarEntregaCompleta(libros As IList(Of Integer), seleccion As IDictionary(Of Integer, Integer)) Implements IReglasCirculacion.ValidarEntregaCompleta
        If libros.Count = 0 Then Throw New InvalidOperationException("La solicitud no contiene libros.")
        If libros.Count <> seleccion.Count OrElse libros.Any(Function(id) Not seleccion.ContainsKey(id)) Then Throw New ArgumentException("La entrega debe incluir todos los libros de la solicitud.")
    End Sub

    Public Sub ValidarSolicitudParaEntrega(solicitud As SolicitudPrestamo, ahoraUtc As Date) Implements IReglasCirculacion.ValidarSolicitudParaEntrega
        If solicitud Is Nothing OrElse solicitud.EstadoSolicitud <> "Aprobada" OrElse solicitud.FechaLimiteRetiro <= ahoraUtc Then Throw New InvalidOperationException("La reserva debe estar aprobada y vigente para entregarse.")
    End Sub

    Public Function CalcularDevolucion(datos As DatosDevolucion) As DevolucionCalculada Implements IReglasCirculacion.CalcularDevolucion
        Dim prestamo = datos.Prestamo
        If prestamo Is Nothing Then Throw New InvalidOperationException("El préstamo no existe.")
        If prestamo.FechaRetorno.HasValue OrElse String.Equals(prestamo.EstadoPrestamo.Trim(), Prestamo.EstadoDevuelto, StringComparison.OrdinalIgnoreCase) Then Throw New InvalidOperationException("Este préstamo ya fue devuelto.")
        If Not String.Equals(prestamo.EstadoPrestamo.Trim(), Prestamo.EstadoActivo, StringComparison.OrdinalIgnoreCase) Then Throw New InvalidOperationException("El préstamo tiene un estado no reconocido. Revisa el registro antes de devolverlo.")
        Dim calculo As New DevolucionCalculada With {.IdPrestamo = prestamo.IdPrestamo, .FechaRetorno = datos.FechaRetorno.Date,
            .DiasRetraso = prestamoNegocio.CalcularDiasRetraso(prestamo.FechaInicio, prestamo.FechaFin, datos.FechaRetorno, Date.Today)}
        If calculo.DiasRetraso = 0 Then Return calculo
        If datos.CargoAnterior IsNot Nothing Then
            calculo.IdPenalizacion = datos.CargoAnterior.IdPenalizacion
            calculo.Monto = datos.CargoAnterior.Monto
            calculo.Motivo = datos.CargoAnterior.Motivo
            calculo.YaRegistrada = True
            Return calculo
        End If
        Dim tipo = penalizacionNegocio.ElegirTramo(datos.Tramos, calculo.DiasRetraso)
        If tipo Is Nothing Then Throw New InvalidOperationException("No existe un tramo de mora activo para este retraso. Configúralo en Penalizaciones antes de devolver.")
        calculo.IdPenalizacion = tipo.IdPenalizacion
        calculo.Monto = tipo.MontoPenalizacion
        calculo.Motivo = $"Devolución con {calculo.DiasRetraso} día(s) de retraso. {tipo.TipoPenalizacion}, desde {tipo.DiasDesde} día(s). Importe fijo S/ {tipo.MontoPenalizacion:0.00}."
        calculo.RegistrarCargo = True
        Return calculo
    End Function

    Public Sub ValidarConfirmacion(actual As DevolucionCalculada, confirmado As DevolucionCalculada) Implements IReglasCirculacion.ValidarConfirmacion
        If confirmado Is Nothing OrElse confirmado.IdPrestamo <> actual.IdPrestamo OrElse confirmado.FechaRetorno <> actual.FechaRetorno OrElse
            confirmado.DiasRetraso <> actual.DiasRetraso OrElse Not Nullable.Equals(confirmado.IdPenalizacion, actual.IdPenalizacion) OrElse
            confirmado.Monto <> actual.Monto OrElse confirmado.YaRegistrada <> actual.YaRegistrada Then
            Throw New InvalidOperationException("La devolución o tarifa cambió. Actualiza el cálculo y vuelve a confirmarlo.")
        End If
    End Sub
End Class
