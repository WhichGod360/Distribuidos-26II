Imports capaDatos

Public Class penalizacionNegocio
    Private ReadOnly dao As New penalizacionDAO()
    Private ReadOnly reglas As IReglasPenalizacion = New reglasPenalizacionNegocio()

    Public Function listarTodos() As List(Of Penalizacion)
        Try
            seguridadNegocio.ExigirPersonal()
            Return dao.listarTodos()
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo listar los tipos de penalización.", ex)
        End Try
    End Function

    Public Function buscar(texto As String, estado As Boolean?) As List(Of Penalizacion)
        Try
            seguridadNegocio.ExigirPersonal()
            Return dao.buscar(texto, estado)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo buscar los tipos de penalización.", ex)
        End Try
    End Function

    Public Function buscarPorId(idPenalizacion As Integer) As Penalizacion
        Try
            If idPenalizacion <= 0 Then Throw New ArgumentException("Selecciona un tipo de penalización válido.")
            seguridadNegocio.ExigirPersonal()
            Return dao.buscarPorId(idPenalizacion)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo obtener el tipo de penalización.", ex)
        End Try
    End Function

    Public Function agregarPenalizacion(tipo As String, descripcion As String, monto As Decimal, estado As Boolean, Optional diasDesde As Integer? = Nothing) As Boolean
        Try
            Dim operador = seguridadNegocio.ExigirPersonal()
            Validar(tipo, monto, diasDesde)
            Return dao.agregarPenalizacion(tipo, descripcion, monto, estado, operador, reglas, diasDesde)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo registrar el tipo de penalización.", ex)
        End Try
    End Function

    Public Function actualizarPenalizacion(idPenalizacion As Integer, tipo As String, descripcion As String, monto As Decimal, estado As Boolean, Optional diasDesde As Integer? = Nothing) As Boolean
        Try
            If idPenalizacion <= 0 Then Throw New ArgumentException("Selecciona un tipo de penalización válido.")
            Dim operador = seguridadNegocio.ExigirPersonal()
            Validar(tipo, monto, diasDesde)
            If Not dao.actualizarPenalizacion(idPenalizacion, tipo, descripcion, monto, estado, operador, reglas, diasDesde) Then
                Throw New InvalidOperationException("El tipo ya no existe.")
            End If
            Return True
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo actualizar el tipo de penalización.", ex)
        End Try
    End Function

    Public Function cambiarEstado(idPenalizacion As Integer, estado As Boolean) As Boolean
        Try
            If idPenalizacion <= 0 Then Throw New ArgumentException("Selecciona un tipo de penalización válido.")
            Dim operador = seguridadNegocio.ExigirPersonal()
            Return dao.cambiarEstado(idPenalizacion, estado, operador, reglas)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudo cambiar el estado del tipo de penalización.", ex)
        End Try
    End Function
    Public Function listarActivas() As List(Of Penalizacion)
        Try
            Return buscar("", True)
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw New Exception("No se pudieron listar las penalizaciones activas.", ex)
        End Try
    End Function

    Public Shared Sub Validar(tipo As String, monto As Decimal, dias As Integer?)
        If String.IsNullOrWhiteSpace(tipo) OrElse tipo.Trim().Length > 30 Then Throw New ArgumentException("Ingresa un tipo de hasta 30 caracteres.")
        If monto < 0 OrElse monto > 99999.99D OrElse Decimal.Round(monto, 2) <> monto Then Throw New ArgumentException("El monto debe estar entre 0 y 99999.99, con hasta dos decimales.")
        If dias.HasValue AndAlso dias.Value < 1 Then Throw New ArgumentException("El tramo empieza como mínimo en un día de retraso.")
    End Sub

    Public Shared Function ElegirTramo(tramos As IEnumerable(Of Penalizacion), dias As Integer) As Penalizacion
        Return tramos.Where(Function(t) t.EstadoPenalizacion AndAlso t.DiasDesde.HasValue AndAlso t.DiasDesde.Value <= dias).
            OrderByDescending(Function(t) t.DiasDesde.Value).FirstOrDefault()
    End Function
End Class
