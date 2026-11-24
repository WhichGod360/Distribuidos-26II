Imports System.Data
Imports capaDatos
Imports capaDAO

Public Class categoriaNegocio

    Private ReadOnly dao As New categoriaDAO()

    Public Function listarCategoria(Optional estado As String = "Todos") As DataTable
        Try
            Return dao.listarTabla(ConvertirEstado(estado))
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo listar las categorías.", ex)
        End Try
    End Function

    Public Function listarActivas() As List(Of String)
        Try
            Return dao.listarTabla(1).AsEnumerable().
                Select(Function(f) f("nombre_categoria").ToString()).ToList()
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo listar las categorías activas.", ex)
        End Try
    End Function

    Public Function agregarCategoria(nombre As String, estado As Integer) As Boolean
        Try
            ValidarNombre(nombre)
            If estado <> 0 AndAlso estado <> 1 Then Throw New ArgumentException("Selecciona un estado válido para la categoría.")
            If NombreEnUso(nombre) Then Return False
            Dim operador As Integer = seguridadNegocio.ExigirPersonal()
            Return dao.insertar(nombre.Trim(), estado, operador)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo registrar la categoría.", ex)
        End Try
    End Function

    Public Function obtenerCategoria(id As Integer) As DataTable
        Try
            If id <= 0 Then Throw New ArgumentException("Selecciona una categoría válida.")
            Return dao.obtenerTablaPorId(id)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo obtener la categoría.", ex)
        End Try
    End Function

    Public Function actualizarCategoria(id As Integer, nombre As String, estado As Integer) As Boolean
        Try
            If id <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(id))
            ValidarNombre(nombre)
            If estado <> 0 AndAlso estado <> 1 Then Throw New ArgumentException("Selecciona un estado válido para la categoría.")
            If NombreEnUso(nombre, id) Then Return False
            Dim operador As Integer = seguridadNegocio.ExigirPersonal()
            Return dao.actualizar(id, nombre.Trim(), estado, operador)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo actualizar la categoría.", ex)
        End Try
    End Function

    Public Function buscarCategoria(nombre As String, Optional estado As String = "Todos") As DataTable
        Try
            Return dao.buscarTabla(If(nombre, "").Trim(), ConvertirEstado(estado))
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo buscar las categorías.", ex)
        End Try
    End Function

    Public Function desactivarCategoria(id As Integer) As Boolean
        Try
            If id <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(id))
            Dim operador As Integer = seguridadNegocio.ExigirPersonal()
            Return dao.desactivar(id, operador)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo desactivar la categoría.", ex)
        End Try
    End Function

    Private Function NombreEnUso(nombre As String, Optional idActual As Integer? = Nothing) As Boolean
        Try
            For Each fila As DataRow In dao.listarTabla().Rows
                Dim id = CInt(fila("id_categoria"))
                Dim existente = fila("nombre_categoria").ToString().Trim()
                If idActual.HasValue AndAlso id = idActual.Value Then Continue For
                If String.Equals(existente, nombre.Trim(), StringComparison.OrdinalIgnoreCase) Then Return True
            Next
            Return False
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo comprobar el nombre de la categoría.", ex)
        End Try
    End Function

    Private Shared Sub ValidarNombre(nombre As String)
        If String.IsNullOrWhiteSpace(nombre) Then Throw New ArgumentException("El nombre de la categoría es obligatorio.")
        If nombre.Trim().Length > 30 Then Throw New ArgumentException("El nombre de la categoría admite hasta 30 caracteres.")
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
