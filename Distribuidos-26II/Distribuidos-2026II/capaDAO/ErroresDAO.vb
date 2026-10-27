Imports System.Data.SqlClient
Imports capaDatos

Friend NotInheritable Class ErroresDAO
    Private Sub New()
    End Sub

    Friend Shared Function Traducir(ex As SqlException, operacion As String) As AccesoDatosException
        Dim mensaje As String
        Select Case ex.Number
            Case 2601, 2627
                mensaje = "Ya existe un registro con esos datos. Revisa los valores que deben ser únicos."
            Case 547
                mensaje = "No se puede guardar el cambio porque está relacionado con otros registros o incumple una validación de la base de datos."
            Case 1205, 1222
                mensaje = "La operación coincidió con otro cambio. Actualiza los datos e intenta nuevamente."
            Case -2
                mensaje = "La base de datos tardó demasiado en responder. Intenta nuevamente."
            Case 53, 17, 4060, 18456
                mensaje = "No se pudo conectar con la base de datos. Revisa la conexión y los permisos."
            Case Else
                mensaje = "No se pudo completar la operación en la base de datos. Revisa la conexión o consulta al administrador."
        End Select
        Return New AccesoDatosException(mensaje, ex.Number, operacion, ex)
    End Function
End Class
