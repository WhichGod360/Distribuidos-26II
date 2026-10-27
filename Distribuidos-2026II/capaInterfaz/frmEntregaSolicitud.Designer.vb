<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEntregaSolicitud
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        layoutEntrega = New TableLayoutPanel()
        encabezado = New Panel()
        lblTituloVista = New Label()
        lblSolicitud = New Label()
        panelCopias = New TableLayoutPanel()
        lblLibro = New Label()
        lblEjemplar = New Label()
        lblSinReserva = New Label()
        lblPlazo = New Label()
        acciones = New FlowLayoutPanel()
        btnCancelar = New Button()
        btnEntregar = New Button()
        layoutEntrega.SuspendLayout()
        encabezado.SuspendLayout()
        panelCopias.SuspendLayout()
        acciones.SuspendLayout()

        SuspendLayout()
        '
        ' layoutEntrega
        '
        layoutEntrega.Name = "layoutEntrega"
        layoutEntrega.Dock = DockStyle.Fill
        layoutEntrega.Padding = New Padding(22)
        layoutEntrega.ColumnCount = 1
        layoutEntrega.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        layoutEntrega.RowCount = 4
        layoutEntrega.RowStyles.Add(New RowStyle(SizeType.Absolute, 110.0F))
        layoutEntrega.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        layoutEntrega.RowStyles.Add(New RowStyle(SizeType.Absolute, 60.0F))
        layoutEntrega.RowStyles.Add(New RowStyle(SizeType.Absolute, 50.0F))
        layoutEntrega.Controls.Add(encabezado, 0, 0)
        layoutEntrega.Controls.Add(panelCopias, 0, 1)
        layoutEntrega.Controls.Add(lblPlazo, 0, 2)
        layoutEntrega.Controls.Add(acciones, 0, 3)
        layoutEntrega.Size = New Size(744, 531)
        layoutEntrega.TabIndex = 0
        '
        ' encabezado
        '
        encabezado.Name = "encabezado"
        encabezado.Dock = DockStyle.Fill
        encabezado.Margin = New Padding(0)
        encabezado.Controls.Add(lblSolicitud)
        encabezado.Controls.Add(lblTituloVista)
        '
        ' lblTituloVista
        '
        lblTituloVista.Name = "lblTituloVista"
        lblTituloVista.Text = "Entrega de reserva"
        lblTituloVista.Dock = DockStyle.Top
        lblTituloVista.Height = 37
        lblTituloVista.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblTituloVista.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' lblSolicitud
        '
        lblSolicitud.Name = "lblSolicitud"
        lblSolicitud.Text = "Selecciona una reserva aprobada para asignar sus ejemplares."
        lblSolicitud.Dock = DockStyle.Fill
        lblSolicitud.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        '
        ' panelCopias
        '
        panelCopias.Name = "panelCopias"
        panelCopias.Dock = DockStyle.Fill
        panelCopias.ColumnCount = 2
        panelCopias.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70.0F))
        panelCopias.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.0F))
        panelCopias.RowCount = 3
        panelCopias.RowStyles.Add(New RowStyle(SizeType.Absolute, 32.0F))
        panelCopias.RowStyles.Add(New RowStyle(SizeType.Absolute, 74.0F))
        panelCopias.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        panelCopias.AutoScroll = True
        panelCopias.Padding = New Padding(0, 4, 8, 4)
        panelCopias.Margin = New Padding(0)
        panelCopias.Controls.Add(lblLibro, 0, 0)
        panelCopias.Controls.Add(lblEjemplar, 1, 0)
        panelCopias.Controls.Add(lblSinReserva, 0, 1)
        panelCopias.SetColumnSpan(lblSinReserva, 2)
        panelCopias.TabIndex = 1
        '
        ' lblLibro
        '
        lblLibro.Name = "lblLibro"
        lblLibro.Text = "Libro reservado"
        lblLibro.Dock = DockStyle.Fill
        lblLibro.Font = New Font("Segoe UI Semibold", 10.0F)
        lblLibro.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' lblEjemplar
        '
        lblEjemplar.Name = "lblEjemplar"
        lblEjemplar.Text = "Ejemplar a entregar"
        lblEjemplar.Dock = DockStyle.Fill
        lblEjemplar.Font = New Font("Segoe UI Semibold", 10.0F)
        lblEjemplar.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' lblSinReserva
        '
        lblSinReserva.Name = "lblSinReserva"
        lblSinReserva.Text = "Los libros y los ejemplares disponibles se mostrarán al abrir una reserva aprobada."
        lblSinReserva.Dock = DockStyle.Fill
        lblSinReserva.ForeColor = Color.DimGray
        lblSinReserva.TextAlign = ContentAlignment.MiddleLeft
        '
        ' lblPlazo
        '
        lblPlazo.Name = "lblPlazo"
        lblPlazo.Text = "El plazo del préstamo comienza al confirmar la entrega."
        lblPlazo.Dock = DockStyle.Fill
        lblPlazo.ForeColor = Color.DimGray
        lblPlazo.TextAlign = ContentAlignment.MiddleLeft
        lblPlazo.Margin = New Padding(0)
        '
        ' acciones
        '
        acciones.Name = "acciones"
        acciones.Dock = DockStyle.Fill
        acciones.FlowDirection = FlowDirection.RightToLeft
        acciones.WrapContents = False
        acciones.Padding = New Padding(0, 7, 0, 0)
        acciones.Margin = New Padding(0)
        acciones.Controls.Add(btnCancelar)
        acciones.Controls.Add(btnEntregar)
        acciones.TabIndex = 2
        '
        ' btnCancelar
        '
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Text = "Volver"
        btnCancelar.Size = New Size(100, 36)
        btnCancelar.Margin = New Padding(10, 0, 0, 0)
        btnCancelar.TabIndex = 1
        btnCancelar.Cursor = Cursors.Hand
        btnCancelar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.UseVisualStyleBackColor = False
        btnCancelar.BackColor = Color.White
        btnCancelar.ForeColor = Color.FromArgb(59, 91, 115)
        btnCancelar.FlatAppearance.BorderSize = 1
        btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 244, 247)
        btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 232, 238)
        btnCancelar.DialogResult = DialogResult.Cancel
        '
        ' btnEntregar
        '
        btnEntregar.Name = "btnEntregar"
        btnEntregar.Text = "Confirmar entrega"
        btnEntregar.Size = New Size(180, 36)
        btnEntregar.Margin = New Padding(10, 0, 0, 0)
        btnEntregar.TabIndex = 0
        btnEntregar.Cursor = Cursors.Hand
        btnEntregar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnEntregar.FlatStyle = FlatStyle.Flat
        btnEntregar.UseVisualStyleBackColor = False
        btnEntregar.BackColor = Color.FromArgb(59, 91, 115)
        btnEntregar.ForeColor = Color.White
        btnEntregar.FlatAppearance.BorderSize = 0
        btnEntregar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        btnEntregar.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 72, 92)
        btnEntregar.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 56, 72)
        '
        ' btnEntregar
        '
        btnEntregar.Enabled = False
        '
        ' Me
        '
        Me.AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 10.0F)
        Me.ClientSize = New Size(744, 531)
        Me.MinimumSize = New Size(650, 420)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Name = "frmEntregaSolicitud"
        Me.Text = "Entrega de reserva"
        Me.CancelButton = btnCancelar
        Me.Controls.Add(layoutEntrega)
        layoutEntrega.ResumeLayout(False)
        layoutEntrega.PerformLayout()
        encabezado.ResumeLayout(False)
        encabezado.PerformLayout()
        panelCopias.ResumeLayout(False)
        panelCopias.PerformLayout()
        acciones.ResumeLayout(False)
        acciones.PerformLayout()

        ResumeLayout(False)
    End Sub

    Friend WithEvents layoutEntrega As TableLayoutPanel
    Friend WithEvents encabezado As Panel
    Friend WithEvents lblTituloVista As Label
    Friend WithEvents lblSolicitud As Label
    Friend WithEvents panelCopias As TableLayoutPanel
    Friend WithEvents lblLibro As Label
    Friend WithEvents lblEjemplar As Label
    Friend WithEvents lblSinReserva As Label
    Friend WithEvents lblPlazo As Label
    Friend WithEvents acciones As FlowLayoutPanel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEntregar As Button
End Class
