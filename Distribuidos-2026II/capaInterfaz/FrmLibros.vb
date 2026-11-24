Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class FrmLibros
    Implements IMantenimientoVista

    Public Event SolicitarEjemplares(idLibro As Integer, titulo As String)
    Private ReadOnly negocioLibro As New libroNegocio()
    Private librosActuales As New List(Of Libro)()
    Private librosFiltrados As New List(Of Libro)()
    Private textoBuscado As String = ""
    Private estadoBuscado As Integer
    Private ordenElegido As Integer
    Private Const TamPagina As Integer = 10
    Private paginaActual As Integer = 1
    Private ReadOnly fuenteEstado As New Font("Segoe UI", 10.0F, FontStyle.Bold)

    Public Sub New()
        InitializeComponent()
        cboEstado.SelectedIndex = 0
        cboOrden.SelectedIndex = 0
    End Sub

    Private Sub FrmLibros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarLibros()
    End Sub

    Public Sub ListarLibros() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        Dim seleccionado = LibroSeleccionado()
        Try
            librosActuales = negocioLibro.listarTodos()
        Catch ex As Exception
            librosActuales.Clear()
            MessageBox.Show(ex.Message, "Libros", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        AplicarFiltros()
        If seleccionado Is Nothing Then Return
        For Each fila As DataGridViewRow In tablaLibros.Rows
            If DirectCast(fila.DataBoundItem, Libro).IdLibro = seleccionado.IdLibro Then
                fila.Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        textoBuscado = txtBuscar.Text.Trim()
        estadoBuscado = cboEstado.SelectedIndex
        ordenElegido = cboOrden.SelectedIndex
        paginaActual = 1
        AplicarFiltros()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Using editor As New FrmLibroDetalle()
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ListarLibros()
        End Using
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim libro = LibroSeleccionado()
        If libro Is Nothing Then Return
        Dim gestionar As Boolean
        Using editor As New FrmLibroDetalle()
            Dim anio = If(libro.AnoPublicacion.HasValue AndAlso libro.AnoPublicacion.Value > 0, CInt(libro.AnoPublicacion.Value), Date.Now.Year)
            editor.CargarParaEditar(libro.IdLibro, libro.TituloLibro, libro.EditorialLibro, New Date(anio, 1, 1),
                SepararNombres(libro.Autor), SepararNombres(libro.Categoria), libro.PublicoLibro,
                libro.StockTotal, libro.StockTotal, libro.EstadoLibro)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ListarLibros()
            gestionar = editor.GestionarEjemplaresSolicitado
        End Using
        If gestionar Then RaiseEvent SolicitarEjemplares(libro.IdLibro, libro.TituloLibro)
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        Dim libro = LibroSeleccionado()
        If libro Is Nothing Then Return
        If MessageBox.Show("¿Deseas desactivar el libro '" & libro.TituloLibro & "'?", "Libros", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            If Not negocioLibro.eliminarLibro(libro.IdLibro) Then Throw New InvalidOperationException("No se pudo desactivar el libro.")
            ListarLibros()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Libros", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnEjemplares_Click(sender As Object, e As EventArgs) Handles btnEjemplares.Click
        Dim libro = LibroSeleccionado()
        If libro IsNot Nothing Then RaiseEvent SolicitarEjemplares(libro.IdLibro, libro.TituloLibro)
    End Sub

    Private Function LibroSeleccionado() As Libro
        If tablaLibros.SelectedRows.Count = 0 Then Return Nothing
        Return TryCast(tablaLibros.SelectedRows(0).DataBoundItem, Libro)
    End Function

    Private Sub tablaLibros_SelectionChanged(sender As Object, e As EventArgs) Handles tablaLibros.SelectionChanged
        Dim libro = LibroSeleccionado()
        btnEditar.Enabled = libro IsNot Nothing
        btnEjemplares.Enabled = libro IsNot Nothing
        btnDesactivar.Enabled = libro IsNot Nothing AndAlso libro.EstadoLibro
    End Sub

    Private Shared Function SepararNombres(valor As String) As IEnumerable(Of String)
        If String.IsNullOrWhiteSpace(valor) Then Return Array.Empty(Of String)()
        Return valor.Split(New String() {", "}, StringSplitOptions.RemoveEmptyEntries)
    End Function

    Private Sub AplicarFiltros()
        Dim consulta As IEnumerable(Of Libro) = librosActuales
        If textoBuscado <> "" Then
            consulta = consulta.Where(Function(libro) libro.TituloLibro.Contains(textoBuscado, StringComparison.CurrentCultureIgnoreCase) OrElse
                                                      If(libro.EditorialLibro, "").Contains(textoBuscado, StringComparison.CurrentCultureIgnoreCase))
        End If
        If estadoBuscado > 0 Then consulta = consulta.Where(Function(libro) libro.EstadoLibro = (estadoBuscado = 1))
        Select Case ordenElegido
            Case 1
                consulta = consulta.OrderByDescending(Function(libro) libro.TituloLibro, StringComparer.CurrentCultureIgnoreCase)
            Case 2
                consulta = consulta.OrderBy(Function(libro) libro.AnoPublicacion.GetValueOrDefault())
            Case 3
                consulta = consulta.OrderByDescending(Function(libro) libro.AnoPublicacion.GetValueOrDefault())
            Case Else
                consulta = consulta.OrderBy(Function(libro) libro.TituloLibro, StringComparer.CurrentCultureIgnoreCase)
        End Select
        librosFiltrados = consulta.ToList()
        MostrarPagina()
    End Sub

    Private Sub MostrarPagina()
        Dim total = librosFiltrados.Count
        Dim totalPaginas = Math.Max(1, CInt(Math.Ceiling(total / TamPagina)))
        paginaActual = Math.Clamp(paginaActual, 1, totalPaginas)
        Dim inicio = (paginaActual - 1) * TamPagina
        Dim pagina = librosFiltrados.Skip(inicio).Take(TamPagina).ToList()

        tablaLibros.DataSource = pagina
        tablaLibros.ClearSelection()
        lblRegistros.Text = If(total = 0, "Sin registros",
                               $"Mostrando {inicio + 1}–{inicio + pagina.Count} de {total} registros")
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
            b.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 220)
            If p = paginaActual Then
                b.BackColor = MantenimientoUI.Primario
                b.ForeColor = Color.White
                b.FlatAppearance.BorderColor = MantenimientoUI.Primario
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

    Private Sub tablaLibros_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles tablaLibros.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex <> colEstado.Index OrElse Not TypeOf e.Value Is Boolean Then Return
        Dim activo = CBool(e.Value)
        e.Value = If(activo, "Activo", "Inactivo")
        e.CellStyle.Font = fuenteEstado
        e.CellStyle.ForeColor = If(activo, Color.FromArgb(25, 35, 140), Color.FromArgb(90, 90, 100))
        e.FormattingApplied = True
    End Sub
End Class
