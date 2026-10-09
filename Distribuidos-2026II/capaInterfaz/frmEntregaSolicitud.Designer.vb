<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEntregaSolicitud
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.Text = "Entrega de reserva"
        Me.Size = New Size(760, 570)
        Me.MinimumSize = New Size(650, 420)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Font = New Font("Segoe UI", 10)
        Me.BackColor = Color.White
        Dim layout As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 1, .RowCount = 4, .Padding = New Padding(22)}
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 94))
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 48))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 44))
        lblSolicitud = New Label With {.Dock = DockStyle.Fill, .Font = New Font("Segoe UI", 11, FontStyle.Bold)}
        panelCopias = New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 2, .AutoScroll = True, .Padding = New Padding(0, 4, 8, 4)}
        panelCopias.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70))
        panelCopias.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30))
        lblPlazo = New Label With {.Dock = DockStyle.Fill, .ForeColor = Color.DimGray}
        Dim acciones As New FlowLayoutPanel With {.Dock = DockStyle.Fill, .FlowDirection = FlowDirection.RightToLeft}
        btnCancelar = New Button With {.Text = "Volver", .Width = 100, .Height = 36, .DialogResult = DialogResult.Cancel}
        btnEntregar = New Button With {.Text = "Confirmar entrega", .Width = 180, .Height = 36, .Enabled = False}
        acciones.Controls.AddRange({btnCancelar, btnEntregar})
        layout.Controls.Add(lblSolicitud, 0, 0)
        layout.Controls.Add(panelCopias, 0, 1)
        layout.Controls.Add(lblPlazo, 0, 2)
        layout.Controls.Add(acciones, 0, 3)
        Me.Controls.Add(layout)
        Me.CancelButton = btnCancelar
    End Sub

    Friend WithEvents lblSolicitud, lblPlazo As Label
    Friend WithEvents panelCopias As TableLayoutPanel
    Friend WithEvents btnCancelar, btnEntregar As Button
End Class
