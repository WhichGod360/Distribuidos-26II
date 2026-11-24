Imports capaNegocio

Public Class frmAgregarCategoria

    Private ReadOnly negocio As New categoriaNegocio()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmAgregarCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        txtNombre.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If negocio.agregarCategoria(txtNombre.Text, If(chkEstado.Checked, 1, 0)) Then
                DialogResult = DialogResult.OK
            Else
                MessageBox.Show("La categoría ya existe.", "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

End Class
