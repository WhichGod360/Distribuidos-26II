Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmAutor
    Implements IMantenimientoVista

    Private ReadOnly negocio As New autorNegocio()
    Private textoBuscado As String = ""

    Private Sub frmAutor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarAutores()
    End Sub

    Public Sub ListarAutores() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        Try
            Dim lista = negocio.listarTodos()
            If textoBuscado <> "" Then
                lista = lista.Where(Function(autor) If(autor.NombreAutor, "").Contains(textoBuscado, StringComparison.OrdinalIgnoreCase) OrElse
                                                    If(autor.NacionalidadAutor, "").Contains(textoBuscado, StringComparison.OrdinalIgnoreCase)).ToList()
            End If
            tablaAutores.DataSource = lista
            tablaAutores.ClearSelection()
            lblResumen.Text = lista.Count & " autor(es)"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autores", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        textoBuscado = txtBuscarAutor.Text.Trim()
        ListarAutores()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AbrirEditor(Nothing)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim autor = AutorSeleccionado()
        If autor IsNot Nothing Then AbrirEditor(autor)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim autor = AutorSeleccionado()
        If autor Is Nothing Then Return
        If MessageBox.Show("¿Deseas eliminar el autor '" & autor.NombreAutor & "'?", "Autores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            If Not negocio.eliminar(autor.IdAutor) Then Throw New InvalidOperationException("No se pudo eliminar el autor.")
            ListarAutores()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub AbrirEditor(autor As Autor)
        Using editor As New frmAutorDetalle(autor)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ListarAutores()
        End Using
    End Sub

    Private Function AutorSeleccionado() As Autor
        If tablaAutores.SelectedRows.Count = 0 Then Return Nothing
        Return TryCast(tablaAutores.SelectedRows(0).DataBoundItem, Autor)
    End Function

    Private Sub tablaAutores_SelectionChanged(sender As Object, e As EventArgs) Handles tablaAutores.SelectionChanged
        Dim haySeleccion = AutorSeleccionado() IsNot Nothing
        btnEditar.Enabled = haySeleccion
        btnEliminar.Enabled = haySeleccion
    End Sub
End Class
