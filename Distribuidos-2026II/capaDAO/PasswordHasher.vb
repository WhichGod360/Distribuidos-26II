Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text

' Formato persistido: PBKDF2-SHA256$iteraciones$salBase64$hashBase64.
Public NotInheritable Class PasswordHasher
    Private Const Prefix As String = "PBKDF2-SHA256$"
    Private Const Iterations As Integer = 600000
    Private Const SaltSize As Integer = 16
    Private Const HashSize As Integer = 32

    Private Sub New()
    End Sub

    Public Shared Function Hash(password As String) As String
        If String.IsNullOrWhiteSpace(password) Then Throw New ArgumentException("Debe ingresar su contraseña.")
        Dim salt As Byte() = RandomNumberGenerator.GetBytes(SaltSize)
        Dim derived As Byte() = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, Iterations, HashAlgorithmName.SHA256, HashSize)
        Return Prefix & Iterations.ToString(CultureInfo.InvariantCulture) & "$" & Convert.ToBase64String(salt) & "$" & Convert.ToBase64String(derived)
    End Function

    Public Shared Function IsHash(stored As String) As Boolean
        Return stored IsNot Nothing AndAlso stored.StartsWith(Prefix, StringComparison.Ordinal)
    End Function

    Public Shared Function Verify(password As String, stored As String) As Boolean
        If password Is Nothing OrElse Not IsHash(stored) Then Return False
        Dim parts As String() = stored.Split("$"c)
        Dim count As Integer
        If parts.Length <> 4 OrElse Not Integer.TryParse(parts(1), NumberStyles.None, CultureInfo.InvariantCulture, count) Then Return False
        ' Limita el coste de datos corruptos antes de ejecutar PBKDF2.
        If count < 100000 OrElse count > 2000000 Then Return False
        Try
            Dim salt As Byte() = Convert.FromBase64String(parts(2))
            Dim expected As Byte() = Convert.FromBase64String(parts(3))
            If salt.Length <> SaltSize OrElse expected.Length <> HashSize Then Return False
            Dim actual As Byte() = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, count, HashAlgorithmName.SHA256, HashSize)
            Return CryptographicOperations.FixedTimeEquals(actual, expected)
        Catch ex As FormatException
            Return False
        End Try
    End Function

    ' Compatibilidad temporal: el DAO reemplaza el texto anterior por un hash.
    Public Shared Function VerifyLegacy(password As String, stored As String) As Boolean
        If password Is Nothing OrElse stored Is Nothing OrElse IsHash(stored) Then Return False
        Return CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(stored))
    End Function
End Class
