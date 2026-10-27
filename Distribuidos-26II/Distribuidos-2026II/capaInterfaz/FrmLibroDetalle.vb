Imports capaNegocio

Public Class FrmLibroDetalle

    Private _modificado As Boolean = False
    Private _idLibro As Integer
    Private ReadOnly negocio As New libroNegocio()
    Private solicitarEjemplares As Boolean

    Public ReadOnly Property GestionarEjemplaresSolicitado As Boolean
        Get
            Return solicitarEjemplares
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
        nudCantidad.Maximum = 500
        nudCantidad.Minimum = 0
        dtpAnio.Format = DateTimePickerFormat.Custom
        dtpAnio.CustomFormat = "yyyy"
        dtpAnio.ShowUpDown = True
    End Sub

    ' =====================================================================
    '  DATOS EXPUESTOS AL FORMULARIO QUE LO LLAMA
    ' =====================================================================
    Public ReadOnly Property Titulo As String
        Get
            Return txtTitulo.Text.Trim()
        End Get
    End Property

    Public ReadOnly Property Editorial As String
        Get
            Return txtEditorial.Text.Trim()
        End Get
    End Property

    Public ReadOnly Property Anio As Date
        Get
            Return dtpAnio.Value
        End Get
    End Property

    Public ReadOnly Property Autores As List(Of String)
        Get
            Return ObtenerChips(flpAutores)
        End Get
    End Property

    Public ReadOnly Property Categorias As List(Of String)
        Get
            Return ObtenerChips(flpCategorias)
        End Get
    End Property

    Public ReadOnly Property Publico As String
        Get
            Return Convert.ToString(cboPublico.SelectedItem)
        End Get
    End Property

    Public ReadOnly Property CantidadEjemplares As Integer
        Get
            Return CInt(nudCantidad.Value)
        End Get
    End Property

    Public ReadOnly Property Activo As Boolean
        Get
            Return chkActivo.Checked
        End Get
    End Property

    ' =====================================================================
    '  MODO EDICIÓN  (si no se llama, el formulario funciona como "Agregar")
    ' =====================================================================
    Public Sub CargarParaEditar(id As Integer, titulo As String, editorial As String, fechaPublicacion As Date,
                                autores As IEnumerable(Of String), categorias As IEnumerable(Of String),
                                publico As String, totalEjemplares As Integer, disponibles As Integer,
                                activo As Boolean)
        _idLibro = id
        lblTituloVista.Text = "Editar libro"
        lblDescripcionVista.Text = "Modifica los datos del libro. Registro N.º " & id & "."
        btnGuardar.Text = "Guardar cambios"

        txtTitulo.Text = titulo
        txtEditorial.Text = editorial
        dtpAnio.Value = fechaPublicacion
        For Each a In autores
            AgregarChip(flpAutores, btnAddAutor, a)
        Next
        For Each c In categorias
            AgregarChip(flpCategorias, btnAddCategoria, c)
        Next
        cboPublico.SelectedIndex = cboPublico.FindStringExact(publico)
        If cboPublico.SelectedIndex < 0 AndAlso Not String.IsNullOrWhiteSpace(publico) Then
            cboPublico.Items.Add(publico)
            cboPublico.SelectedIndex = cboPublico.Items.Count - 1
        End If
        chkActivo.Checked = activo

        ' En edición no se cambia la cantidad: se muestra el resumen y el enlace "Gestionar"
        bloque_nudCantidad.Visible = False
        nudCantidad.Visible = False

        bloque_pnlEjemplares.Visible = True
        pnlEjemplares.Visible = True
        lblEjemplaresInfo.Text = totalEjemplares & " (" & disponibles & " disponibles)"

        _modificado = False
    End Sub

    ' =====================================================================
    '  EVENTOS
    ' =====================================================================
    Private Sub FrmLibroDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        ConfigurarDiseno()
        _modificado = False
    End Sub

    Private Sub ConfigurarDiseno()
        lblTituloVista.Text = If(_idLibro = 0, "Agregar libro", "Editar libro")
        Text = lblTituloVista.Text
        bloque_nudCantidad.Visible = _idLibro = 0
        bloque_pnlEjemplares.Visible = _idLibro > 0
        btnCancelar.DialogResult = DialogResult.None
    End Sub

    Private Sub FrmLibroDetalle_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.DrawRectangle(Pens.Silver, 0, 0, Width - 1, Height - 1)
    End Sub

    Private Sub Marcar(sender As Object, e As EventArgs) Handles txtTitulo.TextChanged, txtEditorial.TextChanged, dtpAnio.ValueChanged, cboPublico.SelectedIndexChanged, nudCantidad.ValueChanged, chkActivo.CheckedChanged
        _modificado = True
    End Sub

    Private Sub btnAddAutor_Click(sender As Object, e As EventArgs) Handles btnAddAutor.Click
        Try
            Dim nombres = New capaNegocio.autorNegocio().listarTodos().Select(Function(a) a.NombreAutor).
                Where(Function(n) Not Autores.Contains(n, StringComparer.OrdinalIgnoreCase)).ToList()
            SeleccionarRegistro("Seleccionar autor", nombres, flpAutores, btnAddAutor)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autores", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddCategoria_Click(sender As Object, e As EventArgs) Handles btnAddCategoria.Click
        Try
            Dim nombres = New capaNegocio.categoriaNegocio().listarActivas().
                Where(Function(n) Not Categorias.Contains(n, StringComparer.OrdinalIgnoreCase)).ToList()
            SeleccionarRegistro("Seleccionar categoría", nombres, flpCategorias, btnAddCategoria)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SeleccionarRegistro(titulo As String, nombres As List(Of String), panel As FlowLayoutPanel, agregar As Button)
        If nombres.Count = 0 Then
            MessageBox.Show("No hay registros disponibles para añadir. Revisa el mantenimiento correspondiente.",
                titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using selector As New frmSeleccionCatalogo(titulo, nombres)
            If Utiles.MantenimientoUI.MostrarDialogo(selector, Me) = DialogResult.OK Then
                AgregarChip(panel, agregar, selector.NombreSeleccionado)
                _modificado = True
            End If
        End Using
    End Sub

    Private Sub lnkGestionar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGestionar.LinkClicked
        If _idLibro <= 0 Then
            MessageBox.Show("Guarda primero el libro; después podrás administrar sus ejemplares.",
                            "Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If _modificado AndAlso FrmConfirmacion.Mostrar(Me, TipoConfirmacion.Advertencia, "Cambios sin guardar",
            "Se descartarán los cambios del formulario al ir a ejemplares.", "Continuar", "Seguir editando") <> DialogResult.OK Then Return
        solicitarEjemplares = True
        DialogResult = DialogResult.Ignore
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim guardado As Boolean
            If _idLibro = 0 Then
                guardado = negocio.agregarLibroCompleto(Titulo, Editorial, CShort(Anio.Year), Publico,
                    Activo, negocio.ResolverAutores(Autores), negocio.ResolverCategorias(Categorias), CantidadEjemplares)
            Else
                guardado = negocio.actualizarLibroCompleto(_idLibro, Titulo, Editorial, CShort(Anio.Year), Publico,
                    Activo, negocio.ResolverAutores(Autores), negocio.ResolverCategorias(Categorias))
            End If
            If Not guardado Then Throw New InvalidOperationException("No se pudo guardar el libro.")
            _modificado = False
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Libros", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Salir(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If _modificado Then
            Dim r = FrmConfirmacion.Mostrar(Me, TipoConfirmacion.Advertencia, "Tienes cambios sin guardar",
                        "Si sales ahora, se perderán los cambios que hiciste en este formulario.",
                        "Salir sin guardar", "Seguir editando")
            If r <> DialogResult.OK Then Return
        End If
        _modificado = False
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub AlCerrar(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _modificado OrElse (DialogResult <> DialogResult.Cancel AndAlso DialogResult <> DialogResult.None) Then Return
        If FrmConfirmacion.Mostrar(Me, TipoConfirmacion.Advertencia, "Cambios sin guardar",
            "Se perderán los cambios del formulario.", "Salir sin guardar", "Seguir editando") <> DialogResult.OK Then
            e.Cancel = True
            DialogResult = DialogResult.None
        Else
            _modificado = False
        End If
    End Sub

    ' =====================================================================
    '  AUXILIARES
    ' =====================================================================

    Private Function ObtenerChips(panel As FlowLayoutPanel) As List(Of String)
        Dim lista As New List(Of String)
        For Each c As Control In panel.Controls
            If TypeOf c Is Label Then lista.Add(CStr(c.Tag))
        Next
        Return lista
    End Function

    Private Sub AgregarChip(panel As FlowLayoutPanel, botonAgregar As Button, texto As String)
        Dim chip As New Label()
        chip.AutoSize = True
        chip.BackColor = Color.FromArgb(209, 217, 255)
        chip.ForeColor = Color.FromArgb(25, 35, 140)
        chip.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        chip.Padding = New Padding(6, 3, 6, 3)
        chip.Margin = New Padding(3, 2, 3, 3)
        chip.Text = texto & "  ✕"
        chip.Tag = texto
        chip.Cursor = Cursors.Hand

        ' Clic sobre el chip = quitarlo
        AddHandler chip.Click, AddressOf QuitarChip

        Dim posicion = panel.Controls.IndexOf(botonAgregar)
        panel.Controls.Add(chip)
        panel.Controls.SetChildIndex(chip, posicion)
    End Sub

    Private Sub QuitarChip(sender As Object, e As EventArgs)
        Dim chip = DirectCast(sender, Label)
        chip.Parent.Controls.Remove(chip)
        chip.Dispose()
        _modificado = True
    End Sub

End Class
