<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        menuPrincipal = New MenuStrip()
        mnuMantenimiento = New ToolStripMenuItem()
        mnuSanciones = New ToolStripMenuItem()
        mnuDetalleSanciones = New ToolStripMenuItem()
        menuPrincipal.SuspendLayout()
        SuspendLayout()
        ' 
        ' menuPrincipal
        ' 
        menuPrincipal.Items.AddRange(New ToolStripItem() {mnuMantenimiento})
        menuPrincipal.Location = New Point(0, 0)
        menuPrincipal.Name = "menuPrincipal"
        menuPrincipal.Size = New Size(1100, 24)
        menuPrincipal.TabIndex = 0
        ' 
        ' mnuMantenimiento
        ' 
        mnuMantenimiento.DropDownItems.AddRange(New ToolStripItem() {mnuSanciones, mnuDetalleSanciones})
        mnuMantenimiento.Name = "mnuMantenimiento"
        mnuMantenimiento.Text = "Mantenimiento"
        ' 
        ' mnuSanciones
        ' 
        mnuSanciones.Name = "mnuSanciones"
        mnuSanciones.Text = "Sanciones"
        ' 
        ' mnuDetalleSanciones
        ' 
        mnuDetalleSanciones.Name = "mnuDetalleSanciones"
        mnuDetalleSanciones.Text = "Detalle de sanciones"
        ' 
        ' frmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1100, 660)
        Controls.Add(menuPrincipal)
        IsMdiContainer = True
        MainMenuStrip = menuPrincipal
        Name = "frmPrincipal"
        Text = "Biblioteca"
        menuPrincipal.ResumeLayout(False)
        menuPrincipal.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents menuPrincipal As MenuStrip
    Friend WithEvents mnuMantenimiento As ToolStripMenuItem
    Friend WithEvents mnuSanciones As ToolStripMenuItem
    Friend WithEvents mnuDetalleSanciones As ToolStripMenuItem
End Class