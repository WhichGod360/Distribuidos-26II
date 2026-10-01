Public Class frmPrincipal

    ' Abre un formulario hijo; si ya está abierto, solo lo activa
    Private Sub abrirHijo(Of T As {Form, New})()
        For Each f As Form In MdiChildren
            If TypeOf f Is T Then
                f.Activate()
                Return
            End If
        Next

        Dim nuevo As New T()
        nuevo.MdiParent = Me
        nuevo.FormBorderStyle = FormBorderStyle.None
        nuevo.StartPosition = FormStartPosition.Manual
        nuevo.Location = Point.Empty
        nuevo.Show()
    End Sub

    Private Sub mnuSanciones_Click(sender As Object, e As EventArgs) Handles mnuSanciones.Click
        abrirHijo(Of frmPenalizacion)()
    End Sub

    Private Sub mnuDetalleSanciones_Click(sender As Object, e As EventArgs) Handles mnuDetalleSanciones.Click
        abrirHijo(Of frmDetallePenalizacion)()
    End Sub

End Class