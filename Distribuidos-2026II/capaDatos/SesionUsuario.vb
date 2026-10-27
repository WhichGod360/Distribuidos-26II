Imports System.Runtime.CompilerServices

<Assembly: InternalsVisibleTo("capaNegocio")>

Public NotInheritable Class SesionUsuario
    Private Shared ReadOnly bloqueo As New Object()
    Private Shared actual As Usuario

    Private Sub New()
    End Sub

    Friend Shared Sub Iniciar(usuario As Usuario)
        If usuario Is Nothing Then Throw New ArgumentNullException(NameOf(usuario))
        SyncLock bloqueo
            actual = New Usuario With {.IdUsuario = usuario.IdUsuario, .NombreUsuario = usuario.NombreUsuario,
                .ApPaterno = usuario.ApPaterno, .ApMaterno = usuario.ApMaterno, .NombreRol = usuario.NombreRol}
        End SyncLock
    End Sub

    Public Shared Sub Cerrar()
        SyncLock bloqueo
            actual = Nothing
        End SyncLock
    End Sub

    Public Shared ReadOnly Property IdUsuario As Integer
        Get
            SyncLock bloqueo
                Return If(actual Is Nothing, 0, actual.IdUsuario)
            End SyncLock
        End Get
    End Property

    Public Shared ReadOnly Property Rol As String
        Get
            SyncLock bloqueo
                Return If(actual Is Nothing, "", actual.NombreRol)
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
                Return If(actual Is Nothing,"",actual.NombreUsuario & " " & actual.ApPaterno & " " & actual.ApMaterno)
            End SyncLock
        End Get
    End Property
End Class
