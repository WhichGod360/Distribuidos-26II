Imports System.Data
Imports System.Data.SqlClient

Friend NotInheritable Class LecturaDAO
    Private Sub New()
    End Sub

    Friend Shared Function PatronContiene(texto As String) As String
        Dim literal = If(texto, "").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]")
        Return "%" & literal & "%"
    End Function

    Friend Shared Sub CargarTabla(dr As SqlDataReader, tabla As DataTable)
        Try
            For indice As Integer = 0 To dr.FieldCount - 1
                tabla.Columns.Add(dr.GetName(indice), dr.GetFieldType(indice))
            Next
            While dr.Read()
                Dim valores(dr.FieldCount - 1) As Object
                dr.GetValues(valores)
                tabla.Rows.Add(valores)
            End While
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "LecturaDAO.CargarTabla")
        End Try
    End Sub
End Class
