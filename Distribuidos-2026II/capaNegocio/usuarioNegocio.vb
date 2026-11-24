Imports capaDatos
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography

Public Class usuarioNegocio

    ' Instancia del DAO para comunicarse con la base de datos
    Private ReadOnly usuarioDao As New usuarioDAO()
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
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al preparar la seguridad de las cuentas.", ex)
        End Try
    End Sub

    Public Function IniciarSesion(email As String, contrasena As String) As Usuario
        Try
            SesionUsuario.Cerrar()

            ValidarCorreo(email)

            If String.IsNullOrWhiteSpace(contrasena) Then
                Throw New ArgumentException("Debe ingresar su contraseña.")
            End If

            PrepararSeguridad()
            Dim usuarioLogueado As Usuario = usuarioDao.ObtenerCredenciales(email.Trim())
            If usuarioLogueado IsNot Nothing Then
                Dim anterior = usuarioLogueado.Contrasena
                Dim esHash = PasswordHasher.IsHash(anterior)
                Dim valida = If(esHash, PasswordHasher.Verify(contrasena, anterior), PasswordHasher.VerifyLegacy(contrasena, anterior))
                If Not valida Then
                    usuarioLogueado = Nothing
                ElseIf Not EstaActivo(usuarioLogueado) Then
                    AuditoriaDAO.RegistrarEvento(usuarioLogueado.IdUsuario, "Acceso", "SELECT", "Inicio de sesión denegado | cuenta inactiva")
                    Throw New InvalidOperationException(MensajeCuentaInactiva(usuarioLogueado))
                ElseIf Not esHash AndAlso Not usuarioDao.MigrarContrasena(usuarioLogueado.IdUsuario, anterior, PasswordHasher.Hash(contrasena)) Then
                    usuarioLogueado = Nothing
                End If
            End If

            If usuarioLogueado Is Nothing Then
                AuditoriaDAO.RegistrarEvento(0, "Acceso", "SELECT", "Inicio de sesión denegado")
                Return Nothing
            End If

            reglas.ValidarRol(usuarioLogueado.NombreRol)
            usuarioLogueado.Contrasena = Nothing
            AuditoriaDAO.RegistrarEvento(usuarioLogueado.IdUsuario, "Acceso", "SELECT", "Inicio de sesión aceptado")
            SesionUsuario.Iniciar(usuarioLogueado)
            Return usuarioLogueado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error inesperado al iniciar sesión.", ex)
        End Try
    End Function

    Public Function ObtenerPregunta(email As String) As String
        Try
            ValidarCorreo(email)

            PrepararSeguridad()
            Dim pregunta As String = usuarioDao.ObtenerPreguntaSeguridad(email.Trim())
            If String.IsNullOrEmpty(pregunta) Then
                Throw New InvalidOperationException("El correo ingresado no existe o no tiene una cuenta activa.")
            End If

            Return pregunta
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al obtener la pregunta de seguridad.", ex)
        End Try
    End Function

    Public Function ValidarRespuesta(email As String, respuesta As String) As String
        Try
            ValidarCorreo(email)
            If String.IsNullOrWhiteSpace(respuesta) Then
                Throw New ArgumentException("Por favor, ingrese su respuesta de seguridad.")
            End If

            PrepararSeguridad()
            Dim identidad As Usuario = usuarioDao.ObtenerIdentidadRecuperacion(email.Trim())
            If identidad Is Nothing OrElse Not RespuestaSeguridadHasher.Verify(respuesta, identidad.RptaSegura) Then
                Throw New InvalidOperationException("La respuesta ingresada es incorrecta.")
            End If

            Dim autorizacion As String = Convert.ToBase64String(PasswordHasher.NewRandomBytes(32))
            SyncLock autorizaciones
                For Each anterior In autorizaciones.Where(Function(a) a.Value.Vence <= Date.UtcNow OrElse
                    String.Equals(a.Value.Identidad.EmailUsuario, identidad.EmailUsuario, StringComparison.OrdinalIgnoreCase)).Select(Function(a) a.Key).ToArray()
                    autorizaciones.Remove(anterior)
                Next
                autorizaciones.Add(autorizacion, New AutorizacionRecuperacion With {.Identidad = identidad, .Vence = Date.UtcNow.AddMinutes(5)})
            End SyncLock
            Return autorizacion
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al validar la respuesta.", ex)
        End Try
    End Function

    Public Sub CambiarContrasena(email As String, nuevaClave As String, confirmarClave As String, autorizacion As String)
        Try
            ValidarCorreo(email)
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
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al cambiar la contraseña.", ex)
        End Try
    End Sub

    Public Sub RegistrarNuevoLector(nuevoUsuario As Usuario, confirmacionClave As String)
        Try
            ValidarDatos(nuevoUsuario, False)
            ValidarAlta(nuevoUsuario, confirmacionClave)
            If Not nuevoUsuario.GeneroUsuario.HasValue Then
                Throw New ArgumentException("Debe seleccionar un género.")
            End If

            PrepararSeguridad()
            If usuarioDao.ExisteDNI(nuevoUsuario.NumeroDniUsuario.Trim()) Then
                Throw New InvalidOperationException("El número de DNI ingresado ya se encuentra registrado.")
            End If

            If usuarioDao.ExisteEmail(nuevoUsuario.EmailUsuario.Trim()) Then
                Throw New InvalidOperationException("El correo electrónico ingresado ya se encuentra registrado.")
            End If

            Dim guardado As Boolean = usuarioDao.RegistrarLector(nuevoUsuario, PasswordHasher.Hash(nuevoUsuario.Contrasena), RespuestaSeguridadHasher.Hash(nuevoUsuario.RptaSegura))
            If Not guardado Then
                Throw New InvalidOperationException("No se pudo completar el registro del usuario.")
            End If
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
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
            seguridadNegocio.ExigirAdministrador()
            If Not {"Todos", "Activo", "Inactivo"}.Contains(estado) Then Throw New ArgumentException("Selecciona un estado válido.")
            If idRol < 0 Then Throw New ArgumentException("Selecciona un rol válido.")
            Return usuarioDao.ListarUsuarios(If(texto, "").Trim(), idRol, estado)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al listar los usuarios.", ex)
        End Try
    End Function

    Public Function ObtenerUsuario(idUsuario As Integer) As Usuario
        Try
            seguridadNegocio.ExigirAdministrador()
            If idUsuario <= 0 Then Throw New ArgumentException("Selecciona un usuario.")
            Dim usuario As Usuario = usuarioDao.ObtenerUsuario(idUsuario)
            If usuario Is Nothing Then Throw New InvalidOperationException("El usuario ya no existe.")
            Return usuario
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al obtener el usuario.", ex)
        End Try
    End Function

    Public Function ListarRoles() As List(Of RolUsuario)
        Try
            seguridadNegocio.ExigirAdministrador()
            Return usuarioDao.ListarRoles()
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al listar los roles.", ex)
        End Try
    End Function

    Public Sub CrearUsuario(usuario As Usuario, confirmacionClave As String)
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            ValidarDatos(usuario, True)
            ValidarAlta(usuario, confirmacionClave)
            PrepararSeguridad()
            Dim claveHash = PasswordHasher.Hash(usuario.Contrasena)
            Dim respuestaHash = RespuestaSeguridadHasher.Hash(usuario.RptaSegura)
            If Not usuarioDao.CrearUsuario(usuario, administrador, claveHash, respuestaHash, reglas) Then
                Throw New InvalidOperationException("No se pudo crear el usuario.")
            End If
        Catch ex As Exception
            If EsDuplicado(ex) Then Throw New ArgumentException("El correo o DNI ya está registrado.", ex)
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al crear el usuario.", ex)
        End Try
    End Sub

    Public Sub ActualizarUsuario(usuario As Usuario)
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            ValidarDatos(usuario, True)
            If usuario.IdUsuario <= 0 Then Throw New ArgumentException("Selecciona un usuario válido.")
            If Not usuarioDao.ActualizarUsuario(usuario, administrador, reglas) Then Throw New InvalidOperationException("No se pudo actualizar el usuario.")
        Catch ex As Exception
            If EsDuplicado(ex) Then Throw New ArgumentException("El correo o DNI pertenece a otra cuenta.", ex)
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al actualizar el usuario.", ex)
        End Try
    End Sub

    Private Shared Function EsDuplicado(ex As Exception) As Boolean
        Dim errorDatos = TryCast(ex, AccesoDatosException)
        Return errorDatos IsNot Nothing AndAlso (errorDatos.NumeroSql = 2601 OrElse errorDatos.NumeroSql = 2627)
    End Function

    Public Sub CambiarEstadoUsuario(idUsuario As Integer, estado As String)
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            If idUsuario <= 0 Then Throw New ArgumentException("Selecciona un usuario.")
            If Not {"Activo", "Inactivo"}.Contains(estado) Then Throw New ArgumentException("Selecciona Activo o Inactivo.")
            If Not usuarioDao.CambiarEstadoUsuario(idUsuario, estado, administrador, reglas) Then Throw New InvalidOperationException("El usuario ya no existe.")
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al cambiar el estado del usuario.", ex)
        End Try
    End Sub

    Public Function ListarLectoresPendientes(Optional texto As String = "") As List(Of Usuario)
        Try
            seguridadNegocio.ExigirAdministrador()
            Return usuarioDao.ListarLectoresPendientes(If(texto, "").Trim())
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al listar los lectores pendientes.", ex)
        End Try
    End Function

    Public Sub AprobarLector(idUsuario As Integer)
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            If idUsuario <= 0 Then Throw New ArgumentException("Selecciona un lector.")
            If Not usuarioDao.AprobarLector(idUsuario, administrador, reglas) Then Throw New InvalidOperationException("El lector ya no está pendiente de aprobación. Actualiza la lista.")
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al aprobar al lector.", ex)
        End Try
    End Sub

    Public Sub RechazarLector(idUsuario As Integer)
        Try
            Dim administrador As Integer = seguridadNegocio.ExigirAdministrador()
            If idUsuario <= 0 Then Throw New ArgumentException("Selecciona un lector.")
            If Not usuarioDao.RechazarLector(idUsuario, administrador, reglas) Then Throw New InvalidOperationException("El lector ya no está pendiente de aprobación. Actualiza la lista.")
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al rechazar al lector.", ex)
        End Try
    End Sub

    Private Shared Function EstaActivo(usuario As Usuario) As Boolean
        Return String.Equals(If(usuario.EstadoUsuario, "").Trim(), "Activo", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Shared Function MensajeCuentaInactiva(usuario As Usuario) As String
        If seguridadNegocio.EsRolLector(usuario.NombreRol) Then
            Return "Tu cuenta está pendiente de aprobación. Un administrador debe activarla antes de que puedas ingresar. Vuelve a intentarlo más tarde."
        End If
        Return "Tu cuenta está inactiva. Comunícate con un administrador."
    End Function

    Private Shared Sub ValidarDatos(usuario As Usuario, requiereRol As Boolean)
        If usuario Is Nothing Then Throw New ArgumentException("Completa los datos del usuario.")
        For Each campo In New KeyValuePair(Of String, String)() {
            New KeyValuePair(Of String, String)("nombres", usuario.NombreUsuario),
            New KeyValuePair(Of String, String)("apellido paterno", usuario.ApPaterno),
            New KeyValuePair(Of String, String)("apellido materno", usuario.ApMaterno)}
            If String.IsNullOrWhiteSpace(campo.Value) OrElse campo.Value.Trim().Length > 100 Then Throw New ArgumentException("Ingresa " & campo.Key & " (máximo 100 caracteres).")
            If Not Regex.IsMatch(campo.Value.Trim(), "\A(?=.*\p{L})[\p{L}\p{M}\p{Zs}\p{Pd}.'’]+\z") Then
                Throw New ArgumentException("Revisa el campo " & campo.Key & ". Usa letras, espacios, guiones, puntos o apóstrofos.")
            End If
        Next
        Dim dni As String = If(usuario.NumeroDniUsuario, "").Trim()
        If dni.Length <> 8 OrElse dni.Any(Function(c) c < "0"c OrElse c > "9"c) Then Throw New ArgumentException("El DNI debe contener exactamente ocho dígitos.")
        ValidarCorreo(usuario.EmailUsuario)
        If usuario.FechaNacimientoUsuario.HasValue AndAlso usuario.FechaNacimientoUsuario.Value.Date > Date.Today Then Throw New ArgumentException("La fecha de nacimiento no puede ser futura.")
        If requiereRol Then
            If usuario.IdRolUsuario <= 0 Then Throw New ArgumentException("Selecciona un rol.")
            If Not {"Activo", "Inactivo"}.Contains(usuario.EstadoUsuario) Then Throw New ArgumentException("Selecciona Activo o Inactivo.")
        End If
    End Sub

    Private Shared Sub ValidarCorreo(valor As String)
        Dim correo = If(valor, "").Trim()
        If correo.Length = 0 OrElse correo.Length > 100 Then Throw New ArgumentException("Ingresa un correo válido de hasta 100 caracteres.")
        Try
            Dim direccion As New MailAddress(correo)
            If direccion.Address <> correo OrElse correo.Any(AddressOf Char.IsWhiteSpace) OrElse
               Not direccion.Host.Contains(".") OrElse direccion.Host.StartsWith(".") OrElse direccion.Host.EndsWith(".") Then
                Throw New FormatException()
            End If
        Catch ex As FormatException
            Throw New ArgumentException("El formato del correo electrónico no es válido.", ex)
        End Try
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
