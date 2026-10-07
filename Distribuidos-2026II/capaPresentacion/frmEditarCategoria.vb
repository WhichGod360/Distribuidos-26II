Imports capaNegocio

Public Class frmEditarCategoria

    Private idCategoria As Integer
    Private negocio As New categoriaNegocio()

    Public Sub New(id As Integer)
        InitializeComponent()
        idCategoria = id
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub frmEditarCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tabla As DataTable = negocio.obtenerCategoria(idCategoria)
        If tabla.Rows.Count > 0 Then
            Dim fila As DataRow = tabla.Rows(0)
            txtNombre.Text = fila("nombre_categoria").ToString()
            chkEstado.Checked = Convert.ToBoolean(fila("estado"))
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("Ingrese el nombre de la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim nombre As String = txtNombre.Text
        Dim estado As Integer
        If chkEstado.Checked Then
            estado = 1
        Else
            estado = 0
        End If
        negocio.actualizarCategoria(idCategoria, nombre, estado)
        MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

End Class