Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmPrestamoDetalle

    Private ReadOnly negocio As New prestamoNegocio()

    Private Class CopiaSeleccionada
        Public Property IdLibro As Integer
        Public Property IdEjemplar As Integer
        Public Property Texto As String
    End Class

    Private ReadOnly copias As New System.ComponentModel.BindingList(Of CopiaSeleccionada)()
    Private ReadOnly listaCopias As New ListBox With {.Dock = DockStyle.Fill, .DisplayMember = NameOf(CopiaSeleccionada.Texto), .AccessibleName = "Ejemplares seleccionados"}
    Private WithEvents btnAgregarCopia As New Button With {.Text = "Agregar ejemplar", .Width = 145, .Height = 34}
    Private WithEvents btnQuitarCopia As New Button With {.Text = "Quitar seleccionado", .Width = 160, .Height = 34}

    Private cargandoCatalogo As Boolean
    Private ReadOnly libros As New libroNegocio()
    Private ReadOnly ejemplares As New ejemplarNegocio()
    Private ReadOnly idBibliotecario As Integer
    Private ReadOnly lectorInicial As Usuario

    Public Sub New()
        InitializeComponent()
        If Not ContextoDiseno.Activo(Me) Then
            ConfigurarSeleccion()
            ActualizarLimite()
        End If
        guardar.Enabled = False
    End Sub

    Public Sub New(idUsuario As Integer, nombreUsuario As String, Optional lectorElegido As Usuario = Nothing)
        Me.New()
        idBibliotecario = idUsuario
        lectorInicial = lectorElegido
        txtBibliotecario.Text = nombreUsuario & " · ID " & idUsuario
        guardar.Enabled = idUsuario > 0
    End Sub

    Private Sub ConfigurarSeleccion()
        Dim botones As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 40, .WrapContents = False}
        botones.Controls.AddRange({btnAgregarCopia, btnQuitarCopia})
        MantenimientoUI.EstilizarBoton(btnAgregarCopia)
        MantenimientoUI.EstilizarBoton(btnQuitarCopia)
        listaCopias.DataSource = copias
        Dim panel As New Panel With {.Dock = DockStyle.Fill, .Height = 110}
        panel.Controls.Add(listaCopias)
        panel.Controls.Add(botones)
        camposEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 110))
        camposEditor.RowCount += 1
        camposEditor.Controls.Add(panel, 0, camposEditor.RowCount - 1)
    End Sub

    Private Sub btnQuitarCopia_Click(sender As Object, e As EventArgs) Handles btnQuitarCopia.Click
        If listaCopias.SelectedIndex >= 0 Then copias.RemoveAt(listaCopias.SelectedIndex)
    End Sub

    Private Sub btnAgregarCopia_Click(sender As Object, e As EventArgs) Handles btnAgregarCopia.Click
        Dim titulo = TryCast(libro.SelectedItem, Libro)
        If Not TypeOf lector.SelectedValue Is Integer OrElse titulo Is Nothing OrElse Not TypeOf ejemplar.SelectedValue Is Integer Then
            MessageBox.Show("Selecciona lector, libro y ejemplar.", "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If copias.Count >= PoliticaPrestamo.MaximoEjemplares OrElse copias.Any(Function(copia) copia.IdLibro = titulo.IdLibro) Then
            MessageBox.Show("Selecciona hasta cinco títulos distintos.", "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim idCopia = CInt(ejemplar.SelectedValue)
        copias.Add(New CopiaSeleccionada With {.IdLibro = titulo.IdLibro, .IdEjemplar = idCopia, .Texto = $"{titulo.TituloLibro} · Ejemplar {idCopia}"})
    End Sub

    Private Sub Cargar(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) OrElse idBibliotecario <= 0 Then Return
        Try
            inicio.Value = Date.Today
            inicio.MaxDate = Date.Today
            inicio.Enabled = False
            ActualizarLimite()
            libro.DisplayMember = "TituloLibro"
            libro.ValueMember = "IdLibro"
            libro.DataSource = libros.listarDisponibles()
            libro.SelectedIndex = -1
            lector.DisplayMember = "Texto"
            lector.ValueMember = "IdUsuario"
            ejemplar.DisplayMember = "IdEjemplar"
            ejemplar.ValueMember = "IdEjemplar"
            ejemplar.SelectedIndex = -1
            If lectorInicial IsNot Nothing Then
                buscar.Text = lectorInicial.NumeroDniUsuario
                BuscarLectores(Me, EventArgs.Empty)
                lector.DroppedDown = False
                lector.SelectedValue = lectorInicial.IdUsuario
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarLimite()
        If ContextoDiseno.Activo(Me) Then Return
        limite.Value = prestamoNegocio.FechaLimite(inicio.Value)
    End Sub

    Private Sub BuscarLectores(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lector.DataSource = Nothing
        If String.IsNullOrWhiteSpace(buscar.Text) Then
            MessageBox.Show("Ingresa un nombre, apellido, DNI o correo para buscar al lector.", "Buscar lector", MessageBoxButtons.OK, MessageBoxIcon.Information)
            buscar.Focus()
            Return
        End If
        Try
            Dim resultados = negocio.buscarLectores(buscar.Text).Select(Function(u) New With {
                .IdUsuario = u.IdUsuario, .Texto = u.NombreCompleto & " · " & u.NumeroDniUsuario & " · " & u.EmailUsuario}).ToList()
            lector.DisplayMember = "Texto"
            lector.ValueMember = "IdUsuario"
            lector.DataSource = resultados
            lector.SelectedIndex = -1
            If resultados.Count = 0 Then MessageBox.Show("No se encontraron estudiantes activos con esos datos.", "Buscar lector", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lector.DroppedDown = resultados.Count > 0 AndAlso Visible
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarLibros()
        If ContextoDiseno.Activo(Me) OrElse idBibliotecario <= 0 OrElse cargandoCatalogo Then Return
        cargandoCatalogo = True
        Try
            Dim idLector = If(TypeOf lector.SelectedValue Is Integer, CInt(lector.SelectedValue), 0)
            libro.DataSource = libros.listarDisponibles(idLector)
            libro.SelectedIndex = -1

            lblPlazo.Text = "Cinco días desde la entrega presencial"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            cargandoCatalogo = False
        End Try
        CargarEjemplares()
    End Sub

    Private Sub CargarEjemplares()
        If ContextoDiseno.Activo(Me) OrElse idBibliotecario <= 0 Then Return
        ejemplar.DataSource = Nothing

        Dim seleccionado = TryCast(libro.SelectedItem, Libro)
        If seleccionado Is Nothing Then Return
        Try
            ejemplar.DisplayMember = "IdEjemplar"
            ejemplar.ValueMember = "IdEjemplar"
            Dim idLector = If(TypeOf lector.SelectedValue Is Integer, CInt(lector.SelectedValue), 0)
            ejemplar.DataSource = ejemplares.listarDisponiblesPorLibro(seleccionado.IdLibro, idLector)
            lblPlazo.Text = "Cinco días desde la entrega presencial"
            ejemplar.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Registrar(sender As Object, e As EventArgs) Handles guardar.Click
        If Not guardar.Enabled Then Return
        If Not TypeOf lector.SelectedValue Is Integer OrElse (copias.Count = 0 AndAlso Not TypeOf ejemplar.SelectedValue Is Integer) Then
            MessageBox.Show("Selecciona un lector y un ejemplar disponible.", "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        guardar.Enabled = False
        Try
            Dim ids = copias.Select(Function(copia) copia.IdEjemplar).ToList()
            If ids.Count = 0 Then ids.Add(CInt(ejemplar.SelectedValue))
            Dim id = negocio.registrar(CInt(lector.SelectedValue), idBibliotecario, ids, Date.Today)
            MessageBox.Show($"Préstamo N.º {id} registrado con {ids.Count} ejemplar(es).", "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "No se pudo registrar el préstamo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CargarEjemplares()
        Finally
            guardar.Enabled = True
        End Try
    End Sub

    Private Sub buscar_KeyDown(sender As Object, e As KeyEventArgs) Handles buscar.KeyDown
        If e.KeyCode <> Keys.Enter Then Return
        e.SuppressKeyPress = True
        BuscarLectores(sender, EventArgs.Empty)
    End Sub

    Private Sub lector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lector.SelectedIndexChanged
        If Not IsHandleCreated Then Return
        copias.Clear()
        CargarLibros()
    End Sub

    Private Sub libro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles libro.SelectedIndexChanged
        If Not IsHandleCreated Then Return
        CargarEjemplares()
    End Sub

    Private Sub inicio_ValueChanged(sender As Object, e As EventArgs) Handles inicio.ValueChanged
        If Not IsHandleCreated Then Return
        ActualizarLimite()
    End Sub
End Class
