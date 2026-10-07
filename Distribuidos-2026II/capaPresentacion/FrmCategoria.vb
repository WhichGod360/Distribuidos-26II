Imports capaNegocio

Public Class FrmCategoria

    Private negocio As New categoriaNegocio()

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

    End Sub
End Class