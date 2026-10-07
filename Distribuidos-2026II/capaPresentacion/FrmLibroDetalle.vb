Class FrmLibroDetalle

    Private _modificado As Boolean = False

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
        lblTituloForm.Text = "Editar libro"
        lblSubtitulo.Text = "Modifica los datos del libro. Registro N.º " & id & "."
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
        chkActivo.Checked = activo

        ' En edición no se cambia la cantidad: se muestra el resumen y el enlace "Gestionar"
        lblCantidad.Visible = False
        nudCantidad.Visible = False
        lblCantidadAyuda.Visible = False
        lblEjemplares.Visible = True
        pnlEjemplares.Visible = True
        lblEjemplaresInfo.Text = totalEjemplares & " (" & disponibles & " disponibles)"

        _modificado = False
    End Sub

    ' =====================================================================
    '  EVENTOS
    ' =====================================================================
    Private Sub FrmLibroDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _modificado = False
    End Sub

    Private Sub FrmLibroDetalle_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.DrawRectangle(Pens.Silver, 0, 0, Width - 1, Height - 1)
    End Sub

    Private Sub Marcar(sender As Object, e As EventArgs) Handles txtTitulo.TextChanged, txtEditorial.TextChanged, dtpAnio.ValueChanged, cboPublico.SelectedIndexChanged, nudCantidad.ValueChanged, chkActivo.CheckedChanged
        _modificado = True
    End Sub

    Private Sub btnAddAutor_Click(sender As Object, e As EventArgs) Handles btnAddAutor.Click
        ' TODO: reemplazar el InputBox por un selector de autores existentes en la BD
        Dim nombre = Microsoft.VisualBasic.Interaction.InputBox("Nombre del autor:", "Añadir autor").Trim()
        If nombre <> "" AndAlso Not Autores.Contains(nombre) Then
            AgregarChip(flpAutores, btnAddAutor, nombre)
            _modificado = True
        End If
    End Sub

    Private Sub btnAddCategoria_Click(sender As Object, e As EventArgs) Handles btnAddCategoria.Click
        ' TODO: reemplazar el InputBox por un selector de categorías existentes en la BD
        Dim nombre = Microsoft.VisualBasic.Interaction.InputBox("Nombre de la categoría:", "Añadir categoría").Trim()
        If nombre <> "" AndAlso Not Categorias.Contains(nombre) Then
            AgregarChip(flpCategorias, btnAddCategoria, nombre)
            _modificado = True
        End If
    End Sub

    Private Sub lnkGestionar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGestionar.LinkClicked
        ' TODO: abrir el mantenimiento de Ejemplares filtrado por este libro
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If ValidarCampos() Then DialogResult = DialogResult.OK
    End Sub

    Private Sub Salir(sender As Object, e As EventArgs) Handles btnCancelar.Click, btnCerrar.Click
        If _modificado Then
            Dim r = FrmConfirmacion.Mostrar(Me, TipoConfirmacion.Advertencia, "Tienes cambios sin guardar",
                        "Si sales ahora, se perderán los cambios que hiciste en este formulario.",
                        "Salir sin guardar", "Seguir editando")
            If r <> DialogResult.OK Then Return
        End If
        DialogResult = DialogResult.Cancel
    End Sub

    ' =====================================================================
    '  AUXILIARES
    ' =====================================================================
    Private Function ValidarCampos() As Boolean
        Dim faltan As New List(Of String)
        If Titulo = "" Then faltan.Add("Título")
        If Editorial = "" Then faltan.Add("Editorial")
        If Autores.Count = 0 Then faltan.Add("Autores")
        If Categorias.Count = 0 Then faltan.Add("Categorías")
        If cboPublico.SelectedIndex < 0 Then faltan.Add("Público objetivo")
        If faltan.Count = 0 Then Return True

        FrmConfirmacion.Mostrar(Me, TipoConfirmacion.Bloqueo, "Faltan datos obligatorios",
                                "Completa: **" & String.Join(", ", faltan) & "**.", "Entendido")
        Return False
    End Function

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
        AddHandler chip.Click, Sub(s, ev)
                                   panel.Controls.Remove(chip)
                                   chip.Dispose()
                                   _modificado = True
                               End Sub

        Dim posicion = panel.Controls.IndexOf(botonAgregar)
        panel.Controls.Add(chip)
        panel.Controls.SetChildIndex(chip, posicion)
    End Sub

End Class
