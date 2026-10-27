Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class usuarioDAO

    Public Function ObtenerCredenciales(email As String) As Usuario
        Try
            Dim usuarioLogueado As Usuario = Nothing
            Dim query As String =
                "SELECT u.id_usuario, u.email_usuario, u.nombre_usuario, u.ap_paterno, u.ap_materno, " &
                "       u.numero_dni_usuario, u.fecha_nacimiento_usuario, u.genero_usuario, " &
                "       u.estado_usuario, u.contrasena, u.id_rol_usuario, r.nombre_rol_usuario " &
                "FROM Usuario u " &
                "INNER JOIN RolUsuario r ON u.id_rol_usuario = r.id_rol_usuario " &
                "WHERE u.email_usuario = @email " &
                "  AND UPPER(LTRIM(RTRIM(u.estado_usuario))) = 'ACTIVO'"

            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()

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
                                .NombreRol = dr("nombre_rol_usuario").ToString(),
                                .Contrasena = dr("contrasena").ToString()
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
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.ObtenerCredenciales")
        End Try
    End Function

    Public Function MigrarContrasena(idUsuario As Integer, anterior As String, nuevoHash As String) As Boolean
        Try
            Dim query As String = "UPDATE Usuario SET contrasena = @hash WHERE id_usuario = @id AND CONVERT(varbinary(max), contrasena) = CONVERT(varbinary(max), @anterior) AND UPPER(LTRIM(RTRIM(estado_usuario))) = 'ACTIVO'"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario
                    cmd.Parameters.Add("@hash", SqlDbType.VarChar, 255).Value = nuevoHash
                    cmd.Parameters.Add("@anterior", SqlDbType.VarChar, 255).Value = anterior
                    Return cmd.ExecuteNonQuery() = 1
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.MigrarContrasena")
        End Try
    End Function

    Public Function ExisteEmail(email As String) As Boolean
        Try
            Dim existe As Boolean = False
            Dim query As String = "SELECT COUNT(1) FROM Usuario WHERE email_usuario = @email"

            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()
                    Dim resultado As Object = cmd.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso Convert.ToInt32(resultado) > 0 Then
                        existe = True
                    End If
                End Using
            End Using
            Return existe
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.ExisteEmail")
        End Try
    End Function

    ' Obtener la pregunta secreta según el email del usuario
    Public Function ObtenerPreguntaSeguridad(email As String) As String
        Try
            Dim pregunta As String = String.Empty
            Dim query As String = "SELECT preguntasegura FROM Usuario WHERE email_usuario = @email AND UPPER(LTRIM(RTRIM(estado_usuario))) = 'ACTIVO'"

            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()
                    Dim resultado As Object = cmd.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                        pregunta = resultado.ToString()
                    End If
                End Using
            End Using

            Return pregunta
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.ObtenerPreguntaSeguridad")
        End Try
    End Function

    ' La identidad verificada solo se usa en negocio; los hashes no se muestran en formularios.
    Public Function ObtenerIdentidadRecuperacion(email As String) As Usuario
        Try
            Dim identidad As Usuario = Nothing
            Dim query As String = "SELECT id_usuario, email_usuario, rptasegura, contrasena FROM Usuario " &
                "WHERE email_usuario = @email AND UPPER(LTRIM(RTRIM(estado_usuario))) = 'ACTIVO'"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            identidad = New Usuario With {.IdUsuario = CInt(dr("id_usuario")),
                                .EmailUsuario = CStr(dr("email_usuario")), .RptaSegura = CStr(dr("rptasegura")),
                                .Contrasena = CStr(dr("contrasena"))}
                        End If
                    End Using
                End Using
            End Using
            Return identidad
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.ObtenerIdentidadRecuperacion")
        End Try
    End Function

    ' Actualizar la contraseña en la base de datos
    Public Function ActualizarContrasena(idUsuario As Integer, email As String, nuevaClaveHash As String,
                                        respuestaVerificada As String, contrasenaAnterior As String) As Boolean
        Try
            Dim query As String = "UPDATE Usuario SET contrasena = @nuevaClave WHERE id_usuario = @id AND email_usuario = @email " &
                "AND CONVERT(varbinary(max), rptasegura) = CONVERT(varbinary(max), @respuesta) " &
                "AND CONVERT(varbinary(max), contrasena) = CONVERT(varbinary(max), @anterior) " &
                "AND UPPER(LTRIM(RTRIM(estado_usuario))) = 'ACTIVO'"

            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@nuevaClave", SqlDbType.VarChar, 255).Value = nuevaClaveHash
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email.Trim()
                    cmd.Parameters.Add("@respuesta", SqlDbType.VarChar, 255).Value = respuestaVerificada
                    cmd.Parameters.Add("@anterior", SqlDbType.VarChar, 255).Value = contrasenaAnterior
                    Return cmd.ExecuteNonQuery() = 1
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.ActualizarContrasena")
        End Try
    End Function

    ' Valida si un DNI ya existe registrado
    Public Function ExisteDNI(dni As String) As Boolean
        Try
            Dim existe As Boolean = False
            Dim query As String = "SELECT COUNT(1) FROM Usuario WHERE numero_dni_usuario = @dni"

            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = dni.Trim()
                    Dim resultado As Object = cmd.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso Convert.ToInt32(resultado) > 0 Then
                        existe = True
                    End If
                End Using
            End Using

            Return existe
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.ExisteDNI")
        End Try
    End Function

    ' El registro público crea únicamente cuentas de lector, nunca de personal.
    Public Function RegistrarLector(usuario As Usuario, claveHash As String, respuestaHash As String) As Boolean
        Try
            Dim query As String =
                "INSERT INTO Usuario (email_usuario, nombre_usuario, ap_paterno, ap_materno, " &
                "                     numero_dni_usuario, fecha_nacimiento_usuario, genero_usuario, " &
                "                     estado_usuario, contrasena, id_rol_usuario, preguntasegura, rptasegura) " &
                "VALUES (@email, @nombre, @apPaterno, @apMaterno, " &
                "        @dni, @fechaNac, @genero, " &
                "        'Activo', @clave, (SELECT MIN(id_rol_usuario) FROM RolUsuario WHERE UPPER(LTRIM(RTRIM(nombre_rol_usuario))) IN ('ESTUDIANTE','LECTOR')), @pregunta, @rpta)"

            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
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

                    cmd.Parameters.Add("@clave", SqlDbType.VarChar, 255).Value = claveHash
                    cmd.Parameters.Add("@pregunta", SqlDbType.VarChar, 255).Value = usuario.PreguntaSegura.Trim()
                    cmd.Parameters.Add("@rpta", SqlDbType.VarChar, 255).Value = respuestaHash

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.RegistrarLector")
        End Try
    End Function

    Public Function LeerRespuestasAnteriores() As List(Of KeyValuePair(Of Integer, String))
        Try
            Dim anteriores As New List(Of KeyValuePair(Of Integer, String))()
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim query As String = "SELECT COL_LENGTH('dbo.Usuario', 'rptasegura') AS longitud"
                Using cmd As New SqlCommand(query, cn)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If Not dr.Read() OrElse IsDBNull(dr("longitud")) OrElse CInt(dr("longitud")) < 255 Then
                            Throw New InvalidOperationException("Ejecuta migraciones/004_respuesta_seguridad_hash.sql antes de abrir esta versión del sistema.")
                        End If
                    End Using
                End Using
                query = "SELECT id_usuario, rptasegura FROM Usuario WHERE rptasegura COLLATE Latin1_General_100_BIN2 NOT LIKE 'PBKDF2-SHA256$%' ORDER BY id_usuario"
                Using cmd As New SqlCommand(query, cn)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim respuesta As String = CStr(dr("rptasegura"))
                            anteriores.Add(New KeyValuePair(Of Integer, String)(CInt(dr("id_usuario")), respuesta))
                        End While
                    End Using
                End Using
            End Using
            Return anteriores
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.LeerRespuestasAnteriores")
        End Try
    End Function

    Public Sub MigrarRespuesta(idUsuario As Integer, anterior As String, nuevoHash As String)
        Try
            Dim query As String = "UPDATE Usuario SET rptasegura=@hash WHERE id_usuario=@id AND CONVERT(varbinary(max),rptasegura)=CONVERT(varbinary(max),@anterior)"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario
                    cmd.Parameters.Add("@hash", SqlDbType.VarChar, 255).Value = nuevoHash
                    cmd.Parameters.Add("@anterior", SqlDbType.VarChar, 255).Value = anterior
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.MigrarRespuesta")
        End Try
    End Sub

    Public Function ListarUsuarios(texto As String, Optional idRol As Integer = 0,
                                   Optional estado As String = "Todos",
                                   Optional bitacora As IContextoBitacora = Nothing) As List(Of Usuario)
        Try
            Dim lista As New List(Of Usuario)()
            Dim query As String = ConsultaUsuarios &
                "WHERE (u.nombre_usuario + ' ' + u.ap_paterno + ' ' + u.ap_materno LIKE @texto " &
                "OR u.email_usuario LIKE @texto OR u.numero_dni_usuario LIKE @texto) " &
                "AND (@idRol = 0 OR u.id_rol_usuario = @idRol) " &
                "AND (@estado = 'Todos' OR UPPER(LTRIM(RTRIM(u.estado_usuario))) = UPPER(@estado)) " &
                "ORDER BY u.ap_paterno, u.ap_materno, u.nombre_usuario"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@texto", SqlDbType.VarChar, -1).Value = "%" & texto.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") & "%"
                    cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol
                    cmd.Parameters.Add("@estado", SqlDbType.VarChar, 30).Value = estado
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(LeerUsuario(dr))
                        End While
                    End Using
                    BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.ListarUsuarios")
        End Try
    End Function

    Public Function ObtenerUsuario(idUsuario As Integer, Optional bitacora As IContextoBitacora = Nothing) As Usuario
        Try
            Dim usuario As Usuario = Nothing
            Dim query As String = ConsultaUsuarios & "WHERE u.id_usuario = @id"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then usuario = LeerUsuario(dr)
                    End Using
                    BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                End Using
            End Using
            Return usuario
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.ObtenerUsuario")
        End Try
    End Function

    Public Function ListarRoles(Optional bitacora As IContextoBitacora = Nothing) As List(Of RolUsuario)
        Try
            Dim lista As New List(Of RolUsuario)()
            Dim query As String = "SELECT id_rol_usuario, nombre_rol_usuario FROM RolUsuario " &
                "WHERE UPPER(LTRIM(RTRIM(nombre_rol_usuario))) IN ('ADMINISTRADOR','BIBLIOTECARIO','ESTUDIANTE','LECTOR') ORDER BY nombre_rol_usuario"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New RolUsuario With {.IdRolUsuario = CInt(dr("id_rol_usuario")), .NombreRolUsuario = CStr(dr("nombre_rol_usuario"))})
                        End While
                    End Using
                    BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.ListarRoles")
        End Try
    End Function

    Public Function CrearUsuario(usuario As Usuario, idAdministrador As Integer, claveHash As String, respuestaHash As String, reglas As IReglasUsuario,
                                 Optional bitacora As IContextoBitacora = Nothing) As Boolean
        Try
            Dim query As String = "INSERT INTO Usuario (email_usuario,nombre_usuario,ap_paterno,ap_materno,numero_dni_usuario," &
                "fecha_nacimiento_usuario,genero_usuario,estado_usuario,contrasena,id_rol_usuario,preguntasegura,rptasegura) " &
                "VALUES (@email,@nombre,@paterno,@materno,@dni,@fecha,@genero,@estado,@clave,@rol,@pregunta,@respuesta)"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    BloquearAdministracion(cn, tx)
                    reglas.ValidarAdministrador(DisponibilidadReserva.LeerUsuario(cn, tx, idAdministrador, True))
                    reglas.ValidarRol(LeerRol(cn, tx, usuario.IdRolUsuario))
                    Using cmd As New SqlCommand(query, cn, tx)
                        AgregarDatosUsuario(cmd, usuario)
                        cmd.Parameters.Add("@clave", SqlDbType.VarChar, 255).Value = claveHash
                        cmd.Parameters.Add("@pregunta", SqlDbType.VarChar, 255).Value = usuario.PreguntaSegura.Trim()
                        cmd.Parameters.Add("@respuesta", SqlDbType.VarChar, 255).Value = respuestaHash
                        If cmd.ExecuteNonQuery() <> 1 Then Return False
                        BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                    End Using
                    tx.Commit()
                    Return True
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.CrearUsuario")
        End Try
    End Function

    Public Function ActualizarUsuario(usuario As Usuario, idAdministrador As Integer, reglas As IReglasUsuario,
                                      Optional bitacora As IContextoBitacora = Nothing) As Boolean
        Try
            Dim query As String = "UPDATE Usuario SET email_usuario=@email,nombre_usuario=@nombre,ap_paterno=@paterno,ap_materno=@materno," &
                "numero_dni_usuario=@dni,fecha_nacimiento_usuario=@fecha,genero_usuario=@genero,estado_usuario=@estado,id_rol_usuario=@rol WHERE id_usuario=@id"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    BloquearAdministracion(cn, tx)
                    reglas.ValidarAdministrador(DisponibilidadReserva.LeerUsuario(cn, tx, idAdministrador, True))
                    reglas.ValidarCambio(LeerCambioUsuario(cn, tx, idAdministrador, usuario.IdUsuario, usuario.IdRolUsuario, usuario.EstadoUsuario))
                    Using cmd As New SqlCommand(query, cn, tx)
                        AgregarDatosUsuario(cmd, usuario)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = usuario.IdUsuario
                        If cmd.ExecuteNonQuery() <> 1 Then Return False
                        BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                    End Using
                    tx.Commit()
                    Return True
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.ActualizarUsuario")
        End Try
    End Function

    Public Function CambiarEstadoUsuario(idUsuario As Integer, estado As String, idAdministrador As Integer, reglas As IReglasUsuario,
                                         Optional bitacora As IContextoBitacora = Nothing) As Boolean
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    BloquearAdministracion(cn, tx)
                    reglas.ValidarAdministrador(DisponibilidadReserva.LeerUsuario(cn, tx, idAdministrador, True))
                    Dim rol As Integer
                    Dim query As String = "SELECT id_rol_usuario FROM Usuario WITH (UPDLOCK,HOLDLOCK) WHERE id_usuario=@id"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario
                        Using dr As SqlDataReader = cmd.ExecuteReader()
                            If Not dr.Read() Then Throw New InvalidOperationException("El usuario ya no existe.")
                            rol = CInt(dr("id_rol_usuario"))
                        End Using
                    End Using
                    reglas.ValidarCambio(LeerCambioUsuario(cn, tx, idAdministrador, idUsuario, rol, estado))
                    query = "UPDATE Usuario SET estado_usuario=@estado WHERE id_usuario=@id"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar, 30).Value = estado
                        If cmd.ExecuteNonQuery() <> 1 Then Return False
                        BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                    End Using
                    tx.Commit()
                    Return True
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.CambiarEstadoUsuario")
        End Try
    End Function

    Private Const ConsultaUsuarios As String = "SELECT u.id_usuario,u.email_usuario,u.nombre_usuario,u.ap_paterno,u.ap_materno," &
        "u.numero_dni_usuario,u.fecha_nacimiento_usuario,u.genero_usuario,u.estado_usuario,u.id_rol_usuario,r.nombre_rol_usuario " &
        "FROM Usuario u INNER JOIN RolUsuario r ON r.id_rol_usuario=u.id_rol_usuario "

    Private Shared Function LeerUsuario(dr As SqlDataReader) As Usuario
        Dim usuario As New Usuario With {.IdUsuario = CInt(dr("id_usuario")), .EmailUsuario = CStr(dr("email_usuario")),
            .NombreUsuario = CStr(dr("nombre_usuario")), .ApPaterno = CStr(dr("ap_paterno")), .ApMaterno = CStr(dr("ap_materno")),
            .NumeroDniUsuario = CStr(dr("numero_dni_usuario")), .EstadoUsuario = CStr(dr("estado_usuario")),
            .IdRolUsuario = CInt(dr("id_rol_usuario")), .NombreRol = CStr(dr("nombre_rol_usuario"))}
        If Not IsDBNull(dr("fecha_nacimiento_usuario")) Then usuario.FechaNacimientoUsuario = CDate(dr("fecha_nacimiento_usuario"))
        If Not IsDBNull(dr("genero_usuario")) Then usuario.GeneroUsuario = CBool(dr("genero_usuario"))
        Return usuario
    End Function

    Private Shared Sub AgregarDatosUsuario(cmd As SqlCommand, usuario As Usuario)
        cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = usuario.EmailUsuario.Trim()
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = usuario.NombreUsuario.Trim()
        cmd.Parameters.Add("@paterno", SqlDbType.VarChar, 100).Value = usuario.ApPaterno.Trim()
        cmd.Parameters.Add("@materno", SqlDbType.VarChar, 100).Value = usuario.ApMaterno.Trim()
        cmd.Parameters.Add("@dni", SqlDbType.VarChar, 8).Value = usuario.NumeroDniUsuario.Trim()
        cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = If(usuario.FechaNacimientoUsuario.HasValue, CObj(usuario.FechaNacimientoUsuario.GetValueOrDefault().Date), DBNull.Value)
        cmd.Parameters.Add("@genero", SqlDbType.Bit).Value = If(usuario.GeneroUsuario.HasValue, CObj(usuario.GeneroUsuario.GetValueOrDefault()), DBNull.Value)
        cmd.Parameters.Add("@estado", SqlDbType.VarChar, 30).Value = usuario.EstadoUsuario
        cmd.Parameters.Add("@rol", SqlDbType.Int).Value = usuario.IdRolUsuario
    End Sub

    Private Shared Sub BloquearAdministracion(cn As SqlConnection, tx As SqlTransaction)
        Try
            Dim query As String = "DECLARE @resultado INT; EXEC @resultado=sys.sp_getapplock @Resource='Biblioteca.AdministrarUsuarios',@LockMode='Exclusive',@LockOwner='Transaction',@LockTimeout=10000; SELECT @resultado AS resultado"
            Using cmd As New SqlCommand(query, cn, tx)
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If Not dr.Read() OrElse CInt(dr("resultado")) < 0 Then Throw New InvalidOperationException("Otro administrador está guardando cambios. Intenta nuevamente.")
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.BloquearAdministracion")
        End Try
    End Sub

    Private Shared Function LeerRol(cn As SqlConnection, tx As SqlTransaction, idRol As Integer) As String
        Try
            Dim query As String = "SELECT nombre_rol_usuario FROM RolUsuario WITH (HOLDLOCK) WHERE id_rol_usuario=@id"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idRol
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then Return dr.GetString(0)
                End Using
            End Using
            Return Nothing
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.LeerRol")
        End Try
    End Function

    Private Shared Function LeerCambioUsuario(cn As SqlConnection, tx As SqlTransaction, administrador As Integer, destino As Integer, nuevoRol As Integer, nuevoEstado As String) As DatosCambioUsuario
        Try
            Dim datos As New DatosCambioUsuario With {.IdAdministrador = administrador, .NuevoRol = LeerRol(cn, tx, nuevoRol),
                .NuevoEstado = nuevoEstado, .Actual = DisponibilidadReserva.LeerUsuario(cn, tx, destino, True)}
            Dim query As String = "SELECT COUNT(*) FROM Usuario u WITH (UPDLOCK,HOLDLOCK) JOIN RolUsuario r ON r.id_rol_usuario=u.id_rol_usuario WHERE UPPER(LTRIM(RTRIM(u.estado_usuario)))='ACTIVO' AND UPPER(LTRIM(RTRIM(r.nombre_rol_usuario)))='ADMINISTRADOR'"
            Using cmd As New SqlCommand(query, cn, tx)
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    dr.Read()
                    datos.AdministradoresActivos = dr.GetInt32(0)
                End Using
            End Using
            query = "SELECT (SELECT COUNT(*) FROM Prestamo WITH (HOLDLOCK) WHERE id_usuario=@id AND fecha_retorno_prestamo IS NULL) + (SELECT COUNT(*) FROM SolicitudPrestamo WITH (HOLDLOCK) WHERE id_usuario=@id AND estado_solicitud IN ('Pendiente','Aprobada') AND fecha_limite_retiro>SYSUTCDATETIME()) AS pendientes"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = destino
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    dr.Read()
                    datos.MovimientosPendientes = dr.GetInt32(0)
                End Using
            End Using
            Return datos
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "usuarioDAO.LeerCambioUsuario")
        End Try
    End Function
End Class
