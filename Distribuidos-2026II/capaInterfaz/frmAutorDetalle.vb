Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmAutorDetalle

    Private ReadOnly autor As Autor
    Private ReadOnly negocio As New autorNegocio()

    Public Sub New()
        InitializeComponent()
        AddHandler guardar.Click, AddressOf Guardar_Click
    End Sub

    Public Sub New(autor As Autor)
        Me.New()
        Me.autor = autor
        If autor IsNot Nothing Then
            nombre.Text = autor.NombreAutor
            lblTituloVista.Text = "Editar autor"
            Text = lblTituloVista.Text
        End If
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs)
        Try
            Dim ok = If(autor Is Nothing, negocio.agregar(nombre.Text), negocio.actualizar(autor.IdAutor, nombre.Text))
            If Not ok Then Throw New InvalidOperationException("El nombre ya existe o el registro no está disponible.")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            nombre.Focus()
        End Try
    End Sub
End Class
