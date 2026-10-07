Imports capaDatos
Imports capaNegocio

Public Class frmAgregarCategoria

    Private negocio As New categoriaNegocio()

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If txtNombre.Text = "" Then
            MessageBox.Show("Ingrese el nombre de la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim nombre As String = txtNombre.Text
            Dim estado As Integer
            If chkEstado.Checked = True Then
                estado = 1
            Else
                estado = 0
            End If
            If negocio.agregarCategoria(nombre, estado) Then
                MessageBox.Show("Categoria ingresada correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("La categoria ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

End Class