Imports System.Drawing.Printing
Imports capaDatos

' Presentación e impresión nativas de WinForms. Los importes vienen de negocio.
Public Class ComprobanteImpresion
    Public Shared Function Texto(comprobante As ComprobanteBiblioteca) As List(Of String)
        Dim lector = comprobante.Prestamos.First()
        Dim lineas As New List(Of String) From {
            "BIBLIOTECA UNIVERSITARIA", "Comprobante de " & comprobante.Tipo.ToLowerInvariant(),
            comprobante.Referencia, "Emitido: " & comprobante.FechaEmision.ToString("dd/MM/yyyy HH:mm"),
            "Emitido por: " & comprobante.EmitidoPor, "",
            "Lector: " & lector.NombreLector, "DNI: " & lector.DniLector, ""}
        For Each prestamo In comprobante.Prestamos
            lineas.Add($"Préstamo {prestamo.IdPrestamo} · Ejemplar {prestamo.IdEjemplar}")
            lineas.Add(prestamo.TituloLibro)
            lineas.Add($"Entrega: {prestamo.FechaInicio:dd/MM/yyyy} · Vencimiento: {prestamo.FechaFin:dd/MM/yyyy}")
            lineas.Add("Entrega registrada por: " & prestamo.NombreBibliotecario)
            If comprobante.Tipo = "Devolución" Then
                lineas.Add($"Devolución: {prestamo.FechaRetorno:dd/MM/yyyy} · Retraso: {prestamo.DiasRetraso} día(s)")
                Dim cargos = comprobante.Penalizaciones.Where(Function(d) d.IdPrestamo = prestamo.IdPrestamo).ToList()
                If cargos.Count = 0 Then lineas.Add("Sin penalizaciones registradas.")
                For Each cargo In cargos
                    lineas.Add($"{cargo.TipoPenalizacion}: S/ {cargo.MontoPenalizacion:0.00} · {cargo.EstadoPagoTexto}")
                    lineas.Add("Motivo: " & cargo.Motivo)
                Next
            End If
            lineas.Add("")
        Next
        If comprobante.Tipo = "Entrega" Then lineas.Add("Devuelve los libros hasta la fecha indicada. Máximo cinco libros pendientes por lector.")
        If comprobante.Penalizaciones.Count > 0 Then
            lineas.Add("Total de cargos registrados: S/ " & comprobante.TotalCargos.ToString("0.00"))
            lineas.Add("Este comprobante registra la devolución y sus cargos; el estado indica si el pago está confirmado.")
        End If
        lineas.Add("")
        lineas.Add("Firma del lector: ________________________")
        lineas.Add("Firma del personal: ______________________")
        Return lineas
    End Function

    ' El mismo render se usa para imprimir y para comprobar las páginas de prueba.
    Public Shared Function DibujarPagina(g As Graphics, area As RectangleF, lineas As List(Of String), ByRef posicion As Integer, pagina As Integer) As Boolean
        Using fuente As New Font("Segoe UI", 10), formato As New StringFormat(StringFormat.GenericTypographic)
            Dim altura = fuente.GetHeight(g) + 5
            Dim y = area.Top
            formato.Trimming = StringTrimming.Word
            While posicion < lineas.Count AndAlso y + altura < area.Bottom - 30
                Dim texto = lineas(posicion)
                If texto.Length = 0 Then
                    y += altura
                    posicion += 1
                    Continue While
                End If
                Dim caracteres, lineasMedidas As Integer
                g.MeasureString(texto, fuente, New SizeF(area.Width, altura), formato, caracteres, lineasMedidas)
                If caracteres = 0 Then Throw New InvalidOperationException("El área de impresión es demasiado pequeña.")
                Dim parte = texto.Substring(0, caracteres)
                g.DrawString(parte, fuente, Brushes.Black, New RectangleF(area.Left, y, area.Width, altura), formato)
                y += altura
                If caracteres < texto.Length Then
                    lineas(posicion) = texto.Substring(caracteres).TrimStart()
                Else
                    posicion += 1
                End If
            End While
            g.DrawString("Página " & pagina, fuente, Brushes.Gray, area.Left, area.Bottom - 20)
        End Using
        Return posicion < lineas.Count
    End Function

    Public Shared Sub Mostrar(comprobante As ComprobanteBiblioteca, origen As IWin32Window)
        Using ventana As New VistaComprobante(comprobante)
            ventana.ShowDialog(origen)
        End Using
    End Sub

    Private Class VistaComprobante
        Inherits Form

        Private ReadOnly comprobante As ComprobanteBiblioteca
        Private WithEvents documento As New PrintDocument()
        Private WithEvents imprimir As New Button With {
            .Text = "Elegir impresora e imprimir", .Dock = DockStyle.Top, .Height = 42}
        Private posicion As Integer
        Private pagina As Integer
        Private lineas As List(Of String)

        Public Sub New(datos As ComprobanteBiblioteca)
            comprobante = datos
            documento.DocumentName = "Biblioteca - " & comprobante.Referencia
            documento.DefaultPageSettings.Margins = New Margins(60, 60, 60, 60)
            Text = "Comprobante de " & comprobante.Tipo.ToLowerInvariant()
            Size = New Size(950, 740)
            StartPosition = FormStartPosition.CenterParent
            Dim vista As New PrintPreviewControl With {.Dock = DockStyle.Fill, .Document = documento, .AutoZoom = True}
            Controls.Add(vista)
            Controls.Add(imprimir)
        End Sub

        Private Sub documento_BeginPrint(sender As Object, e As PrintEventArgs) Handles documento.BeginPrint
            posicion = 0
            pagina = 0
            lineas = Texto(comprobante)
        End Sub

        Private Sub documento_PrintPage(sender As Object, e As PrintPageEventArgs) Handles documento.PrintPage
            pagina += 1
            e.HasMorePages = DibujarPagina(e.Graphics, e.MarginBounds, lineas, posicion, pagina)
        End Sub

        Private Sub imprimir_Click(sender As Object, e As EventArgs) Handles imprimir.Click
            Try
                Using dialogo As New PrintDialog With {.Document = documento, .UseEXDialog = True, .AllowSomePages = False}
                    If dialogo.ShowDialog(Me) = DialogResult.OK Then documento.Print()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Protected Overrides Sub Dispose(disposing As Boolean)
            Try
                MyBase.Dispose(disposing)
            Finally
                If disposing Then documento.Dispose()
            End Try
        End Sub
    End Class
End Class
