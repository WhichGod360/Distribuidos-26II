Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class penalizacionDAO
    Private Const ConsultaPenalizacion As String = "SELECT id_penalizacion,tipo_penalizacion,descripcion_penalizacion,monto_penalizacion,estado_penalizacion,dias_desde FROM Penalizacion"

    Friend Shared Function Mapear(dr As SqlDataReader) As Penalizacion
        Try
            Return New Penalizacion With {.IdPenalizacion = CInt(dr("id_penalizacion")),
                .TipoPenalizacion = CStr(dr("tipo_penalizacion")),
                .DescripcionPenalizacion = If(IsDBNull(dr("descripcion_penalizacion")), "", CStr(dr("descripcion_penalizacion"))),
                .MontoPenalizacion = CDec(dr("monto_penalizacion")), .EstadoPenalizacion = CBool(dr("estado_penalizacion")),
                .DiasDesde = If(IsDBNull(dr("dias_desde")), CType(Nothing, Integer?), CInt(dr("dias_desde")))}
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "penalizacionDAO.Mapear")
        End Try
    End Function

    Public Function listarTodos() As List(Of Penalizacion)
        Try
            Return buscar("", Nothing)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "penalizacionDAO.listarTodos")
        End Try
    End Function

    Public Function buscar(texto As String, estado As Boolean?) As List(Of Penalizacion)
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As New List(Of Penalizacion)()
            Dim query As String = ConsultaPenalizacion & " WHERE (tipo_penalizacion LIKE @texto OR descripcion_penalizacion LIKE @texto) AND (@estado IS NULL OR estado_penalizacion=@estado) ORDER BY dias_desde,tipo_penalizacion,id_penalizacion"
            Dim accion = If(String.IsNullOrWhiteSpace(texto) AndAlso Not estado.HasValue, "LISTADO", "BUSQUEDA")
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@texto", SqlDbType.VarChar, -1).Value = LecturaDAO.PatronContiene(texto)
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = If(estado.HasValue, CObj(estado.Value), DBNull.Value)
                Using dr = cmd.ExecuteReader()
                    While dr.Read()
                        resultado.Add(Mapear(dr))
                    End While
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Penalizacion", accion, "Consultar tipos de penalización")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "penalizacionDAO.buscar")
        End Try
    End Function

    Public Function buscarPorId(id As Integer) As Penalizacion
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As Penalizacion = Nothing
            Dim query As String = ConsultaPenalizacion & " WHERE id_penalizacion=@id"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                Using dr = cmd.ExecuteReader()
                    If dr.Read() Then resultado = Mapear(dr)
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Penalizacion", "BUSQUEDA", $"Consultar tipo de penalización | ID={id}")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "penalizacionDAO.buscarPorId")
        End Try
    End Function

    Public Function agregarPenalizacion(tipo As String, descripcion As String, monto As Decimal, estado As Boolean, idOperador As Integer, reglas As IReglasPenalizacion, Optional diasDesde As Integer? = Nothing) As Boolean
        Try
            Return Guardar(0, tipo, descripcion, monto, estado, diasDesde, idOperador, reglas)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "penalizacionDAO.agregarPenalizacion")
        End Try
    End Function

    Public Function actualizarPenalizacion(id As Integer, tipo As String, descripcion As String, monto As Decimal, estado As Boolean, idOperador As Integer, reglas As IReglasPenalizacion, Optional diasDesde As Integer? = Nothing) As Boolean
        Try
            Return Guardar(id, tipo, descripcion, monto, estado, diasDesde, idOperador, reglas)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "penalizacionDAO.actualizarPenalizacion")
        End Try
    End Function

    Private Function Guardar(id As Integer, tipo As String, descripcion As String, monto As Decimal, estado As Boolean, dias As Integer?, idOperador As Integer, reglas As IReglasPenalizacion) As Boolean
        Try
            Dim query As String
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    reglas.ValidarPersonal(DisponibilidadReserva.LeerUsuario(cn, tx, idOperador))
                    If id > 0 Then
                        Dim anterior As Integer?
                        query = "SELECT dias_desde FROM Penalizacion WITH (UPDLOCK,HOLDLOCK) WHERE id_penalizacion=@id"
                        Using cmd As New SqlCommand(query, cn, tx)
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                            Dim valor = cmd.ExecuteScalar()
                            If valor Is Nothing Then Return False
                            anterior = If(IsDBNull(valor), CType(Nothing, Integer?), CInt(valor))
                        End Using
                        query = "SELECT COUNT(*) FROM DetallePenalizacion WITH (HOLDLOCK) WHERE id_penalizacion=@id"
                        Using cmd As New SqlCommand(query, cn, tx)
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                            reglas.ValidarCambioTramo(anterior, dias, CInt(cmd.ExecuteScalar()))
                        End Using
                    End If
                    query = If(id = 0,
                        "INSERT INTO Penalizacion(tipo_penalizacion,descripcion_penalizacion,monto_penalizacion,estado_penalizacion,dias_desde) OUTPUT INSERTED.id_penalizacion VALUES(@tipo,@descripcion,@monto,@estado,@dias)",
                        "UPDATE Penalizacion SET tipo_penalizacion=@tipo,descripcion_penalizacion=@descripcion,monto_penalizacion=@monto,estado_penalizacion=@estado,dias_desde=@dias WHERE id_penalizacion=@id")
                    Dim resultado As Boolean
                    Dim idGuardado = id
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                        cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 30).Value = tipo.Trim()
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1).Value = If(String.IsNullOrWhiteSpace(descripcion), DBNull.Value, CObj(descripcion.Trim()))
                        AgregarMonto(cmd, "@monto", monto)
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado
                        cmd.Parameters.Add("@dias", SqlDbType.Int).Value = If(dias.HasValue, CObj(dias.Value), DBNull.Value)
                        If id = 0 Then
                            idGuardado = CInt(cmd.ExecuteScalar())
                            resultado = idGuardado > 0
                        Else
                            resultado = cmd.ExecuteNonQuery() = 1
                        End If
                    End Using
                    If resultado Then AuditoriaDAO.Registrar(cn, tx, idOperador, "Penalizacion",
                        If(id = 0, "INSERT", "UPDATE"),
                        $"ID={idGuardado}; tipo={tipo.Trim()}; monto={monto:F2}; activo={estado}; desde días={If(dias.HasValue, dias.Value.ToString(), "otro motivo")}")
                    tx.Commit()
                    Return resultado
                End Using
            End Using
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "penalizacionDAO.Guardar")
        End Try
    End Function

    Public Function cambiarEstado(id As Integer, estado As Boolean, idOperador As Integer, reglas As IReglasPenalizacion) As Boolean
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction()
                    reglas.ValidarPersonal(DisponibilidadReserva.LeerUsuario(cn, tx, idOperador))
                    Dim query As String = "UPDATE Penalizacion SET estado_penalizacion=@estado WHERE id_penalizacion=@id"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado
                        Dim ok = cmd.ExecuteNonQuery() = 1
                        If ok Then AuditoriaDAO.Registrar(cn, tx, idOperador, "Penalizacion",
                            If(estado, "UPDATE", "DELETE"),
                            $"ID={id}; {If(estado, "activación", "baja lógica")}; activo={estado}")
                        tx.Commit()
                        Return ok
                    End Using
                End Using
            End Using
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "penalizacionDAO.cambiarEstado")
        End Try
    End Function

    Friend Shared Sub AgregarMonto(cmd As SqlCommand, nombre As String, monto As Decimal)
        Try
            Dim parametro = cmd.Parameters.Add(nombre, SqlDbType.Decimal)
            parametro.Precision = 7
            parametro.Scale = 2
            parametro.Value = monto
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "penalizacionDAO.AgregarMonto")
        End Try
    End Sub

End Class
