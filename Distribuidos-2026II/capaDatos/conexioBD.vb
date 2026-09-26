Imports System.Data
Imports System.Data.SqlClient

Public Class Conexion
    Private Shared _instancia As Conexion
    Private Shared ReadOnly _bloqueo As New Object()

    ' Transacción activa (si se inicia una)
    Private _transaccionActiva As SqlTransaction = Nothing
    Private _conexionTransaccional As SqlConnection = Nothing

    Private ReadOnly cadenaConexion As String =
        "Data Source=.\SQLEXPRESS;" &
        "Initial Catalog=distribuidos-II;" &
        "Integrated Security=SSPI;" &
        "TrustServerCertificate=True;"
    Private Sub New()
    End Sub

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