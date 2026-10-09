Imports System.Threading.Tasks
Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmLector
    Private catalogo As New List(Of Libro)()
    Private reservas As New List(Of SolicitudPrestamo)()
    Private prestamos As New List(Of Prestamo)()
    Private penalizaciones As New ResumenPenalizaciones()
    Private ReadOnly carrito As New List(Of Libro)()
    Private ReadOnly solicitudes As New solicitudPrestamoNegocio()
    Private ocupado As Boolean
    Private datosDisponibles As Boolean

    Public Sub New()
        InitializeComponent()
        For Each boton In {btnSalir, btnActualizar, btnQuitar, btnVaciar, btnCancelar, btnActualizarPenalizaciones}
            MantenimientoUI.EstilizarBoton(boton)
        Next
        MantenimientoUI.EstilizarBoton(btnSolicitar, True)
        MantenimientoUI.EstilizarBoton(btnActualizarAvisos)
        AddHandler btnActualizarAvisos.Click, Async Sub() Await ActualizarAsync()
        For Each tabla In {tablaCarrito, tablaReservas, tablaPrestamos, tablaPenalizaciones,tablaAvisos}
            DataGridViewHelper.AplicarEstiloTabla(tabla)
            tabla.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            tabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Next
        AddHandler Load, AddressOf Cargar
        AddHandler btnActualizar.Click, Async Sub() Await ActualizarAsync()
        AddHandler btnActualizarPenalizaciones.Click, Async Sub() Await ActualizarAsync()
        AddHandler cboPagoPenalizaciones.SelectedIndexChanged, Sub() MostrarPenalizaciones()
        AddHandler txtBuscar.TextChanged, Sub() MostrarCatalogo()
        AddHandler cboCategoria.SelectedIndexChanged, Sub() MostrarCatalogo()
        AddHandler btnQuitar.Click, AddressOf Quitar
        AddHandler btnVaciar.Click, Sub()
                                        carrito.Clear()
                                        MostrarCarrito()
                                        MostrarCatalogo()
                                    End Sub
        AddHandler btnSolicitar.Click, AddressOf Solicitar
        AddHandler btnCancelar.Click, AddressOf Cancelar
        AddHandler tablaReservas.SelectionChanged, Sub() ActualizarCancelacion()
        AddHandler btnSalir.Click, Sub()
                                      SesionUsuario.Cerrar()
                                      Application.Restart()
                                  End Sub
        AddHandler FormClosed, Sub()
                                   If Not ContextoDiseno.Activo(Me) Then Application.Exit()
                               End Sub
    End Sub

    Private Async Sub Cargar(sender As Object, e As EventArgs)
        If ContextoDiseno.Activo(Me) Then Return
        Try
            seguridadNegocio.ExigirLector()
            lblBienvenida.Text = "Mi biblioteca · " & SesionUsuario.Rol
            Await ActualizarAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
        End Try
    End Sub

    Private Async Function ActualizarAsync() As Task
        If ocupado OrElse IsDisposed Then Return
        CambiarOcupado(True)
        datosDisponibles = False
        lblEstado.Text = "Consultando la biblioteca..."
        Try
            Dim resultado = Await Task.Run(Function() New With {
                .Catalogo = New catalogoLectorNegocio().listar(), .Reservas = solicitudes.listarMias(),
                .Prestamos = New prestamoNegocio().listarPorLector(SesionUsuario.IdUsuario),
                .Penalizaciones = New detallePenalizacionNegocio().ConsultarMias(),
                .Avisos=New avisoLectorNegocio().ConsultarMios()})
            If IsDisposed Then Return
            catalogo = resultado.Catalogo
            reservas = resultado.Reservas
            prestamos = resultado.Prestamos
            penalizaciones = resultado.Penalizaciones
            tablaAvisos.DataSource=resultado.Avisos
            tablaAvisos.Columns("Asunto").FillWeight=30
            tablaAvisos.Columns("Detalle").FillWeight=170
            tablaAvisos.ClearSelection()
            tabAvisos.Text="Avisos (" & resultado.Avisos.Count & ")"
            datosDisponibles = True
            Dim categoriaAnterior = TryCast(cboCategoria.SelectedItem, String)
            Dim categorias = New List(Of String) From {"Todas las categorías"}
            categorias.AddRange(catalogo.SelectMany(Function(l) l.Categoria.Split(","c)).Select(Function(c) c.Trim()).Where(Function(c) c <> "").Distinct().OrderBy(Function(c) c))
            cboCategoria.DataSource = categorias
            cboCategoria.SelectedItem = If(categorias.Contains(categoriaAnterior), categoriaAnterior, categorias(0))
            tablaReservas.DataSource = reservas.Select(Function(s) New With {
                .Solicitud = s.IdSolicitud, .Libros = s.Libros, .Estado = s.EstadoActual,
                .RecojoHasta = s.LimiteLocal.ToString("dd/MM/yyyy HH:mm"),
                .AprobadaPor = s.NombreAprobador}).ToList()
            tablaPrestamos.DataSource = prestamos.Select(Function(p) New With {
                .Prestamo = p.IdPrestamo, .Libro = p.TituloLibro, .Ejemplar = p.IdEjemplar,
                .Inicio = p.FechaInicio.ToString("dd/MM/yyyy"), .Vencimiento = p.FechaFin.ToString("dd/MM/yyyy"),
                .Devolucion = If(p.FechaRetorno.HasValue, p.FechaRetorno.Value.ToString("dd/MM/yyyy"), "Pendiente"),
                .Estado = prestamoNegocio.EstadoParaMostrar(p, Date.Today)}).ToList()
            If tablaReservas.Columns.Contains("RecojoHasta") Then tablaReservas.Columns("RecojoHasta").HeaderText = "Recoger hasta (Lima)"
            If tablaReservas.Columns.Contains("AprobadaPor") Then tablaReservas.Columns("AprobadaPor").HeaderText = "Aprobada por"
            If tablaPrestamos.Columns.Contains("Prestamo") Then tablaPrestamos.Columns("Prestamo").HeaderText = "Préstamo"
            If tablaPrestamos.Columns.Contains("Devolucion") Then tablaPrestamos.Columns("Devolucion").HeaderText = "Devolución"
            tablaReservas.ClearSelection()
            tablaPrestamos.ClearSelection()
            MostrarPenalizaciones()
            lblEstado.Text = $"{catalogo.Count} títulos · Libros pendientes: {LibrosPendientes()}/5 · Cupo: {CupoDisponible()} · Una solicitud vigente · Recojo después de aprobación"
        Catch ex As Exception
            catalogo.Clear()
            reservas.Clear()
            prestamos.Clear()
            penalizaciones = New ResumenPenalizaciones()
            tablaReservas.DataSource = Nothing
            tablaPrestamos.DataSource = Nothing
            tablaPenalizaciones.DataSource = Nothing
            tablaAvisos.DataSource=Nothing
            tabAvisos.Text="Avisos"
            For Each etiqueta In {lblTotalPenalizaciones, lblPendientePenalizaciones, lblPorRevisarPenalizaciones, lblPagadoPenalizaciones}
                etiqueta.Text = "Sin datos actualizados"
            Next
            lblAvisoPenalizaciones.Text = "Actualiza para consultar tus penalizaciones."
            lblEstado.Text = "No se pudieron actualizar los datos. Pulsa Actualizar para intentarlo nuevamente."
            MessageBox.Show(ex.Message, "Mi biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If Not IsDisposed Then
                CambiarOcupado(False)
                MostrarCarrito()
                MostrarCatalogo()
            End If
        End Try
    End Function

    Private Sub CambiarOcupado(valor As Boolean)
        ocupado = valor
        pestanas.Enabled = Not valor
        btnSalir.Enabled = Not valor
        UseWaitCursor = valor
        ActualizarCancelacion()
    End Sub

    Private Sub ActualizarCancelacion()
        Dim actual = ReservaSeleccionada()
        btnCancelar.Enabled = Not ocupado AndAlso circulacionLectorNegocio.PuedeCancelar(actual)
    End Sub

    Private Sub MostrarCatalogo()
        If ocupado OrElse ContextoDiseno.Activo(Me) Then Return
        panelCatalogo.SuspendLayout()
        For Each control As Control In panelCatalogo.Controls.Cast(Of Control)().ToArray()
            control.Dispose()
        Next
        panelCatalogo.Controls.Clear()
        Dim texto = txtBuscar.Text.Trim()
        Dim categoria = TryCast(cboCategoria.SelectedItem, String)
        Dim lista = catalogo.Where(Function(l) (l.TituloLibro & " " & l.Autor & " " & l.EditorialLibro).IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 AndAlso
            (categoria Is Nothing OrElse categoria = "Todas las categorías" OrElse l.Categoria.Split(","c).Any(Function(c) c.Trim() = categoria))).ToList()
        For Each libro In lista
            panelCatalogo.Controls.Add(Tarjeta(libro))
        Next
        If lista.Count = 0 Then panelCatalogo.Controls.Add(New Label With {.Text = "No hay libros para esta búsqueda.", .AutoSize = True, .Padding = New Padding(12)})
        panelCatalogo.ResumeLayout()
    End Sub

    Private Function Tarjeta(libro As Libro) As Control
        Dim panelTarjeta As New TableLayoutPanel With {.Width = 245, .Height = 340, .ColumnCount = 1, .RowCount = 6,
            .Padding = New Padding(12), .Margin = New Padding(0, 0, 14, 14), .BackColor = Color.FromArgb(245, 247, 254)}
        For Each alto In {115, 62, 42, 28, 25, 40}
            panelTarjeta.RowStyles.Add(New RowStyle(SizeType.Absolute, alto))
        Next
        panelTarjeta.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
        Dim portada As New Panel With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(226, 233, 255)}
        AddHandler portada.Paint, Sub(sender, e)
                                     e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                                     Using pincel As New SolidBrush(MantenimientoUI.Primario), linea As New Pen(Color.White, 2), fuente As New Font("Segoe UI", 8)
                                         e.Graphics.FillRectangle(pincel, 82, 14, 54, 68)
                                         e.Graphics.DrawLine(linea, 91, 14, 91, 82)
                                         e.Graphics.DrawLine(linea, 101, 36, 126, 36)
                                         e.Graphics.DrawLine(linea, 101, 45, 121, 45)
                                         e.Graphics.DrawString("Imagen referencial", fuente, Brushes.DimGray, 57, 88)
                                     End Using
                                 End Sub
        panelTarjeta.Controls.Add(portada, 0, 0)
        panelTarjeta.Controls.Add(New Label With {.Text = libro.TituloLibro, .Dock = DockStyle.Fill, .Font = New Font("Segoe UI", 11, FontStyle.Bold), .AutoEllipsis = True}, 0, 1)
        panelTarjeta.Controls.Add(New Label With {.Text = libro.Autor, .Dock = DockStyle.Fill, .AutoEllipsis = True, .ForeColor = MantenimientoUI.Suave}, 0, 2)
        panelTarjeta.Controls.Add(New Label With {.Text = libro.Categoria, .Dock = DockStyle.Fill, .AutoEllipsis = True}, 0, 3)
        panelTarjeta.Controls.Add(New Label With {.Text = If(libro.Disponibles > 0, libro.Disponibles & " disponible(s)", "Sin disponibilidad"), .Dock = DockStyle.Fill}, 0, 4)
        Dim agregado = carrito.Any(Function(l) l.IdLibro = libro.IdLibro)
        Dim boton As New Button With {.Text = If(agregado, "En tu carrito", "Agregar al carrito"), .Dock = DockStyle.Fill,
            .Enabled = datosDisponibles AndAlso circulacionLectorNegocio.PuedeAgregar(libro, carrito, EstadoCirculacion())}
        MantenimientoUI.EstilizarBoton(boton, True)
        AddHandler boton.Click, Sub()
                                   Try
                                       circulacionLectorNegocio.Agregar(libro, carrito, EstadoCirculacion())
                                   Catch ex As Exception
                                       MessageBox.Show(ex.Message, "Carrito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                       Return
                                   End Try
                                   MostrarCarrito()
                                   MostrarCatalogo()
                               End Sub
        panelTarjeta.Controls.Add(boton, 0, 5)
        Return panelTarjeta
    End Function

    Private Sub MostrarCarrito()
        tablaCarrito.Rows.Clear()
        For Each libro In carrito
            tablaCarrito.Rows.Add(libro.IdLibro, libro.TituloLibro, libro.Autor)
        Next
        tabCarrito.Text = "Carrito (" & carrito.Count & ")"
        btnSolicitar.Enabled = datosDisponibles AndAlso Not ocupado AndAlso circulacionLectorNegocio.PuedeSolicitar(carrito, EstadoCirculacion())
        btnQuitar.Enabled = carrito.Count > 0
        btnVaciar.Enabled = carrito.Count > 0
    End Sub

    Private Sub Quitar(sender As Object, e As EventArgs)
        If tablaCarrito.SelectedRows.Count = 0 Then Return
        Dim id = CInt(tablaCarrito.SelectedRows(0).Cells("IdLibro").Value)
        carrito.RemoveAll(Function(l) l.IdLibro = id)
        MostrarCarrito()
        MostrarCatalogo()
    End Sub

    Private Async Sub Solicitar(sender As Object, e As EventArgs)
        If ocupado OrElse carrito.Count = 0 Then Return
        Dim ids = carrito.Select(Function(l) l.IdLibro).ToList()
        CambiarOcupado(True)
        Try
            Dim id = Await Task.Run(Function() solicitudes.solicitar(ids))
            If IsDisposed Then Return
            carrito.Clear()
            MessageBox.Show("Solicitud N.º " & id & " registrada. Espera la aprobación del bibliotecario. El límite de recojo es cinco días desde ahora.", "Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information)
            pestanas.SelectedTab = tabReservas
        Catch ex As Exception
            If Not IsDisposed Then MessageBox.Show(ex.Message, "No se pudo reservar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If Not IsDisposed Then CambiarOcupado(False)
        End Try
        Await ActualizarAsync()
    End Sub

    Private Function ReservaSeleccionada() As SolicitudPrestamo
        If tablaReservas.SelectedRows.Count = 0 OrElse Not tablaReservas.Columns.Contains("Solicitud") Then Return Nothing
        Dim id = CInt(tablaReservas.SelectedRows(0).Cells("Solicitud").Value)
        Return reservas.FirstOrDefault(Function(s) s.IdSolicitud = id)
    End Function

    Private Async Sub Cancelar(sender As Object, e As EventArgs)
        Dim reserva = ReservaSeleccionada()
        If ocupado OrElse Not circulacionLectorNegocio.PuedeCancelar(reserva) Then Return
        If MessageBox.Show("¿Cancelar toda la solicitud N.º " & reserva.IdSolicitud & "?", "Cancelar reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        CambiarOcupado(True)
        Try
            Await Task.Run(Sub() solicitudes.cancelar(reserva.IdSolicitud))
        Catch ex As Exception
            If Not IsDisposed Then MessageBox.Show(ex.Message, "Reserva", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If Not IsDisposed Then CambiarOcupado(False)
        End Try
        Await ActualizarAsync()
    End Sub
    Private Function EstadoCirculacion() As EstadoCirculacionLector
        Return circulacionLectorNegocio.Evaluar(prestamos, reservas, penalizaciones)
    End Function

    Private Function LibrosPendientes() As Integer
        Return EstadoCirculacion().LibrosPendientes
    End Function

    Private Function CupoDisponible() As Integer
        Return EstadoCirculacion().CupoDisponible
    End Function

    Private Sub MostrarPenalizaciones()
        If ContextoDiseno.Activo(Me) OrElse Not datosDisponibles Then Return
        Dim filtro As String = If(TryCast(cboPagoPenalizaciones.SelectedItem, String), "Todos")
        Dim estado As String = If(filtro = "Por revisar", DetallePenalizacion.PagoPorRevisar, filtro)
        Dim detalles = penalizaciones.Detalles.Where(Function(d) estado = "Todos" OrElse d.EstadoPago = estado).ToList()
        tablaPenalizaciones.DataSource = detalles.Select(Function(d) New With {
            .Prestamo = d.IdPrestamo, .Libro = d.TituloLibro, .Tipo = d.TipoPenalizacion,
            .Motivo = d.Motivo, .Importe = d.MontoPenalizacion, .Estado = d.EstadoPagoTexto,
            .DiasRetraso = d.DiasRetraso}).ToList()
        If tablaPenalizaciones.Columns.Contains("Importe") Then
            tablaPenalizaciones.Columns("Importe").DefaultCellStyle.Format = "'S/ '0.00"
            tablaPenalizaciones.Columns("Importe").FillWeight = 65
            tablaPenalizaciones.Columns("Motivo").FillWeight = 200
            tablaPenalizaciones.Columns("Libro").FillWeight = 150
            tablaPenalizaciones.Columns("Prestamo").HeaderText = "Préstamo"
            tablaPenalizaciones.Columns("Prestamo").FillWeight = 55
            tablaPenalizaciones.Columns("DiasRetraso").HeaderText = "Días de retraso"
            tablaPenalizaciones.Columns("DiasRetraso").FillWeight = 65
            tablaPenalizaciones.Columns("Estado").HeaderText = "Estado de pago"
        End If
        tablaPenalizaciones.ClearSelection()
        lblTotalPenalizaciones.Text = "Total registrado" & vbCrLf & "S/ " & penalizaciones.Total.ToString("0.00")
        lblPendientePenalizaciones.Text = "Pendiente" & vbCrLf & "S/ " & penalizaciones.Pendiente.ToString("0.00")
        lblPorRevisarPenalizaciones.Text = "Por revisar" & vbCrLf & "S/ " & penalizaciones.PorRevisar.ToString("0.00")
        lblPagadoPenalizaciones.Text = "Pagado" & vbCrLf & "S/ " & penalizaciones.Pagado.ToString("0.00")
        lblAvisoPenalizaciones.Text = "Total pendiente o por revisar: S/ " & penalizaciones.TotalPorRegularizar.ToString("0.00") & ". " &
            If(penalizaciones.Detalles.Count = 0, "No tienes penalizaciones registradas.",
            $"{detalles.Count} registro(s) en esta vista; totales de todas tus penalizaciones.") & vbCrLf &
            If(penalizaciones.BloqueaPrestamos, "Tienes pagos pendientes o por revisar. Regularízalos en ventanilla para solicitar nuevos libros.", "Tus penalizaciones no bloquean nuevos préstamos.")
    End Sub
End Class
