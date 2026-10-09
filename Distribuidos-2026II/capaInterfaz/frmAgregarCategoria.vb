Imports capaDatos
Imports capaNegocio

Public Class frmAgregarCategoria

    Private negocio As New categoriaNegocio()

    Public Sub New()
        InitializeComponent()
        Button10.Text = "Guardar"
        chkEstado.Checked = True

    End Sub

    Private Sub frmAgregarCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        txtNombre.Focus()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            If String.IsNullOrWhiteSpace(txtNombre.Text) Then
                MessageBox.Show("Ingrese el nombre de la categoría.", "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNombre.Focus()
                Return
            End If
            If negocio.agregarCategoria(txtNombre.Text, If(chkEstado.Checked, 1, 0)) Then
                DialogResult = DialogResult.OK
            Else
                MessageBox.Show("La categoría ya existe.", "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo guardar la categoría: " & ex.Message, "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

End Class
