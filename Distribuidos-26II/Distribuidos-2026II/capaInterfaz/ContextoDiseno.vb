Imports System.ComponentModel

Friend NotInheritable Class ContextoDiseno
    Private Sub New()
    End Sub

    Public Shared Function Activo(control As Control) As Boolean
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return True
        Dim actual = control
        While actual IsNot Nothing
            If actual.Site IsNot Nothing AndAlso actual.Site.DesignMode Then Return True
            actual = actual.Parent
        End While
        Return False
    End Function
End Class
