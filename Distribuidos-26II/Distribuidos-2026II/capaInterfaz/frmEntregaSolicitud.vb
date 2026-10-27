Imports System.Threading.Tasks
Imports capaDatos
Imports capaNegocio

Public Class frmEntregaSolicitud
    Private ReadOnly solicitud As SolicitudPrestamo
    Private ReadOnly seleccion As New Dictionary(Of Integer, ComboBox)()
    Private ocupado As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(reserva As SolicitudPrestamo)
        Me.New()
        solicitud = reserva
    End Sub

    Private Async Sub Cargar(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) OrElse solicitud Is Nothing Then Return
        ocupado = True
        btnCancelar.Enabled = False
        UseWaitCursor = True
        lblSolicitud.Text = "Solicitud N.º " & solicitud.IdSolicitud & " · " & solicitud.NombreLector & vbCrLf &
            "DNI: " & solicitud.DniLector & " · Recojo hasta " & solicitud.LimiteLocal.ToString("dd/MM/yyyy HH:mm")
        lblPlazo.Text = "Entrega hoy: " & Date.Today.ToString("dd/MM/yyyy") & " · Devolver hasta: " & prestamoNegocio.FechaLimite(Date.Today).ToString("dd/MM/yyyy")
        Try
            Dim copias = Await Task.Run(Function()
                                            seguridadNegocio.ExigirPersonal()
                                            Dim resultado As New Dictionary(Of Integer, List(Of Ejemplar))()
                                            For Each detalle In solicitud.Detalles
                                                resultado.Add(detalle.IdLibro, New ejemplarNegocio().listarDisponiblesPorLibro(detalle.IdLibro, solicitud.IdUsuario))
                                            Next
                                            Return resultado
                                        End Function)
            If IsDisposed Then Return
            panelCopias.Controls.Remove(lblSinReserva)
            lblSinReserva.Dispose()
            panelCopias.RowStyles.Clear()
            panelCopias.RowStyles.Add(New RowStyle(SizeType.Absolute, 32))
            panelCopias.RowCount = solicitud.Detalles.Count + 2
            Dim fila = 1
            For Each detalle In solicitud.Detalles
                panelCopias.RowStyles.Add(New RowStyle(SizeType.Absolute, 74))
                panelCopias.Controls.Add(New Label With {.Text = detalle.TituloLibro, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleLeft}, 0, fila)
                Dim combo As New ComboBox With {.Dock = DockStyle.Top, .DropDownStyle = ComboBoxStyle.DropDownList,
                    .DisplayMember = "IdEjemplar", .ValueMember = "IdEjemplar", .DataSource = copias(detalle.IdLibro), .Margin = New Padding(8, 18, 0, 0)}
                seleccion.Add(detalle.IdLibro, combo)
                panelCopias.Controls.Add(combo, 1, fila)
                fila += 1
            Next
            panelCopias.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            btnEntregar.Enabled = seleccion.Count > 0 AndAlso seleccion.Values.All(Function(c) c.Items.Count > 0)
            If Not btnEntregar.Enabled Then lblPlazo.Text = "Faltan copias disponibles. Revisa los ejemplares antes de entregar esta reserva."
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Entrega", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            ocupado = False
            btnCancelar.Enabled = True
            UseWaitCursor = False
        End Try
    End Sub

    Private Async Sub Entregar(sender As Object, e As EventArgs) Handles btnEntregar.Click
        If ocupado OrElse solicitud Is Nothing Then Return
        If seleccion.Values.Any(Function(c) c.SelectedValue Is Nothing) Then
            MessageBox.Show("Selecciona una copia para cada libro.", "Entrega", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim copias = seleccion.ToDictionary(Function(par) par.Key, Function(par) CInt(par.Value.SelectedValue))
        ocupado = True
        btnEntregar.Enabled = False
        btnCancelar.Enabled = False
        panelCopias.Enabled = False
        UseWaitCursor = True
        Dim entregado = False
        Try
            Dim ids = Await Task.Run(Function() New solicitudPrestamoNegocio().entregar(solicitud.IdSolicitud, copias))
            MessageBox.Show(ids.Count & " libro(s) entregado(s). Préstamos: " & String.Join(", ", ids) & ". El plazo comienza hoy.", "Entrega registrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            entregado = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "No se pudo entregar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            ocupado = False
            btnCancelar.Enabled = True
            panelCopias.Enabled = True
            btnEntregar.Enabled = Not entregado
            UseWaitCursor = False
        End Try
        If entregado Then DialogResult = DialogResult.OK
    End Sub

    Private Sub Formulario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ocupado Then e.Cancel = True
    End Sub
End Class
