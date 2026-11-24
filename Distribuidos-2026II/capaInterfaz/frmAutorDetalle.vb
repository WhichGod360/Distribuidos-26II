Imports capaDatos
Imports capaNegocio

Public Class frmAutorDetalle

    Private ReadOnly autor As Autor
    Private ReadOnly negocio As New autorNegocio()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(autor As Autor)
        Me.New()
        Me.autor = autor
        If autor IsNot Nothing Then
            txtNombre.Text = autor.NombreAutor
            txtNacionalidad.Text = autor.NacionalidadAutor

            If autor.FechaNacimientoAutor.HasValue Then
                dtpFechaNacimiento.Value = autor.FechaNacimientoAutor.Value
                dtpFechaNacimiento.Checked = True
            Else
                dtpFechaNacimiento.Checked = False
            End If

            If autor.FechaFallecimientoAutor.HasValue Then
                dtpFechaFallecimiento.Value = autor.FechaFallecimientoAutor.Value
                dtpFechaFallecimiento.Checked = True
            Else
                dtpFechaFallecimiento.Checked = False
            End If

            txtBiografia.Text = autor.BiografiaAutor

            lblTituloVista.Text = "Editar autor"
            Text = lblTituloVista.Text
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim nombreAutor As String = txtNombre.Text.Trim()
            Dim nacionalidad As String = txtNacionalidad.Text.Trim()
            Dim biografia As String = txtBiografia.Text.Trim()

            Dim fechaNacimiento As Date? = If(dtpFechaNacimiento.Checked, dtpFechaNacimiento.Value.Date, CType(Nothing, Date?))
            Dim fechaFallecimiento As Date? = If(dtpFechaFallecimiento.Checked, dtpFechaFallecimiento.Value.Date, CType(Nothing, Date?))

            Dim ok = If(autor Is Nothing,
                        negocio.agregar(nombreAutor, nacionalidad, fechaNacimiento, fechaFallecimiento, biografia),
                        negocio.actualizar(autor.IdAutor, nombreAutor, nacionalidad, fechaNacimiento, fechaFallecimiento, biografia))

            If Not ok Then Throw New InvalidOperationException("El nombre ya existe o el registro no está disponible.")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNombre.Focus()
        End Try
    End Sub

End Class
