Imports System.Data.SqlClient

Friend NotInheritable Class EsquemaPago
    Public Shared Sub ExigirColumna(cn As SqlConnection, Optional tx As SqlTransaction = Nothing)
        Using cmd As New SqlCommand("SELECT COL_LENGTH('dbo.DetallePenalizacion', 'estado_pago_detalle')", cn, tx)
            If IsDBNull(cmd.ExecuteScalar()) Then
                Throw New InvalidOperationException("Falta la migración 001 de estado de pago. El equipo debe aplicarla y revisar las penalizaciones anteriores antes de registrar préstamos.")
            End If
        End Using
    End Sub
End Class
