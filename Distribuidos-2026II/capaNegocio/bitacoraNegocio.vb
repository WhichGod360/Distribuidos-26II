Imports capaDatos

Public Class bitacoraNegocio
    Private ReadOnly dao As New bitacoraDAO()

    Public Function Listar(Optional fechaDesde As Date? = Nothing,
                           Optional fechaHasta As Date? = Nothing,
                           Optional idUsuario As Integer? = Nothing,
                           Optional objeto As String = Nothing,
                           Optional accion As String = Nothing,
                           Optional despuesDeId As Integer? = Nothing) As List(Of Bitacora)
        Try
            seguridadNegocio.ExigirAdministrador()
            If fechaDesde.HasValue Then fechaDesde = fechaDesde.Value.Date
            If fechaHasta.HasValue Then fechaHasta = fechaHasta.Value.Date
            If fechaDesde.HasValue AndAlso fechaHasta.HasValue AndAlso fechaDesde.Value > fechaHasta.Value Then
                Throw New ArgumentException("La fecha inicial no puede ser posterior a la fecha final.")
            End If
            If idUsuario.HasValue AndAlso idUsuario.Value < 0 Then
                Throw New ArgumentException("El ID del usuario debe ser cero o un número positivo.")
            End If
            If despuesDeId.HasValue AndAlso despuesDeId.Value < 0 Then
                Throw New ArgumentException("El último ID de la bitácora no puede ser negativo.")
            End If

            Dim objetoMan As String = NormalizarObjeto(objeto)
            Dim accionMan As String = NormalizarAccion(accion)
            Return dao.Listar(fechaDesde, fechaHasta, idUsuario, objetoMan, accionMan, despuesDeId)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar la bitácora.", ex)
        End Try
    End Function

    Public Function ObtenerPorId(idMan As Integer) As Bitacora
        Try
            seguridadNegocio.ExigirAdministrador()
            If idMan <= 0 Then Throw New ArgumentException("El ID del movimiento debe ser un número positivo.")
            Return dao.ObtenerPorId(idMan)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("Ocurrió un error al consultar el movimiento de la bitácora.", ex)
        End Try
    End Function

    Private Shared Function NormalizarObjeto(objeto As String) As String
        If String.IsNullOrWhiteSpace(objeto) Then
            Return Nothing
        End If

        Dim nombre As String = objeto.Trim()
        If nombre.Length > 30 Then Throw New ArgumentException("El objeto de la bitácora admite hasta 30 caracteres.")
        Return nombre
    End Function

    Private Shared Function NormalizarAccion(accion As String) As String
        If String.IsNullOrWhiteSpace(accion) Then
            Return Nothing
        End If

        Select Case accion.Trim().ToUpperInvariant()
            Case "1", "INSERT"
                Return "INSERT"
            Case "2", "UPDATE"
                Return "UPDATE"
            Case "3", "DELETE"
                Return "DELETE"
            Case "4", "SELECT"
                Return "SELECT"
            Case "5", "BUSQUEDA", "BÚSQUEDA"
                Return "BUSQUEDA"
            Case "6", "LISTADO"
                Return "LISTADO"
            Case Else
                Throw New ArgumentException("La acción debe ser INSERT, UPDATE, DELETE, SELECT, BUSQUEDA o LISTADO.")
        End Select
    End Function
End Class
