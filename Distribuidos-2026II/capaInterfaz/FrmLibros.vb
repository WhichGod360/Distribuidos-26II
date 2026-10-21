Imports System.Runtime.InteropServices
Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class FrmLibros
    Implements IMantenimientoVista

    ' --- API nativa para poner texto de ayuda (Placeholder) en txtBuscar ---
    Private Const EM_SETCUEBANNER As Integer = &H1501
    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, lParam As String) As IntPtr
    End Function

    Public Event SolicitarEjemplares(idLibro As Integer, titulo As String)
    Private ReadOnly negocioLibro As New libroNegocio()
    Private librosActuales As New List(Of Libro)()
    Private ReadOnly colorPrimario As Color = MantenimientoUI.Primario
    Private ReadOnly dtLibros As New DataTable("Libros")
    Private vista As DataView
    Private Const TamPagina As Integer = 10
    Private paginaActual As Integer = 1
    Private ReadOnly fuenteEstado As New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)

    Public Sub New()
        InitializeComponent()
        DataGridView1.AutoGenerateColumns = False
        colId.DataPropertyName = "id"
        colTitulo.DataPropertyName = "titulo"
        colEditorial.DataPropertyName = "editorial"
        colAnio.DataPropertyName = "anio"
        colStock.DataPropertyName = "stock"
        colEstado.DataPropertyName = "estado"

        colId.FillWeight = 8
        colTitulo.FillWeight = 36
        colEditorial.FillWeight = 20
        colAnio.FillWeight = 10
        colStock.FillWeight = 10
        colEstado.FillWeight = 16

        dtLibros.Columns.Add("id", GetType(Integer))
        dtLibros.Columns.Add("titulo", GetType(String))
        dtLibros.Columns.Add("editorial", GetType(String))
        dtLibros.Columns.Add("anio", GetType(Integer))
        dtLibros.Columns.Add("stock", GetType(Integer))
        dtLibros.Columns.Add("estado", GetType(String))

        cboEstado.SelectedIndex = 0
        cboOrden.SelectedIndex = 0

        ' Aplicamos la mejora visual moderna
        AplicarEstilosModernos()

        AddHandler DataGridView1.CellFormatting, AddressOf dgvLibros_CellFormatting
        AddHandler DataGridView1.SelectionChanged, AddressOf SeleccionChanged
        AddHandler btnEditar.Click, Sub()
                                        Dim libro = LibroSeleccionado()
                                        If libro IsNot Nothing Then EditarLibro(libro.IdLibro)
                                    End Sub
        AddHandler btnDesactivar.Click, Sub()
                                            Dim libro = LibroSeleccionado()
                                            If libro IsNot Nothing Then EliminarLibro(libro.IdLibro)
                                        End Sub
        AddHandler btnEjemplares.Click, Sub()
                                            Dim libro = LibroSeleccionado()
                                            If libro IsNot Nothing Then RaiseEvent SolicitarEjemplares(libro.IdLibro, libro.TituloLibro)
                                        End Sub
    End Sub

    ' =====================================================================
    '  MEJORA VISUAL PARA PRESENTACIÓN
    ' =====================================================================
    Private Sub AplicarEstilosModernos()
        Me.BackColor = Color.FromArgb(248, 250, 252) ' Fondo general gris azulado súper limpio

        ' 1. Estilizar Botón Principal (Agregar)
        btnAgregar.Text = "＋ Agregar libro"
        btnAgregar.FlatStyle = FlatStyle.Flat
        btnAgregar.FlatAppearance.BorderSize = 0
        btnAgregar.BackColor = colorPrimario
        btnAgregar.ForeColor = Color.White
        btnAgregar.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnAgregar.Cursor = Cursors.Hand

        ' 2. Estilizar Botones de Acción Secundarios
        btnEditar.Text = "✎ Editar"
        EstilizarBotonSecundario(btnEditar, Color.FromArgb(51, 65, 85), Color.FromArgb(203, 213, 225))

        btnEjemplares.Text = "📚 Ver ejemplares"
        EstilizarBotonSecundario(btnEjemplares, Color.FromArgb(30, 64, 175), Color.FromArgb(191, 219, 254))

        btnDesactivar.Text = "✕ Desactivar"
        EstilizarBotonSecundario(btnDesactivar, Color.FromArgb(185, 28, 28), Color.FromArgb(254, 202, 202))

        ' 3. Estilizar DataGridView (Estilo Tabla Web Moderna)
        With DataGridView1
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = Color.FromArgb(226, 232, 240)
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToResizeRows = False
            .EnableHeadersVisualStyles = False

            ' Estilo de Cabecera
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .ColumnHeadersHeight = 44
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85)
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249)
            .ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(51, 65, 85)
            .ColumnHeadersDefaultCellStyle.Padding = New Padding(8, 0, 0, 0)

            ' Estilo de Filas
            .RowTemplate.Height = 42
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255) ' Azul suave al seleccionar
            .DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 138)
            .DefaultCellStyle.Padding = New Padding(8, 0, 0, 0)

            ' Filas alternas (Efecto Cebra sutil)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
        End With

        ' Alineación de columnas numéricas y estado
        colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colAnio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' 4. Estilizar botones de paginación Anterior / Siguiente
        For Each btnPag As Button In {btnPagPrev, btnPagNext}
            btnPag.FlatStyle = FlatStyle.Flat
            btnPag.BackColor = Color.White
            btnPag.ForeColor = Color.FromArgb(51, 65, 85)
            btnPag.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225)
            btnPag.Cursor = Cursors.Hand
        Next
    End Sub

    Private Sub EstilizarBotonSecundario(btn As Button, colorTexto As Color, colorBorde As Color)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 1
        btn.FlatAppearance.BorderColor = colorBorde
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249)
        btn.BackColor = Color.White
        btn.ForeColor = colorTexto
        btn.Font = New Font("Segoe UI Semibold", 9.25F, FontStyle.Bold)
        btn.Cursor = Cursors.Hand
    End Sub

    Private Sub FrmLibros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        ' Poner texto guía en el buscador
        If txtBuscar.IsHandleCreated Then
            SendMessage(txtBuscar.Handle, EM_SETCUEBANNER, 1, "🔍 Buscar por título o editorial...")
        End If
        ActualizarDatos()
    End Sub

    Public Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        Dim libro = LibroSeleccionado()
        CargarDatosDesdeBD()
        AplicarFiltros(False)
        If libro IsNot Nothing Then
            For Each fila As DataGridViewRow In DataGridView1.Rows
                If CInt(fila.Cells("colId").Value) = libro.IdLibro Then fila.Selected = True
            Next
        End If
    End Sub

    Private Function LibroSeleccionado() As Libro
        If DataGridView1.SelectedRows.Count = 0 Then Return Nothing
        Dim id = CInt(DataGridView1.SelectedRows(0).Cells("colId").Value)
        Return librosActuales.FirstOrDefault(Function(l) l.IdLibro = id)
    End Function

    Private Sub SeleccionChanged(sender As Object, e As EventArgs)
        Dim libro = LibroSeleccionado()
        btnEditar.Enabled = libro IsNot Nothing
        btnEjemplares.Enabled = libro IsNot Nothing
        btnDesactivar.Enabled = libro IsNot Nothing AndAlso libro.EstadoLibro
    End Sub

    Private Sub CargarDatosDesdeBD()
        Try
            dtLibros.Rows.Clear()
            librosActuales = negocioLibro.listarTodos()
            For Each libro As Libro In librosActuales
                dtLibros.Rows.Add(libro.IdLibro, libro.TituloLibro, libro.EditorialLibro,
                                  If(libro.AnoPublicacion.HasValue, libro.AnoPublicacion.Value, 0),
                                  libro.StockTotal, If(libro.EstadoLibro, "Activo", "Inactivo"))
            Next
            vista = New DataView(dtLibros)
        Catch ex As Exception
            MessageBox.Show("No se pudo cargar el catálogo de libros: " & ex.Message, "Libros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            vista = New DataView(dtLibros)
        End Try
    End Sub

    ' =====================================================================
    '  FILTROS / ORDEN / PAGINACIÓN
    ' =====================================================================
    Private Sub AplicarFiltros(Optional resetPagina As Boolean = True)
        If vista Is Nothing Then Return

        Dim filtros As New List(Of String)
        Dim txt = txtBuscar.Text.Trim().Replace("'", "''")
        txt = txt.Replace("[", "[[]").Replace("*", "[*]").Replace("%", "[%]")
        If txt <> "" Then filtros.Add("(titulo LIKE '%" & txt & "%' OR editorial LIKE '%" & txt & "%')")

        Select Case cboEstado.SelectedIndex
            Case 1 : filtros.Add("estado = 'Activo'")
            Case 2 : filtros.Add("estado = 'Inactivo'")
        End Select
        vista.RowFilter = String.Join(" AND ", filtros)

        Select Case cboOrden.SelectedIndex
            Case 1 : vista.Sort = "titulo DESC"
            Case 2 : vista.Sort = "anio ASC"
            Case 3 : vista.Sort = "anio DESC"
            Case Else : vista.Sort = "titulo ASC"
        End Select

        If resetPagina Then paginaActual = 1
        MostrarPagina()
    End Sub

    Private Sub MostrarPagina()
        Dim total = vista.Count
        Dim totalPaginas = Math.Max(1, CInt(Math.Ceiling(total / TamPagina)))
        paginaActual = Math.Min(Math.Max(1, paginaActual), totalPaginas)

        Dim pagina = dtLibros.Clone()
        Dim ini = (paginaActual - 1) * TamPagina
        Dim fin = Math.Min(ini + TamPagina, total) - 1
        For i As Integer = ini To fin
            pagina.ImportRow(vista(i).Row)
        Next

        DataGridView1.DataSource = pagina
        DataGridView1.ClearSelection()
        lblRegistros.Text = If(total = 0, "Sin registros para mostrar",
                               "Mostrando " & (ini + 1) & "–" & (fin + 1) & " de " & total & " libros")
        ConstruirPaginacion(totalPaginas)
    End Sub

    Private Sub ConstruirPaginacion(totalPaginas As Integer)
        flpNumeros.SuspendLayout()
        For i As Integer = flpNumeros.Controls.Count - 1 To 0 Step -1
            flpNumeros.Controls(i).Dispose()
        Next

        Dim ini = Math.Max(1, paginaActual - 2)
        Dim fin = Math.Min(totalPaginas, ini + 4)
        ini = Math.Max(1, fin - 4)

        For p As Integer = ini To fin
            Dim b As New Button()
            b.Text = p.ToString()
            b.Tag = p
            b.Size = New Size(34, 30)
            b.Margin = New Padding(3)
            b.Cursor = Cursors.Hand
            b.FlatStyle = FlatStyle.Flat
            b.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
            If p = paginaActual Then
                b.BackColor = colorPrimario
                b.ForeColor = Color.White
                b.FlatAppearance.BorderColor = colorPrimario
            Else
                b.BackColor = Color.White
                b.ForeColor = Color.FromArgb(51, 65, 85)
                b.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225)
            End If
            AddHandler b.Click, AddressOf Pagina_Click
            flpNumeros.Controls.Add(b)
        Next
        flpNumeros.ResumeLayout()

        btnPagPrev.Enabled = paginaActual > 1
        btnPagNext.Enabled = paginaActual < totalPaginas
    End Sub

    Private Sub Pagina_Click(sender As Object, e As EventArgs)
        paginaActual = CInt(DirectCast(sender, Button).Tag)
        MostrarPagina()
    End Sub

    Private Sub btnPagPrev_Click(sender As Object, e As EventArgs) Handles btnPagPrev.Click
        paginaActual -= 1
        MostrarPagina()
    End Sub

    Private Sub btnPagNext_Click(sender As Object, e As EventArgs) Handles btnPagNext.Click
        paginaActual += 1
        MostrarPagina()
    End Sub

    Private Sub Filtro_Changed(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged, cboEstado.SelectedIndexChanged, cboOrden.SelectedIndexChanged
        AplicarFiltros()
    End Sub

    ' =====================================================================
    '  GRILLA (ESTILO BADGE EN ESTADO Y STOCK)
    ' =====================================================================
    Private Sub dgvLibros_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 Then Return

        Dim nombreCol = DataGridView1.Columns(e.ColumnIndex).Name
        If nombreCol = "colEstado" Then
            Dim activo = Convert.ToString(e.Value) = "Activo"
            e.CellStyle.Font = fuenteEstado
            If activo Then
                e.Value = "● Activo"
                e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61) ' Verde oscuro elegante
                e.CellStyle.SelectionForeColor = Color.FromArgb(21, 128, 61)
            Else
                e.Value = "○ Inactivo"
                e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28) ' Rojo elegante
                e.CellStyle.SelectionForeColor = Color.FromArgb(185, 28, 28)
            End If
        ElseIf nombreCol = "colStock" Then
            Dim stock As Integer = 0
            If e.Value IsNot Nothing AndAlso Integer.TryParse(e.Value.ToString(), stock) Then
                If stock = 0 Then
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28)
                    e.CellStyle.Font = fuenteEstado
                End If
            End If
        End If
    End Sub

    Private Sub dgvLibros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim id = CInt(DataGridView1.Rows(e.RowIndex).Cells("colId").Value)
        Select Case DataGridView1.Columns(e.ColumnIndex).Name
            Case "DataGridViewButtonColumn1" : EditarLibro(id)
            Case "DataGridViewButtonColumn2" : EliminarLibro(id)
        End Select
    End Sub

    ' =====================================================================
    '  AGREGAR / EDITAR / ELIMINAR
    ' =====================================================================
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Using editor As New FrmLibroDetalle()
            editor.ConfigurarGuardado(Function(f) GuardarLibro(f, 0))
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ActualizarDatos()
        End Using
    End Sub

    Private Sub EditarLibro(id As Integer)
        Dim libro = librosActuales.FirstOrDefault(Function(l) l.IdLibro = id)
        If libro Is Nothing Then Return
        Dim gestionar As Boolean
        Using editor As New FrmLibroDetalle()
            Dim anio = If(libro.AnoPublicacion.HasValue AndAlso libro.AnoPublicacion.Value > 0, CInt(libro.AnoPublicacion.Value), Date.Now.Year)
            editor.CargarParaEditar(id, libro.TituloLibro, libro.EditorialLibro, New Date(anio, 1, 1),
                SepararNombres(libro.Autor), SepararNombres(libro.Categoria), libro.PublicoLibro,
                libro.StockTotal, libro.StockTotal, libro.EstadoLibro)
            editor.ConfigurarGuardado(Function(f) GuardarLibro(f, id))
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ActualizarDatos()
            gestionar = editor.GestionarEjemplaresSolicitado
        End Using
        If gestionar Then RaiseEvent SolicitarEjemplares(libro.IdLibro, libro.TituloLibro)
    End Sub

    Private Function GuardarLibro(editor As FrmLibroDetalle, id As Integer) As Boolean
        Try
            Dim ok As Boolean
            If id = 0 Then
                ok = negocioLibro.agregarLibroCompleto(editor.Titulo, editor.Editorial, CShort(editor.Anio.Year), editor.Publico,
                    editor.Activo, negocioLibro.ResolverAutores(editor.Autores), negocioLibro.ResolverCategorias(editor.Categorias), editor.CantidadEjemplares)
            Else
                ok = negocioLibro.actualizarLibroCompleto(id, editor.Titulo, editor.Editorial, CShort(editor.Anio.Year), editor.Publico,
                    editor.Activo, negocioLibro.ResolverAutores(editor.Autores), negocioLibro.ResolverCategorias(editor.Categorias))
            End If
            If Not ok Then Throw New InvalidOperationException("No se pudo guardar el libro.")
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Libros", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
    End Function

    Private Sub EliminarLibro(id As Integer)
        Dim libro = librosActuales.FirstOrDefault(Function(l) l.IdLibro = id)
        If libro Is Nothing Then Return
        If MessageBox.Show("¿Deseas desactivar el libro '" & libro.TituloLibro & "'?", "Libros", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            If Not negocioLibro.eliminarLibro(id) Then Throw New InvalidOperationException("No se pudo desactivar el libro.")
            ActualizarDatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Libros", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Shared Function SepararNombres(valor As String) As IEnumerable(Of String)
        If String.IsNullOrWhiteSpace(valor) Then Return Array.Empty(Of String)()
        Return valor.Split(New String() {", "}, StringSplitOptions.RemoveEmptyEntries)
    End Function

End Class