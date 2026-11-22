Imports System.Data.SqlClient
Imports System.Globalization
Imports capaDatos

Public NotInheritable Class AuditoriaDAO
    Private Sub New()
    End Sub

    Friend Shared Function Consultar(Of T)(objeto As String, accion As String, detalle As String, consulta As Func(Of T)) As T
        Dim actor = SesionUsuario.IdUsuario
        Dim resultado = consulta()
        RegistrarEvento(actor, objeto, accion, detalle)
        Return resultado
    End Function

    Public Shared Sub RegistrarEvento(idUsuario As Integer, objeto As String, accion As String, detalle As String)
        Dim dao As New bitacoraDAO()
        dao.Registrar(Preparar(idUsuario, objeto, accion, detalle))
    End Sub

    Friend Shared Sub Registrar(cn As SqlConnection, tx As SqlTransaction, idUsuario As Integer,
                               objeto As String, accion As String, detalle As String)
        Dim dao As New bitacoraDAO()
        dao.Registrar(Preparar(idUsuario, objeto, accion, detalle), cn, tx)
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
