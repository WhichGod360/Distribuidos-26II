Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Namespace Global.Utiles
    Public NotInheritable Class DataGridViewHelper
        Private Sub New()
        End Sub

        Public Shared Sub ConfigurarColumnasFill(tabla As DataGridView, pesos As IDictionary(Of String, Single))
            If tabla Is Nothing Then Throw New ArgumentNullException(NameOf(tabla))
            If pesos Is Nothing Then Throw New ArgumentNullException(NameOf(pesos))

            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            For Each columna As KeyValuePair(Of String, Single) In pesos
                If tabla.Columns.Contains(columna.Key) Then
                    tabla.Columns(columna.Key).FillWeight = columna.Value
                End If
            Next
        End Sub

        Public Shared Sub AplicarEstiloMantenimiento(formulario As Form)
            If formulario Is Nothing Then Throw New ArgumentNullException(NameOf(formulario))
            formulario.BackColor = Color.FromArgb(245, 246, 252)
            formulario.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)
            formulario.StartPosition = FormStartPosition.CenterParent
            EstilizarControles(formulario.Controls)
        End Sub

        Private Shared Sub EstilizarControles(controles As Control.ControlCollection)
            For Each control As Control In controles
                If TypeOf control Is DataGridView Then
                    Dim tabla = DirectCast(control, DataGridView)
                    AplicarEstiloTabla(tabla)
                ElseIf TypeOf control Is Button Then
                    Dim boton = DirectCast(control, Button)
                    boton.Cursor = Cursors.Hand
                    boton.FlatStyle = FlatStyle.Flat
                    boton.FlatAppearance.BorderColor = Color.FromArgb(205, 210, 225)
                    If boton.Name.IndexOf("Guardar", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                       boton.Name.IndexOf("Agregar", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                       boton.Name.IndexOf("Nuevo", StringComparison.OrdinalIgnoreCase) >= 0 Then
                        boton.BackColor = Color.FromArgb(72, 101, 244)
                        boton.ForeColor = Color.White
                        boton.FlatAppearance.BorderSize = 0
                    ElseIf boton.Name.IndexOf("Eliminar", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                           boton.Name.IndexOf("Desactivar", StringComparison.OrdinalIgnoreCase) >= 0 Then
                        boton.BackColor = Color.FromArgb(255, 239, 239)
                        boton.ForeColor = Color.FromArgb(150, 35, 35)
                    End If
                End If

                If control.HasChildren Then EstilizarControles(control.Controls)
            Next
        End Sub

        Public Shared Sub AplicarEstiloTabla(tabla As DataGridView)
            tabla.BackgroundColor = Color.White
            tabla.BorderStyle = BorderStyle.None
            tabla.EnableHeadersVisualStyles = False
            tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 238, 255)
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(20, 20, 30)
            tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 238, 255)
            tabla.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 20, 30)
            tabla.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            tabla.ColumnHeadersHeight = 40
            tabla.DefaultCellStyle.Font = New Font("Segoe UI", 10.0F)
            tabla.DefaultCellStyle.BackColor = Color.White
            tabla.DefaultCellStyle.ForeColor = Color.FromArgb(20, 20, 30)
            tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 225, 255)
            tabla.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 20, 30)
            tabla.RowsDefaultCellStyle = New DataGridViewCellStyle()
            tabla.AlternatingRowsDefaultCellStyle = New DataGridViewCellStyle With {.BackColor = Color.FromArgb(249, 250, 255)}
            For Each columna As DataGridViewColumn In tabla.Columns
                columna.HeaderCell.Style = New DataGridViewCellStyle()
                columna.DefaultCellStyle.Font = Nothing
                columna.DefaultCellStyle.BackColor = Color.Empty
                columna.DefaultCellStyle.ForeColor = Color.Empty
                columna.DefaultCellStyle.SelectionBackColor = Color.Empty
                columna.DefaultCellStyle.SelectionForeColor = Color.Empty
            Next
            tabla.GridColor = Color.FromArgb(222, 225, 236)
            tabla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            tabla.RowTemplate.Height = 36
            tabla.RowTemplate.DefaultCellStyle = New DataGridViewCellStyle()
            tabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            For Each fila As DataGridViewRow In tabla.Rows
                fila.Height = 36
                fila.DefaultCellStyle = New DataGridViewCellStyle()
            Next
        End Sub
    End Class
End Namespace
