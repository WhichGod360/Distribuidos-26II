Imports System.Drawing.Drawing2D
Imports System.Threading.Tasks
Imports capaDatos
Imports capaNegocio

Public Class frmPrincipal
    <ComponentModel.DesignerSerializationVisibility(ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property IdUsuario As Integer
    <ComponentModel.DesignerSerializationVisibility(ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property Usuario As String = "Invitado"
    <ComponentModel.DesignerSerializationVisibility(ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property Rol As String = ""
    Private ReadOnly negocio As New dashboardNegocio()
    Private ReadOnly vistas As New Dictionary(Of String, Form)()
    Private vistaActual As Form
    Private datos As DashboardResumen
    Private cargando, cerrado, cargado As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Function EsAdministrador() As Boolean
        Return seguridadNegocio.PuedeGestionarUsuarios(IdUsuario, Rol)
    End Function

    Private Function PuedePrestar() As Boolean
        Return seguridadNegocio.PuedeOperar(IdUsuario, Rol)
    End Function

    Private Async Sub CargarPrincipal(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        Try
            seguridadNegocio.ExigirPersonal()
            seguridadNegocio.ExigirSesion(IdUsuario)
        Catch ex As UnauthorizedAccessException
            MessageBox.Show(ex.Message, "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
            Return
        End Try
        lblNombre.Text = Usuario
        lblRol.Text = Rol & " · ID " & IdUsuario
        btnUsuarios.Visible = EsAdministrador()
        lblTituloVista.Text = If(EsAdministrador(), "Resumen de administración", "Tu jornada en la biblioteca")
        lblDescripcionVista.Text = "Filtra los préstamos por su fecha de inicio. La disponibilidad corresponde al stock actual."
        vista_pnlBarras.Visible = False
        vista_pnlDona.Visible = False
        dtDesde.Value = New Date(Date.Today.Year, 1, 1)
        dtHasta.Value = Date.Today
        cboEst.SelectedIndex = 0
        btnNuevoRapido.Text = If(EsAdministrador(), "Gestionar usuarios", "Nuevo préstamo")
        btnDevolverRapido.Text = If(EsAdministrador(), "Gestionar categorías", "Registrar devolución")
        btnNuevoRapido.Enabled = EsAdministrador() OrElse PuedePrestar()
        btnDevolverRapido.Enabled = btnNuevoRapido.Enabled
        SeleccionarMenu(btnInicio)
        If IdUsuario <= 0 Then
            lblEstadoCarga.Text = "Inicia sesión para consultar los datos."
            Return
        End If
        cargado = True
        Await CargarCategoriasAsync()
        Await ActualizarDashboardAsync()
    End Sub

    Private Async Function CargarCategoriasAsync() As Task
        If ContextoDiseno.Activo(Me) OrElse IdUsuario <= 0 OrElse IsDisposed Then Return
        Try
            Dim categorias = Await Task.Run(Function() negocio.categorias())
            If cerrado Then Return
            Dim anterior As Integer = If(cboCat.SelectedValue Is Nothing, 0, CInt(cboCat.SelectedValue))
            cboCat.DisplayMember = "NombreCategoria"
            cboCat.ValueMember = "IdCategoria"
            cboCat.DataSource = categorias
            cboCat.SelectedValue = If(categorias.Any(Function(c) c.IdCategoria = anterior), anterior, 0)
        Catch
            If cerrado Then Return
            cboCat.DisplayMember = "NombreCategoria"
            cboCat.ValueMember = "IdCategoria"
            cboCat.DataSource = New List(Of Categoria) From {New Categoria With {.IdCategoria = 0, .NombreCategoria = "Todas las categorías"}}
        End Try
    End Function

    Public Async Function ActualizarDashboardAsync() As Task
        If ContextoDiseno.Activo(Me) OrElse Not cargado OrElse cargando OrElse cerrado Then Return
        If dtDesde.Value.Date > dtHasta.Value.Date Then
            lblEstadoCarga.Text = "La fecha Desde debe ser anterior o igual a Hasta."
            Return
        End If
        Dim desde = dtDesde.Value.Date, hasta = dtHasta.Value.Date
        Dim categoria As Integer = If(cboCat.SelectedValue Is Nothing, 0, CInt(cboCat.SelectedValue))
        Dim estado = If(TryCast(cboEst.SelectedItem, String), "Todos")
        cargando = True
        pnlFiltros.Enabled = False
        LimpiarResultados("Consultando la biblioteca...")
        Try
            Dim resultado = Await Task.Run(Function() negocio.consultar(desde, hasta, categoria, estado))
            If cerrado Then Return
            datos = resultado
            lblCap0.Text = If(EsAdministrador(), "Préstamos en selección", "Activos en selección")
            lblCap1.Text = If(EsAdministrador(), "Lectores atendidos", "Vencidos en selección")
            lblCap2.Text = If(EsAdministrador(), "Libros prestados", "Devueltos en selección")
            lblNum0.Text = If(EsAdministrador(), datos.TotalPrestamos, datos.Activos).ToString("N0")
            lblNum1.Text = If(EsAdministrador(), datos.LectoresAtendidos, datos.Vencidos).ToString("N0")
            lblNum2.Text = If(EsAdministrador(), datos.LibrosPrestados, datos.Devueltos).ToString("N0")
            lblNum3.Text = datos.EjemplaresDisponibles.ToString("N0")
            lblActualidad.Text = $"Hoy: {datos.DevolucionesHoy} devolución(es) · {datos.LibrosHabilitados} libro(s) habilitado(s) en la categoría · {datos.LectoresActivos} estudiante(s) activo(s) en la biblioteca"
            tablaPendientes.DataSource = datos.Pendientes
            tablaCategorias.DataSource = datos.PorCategoria
            tablaPendientes.ClearSelection()
            tablaCategorias.ClearSelection()
            lblSinPendientes.Text = If(datos.Pendientes.Count = 0, "No hay devoluciones pendientes en esta selección.", "Hasta 8 préstamos · Doble clic para abrir en Préstamos")
            lblEstadoCarga.Text = $"{datos.TotalPrestamos} préstamo(s) · Inicio: {desde:dd/MM/yyyy} a {hasta:dd/MM/yyyy} · Actualizado {Date.Now:HH:mm}" & If(datos.PorRevisar > 0, $" · {datos.PorRevisar} registro(s) por revisar", "")
        Catch
            If cerrado Then Return
            LimpiarResultados("No se pudo consultar SQL Server. Comprueba la conexión y pulsa Actualizar.")
        Finally
            cargando = False
            If Not cerrado Then
                pnlFiltros.Enabled = True
                pnlBarras.Invalidate()
                pnlDona.Invalidate()
            End If
        End Try
    End Function

    Private Sub LimpiarResultados(mensaje As String)
        datos = Nothing
        For Each etiqueta In {lblNum0, lblNum1, lblNum2, lblNum3}
            etiqueta.Text = "—"
        Next
        tablaPendientes.DataSource = New List(Of PendienteDashboard)()
        tablaCategorias.DataSource = New List(Of DatoGrafico)()
        lblActualidad.Text = mensaje
        lblSinPendientes.Text = mensaje
        lblEstadoCarga.Text = mensaje
        pnlBarras.Invalidate()
        pnlDona.Invalidate()
    End Sub

    Private Async Sub Actualizar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        If cargando Then Return
        Await CargarCategoriasAsync()
        Await ActualizarDashboardAsync()
    End Sub

    Private Async Sub Limpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        dtDesde.Value = New Date(Date.Today.Year, 1, 1)
        dtHasta.Value = Date.Today
        cboCat.SelectedValue = 0
        cboEst.SelectedIndex = 0
        Await ActualizarDashboardAsync()
    End Sub

    Private Sub Menu_Click(sender As Object, e As EventArgs) Handles btnInicio.Click, btnBuscar.Click, btnPrestamos.Click, btnSolicitudes.Click, btnLibros.Click, btnAutores.Click, btnCategorias.Click, btnPenalizaciones.Click, btnUsuarios.Click
        Try
            AbrirModulo(CStr(DirectCast(sender, Button).Tag))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Acceso al módulo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub SeleccionarMenu(seleccion As Button)
        For Each boton In {btnInicio, btnBuscar, btnPrestamos, btnSolicitudes, btnLibros, btnAutores, btnCategorias, btnPenalizaciones, btnUsuarios}
            boton.BackColor = If(boton Is seleccion, Utiles.MantenimientoUI.Primario, Color.FromArgb(244, 246, 253))
            boton.ForeColor = If(boton Is seleccion, Color.White, Utiles.MantenimientoUI.Texto)
        Next
    End Sub

    Public Sub AbrirModulo(clave As String)
        If ContextoDiseno.Activo(Me) Then Return
        seguridadNegocio.ExigirPersonal()
        Select Case clave
            Case "usuarios"
                seguridadNegocio.ExigirAdministrador()
                SeleccionarMenu(btnUsuarios)
                If Not vistas.ContainsKey(clave) Then
                    Dim formulario As New frmUsuarios()
                    AddHandler formulario.DatosCambiados, AddressOf DatosCambiaron
                    vistas.Add(clave, formulario)
                End If
            Case "solicitudes"
                SeleccionarMenu(btnSolicitudes)
                If Not vistas.ContainsKey(clave) Then
                    Dim formulario As New frmSolicitudes()
                    AddHandler formulario.DatosCambiados, AddressOf DatosCambiaron
                    vistas.Add(clave, formulario)
                End If
            Case "inicio"
                MostrarInicio()
                Return
            Case "lectores"
                SeleccionarMenu(btnBuscar)
                If Not vistas.ContainsKey(clave) Then
                    Dim formulario As New frmBuscarLector(IdUsuario, Usuario, Rol)
                    AddHandler formulario.SolicitarPrestamos, Sub(id) MostrarPrestamos("Todos", id)
                    AddHandler formulario.DatosCambiados, AddressOf DatosCambiaron
                    vistas.Add(clave, formulario)
                End If
            Case "prestamos"
                MostrarPrestamos("Todos")
                Return
            Case "libros", "Libros y ejemplares"
                clave = "libros"
                SeleccionarMenu(btnLibros)
                If Not vistas.ContainsKey(clave) Then
                    Dim formulario As New FrmLibros()
                    AddHandler formulario.SolicitarEjemplares, AddressOf MostrarEjemplares
                    vistas.Add(clave, formulario)
                End If
            Case "autores"
                SeleccionarMenu(btnAutores)
                If Not vistas.ContainsKey(clave) Then vistas.Add(clave, New frmAutor())
            Case "categorias"
                SeleccionarMenu(btnCategorias)
                If Not vistas.ContainsKey(clave) Then vistas.Add(clave, New FrmCategoria())
            Case "penalizaciones"
                SeleccionarMenu(btnPenalizaciones)
                If Not vistas.ContainsKey(clave) Then
                    Dim formulario As New frmPenalizacion()
                    AddHandler formulario.SolicitarDetalles, AddressOf MostrarDetallesPenalizacion
                    vistas.Add(clave, formulario)
                End If
            Case Else
                Throw New ArgumentException("Ruta de navegación no reconocida.", NameOf(clave))
        End Select
        MostrarVista(vistas(clave))
    End Sub

    Private Function VistaPrestamos() As frmPrestamos
        If Not vistas.ContainsKey("prestamos") Then
            Dim formulario As New frmPrestamos(IdUsuario, Usuario, Rol)
            AddHandler formulario.DatosCambiados, AddressOf DatosCambiaron
            vistas.Add("prestamos", formulario)
        End If
        Return DirectCast(vistas("prestamos"), frmPrestamos)
    End Function

    Public Sub MostrarPrestamos(filtro As String, Optional idLector As Integer = 0, Optional idPrestamo As Integer = 0)
        seguridadNegocio.ExigirPersonal()
        Dim formulario = VistaPrestamos()
        formulario.AplicarContexto(filtro, idLector, idPrestamo)
        MostrarVista(formulario)
        SeleccionarMenu(btnPrestamos)
    End Sub

    Private Sub MostrarVista(formulario As Form)
        Dim integrado = formulario.Parent Is pnlMain
        If vistaActual IsNot Nothing AndAlso vistaActual IsNot formulario Then vistaActual.Hide()
        panelDashboard.Hide()
        If Not integrado Then
            formulario.TopLevel = False
            formulario.FormBorderStyle = FormBorderStyle.None
            formulario.ShowInTaskbar = False
            formulario.Dock = DockStyle.Fill
            formulario.MinimumSize = Size.Empty
            pnlMain.Controls.Add(formulario)
        End If
        vistaActual = formulario
        formulario.Show()
        formulario.BringToFront()
        If integrado Then TryCast(formulario, IMantenimientoVista)?.ActualizarDatos()
    End Sub

    Private Async Sub MostrarInicio()
        If vistaActual IsNot Nothing Then vistaActual.Hide()
        vistaActual = Nothing
        panelDashboard.Show()
        panelDashboard.BringToFront()
        SeleccionarMenu(btnInicio)
        Await CargarCategoriasAsync()
        Await ActualizarDashboardAsync()
    End Sub

    Private Sub MostrarEjemplares(idLibro As Integer, titulo As String)
        Dim formulario As New frmEjemplares(idLibro, titulo)
        AddHandler formulario.VolverALibros, Sub() AbrirModulo("libros")
        ReemplazarVista("ejemplares", formulario)
        SeleccionarMenu(btnLibros)
    End Sub

    Private Sub MostrarDetallesPenalizacion(id As Integer)
        Dim formulario As New frmDetallePenalizacion(id)
        AddHandler formulario.VolverAPenalizaciones, Sub() AbrirModulo("penalizaciones")
        ReemplazarVista("detalles", formulario)
    End Sub

    Private Sub ReemplazarVista(clave As String, formulario As Form)
        If vistas.ContainsKey(clave) Then
            Dim anterior = vistas(clave)
            If vistaActual Is anterior Then vistaActual = Nothing
            anterior.Dispose()
        End If
        vistas(clave) = formulario
        MostrarVista(formulario)
    End Sub

    Private Async Sub DatosCambiaron()
        Await ActualizarDashboardAsync()
    End Sub

    Private Sub NuevoRapido_Click(sender As Object, e As EventArgs) Handles btnNuevoRapido.Click
        If EsAdministrador() Then
            AbrirModulo("usuarios")
        ElseIf PuedePrestar() Then
            MostrarPrestamos("Todos")
            VistaPrestamos().NuevoPrestamo()
        End If
    End Sub

    Private Sub DevolverRapido_Click(sender As Object, e As EventArgs) Handles btnDevolverRapido.Click
        If EsAdministrador() Then
            AbrirModulo("categorias")
        ElseIf PuedePrestar() Then
            MostrarPrestamos("Activos")
        End If
    End Sub

    Private Sub LectorRapido_Click(sender As Object, e As EventArgs) Handles btnLectorRapido.Click
        AbrirModulo("lectores")
    End Sub

    Private Sub CatalogoRapido_Click(sender As Object, e As EventArgs) Handles btnCatalogoRapido.Click, cardStat3.Click, lblNum3.Click
        AbrirModulo("libros")
    End Sub

    Private Sub Activos_Click(sender As Object, e As EventArgs) Handles cardStat0.Click, lblNum0.Click
        MostrarPrestamos(If(EsAdministrador(), "Todos", "Activos"))
    End Sub

    Private Sub Vencidos_Click(sender As Object, e As EventArgs) Handles cardStat1.Click, lblNum1.Click
        If EsAdministrador() Then AbrirModulo("lectores") Else MostrarPrestamos("Vencidos")
    End Sub

    Private Sub Devueltos_Click(sender As Object, e As EventArgs) Handles cardStat2.Click, lblNum2.Click
        If EsAdministrador() Then AbrirModulo("libros") Else MostrarPrestamos("Devueltos")
    End Sub

    Private Sub Pendiente_DobleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tablaPendientes.CellDoubleClick
        If e.RowIndex < 0 Then Return
        Dim pendiente = TryCast(tablaPendientes.Rows(e.RowIndex).DataBoundItem, PendienteDashboard)
        If pendiente IsNot Nothing Then MostrarPrestamos("Activos", 0, pendiente.IdPrestamo)
    End Sub

    Private Sub DibujarBarras(sender As Object, e As PaintEventArgs) Handles pnlBarras.Paint
        If ContextoDiseno.Activo(Me) Then Return
        If datos Is Nothing OrElse datos.PorMes.Count = 0 Then
            DibujarVacio(e.Graphics, pnlBarras, If(cargando, "Consultando...", "Sin préstamos en la selección"))
            Return
        End If
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim meses = datos.PorMes, maximo = Math.Max(1, meses.Max(Function(m) m.Cantidad))
        Dim ancho As Single = pnlBarras.Width / CSng(meses.Count), baseY = pnlBarras.Height - 30
        Using azul As New SolidBrush(Utiles.MantenimientoUI.Primario), texto As New SolidBrush(Utiles.MantenimientoUI.Texto), fuente As New Font("Segoe UI", 8.0F), formato As New StringFormat With {.Alignment = StringAlignment.Center}
            For i = 0 To meses.Count - 1
                Dim alto As Single = Math.Max(0, (baseY - 23) * meses(i).Cantidad / maximo)
                Dim x As Single = ancho * i + ancho * 0.2F
                g.FillRectangle(azul, x, baseY - alto, Math.Max(1, ancho * 0.6F), alto)
                If meses.Count <= 16 Then g.DrawString(meses(i).Cantidad.ToString(), fuente, texto, x + ancho * 0.3F, baseY - alto - 18, formato)
                If i Mod Math.Max(1, CInt(Math.Ceiling(meses.Count / 6.0))) = 0 Then g.DrawString(meses(i).Etiqueta, fuente, texto, x + ancho * 0.3F, baseY + 5, formato)
            Next
        End Using
    End Sub

    Private Sub DibujarDona(sender As Object, e As PaintEventArgs) Handles pnlDona.Paint
        If ContextoDiseno.Activo(Me) Then Return
        If datos Is Nothing OrElse datos.TotalPrestamos = 0 Then
            DibujarVacio(e.Graphics, pnlDona, If(cargando, "Consultando...", "Sin préstamos en la selección"))
            Return
        End If
        Dim valores = {datos.Activos - datos.Vencidos, datos.Vencidos, datos.Devueltos, datos.PorRevisar}
        Dim nombres = {"Vigentes", "Vencidos", "Devueltos", "Por revisar"}
        Dim colores = {Utiles.MantenimientoUI.Primario, Color.FromArgb(218, 115, 78), Color.FromArgb(67, 160, 132), Color.Gray}
        Dim diametro = Math.Min(112, Math.Min(pnlDona.Height - 18, pnlDona.Width \ 2 - 18))
        If diametro <= 25 Then Return
        Dim circulo As New Rectangle(10, (pnlDona.Height - diametro) \ 2, diametro, diametro)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim inicio As Single = -90
        Using fuente As New Font("Segoe UI", 9.0F), texto As New SolidBrush(Utiles.MantenimientoUI.Texto)
            For i = 0 To 3
                Dim angulo As Single = 360.0F * valores(i) / datos.TotalPrestamos
                Using pluma As New Pen(colores(i), 18), relleno As New SolidBrush(colores(i))
                    If angulo > 0 Then e.Graphics.DrawArc(pluma, circulo, inicio, angulo)
                    e.Graphics.FillRectangle(relleno, diametro + 27, 18 + i * 32, 10, 10)
                End Using
                e.Graphics.DrawString(nombres(i) & "  " & valores(i), fuente, texto, diametro + 43, 14 + i * 32)
                inicio += angulo
            Next
        End Using
    End Sub

    Private Shared Sub DibujarVacio(g As Graphics, panel As Panel, mensaje As String)
        Using fuente As New Font("Segoe UI", 10.0F), pincel As New SolidBrush(Utiles.MantenimientoUI.Suave), formato As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
            g.DrawString(mensaje, fuente, pincel, panel.ClientRectangle, formato)
        End Using
    End Sub

    Private Sub Graficos_Resize(sender As Object, e As EventArgs) Handles pnlBarras.Resize, pnlDona.Resize
        DirectCast(sender, Control).Invalidate()
    End Sub

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        SesionUsuario.Cerrar()
        Application.Restart()
    End Sub

    Private Sub Principal_Cerrado(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        cerrado = True
        If Not ContextoDiseno.Activo(Me) Then Application.Exit()
    End Sub

    Private Sub Principal_Liberado(sender As Object, e As EventArgs) Handles MyBase.Disposed
        cerrado = True
    End Sub
End Class
