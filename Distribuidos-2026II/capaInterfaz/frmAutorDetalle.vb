Imports capaDatos
Imports capaNegocio
Imports Utiles

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
            ' Cargar campos existentes en el formulario
            nombre.Text = autor.NombreAutor

            ' Cargar campos nuevos (verificando que existan los controles en el Designer si ya los agregaste)
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

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles guardar.Click
        Try
            ' Lectura de datos desde la interfaz
            Dim strNombre As String = nombre.Text.Trim()
            Dim strNacionalidad As String = txtNacionalidad.Text.Trim()
            Dim strBiografia As String = txtBiografia.Text.Trim()

            ' Obtención de fechas (evaluando si el usuario las activó/seleccionó)
            Dim fNacimiento As Date? = If(dtpFechaNacimiento.Checked, dtpFechaNacimiento.Value.Date, CType(Nothing, Date?))
            Dim fFallecimiento As Date? = If(dtpFechaFallecimiento.Checked, dtpFechaFallecimiento.Value.Date, CType(Nothing, Date?))

            ' Guardar enviando los 5 parámetros requeridos
            Dim ok = If(autor Is Nothing,
                        negocio.agregar(strNombre, strNacionalidad, fNacimiento, fFallecimiento, strBiografia),
                        negocio.actualizar(autor.IdAutor, strNombre, strNacionalidad, fNacimiento, fFallecimiento, strBiografia))

            If Not ok Then Throw New InvalidOperationException("El nombre ya existe o el registro no está disponible.")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autores", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            nombre.Focus()
        End Try
    End Sub

End Class
