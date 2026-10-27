Imports System.Drawing.Drawing2D

Public Enum TipoConfirmacion
    Peligro
    Advertencia
    Neutra
    Bloqueo
End Enum

Public Class FrmConfirmacion

    ''' <summary>
    ''' Muestra el mensaje. Devuelve DialogResult.OK (botón principal) o DialogResult.Cancel (botón secundario).
    ''' En el mensaje, el texto entre ** ** se muestra en negrita.
    ''' Ejemplo: FrmConfirmacion.Mostrar(Me, TipoConfirmacion.Peligro, "¿Eliminar?", "Se eliminará **X**.", "Sí, eliminar")
    ''' </summary>
    Public Shared Function Mostrar(propietario As IWin32Window, tipo As TipoConfirmacion,
                                   titulo As String, mensaje As String,
                                   Optional textoAceptar As String = "Confirmar",
                                   Optional textoCancelar As String = "Cancelar") As DialogResult
        Using f As New FrmConfirmacion()
            f.Configurar(tipo, titulo, mensaje, textoAceptar, textoCancelar)
            Return f.ShowDialog(propietario)
        End Using
    End Function

    Private Sub Configurar(tipo As TipoConfirmacion, titulo As String, mensaje As String,
                           textoAceptar As String, textoCancelar As String)
        Dim icono As String
        Dim fondoIcono As Color
        Dim colorBoton As Color

        Select Case tipo
            Case TipoConfirmacion.Peligro
                icono = "🗑"
                fondoIcono = Color.FromArgb(253, 232, 232)
                colorBoton = Color.FromArgb(214, 69, 69)
            Case TipoConfirmacion.Advertencia
                icono = "⚠"
                fondoIcono = Color.FromArgb(254, 243, 199)
                colorBoton = Color.FromArgb(217, 158, 11)
            Case TipoConfirmacion.Neutra
                icono = "📖"
                fondoIcono = Color.FromArgb(230, 236, 255)
                colorBoton = Color.FromArgb(74, 108, 247)
            Case Else ' Bloqueo
                icono = "⛔"
                fondoIcono = Color.FromArgb(253, 232, 232)
                colorBoton = Color.FromArgb(74, 108, 247)
        End Select

        pnlIcono.BackColor = fondoIcono
        lblIcono.Text = icono
        lblTitulo.Text = titulo
        btnAceptar.Text = textoAceptar
        btnAceptar.BackColor = colorBoton
        btnCancelar.Text = textoCancelar

        ' Bloqueo: un solo botón a todo el ancho
        If tipo = TipoConfirmacion.Bloqueo Then
            btnCancelar.Visible = False
            btnAceptar.Left = btnCancelar.Left
            btnAceptar.Width = ClientSize.Width - 2 * btnCancelar.Left
        End If

        ' Icono circular
        Dim gp As New GraphicsPath()
        gp.AddEllipse(0, 0, pnlIcono.Width - 1, pnlIcono.Height - 1)
        pnlIcono.Region = New Region(gp)

        MostrarMensaje(mensaje)
    End Sub

    Private Sub MostrarMensaje(mensaje As String)
        Dim normal As Font = rtbMensaje.Font
        Dim negrita As New Font(rtbMensaje.Font, FontStyle.Bold)
        Dim partes = mensaje.Split(New String() {"**"}, StringSplitOptions.None)

        rtbMensaje.Clear()
        For i As Integer = 0 To partes.Length - 1
            rtbMensaje.SelectionStart = rtbMensaje.TextLength
            rtbMensaje.SelectionLength = 0
            rtbMensaje.SelectionFont = If(i Mod 2 = 1, negrita, normal)
            rtbMensaje.SelectionColor = If(i Mod 2 = 1, Color.Black, Color.FromArgb(90, 90, 100))
            rtbMensaje.SelectedText = partes(i)
        Next
        rtbMensaje.SelectAll()
        rtbMensaje.SelectionAlignment = HorizontalAlignment.Center
        rtbMensaje.Select(0, 0)
    End Sub

    ' El RichTextBox es solo de lectura: que no robe el foco
    Private Sub rtbMensaje_Enter(sender As Object, e As EventArgs) Handles rtbMensaje.Enter
        btnAceptar.Focus()
    End Sub

    Private Sub FrmConfirmacion_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.DrawRectangle(Pens.Silver, 0, 0, Width - 1, Height - 1)
    End Sub

End Class
