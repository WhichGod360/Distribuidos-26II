Imports System.Runtime.InteropServices
Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class FrmLibros
    Implements IMantenimientoVista

    Public Event SolicitarEjemplares(idLibro As Integer, titulo As String)
    Private ReadOnly negocioLibro As New libroNegocio()
    Private librosActuales As New List(Of Libro)()
    Private ReadOnly colorPrimario As Color = MantenimientoUI.Primario
    Private ReadOnly dtLibros As New DataTable("Libros")
    Private vista As DataView
    Private Const TamPagina As Integer = 10
    Private paginaActual As Integer = 1
    Private ReadOnly fuenteEstado As New Font("Segoe UI", 10.0F, FontStyle.Bold)

    Public Sub New()
        InitializeComponent()
        DataGridView1.AutoGenerateColumns = False
        colId.DataPropertyName = "id"
        colTitulo.DataPropertyName = "titulo"
        colEditorial.DataPropertyName = "editorial"
        colAnio.DataPropertyName = "anio"
        colStock.DataPropertyName = "stock"
        colEstado.DataPropertyName = "estado"

        colId.FillWeight = 10
        colTitulo.FillWeight = 34
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
        btnAgregar.Text = "Agregar libro"
    End Sub

    Private Sub FrmLibros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
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
            MessageBox.Show(ex.Message, "Libros", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        lblRegistros.Text = If(total = 0, "Sin registros",
                               "Mostrando " & (ini + 1) & "–" & (fin + 1) & " de " & total & " registros")
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
                b.BackColor = colorPrimario
                b.ForeColor = Color.White
                b.FlatAppearance.BorderColor = colorPrimario
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
    '  GRILLA
    ' =====================================================================
    Private Sub dgvLibros_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.RowIndex >= 0 AndAlso DataGridView1.Columns(e.ColumnIndex).Name = "colEstado" Then
            Dim activo = Convert.ToString(e.Value) = "Activo"
            e.CellStyle.Font = fuenteEstado
            e.CellStyle.ForeColor = If(activo, Color.FromArgb(25, 35, 140), Color.FromArgb(90, 90, 100))
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
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ActualizarDatos()
            gestionar = editor.GestionarEjemplaresSolicitado
        End Using
        If gestionar Then RaiseEvent SolicitarEjemplares(libro.IdLibro, libro.TituloLibro)
    End Sub

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

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If Not IsHandleCreated Then Return
        SeleccionChanged(sender, e)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim libro = LibroSeleccionado()
        If libro IsNot Nothing Then EditarLibro(libro.IdLibro)
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        Dim libro = LibroSeleccionado()
        If libro IsNot Nothing Then EliminarLibro(libro.IdLibro)
    End Sub

    Private Sub btnEjemplares_Click(sender As Object, e As EventArgs) Handles btnEjemplares.Click
        Dim libro = LibroSeleccionado()
        If libro IsNot Nothing Then RaiseEvent SolicitarEjemplares(libro.IdLibro, libro.TituloLibro)
    End Sub

End Class
