Imports System.Data
Imports capaDatos
Imports capaDAO

Public Class categoriaNegocio

    Private ReadOnly dato As New categoriaDAO()

    Public Function listarCategoria() As DataTable
        Return dato.listarTabla()
    End Function

    Public Function listarActivas() As List(Of String)
        Return dato.listarTabla().AsEnumerable().Where(Function(f) f("estado").ToString() = "Activo").
            Select(Function(f) f("nombre_categoria").ToString()).ToList()
    End Function

    Public Function agregarCategoria(nombre As String, estado As Integer) As Boolean
        ValidarNombre(nombre)
        Dim tabla As DataTable = dato.listarTabla()
        For Each fila As DataRow In tabla.Rows
            If String.Equals(fila("nombre_categoria").ToString().Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase) Then
                Return False
            End If
        Next
        seguridadNegocio.ExigirPersonal()
        Return dato.insertar(nombre.Trim(), estado)
    End Function

    Public Function obtenerCategoria(id As Integer) As DataTable
        Return dato.obtenerTablaPorId(id)
    End Function

    Public Function actualizarCategoria(id As Integer, nombre As String, estado As Integer) As Boolean
        If id <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(id))
        ValidarNombre(nombre)
        Dim tabla As DataTable = dato.listarTabla()
        For Each fila As DataRow In tabla.Rows
            If CInt(fila("id_categoria")) <> id AndAlso
               String.Equals(fila("nombre_categoria").ToString().Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase) Then
                Return False
            End If
        Next
        seguridadNegocio.ExigirPersonal()
        Return dato.actualizar(id, nombre.Trim(), estado)
    End Function

    Public Function buscarCategoria(nombre As String) As DataTable
        Return dato.buscarTabla(nombre)
    End Function

    Public Function desactivarCategoria(id As Integer) As Boolean
        If id <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(id))
        seguridadNegocio.ExigirPersonal()
        Return dato.desactivar(id)
    End Function

    Private Shared Sub ValidarNombre(nombre As String)
        If String.IsNullOrWhiteSpace(nombre) Then Throw New ArgumentException("El nombre de la categoría es obligatorio.")
    End Sub

End Class
