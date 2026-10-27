Imports System.Data
Imports System.Data.SqlClient
Imports capaDatos

Friend Class MoraDAO
    Friend Shared Function LeerTramos(cn As SqlConnection, tx As SqlTransaction) As List(Of Penalizacion)
        Try
            Dim lista As New List(Of Penalizacion)
            Dim query As String = "SELECT * FROM Penalizacion WITH (HOLDLOCK) WHERE dias_desde IS NOT NULL"
            Using cmd As New SqlCommand(query, cn, tx)
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        lista.Add(penalizacionDAO.Mapear(dr))
                    End While
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "MoraDAO.LeerTramos")
        End Try
    End Function

    Friend Shared Function LeerDevolucion(cn As SqlConnection, tx As SqlTransaction, id As Integer, retorno As Date, bloquear As Boolean) As DatosDevolucion
        Try
            Dim datos As New DatosDevolucion With {.FechaRetorno = retorno}
            Dim query As String = "SELECT id_prestamo,fecha_inicio_prestamo,fecha_fin_prestamo,fecha_retorno_prestamo,estado_prestamo FROM Prestamo WITH (" &
                If(bloquear, "UPDLOCK,HOLDLOCK", "HOLDLOCK") & ") WHERE id_prestamo=@id"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then datos.Prestamo = New Prestamo With {.IdPrestamo = dr.GetInt32(0), .FechaInicio = dr.GetDateTime(1), .FechaFin = dr.GetDateTime(2),
                        .FechaRetorno = If(dr.IsDBNull(3), CType(Nothing, Date?), dr.GetDateTime(3)), .EstadoPrestamo = dr.GetString(4)}
                End Using
            End Using
            query = "SELECT TOP(1) d.id_penalizacion,d.monto_aplicado,d.descripcion_detallepenalizacion FROM DetallePenalizacion d WITH (HOLDLOCK) JOIN Penalizacion p WITH (HOLDLOCK) ON p.id_penalizacion=d.id_penalizacion WHERE d.id_prestamo=@id AND p.dias_desde IS NOT NULL ORDER BY d.id_detalle_penalizacion"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then datos.CargoAnterior = New DevolucionCalculada With {.IdPenalizacion = dr.GetInt32(0), .Monto = dr.GetDecimal(1),
                        .Motivo = If(dr.IsDBNull(2), "Mora registrada anteriormente", dr.GetString(2)), .YaRegistrada = True}
                End Using
            End Using
            datos.Tramos = LeerTramos(cn, tx)
            Return datos
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "MoraDAO.LeerDevolucion")
        End Try
    End Function

    Friend Shared Sub Registrar(cn As SqlConnection, tx As SqlTransaction, calculo As DevolucionCalculada)
        Try
            Dim query As String = "INSERT INTO DetallePenalizacion(descripcion_detallepenalizacion,id_penalizacion,id_prestamo,estado_pago_detalle,monto_aplicado) VALUES(@motivo,@tipo,@prestamo,'Pendiente',@monto)"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@motivo", SqlDbType.VarChar, -1).Value = calculo.Motivo
                cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = calculo.IdPenalizacion.Value
                cmd.Parameters.Add("@prestamo", SqlDbType.Int).Value = calculo.IdPrestamo
                penalizacionDAO.AgregarMonto(cmd, "@monto", calculo.Monto)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "MoraDAO.Registrar")
        End Try
    End Sub
End Class
