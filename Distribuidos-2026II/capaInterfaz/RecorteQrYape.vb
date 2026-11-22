Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Friend NotInheritable Class RecorteQrYape
    Private Sub New()
    End Sub

    Friend Shared Function ParaMostrar(archivo As Stream) As Bitmap
        Using tarjeta As New Bitmap(archivo)
            ' Recorta el código de la tarjeta de Yape y conserva sus píxeles.
            Dim regionQr As New Rectangle(250, 460, 630, 630)
            Const margen As Integer = 32
            Using codigo = tarjeta.Clone(regionQr, PixelFormat.Format32bppArgb)
                Dim resultado As New Bitmap(codigo.Width + 2 * margen, codigo.Height + 2 * margen)
                Using lienzo = Graphics.FromImage(resultado)
                    lienzo.Clear(Color.White)
                    lienzo.DrawImageUnscaled(codigo, margen, margen)
                End Using
                Return resultado
            End Using
        End Using
    End Function
End Class
