Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmAutor
    Implements IMantenimientoVista

    Private ReadOnly negocio As New autorNegocio()

    Public Sub New()
        InitializeComponent()
        tablaAutores.AutoGenerateColumns = False



        AddHandler txtBuscarAutor.TextChanged, Sub() ActualizarDatos()
        AddHandler tablaAutores.SelectionChanged, AddressOf SeleccionChanged
        AddHandler btnAgregar.Click, Sub() AbrirEditor(Nothing)
        AddHandler btnEditar.Click, Sub() AbrirEditor(AutorSeleccionado())
        AddHandler btnEliminar.Click, AddressOf Eliminar_Click
    End Sub

    Private Sub frmAutor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        ActualizarDatos()
    End Sub

    Public Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        Try
            Dim texto As String = txtBuscarAutor.Text.Trim()
            Dim lista = negocio.listarTodos().Where(Function(a) a.NombreAutor.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
            tablaAutores.DataSource = lista
            tablaAutores.ClearSelection()
            lblResumen.Text = lista.Count & " autor(es)"
            SeleccionChanged(Me, EventArgs.Empty)
        Catch ex As Exception
            MessageBox.Show("No se pudieron cargar los autores: " & ex.Message, "Autores", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function AutorSeleccionado() As Autor
        If tablaAutores.SelectedRows.Count = 0 Then Return Nothing
        Return TryCast(tablaAutores.SelectedRows(0).DataBoundItem, Autor)
    End Function

    Private Sub SeleccionChanged(sender As Object, e As EventArgs)
        Dim seleccionado = AutorSeleccionado() IsNot Nothing
        btnEditar.Enabled = seleccionado
        btnEliminar.Enabled = seleccionado
    End Sub

    Private Sub AbrirEditor(autor As Autor)
        Using editor As New frmAutorDetalle(autor)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ActualizarDatos()
        End Using
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs)
        Dim autor = AutorSeleccionado()
        If autor Is Nothing Then Return
        If MessageBox.Show("¿Deseas eliminar el autor '" & autor.NombreAutor & "'?", "Autores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            If Not negocio.eliminar(autor.IdAutor) Then Throw New InvalidOperationException("No se pudo eliminar el autor.")
            ActualizarDatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class
