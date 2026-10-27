Imports capaNegocio

Public Class frmEditarCategoria

    Private idCategoria As Integer
    Private negocio As New categoriaNegocio()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(id As Integer)
        Me.New()
        idCategoria = id
        Button10.Text = "Guardar"
    End Sub

    Private Sub frmEditarCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) OrElse idCategoria <= 0 Then Return
        Try
            Dim tabla As DataTable = negocio.obtenerCategoria(idCategoria)
            If tabla.Rows.Count = 0 Then Throw New InvalidOperationException("No se encontró la categoría seleccionada.")
            Dim fila As DataRow = tabla.Rows(0)
            txtNombre.Text = fila("nombre_categoria").ToString()
            chkEstado.Checked = Convert.ToBoolean(fila("estado"))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DialogResult = DialogResult.Cancel
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim nombre As String = txtNombre.Text
        Dim estado As Integer
        If chkEstado.Checked Then
            estado = 1
        Else
            estado = 0
        End If
        Try
            If negocio.actualizarCategoria(idCategoria, nombre, estado) Then
                DialogResult = DialogResult.OK
            Else
                MessageBox.Show("No se encontró la categoría o el nombre ya está en uso.", "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
