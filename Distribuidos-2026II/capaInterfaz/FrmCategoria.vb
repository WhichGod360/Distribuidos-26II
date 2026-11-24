Imports capaNegocio
Imports Utiles

Public Class FrmCategoria
    Implements IMantenimientoVista

    Private ReadOnly negocio As New categoriaNegocio()
    Private nombreBuscado As String = ""
    Private estadoBuscado As String = "Todos"

    Public Sub New()
        InitializeComponent()
        cboEstado.SelectedIndex = 0
    End Sub

    Private Sub FrmCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarCategorias()
    End Sub

    Public Sub ListarCategorias() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        Try
            Dim categorias As DataTable
            If nombreBuscado = "" Then
                categorias = negocio.listarCategoria(estadoBuscado)
            Else
                categorias = negocio.buscarCategoria(nombreBuscado, estadoBuscado)
            End If
            tbCategoria.DataSource = categorias
            tbCategoria.ClearSelection()
            lblResumen.Text = categorias.Rows.Count & " categoría(s)"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        nombreBuscado = txtBuscar.Text.Trim()
        estadoBuscado = CStr(cboEstado.SelectedItem)
        ListarCategorias()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Using editor As New frmAgregarCategoria()
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ListarCategorias()
        End Using
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If tbCategoria.SelectedRows.Count = 0 Then Return
        Dim id = CInt(tbCategoria.SelectedRows(0).Cells("id_categoria").Value)
        Using editor As New frmEditarCategoria(id)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ListarCategorias()
        End Using
    End Sub

    Private Sub tbCategoria_SelectionChanged(sender As Object, e As EventArgs) Handles tbCategoria.SelectionChanged
        btnEditar.Enabled = tbCategoria.SelectedRows.Count > 0
    End Sub
End Class
