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
                ' Parámetro tipado para evitar inyección SQL
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()

                ' ExecuteScalar devuelve la primera columna de la primera fila (el COUNT)
                Dim resultado As Object = cmd.ExecuteScalar()
                If resultado IsNot Nothing AndAlso Convert.ToInt32(resultado) > 0 Then
                    existe = True
                End If
            End Using
        End Using

        Return existe
    End Function

End Class
