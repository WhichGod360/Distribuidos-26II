Imports System.Data.SqlClient

Friend NotInheritable Class EsquemaPago
    Public Shared Sub ExigirColumna(cn As SqlConnection, Optional tx As SqlTransaction = Nothing)
        Try
            Dim queryConsulta1 As String = "SELECT COL_LENGTH('dbo.DetallePenalizacion', 'estado_pago_detalle')"
            Using cmd As New SqlCommand(queryConsulta1, cn, tx)
                If IsDBNull(cmd.ExecuteScalar()) Then
                    Throw New InvalidOperationException("Falta el estado de pago de las penalizaciones. Aplica la actualización 002 y revisa los pagos anteriores antes de registrar préstamos.")
                End If
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "EsquemaPago.ExigirColumna")
        End Try
    End Sub
End Class
