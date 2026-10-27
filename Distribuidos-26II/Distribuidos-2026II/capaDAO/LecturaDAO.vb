Imports System.Data
Imports System.Data.SqlClient

Friend NotInheritable Class LecturaDAO
    Private Sub New()
    End Sub

    Friend Shared Sub CargarTabla(dr As SqlDataReader, tabla As DataTable)
        For indice As Integer = 0 To dr.FieldCount - 1
            tabla.Columns.Add(dr.GetName(indice), dr.GetFieldType(indice))
        Next
        While dr.Read()
            Dim valores(dr.FieldCount - 1) As Object
            dr.GetValues(valores)
            tabla.Rows.Add(valores)
        End While
    End Sub
End Class
