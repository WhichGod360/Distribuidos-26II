Imports capaNegocio
Imports Utiles

Public Class frmPagosYape
    Private ReadOnly negocio As New pagoYapeNegocio()
    Private reportes As DataTable

    Public Sub New()
        InitializeComponent()
        If ContextoDiseno.Activo(Me) Then Return
        cboEstado.DisplayMember = "Value"
        cboEstado.ValueMember = "Key"
        cboEstado.DataSource = New KeyValuePair(Of String, String)() {
            New KeyValuePair(Of String, String)("EnRevision", "En revisión"),
            New KeyValuePair(Of String, String)("Confirmado", "Confirmados"),
            New KeyValuePair(Of String, String)("Denegado", "Denegados"),
            New KeyValuePair(Of String, String)("", "Todos")}
    End Sub

    Private Sub Recargar(sender As Object, e As EventArgs) Handles MyBase.Load, cboEstado.SelectedIndexChanged, btnActualizar.Click
        CargarReportes()
    End Sub

    Private Sub BuscarReportes(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        MostrarFilas()
    End Sub

    Private Sub ActualizarSeleccion(sender As Object, e As EventArgs) Handles tablaReportes.SelectionChanged
        btnAbrirReporte.Enabled = tablaReportes.SelectedRows.Count > 0
    End Sub

    Private Sub AbrirConClic(sender As Object, e As EventArgs) Handles btnAbrirReporte.Click
        AbrirReporte()
    End Sub

    Private Sub AbrirConDobleClic(sender As Object, e As DataGridViewCellEventArgs) Handles tablaReportes.CellDoubleClick
        If e.RowIndex >= 0 Then AbrirReporte()
    End Sub

    Private Sub CargarReportes()
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        Try
            seguridadNegocio.ExigirPersonal()
            If Not negocio.Disponible() Then
                Limpiar("La revisión de Yape se habilita al aplicar su migración en la base de Lecturae.")
                Return
            End If
            reportes = negocio.Bandeja(CStr(cboEstado.SelectedValue))
            MostrarFilas()
        Catch ex As Exception
            Limpiar(ex.Message)
        End Try
    End Sub

    Private Sub Limpiar(mensaje As String)
        reportes = Nothing
        tablaReportes.Rows.Clear()
        btnAbrirReporte.Enabled = False
        lblResumen.Text = mensaje
    End Sub

    Private Sub MostrarFilas()
        If reportes Is Nothing Then Return
        Dim criterio = txtBuscar.Text.Trim()
        tablaReportes.Rows.Clear()
        For Each reporte As DataRow In reportes.Rows
            Dim id = reporte.Field(Of Integer)("IdPago")
            Dim cargo = reporte.Field(Of Integer)("IdDetalle")
            Dim lector = reporte.Field(Of String)("Lector")
            If criterio.Length > 0 AndAlso $"{id} {cargo} {lector}".IndexOf(criterio, StringComparison.OrdinalIgnoreCase) < 0 Then Continue For
            tablaReportes.Rows.Add(id, cargo, lector, reporte.Field(Of Decimal)("Monto"), reporte.Field(Of Date)("FechaReporte"), reporte.Field(Of String)("Estado"))
        Next
        tablaReportes.ClearSelection()
        btnAbrirReporte.Enabled = False
        lblResumen.Text = If(tablaReportes.Rows.Count = 0, "No hay reportes que coincidan con el filtro.", $"{tablaReportes.Rows.Count} reporte(s)")
    End Sub

    Private Sub AbrirReporte()
        If tablaReportes.SelectedRows.Count = 0 Then Return
        Try
            Dim id = CInt(tablaReportes.SelectedRows(0).Cells(0).Value)
            Dim reporte = negocio.Reporte(id)
            If reporte Is Nothing Then Throw New InvalidOperationException("El reporte ya no está disponible.")
            Using detalle As New frmDecisionPagoYape(id, reporte)
                MantenimientoUI.MostrarDialogo(detalle, Me)
            End Using
            CargarReportes()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class
