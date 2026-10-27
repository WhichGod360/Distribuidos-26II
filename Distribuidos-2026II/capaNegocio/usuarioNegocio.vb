Imports capaDatos
Imports System.Net.Mail
Imports System.Security.Cryptography

Public Class usuarioNegocio

    ' Instancia del DAO para comunicarse con la base de datos
    Private ReadOnly usuarioDao As New usuarioDAO()
    Private ReadOnly bitacora As New bitacoraNegocio()
    Private ReadOnly reglas As IReglasUsuario = New reglasUsuarioNegocio()
    Private Shared ReadOnly autorizaciones As New Dictionary(Of String, AutorizacionRecuperacion)()

    Private Class AutorizacionRecuperacion
        Public Property Identidad As Usuario
        Public Property Vence As Date
    End Class

    Public Sub PrepararSeguridad()
        Try
            For Each anterior In usuarioDao.LeerRespuestasAnteriores()
                If Not PasswordHasher.IsHash(anterior.Value) Then usuarioDao.MigrarRespuesta(anterior.Key, anterior.Value, RespuestaSeguridadHasher.Hash(anterior.Value))
            Next
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al preparar la seguridad de las cuentas.", ex)
        End Try
    End Sub

    Public Function IniciarSesion(email As String, contrasena As String) As Usuario
        Try
            SesionUsuario.Cerrar()
            PrepararSeguridad()

            ' 1. Validaciones previas de formato y campos vacíos
            If String.IsNullOrWhiteSpace(email) Then
                Throw New ArgumentException("Debe ingresar su correo electrónico.")
            End If

            If String.IsNullOrWhiteSpace(contrasena) Then
                Throw New ArgumentException("Debe ingresar su contraseña.")
            End If

            Dim usuarioLogueado As Usuario = usuarioDao.ObtenerCredenciales(email.Trim())
            If usuarioLogueado IsNot Nothing Then
                Dim anterior = usuarioLogueado.Contrasena
                If PasswordHasher.IsHash(anterior) Then
                    If Not PasswordHasher.Verify(contrasena, anterior) Then usuarioLogueado = Nothing
                ElseIf Not PasswordHasher.VerifyLegacy(contrasena, anterior) OrElse
                    Not usuarioDao.MigrarContrasena(usuarioLogueado.IdUsuario, anterior, PasswordHasher.Hash(contrasena)) Then
                    usuarioLogueado = Nothing
                End If
            End If

            ' La interfaz presenta el aviso cuando las credenciales no son validas.
            If usuarioLogueado Is Nothing Then
                Return Nothing
            End If

            reglas.ValidarRol(usuarioLogueado.NombreRol)
            usuarioLogueado.Contrasena = Nothing
            SesionUsuario.Iniciar(usuarioLogueado)
            Return usuarioLogueado
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error inesperado al iniciar sesión.", ex)
        End Try
    End Function

    Public Function ObtenerPregunta(email As String) As String
        Try
            If String.IsNullOrWhiteSpace(email) Then
                Throw New ArgumentException("Debe ingresar un correo electrónico.")
            End If

            PrepararSeguridad()
            Dim pregunta As String = usuarioDao.ObtenerPreguntaSeguridad(email.Trim())
            If String.IsNullOrEmpty(pregunta) Then
                Throw New InvalidOperationException("El correo ingresado no existe o no tiene una cuenta activa.")
            End If

            Return pregunta
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al obtener la pregunta de seguridad.", ex)
        End Try
    End Function

    Public Function ValidarRespuesta(email As String, respuesta As String) As String
        Try
            If String.IsNullOrWhiteSpace(email) OrElse email.Trim().Length > 100 Then Throw New ArgumentException("Ingresa un correo válido.")
            If String.IsNullOrWhiteSpace(respuesta) Then
                Throw New ArgumentException("Por favor, ingrese su respuesta de seguridad.")
            End If

            PrepararSeguridad()
            Dim identidad As Usuario = usuarioDao.ObtenerIdentidadRecuperacion(email.Trim())
            If identidad Is Nothing OrElse Not RespuestaSeguridadHasher.Verify(respuesta, identidad.RptaSegura) Then
                Throw New InvalidOperationException("La respuesta ingresada es incorrecta.")
            End If

            Dim autorizacion As String = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32))
            SyncLock autorizaciones
                For Each anterior In autorizaciones.Where(Function(a) a.Value.Vence <= Date.UtcNow OrElse
                    String.Equals(a.Value.Identidad.EmailUsuario, identidad.EmailUsuario, StringComparison.OrdinalIgnoreCase)).Select(Function(a) a.Key).ToArray()
                    autorizaciones.Remove(anterior)
                Next
                autorizaciones.Add(autorizacion, New AutorizacionRecuperacion With {.Identidad = identidad, .Vence = Date.UtcNow.AddMinutes(5)})
            End SyncLock
            Return autorizacion
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al validar la respuesta.", ex)
        End Try
    End Function

    Public Sub CambiarContrasena(email As String, nuevaClave As String, confirmarClave As String, autorizacion As String)
        Try
            If String.IsNullOrWhiteSpace(nuevaClave) OrElse String.IsNullOrWhiteSpace(confirmarClave) Then
                Throw New ArgumentException("Debe completar ambos campos de contraseña.")
            End If

            If nuevaClave <> confirmarClave Then
                Throw New ArgumentException("Las contraseñas no coinciden.")
            End If

            If nuevaClave.Length < 8 OrElse Not nuevaClave.Any(AddressOf Char.IsUpper) OrElse Not nuevaClave.Any(AddressOf Char.IsDigit) Then
                Throw New ArgumentException("La contraseña no cumple con los requisitos mínimos de seguridad.")
            End If

            ValidarClave(nuevaClave, confirmarClave)
            Dim validada As AutorizacionRecuperacion = Nothing
            SyncLock autorizaciones
                If String.IsNullOrEmpty(autorizacion) OrElse Not autorizaciones.TryGetValue(autorizacion, validada) Then
                    Throw New UnauthorizedAccessException("Valida primero tu respuesta de seguridad para cambiar la contraseña.")
                End If
                If validada.Vence <= Date.UtcNow OrElse Not String.Equals(validada.Identidad.EmailUsuario, If(email, "").Trim(), StringComparison.OrdinalIgnoreCase) Then
                    autorizaciones.Remove(autorizacion)
                    Throw New UnauthorizedAccessException("La verificación venció o no corresponde a esta cuenta. Inicia nuevamente la recuperación.")
                End If
                autorizaciones.Remove(autorizacion)
            End SyncLock
            Dim identidad As Usuario = validada.Identidad
            Dim actualizado As Boolean = usuarioDao.ActualizarContrasena(identidad.IdUsuario, identidad.EmailUsuario, PasswordHasher.Hash(nuevaClave), identidad.RptaSegura, identidad.Contrasena)
            If Not actualizado Then
                Throw New InvalidOperationException("La cuenta cambió después de la verificación. Inicia nuevamente la recuperación.")
            End If
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al cambiar la contraseña.", ex)
        End Try
    End Sub

    Public Sub RegistrarNuevoLector(nuevoUsuario As Usuario, confirmacionClave As String)
        Try
            ValidarDatos(nuevoUsuario, False)
            ValidarAlta(nuevoUsuario, confirmacionClave)
            PrepararSeguridad()

            If String.IsNullOrWhiteSpace(nuevoUsuario.NumeroDniUsuario) OrElse nuevoUsuario.NumeroDniUsuario.Trim().Length <> 8 OrElse Not IsNumeric(nuevoUsuario.NumeroDniUsuario) Then
                Throw New ArgumentException("El DNI debe contener exactamente 8 dígitos numéricos.")
            End If

            If String.IsNullOrWhiteSpace(nuevoUsuario.NombreUsuario) Then
                Throw New ArgumentException("Debe ingresar los nombres.")
            End If

            If String.IsNullOrWhiteSpace(nuevoUsuario.ApPaterno) Then
                Throw New ArgumentException("Debe ingresar el apellido paterno.")
            End If

            If String.IsNullOrWhiteSpace(nuevoUsuario.ApMaterno) Then
                Throw New ArgumentException("Debe ingresar el apellido materno.")
            End If

            If Not nuevoUsuario.GeneroUsuario.HasValue Then
                Throw New ArgumentException("Debe seleccionar un género.")
            End If

            If String.IsNullOrWhiteSpace(nuevoUsuario.EmailUsuario) Then
                Throw New ArgumentException("Debe ingresar un correo electrónico.")
            End If

            If usuarioDao.ExisteDNI(nuevoUsuario.NumeroDniUsuario.Trim()) Then
                Throw New InvalidOperationException("El número de DNI ingresado ya se encuentra registrado.")
            End If

            If usuarioDao.ExisteEmail(nuevoUsuario.EmailUsuario.Trim()) Then
                Throw New InvalidOperationException("El correo electrónico ingresado ya se encuentra registrado.")
            End If

            If String.IsNullOrWhiteSpace(nuevoUsuario.Contrasena) OrElse String.IsNullOrWhiteSpace(confirmacionClave) Then
                Throw New ArgumentException("Debe ingresar y confirmar su contraseña.")
            End If

            If nuevoUsuario.Contrasena <> confirmacionClave Then
                Throw New ArgumentException("Las contraseñas no coinciden.")
            End If

            If nuevoUsuario.Contrasena.Length < 8 OrElse Not nuevoUsuario.Contrasena.Any(AddressOf Char.IsUpper) OrElse Not nuevoUsuario.Contrasena.Any(AddressOf Char.IsDigit) Then
                Throw New ArgumentException("La contraseña no cumple con los requisitos mínimos de seguridad.")
            End If

            If String.IsNullOrWhiteSpace(nuevoUsuario.PreguntaSegura) Then
                Throw New ArgumentException("Debe escribir una pregunta de seguridad.")
            End If

            If String.IsNullOrWhiteSpace(nuevoUsuario.RptaSegura) Then
                Throw New ArgumentException("Debe ingresar la respuesta a su pregunta de seguridad.")
            End If

            Dim guardado As Boolean = usuarioDao.RegistrarLector(nuevoUsuario, PasswordHasher.Hash(nuevoUsuario.Contrasena), RespuestaSeguridadHasher.Hash(nuevoUsuario.RptaSegura))
            If Not guardado Then
                Throw New InvalidOperationException("No se pudo completar el registro del usuario.")
            End If
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al registrar el nuevo lector.", ex)
        End Try
    End Sub

    Public Sub CancelarRecuperacion(autorizacion As String)
        If String.IsNullOrEmpty(autorizacion) Then Return
        SyncLock autorizaciones
            autorizaciones.Remove(autorizacion)
        End SyncLock
    End Sub

    Public Function ListarUsuarios(Optional texto As String = "", Optional idRol As Integer = 0, Optional estado As String = "Todos") As List(Of Usuario)
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            If Not {"Todos", "Activo", "Inactivo"}.Contains(estado) Then Throw New ArgumentException("Selecciona un estado válido.")
            If idRol < 0 Then Throw New ArgumentException("Selecciona un rol válido.")
            Dim criterio As String = If(texto, "").Trim()
            Dim accion As String = If(criterio.Length = 0 AndAlso idRol = 0 AndAlso estado = "Todos", "LISTADO", "BUSQUEDA")
            Return usuarioDao.ListarUsuarios(criterio, idRol, estado, bitacora.CrearContexto("Usuario", accion, administrador))
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al listar los usuarios.", ex)
        End Try
    End Function

    Public Function ObtenerUsuario(idUsuario As Integer) As Usuario
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            If idUsuario <= 0 Then Throw New ArgumentException("Selecciona un usuario.")
            Dim usuario As Usuario = usuarioDao.ObtenerUsuario(idUsuario, bitacora.CrearContexto("Usuario", "BUSQUEDA", administrador))
            If usuario Is Nothing Then Throw New InvalidOperationException("El usuario ya no existe.")
            Return usuario
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al obtener el usuario.", ex)
        End Try
    End Function

    Public Function ListarRoles() As List(Of RolUsuario)
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            Return usuarioDao.ListarRoles(bitacora.CrearContexto("Usuario", "LISTADO", administrador))
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al listar los roles.", ex)
        End Try
    End Function

    Public Sub CrearUsuario(usuario As Usuario, confirmacionClave As String)
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            ValidarDatos(usuario, True)
            ValidarAlta(usuario, confirmacionClave)
            PrepararSeguridad()
            Try
                If Not usuarioDao.CrearUsuario(usuario, administrador, PasswordHasher.Hash(usuario.Contrasena), RespuestaSeguridadHasher.Hash(usuario.RptaSegura), reglas,
                                              bitacora.CrearContexto("Usuario", "INSERT", administrador)) Then Throw New InvalidOperationException("No se pudo crear el usuario.")
            Catch ex As AccesoDatosException When ex.NumeroSql = 2601 OrElse ex.NumeroSql = 2627
                Throw New ArgumentException("El correo o DNI ya está registrado.", ex)
            End Try
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al crear el usuario.", ex)
        End Try
    End Sub

    Public Sub ActualizarUsuario(usuario As Usuario)
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            ValidarDatos(usuario, True)
            If usuario.IdUsuario <= 0 Then Throw New ArgumentException("Selecciona un usuario válido.")
            Try
                If Not usuarioDao.ActualizarUsuario(usuario, administrador, reglas,
                                                   bitacora.CrearContexto("Usuario", "UPDATE", administrador)) Then Throw New InvalidOperationException("No se pudo actualizar el usuario.")
            Catch ex As AccesoDatosException When ex.NumeroSql = 2601 OrElse ex.NumeroSql = 2627
                Throw New ArgumentException("El correo o DNI pertenece a otra cuenta.", ex)
            End Try
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al actualizar el usuario.", ex)
        End Try
    End Sub

    Public Sub CambiarEstadoUsuario(idUsuario As Integer, estado As String)
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            If idUsuario <= 0 Then Throw New ArgumentException("Selecciona un usuario.")
            If Not {"Activo", "Inactivo"}.Contains(estado) Then Throw New ArgumentException("Selecciona Activo o Inactivo.")
            If Not usuarioDao.CambiarEstadoUsuario(idUsuario, estado, administrador, reglas,
                                                  bitacora.CrearContexto("Usuario", "UPDATE", administrador)) Then Throw New InvalidOperationException("No se pudo cambiar el estado.")
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al cambiar el estado del usuario.", ex)
        End Try
    End Sub

    Private Shared Sub ValidarDatos(usuario As Usuario, requiereRol As Boolean)
        If usuario Is Nothing Then Throw New ArgumentException("Completa los datos del usuario.")
        For Each campo In New KeyValuePair(Of String, String)() {
            New KeyValuePair(Of String, String)("nombres", usuario.NombreUsuario),
            New KeyValuePair(Of String, String)("apellido paterno", usuario.ApPaterno),
            New KeyValuePair(Of String, String)("apellido materno", usuario.ApMaterno)}
            If String.IsNullOrWhiteSpace(campo.Value) OrElse campo.Value.Trim().Length > 100 Then Throw New ArgumentException("Ingresa " & campo.Key & " (máximo 100 caracteres).")
        Next
        Dim dni As String = If(usuario.NumeroDniUsuario, "").Trim()
        If dni.Length <> 8 OrElse dni.Any(Function(c) c < "0"c OrElse c > "9"c) Then Throw New ArgumentException("El DNI debe contener exactamente ocho dígitos.")
        Dim email As String = If(usuario.EmailUsuario, "").Trim()
        If email.Length = 0 OrElse email.Length > 100 Then Throw New ArgumentException("Ingresa un correo válido (máximo 100 caracteres).")
        Try
            If New MailAddress(email).Address <> email Then Throw New FormatException()
        Catch ex As FormatException
            Throw New ArgumentException("El formato del correo electrónico no es válido.")
        End Try
        If usuario.FechaNacimientoUsuario.HasValue AndAlso usuario.FechaNacimientoUsuario.Value.Date > Date.Today Then Throw New ArgumentException("La fecha de nacimiento no puede ser futura.")
        If requiereRol Then
            If usuario.IdRolUsuario <= 0 Then Throw New ArgumentException("Selecciona un rol.")
            If Not {"Activo", "Inactivo"}.Contains(usuario.EstadoUsuario) Then Throw New ArgumentException("Selecciona Activo o Inactivo.")
        End If
    End Sub

    Private Shared Sub ValidarAlta(usuario As Usuario, confirmacion As String)
        ValidarClave(usuario.Contrasena, confirmacion)
        If String.IsNullOrWhiteSpace(usuario.PreguntaSegura) OrElse usuario.PreguntaSegura.Trim().Length > 255 Then Throw New ArgumentException("Ingresa la pregunta de seguridad (máximo 255 caracteres).")
        If String.IsNullOrWhiteSpace(usuario.RptaSegura) OrElse usuario.RptaSegura.Trim().Length > 200 Then Throw New ArgumentException("Ingresa la respuesta de seguridad (máximo 200 caracteres).")
    End Sub

    Public Shared Function EvaluarClave(clave As String) As RequisitosClave
        Dim texto = If(clave, "")
        Return New RequisitosClave With {.LongitudValida = texto.Length >= 8 AndAlso texto.Length <= 128,
            .TieneMayuscula = texto.Any(AddressOf Char.IsUpper), .TieneNumero = texto.Any(AddressOf Char.IsDigit)}
    End Function

    Private Shared Sub ValidarClave(clave As String, confirmacion As String)
        If String.IsNullOrWhiteSpace(clave) OrElse clave <> confirmacion Then Throw New ArgumentException("Ingresa y confirma la misma contraseña.")
        Dim requisitos = EvaluarClave(clave)
        If Not requisitos.LongitudValida OrElse Not requisitos.TieneMayuscula OrElse Not requisitos.TieneNumero Then
            Throw New ArgumentException("La contraseña debe tener entre 8 y 128 caracteres, una mayúscula y un número.")
        End If
    End Sub
End Class
