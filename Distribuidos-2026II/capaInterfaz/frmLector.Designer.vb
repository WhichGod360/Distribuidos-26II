<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLector
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
        Me.Text = "Mi biblioteca"
        Me.Size = New Size(1180, 760)
        Me.MinimumSize = New Size(900, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = New Font("Segoe UI", 10)
        Me.BackColor = Color.White
        Dim layout As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 1, .RowCount = 3, .Padding = New Padding(20)}
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 70))
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        Dim cabecera As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 2, .RowCount = 1}
        cabecera.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
        cabecera.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 160))
        lblBienvenida = New Label With {.Dock = DockStyle.Fill, .Font = New Font("Segoe UI", 17, FontStyle.Bold), .Text = "Mi biblioteca", .TextAlign = ContentAlignment.MiddleLeft}
        btnSalir = New Button With {.Text = "Cerrar sesión", .Dock = DockStyle.Fill, .Margin = New Padding(0, 15, 0, 15)}
        cabecera.Controls.Add(lblBienvenida, 0, 0)
        cabecera.Controls.Add(btnSalir, 1, 0)
        layout.Controls.Add(cabecera, 0, 0)
        pestanas = New TabControl With {.Dock = DockStyle.Fill}
        tabCatalogo = New TabPage("Catálogo") With {.BackColor = Color.White, .Padding = New Padding(12)}
        tabCarrito = New TabPage("Carrito") With {.BackColor = Color.White, .Padding = New Padding(12)}
        tabReservas = New TabPage("Mis reservas") With {.BackColor = Color.White, .Padding = New Padding(12)}
        tabPrestamos = New TabPage("Mis préstamos") With {.BackColor = Color.White, .Padding = New Padding(12)}
        tabPenalizaciones = New TabPage("Mis penalizaciones") With {.BackColor = Color.White, .Padding = New Padding(12)}
        pestanas.TabPages.AddRange({tabCatalogo, tabCarrito, tabReservas, tabPrestamos, tabPenalizaciones})
        tabAvisos=New TabPage("Avisos") With {.BackColor=Color.White,.Padding=New Padding(12)}
        tablaAvisos=NuevaTabla()
        tablaAvisos.AutoGenerateColumns=True
        btnActualizarAvisos=New Button With {.Text="Actualizar avisos",.Dock=DockStyle.Bottom,.Height=38}
        tabAvisos.Controls.Add(tablaAvisos)
        tabAvisos.Controls.Add(btnActualizarAvisos)
        pestanas.TabPages.Add(tabAvisos)
        Dim barra As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 44, .WrapContents = False}
        txtBuscar = New TextBox With {.Width = 290, .PlaceholderText = "Buscar título, autor o editorial"}
        cboCategoria = New ComboBox With {.Width = 210, .DropDownStyle = ComboBoxStyle.DropDownList}
        btnActualizar = New Button With {.Text = "Actualizar", .Width = 120, .Height = 32}
        barra.Controls.AddRange({txtBuscar, cboCategoria, btnActualizar})
        panelCatalogo = New FlowLayoutPanel With {.Dock = DockStyle.Fill, .AutoScroll = True, .WrapContents = True, .Padding = New Padding(0, 8, 0, 0)}
        tabCatalogo.Controls.Add(panelCatalogo)
        tabCatalogo.Controls.Add(barra)
        tablaCarrito = NuevaTabla()
        tablaCarrito.Columns.Add("IdLibro", "ID")
        tablaCarrito.Columns("IdLibro").Visible = False
        tablaCarrito.Columns.Add("Titulo", "Libro")
        tablaCarrito.Columns.Add("Autor", "Autor")
        Dim acciones As New FlowLayoutPanel With {.Dock = DockStyle.Bottom, .Height = 90, .WrapContents = True}
        btnQuitar = New Button With {.Text = "Quitar seleccionado", .Width = 170, .Height = 36}
        btnVaciar = New Button With {.Text = "Vaciar carrito", .Width = 140, .Height = 36}
        btnSolicitar = New Button With {.Text = "Solicitar reserva", .Width = 170, .Height = 36}
        Dim nota As New Label With {.Text = "Una copia por título. Máximo cinco libros pendientes de devolución en total. El recojo vence cinco días después de solicitar; necesitas aprobación previa.", .AutoSize = True, .MaximumSize = New Size(820, 0)}
        acciones.Controls.AddRange({btnQuitar, btnVaciar, btnSolicitar, nota})
        tabCarrito.Controls.Add(tablaCarrito)
        tabCarrito.Controls.Add(acciones)
        tablaReservas = NuevaTabla()
        tablaReservas.AutoGenerateColumns = True
        Dim reservaAcciones As New FlowLayoutPanel With {.Dock = DockStyle.Bottom, .Height = 46}
        btnCancelar = New Button With {.Text = "Cancelar reserva", .Width = 170, .Height = 36, .Enabled = False}
        reservaAcciones.Controls.Add(btnCancelar)
        tabReservas.Controls.Add(tablaReservas)
        tabReservas.Controls.Add(reservaAcciones)
        tablaPrestamos = NuevaTabla()
        tablaPrestamos.AutoGenerateColumns = True
        tabPrestamos.Controls.Add(tablaPrestamos)
        tablaPenalizaciones = NuevaTabla()
        tablaPenalizaciones.AutoGenerateColumns = True
        Dim resumenPenalizaciones As New TableLayoutPanel With {.Dock = DockStyle.Top, .ColumnCount = 4, .RowCount = 1, .Height = 70}
        For i As Integer = 0 To 3
            resumenPenalizaciones.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25))
        Next
        lblTotalPenalizaciones = New Label With {.Dock = DockStyle.Fill, .Text = "Total registrado", .Font = New Font("Segoe UI", 11, FontStyle.Bold)}
        lblPendientePenalizaciones = New Label With {.Dock = DockStyle.Fill, .Text = "Pendiente", .Font = New Font("Segoe UI", 11, FontStyle.Bold)}
        lblPorRevisarPenalizaciones = New Label With {.Dock = DockStyle.Fill, .Text = "Por revisar", .Font = New Font("Segoe UI", 11, FontStyle.Bold)}
        lblPagadoPenalizaciones = New Label With {.Dock = DockStyle.Fill, .Text = "Pagado", .Font = New Font("Segoe UI", 11, FontStyle.Bold)}
        resumenPenalizaciones.Controls.Add(lblTotalPenalizaciones, 0, 0)
        resumenPenalizaciones.Controls.Add(lblPendientePenalizaciones, 1, 0)
        resumenPenalizaciones.Controls.Add(lblPorRevisarPenalizaciones, 2, 0)
        resumenPenalizaciones.Controls.Add(lblPagadoPenalizaciones, 3, 0)
        Dim filtrosPenalizaciones As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 44, .WrapContents = False}
        filtrosPenalizaciones.Controls.Add(New Label With {.Text = "Estado de pago", .AutoSize = True, .Margin = New Padding(0, 7, 8, 0)})
        cboPagoPenalizaciones = New ComboBox With {.Width = 150, .DropDownStyle = ComboBoxStyle.DropDownList}
        cboPagoPenalizaciones.Items.AddRange({"Todos", "Pendiente", "Por revisar", "Pagada"})
        cboPagoPenalizaciones.SelectedIndex = 0
        btnActualizarPenalizaciones = New Button With {.Text = "Actualizar", .Width = 120, .Height = 32}
        filtrosPenalizaciones.Controls.AddRange({cboPagoPenalizaciones, btnActualizarPenalizaciones})
        lblAvisoPenalizaciones = New Label With {.Dock = DockStyle.Bottom, .Height = 62, .ForeColor = Color.FromArgb(100, 105, 125)}
        tabPenalizaciones.Controls.Add(tablaPenalizaciones)
        tabPenalizaciones.Controls.Add(filtrosPenalizaciones)
        tabPenalizaciones.Controls.Add(resumenPenalizaciones)
        tabPenalizaciones.Controls.Add(lblAvisoPenalizaciones)
        layout.Controls.Add(pestanas, 0, 1)
        lblEstado = New Label With {.Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleLeft, .ForeColor = Color.FromArgb(100, 105, 125), .AutoEllipsis = True}
        layout.Controls.Add(lblEstado, 0, 2)
        Me.Controls.Add(layout)
    End Sub

    Private Shared Function NuevaTabla() As DataGridView
        Return New DataGridView With {.Dock = DockStyle.Fill, .ReadOnly = True, .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False, .MultiSelect = False, .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .RowHeadersVisible = False, .BackgroundColor = Color.White, .BorderStyle = BorderStyle.None,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells}
    End Function

    Friend WithEvents lblBienvenida As Label
    Friend WithEvents btnSalir, btnActualizar, btnQuitar, btnVaciar, btnSolicitar, btnCancelar As Button
    Friend WithEvents pestanas As TabControl
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents cboCategoria As ComboBox
    Friend WithEvents panelCatalogo As FlowLayoutPanel
    Friend WithEvents tablaCarrito, tablaReservas, tablaPrestamos, tablaPenalizaciones As DataGridView
    Friend WithEvents cboPagoPenalizaciones As ComboBox
    Friend WithEvents btnActualizarPenalizaciones As Button
    Friend lblTotalPenalizaciones, lblPendientePenalizaciones, lblPorRevisarPenalizaciones, lblPagadoPenalizaciones, lblAvisoPenalizaciones As Label
    Friend WithEvents lblEstado As Label
    Friend tabCatalogo, tabCarrito, tabReservas, tabPrestamos, tabPenalizaciones As TabPage
    Friend tabAvisos As TabPage
    Friend tablaAvisos As DataGridView
    Friend btnActualizarAvisos As Button
End Class
