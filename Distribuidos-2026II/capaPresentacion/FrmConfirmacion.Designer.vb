\xEF\xBB\xBFImports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConfirmacion
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlIcono = New Panel()
        Me.lblIcono = New Label()
        Me.lblTitulo = New Label()
        Me.rtbMensaje = New RichTextBox()
        Me.btnCancelar = New Button()
        Me.btnAceptar = New Button()
        Me.pnlIcono.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlIcono
        '
        Me.pnlIcono.BackColor = Color.FromArgb(253, 232, 232)
        Me.pnlIcono.Controls.Add(Me.lblIcono)
        Me.pnlIcono.Location = New Point(178, 24)
        Me.pnlIcono.Name = "pnlIcono"
        Me.pnlIcono.Size = New Size(64, 64)
        Me.pnlIcono.TabIndex = 0
        '
        'lblIcono
        '
        Me.lblIcono.BackColor = Color.Transparent
        Me.lblIcono.Dock = DockStyle.Fill
        Me.lblIcono.Font = New Font("Segoe UI Emoji", 20.0!)
        Me.lblIcono.Location = New Point(0, 0)
        Me.lblIcono.Name = "lblIcono"
        Me.lblIcono.Size = New Size(64, 64)
        Me.lblIcono.TabIndex = 0
        Me.lblIcono.Text = "🗑"
        Me.lblIcono.TextAlign = ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
        Me.lblTitulo.Location = New Point(20, 104)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New Size(380, 32)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Título"
        Me.lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        '
        'rtbMensaje
        '
        Me.rtbMensaje.BackColor = Color.White
        Me.rtbMensaje.BorderStyle = BorderStyle.None
        Me.rtbMensaje.Cursor = Cursors.Default
        Me.rtbMensaje.ForeColor = Color.FromArgb(90, 90, 100)
        Me.rtbMensaje.Location = New Point(40, 142)
        Me.rtbMensaje.Name = "rtbMensaje"
        Me.rtbMensaje.[ReadOnly] = True
        Me.rtbMensaje.ScrollBars = RichTextBoxScrollBars.None
        Me.rtbMensaje.Size = New Size(340, 64)
        Me.rtbMensaje.TabIndex = 2
        Me.rtbMensaje.TabStop = False
        Me.rtbMensaje.Text = ""
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = Color.White
        Me.btnCancelar.Cursor = Cursors.Hand
        Me.btnCancelar.DialogResult = DialogResult.Cancel
        Me.btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(74, 108, 247)
        Me.btnCancelar.FlatStyle = FlatStyle.Flat
        Me.btnCancelar.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
        Me.btnCancelar.ForeColor = Color.FromArgb(74, 108, 247)
        Me.btnCancelar.Location = New Point(30, 218)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New Size(170, 40)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = Color.FromArgb(74, 108, 247)
        Me.btnAceptar.Cursor = Cursors.Hand
        Me.btnAceptar.DialogResult = DialogResult.OK
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.FlatStyle = FlatStyle.Flat
        Me.btnAceptar.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
        Me.btnAceptar.ForeColor = Color.White
        Me.btnAceptar.Location = New Point(220, 218)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New Size(170, 40)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Confirmar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'FrmConfirmacion
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.White
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New Size(420, 284)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.rtbMensaje)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.pnlIcono)
        Me.Font = New Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Name = "FrmConfirmacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "Confirmación"
        Me.pnlIcono.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlIcono As Panel
    Friend WithEvents lblIcono As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents rtbMensaje As RichTextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button

End Class
