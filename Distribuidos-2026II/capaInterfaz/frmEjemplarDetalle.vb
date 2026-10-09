Imports capaNegocio
Imports Utiles

Public Class frmEjemplarDetalle
    Private ReadOnly idLibro As Integer

    Public Sub New()
        InitializeComponent()
        AddHandler guardar.Click, AddressOf Guardar_Click
    End Sub

    Public Sub New(idLibro As Integer, titulo As String)
        Me.New()
        Me.idLibro = idLibro
        libro.Text = titulo
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs)
        Try
            If Not New ejemplarNegocio().agregar(idLibro) Then Throw New InvalidOperationException("No se pudo agregar el ejemplar.")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
