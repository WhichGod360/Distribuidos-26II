Imports System.Data
Imports System.Data.SqlClient
Imports capaDatos

Public Class pagoYapeDAO
    Private Const ConsultaCargo As String =
        "SELECT dp.id_detalle_penalizacion AS IdDetalle, dp.estado_pago_detalle AS Estado, " &
        "dp.monto_aplicado AS Monto, l.titulo_libro AS Libro " &
        "FROM dbo.DetallePenalizacion dp JOIN dbo.Prestamo p ON p.id_prestamo=dp.id_prestamo " &
        "JOIN dbo.Ejemplar e ON e.id_ejemplar=p.id_ejemplar JOIN dbo.Libro l ON l.id_libro=e.id_libro " &
        "WHERE dp.id_detalle_penalizacion=@id AND p.id_usuario=@lector"

    Public Function Disponible() As Boolean
        Return ExisteEsquema("OBJECT_ID(N'dbo.PagoWebPenalizacion',N'U') IS NOT NULL " &
                            "AND OBJECT_ID(N'dbo.RegistrarReporteYape',N'P') IS NOT NULL " &
                            "AND OBJECT_ID(N'dbo.RevisarReporteYape',N'P') IS NOT NULL " &
                            "AND OBJECT_ID(N'dbo.TR_DetallePenalizacion_ProtegerYape',N'TR') IS NOT NULL")
    End Function

    Public Function DemoDisponible() As Boolean
        If Not Conexion.ObtenerInstancia().AdmitePagoDemo() Then Return False
        Return ExisteEsquema("OBJECT_ID(N'dbo.PagoDemoPenalizacion',N'U') IS NOT NULL")
    End Function

    Private Shared Function ExisteEsquema(condicion As String) As Boolean
        Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente()
            Using cmd As New SqlCommand("SELECT CASE WHEN " & condicion & " THEN 1 ELSE 0 END", cn)
                Return CInt(cmd.ExecuteScalar()) = 1
            End Using
        End Using
    End Function

    Public Function CargoDelLector(id As Integer, lector As Integer) As DataRow
        Return PrimeraFila(Consultar($"Consultar cargo para pago | cargo={id}", ConsultaCargo, ParametroId("@id", id), ParametroId("@lector", lector)))
    End Function

    Public Function Historial(id As Integer, lector As Integer) As DataTable
        Return Consultar($"Consultar historial Yape | cargo={id}",
            "SELECT id_pago AS IdPago, monto AS Monto, CASE estado WHEN 'EnRevision' THEN N'En revisión' ELSE estado END AS Estado, " &
            "motivo_denegacion AS Motivo, DATEADD(HOUR,-5,fecha_reporte_utc) AS FechaReporte " &
            "FROM dbo.PagoWebPenalizacion WHERE id_detalle_penalizacion=@id AND id_lector=@lector ORDER BY id_pago DESC",
            ParametroId("@id", id), ParametroId("@lector", lector))
    End Function

    Public Function Bandeja(estado As String) As DataTable
        Return Consultar("Consultar bandeja de pagos Yape",
            "SELECT pa.id_pago AS IdPago, pa.id_detalle_penalizacion AS IdDetalle, " &
            "CONCAT(u.nombre_usuario,' ',u.ap_paterno,' ',u.ap_materno) AS Lector, pa.monto AS Monto, " &
            "CASE pa.estado WHEN 'EnRevision' THEN N'En revisión' ELSE pa.estado END AS Estado, " &
            "DATEADD(HOUR,-5,pa.fecha_reporte_utc) AS FechaReporte " &
            "FROM dbo.PagoWebPenalizacion pa JOIN dbo.Usuario u ON u.id_usuario=pa.id_lector " &
            "WHERE (@estado='' OR pa.estado=@estado) ORDER BY CASE WHEN pa.estado='EnRevision' THEN 0 ELSE 1 END, pa.id_pago DESC",
            Texto("@estado", SqlDbType.VarChar, 12, estado))
    End Function

    Public Function Reporte(id As Integer) As DataRow
        Return PrimeraFila(Consultar($"Consultar reporte Yape | reporte={id}",
            "SELECT pa.id_detalle_penalizacion AS IdDetalle, dp.id_prestamo AS IdPrestamo, pa.monto AS Monto, " &
            "pa.nombre_yape AS NombreYape, pa.celular_yape AS Celular, pa.codigo_yape AS Codigo, pa.estado AS Estado, " &
            "pa.motivo_denegacion AS Motivo, DATEADD(HOUR,-5,pa.fecha_revision_utc) AS FechaRevision, " &
            "CONCAT(u.nombre_usuario,' ',u.ap_paterno,' ',u.ap_materno) AS Lector, " &
            "CONCAT(r.nombre_usuario,' ',r.ap_paterno,' ',r.ap_materno) AS Revisor " &
            "FROM dbo.PagoWebPenalizacion pa JOIN dbo.DetallePenalizacion dp ON dp.id_detalle_penalizacion=pa.id_detalle_penalizacion " &
            "JOIN dbo.Usuario u ON u.id_usuario=pa.id_lector LEFT JOIN dbo.Usuario r ON r.id_usuario=pa.id_revisor " &
            "WHERE pa.id_pago=@id", ParametroId("@id", id)))
    End Function

    Public Function Decisiones(lector As Integer) As DataTable
        Return Consultar("Consultar avisos de pagos Yape",
            "SELECT id_pago AS IdPago, id_detalle_penalizacion AS IdDetalle, estado AS Estado, " &
            "motivo_denegacion AS Motivo FROM dbo.PagoWebPenalizacion " &
            "WHERE id_lector=@lector AND estado IN ('Confirmado','Denegado') ORDER BY fecha_revision_utc DESC, id_pago DESC",
            ParametroId("@lector", lector))
    End Function

    Public Sub Registrar(id As Integer, lector As Integer, importe As Decimal, nombre As String, celular As String, codigo As String)
        Ejecutar("dbo.RegistrarReporteYape", lector, "INSERT", $"Reportar pago Yape | cargo={id}",
            ParametroId("@id_lector", lector), ParametroId("@id_detalle", id), Monto("@importe_mostrado", importe),
            Texto("@nombre", SqlDbType.NVarChar, 120, nombre), Texto("@celular", SqlDbType.VarChar, 9, celular),
            Texto("@codigo", SqlDbType.VarChar, 3, codigo))
    End Sub

    Public Sub Revisar(id As Integer, revisor As Integer, confirmar As Boolean, motivo As String)
        Ejecutar("dbo.RevisarReporteYape", revisor, "UPDATE", $"{If(confirmar, "Confirmar", "Denegar")} pago Yape | reporte={id}",
            ParametroId("@id_revisor", revisor), ParametroId("@id_pago", id), New SqlParameter("@confirmar", SqlDbType.Bit) With {.Value = confirmar},
            Texto("@motivo", SqlDbType.NVarChar, 255, If(confirmar, Nothing, motivo)))
    End Sub

    Public Function ConfirmarDemo(id As Integer, lector As Integer, importe As Decimal, transaccion As Guid) As Boolean
        Dim conexionActual = Conexion.ObtenerInstancia()
        If Not conexionActual.AdmitePagoDemo() Then Throw New UnauthorizedAccessException("La simulación solo está disponible en LocalDB.")
        Try
            Using cn = conexionActual.CrearConexionIndependiente()
                Using tx = cn.BeginTransaction(IsolationLevel.Serializable)
                    Dim consulta = "SELECT 1 FROM dbo.PagoDemoPenalizacion WITH (UPDLOCK,HOLDLOCK) WHERE id_detalle_penalizacion=@id " &
                        "AND id_lector=@lector AND monto=@monto AND id_transaccion=@transaccion"
                    Using cmd As New SqlCommand(consulta, cn, tx)
                        cmd.Parameters.AddRange({ParametroId("@id", id), ParametroId("@lector", lector), Monto("@monto", importe),
                            New SqlParameter("@transaccion", SqlDbType.UniqueIdentifier) With {.Value = transaccion}})
                        If cmd.ExecuteScalar() IsNot Nothing Then Return False
                    End Using

                    Dim sql = "UPDATE dp SET estado_pago_detalle='Pagada' FROM dbo.DetallePenalizacion dp " &
                        "JOIN dbo.Prestamo p ON p.id_prestamo=dp.id_prestamo JOIN dbo.Usuario u ON u.id_usuario=p.id_usuario " &
                        "JOIN dbo.RolUsuario r ON r.id_rol_usuario=u.id_rol_usuario " &
                        "WHERE dp.id_detalle_penalizacion=@id AND dp.estado_pago_detalle='Pendiente' AND dp.monto_aplicado=@monto " &
                        "AND p.id_usuario=@lector AND u.estado_usuario='Activo' AND r.nombre_rol_usuario IN ('Estudiante','Lector')"
                    Using cmd As New SqlCommand(sql, cn, tx)
                        cmd.Parameters.AddRange({ParametroId("@id", id), ParametroId("@lector", lector), Monto("@monto", importe)})
                        If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException("El cargo cambió o ya no admite este pago de demostración.")
                    End Using

                    Using cmd As New SqlCommand("INSERT dbo.PagoDemoPenalizacion(id_detalle_penalizacion,id_lector,monto,id_transaccion) VALUES(@id,@lector,@monto,@transaccion)", cn, tx)
                        cmd.Parameters.AddRange({ParametroId("@id", id), ParametroId("@lector", lector), Monto("@monto", importe),
                            New SqlParameter("@transaccion", SqlDbType.UniqueIdentifier) With {.Value = transaccion}})
                        cmd.ExecuteNonQuery()
                    End Using
                    AuditoriaDAO.Registrar(cn, tx, lector, "PagoDemo", "UPDATE", $"SIMULACIÓN | confirmar pago | cargo={id}; importe={importe:0.00}")
                    tx.Commit()
                    Return True
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "pagoYapeDAO.ConfirmarDemo")
        End Try
    End Function

    Private Shared Function Consultar(detalle As String, sql As String, ParamArray parametros As SqlParameter()) As DataTable
        Return AuditoriaDAO.Consultar("PagoYape", "SELECT", detalle,
            Function()
                Try
                    Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                        Using cmd As New SqlCommand(sql, cn)
                            cmd.Parameters.AddRange(parametros)
                            Using dr = cmd.ExecuteReader()
                                Dim datos As New DataTable()
                                datos.Load(dr)
                                Return datos
                            End Using
                        End Using
                    End Using
                Catch ex As SqlException
                    Throw ErroresDAO.Traducir(ex, "pagoYapeDAO.Consultar")
                End Try
            End Function)
    End Function

    Private Shared Sub Ejecutar(procedimiento As String, actor As Integer, accion As String, detalle As String, ParamArray parametros As SqlParameter())
        Try
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx = cn.BeginTransaction()
                    Using cmd As New SqlCommand(procedimiento, cn, tx)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddRange(parametros)
                        cmd.ExecuteNonQuery()
                    End Using
                    AuditoriaDAO.Registrar(cn, tx, actor, "PagoYape", accion, detalle)
                    tx.Commit()
                End Using
            End Using
        Catch ex As SqlException When ex.Number >= 51001 AndAlso ex.Number <= 51006
            Throw New InvalidOperationException(ex.Message, ex)
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, procedimiento)
        End Try
    End Sub

    Private Shared Function PrimeraFila(tabla As DataTable) As DataRow
        Return If(tabla.Rows.Count = 0, Nothing, tabla.Rows(0))
    End Function

    Private Shared Function ParametroId(nombre As String, valor As Integer) As SqlParameter
        Return New SqlParameter(nombre, SqlDbType.Int) With {.Value = valor}
    End Function

    Private Shared Function Texto(nombre As String, tipo As SqlDbType, longitud As Integer, valor As String) As SqlParameter
        Return New SqlParameter(nombre, tipo, longitud) With {.Value = If(valor Is Nothing, DBNull.Value, CObj(valor))}
    End Function

    Private Shared Function Monto(nombre As String, valor As Decimal) As SqlParameter
        Return New SqlParameter(nombre, SqlDbType.Decimal) With {.Precision = 7, .Scale = 2, .Value = valor}
    End Function
End Class
