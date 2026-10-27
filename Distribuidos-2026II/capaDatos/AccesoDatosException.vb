Public Class AccesoDatosException
    Inherits InvalidOperationException

    Public ReadOnly Property NumeroSql As Integer
    Public ReadOnly Property Operacion As String

    Public Sub New(mensaje As String, numero As Integer, operacion As String, causa As Exception)
        MyBase.New(mensaje, causa)
        NumeroSql = numero
        Me.Operacion = operacion
    End Sub
End Class
