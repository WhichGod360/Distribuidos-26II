Imports System.Data
Imports System.Data.SqlClient

Public Class usuarioDAO

    Public Function Autenticar(email As String, clave As String) As Usuario
        Dim usuarioLogueado As Usuario = Nothing
        Dim query As String =
            "SELECT u.id_usuario, u.email_usuario, u.nombre_usuario, u.ap_paterno, u.ap_materno, " &
            "       u.numero_dni_usuario, u.fecha_nacimiento_usuario, u.genero_usuario, " &
            "       u.estado_usuario, u.id_rol_usuario, r.nombre_rol_usuario " &
            "FROM Usuario u " &
            "INNER JOIN RolUsuario r ON u.id_rol_usuario = r.id_rol_usuario " &
            "WHERE u.email_usuario = @email " &
            "  AND u.contrasena = @clave " &
            "  AND u.estado_usuario = 'ACTIVO'"

        Using cn As SqlConnection = Conexion.ObtenerInstancia().ObtenerConexion()
            Using cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()
                cmd.Parameters.Add("@clave", SqlDbType.VarChar, 255).Value = clave

                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        usuarioLogueado = New Usuario() With {
                            .IdUsuario = Convert.ToInt32(dr("id_usuario")),
                            .EmailUsuario = dr("email_usuario").ToString(),
                            .NombreUsuario = dr("nombre_usuario").ToString(),
                            .ApPaterno = dr("ap_paterno").ToString(),
                            .ApMaterno = dr("ap_materno").ToString(),
                            .NumeroDniUsuario = dr("numero_dni_usuario").ToString(),
                            .EstadoUsuario = dr("estado_usuario").ToString(),
                            .IdRolUsuario = Convert.ToInt32(dr("id_rol_usuario")),
                            .NombreRol = dr("nombre_rol_usuario").ToString()
                        }

                        ' Si la columna en BD es NULL, evitamos que rompa la conversión:
                        If Not IsDBNull(dr("fecha_nacimiento_usuario")) Then
                            usuarioLogueado.FechaNacimientoUsuario = Convert.ToDateTime(dr("fecha_nacimiento_usuario"))
                        End If

                        If Not IsDBNull(dr("genero_usuario")) Then
                            usuarioLogueado.GeneroUsuario = Convert.ToBoolean(dr("genero_usuario"))
                        End If
                    End If
                End Using
            End Using
        End Using

        Return usuarioLogueado
    End Function

    Public Function ExisteEmail(email As String) As Boolean
        Dim existe As Boolean = False
        Dim query As String = "SELECT COUNT(1) FROM Usuario WHERE email_usuario = @email"

        Using cn As SqlConnection = Conexion.ObtenerInstancia().ObtenerConexion()
            Using cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()
                Dim resultado As Object = cmd.ExecuteScalar()
                If resultado IsNot Nothing AndAlso Convert.ToInt32(resultado) > 0 Then
                    existe = True
                End If
            End Using
        End Using
        Return existe
    End Function

    ' Obtener la pregunta secreta según el email del usuario
    Public Function ObtenerPreguntaSeguridad(email As String) As String
        Dim pregunta As String = String.Empty
        Dim query As String = "SELECT preguntasegura FROM Usuario WHERE email_usuario = @email AND estado_usuario = 'ACTIVO'"

        Using cn As SqlConnection = Conexion.ObtenerInstancia().ObtenerConexion()
            Using cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()
                Dim resultado As Object = cmd.ExecuteScalar()
                If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                    pregunta = resultado.ToString()
                End If
            End Using
        End Using

        Return pregunta
    End Function

    ' Validar si la respuesta ingresada coincide con la guardada en BD
    Public Function ValidarRespuestaSeguridad(email As String, respuesta As String) As Boolean
        Dim valida As Boolean = False
        Dim query As String = "SELECT COUNT(1) FROM Usuario WHERE email_usuario = @email AND LOWER(RTRIM(LTRIM(rptasegura))) = LOWER(RTRIM(LTRIM(@rpta))) AND estado_usuario = 'ACTIVO'"

        Using cn As SqlConnection = Conexion.ObtenerInstancia().ObtenerConexion()
            Using cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()
                cmd.Parameters.Add("@rpta", SqlDbType.VarChar, 20).Value = respuesta.Trim()
                Dim resultado As Object = cmd.ExecuteScalar()
                If resultado IsNot Nothing AndAlso Convert.ToInt32(resultado) > 0 Then
                    valida = True
                End If
            End Using
        End Using

        Return valida
    End Function

    ' Actualizar la contraseña en la base de datos
    Public Function ActualizarContrasena(email As String, nuevaClave As String) As Boolean
        Dim query As String = "UPDATE Usuario SET contrasena = @nuevaClave WHERE email_usuario = @email"

        Using cn As SqlConnection = Conexion.ObtenerInstancia().ObtenerConexion()
            Using cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@nuevaClave", SqlDbType.VarChar, 255).Value = nuevaClave
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    ' Valida si un DNI ya existe registrado
    Public Function ExisteDNI(dni As String) As Boolean
        Dim existe As Boolean = False
        Dim query As String = "SELECT COUNT(1) FROM Usuario WHERE numero_dni_usuario = @dni"

        Using cn As SqlConnection = Conexion.ObtenerInstancia().ObtenerConexion()
            Using cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = dni.Trim()
                Dim resultado As Object = cmd.ExecuteScalar()
                If resultado IsNot Nothing AndAlso Convert.ToInt32(resultado) > 0 Then
                    existe = True
                End If
            End Using
        End Using

        Return existe
    End Function

    ' Registra un nuevo usuario obligatoriamente como Lector (id_rol_usuario = 3)
    Public Function RegistrarLector(usuario As Usuario) As Boolean
        Dim query As String =
            "INSERT INTO Usuario (email_usuario, nombre_usuario, ap_paterno, ap_materno, " &
            "                     numero_dni_usuario, fecha_nacimiento_usuario, genero_usuario, " &
            "                     estado_usuario, contrasena, id_rol_usuario, preguntasegura, rptasegura) " &
            "VALUES (@email, @nombre, @apPaterno, @apMaterno, " &
            "        @dni, @fechaNac, @genero, " &
            "        'Activo', @clave, 3, @pregunta, @rpta)"

        Using cn As SqlConnection = Conexion.ObtenerInstancia().ObtenerConexion()
            Using cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = usuario.EmailUsuario.Trim()
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = usuario.NombreUsuario.Trim()
                cmd.Parameters.Add("@apPaterno", SqlDbType.VarChar, 100).Value = usuario.ApPaterno.Trim()
                cmd.Parameters.Add("@apMaterno", SqlDbType.VarChar, 100).Value = usuario.ApMaterno.Trim()
                cmd.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = usuario.NumeroDniUsuario.Trim()

                If usuario.FechaNacimientoUsuario.HasValue Then
                    cmd.Parameters.Add("@fechaNac", SqlDbType.Date).Value = usuario.FechaNacimientoUsuario.Value
                Else
                    cmd.Parameters.Add("@fechaNac", SqlDbType.Date).Value = DBNull.Value
                End If

                If usuario.GeneroUsuario.HasValue Then
                    cmd.Parameters.Add("@genero", SqlDbType.Bit).Value = usuario.GeneroUsuario.Value
                Else
                    cmd.Parameters.Add("@genero", SqlDbType.Bit).Value = DBNull.Value
                End If

                cmd.Parameters.Add("@clave", SqlDbType.VarChar, 255).Value = usuario.Contrasena
                cmd.Parameters.Add("@pregunta", SqlDbType.VarChar, 255).Value = usuario.PreguntaSegura.Trim()
                cmd.Parameters.Add("@rpta", SqlDbType.VarChar, 20).Value = usuario.RptaSegura.Trim()

                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

End Class
