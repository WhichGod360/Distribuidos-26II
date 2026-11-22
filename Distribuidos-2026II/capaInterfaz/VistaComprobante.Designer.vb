<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VistaComprobante
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso documento IsNot Nothing Then documento.Dispose()
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.vista = New PrintPreviewControl()
        Me.btnImprimir = New Button()
        Me.SuspendLayout()

        ' vista
        Me.vista.Name = "vista"
        Me.vista.Dock = DockStyle.Fill
        Me.vista.AutoZoom = True
        Me.vista.TabIndex = 1

        ' btnImprimir
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Dock = DockStyle.Top
        Me.btnImprimir.Height = 42
        Me.btnImprimir.Text = "Elegir impresora e imprimir"
        Me.btnImprimir.TabIndex = 0

        ' VistaComprobante
        Me.Name = "VistaComprobante"
        Me.Text = "Vista previa del comprobante"
        Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9.0F)
        Me.ClientSize = New Size(934, 701)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ShowInTaskbar = False
        Me.MinimizeBox = False
        Me.MaximizeBox = True
        Me.Controls.Add(Me.vista)
        Me.Controls.Add(Me.btnImprimir)
        Me.ResumeLayout(False)
    End Sub

    Private components As System.ComponentModel.IContainer
    Friend WithEvents vista As PrintPreviewControl
    Friend WithEvents btnImprimir As Button
End Class
