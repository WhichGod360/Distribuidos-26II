Imports System.Drawing
Imports System.Windows.Forms

Namespace Global.Utiles
    Public NotInheritable Class MantenimientoUI
        Public Shared ReadOnly Primario As Color = Color.FromArgb(59, 91, 115)
        Public Shared ReadOnly PrimarioHover As Color = Color.FromArgb(47, 72, 92)
        Public Shared ReadOnly PrimarioPresionado As Color = Color.FromArgb(35, 56, 72)
        Public Shared ReadOnly SecundarioHover As Color = Color.FromArgb(240, 244, 247)
        Public Shared ReadOnly SecundarioPresionado As Color = Color.FromArgb(225, 232, 238)
        Public Shared ReadOnly Texto As Color = Color.FromArgb(47, 72, 92)
        Public Shared ReadOnly Suave As Color = Color.FromArgb(120, 120, 120)
        Public Shared ReadOnly Borde As Color = Color.FromArgb(222, 226, 231)

        Private Sub New()
        End Sub

        Public Shared Function MostrarDialogo(formulario As Form, origen As Control) As DialogResult
            Dim propietario As Form = TryCast(origen.TopLevelControl, Form)
            If propietario Is Nothing Then propietario = origen.FindForm()
            Dim area = Screen.FromControl(origen).WorkingArea
            formulario.Size = New Size(Math.Min(formulario.Width, area.Width - 32), Math.Min(formulario.Height, area.Height - 48))
            Return formulario.ShowDialog(propietario)
        End Function

        Public Shared Sub EstilizarBoton(boton As Button, Optional principal As Boolean = False)
            boton.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Regular)
            boton.Cursor = Cursors.Hand
            boton.FlatStyle = FlatStyle.Flat
            boton.UseVisualStyleBackColor = False
            boton.FlatAppearance.BorderSize = If(principal, 0, 1)
            boton.FlatAppearance.BorderColor = If(principal, Borde, Primario)
            boton.FlatAppearance.MouseOverBackColor = If(principal, PrimarioHover, SecundarioHover)
            boton.FlatAppearance.MouseDownBackColor = If(principal, PrimarioPresionado, SecundarioPresionado)
            boton.BackColor = If(principal, Primario, Color.White)
            boton.ForeColor = If(principal, Color.White, Primario)
        End Sub
    End Class
End Namespace
