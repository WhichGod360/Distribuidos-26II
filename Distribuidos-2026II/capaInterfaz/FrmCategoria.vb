Imports capaNegocio
Imports Utiles

Public Class FrmCategoria
    Implements IMantenimientoVista

    Private ReadOnly negocio As New categoriaNegocio()
    Private idCategoriaSeleccionada As Integer

    Public Sub New()
        InitializeComponent()
        Button10.Text = "Agregar categoría"
        Button11.Text = "Editar"
        Button11.Enabled = False

        cboEstado.SelectedIndex = 0

        AddHandler cboEstado.SelectedIndexChanged, Sub() ActualizarDatos()
        AddHandler tbCategoria.SelectionChanged, AddressOf SeleccionChanged
    End Sub

    Private Sub FrmCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        ActualizarDatos()
    End Sub

    Public Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        Try
            Dim tabla As DataTable = If(txtBuscar.Text.Trim() = "", negocio.listarCategoria(), negocio.buscarCategoria(txtBuscar.Text.Trim()))
            Dim vista As New DataView(tabla)
            If cboEstado.SelectedIndex > 0 Then vista.RowFilter = "estado = '" & cboEstado.SelectedItem.ToString() & "'"
            tbCategoria.DataSource = vista
            tbCategoria.Columns("id_categoria").HeaderText = "ID"
            tbCategoria.Columns("nombre_categoria").HeaderText = "Nombre de la categoría"
            tbCategoria.Columns("estado").HeaderText = "Estado"
            DataGridViewHelper.ConfigurarColumnasFill(tbCategoria, New Dictionary(Of String, Single) From {
                {"id_categoria", 15}, {"nombre_categoria", 60}, {"estado", 25}})
            tbCategoria.ClearSelection()
            lblResumen.Text = vista.Count & " categoría(s)"
            SeleccionChanged(Me, EventArgs.Empty)
        Catch ex As Exception
            MessageBox.Show("No se pudieron cargar las categorías: " & ex.Message, "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SeleccionChanged(sender As Object, e As EventArgs)
        idCategoriaSeleccionada = If(tbCategoria.SelectedRows.Count = 0, 0, Convert.ToInt32(tbCategoria.SelectedRows(0).Cells("id_categoria").Value))
        Button11.Enabled = idCategoriaSeleccionada > 0
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Using editor As New frmAgregarCategoria()
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ActualizarDatos()
        End Using
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If idCategoriaSeleccionada <= 0 Then Return
        Using editor As New frmEditarCategoria(idCategoriaSeleccionada)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ActualizarDatos()
        End Using
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ActualizarDatos()
    End Sub
End Class
