Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmPenalizacionEditar

    Private ReadOnly penalizacion As Penalizacion
    Private ReadOnly negocio As New penalizacionNegocio()

    Public Sub New()
        InitializeComponent()
        AddHandler guardar.Click, AddressOf Guardar_Click
    End Sub

    Public Sub New(penalizacion As Penalizacion)
        Me.New()
        Me.penalizacion = penalizacion
        If penalizacion IsNot Nothing Then
            lblTituloVista.Text = "Editar penalización"
            Text = lblTituloVista.Text
            tipo.Text = penalizacion.TipoPenalizacion
            monto.Value = Math.Clamp(penalizacion.MontoPenalizacion, monto.Minimum, monto.Maximum)
            descripcion.Text = penalizacion.DescripcionPenalizacion
            activo.Checked = penalizacion.EstadoPenalizacion
        End If
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(tipo.Text) Then
            MessageBox.Show("Ingresa el tipo de penalización.", "Penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tipo.Focus()
            Return
        End If
        Try
            Dim ok = If(penalizacion Is Nothing,
                negocio.agregarPenalizacion(tipo.Text.Trim(), descripcion.Text.Trim(), monto.Value, activo.Checked),
                negocio.actualizarPenalizacion(penalizacion.IdPenalizacion, tipo.Text.Trim(), descripcion.Text.Trim(), monto.Value, activo.Checked))
            If Not ok Then Throw New InvalidOperationException("No se pudo guardar la penalización.")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
