Imports capaDatos

Public NotInheritable Class reglasPenalizacionNegocio
    Implements IReglasPenalizacion

    Public Sub ValidarPersonal(usuario As Usuario) Implements IReglasPenalizacion.ValidarPersonal
        Dim reglas As New reglasCirculacionNegocio()
        reglas.ValidarUsuario(usuario, "BIBLIOTECARIO", "Se requiere personal activo.")
    End Sub

    Public Sub ValidarCambioTramo(anterior As Integer?, nuevo As Integer?, cargos As Integer) Implements IReglasPenalizacion.ValidarCambioTramo
        If Not Nullable.Equals(anterior, nuevo) AndAlso cargos > 0 Then Throw New InvalidOperationException("Este tipo ya tiene cargos. Conserva su tramo; puedes desactivarlo y crear otro.")
    End Sub

    Public Sub ValidarCargo(tipo As Penalizacion, prestamo As Prestamo, tramos As IList(Of Penalizacion), cargos As IList(Of Penalizacion)) Implements IReglasPenalizacion.ValidarCargo
        If prestamo Is Nothing Then Throw New InvalidOperationException("El préstamo no existe.")
        If tipo Is Nothing Then Throw New InvalidOperationException("El tipo de penalización no existe.")
        If Not tipo.EstadoPenalizacion Then Throw New InvalidOperationException("No puedes aplicar un tipo inactivo.")
        If tipo.DiasDesde.HasValue Then
            If Not prestamo.FechaRetorno.HasValue OrElse prestamo.DiasRetraso < 1 Then Throw New InvalidOperationException("La mora se registra al confirmar una devolución con retraso.")
            Dim tramo = penalizacionNegocio.ElegirTramo(tramos, prestamo.DiasRetraso)
            If tramo Is Nothing OrElse tramo.IdPenalizacion <> tipo.IdPenalizacion Then Throw New InvalidOperationException("El tipo no corresponde al tramo de retraso de esta devolución.")
        End If
        If cargos.Any(Function(c) c.IdPenalizacion = tipo.IdPenalizacion OrElse (tipo.DiasDesde.HasValue AndAlso c.DiasDesde.HasValue)) Then Throw New InvalidOperationException("Ya existe ese cargo para este préstamo. Edita su motivo o estado de pago.")
    End Sub
End Class
