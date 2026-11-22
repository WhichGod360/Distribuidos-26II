Imports System.Data
Imports System.Data.SqlClient

Public Class Conexion
    Private Shared _instancia As Conexion
    Private Shared ReadOnly _bloqueo As New Object()

    ' Transacción activa (si se inicia una)
    Private _transaccionActiva As SqlTransaction = Nothing
    Private _conexionTransaccional As SqlConnection = Nothing

    Private ReadOnly cadenaConexion As String

    Private Const CadenaSomee As String =
        "workstation id=somee_distribuidos-II.mssql.somee.com;" &
        "packet size=4096;" &
        "user id=lope_SQLLogin_1;" &
        "pwd=woxcl7vth3;" &
        "data source=somee_distribuidos-II.mssql.somee.com;" &
        "persist security info=False;" &
        "initial catalog=somee_distribuidos-II;" &
        "TrustServerCertificate=True;"

    Private Sub New()
        ' Conexión activa: SQL Server remoto de Somee.
        ' o comentas una o comentas otra según donde quieras conectarte.

        Dim configurada = Environment.GetEnvironmentVariable("BIBLIOTECA_CONNECTION_STRING")
        If String.IsNullOrWhiteSpace(configurada) Then
            Dim archivo = Environment.GetEnvironmentVariable("BIBLIOTECA_CONNECTION_FILE")
            If Not String.IsNullOrWhiteSpace(archivo) AndAlso System.IO.File.Exists(archivo) Then
                configurada = System.IO.File.ReadAllText(archivo).Trim()
            End If
        End If
        cadenaConexion = If(String.IsNullOrWhiteSpace(configurada), CadenaSomee, configurada)

        ' cadenaConexion = "Data Source=.\SQLEXPRESS01;Initial Catalog=distribuidos-II;Integrated Security=SSPI;TrustServerCertificate=True;"
    End Sub

    Public Function AdmitePagoDemo() As Boolean
        If Environment.GetEnvironmentVariable("BIBLIOTECA_PAGO_DEMO") <> "1" Then Return False
        Dim configuracion As New SqlConnectionStringBuilder(cadenaConexion)
        Return configuracion.IntegratedSecurity AndAlso
            String.Equals(configuracion.DataSource, "(localdb)\MSSQLLocalDB", StringComparison.OrdinalIgnoreCase) AndAlso
            (String.Equals(configuracion.InitialCatalog, "LecturaePruebas", StringComparison.OrdinalIgnoreCase) OrElse
             configuracion.InitialCatalog.StartsWith("LecturaePruebas_", StringComparison.OrdinalIgnoreCase))
    End Function

    ' Cada operación concurrente debe ser dueña de su conexión y transacción.
    Public Function CrearConexionIndependiente() As SqlConnection
        Dim cn As New SqlConnection(cadenaConexion)
        Try
            cn.Open()
            Return cn
        Catch
            cn.Dispose()
            Throw
        End Try
    End Function

    ' Acceso a la instancia única
    Public Shared Function ObtenerInstancia() As Conexion
        If _instancia Is Nothing Then
            SyncLock _bloqueo
                If _instancia Is Nothing Then
                    _instancia = New Conexion()
                End If
            End SyncLock
        End If
        Return _instancia
    End Function

    ''' Devuelve una conexión abierta lista para operar.
    ''' Si hay una transacción activa, devuelve la conexión de dicha transacción
    Public Function ObtenerConexion() As SqlConnection
        If EnTransaccion Then
            Return _conexionTransaccional
        End If

        Dim cn As New SqlConnection(cadenaConexion)
        If cn.State <> ConnectionState.Open Then
            cn.Open()
        End If
        Return cn
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
        If EnTransaccion Then
            Throw New InvalidOperationException("Ya existe una transacción en curso.")
        End If

        _conexionTransaccional = New SqlConnection(cadenaConexion)
        _conexionTransaccional.Open()
        _transaccionActiva = _conexionTransaccional.BeginTransaction()
    End Sub

    Public Sub ConfirmarTransaccion()
        If Not EnTransaccion Then
            Throw New InvalidOperationException("No hay ninguna transacción activa para confirmar.")
        End If

        Try
            _transaccionActiva.Commit()
        Finally
            LimpiarTransaccion()
        End Try
    End Sub

    Public Sub CancelarTransaccion()
        If Not EnTransaccion Then Exit Sub

        Try
            _transaccionActiva.Rollback()
        Finally
            LimpiarTransaccion()
        End Try
    End Sub

    Private Sub LimpiarTransaccion()
        If _transaccionActiva IsNot Nothing Then
            _transaccionActiva.Dispose()
            _transaccionActiva = Nothing
        End If

        If _conexionTransaccional IsNot Nothing Then
            If _conexionTransaccional.State = ConnectionState.Open Then
                _conexionTransaccional.Close()
            End If
            _conexionTransaccional.Dispose()
            _conexionTransaccional = Nothing
        End If
    End Sub
End Class
