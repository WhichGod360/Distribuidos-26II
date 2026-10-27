Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmAutor
    Implements IMantenimientoVista

    Private ReadOnly negocio As New autorNegocio()

    Public Sub New()
        InitializeComponent()
        tablaAutores.AutoGenerateColumns = False
    End Sub

    Private Sub frmAutor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        ActualizarDatos()
    End Sub

    Public Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        Try
            Dim texto As String = txtBuscarAutor.Text.Trim()

            ' Actualizado para buscar tanto por Nombre como por Nacionalidad
            Dim lista = negocio.listarTodos().Where(Function(a)
                                                        Dim coincideNombre = String.IsNullOrEmpty(texto) OrElse (a.NombreAutor IsNot Nothing AndAlso a.NombreAutor.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                                                        Dim coincideNacionalidad = String.IsNullOrEmpty(texto) OrElse (a.NacionalidadAutor IsNot Nothing AndAlso a.NacionalidadAutor.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                                                        Return coincideNombre OrElse coincideNacionalidad
                                                    End Function).ToList()

            tablaAutores.DataSource = lista
            tablaAutores.ClearSelection()
            lblResumen.Text = lista.Count & " autor(es)"
            SeleccionChanged(Me, EventArgs.Empty)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autores", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
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

    Private Sub txtBuscarAutor_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarAutor.TextChanged
        If Not IsHandleCreated Then Return
        ActualizarDatos()
    End Sub

    Private Sub tablaAutores_SelectionChanged(sender As Object, e As EventArgs) Handles tablaAutores.SelectionChanged
        If Not IsHandleCreated Then Return
        SeleccionChanged(sender, e)
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AbrirEditor(Nothing)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        AbrirEditor(AutorSeleccionado())
    End Sub
End Class
