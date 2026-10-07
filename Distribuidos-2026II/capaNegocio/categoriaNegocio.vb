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

    Public Function obtenerCategoria(id As Integer) As DataTable
        Return dato.ObtenerPorId(id)
    End Function

    Public Function actualizarCategoria(id As Integer, nombre As String, estado As Integer) As Boolean
        Return dato.Actualizar(id, nombre, estado)
    End Function

    Public Function buscarCategoria(nombre As String) As DataTable
        Return dato.BuscarCategoria(nombre)
    End Function

End Class