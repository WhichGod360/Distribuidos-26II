Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmPrestamoDetalle

    Private ReadOnly negocio As New prestamoNegocio()
    Private ReadOnly libros As New libroNegocio()
    Private ReadOnly ejemplares As New ejemplarNegocio()
    Private ReadOnly idBibliotecario As Integer
    Private ReadOnly lectorInicial As Usuario

    Public Sub New()
        InitializeComponent()
        If Not ContextoDiseno.Activo(Me) Then ActualizarLimite()
        guardar.Enabled = False
        AddHandler Load, AddressOf Cargar
        AddHandler btnBuscar.Click, AddressOf BuscarLectores
        AddHandler buscar.KeyDown, Sub(sender, e)
                                      If e.KeyCode <> Keys.Enter Then Return
                                      e.SuppressKeyPress = True
                                      BuscarLectores(sender, EventArgs.Empty)
                                  End Sub
        AddHandler libro.SelectedIndexChanged, Sub() CargarEjemplares()
        AddHandler guardar.Click, AddressOf Registrar
        AddHandler inicio.ValueChanged, Sub() ActualizarLimite()
    End Sub

    Public Sub New(idUsuario As Integer, nombreUsuario As String, Optional lectorElegido As Usuario = Nothing)
        Me.New()
        idBibliotecario = idUsuario
        lectorInicial = lectorElegido
        txtBibliotecario.Text = nombreUsuario & " · ID " & idUsuario
        guardar.Enabled = idUsuario > 0
    End Sub

    Private Sub Cargar(sender As Object, e As EventArgs)
        If ContextoDiseno.Activo(Me) OrElse idBibliotecario <= 0 Then Return
        Try
            inicio.Value = Date.Today
            inicio.MaxDate = Date.Today
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
            MessageBox.Show("No se pudo cargar el catálogo: " & ex.Message, "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActualizarLimite()
        If ContextoDiseno.Activo(Me) Then Return
        limite.Value = PoliticaPrestamo.FechaLimite(inicio.Value)
    End Sub

    Private Sub BuscarLectores(sender As Object, e As EventArgs)
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
            MessageBox.Show("No se pudieron buscar los lectores: " & ex.Message, "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarEjemplares()
        If ContextoDiseno.Activo(Me) OrElse idBibliotecario <= 0 Then Return
        ejemplar.DataSource = Nothing
        Dim seleccionado = TryCast(libro.SelectedItem, Libro)
        If seleccionado Is Nothing Then Return
        Try
            ejemplar.DisplayMember = "IdEjemplar"
            ejemplar.ValueMember = "IdEjemplar"
            ejemplar.DataSource = ejemplares.listarDisponiblesPorLibro(seleccionado.IdLibro)
            ejemplar.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("No se pudo consultar la disponibilidad: " & ex.Message, "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Registrar(sender As Object, e As EventArgs)
        If Not guardar.Enabled Then Return
        If lector.SelectedValue Is Nothing OrElse ejemplar.SelectedValue Is Nothing Then
            MessageBox.Show("Selecciona un lector y un ejemplar disponible.", "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        guardar.Enabled = False
        Try
            Dim id = negocio.registrar(CInt(lector.SelectedValue), idBibliotecario, CInt(ejemplar.SelectedValue), inicio.Value)
            MessageBox.Show("Préstamo N.º " & id & " registrado.", "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "No se pudo registrar el préstamo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CargarEjemplares()
        Finally
            guardar.Enabled = True
        End Try
    End Sub
End Class
