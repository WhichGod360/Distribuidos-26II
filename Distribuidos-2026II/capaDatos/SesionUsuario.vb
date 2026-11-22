Imports System.Runtime.CompilerServices

<Assembly: InternalsVisibleTo("capaNegocio")>

Public Interface IAlmacenSesionUsuario
    Property Actual As Usuario
End Interface

Public NotInheritable Class SesionUsuario
    Private Shared ReadOnly bloqueo As New Object()
    Private Shared actual As Usuario
    Private Shared almacen As IAlmacenSesionUsuario

    Private Sub New()
    End Sub

    Public Shared Sub ConfigurarAlmacen(nuevo As IAlmacenSesionUsuario)
        SyncLock bloqueo
            almacen = nuevo
        End SyncLock
    End Sub

    Private Shared Function UsuarioActual() As Usuario
        Return If(almacen Is Nothing, actual, almacen.Actual)
    End Function

    Friend Shared Sub Iniciar(usuario As Usuario)
        If usuario Is Nothing Then Throw New ArgumentNullException(NameOf(usuario))
        SyncLock bloqueo
            Dim identidad = New Usuario With {.IdUsuario = usuario.IdUsuario, .NombreUsuario = usuario.NombreUsuario,
                .ApPaterno = usuario.ApPaterno, .ApMaterno = usuario.ApMaterno, .NombreRol = usuario.NombreRol}
            If almacen Is Nothing Then
                actual = identidad
            Else
                almacen.Actual = identidad
            End If
        End SyncLock
    End Sub

    Public Shared Sub Cerrar()
        SyncLock bloqueo
            If almacen Is Nothing Then
                actual = Nothing
            Else
                almacen.Actual = Nothing
            End If
        End SyncLock
    End Sub

    Public Shared ReadOnly Property IdUsuario As Integer
        Get
            SyncLock bloqueo
                Dim usuario = UsuarioActual()
                Return If(usuario Is Nothing, 0, usuario.IdUsuario)
            End SyncLock
        End Get
    End Property

    Public Shared ReadOnly Property Rol As String
        Get
            SyncLock bloqueo
                Dim usuario = UsuarioActual()
                Return If(usuario Is Nothing, "", usuario.NombreRol)
            End SyncLock
        End Get
    End Property

    Public Shared ReadOnly Property EsPersonal As Boolean
        Get
            Return IdUsuario > 0 AndAlso (String.Equals(Rol, "Administrador", StringComparison.OrdinalIgnoreCase) OrElse
                String.Equals(Rol, "Bibliotecario", StringComparison.OrdinalIgnoreCase))
        End Get
    End Property

    Public Shared ReadOnly Property NombreCompleto As String
        Get
            SyncLock bloqueo
                Dim usuario = UsuarioActual()
                Return If(usuario Is Nothing,"",usuario.NombreUsuario & " " & usuario.ApPaterno & " " & usuario.ApMaterno)
            End SyncLock
        End Get
    End Property
End Class
