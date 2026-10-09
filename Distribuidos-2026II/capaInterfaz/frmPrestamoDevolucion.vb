Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmPrestamoDevolucion

    Private ReadOnly prestamo As Prestamo
    Private ReadOnly idBibliotecario As Integer
    Private ReadOnly negocio As New prestamoNegocio()

    Public Sub New()
        InitializeComponent()
        guardar.Enabled = False
        AddHandler retorno.ValueChanged, Sub() MostrarRetraso()
        AddHandler guardar.Click, AddressOf Devolver
    End Sub

    Public Sub New(prestamo As Prestamo, idUsuario As Integer, nombreUsuario As String)
        Me.New()
        Me.prestamo = prestamo
        idBibliotecario = idUsuario
        txtBibliotecario.Text = nombreUsuario & " · ID " & idUsuario
        txtPrestamo.Text = "N.º " & prestamo.IdPrestamo & " · " & prestamo.NombreLector
        txtEjemplar.Text = prestamo.TituloLibro & " · Ejemplar " & prestamo.IdEjemplar
        lblFechas.Text = "Inicio: " & prestamo.FechaInicio.ToString("dd/MM/yyyy") & " · Límite: " & prestamo.FechaFin.ToString("dd/MM/yyyy")
        retorno.Value = Date.Today
        retorno.MaxDate = Date.Today
        guardar.Enabled = idUsuario > 0 AndAlso prestamo.EstaActivo
        MostrarRetraso()
    End Sub

    Private Sub MostrarRetraso()
        If prestamo Is Nothing OrElse ContextoDiseno.Activo(Me) Then Return
        Try
            retraso.Text = prestamoNegocio.CalcularDiasRetraso(prestamo.FechaInicio, prestamo.FechaFin, retorno.Value, Date.Today).ToString()
        Catch ex As ArgumentException
            retraso.Text = ex.Message
        End Try
    End Sub

    Private Sub Devolver(sender As Object, e As EventArgs)
        If Not guardar.Enabled Then Return
        guardar.Enabled = False
        Try
            prestamoNegocio.CalcularDiasRetraso(prestamo.FechaInicio, prestamo.FechaFin, retorno.Value, Date.Today)
            Dim dias = negocio.devolver(prestamo.IdPrestamo, idBibliotecario, retorno.Value)
            MessageBox.Show("Devolución registrada. Días de retraso: " & dias & ".", "Préstamos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "No se pudo registrar la devolución", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            guardar.Enabled = True
        End Try
    End Sub
End Class
