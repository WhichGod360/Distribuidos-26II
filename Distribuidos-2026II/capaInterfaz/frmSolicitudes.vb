Imports System.Threading.Tasks
Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmSolicitudes
    Implements IMantenimientoVista

    Public Event DatosCambiados()
    Private ReadOnly negocio As New solicitudPrestamoNegocio()
    Private datos As New List(Of SolicitudPrestamo)()
    Private ocupado As Boolean

    Public Sub New()
        InitializeComponent()
        cboEstado.SelectedIndex = 0
        For Each boton In {btnAprobar, btnEntregar, btnRechazar, btnActualizar,btnComprobante}
            MantenimientoUI.EstilizarBoton(boton, boton Is btnAprobar OrElse boton Is btnEntregar)
        Next
        For Each vista In {tabla, tablaDetalle}
            DataGridViewHelper.AplicarEstiloTabla(vista)
            vista.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            vista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Next
        AddHandler Load, Sub() ActualizarDatos()
        AddHandler btnActualizar.Click, Sub() ActualizarDatos()
        AddHandler txtBuscar.TextChanged, Sub() Filtrar()
        AddHandler cboEstado.SelectedIndexChanged, Sub() Filtrar()
        AddHandler tabla.SelectionChanged, Sub() MostrarDetalle()
        AddHandler btnAprobar.Click, Async Sub() Await CambiarEstadoAsync(True)
        AddHandler btnRechazar.Click, Async Sub() Await CambiarEstadoAsync(False)
        AddHandler btnEntregar.Click, AddressOf Entregar
        AddHandler btnComprobante.Click,Sub()
                                           Dim actual=Seleccionada()
                                           If actual Is Nothing Then Return
                                           Try
                                               ComprobanteImpresion.Mostrar(New comprobanteNegocio().PorSolicitud(actual.IdSolicitud),Me)
                                           Catch ex As Exception
                                               MessageBox.Show(ex.Message,"Comprobante",MessageBoxButtons.OK,MessageBoxIcon.Warning)
                                           End Try
                                       End Sub
    End Sub

    Public Async Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If ocupado OrElse ContextoDiseno.Activo(Me) OrElse IsDisposed Then Return
        Ocupacion(True)
        lblResumen.Text = "Consultando solicitudes..."
        Try
            Dim resultado = Await Task.Run(Function() negocio.listarTodas())
            If IsDisposed Then Return
            datos = resultado
        Catch ex As Exception
            datos.Clear()
            If Not IsDisposed Then MessageBox.Show(ex.Message, "Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If Not IsDisposed Then
                Ocupacion(False)
                Filtrar()
            End If
        End Try
    End Sub

    Private Sub Ocupacion(valor As Boolean)
        ocupado = valor
        txtBuscar.Enabled = Not valor
        cboEstado.Enabled = Not valor
        tabla.Enabled = Not valor
        btnActualizar.Enabled = Not valor
        UseWaitCursor = valor
        MostrarDetalle()
    End Sub

    Private Sub Filtrar()
        If ocupado Then Return
        Dim texto = txtBuscar.Text.Trim()
        Dim estado = CStr(cboEstado.SelectedItem)
        Dim lista = datos.Where(Function(s) (estado = "Todos" OrElse s.EstadoActual = estado) AndAlso
            (s.IdSolicitud & " " & s.NombreLector & " " & s.DniLector & " " & s.Libros).IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
        tabla.DataSource = lista.Select(Function(s) New With {.Solicitud = s.IdSolicitud, .Lector = s.NombreLector,
            .DNI = s.DniLector, .Libros = s.Libros, .Estado = s.EstadoActual,
            .RecojoHasta = s.LimiteLocal.ToString("dd/MM/yyyy HH:mm"), .AprobadaPor = s.NombreAprobador}).ToList()
        If tabla.Columns.Contains("RecojoHasta") Then tabla.Columns("RecojoHasta").HeaderText = "Recoger hasta (Lima)"
        If tabla.Columns.Contains("AprobadaPor") Then tabla.Columns("AprobadaPor").HeaderText = "Aprobada por"
        tabla.ClearSelection()
        MostrarDetalle()
        lblResumen.Text = lista.Count & " solicitud(es) · Selecciona una solicitud para ver sus libros · Horario de Lima"
    End Sub

    Private Function Seleccionada() As SolicitudPrestamo
        If tabla.SelectedRows.Count = 0 OrElse Not tabla.Columns.Contains("Solicitud") Then Return Nothing
        Dim id = CInt(tabla.SelectedRows(0).Cells("Solicitud").Value)
        Return datos.FirstOrDefault(Function(s) s.IdSolicitud = id)
    End Function

    Private Sub MostrarDetalle()
        Dim solicitud = Seleccionada()
        tablaDetalle.DataSource = If(solicitud Is Nothing, Nothing, solicitud.Detalles.Select(Function(d) New With {
            .Libro = d.TituloLibro, .Prestamo = If(d.IdPrestamo.HasValue, d.IdPrestamo.Value.ToString(), "Sin entregar")}).ToList())
        btnAprobar.Enabled = Not ocupado AndAlso solicitudPrestamoNegocio.PuedeAprobar(solicitud)
        btnEntregar.Enabled = Not ocupado AndAlso solicitudPrestamoNegocio.PuedeEntregar(solicitud)
        btnRechazar.Enabled = Not ocupado AndAlso circulacionLectorNegocio.PuedeCancelar(solicitud)
        btnComprobante.Enabled=Not ocupado AndAlso solicitudPrestamoNegocio.PuedeEmitirComprobante(solicitud)
    End Sub

    Private Async Function CambiarEstadoAsync(aprobar As Boolean) As Task
        Dim solicitud = Seleccionada()
        If ocupado OrElse solicitud Is Nothing Then Return
        If Not aprobar AndAlso MessageBox.Show("¿Rechazar toda la solicitud N.º " & solicitud.IdSolicitud & "?", "Rechazar solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Ocupacion(True)
        Try
            Await Task.Run(Sub()
                               If aprobar Then
                                   negocio.aprobar(solicitud.IdSolicitud)
                               Else
                                   negocio.rechazar(solicitud.IdSolicitud)
                               End If
                           End Sub)
            If IsDisposed Then Return
            MessageBox.Show(If(aprobar, "Solicitud aprobada. Los préstamos se registrarán al entregar los libros.", "Solicitud rechazada. Su disponibilidad quedó liberada."), "Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RaiseEvent DatosCambiados()
        Catch ex As Exception
            If Not IsDisposed Then MessageBox.Show(ex.Message, "Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If Not IsDisposed Then Ocupacion(False)
        End Try
        ActualizarDatos()
    End Function

    Private Sub Entregar(sender As Object, e As EventArgs)
        Dim solicitud = Seleccionada()
        If ocupado OrElse Not solicitudPrestamoNegocio.PuedeEntregar(solicitud) Then Return
        Using editor As New frmEntregaSolicitud(solicitud)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then
                RaiseEvent DatosCambiados()
                ActualizarDatos()
            End If
        End Using
    End Sub
End Class
