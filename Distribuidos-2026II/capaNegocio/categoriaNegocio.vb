Imports System.Data
Imports capaDatos
Imports capaDAO

Public Class categoriaNegocio

    Private ReadOnly dato As New categoriaDAO()
    Private ReadOnly bitacora As New bitacoraNegocio()

    Public Function listarCategoria(Optional estado As String = "Todos") As DataTable
        Try
            Dim filtroEstado As Integer? = ConvertirEstado(estado)
            Dim accion As String = If(filtroEstado.HasValue, "BUSQUEDA", "LISTADO")
            Return dato.listarTabla(filtroEstado, bitacora.CrearContexto("Categoria", accion))
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar las categorías.", ex)
        End Try
    End Function

    Public Function listarActivas() As List(Of String)
        Try
            Return dato.listarTabla(1, bitacora.CrearContexto("Categoria", "BUSQUEDA")).AsEnumerable().
                Select(Function(f) f("nombre_categoria").ToString()).ToList()
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar las categorías.", ex)
        End Try
    End Function

    Public Function agregarCategoria(nombre As String, estado As Integer) As Boolean
        Try
            ValidarNombre(nombre)
            Dim tabla As DataTable = dato.listarTabla()
            For Each fila As DataRow In tabla.Rows
                If String.Equals(fila("nombre_categoria").ToString().Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase) Then
                    Return False
                End If
            Next
            Dim operador As Integer = seguridadNegocio.ExigirPersonal()
            Return dato.insertar(nombre.Trim(), estado, bitacora.CrearContexto("Categoria", "INSERT", operador))
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al registrar las categorías.", ex)
        End Try
    End Function

    Public Function obtenerCategoria(id As Integer) As DataTable
        Try
            Return dato.obtenerTablaPorId(id, bitacora.CrearContexto("Categoria", "BUSQUEDA"))
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar las categorías.", ex)
        End Try
    End Function

    Public Function actualizarCategoria(id As Integer, nombre As String, estado As Integer) As Boolean
        Try
            If id <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(id))
            ValidarNombre(nombre)
            Dim tabla As DataTable = dato.listarTabla()
            For Each fila As DataRow In tabla.Rows
                If CInt(fila("id_categoria")) <> id AndAlso
                   String.Equals(fila("nombre_categoria").ToString().Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase) Then
                    Return False
                End If
            Next
            Dim operador As Integer = seguridadNegocio.ExigirPersonal()
            Return dato.actualizar(id, nombre.Trim(), estado, bitacora.CrearContexto("Categoria", "UPDATE", operador))
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al actualizar las categorías.", ex)
        End Try
    End Function

    Public Function buscarCategoria(nombre As String, Optional estado As String = "Todos") As DataTable
        Try
            Return dato.buscarTabla(nombre, ConvertirEstado(estado), bitacora.CrearContexto("Categoria", "BUSQUEDA"))
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar las categorías.", ex)
        End Try
    End Function

    Public Function desactivarCategoria(id As Integer) As Boolean
        Try
            If id <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(id))
            Dim operador As Integer = seguridadNegocio.ExigirPersonal()
            Return dato.desactivar(id, bitacora.CrearContexto("Categoria", "UPDATE", operador))
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al desactivar las categorías.", ex)
        End Try
    End Function

    Private Shared Sub ValidarNombre(nombre As String)
        If String.IsNullOrWhiteSpace(nombre) Then Throw New ArgumentException("El nombre de la categoría es obligatorio.")
    End Sub

    Private Shared Function ConvertirEstado(estado As String) As Integer?
        Select Case estado
            Case "Todos"
                Return Nothing
            Case "Activo"
                Return 1
            Case "Inactivo"
                Return 0
            Case Else
                Throw New ArgumentException("Selecciona un estado válido.")
        End Select
    End Function

End Class
