Imports capaDatos

Public Class usuarioNegocio

    ' Instancia del DAO para comunicarse con la base de datos
    Private ReadOnly usuarioDao As New usuarioDAO()

    Public Function IniciarSesion(email As String, contrasena As String) As Usuario
        ' 1. Validaciones previas de formato y campos vacíos
        If String.IsNullOrWhiteSpace(email) Then
            Throw New ArgumentException("Debe ingresar su correo electrónico.")
        End If

        If String.IsNullOrWhiteSpace(contrasena) Then
            Throw New ArgumentException("Debe ingresar su contraseña.")
        End If


        Dim usuarioLogueado As Usuario = usuarioDao.Autenticar(email.Trim(), contrasena)

        ' 3. Si no existe o las credenciales son incorrectas
        If usuarioLogueado Is Nothing Then
            Throw New UnauthorizedAccessException("Correo o contraseña incorrectos, o la cuenta está inactiva.")
        End If

        Return usuarioLogueado
    End Function

    Public Function ObtenerPregunta(email As String) As String
        If String.IsNullOrWhiteSpace(email) Then
            Throw New ArgumentException("Debe ingresar un correo electrónico.")
        End If

        Dim pregunta As String = usuarioDao.ObtenerPreguntaSeguridad(email.Trim())
        If String.IsNullOrEmpty(pregunta) Then
            Throw New Exception("El correo ingresado no existe o no tiene una cuenta activa.")
        End If

        Return pregunta
    End Function

    Public Function ValidarRespuesta(email As String, respuesta As String) As Boolean
        If String.IsNullOrWhiteSpace(respuesta) Then
            Throw New ArgumentException("Por favor, ingrese su respuesta de seguridad.")
        End If

        Dim esCorrecta As Boolean = usuarioDao.ValidarRespuestaSeguridad(email.Trim(), respuesta.Trim())
        If Not esCorrecta Then
            Throw New Exception("La respuesta ingresada es incorrecta.")
        End If

        Return True
    End Function

    Public Sub CambiarContrasena(email As String, nuevaClave As String, confirmarClave As String)
        If String.IsNullOrWhiteSpace(nuevaClave) OrElse String.IsNullOrWhiteSpace(confirmarClave) Then
            Throw New ArgumentException("Debe completar ambos campos de contraseña.")
        End If

        If nuevaClave <> confirmarClave Then
            Throw New ArgumentException("Las contraseñas no coinciden.")
        End If

        ' Validar requisitos: al menos 8 caracteres, una mayúscula y un número
        If nuevaClave.Length < 8 OrElse Not nuevaClave.Any(AddressOf Char.IsUpper) OrElse Not nuevaClave.Any(AddressOf Char.IsDigit) Then
            Throw New ArgumentException("La contraseña no cumple con los requisitos mínimos de seguridad.")
        End If

        Dim actualizado As Boolean = usuarioDao.ActualizarContrasena(email.Trim(), nuevaClave)
        If Not actualizado Then
            Throw New Exception("No se pudo actualizar la contraseña. Verifique los datos.")
        End If
    End Sub

    Public Sub RegistrarNuevoLector(nuevoUsuario As Usuario, confirmacionClave As String)
        ' Validaciones de campos obligatorios
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

        ' Validar duplicados de DNI y Correo
        If usuarioDao.ExisteDNI(nuevoUsuario.NumeroDniUsuario.Trim()) Then
            Throw New Exception("El número de DNI ingresado ya se encuentra registrado.")
        End If

        If usuarioDao.ExisteEmail(nuevoUsuario.EmailUsuario.Trim()) Then
            Throw New Exception("El correo electrónico ingresado ya se encuentra registrado.")
        End If

        ' Validar contraseñas
        If String.IsNullOrWhiteSpace(nuevoUsuario.Contrasena) OrElse String.IsNullOrWhiteSpace(confirmacionClave) Then
            Throw New ArgumentException("Debe ingresar y confirmar su contraseña.")
        End If

        If nuevoUsuario.Contrasena <> confirmacionClave Then
            Throw New ArgumentException("Las contraseñas no coinciden.")
        End If

        ' Requisitos: 8 caracteres, una mayúscula y un número
        If nuevoUsuario.Contrasena.Length < 8 OrElse Not nuevoUsuario.Contrasena.Any(AddressOf Char.IsUpper) OrElse Not nuevoUsuario.Contrasena.Any(AddressOf Char.IsDigit) Then
            Throw New ArgumentException("La contraseña no cumple con los requisitos mínimos de seguridad.")
        End If

        ' Validar pregunta y respuesta de seguridad
        If String.IsNullOrWhiteSpace(nuevoUsuario.PreguntaSegura) Then
            Throw New ArgumentException("Debe escribir una pregunta de seguridad.")
        End If

        If String.IsNullOrWhiteSpace(nuevoUsuario.RptaSegura) Then
            Throw New ArgumentException("Debe ingresar la respuesta a su pregunta de seguridad.")
        End If

        ' Ejecutar registro
        Dim guardado As Boolean = usuarioDao.RegistrarLector(nuevoUsuario)
        If Not guardado Then
            Throw New Exception("No se pudo completar el registro del usuario.")
        End If
    End Sub

End Class