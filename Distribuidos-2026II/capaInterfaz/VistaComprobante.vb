Imports System.Drawing.Printing
Imports capaDatos

Friend Class VistaComprobante
    Private ReadOnly comprobante As ComprobanteBiblioteca
    Private WithEvents documento As PrintDocument
    Private posicion As Integer
    Private pagina As Integer
    Private lineas As List(Of String)

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(datos As ComprobanteBiblioteca)
        Me.New()
        comprobante = datos
        documento = New PrintDocument()
        documento.DocumentName = "Biblioteca - " & comprobante.Referencia
        documento.DefaultPageSettings.Margins = New Margins(60, 60, 60, 60)
        Text = "Comprobante de " & comprobante.Tipo.ToLowerInvariant()
        vista.Document = documento
    End Sub

    Private Sub PrepararDocumento(sender As Object, e As PrintEventArgs) Handles documento.BeginPrint
        posicion = 0
        pagina = 0
        lineas = ComprobanteImpresion.Texto(comprobante)
    End Sub

    Private Sub ImprimirPagina(sender As Object, e As PrintPageEventArgs) Handles documento.PrintPage
        pagina += 1
        e.HasMorePages = ComprobanteImpresion.DibujarPagina(e.Graphics, e.MarginBounds, lineas, posicion, pagina)
    End Sub

    Private Sub ElegirImpresora(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If documento Is Nothing Then Return
        Try
            Using dialogo As New PrintDialog With {.Document = documento, .UseEXDialog = True, .AllowSomePages = False}
                If dialogo.ShowDialog(Me) = DialogResult.OK Then documento.Print()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class
