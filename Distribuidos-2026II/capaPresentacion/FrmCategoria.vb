Imports capaNegocio

Public Class FrmCategoria

    Private negocio As New categoriaNegocio()
    Private idCategoriaSeleccionada As Integer

    Private Sub listarCategoria()
        Dim tabla As DataTable = negocio.listarCategoria()
        tbCategoria.DataSource = tabla
        With tbCategoria
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns("id_categoria").FillWeight = 20
            .Columns("nombre_categoria").FillWeight = 50
            .Columns("estado").FillWeight = 30
        End With
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub FrmCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarCategoria()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim frmAgregarCategoria As New frmAgregarCategoria()
        frmAgregarCategoria.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If idCategoriaSeleccionada = 0 Then
            MessageBox.Show("Seleccione una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim frm As New frmEditarCategoria(idCategoriaSeleccionada)
        frm.ShowDialog()
    End Sub

    Private Sub tbCategoria_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tbCategoria.CellClick
        If e.RowIndex >= 0 Then
            idCategoriaSeleccionada = Convert.ToInt32(tbCategoria.Rows(e.RowIndex).Cells("id_categoria").Value)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim texto As String = txtBuscar.Text.Trim()
        If texto = "" Then
            listarCategoria()
        Else
            Dim tabla As DataTable = negocio.buscarCategoria(texto)
            tbCategoria.DataSource = tabla
        End If
    End Sub

End Class