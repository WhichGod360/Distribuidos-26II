Imports capaDatos

Public NotInheritable Class seguridadNegocio
    Private Sub New()
    End Sub

    Public Shared Function EsRolLector(rol As String) As Boolean
        Return {"ESTUDIANTE", "LECTOR"}.Contains(If(rol, "").Trim().ToUpperInvariant())
    End Function

    Public Shared Function EsRolPersonal(rol As String) As Boolean
        Return {"ADMINISTRADOR", "BIBLIOTECARIO"}.Contains(If(rol, "").Trim().ToUpperInvariant())
    End Function

    Public Shared Function PuedeOperar(id As Integer, rol As String) As Boolean
        Return id > 0 AndAlso EsRolPersonal(rol)
    End Function

    Public Shared Function PuedeGestionarUsuarios(id As Integer, rol As String) As Boolean
        Return id > 0 AndAlso String.Equals(If(rol, "").Trim(), "Administrador", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Shared Sub ExigirSesion(id As Integer)
        If SesionUsuario.IdUsuario <> id Then Throw New UnauthorizedAccessException("La ventana no corresponde a la sesión actual.")
    End Sub

    Public Shared Function ExigirPersonal() As Integer
        Try
            Return ExigirRoles("Administrador", "Bibliotecario")
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudieron verificar los permisos de la cuenta.", ex)
        End Try
    End Function

    Public Shared Function ExigirAdministrador() As Integer
        Try
            Return ExigirRoles("Administrador")
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudieron verificar los permisos de la cuenta.", ex)
        End Try
    End Function

    Public Shared Function ExigirLector() As Integer
        Try
            Return ExigirRoles("Estudiante", "Lector")
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudieron verificar los permisos de la cuenta.", ex)
        End Try
    End Function

    Private Shared Function ExigirRoles(ParamArray roles As String()) As Integer
        Try
            Dim id = SesionUsuario.IdUsuario
            If id <= 0 Then Throw New UnauthorizedAccessException("Inicia sesión para realizar esta operación.")
            Dim rol = New seguridadDAO().ObtenerRolActivo(id)
            If rol Is Nothing OrElse Not roles.Any(Function(r) String.Equals(r, rol.Trim(), StringComparison.OrdinalIgnoreCase)) Then
                Throw New UnauthorizedAccessException("Tu cuenta no tiene permiso para realizar esta operación.")
            End If
            Return id
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudieron verificar los permisos de la cuenta.", ex)
        End Try
    End Function

    Public Shared Sub ExigirAccesoLector(idLector As Integer)
        Try
            If idLector <= 0 Then Throw New ArgumentException("Selecciona un lector.")
            If PuedeOperar(SesionUsuario.IdUsuario, SesionUsuario.Rol) Then
                ExigirPersonal()
            ElseIf ExigirLector() <> idLector Then
                Throw New UnauthorizedAccessException("Solo puedes consultar tus propios datos.")
            End If
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudieron verificar los permisos de la cuenta.", ex)
        End Try
    End Sub

    Public Shared Sub ExigirOperador(idOperador As Integer)
        Try
            If ExigirPersonal() <> idOperador Then Throw New UnauthorizedAccessException("El operador debe ser la cuenta de la sesión actual.")
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudieron verificar los permisos de la cuenta.", ex)
        End Try
    End Sub
End Class
