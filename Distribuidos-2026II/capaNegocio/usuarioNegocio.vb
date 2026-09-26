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

        ' 2. Llamada a la capa de datos para consultar en SQL Server
        Dim usuarioLogueado As Usuario = usuarioDao.Autenticar(email.Trim(), contrasena)

        ' 3. Si no existe o las credenciales son incorrectas
        If usuarioLogueado Is Nothing Then
            Throw New Exception("Correo o contraseña incorrectos, o la cuenta está inactiva.")
        End If

        Return usuarioLogueado
    End Function

    ''' 
    ''' Valida si un correo ya se encuentra registrado en el sistema.
    ''' 
    Public Function ValidarCorreoExistente(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then
            Return False
        End If

        Return usuarioDao.ExisteEmail(email.Trim())
    End Function

End Class