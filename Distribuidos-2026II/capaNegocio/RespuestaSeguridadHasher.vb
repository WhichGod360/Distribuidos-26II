Imports System.Text

' La pregunta se muestra al lector; solo su respuesta se almacena como hash.
Public NotInheritable Class RespuestaSeguridadHasher
    Private Sub New()
    End Sub

    Public Shared Function Hash(respuesta As String) As String
        Return PasswordHasher.Hash(Normalizar(respuesta))
    End Function

    Public Shared Function Verify(respuesta As String, almacenada As String) As Boolean
        If String.IsNullOrWhiteSpace(respuesta) Then Return False
        Return PasswordHasher.Verify(Normalizar(respuesta), almacenada)
    End Function

    Private Shared Function Normalizar(respuesta As String) As String
        If String.IsNullOrWhiteSpace(respuesta) Then Throw New ArgumentException("Ingresa la respuesta de seguridad.")
        Return respuesta.Trim().Normalize(NormalizationForm.FormKC).ToUpperInvariant()
    End Function
End Class
