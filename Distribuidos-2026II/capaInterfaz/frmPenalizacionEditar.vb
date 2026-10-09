Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmPenalizacionEditar

    Private ReadOnly penalizacion As Penalizacion
    Private ReadOnly negocio As New penalizacionNegocio()

    Public Sub New()
        InitializeComponent()
        AddHandler esMora.CheckedChanged, Sub() diasDesde.Enabled=esMora.Checked
        AddHandler guardar.Click, AddressOf Guardar_Click
    End Sub

    Public Sub New(penalizacion As Penalizacion)
        Me.New()
        Me.penalizacion = penalizacion
        If penalizacion IsNot Nothing Then
            Text = "Editar penalización"
            tipo.Text = penalizacion.TipoPenalizacion
            monto.Value = Math.Clamp(penalizacion.MontoPenalizacion, monto.Minimum, monto.Maximum)
            descripcion.Text = penalizacion.DescripcionPenalizacion
            activo.Checked = penalizacion.EstadoPenalizacion
            esMora.Checked=penalizacion.DiasDesde.HasValue
            diasDesde.Value=If(penalizacion.DiasDesde.HasValue,CDec(penalizacion.DiasDesde.Value),1D)
        End If
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs)
        Try
            Dim dias As Integer?=If(esMora.Checked,CInt(diasDesde.Value),CType(Nothing,Integer?))
            Dim ok = If(penalizacion Is Nothing,
                negocio.agregarPenalizacion(tipo.Text.Trim(), descripcion.Text.Trim(), monto.Value, activo.Checked,dias),
                negocio.actualizarPenalizacion(penalizacion.IdPenalizacion, tipo.Text.Trim(), descripcion.Text.Trim(), monto.Value, activo.Checked,dias))
            If Not ok Then Throw New InvalidOperationException("No se pudo guardar la penalización.")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
