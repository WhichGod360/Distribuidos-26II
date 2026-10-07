Imports System.Runtime.InteropServices
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FrmLibros

    ' ---------- Placeholder del TextBox (funciona en .NET Framework y .NET) ----------
    Private Const EM_SETCUEBANNER As Integer = &H1501
    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, lParam As String) As IntPtr
    End Function

    ' ---------- Estado ----------
    Private ReadOnly colorPrimario As Color = Color.FromArgb(74, 108, 247)
    Private ReadOnly dtLibros As New DataTable("Libros")
    Private vista As DataView
    Private Const TamPagina As Integer = 5
    Private paginaActual As Integer = 1
    Private fuenteEstado As Font
    Private fuenteSubNormal As Font
    Private fuenteSubActivo As Font

    ' =====================================================================
    '  CARGA
    ' =====================================================================
    Private Sub FrmLibros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SendMessage(txtBuscar.Handle, EM_SETCUEBANNER, 1, "Buscar en libros...")

        fuenteEstado = New Font(DataGridView1.Font, FontStyle.Bold)
        fuenteSubNormal = New Font("Segoe UI", 9.5!)
        fuenteSubActivo = New Font("Segoe UI", 9.5!, FontStyle.Bold)

        ' Avatar circular
        Dim gp As New GraphicsPath()
        gp.AddEllipse(0, 0, picUsuario.Width - 1, picUsuario.Height - 1)
        picUsuario.Region = New Region(gp)

        EstablecerUsuario("Nombre usuario", "Bibliotecario", False)

        CargarDatosEjemplo()
        cboEstado.SelectedIndex = 0
        cboOrden.SelectedIndex = 0
        AplicarFiltros()
    End Sub

    ''' <summary>Llamar desde el login para mostrar el usuario y habilitar el menú de administrador.</summary>
    Public Sub EstablecerUsuario(nombre As String, rol As String, esAdmin As Boolean)
        lblUsuario.Text = nombre
        lblRol.Text = rol
        For Each b As Button In New Button() {btnRoles, btnGestionarBibliotecarios, btnConfiguracion}
            b.Enabled = esAdmin
            If esAdmin Then b.Text = b.Text.Replace("🔒", "").Trim()
        Next
        AjustarEncabezado()
    End Sub

    Private Sub AjustarEncabezado() Handles pnlHeader.Resize
        Dim h = pnlHeader.Height
        picUsuario.Left = pnlHeader.Width - picUsuario.Width - 20
        picUsuario.Top = (h - picUsuario.Height) \ 2
        lblRol.Left = picUsuario.Left - 12 - lblRol.Width
        lblRol.Top = (h - lblRol.Height) \ 2
        lblUsuario.Left = lblRol.Left - 10 - lblUsuario.Width
        lblUsuario.Top = (h - lblUsuario.Height) \ 2
    End Sub

    ' =====================================================================
    '  DATOS  (DEMO: reemplazar por consultas a tu base de datos)
    ' =====================================================================
    Private Sub CargarDatosEjemplo()
        dtLibros.Columns.Add("id", GetType(Integer))
        dtLibros.Columns.Add("titulo", GetType(String))
        dtLibros.Columns.Add("editorial", GetType(String))
        dtLibros.Columns.Add("anio", GetType(Integer))
        dtLibros.Columns.Add("stock", GetType(Integer))
        dtLibros.Columns.Add("estado", GetType(String))
        For i As Integer = 1 To 48
            dtLibros.Rows.Add(i, "Título del libro " & i, "Editorial", 2020, 5 - (i Mod 5),
                              If(i Mod 4 = 0, "Inactivo", "Activo"))
        Next
        vista = New DataView(dtLibros)
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
        pnlPaginacion.Left = pnlContent.ClientSize.Width - 30 - pnlPaginacion.Width
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
    Private Sub dgvLibros_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
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
            Case "colEditar" : EditarLibro(id)
            Case "colEliminar" : EliminarLibro(id)
        End Select
    End Sub

    ' =====================================================================
    '  AGREGAR / EDITAR / ELIMINAR
    ' =====================================================================
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Using f As New FrmLibroDetalle()
            If f.ShowDialog(Me) = DialogResult.OK Then
                ' TODO: INSERT en la BD (libro + autores + categorías + f.CantidadEjemplares ejemplares)
                Dim id As Integer = If(dtLibros.Rows.Count = 0, 1, CInt(dtLibros.Compute("MAX(id)", "")) + 1)
                dtLibros.Rows.Add(id, f.Titulo, f.Editorial, f.Anio.Year, f.CantidadEjemplares,
                                  If(f.Activo, "Activo", "Inactivo"))
                AplicarFiltros(False)
            End If
        End Using
    End Sub

    Private Sub EditarLibro(id As Integer)
        Dim fila = dtLibros.Select("id = " & id)(0)
        Using f As New FrmLibroDetalle()
            ' TODO: cargar autores, categorías, público y ejemplares reales desde la BD
            f.CargarParaEditar(id, CStr(fila("titulo")), CStr(fila("editorial")), New Date(CInt(fila("anio")), 1, 1),
                               New String() {"Autor 1"}, New String() {"Categoría 1"}, "Adultos",
                               CInt(fila("stock")), CInt(fila("stock")), CStr(fila("estado")) = "Activo")
            If f.ShowDialog(Me) = DialogResult.OK Then
                ' TODO: UPDATE en la BD
                fila("titulo") = f.Titulo
                fila("editorial") = f.Editorial
                fila("anio") = f.Anio.Year
                fila("estado") = If(f.Activo, "Activo", "Inactivo")
                AplicarFiltros(False)
            End If
        End Using
    End Sub

    Private Sub EliminarLibro(id As Integer)
        Dim fila = dtLibros.Select("id = " & id)(0)

        ' TODO: consultar préstamos activos reales (DEMO: los ids múltiplos de 7 tienen 2)
        Dim prestamosActivos As Integer = If(id Mod 7 = 0, 2, 0)
        If prestamosActivos > 0 Then
            FrmConfirmacion.Mostrar(Me, TipoConfirmacion.Bloqueo, "No se puede eliminar",
                "Este libro tiene **" & prestamosActivos & " préstamos activos**. Registra las devoluciones antes de eliminarlo.",
                "Entendido")
            Return
        End If

        Dim titulo = CStr(fila("titulo"))
        Dim r = FrmConfirmacion.Mostrar(Me, TipoConfirmacion.Peligro, "¿Eliminar este libro?",
                "Se eliminará **" & ChrW(8220) & titulo & ChrW(8221) & "** y no podrás recuperarlo. Esta acción no se puede deshacer.",
                "Sí, eliminar")
        If r = DialogResult.OK Then
            ' TODO: DELETE en la BD
            fila.Delete()
            dtLibros.AcceptChanges()
            AplicarFiltros(False)
        End If
    End Sub

    ' =====================================================================
    '  MENÚ LATERAL
    ' =====================================================================
    Private Sub btnMantenimientos_Click(sender As Object, e As EventArgs) Handles btnMantenimientos.Click
        pnlSubMant.Visible = Not pnlSubMant.Visible
        btnMantenimientos.Text = "🛠 Mantenimientos " & If(pnlSubMant.Visible, "▾", "▸")
    End Sub

    Private Sub SubMenu_Click(sender As Object, e As EventArgs) Handles btnSubLibros.Click, btnSubEjemplares.Click, btnSubAutores.Click, btnSubCategorias.Click, btnSubPenalizaciones.Click
        Dim activo = DirectCast(sender, Button)
        For Each c As Control In pnlSubMant.Controls
            Dim b = TryCast(c, Button)
            If b Is Nothing Then Continue For
            b.Font = If(b Is activo, fuenteSubActivo, fuenteSubNormal)
            b.ForeColor = If(b Is activo, colorPrimario, Color.FromArgb(90, 90, 100))
        Next
        ' TODO: abrir el formulario de mantenimiento correspondiente (según activo.Name)
    End Sub

    Private Sub Menu_Click(sender As Object, e As EventArgs) Handles btnInicio.Click, btnBuscarUsuario.Click, btnUsuarios.Click, btnPrestamos.Click, btnReportes.Click, btnRoles.Click, btnGestionarBibliotecarios.Click, btnConfiguracion.Click
        ' TODO: abrir el formulario correspondiente (según DirectCast(sender, Button).Name)
    End Sub

    Private Sub lblFooter_Click(sender As Object, e As EventArgs) Handles lblFooter.Click

    End Sub
End Class
