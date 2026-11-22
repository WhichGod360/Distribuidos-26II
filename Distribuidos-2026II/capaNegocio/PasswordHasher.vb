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
        Dim salt As Byte() = NewRandomBytes(SaltSize)
        Dim derived As Byte() = Derive(password, salt, Iterations)
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
            Dim actual As Byte() = Derive(password, salt, count)
            Return EqualsFixed(actual, expected)
        Catch ex As FormatException
            Return False
        End Try
    End Function

    ' Compatibilidad temporal: Negocio verifica y solicita a DAO reemplazar el texto anterior por un hash.
    Public Shared Function VerifyLegacy(password As String, stored As String) As Boolean
        If password Is Nothing OrElse stored Is Nothing OrElse IsHash(stored) Then Return False
        Return EqualsFixed(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(stored))
    End Function

    Friend Shared Function NewRandomBytes(length As Integer) As Byte()
#If NET472 Then
        Dim bytes(length - 1) As Byte
        Using rng = RandomNumberGenerator.Create()
            rng.GetBytes(bytes)
        End Using
        Return bytes
#Else
        Return RandomNumberGenerator.GetBytes(length)
#End If
    End Function

    Private Shared Function Derive(password As String, salt As Byte(), iterations As Integer) As Byte()
#If NET472 Then
        Using pbkdf2 As New Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), salt, iterations, HashAlgorithmName.SHA256)
            Return pbkdf2.GetBytes(HashSize)
        End Using
#Else
        Return Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, iterations, HashAlgorithmName.SHA256, HashSize)
#End If
    End Function

    Private Shared Function EqualsFixed(a As Byte(), b As Byte()) As Boolean
#If NET472 Then
        If a.Length = 0 OrElse b.Length = 0 Then Return a.Length = b.Length
        Dim diferencia = a.Length Xor b.Length
        For i = 0 To Math.Max(a.Length, b.Length) - 1
            diferencia = diferencia Or (a(i Mod a.Length) Xor b(i Mod b.Length))
        Next
        Return diferencia = 0
#Else
        Return CryptographicOperations.FixedTimeEquals(a, b)
#End If
    End Function
End Class
