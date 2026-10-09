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
    Public Event DatosCambiados()

    Public Sub New()
        InitializeComponent()
        filtroEstado.SelectedIndex = 0
        btnNuevo.Enabled = False
        AddHandler Load, Sub() ActualizarDatos()
        AddHandler buscar.TextChanged, Sub() Filtrar()
        AddHandler filtroEstado.SelectedIndexChanged, Sub() Filtrar()
        AddHandler tabla.SelectionChanged, Sub() ActualizarSeleccion()
        AddHandler tabla.CellFormatting, AddressOf FormatearCelda
        AddHandler btnNuevo.Click, AddressOf Nuevo_Click
        AddHandler btnDevolver.Click, AddressOf Devolver_Click
        AddHandler btnActualizar.Click, Sub()
                                             lectorContexto = 0
                                             prestamoContexto = 0
                                             ActualizarDatos()
                                         End Sub
    End Sub

    Public Sub New(idUsuario As Integer, nombreUsuario As String, rol As String)
        Me.New()
        idBibliotecario = idUsuario
        nombreBibliotecario = nombreUsuario
        puedeOperar = idUsuario > 0 AndAlso String.Equals(If(rol, "").Trim(), "Bibliotecario", StringComparison.OrdinalIgnoreCase)
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
            MessageBox.Show("No se pudieron cargar los préstamos: " & ex.Message, "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Filtrar()
        Dim texto = buscar.Text.Trim()
        Dim filtro = CStr(filtroEstado.SelectedItem)
        Dim hoy = Date.Today
        Dim filas = datos.Where(Function(p)
                                    If lectorContexto > 0 AndAlso p.IdUsuario <> lectorContexto Then Return False
                                    If prestamoContexto > 0 AndAlso p.IdPrestamo <> prestamoContexto Then Return False
                                    Select Case filtro
                                        Case "Activos"
                                            If Not p.EstaActivo Then Return False
                                        Case "Vencidos"
                                            If Not p.EstaVencido(hoy) Then Return False
                                        Case "Devueltos"
                                            If Not p.FechaRetorno.HasValue OrElse Not String.Equals(p.EstadoPrestamo.Trim(), Prestamo.EstadoDevuelto, StringComparison.OrdinalIgnoreCase) Then Return False
                                    End Select
                                    Dim contenido = $"{p.IdPrestamo} {p.NombreLector} {p.DniLector} {p.CorreoLector} {p.IdEjemplar} {p.TituloLibro}"
                                    Return contenido.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0
                                End Function).ToList()
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
        btnDevolver.Enabled = puedeOperar AndAlso prestamo IsNot Nothing AndAlso prestamo.EstaActivo
    End Sub

    Private Sub FormatearCelda(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse tabla.Columns(e.ColumnIndex).Name <> "EstadoPrestamo" Then Return
        Dim prestamo = TryCast(tabla.Rows(e.RowIndex).DataBoundItem, Prestamo)
        If prestamo Is Nothing Then Return
        e.Value = prestamo.EstadoParaMostrar(Date.Today)
        e.FormattingApplied = True
        If prestamo.EstaVencido(Date.Today) Then e.CellStyle.ForeColor = Color.FromArgb(185, 45, 45)
    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs)
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

    Private Sub Devolver_Click(sender As Object, e As EventArgs)
        Dim prestamo = Seleccionado()
        If Not puedeOperar OrElse prestamo Is Nothing OrElse Not prestamo.EstaActivo Then Return
        Using editor As New frmPrestamoDevolucion(prestamo, idBibliotecario, nombreBibliotecario)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then
                ActualizarDatos()
                RaiseEvent DatosCambiados()
            End If
        End Using
    End Sub
End Class
