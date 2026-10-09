<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSolicitudes
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
        Me.Text = "Solicitudes y reservas"
        Me.Size = New Size(1050, 650)
        Me.Font = New Font("Segoe UI", 10)
        Me.BackColor = Color.White
        Dim layout As New TableLayoutPanel With {.Dock = DockStyle.Fill, .Padding = New Padding(24, 18, 24, 14), .ColumnCount = 1, .RowCount = 6}
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
        For Each alto In {70, 44, 48}
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, alto))
        Next
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 65))
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 35))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 36))
        Dim encabezado As New Label With {.Text = "Solicitudes y reservas" & vbCrLf & "Aprueba primero. Registra los préstamos cuando entregues los ejemplares.", .Dock = DockStyle.Fill, .Font = New Font("Segoe UI", 12, FontStyle.Bold)}
        layout.Controls.Add(encabezado, 0, 0)
        Dim filtros As New FlowLayoutPanel With {.Dock = DockStyle.Fill, .WrapContents = False}
        txtBuscar = New TextBox With {.Width = 330, .PlaceholderText = "Buscar lector, DNI, libro o solicitud"}
        cboEstado = New ComboBox With {.Width = 190, .DropDownStyle = ComboBoxStyle.DropDownList}
        cboEstado.Items.AddRange({"Todos", "Pendiente", "Aprobada", "Atendida", "Rechazada", "Cancelada", "Vencida"})
        filtros.Controls.AddRange({txtBuscar, cboEstado})
        layout.Controls.Add(filtros, 0, 1)
        Dim acciones As New FlowLayoutPanel With {.Dock = DockStyle.Fill, .WrapContents = False}
        btnAprobar = New Button With {.Text = "Aprobar solicitud", .Width = 160, .Height = 36, .Enabled = False}
        btnEntregar = New Button With {.Text = "Entregar libros", .Width = 160, .Height = 36, .Enabled = False}
        btnRechazar = New Button With {.Text = "Rechazar solicitud", .Width = 170, .Height = 36, .Enabled = False}
        btnActualizar = New Button With {.Text = "Actualizar", .Width = 120, .Height = 36}
        btnComprobante=New Button With {.Text="Comprobante entrega",.Width=195,.Height=36,.Enabled=False}
        acciones.Controls.AddRange({btnAprobar, btnEntregar, btnRechazar, btnActualizar,btnComprobante})
        layout.Controls.Add(acciones, 0, 2)
        tabla = NuevaTabla()
        tabla.AutoGenerateColumns = True
        tablaDetalle = NuevaTabla()
        tablaDetalle.AutoGenerateColumns = True
        layout.Controls.Add(tabla, 0, 3)
        layout.Controls.Add(tablaDetalle, 0, 4)
        lblResumen = New Label With {.Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleLeft, .ForeColor = Color.DimGray, .AutoEllipsis = True}
        layout.Controls.Add(lblResumen, 0, 5)
        Me.Controls.Add(layout)
    End Sub

    Private Shared Function NuevaTabla() As DataGridView
        Return New DataGridView With {.Dock = DockStyle.Fill, .ReadOnly = True, .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False, .RowHeadersVisible = False, .MultiSelect = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect, .BackgroundColor = Color.White,
            .BorderStyle = BorderStyle.None, .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells}
    End Function

    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents btnAprobar, btnEntregar, btnRechazar, btnActualizar As Button
    Friend btnComprobante As Button
    Friend WithEvents tabla, tablaDetalle As DataGridView
    Friend WithEvents lblResumen As Label
End Class
