Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmPrestamoDevolucion

    Private ReadOnly prestamo As Prestamo
    Private ReadOnly idBibliotecario As Integer
    Private ReadOnly negocio As New prestamoNegocio()
    Private calculo As DevolucionCalculada

    Public Sub New()
        InitializeComponent()
        guardar.Enabled = False
    End Sub

    Public Sub New(prestamo As Prestamo, idUsuario As Integer, nombreUsuario As String)
        Me.New()
        Me.prestamo = prestamo
        idBibliotecario = idUsuario
        txtBibliotecario.Text = nombreUsuario & " · ID " & idUsuario
        txtPrestamo.Text = "N.º " & prestamo.IdPrestamo & " · " & prestamo.NombreLector
        txtEjemplar.Text = prestamo.TituloLibro & " · Ejemplar " & prestamo.IdEjemplar
        lblFechas.Text = "Inicio: " & prestamo.FechaInicio.ToString("dd/MM/yyyy") & " · Límite: " & prestamo.FechaFin.ToString("dd/MM/yyyy")
        retorno.MaxDate = Date.Today
        retorno.Value = Date.Today
        etiqueta_retraso.Text = "Retraso e importe de mora"
        camposEditor.RowStyles(5).Height = 140
        bloque_retraso.Height = 134
        retraso.AutoSize = False
        retraso.Dock = DockStyle.Fill
        Size = New Size(720, 760)
        guardar.Width = 240
        MostrarRetraso()
    End Sub

    Private Sub MostrarRetraso(Optional mostrarMensaje As Boolean = True)
        If prestamo Is Nothing OrElse ContextoDiseno.Activo(Me) Then Return
        Try
            calculo = negocio.PrevisualizarDevolucion(prestamo.IdPrestamo, retorno.Value)
            retraso.Text = calculo.Resumen
            guardar.Text = If(calculo.DiasRetraso > 0 AndAlso Not calculo.YaRegistrada, "Devolver y registrar mora", "Confirmar devolución")
            guardar.Enabled = idBibliotecario > 0 AndAlso prestamoNegocio.PuedeDevolver(prestamo)
        Catch ex As Exception
            calculo = Nothing
            guardar.Enabled = False
            retraso.Text = ex.Message
            If mostrarMensaje Then MessageBox.Show(ex.Message, "Cálculo de devolución", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Devolver(sender As Object, e As EventArgs) Handles guardar.Click
        If Not guardar.Enabled Then Return
        If calculo Is Nothing Then Return
        If MessageBox.Show(calculo.Resumen & vbCrLf & "¿Confirmar la devolución?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        guardar.Enabled = False
        Try
            prestamoNegocio.CalcularDiasRetraso(prestamo.FechaInicio, prestamo.FechaFin, retorno.Value, Date.Today)
            Dim resultado = negocio.DevolverConfirmado(calculo)
            MessageBox.Show("Devolución registrada." & vbCrLf & resultado.Resumen & vbCrLf & "Puedes imprimir el comprobante desde Préstamos.", "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "No se pudo registrar la devolución", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If DialogResult <> DialogResult.OK Then MostrarRetraso(False)
        End Try
    End Sub

    Private Sub retorno_ValueChanged(sender As Object, e As EventArgs) Handles retorno.ValueChanged
        If Not IsHandleCreated Then Return
        MostrarRetraso()
    End Sub
End Class
