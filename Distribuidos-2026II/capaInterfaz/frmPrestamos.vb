Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmPrestamos

    Implements IMantenimientoVista

    Private ReadOnly negocio As New prestamoNegocio()
    Private ReadOnly idBibliotecario As Integer
    Private ReadOnly nombreBibliotecario As String
    Private ReadOnly puedeOperar As Boolean
    Private datos As New List(Of Prestamo)()
    Private lectorContexto As Integer
    Private prestamoContexto As Integer
    Private ReadOnly btnEntrega As New Button With {.Text = "Comprobante entrega", .Width = 195, .Height = 36}
    Private ReadOnly btnRetorno As New Button With {.Text = "Comprobante devolución", .Width = 215, .Height = 36}
    Public Event DatosCambiados()

    Public Sub New()
        InitializeComponent()
        barraAcciones.Controls.AddRange({btnEntrega, btnRetorno})
        MantenimientoUI.EstilizarBoton(btnEntrega)
        MantenimientoUI.EstilizarBoton(btnRetorno)
        AddHandler btnEntrega.Click, AddressOf btnEntrega_Click
        AddHandler btnRetorno.Click, AddressOf btnRetorno_Click
        filtroEstado.SelectedIndex = 0
        btnNuevo.Enabled = False
    End Sub

    Public Sub New(idUsuario As Integer, nombreUsuario As String, rol As String)
        Me.New()
        idBibliotecario = idUsuario
        nombreBibliotecario = nombreUsuario
        puedeOperar = seguridadNegocio.PuedeOperar(idUsuario, rol)
        btnNuevo.Enabled = puedeOperar
        lblDescripcionVista.Text = "Sesión: " & nombreUsuario & " · " & rol & " · Una fila por ejemplar físico"
    End Sub

    Public Sub AplicarContexto(filtro As String, Optional idLector As Integer = 0, Optional idPrestamo As Integer = 0)
        lectorContexto = idLector
        prestamoContexto = idPrestamo
        buscar.Clear()
        filtroEstado.SelectedItem = filtro
        Filtrar()
    End Sub

    Public Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated OrElse idBibliotecario <= 0 Then Return
        Try
            datos = negocio.listar()
            Filtrar()
        Catch ex As Exception
            datos.Clear()
            Filtrar()
            resumen.Text = "No se pudieron cargar los préstamos. Pulsa Actualizar para reintentar."
            MessageBox.Show(ex.Message, "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Filtrar()
        Dim texto = buscar.Text.Trim()
        Dim filtro = CStr(filtroEstado.SelectedItem)
        Dim hoy = Date.Today
        Dim filas = prestamoNegocio.FiltrarConsulta(datos, filtro, texto, lectorContexto, prestamoContexto, hoy)
        tabla.DataSource = filas
        tabla.ClearSelection()
        resumen.Text = filas.Count & " préstamo(s) · Activos incluye vencidos · Vencido: fecha límite anterior a hoy · Retraso guardado al devolver"
        If lectorContexto > 0 OrElse prestamoContexto > 0 Then resumen.Text = filas.Count & " préstamo(s) del contexto seleccionado · Actualizar quita el filtro de lector/préstamo"
        ActualizarSeleccion()
    End Sub

    Private Function Seleccionado() As Prestamo
        If tabla.SelectedRows.Count = 0 Then Return Nothing
        Return TryCast(tabla.SelectedRows(0).DataBoundItem, Prestamo)
    End Function

    Private Sub ActualizarSeleccion()
        Dim prestamo = Seleccionado()
        btnDevolver.Enabled = puedeOperar AndAlso prestamoNegocio.PuedeDevolver(prestamo)
        btnEntrega.Enabled = puedeOperar AndAlso prestamo IsNot Nothing
        btnRetorno.Enabled = puedeOperar AndAlso prestamo IsNot Nothing AndAlso prestamo.FechaRetorno.HasValue
    End Sub

    Private Sub VerComprobante(devolucion As Boolean)
        Dim actual = Seleccionado()
        If actual Is Nothing Then Return
        Try
            ComprobanteImpresion.Mostrar(New comprobanteNegocio().PorPrestamo(actual.IdPrestamo, devolucion), Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub FormatearCelda(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles tabla.CellFormatting
        If e.RowIndex < 0 OrElse tabla.Columns(e.ColumnIndex).Name <> "EstadoPrestamo" Then Return
        Dim prestamo = TryCast(tabla.Rows(e.RowIndex).DataBoundItem, Prestamo)
        If prestamo Is Nothing Then Return
        e.Value = prestamoNegocio.EstadoParaMostrar(prestamo, Date.Today)
        e.FormattingApplied = True
        If prestamoNegocio.EstaVencido(prestamo, Date.Today) Then e.CellStyle.ForeColor = Color.FromArgb(185, 45, 45)
    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        NuevoPrestamo()
    End Sub

    Public Sub NuevoPrestamo(Optional lectorInicial As Usuario = Nothing)
        If Not puedeOperar Then Return
        Using editor As New frmPrestamoDetalle(idBibliotecario, nombreBibliotecario, lectorInicial)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then
                ActualizarDatos()
                RaiseEvent DatosCambiados()
            End If
        End Using
    End Sub

    Private Sub Devolver_Click(sender As Object, e As EventArgs) Handles btnDevolver.Click
        Dim prestamo = Seleccionado()
        If Not puedeOperar OrElse Not prestamoNegocio.PuedeDevolver(prestamo) Then Return
        Using editor As New frmPrestamoDevolucion(prestamo, idBibliotecario, nombreBibliotecario)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then
                ActualizarDatos()
                RaiseEvent DatosCambiados()
            End If
        End Using
    End Sub

    Private Sub btnEntrega_Click(sender As Object, e As EventArgs)
        VerComprobante(False)
    End Sub

    Private Sub btnRetorno_Click(sender As Object, e As EventArgs)
        VerComprobante(True)
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarDatos()
    End Sub

    Private Sub buscar_TextChanged(sender As Object, e As EventArgs) Handles buscar.TextChanged
        If Not IsHandleCreated Then Return
        Filtrar()
    End Sub

    Private Sub filtroEstado_SelectedIndexChanged2(sender As Object, e As EventArgs) Handles filtroEstado.SelectedIndexChanged
        If Not IsHandleCreated Then Return
        Filtrar()
    End Sub

    Private Sub tabla_SelectionChanged(sender As Object, e As EventArgs) Handles tabla.SelectionChanged
        If Not IsHandleCreated Then Return
        ActualizarSeleccion()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        lectorContexto = 0
        prestamoContexto = 0
        ActualizarDatos()
    End Sub
End Class
