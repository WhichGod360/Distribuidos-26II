Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class autorDAO

    ' Método auxiliar para mapear el DataReader al objeto Autor y evitar repetir código
    Private Function MapearAutor(dr As SqlDataReader) As Autor
        Dim objAutor As New Autor() With {
            .IdAutor = dr.GetInt32(dr.GetOrdinal("id_autor")),
            .NombreAutor = dr.GetString(dr.GetOrdinal("nombre_autor")),
            .NacionalidadAutor = If(IsDBNull(dr("nacionalidad_autor")), Nothing, dr.GetString(dr.GetOrdinal("nacionalidad_autor"))),
            .FechaNacimientoAutor = If(IsDBNull(dr("fecha_nacimiento_autor")), CType(Nothing, Date?), dr.GetDateTime(dr.GetOrdinal("fecha_nacimiento_autor"))),
            .FechaFallecimientoAutor = If(IsDBNull(dr("fecha_fallecimiento_autor")), CType(Nothing, Date?), dr.GetDateTime(dr.GetOrdinal("fecha_fallecimiento_autor"))),
            .BiografiaAutor = If(IsDBNull(dr("biografia_autor")), Nothing, dr.GetString(dr.GetOrdinal("biografia_autor")))
        }
        Return objAutor
    End Function

    Public Function listarTodos() As List(Of Autor)
        Try
            Dim lista As New List(Of Autor)()
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim query As String = "SELECT id_autor, nombre_autor, nacionalidad_autor, fecha_nacimiento_autor, fecha_fallecimiento_autor, biografia_autor FROM Autor ORDER BY nombre_autor"
                Using cmd As New SqlCommand(query, cn)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(MapearAutor(dr))
                        End While
                    End Using
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "autorDAO.listarTodos")
        End Try
    End Function

    Public Function buscarPorId(idAutor As Integer) As Autor
        Try
            Dim objAutor As Autor = Nothing
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim query As String = "SELECT id_autor, nombre_autor, nacionalidad_autor, fecha_nacimiento_autor, fecha_fallecimiento_autor, biografia_autor FROM Autor WHERE id_autor = @idAutor"
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@idAutor", SqlDbType.Int).Value = idAutor
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            objAutor = MapearAutor(dr)
                        End If
                    End Using
                End Using
            End Using
            Return objAutor
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "autorDAO.buscarPorId")
        End Try
    End Function

    Public Function buscarPorNombre(nombre As String) As Autor
        Try
            Dim objAutor As Autor = Nothing
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim query As String = "SELECT id_autor, nombre_autor, nacionalidad_autor, fecha_nacimiento_autor, fecha_fallecimiento_autor, biografia_autor FROM Autor WHERE nombre_autor = @nombre"
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            objAutor = MapearAutor(dr)
                        End If
                    End Using
                End Using
            End Using
            Return objAutor
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "autorDAO.buscarPorNombre")
        End Try
    End Function

    ' NUEVO MÉTODO: Filtrar / listar por nacionalidad
    Public Function listarPorNacionalidad(nacionalidad As String) As List(Of Autor)
        Try
            Dim lista As New List(Of Autor)()
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim query As String = "SELECT id_autor, nombre_autor, nacionalidad_autor, fecha_nacimiento_autor, fecha_fallecimiento_autor, biografia_autor FROM Autor WHERE nacionalidad_autor = @nacionalidad ORDER BY nombre_autor"
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 100).Value = nacionalidad
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(MapearAutor(dr))
                        End While
                    End Using
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "autorDAO.listarPorNacionalidad")
        End Try
    End Function

    Public Function insertar(nombre As String, nacionalidad As String, fechaNacimiento As Date?, fechaFallecimiento As Date?, biografia As String) As Boolean
        Try
            Dim query As String = "INSERT INTO Autor (nombre_autor, nacionalidad_autor, fecha_nacimiento_autor, fecha_fallecimiento_autor, biografia_autor) " &
                                          "SELECT @nombre, @nacionalidad, @f_nacimiento, @f_fallecimiento, @biografia " &
                                          "WHERE NOT EXISTS (SELECT 1 FROM Autor WHERE UPPER(LTRIM(RTRIM(nombre_autor))) = UPPER(LTRIM(RTRIM(@nombre))))"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                    cmd.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 100).Value = If(String.IsNullOrEmpty(nacionalidad), DBNull.Value, nacionalidad)
                    cmd.Parameters.Add("@f_nacimiento", SqlDbType.Date).Value = If(fechaNacimiento.HasValue, fechaNacimiento.Value, DBNull.Value)
                    cmd.Parameters.Add("@f_fallecimiento", SqlDbType.Date).Value = If(fechaFallecimiento.HasValue, fechaFallecimiento.Value, DBNull.Value)
                    cmd.Parameters.Add("@biografia", SqlDbType.VarChar, -1).Value = If(String.IsNullOrEmpty(biografia), DBNull.Value, biografia)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "autorDAO.insertar")
        End Try
    End Function

    Public Function actualizar(idAutor As Integer, nombre As String, nacionalidad As String, fechaNacimiento As Date?, fechaFallecimiento As Date?, biografia As String) As Boolean
        Try
            Dim query As String = "UPDATE Autor SET nombre_autor = @nombre, nacionalidad_autor = @nacionalidad, fecha_nacimiento_autor = @f_nacimiento, fecha_fallecimiento_autor = @f_fallecimiento, biografia_autor = @biografia " &
                                          "WHERE id_autor = @id AND NOT EXISTS (SELECT 1 FROM Autor WHERE id_autor <> @id AND UPPER(LTRIM(RTRIM(nombre_autor))) = UPPER(LTRIM(RTRIM(@nombre))))"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idAutor
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                    cmd.Parameters.Add("@nacionalidad", SqlDbType.VarChar, 100).Value = If(String.IsNullOrEmpty(nacionalidad), DBNull.Value, nacionalidad)
                    cmd.Parameters.Add("@f_nacimiento", SqlDbType.Date).Value = If(fechaNacimiento.HasValue, fechaNacimiento.Value, DBNull.Value)
                    cmd.Parameters.Add("@f_fallecimiento", SqlDbType.Date).Value = If(fechaFallecimiento.HasValue, fechaFallecimiento.Value, DBNull.Value)
                    cmd.Parameters.Add("@biografia", SqlDbType.VarChar, -1).Value = If(String.IsNullOrEmpty(biografia), DBNull.Value, biografia)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "autorDAO.actualizar")
        End Try
    End Function

    Public Function eliminar(idAutor As Integer, validar As Action(Of Integer)) As Boolean
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
                        tx.Commit()
                        Return resultado
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "autorDAO.eliminar")
        End Try
    End Function
End Class
