Imports capaDatos

Public NotInheritable Class reglasUsuarioNegocio
    Implements IReglasUsuario

    Public Sub ValidarAdministrador(usuario As Usuario) Implements IReglasUsuario.ValidarAdministrador
        If usuario Is Nothing OrElse Not String.Equals(usuario.EstadoUsuario.Trim(), "Activo", StringComparison.OrdinalIgnoreCase) OrElse
            Not String.Equals(usuario.NombreRol.Trim(), "Administrador", StringComparison.OrdinalIgnoreCase) Then Throw New UnauthorizedAccessException("Solo un administrador activo puede gestionar usuarios.")
    End Sub

    Public Sub ValidarRol(rol As String) Implements IReglasUsuario.ValidarRol
        If Not {"ADMINISTRADOR", "BIBLIOTECARIO", "ESTUDIANTE", "LECTOR"}.Contains(If(rol, "").Trim().ToUpperInvariant()) Then Throw New ArgumentException("Selecciona un rol válido.")
    End Sub

    Public Sub ValidarCambio(datos As DatosCambioUsuario) Implements IReglasUsuario.ValidarCambio
        ValidarRol(datos.NuevoRol)
        If datos.Actual Is Nothing Then Throw New InvalidOperationException("El usuario ya no existe.")
        Dim nuevoRol = datos.NuevoRol.Trim().ToUpperInvariant()
        Dim rolActual = datos.Actual.NombreRol.Trim().ToUpperInvariant()
        Dim estadoActual = datos.Actual.EstadoUsuario.Trim().ToUpperInvariant()
        If datos.IdAdministrador = datos.Actual.IdUsuario AndAlso (nuevoRol <> "ADMINISTRADOR" OrElse datos.NuevoEstado <> "Activo") Then Throw New InvalidOperationException("No puedes desactivar tu propia cuenta ni quitarte el rol de administrador.")
        If rolActual = "ADMINISTRADOR" AndAlso estadoActual = "ACTIVO" AndAlso (nuevoRol <> "ADMINISTRADOR" OrElse datos.NuevoEstado <> "Activo") AndAlso datos.AdministradoresActivos <= 1 Then Throw New InvalidOperationException("Debe quedar al menos un administrador activo.")
        If {"ESTUDIANTE", "LECTOR"}.Contains(rolActual) AndAlso Not {"ESTUDIANTE", "LECTOR"}.Contains(nuevoRol) AndAlso datos.MovimientosPendientes > 0 Then Throw New InvalidOperationException("El lector debe devolver sus libros y cerrar sus reservas antes de cambiar a un rol de personal.")
    End Sub
End Class
