Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmBuscarLector
    Implements IMantenimientoVista

    Private ReadOnly negocio As New prestamoNegocio()
    Private ReadOnly idBibliotecario As Integer
    Private ReadOnly nombreBibliotecario As String
    Private ReadOnly puedeOperar As Boolean
    Private versionHistorial As Integer
    Private versionBusqueda As Integer
    Private buscando As Boolean
    Public Event SolicitarPrestamos(idLector As Integer)
    Public Event DatosCambiados()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(idUsuario As Integer, nombreUsuario As String, rol As String)
        Me.New()
        idBibliotecario = idUsuario
        nombreBibliotecario = nombreUsuario
        puedeOperar = idUsuario > 0 AndAlso String.Equals(If(rol, "").Trim(), "Bibliotecario", StringComparison.OrdinalIgnoreCase)
        lblDescripcionVista.Text = "Estudiantes activos · Sesión: " & nombreUsuario & " · " & rol
    End Sub

    Private Async Sub Buscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If buscando OrElse ContextoDiseno.Activo(Me) OrElse idBibliotecario <= 0 Then Return
        Dim criterio = txtBuscar.Text.Trim()
        If criterio.Length = 0 Then
            lblResumen.Text = "Escribe un nombre, apellido, DNI o correo para buscar."
            txtBuscar.Focus()
            Return
        End If
        buscando = True
        versionBusqueda += 1
        Dim version = versionBusqueda
        btnBuscar.Enabled = False
        tablaLectores.DataSource = Nothing
        LimpiarHistorial()
        lblResumen.Text = "Buscando estudiantes activos…"
        Try
            Dim lectores = Await Task.Run(Function() negocio.buscarLectores(criterio))
            If IsDisposed OrElse version <> versionBusqueda Then Return
            tablaLectores.DataSource = lectores
            tablaLectores.ClearSelection()
            LimpiarHistorial()
            lblResumen.Text = lectores.Count & " lector(es) · Selecciona uno para consultar sus préstamos."
        Catch ex As Exception
            If Not IsDisposed AndAlso version = versionBusqueda Then lblResumen.Text = "No se pudo buscar. Revisa la conexión y vuelve a intentarlo. " & ex.Message
        Finally
            If Not IsDisposed Then
                buscando = False
                btnBuscar.Enabled = True
            End If
        End Try
    End Sub

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        versionBusqueda += 1
        txtBuscar.Clear()
        tablaLectores.DataSource = Nothing
        LimpiarHistorial()
        lblResumen.Text = "Busca por nombre, apellido, DNI o correo."
        txtBuscar.Focus()
    End Sub

    Private Function LectorSeleccionado() As Usuario
        If tablaLectores.SelectedRows.Count = 0 Then Return Nothing
        Return TryCast(tablaLectores.SelectedRows(0).DataBoundItem, Usuario)
    End Function

    Private Function PrestamoSeleccionado() As Prestamo
        If tablaPrestamos.SelectedRows.Count = 0 Then Return Nothing
        Return TryCast(tablaPrestamos.SelectedRows(0).DataBoundItem, Prestamo)
    End Function

    Private Sub LimpiarHistorial()
        versionHistorial += 1
        tablaPrestamos.DataSource = Nothing
        lblLector.Text = "Selecciona un lector para ver su historial."
        btnNuevo.Enabled = False
        btnVerPrestamos.Enabled = False
        btnDevolver.Enabled = False
    End Sub

    Private Async Sub SeleccionarLector(sender As Object, e As EventArgs) Handles tablaLectores.SelectionChanged
        If buscando Then Return
        Await CargarHistorialAsync()
    End Sub

    Private Async Function CargarHistorialAsync() As Task
        If ContextoDiseno.Activo(Me) OrElse idBibliotecario <= 0 OrElse IsDisposed Then Return
        Dim lector = LectorSeleccionado()
        LimpiarHistorial()
        If lector Is Nothing Then Return
        Dim version = versionHistorial
        lblLector.Text = lector.NombreCompleto & " · DNI " & lector.NumeroDniUsuario
        btnNuevo.Enabled = puedeOperar
        btnVerPrestamos.Enabled = True
        lblResumen.Text = "Consultando historial…"
        Try
            Dim prestamos = Await Task.Run(Function() negocio.listarPorLector(lector.IdUsuario))
            If IsDisposed OrElse version <> versionHistorial Then Return
            tablaPrestamos.DataSource = prestamos
            tablaPrestamos.ClearSelection()
            lblResumen.Text = prestamos.Count & " préstamo(s) del lector · Activos: " & prestamos.Where(Function(p) p.EstaActivo).Count() & " · Vencidos: " & prestamos.Where(Function(p) p.EstaVencido(Date.Today)).Count()
        Catch ex As Exception
            If Not IsDisposed AndAlso version = versionHistorial Then lblResumen.Text = "No se pudo consultar el historial. " & ex.Message
        End Try
    End Function

    Public Async Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If Not IsHandleCreated Then Return
        Await CargarHistorialAsync()
    End Sub

    Private Sub SeleccionarPrestamo(sender As Object, e As EventArgs) Handles tablaPrestamos.SelectionChanged
        Dim prestamo = PrestamoSeleccionado()
        btnDevolver.Enabled = puedeOperar AndAlso prestamo IsNot Nothing AndAlso prestamo.EstaActivo
    End Sub

    Private Sub FormatearEstado(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles tablaPrestamos.CellFormatting
        If e.RowIndex < 0 OrElse tablaPrestamos.Columns(e.ColumnIndex).DataPropertyName <> "EstadoPrestamo" Then Return
        Dim prestamo = TryCast(tablaPrestamos.Rows(e.RowIndex).DataBoundItem, Prestamo)
        If prestamo Is Nothing Then Return
        e.Value = prestamo.EstadoParaMostrar(Date.Today)
        e.FormattingApplied = True
        If prestamo.EstaVencido(Date.Today) Then e.CellStyle.ForeColor = Color.Firebrick
    End Sub

    Private Sub VerPrestamos(sender As Object, e As EventArgs) Handles btnVerPrestamos.Click
        Dim lector = LectorSeleccionado()
        If lector IsNot Nothing Then RaiseEvent SolicitarPrestamos(lector.IdUsuario)
    End Sub

    Private Async Sub NuevoPrestamo(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim lector = LectorSeleccionado()
        If Not puedeOperar OrElse lector Is Nothing Then Return
        Using editor As New frmPrestamoDetalle(idBibliotecario, nombreBibliotecario, lector)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then
                RaiseEvent DatosCambiados()
                Await CargarHistorialAsync()
            End If
        End Using
    End Sub

    Private Async Sub DevolverPrestamo(sender As Object, e As EventArgs) Handles btnDevolver.Click
        Dim prestamo = PrestamoSeleccionado()
        If Not puedeOperar OrElse prestamo Is Nothing OrElse Not prestamo.EstaActivo Then Return
        Using editor As New frmPrestamoDevolucion(prestamo, idBibliotecario, nombreBibliotecario)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then
                RaiseEvent DatosCambiados()
                Await CargarHistorialAsync()
            End If
        End Using
    End Sub
End Class
