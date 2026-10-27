Public Class Usuario
    Public Property IdUsuario As Integer
    Public Property EmailUsuario As String
    Public Property NombreUsuario As String
    Public Property ApPaterno As String
    Public Property ApMaterno As String
    Public Property NumeroDniUsuario As String
    Public Property FechaNacimientoUsuario As Date?
    Public Property GeneroUsuario As Boolean?
    Public Property EstadoUsuario As String
    Public Property Contrasena As String
    Public Property IdRolUsuario As Integer
    Public Property PreguntaSegura As String
    Public Property RptaSegura As String

    Public Property NombreRol As String

    Public ReadOnly Property NombreCompleto As String
        Get
            Return $"{NombreUsuario} {ApPaterno} {ApMaterno}".Trim()
        End Get
    End Property
End Class