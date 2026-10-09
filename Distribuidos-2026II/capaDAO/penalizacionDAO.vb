Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class penalizacionDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()
    Private Const COLUMNAS As String = "id_penalizacion,tipo_penalizacion,descripcion_penalizacion,monto_penalizacion,estado_penalizacion,dias_desde"

    Friend Shared Function Mapear(dr As SqlDataReader) As Penalizacion
        Return New Penalizacion With {.IdPenalizacion=CInt(dr("id_penalizacion")),
            .TipoPenalizacion=CStr(dr("tipo_penalizacion")),
            .DescripcionPenalizacion=If(IsDBNull(dr("descripcion_penalizacion")), "", CStr(dr("descripcion_penalizacion"))),
            .MontoPenalizacion=CDec(dr("monto_penalizacion")), .EstadoPenalizacion=CBool(dr("estado_penalizacion")),
            .DiasDesde=If(IsDBNull(dr("dias_desde")), CType(Nothing,Integer?), CInt(dr("dias_desde")))}
    End Function

    Public Function listarTodos() As List(Of Penalizacion)
        Return buscar("", Nothing)
    End Function

    Public Function buscar(texto As String, estado As Boolean?) As List(Of Penalizacion)
        Try
            Dim lista As New List(Of Penalizacion)
            Dim query As String = "SELECT " & COLUMNAS & " FROM Penalizacion WHERE (tipo_penalizacion LIKE @texto OR descripcion_penalizacion LIKE @texto) AND (@estado IS NULL OR estado_penalizacion=@estado) ORDER BY dias_desde,tipo_penalizacion,id_penalizacion"
            Using cn As SqlConnection = con.CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@texto",SqlDbType.VarChar,-1).Value="%" & If(texto, "").Replace("[","[[]").Replace("%","[%]").Replace("_","[_]") & "%"
                    cmd.Parameters.Add("@estado",SqlDbType.Bit).Value=If(estado.HasValue,CObj(estado.Value),DBNull.Value)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(Mapear(dr))
                        End While
                    End Using
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "penalizacionDAO.buscar")
        End Try
    End Function

    Public Function buscarPorId(id As Integer) As Penalizacion
        Try
            Using cn As SqlConnection = con.CrearConexionIndependiente()
                Dim queryConsulta1 As String = "SELECT " & COLUMNAS & " FROM Penalizacion WHERE id_penalizacion=@id"
                Using cmd As New SqlCommand(queryConsulta1,cn)
                    cmd.Parameters.Add("@id",SqlDbType.Int).Value=id
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then Return Mapear(dr)
                    End Using
                End Using
            End Using
            Return Nothing
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "penalizacionDAO.buscarPorId")
        End Try
    End Function

    Public Function agregarPenalizacion(tipo As String, descripcion As String, monto As Decimal, estado As Boolean, idOperador As Integer, reglas As IReglasPenalizacion, Optional diasDesde As Integer? = Nothing) As Boolean
        Return Guardar(0,tipo,descripcion,monto,estado,diasDesde,idOperador,reglas)
    End Function

    Public Function actualizarPenalizacion(id As Integer, tipo As String, descripcion As String, monto As Decimal, estado As Boolean, idOperador As Integer, reglas As IReglasPenalizacion, Optional diasDesde As Integer? = Nothing) As Boolean
        Return Guardar(id,tipo,descripcion,monto,estado,diasDesde,idOperador,reglas)
    End Function

    Private Function Guardar(id As Integer,tipo As String,descripcion As String,monto As Decimal,estado As Boolean,dias As Integer?, idOperador As Integer, reglas As IReglasPenalizacion) As Boolean
        Try
            Using cn As SqlConnection = con.CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    reglas.ValidarPersonal(DisponibilidadReserva.LeerUsuario(cn,tx,idOperador))
                    If id>0 Then
                        Dim anterior As Integer?
                        Dim queryConsulta2 As String = "SELECT dias_desde FROM Penalizacion WITH (UPDLOCK,HOLDLOCK) WHERE id_penalizacion=@id"
                        Using cmd As New SqlCommand(queryConsulta2,cn,tx)
                            cmd.Parameters.Add("@id",SqlDbType.Int).Value=id
                            Dim valor=cmd.ExecuteScalar()
                            If valor Is Nothing Then Throw New InvalidOperationException("El tipo ya no existe.")
                            anterior=If(IsDBNull(valor),CType(Nothing,Integer?),CInt(valor))
                        End Using
                        Dim queryConsulta3 As String = "SELECT COUNT(*) FROM DetallePenalizacion WITH (HOLDLOCK) WHERE id_penalizacion=@id"
                        Using cmd As New SqlCommand(queryConsulta3,cn,tx)
                            cmd.Parameters.Add("@id",SqlDbType.Int).Value=id
                            reglas.ValidarCambioTramo(anterior,dias,CInt(cmd.ExecuteScalar()))
                        End Using
                    End If
                    Dim query As String=If(id=0,
                        "INSERT INTO Penalizacion(tipo_penalizacion,descripcion_penalizacion,monto_penalizacion,estado_penalizacion,dias_desde) VALUES(@tipo,@descripcion,@monto,@estado,@dias)",
                        "UPDATE Penalizacion SET tipo_penalizacion=@tipo,descripcion_penalizacion=@descripcion,monto_penalizacion=@monto,estado_penalizacion=@estado,dias_desde=@dias WHERE id_penalizacion=@id")
                    Dim resultado As Boolean
                    Using cmd As New SqlCommand(query,cn,tx)
                        cmd.Parameters.Add("@id",SqlDbType.Int).Value=id
                        cmd.Parameters.Add("@tipo",SqlDbType.VarChar,30).Value=tipo.Trim()
                        cmd.Parameters.Add("@descripcion",SqlDbType.VarChar,-1).Value=If(String.IsNullOrWhiteSpace(descripcion),DBNull.Value,CObj(descripcion.Trim()))
                        AgregarMonto(cmd,"@monto",monto)
                        cmd.Parameters.Add("@estado",SqlDbType.Bit).Value=estado
                        cmd.Parameters.Add("@dias",SqlDbType.Int).Value=If(dias.HasValue,CObj(dias.Value),DBNull.Value)
                        resultado=cmd.ExecuteNonQuery()=1
                    End Using
                    tx.Commit()
                    Return resultado
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "penalizacionDAO.Guardar")
        End Try
    End Function

    Public Function cambiarEstado(id As Integer, estado As Boolean, idOperador As Integer, reglas As IReglasPenalizacion) As Boolean
        Try
            Using cn As SqlConnection = con.CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction()
                    reglas.ValidarPersonal(DisponibilidadReserva.LeerUsuario(cn,tx,idOperador))
                    Dim queryConsulta4 As String = "UPDATE Penalizacion SET estado_penalizacion=@estado WHERE id_penalizacion=@id"
                    Using cmd As New SqlCommand(queryConsulta4,cn,tx)
                        cmd.Parameters.Add("@id",SqlDbType.Int).Value=id
                        cmd.Parameters.Add("@estado",SqlDbType.Bit).Value=estado
                        Dim ok=cmd.ExecuteNonQuery()=1
                        tx.Commit()
                        Return ok
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "penalizacionDAO.cambiarEstado")
        End Try
    End Function

    Friend Shared Sub AgregarMonto(cmd As SqlCommand,nombre As String,monto As Decimal)
        Dim parametro=cmd.Parameters.Add(nombre,SqlDbType.Decimal)
        parametro.Precision=7
        parametro.Scale=2
        parametro.Value=monto
    End Sub

End Class
