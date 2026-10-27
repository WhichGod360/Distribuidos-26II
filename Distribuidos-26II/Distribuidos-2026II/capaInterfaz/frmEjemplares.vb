Imports System.Data
Imports capaNegocio
Imports Utiles

Public Class frmEjemplares

    Implements IMantenimientoVista

    Public Event VolverALibros()
    Private ReadOnly negocio As New ejemplarNegocio()
    Private ReadOnly idLibro As Integer
    Private ReadOnly tituloLibro As String
    Private datos As DataTable

    Public Sub New()
        InitializeComponent()
        filtroEstado.SelectedIndex = 0
    End Sub

    Public Sub New(id As Integer, titulo As String)
        Me.New()
        If id <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(id))
        idLibro = id
        tituloLibro = titulo
        lblDescripcionVista.Text = "Libro: " & tituloLibro
    End Sub

    Public Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated OrElse idLibro <= 0 Then Return
        Try
            datos = negocio.listarPorLibro(idLibro)
            Filtrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Filtrar()
        If datos Is Nothing Then Return
        Dim texto = buscar.Text.Trim().Replace("'", "''").Replace("[", "[[]").Replace("*", "[*]").Replace("%", "[%]")
        Dim condiciones As New List(Of String)()
        If texto <> "" Then condiciones.Add("(Convert(id_ejemplar, 'System.String') LIKE '%" & texto & "%' OR estado LIKE '%" & texto & "%')")
        If filtroEstado.SelectedIndex > 0 Then condiciones.Add("estado = '" & filtroEstado.SelectedItem.ToString() & "'")
        Dim vista As New DataView(datos) With {.RowFilter = String.Join(" AND ", condiciones)}
        tabla.DataSource = vista
        tabla.Columns("activo").Visible = False
        tabla.Columns("id_ejemplar").HeaderText = "ID del ejemplar"
        tabla.Columns("id_ejemplar").FillWeight = 30
        tabla.Columns("estado").HeaderText = "Estado"
        tabla.Columns("estado").FillWeight = 70
        tabla.ClearSelection()
        lblResumen.Text = vista.Count & " ejemplar(es) · Libro N.º " & idLibro
        SeleccionChanged(Me, EventArgs.Empty)
    End Sub

    Private Function Seleccionado() As DataRow
        If tabla.SelectedRows.Count = 0 Then Return Nothing
        Dim vista = TryCast(tabla.SelectedRows(0).DataBoundItem, DataRowView)
        Return If(vista Is Nothing, Nothing, vista.Row)
    End Function

    Private Sub SeleccionChanged(sender As Object, e As EventArgs)
        Dim fila = Seleccionado()
        btnEstado.Enabled = fila IsNot Nothing
        btnEstado.Text = If(fila IsNot Nothing AndAlso Not Convert.ToBoolean(fila("activo")), "Activar", "Desactivar")
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Using editor As New frmEjemplarDetalle(idLibro, tituloLibro)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ActualizarDatos()
        End Using
    End Sub

    Private Sub Estado_Click(sender As Object, e As EventArgs) Handles btnEstado.Click
        Dim fila = Seleccionado()
        If fila Is Nothing Then Return
        Dim nuevoEstado = Not Convert.ToBoolean(fila("activo"))
        If MessageBox.Show("¿Deseas " & If(nuevoEstado, "activar", "desactivar") & " este ejemplar?", "Ejemplares",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            If Not negocio.cambiarEstado(idLibro, CInt(fila("id_ejemplar")), nuevoEstado) Then
                MessageBox.Show("No se pudo cambiar el estado. No se pueden desactivar ejemplares con préstamos registrados, incluso devueltos, o que ya tengan ese estado.",
                    "Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            ActualizarDatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarDatos()
    End Sub

    Private Sub buscar_TextChanged(sender As Object, e As EventArgs) Handles buscar.TextChanged
        If Not IsHandleCreated Then Return
        Filtrar()
    End Sub

    Private Sub filtroEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles filtroEstado.SelectedIndexChanged
        If Not IsHandleCreated Then Return
        Filtrar()
    End Sub

    Private Sub tabla_SelectionChanged(sender As Object, e As EventArgs) Handles tabla.SelectionChanged
        If Not IsHandleCreated Then Return
        SeleccionChanged(sender, e)
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        RaiseEvent VolverALibros()
    End Sub
End Class
