Imports System.Data
Imports System.Text.RegularExpressions
Imports capaDatos

Public Class pagoYapeNegocio
    Private ReadOnly dao As New pagoYapeDAO()

    Public Shared Function ModoDemoSolicitado() As Boolean
        Return Environment.GetEnvironmentVariable("BIBLIOTECA_PAGO_DEMO") = "1"
    End Function

    Public Function Disponible() As Boolean
        Return dao.Disponible()
    End Function

    Public Function DemoDisponible() As Boolean
        Return dao.DemoDisponible()
    End Function

    Public Function CargoMio(id As Integer) As DataRow
        ValidarId(id)
        Dim cargo = dao.CargoDelLector(id, seguridadNegocio.ExigirLector())
        If cargo Is Nothing Then Throw New InvalidOperationException("El cargo no está disponible para tu cuenta.")
        Return cargo
    End Function

    Public Function HistorialMio(id As Integer) As DataTable
        ValidarId(id)
        Return dao.Historial(id, seguridadNegocio.ExigirLector())
    End Function

    Public Function Bandeja(estado As String) As DataTable
        seguridadNegocio.ExigirPersonal()
        If Not {"", "EnRevision", "Confirmado", "Denegado"}.Contains(estado) Then Throw New ArgumentException("Selecciona un estado válido.")
        Return dao.Bandeja(estado)
    End Function

    Public Function Reporte(id As Integer) As DataRow
        seguridadNegocio.ExigirPersonal()
        ValidarId(id)
        Return dao.Reporte(id)
    End Function

    Public Function AvisosMios() As List(Of AvisoLector)
        Dim lector = seguridadNegocio.ExigirLector()
        Return dao.Decisiones(lector).AsEnumerable().Select(
            Function(fila)
                Dim confirmado = fila.Field(Of String)("Estado") = "Confirmado"
                Dim detalle = $"Reporte N.º {fila.Field(Of Integer)("IdPago")} · Cargo N.º {fila.Field(Of Integer)("IdDetalle")}. "
                detalle &= If(confirmado, "El cargo figura como pagado.", fila.Field(Of String)("Motivo"))
                Return New AvisoLector With {
                    .Asunto = If(confirmado, "Pago por Yape confirmado", "Pago por Yape denegado"), .Detalle = detalle}
            End Function).ToList()
    End Function

    Public Sub Registrar(id As Integer, importe As Decimal, nombre As String, celular As String, codigo As String)
        If ModoDemoSolicitado() Then Throw New InvalidOperationException("Los reportes de Yape están deshabilitados en la demostración.")
        Dim lector = seguridadNegocio.ExigirLector()
        ValidarId(id)
        ValidarImporte(importe)
        nombre = If(nombre, "").Trim()
        celular = If(celular, "").Trim()
        codigo = If(codigo, "").Trim()
        If nombre.Length = 0 OrElse nombre.Length > 120 Then Throw New ArgumentException("Ingresa el nombre del comprobante de Yape.")
        If Not Regex.IsMatch(celular, "\A9[0-9]{8}\z") Then Throw New ArgumentException("Ingresa el celular de nueve dígitos del remitente.")
        If Not Regex.IsMatch(codigo, "\A[0-9]{3}\z") Then Throw New ArgumentException("Ingresa el código de tres dígitos que figura en el comprobante.")
        dao.Registrar(id, lector, importe, nombre, celular, codigo)
    End Sub

    Public Sub Revisar(id As Integer, confirmar As Boolean, motivo As String)
        Dim revisor = seguridadNegocio.ExigirPersonal()
        ValidarId(id)
        motivo = If(motivo, "").Trim()
        If Not confirmar AndAlso (motivo.Length = 0 OrElse motivo.Length > 255) Then
            Throw New ArgumentException("Escribe un motivo de denegación de hasta 255 caracteres.")
        End If
        dao.Revisar(id, revisor, confirmar, motivo)
    End Sub

    ' La web valida el comprobante firmado antes de llamar a esta operación de prueba.
    Public Function ConfirmarDemo(id As Integer, lector As Integer, importe As Decimal, transaccion As Guid) As Boolean
        ValidarId(id)
        If lector <= 0 OrElse transaccion = Guid.Empty Then Throw New ArgumentException("El QR de demostración no es válido.")
        ValidarImporte(importe)
        If Not DemoDisponible() Then Throw New UnauthorizedAccessException("La demostración está deshabilitada.")
        Return dao.ConfirmarDemo(id, lector, importe, transaccion)
    End Function

    Private Shared Sub ValidarId(id As Integer)
        If id <= 0 Then Throw New ArgumentException("Selecciona un registro válido.")
    End Sub

    Private Shared Sub ValidarImporte(importe As Decimal)
        If importe <= 0D OrElse importe > 99999.99D OrElse Decimal.Round(importe, 2) <> importe Then
            Throw New ArgumentException("El importe del pago no es válido.")
        End If
    End Sub
End Class
