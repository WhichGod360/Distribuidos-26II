Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class bitacoraDAO

    Public Function Registrar(registro As Bitacora) As Integer
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    Dim idMan As Integer = Registrar(registro, cn, tx)
                    tx.Commit()
                    Return idMan
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "bitacoraDAO.Registrar")
        End Try
    End Function

    ' Permite guardar el movimiento dentro de la transacción del mantenimiento.
    ' La conexión y la transacción pertenecen al método que llama.
    Friend Function Registrar(registro As Bitacora, cn As SqlConnection, tx As SqlTransaction) As Integer
        If registro Is Nothing Then Throw New ArgumentNullException(NameOf(registro))
        If cn Is Nothing Then Throw New ArgumentNullException(NameOf(cn))
        If tx Is Nothing Then Throw New ArgumentNullException(NameOf(tx))

        Try
            ' El bloqueo se mantiene hasta confirmar o revertir la transacción.
            ' Así la asignación del ID también funciona con la tabla vacía.
            Dim query As String =
                "DECLARE @idMan int; " &
                "SELECT @idMan = ISNULL(MAX(idMan), 0) + 1 " &
                "FROM dbo.bitacora_mantenimiento WITH (TABLOCKX, HOLDLOCK); " &
                "INSERT INTO dbo.bitacora_mantenimiento " &
                "(idMan, fechaMan, horaMan, idUsuario, objeto, accion, cadenaMan) " &
                "VALUES (@idMan, @fechaMan, @horaMan, @idUsuario, @objeto, @accion, LEFT(@cadenaMan, 255)); " &
                "SELECT @idMan;"

            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@fechaMan", SqlDbType.Date).Value = registro.FechaMan
                cmd.Parameters.Add("@horaMan", SqlDbType.VarChar, 10).Value = registro.HoraMan
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = registro.IdUsuario
                cmd.Parameters.Add("@objeto", SqlDbType.VarChar, 30).Value = registro.Objeto
                cmd.Parameters.Add("@accion", SqlDbType.VarChar, 15).Value = registro.Accion
                cmd.Parameters.Add("@cadenaMan", SqlDbType.VarChar, -1).Value =
                    If(registro.CadenaMan Is Nothing, DBNull.Value, CObj(registro.CadenaMan))
                Return CInt(cmd.ExecuteScalar())
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "bitacoraDAO.Registrar")
        End Try
    End Function

    Public Function Listar(Optional fechaDesde As Date? = Nothing,
                           Optional fechaHasta As Date? = Nothing,
                           Optional idUsuario As Integer? = Nothing,
                           Optional objeto As String = Nothing,
                           Optional accion As String = Nothing,
                           Optional despuesDeId As Integer? = Nothing) As List(Of Bitacora)
        Try
            Dim lista As New List(Of Bitacora)()
            Dim query As String =
                "SELECT idMan, fechaMan, horaMan, idUsuario, objeto, accion, cadenaMan " &
                "FROM dbo.bitacora_mantenimiento " &
                "WHERE (@fechaDesde IS NULL OR fechaMan >= @fechaDesde) " &
                "AND (@fechaHasta IS NULL OR fechaMan <= @fechaHasta) " &
                "AND (@idUsuario IS NULL OR idUsuario = @idUsuario) " &
                "AND (@objeto IS NULL OR objeto = @objeto) " &
                "AND (@accion IS NULL OR accion = @accion) " &
                "AND (@despuesDeId IS NULL OR idMan > @despuesDeId) " &
                "ORDER BY idMan DESC"

            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@fechaDesde", SqlDbType.Date).Value =
                        If(fechaDesde.HasValue, CObj(fechaDesde.Value), DBNull.Value)
                    cmd.Parameters.Add("@fechaHasta", SqlDbType.Date).Value =
                        If(fechaHasta.HasValue, CObj(fechaHasta.Value), DBNull.Value)
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value =
                        If(idUsuario.HasValue, CObj(idUsuario.Value), DBNull.Value)
                    cmd.Parameters.Add("@objeto", SqlDbType.VarChar, 30).Value =
                        If(objeto Is Nothing, DBNull.Value, CObj(objeto))
                    cmd.Parameters.Add("@accion", SqlDbType.VarChar, 15).Value =
                        If(accion Is Nothing, DBNull.Value, CObj(accion))
                    cmd.Parameters.Add("@despuesDeId", SqlDbType.Int).Value =
                        If(despuesDeId.HasValue, CObj(despuesDeId.Value), DBNull.Value)

                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(Leer(dr))
                        End While
                    End Using
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "bitacoraDAO.Listar")
        End Try
    End Function

    Public Function ObtenerPorId(idMan As Integer) As Bitacora
        Try
            Dim query As String =
                "SELECT idMan, fechaMan, horaMan, idUsuario, objeto, accion, cadenaMan " &
                "FROM dbo.bitacora_mantenimiento WHERE idMan = @idMan"

            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@idMan", SqlDbType.Int).Value = idMan
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then Return Leer(dr)
                    End Using
                End Using
            End Using
            Return Nothing
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "bitacoraDAO.ObtenerPorId")
        End Try
    End Function

    Private Shared Function Leer(dr As SqlDataReader) As Bitacora
        Return New Bitacora With {
            .IdMan = dr.GetInt32(dr.GetOrdinal("idMan")),
            .FechaMan = dr.GetDateTime(dr.GetOrdinal("fechaMan")),
            .HoraMan = dr.GetString(dr.GetOrdinal("horaMan")),
            .IdUsuario = dr.GetInt32(dr.GetOrdinal("idUsuario")),
            .Objeto = dr.GetString(dr.GetOrdinal("objeto")),
            .Accion = dr.GetString(dr.GetOrdinal("accion")),
            .CadenaMan = If(dr.IsDBNull(dr.GetOrdinal("cadenaMan")), Nothing, dr.GetString(dr.GetOrdinal("cadenaMan")))
        }
    End Function
End Class
