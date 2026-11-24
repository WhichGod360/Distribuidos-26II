Imports System.Data.SqlClient
Imports System.Globalization
Imports capaDatos

Public NotInheritable Class AuditoriaDAO
    Private Sub New()
    End Sub

    Friend Shared Function Consultar(Of T)(objeto As String, accion As String, detalle As String, consulta As Func(Of T)) As T
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado = consulta()
            RegistrarEvento(actor, objeto, accion, detalle)
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "AuditoriaDAO.Consultar")
        End Try
    End Function

    Public Shared Sub RegistrarEvento(idUsuario As Integer, objeto As String, accion As String, detalle As String)
        Try
            Dim dao As New bitacoraDAO()
            dao.Registrar(Preparar(idUsuario, objeto, accion, detalle))
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "AuditoriaDAO.RegistrarEvento")
        End Try
    End Sub

    Friend Shared Sub Registrar(cn As SqlConnection, tx As SqlTransaction, idUsuario As Integer,
                               objeto As String, accion As String, detalle As String)
        Try
            Dim dao As New bitacoraDAO()
            dao.Registrar(Preparar(idUsuario, objeto, accion, detalle), cn, tx)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "AuditoriaDAO.Registrar")
        End Try
    End Sub

    Private Shared Function Preparar(idUsuario As Integer, objeto As String, accion As String, detalle As String) As Bitacora
        Dim ahora = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5))
#If NET472 Then
        Const origen As String = "Web"
#Else
        Const origen As String = "Escritorio"
#End If
        Return New Bitacora With {
            .FechaMan = ahora.Date,
            .HoraMan = ahora.ToString("HH:mm:ss", CultureInfo.InvariantCulture),
            .IdUsuario = idUsuario,
            .Objeto = objeto,
            .Accion = accion,
            .CadenaMan = origen & " | " & detalle
        }
    End Function
End Class
