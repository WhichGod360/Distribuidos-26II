Imports System.Data
Imports capaDatos

Public Class categoriaNegocio

    Private dato As New categoriaDato()

    Public Function listarCategoria() As DataTable
        Return dato.Listar()
    End Function

    Public Function agregarCategoria(nombre As String, estado As Integer) As Boolean
        Dim tabla As DataTable = dato.Listar()
        For Each fila As DataRow In tabla.Rows
            If fila("nombre_categoria").ToString().ToLower() = nombre.ToLower() Then
                Return False
            End If
        Next
        dato.Insertar(nombre, estado)
        Return True
    End Function

End Class