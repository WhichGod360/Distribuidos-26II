Imports capaNegocio

Public Class frmEjemplarDetalle
    Private ReadOnly idLibro As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(idLibro As Integer, titulo As String)
        Me.New()
        Me.idLibro = idLibro
        txtLibro.Text = titulo
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Not New ejemplarNegocio().agregar(idLibro) Then Throw New InvalidOperationException("No se pudo agregar el ejemplar.")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
