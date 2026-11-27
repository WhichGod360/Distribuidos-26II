Imports System.Data
Imports System.Data.SqlClient

Public Class Conexion
    Private Shared _instancia As Conexion
    Private Shared ReadOnly _bloqueo As New Object()

    ' Transacción activa (si se inicia una)
    Private _transaccionActiva As SqlTransaction = Nothing
    Private _conexionTransaccional As SqlConnection = Nothing

    Private ReadOnly cadenaConexion As String

#If Not NET472 Then
    Private Const CadenaSomee As String =
        "workstation id=somee_distribuidos-II.mssql.somee.com;" &
        "packet size=4096;" &
        "user id=lope_SQLLogin_1;" &
        "pwd=woxcl7vth3;" &
        "data source=somee_distribuidos-II.mssql.somee.com;" &
        "persist security info=False;" &
        "initial catalog=somee_distribuidos-II;" &
        "TrustServerCertificate=True;"

#End If

    Private Sub New()
        Dim configurada = Environment.GetEnvironmentVariable("BIBLIOTECA_CONNECTION_STRING")
        If String.IsNullOrWhiteSpace(configurada) Then
            Dim archivo = Environment.GetEnvironmentVariable("BIBLIOTECA_CONNECTION_FILE")
#If NET472 Then
            If String.IsNullOrWhiteSpace(archivo) Then
                archivo = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "connection-string.txt")
            End If
#End If
            If Not String.IsNullOrWhiteSpace(archivo) AndAlso System.IO.File.Exists(archivo) Then
                configurada = System.IO.File.ReadAllText(archivo).Trim()
            End If
        End If
#If NET472 Then
        If String.IsNullOrWhiteSpace(configurada) Then Throw New InvalidOperationException("Configura la conexión SQL del servidor.")
        cadenaConexion = configurada
#Else
        cadenaConexion = If(String.IsNullOrWhiteSpace(configurada), CadenaSomee, configurada)
#End If

        ' cadenaConexion = "Data Source=.\SQLEXPRESS01;Initial Catalog=distribuidos-II;Integrated Security=SSPI;TrustServerCertificate=True;"
    End Sub

    ' Cada operación concurrente debe ser dueña de su conexión y transacción.
    Public Function CrearConexionIndependiente() As SqlConnection
        Dim cn As SqlConnection = Nothing
        Try
            cn = New SqlConnection(cadenaConexion)
            cn.Open()
            Return cn
        Catch ex As Exception
            If cn IsNot Nothing Then cn.Dispose()
            Throw
        End Try
    End Function

    ' Acceso a la instancia única
    Public Shared Function ObtenerInstancia() As Conexion
        Try
            If _instancia Is Nothing Then
                SyncLock _bloqueo
                    If _instancia Is Nothing Then
                        _instancia = New Conexion()
                    End If
                End SyncLock
            End If
            Return _instancia
        Catch ex As Exception
            Throw New InvalidOperationException("No se pudo cargar la configuración de la conexión.", ex)
        End Try
    End Function

    ''' Devuelve una conexión abierta lista para operar.
    ''' Si hay una transacción activa, devuelve la conexión de dicha transacción
    Public Function ObtenerConexion() As SqlConnection
        Try
            If EnTransaccion Then Return _conexionTransaccional
            Return CrearConexionIndependiente()
        Catch ex As Exception
            Throw New InvalidOperationException("No se pudo abrir la conexión a la base de datos.", ex)
        End Try
    End Function

    Public ReadOnly Property EnTransaccion As Boolean
        Get
            Return _transaccionActiva IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property TransaccionActual As SqlTransaction
        Get
            Return _transaccionActiva
        End Get
    End Property
    Public Sub IniciarTransaccion()
        If EnTransaccion Then Throw New InvalidOperationException("Ya existe una transacción en curso.")
        Dim cn As SqlConnection = Nothing
        Try
            cn = CrearConexionIndependiente()
            _transaccionActiva = cn.BeginTransaction()
            _conexionTransaccional = cn
        Catch ex As Exception
            If cn IsNot Nothing Then cn.Dispose()
            Throw
        End Try
    End Sub

    Public Sub ConfirmarTransaccion()
        If Not EnTransaccion Then
            Throw New InvalidOperationException("No hay ninguna transacción activa para confirmar.")
        End If

        Try
            _transaccionActiva.Commit()
        Catch ex As Exception
            Throw
        Finally
            LimpiarTransaccion()
        End Try
    End Sub

    Public Sub CancelarTransaccion()
        If Not EnTransaccion Then Exit Sub

        Try
            _transaccionActiva.Rollback()
        Catch ex As Exception
            Throw
        Finally
            LimpiarTransaccion()
        End Try
    End Sub

    Private Sub LimpiarTransaccion()
        Dim tx = _transaccionActiva
        Dim cn = _conexionTransaccional
        _transaccionActiva = Nothing
        _conexionTransaccional = Nothing
        Try
            If tx IsNot Nothing Then tx.Dispose()
        Catch ex As Exception
            Throw
        Finally
            If cn IsNot Nothing Then cn.Dispose()
        End Try
    End Sub
End Class
