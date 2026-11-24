Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class autorDAO
    Private Const ConsultaAutor As String =
        "SELECT id_autor, nombre_autor, nacionalidad_autor, fecha_nacimiento_autor, fecha_fallecimiento_autor, biografia_autor FROM Autor"

    Private Function MapearAutor(dr As SqlDataReader) As Autor
        Try
            Dim objAutor As New Autor() With {
                .IdAutor = dr.GetInt32(dr.GetOrdinal("id_autor")),
                .NombreAutor = dr.GetString(dr.GetOrdinal("nombre_autor")),
                .NacionalidadAutor = If(IsDBNull(dr("nacionalidad_autor")), Nothing, dr.GetString(dr.GetOrdinal("nacionalidad_autor"))),
                .FechaNacimientoAutor = If(IsDBNull(dr("fecha_nacimiento_autor")), CType(Nothing, Date?), dr.GetDateTime(dr.GetOrdinal("fecha_nacimiento_autor"))),
                .FechaFallecimientoAutor = If(IsDBNull(dr("fecha_fallecimiento_autor")), CType(Nothing, Date?), dr.GetDateTime(dr.GetOrdinal("fecha_fallecimiento_autor"))),
                .BiografiaAutor = If(IsDBNull(dr("biografia_autor")), Nothing, dr.GetString(dr.GetOrdinal("biografia_autor")))
            }
            Return objAutor
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "autorDAO.MapearAutor")
        End Try
    End Function

    Public Function listarTodos() As List(Of Autor)
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As New List(Of Autor)()
            Dim query As String = ConsultaAutor & " ORDER BY nombre_autor"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                Using dr = cmd.ExecuteReader()
                    While dr.Read()
                        resultado.Add(MapearAutor(dr))
                    End While
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Autor", "LISTADO", "Listar autores")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "autorDAO.listarTodos")
        End Try
    End Function

    Public Function buscarPorId(idAutor As Integer) As Autor
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As Autor = Nothing
            Dim query As String = ConsultaAutor & " WHERE id_autor = @idAutor"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@idAutor", SqlDbType.Int).Value = idAutor
                Using dr = cmd.ExecuteReader()
                    If dr.Read() Then resultado = MapearAutor(dr)
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Autor", "BUSQUEDA", $"Consultar autor | ID={idAutor}")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "autorDAO.buscarPorId")
        End Try
    End Function

    Public Function buscarPorNombre(nombre As String) As Autor
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As Autor = Nothing
            Dim query As String = ConsultaAutor & " WHERE nombre_autor = @nombre"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                Using dr = cmd.ExecuteReader()
                    If dr.Read() Then resultado = MapearAutor(dr)
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Autor", "BUSQUEDA", "Buscar autor por nombre")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "autorDAO.buscarPorNombre")
        End Try
    End Function

    Public Function listarPorNacionalidad(nacionalidad As String) As List(Of Autor)
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As New List(Of Autor)()
            Dim query As String = ConsultaAutor & " WHERE nacionalidad_autor = @nacionalidad ORDER BY nombre_autor"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 100).Value = nacionalidad
                Using dr = cmd.ExecuteReader()
                    While dr.Read()
                        resultado.Add(MapearAutor(dr))
                    End While
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Autor", "BUSQUEDA", "Filtrar autores por nacionalidad")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "autorDAO.listarPorNacionalidad")
        End Try
    End Function

    Private Shared Sub AgregarDatosAutor(cmd As SqlCommand, nombre As String, nacionalidad As String,
                                        fechaNacimiento As Date?, fechaFallecimiento As Date?, biografia As String)
        Try
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
            cmd.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 100).Value = If(String.IsNullOrEmpty(nacionalidad), DBNull.Value, nacionalidad)
            cmd.Parameters.Add("@f_nacimiento", SqlDbType.Date).Value = If(fechaNacimiento.HasValue, fechaNacimiento.Value, DBNull.Value)
            cmd.Parameters.Add("@f_fallecimiento", SqlDbType.Date).Value = If(fechaFallecimiento.HasValue, fechaFallecimiento.Value, DBNull.Value)
            cmd.Parameters.Add("@biografia", SqlDbType.VarChar, -1).Value = If(String.IsNullOrEmpty(biografia), DBNull.Value, biografia)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "autorDAO.AgregarDatosAutor")
        End Try
    End Sub

    Public Function insertar(nombre As String, nacionalidad As String, fechaNacimiento As Date?, fechaFallecimiento As Date?, biografia As String, idOperador As Integer) As Boolean
        Try
            Dim query As String = "INSERT INTO Autor (nombre_autor, nacionalidad_autor, fecha_nacimiento_autor, fecha_fallecimiento_autor, biografia_autor) " &
                "SELECT @nombre, @nacionalidad, @f_nacimiento, @f_fallecimiento, @biografia " &
                "WHERE NOT EXISTS (SELECT 1 FROM Autor WHERE UPPER(LTRIM(RTRIM(nombre_autor))) = UPPER(LTRIM(RTRIM(@nombre))))"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), tx = cn.BeginTransaction()
                Using cmd As New SqlCommand(query, cn, tx)
                    AgregarDatosAutor(cmd, nombre, nacionalidad, fechaNacimiento, fechaFallecimiento, biografia)
                    If cmd.ExecuteNonQuery() <= 0 Then Return False
                End Using
                AuditoriaDAO.Registrar(cn, tx, idOperador, "Autor", "INSERT", "Registrar autor")
                tx.Commit()
            End Using
            Return True
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "autorDAO.insertar")
        End Try
    End Function

    Public Function actualizar(idAutor As Integer, nombre As String, nacionalidad As String, fechaNacimiento As Date?, fechaFallecimiento As Date?, biografia As String, idOperador As Integer) As Boolean
        Try
            Dim query As String = "UPDATE Autor SET nombre_autor = @nombre, nacionalidad_autor = @nacionalidad, fecha_nacimiento_autor = @f_nacimiento, fecha_fallecimiento_autor = @f_fallecimiento, biografia_autor = @biografia " &
                "WHERE id_autor = @id AND NOT EXISTS (SELECT 1 FROM Autor WHERE id_autor <> @id AND UPPER(LTRIM(RTRIM(nombre_autor))) = UPPER(LTRIM(RTRIM(@nombre))))"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), tx = cn.BeginTransaction()
                Using cmd As New SqlCommand(query, cn, tx)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idAutor
                    AgregarDatosAutor(cmd, nombre, nacionalidad, fechaNacimiento, fechaFallecimiento, biografia)
                    If cmd.ExecuteNonQuery() <= 0 Then Return False
                End Using
                AuditoriaDAO.Registrar(cn, tx, idOperador, "Autor", "UPDATE", $"Actualizar autor | ID={idAutor}")
                tx.Commit()
            End Using
            Return True
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "autorDAO.actualizar")
        End Try
    End Function

    Public Function eliminar(idAutor As Integer, validar As Action(Of Integer), idOperador As Integer) As Boolean
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    Dim query As String = "SELECT COUNT(*) FROM DetalleLibro WITH (UPDLOCK,HOLDLOCK) WHERE id_autor=@id"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idAutor
                        validar(CInt(cmd.ExecuteScalar()))
                    End Using
                    query = "DELETE FROM Autor WHERE id_autor=@id"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idAutor
                        Dim resultado = cmd.ExecuteNonQuery() > 0
                        If resultado Then AuditoriaDAO.Registrar(cn, tx, idOperador, "Autor", "DELETE", $"Eliminar autor | ID={idAutor}")
                        tx.Commit()
                        Return resultado
                    End Using
                End Using
            End Using
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "autorDAO.eliminar")
        End Try
    End Function
End Class
