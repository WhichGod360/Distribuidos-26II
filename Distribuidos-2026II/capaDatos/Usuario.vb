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

    ' Propiedad auxiliar para guardar el texto del rol traído desde RolUsuario (INNER JOIN)
    Public Property NombreRol As String

    ' Propiedad de solo lectura para mostrar el nombre completo en pantalla
    Public ReadOnly Property NombreCompleto As String
        Get
            Return $"{NombreUsuario} {ApPaterno} {ApMaterno}".Trim()
        End Get
    End Property
End Class
