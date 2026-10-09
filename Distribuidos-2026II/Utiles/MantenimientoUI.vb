Imports System.Drawing
Imports System.Windows.Forms

Namespace Global.Utiles
    Public Class CampoMantenimiento
        Public ReadOnly Etiqueta As String
        Public ReadOnly Control As Control
        Public ReadOnly Alto As Integer

        Public Sub New(etiqueta As String, control As Control, Optional alto As Integer = 30)
            Me.Etiqueta = etiqueta
            Me.Control = control
            Me.Alto = alto
        End Sub
    End Class

    ' Solo distribución y estilo; las consultas y decisiones siguen en cada módulo.
    Public NotInheritable Class MantenimientoUI
        Public Shared ReadOnly Primario As Color = Color.FromArgb(72, 101, 244)
        Public Shared ReadOnly Texto As Color = Color.FromArgb(20, 20, 30)
        Public Shared ReadOnly Suave As Color = Color.FromArgb(110, 115, 130)
        Public Shared ReadOnly Borde As Color = Color.FromArgb(222, 225, 236)

        Private Sub New()
        End Sub

        Public Shared Sub ConfigurarListado(formulario As Form, titulo As String, descripcion As String,
                                             tabla As DataGridView, buscar As TextBox, acciones As IEnumerable(Of Button),
                                             resumen As Label, Optional filtros As IEnumerable(Of CampoMantenimiento) = Nothing,
                                             Optional paginacion As Control = Nothing)
            formulario.SuspendLayout()
            OcultarContenidoAnterior(formulario)
            formulario.MinimumSize = Size.Empty
            formulario.BackColor = Color.White
            formulario.Font = New Font("Segoe UI", 10.0F)
            formulario.Text = titulo

            Dim layout As New TableLayoutPanel With {
                .Name = "layoutMantenimiento", .Dock = DockStyle.Fill, .Padding = New Padding(24, 18, 24, 14),
                .ColumnCount = 1, .RowCount = 5, .BackColor = Color.White
            }
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 78))
            layout.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            layout.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
            layout.Controls.Add(Encabezado(titulo, descripcion), 0, 0)

            Dim barra As New FlowLayoutPanel With {.Name = "barraFiltros", .Dock = DockStyle.Fill, .AutoSize = True,
                .WrapContents = True, .Margin = New Padding(0, 0, 0, 10), .Padding = Padding.Empty}
            buscar.PlaceholderText = "Buscar..."
            barra.Controls.Add(BloqueCampo(New CampoMantenimiento("Buscar", buscar), 310))
            If filtros IsNot Nothing Then
                For Each filtro In filtros
                    barra.Controls.Add(BloqueCampo(filtro, 160))
                Next
            End If
            layout.Controls.Add(barra, 0, 1)

            Dim botones As New FlowLayoutPanel With {.Name = "barraAcciones", .Dock = DockStyle.Fill, .AutoSize = True,
                .WrapContents = True, .Margin = New Padding(0, 0, 0, 12)}
            For Each boton As Button In acciones
                boton.Dock = DockStyle.None
                boton.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                boton.AutoSize = False
                boton.Size = New Size(Math.Max(110, TextRenderer.MeasureText(boton.Text, New Font("Segoe UI", 10.0F, FontStyle.Bold)).Width + 28), 36)
                boton.Margin = New Padding(0, 0, 10, 4)
                boton.Visible = True
                EstilizarBoton(boton, boton.Text.StartsWith("Agregar", StringComparison.OrdinalIgnoreCase) OrElse boton.Text.StartsWith("Nuevo", StringComparison.OrdinalIgnoreCase))
                botones.Controls.Add(boton)
            Next
            layout.Controls.Add(botones, 0, 2)

            tabla.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            tabla.Dock = DockStyle.Fill
            tabla.Margin = Padding.Empty
            tabla.Visible = True
            tabla.ReadOnly = True
            tabla.AllowUserToAddRows = False
            tabla.AllowUserToDeleteRows = False
            tabla.MultiSelect = False
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            tabla.RowHeadersVisible = False
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridViewHelper.AplicarEstiloTabla(tabla)
            layout.Controls.Add(tabla, 0, 3)

            Dim pie As New Panel With {.Name = "pieMantenimiento", .Dock = DockStyle.Fill, .Margin = Padding.Empty}
            resumen.Dock = DockStyle.Fill
            resumen.AutoSize = False
            resumen.TextAlign = ContentAlignment.MiddleLeft
            resumen.Font = New Font("Segoe UI", 9.5F)
            resumen.ForeColor = Suave
            resumen.Visible = True
            pie.Controls.Add(resumen)
            If paginacion IsNot Nothing Then
                paginacion.Dock = DockStyle.Right
                paginacion.Visible = True
                pie.Controls.Add(paginacion)
            End If
            layout.Controls.Add(pie, 0, 4)
            formulario.Controls.Add(layout)
            layout.BringToFront()
            formulario.ResumeLayout(True)
        End Sub

        Public Shared Sub ConfigurarDialogo(formulario As Form, titulo As String, descripcion As String,
                                             guardar As Button, cancelar As Button, ParamArray campos As CampoMantenimiento())
            formulario.SuspendLayout()
            OcultarContenidoAnterior(formulario)
            formulario.Font = New Font("Segoe UI", 10.0F)
            formulario.BackColor = Color.White
            formulario.Text = titulo
            formulario.FormBorderStyle = FormBorderStyle.FixedDialog
            formulario.MinimizeBox = False
            formulario.MaximizeBox = False
            formulario.ShowInTaskbar = False
            formulario.StartPosition = FormStartPosition.CenterParent
            formulario.MinimumSize = Size.Empty
            Dim altoCampos As Integer = campos.Sum(Function(c) c.Alto + 26)
            formulario.ClientSize = New Size(560, Math.Min(650, 98 + altoCampos + 70))
            Dim layout As New TableLayoutPanel With {.Name = "layoutEditor", .Dock = DockStyle.Fill,
                .Padding = New Padding(24, 18, 24, 16), .ColumnCount = 1, .RowCount = 3, .BackColor = Color.White}
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 80))
            layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 54))
            layout.Controls.Add(Encabezado(titulo, descripcion), 0, 0)

            Dim cuerpo As New Panel With {.Dock = DockStyle.Fill, .AutoScroll = True, .Margin = Padding.Empty}
            Dim lista As New TableLayoutPanel With {.Dock = DockStyle.Top, .AutoSize = True, .ColumnCount = 1, .RowCount = campos.Length,
                .Padding = New Padding(0, 0, 6, 0)}
            lista.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            For i As Integer = 0 To campos.Length - 1
                lista.RowStyles.Add(New RowStyle(SizeType.Absolute, campos(i).Alto + 26))
                lista.Controls.Add(BloqueCampo(campos(i), 0, 20), 0, i)
            Next
            cuerpo.Controls.Add(lista)
            layout.Controls.Add(cuerpo, 0, 1)
            Dim botones As New FlowLayoutPanel With {.Dock = DockStyle.Fill, .FlowDirection = FlowDirection.RightToLeft,
                .WrapContents = False, .Padding = New Padding(0, 12, 0, 0), .Margin = Padding.Empty}
            For Each boton As Button In {guardar, cancelar}
                boton.Visible = True
                boton.Dock = DockStyle.None
                boton.Anchor = AnchorStyles.None
                boton.Size = New Size(138, 36)
                boton.Margin = New Padding(10, 0, 0, 0)
                EstilizarBoton(boton, boton Is guardar)
                botones.Controls.Add(boton)
            Next
            If String.IsNullOrWhiteSpace(guardar.Text) Then guardar.Text = "Guardar"
            cancelar.Text = "Cancelar"
            cancelar.DialogResult = DialogResult.Cancel
            formulario.AcceptButton = guardar
            formulario.CancelButton = cancelar
            layout.Controls.Add(botones, 0, 2)
            formulario.Controls.Add(layout)
            layout.BringToFront()
            formulario.ResumeLayout(True)
        End Sub

        Public Shared Function MostrarDialogo(formulario As Form, origen As Control) As DialogResult
            Dim propietario As Form = TryCast(origen.TopLevelControl, Form)
            If propietario Is Nothing Then propietario = origen.FindForm()
            Return formulario.ShowDialog(propietario)
        End Function

        Public Shared Sub EstilizarBoton(boton As Button, Optional principal As Boolean = False)
            boton.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
            boton.Cursor = Cursors.Hand
            boton.FlatStyle = FlatStyle.Flat
            boton.UseVisualStyleBackColor = False
            boton.FlatAppearance.BorderSize = If(principal, 0, 1)
            boton.FlatAppearance.BorderColor = If(principal, Primario, Borde)
            boton.BackColor = If(principal, Primario, Color.White)
            boton.ForeColor = If(principal, Color.White, Texto)
        End Sub

        Private Shared Function Encabezado(titulo As String, descripcion As String) As Control
            Dim panel As New Panel With {.Dock = DockStyle.Fill, .Margin = Padding.Empty}
            Dim nombre As New Label With {.Text = titulo, .Dock = DockStyle.Top, .Height = 37,
                .Font = New Font("Segoe UI", 20.0F, FontStyle.Bold), .ForeColor = Texto}
            Dim detalle As New Label With {.Text = descripcion, .Dock = DockStyle.Fill,
                .Font = New Font("Segoe UI", 10.0F), .ForeColor = Suave, .AutoEllipsis = True}
            panel.Controls.Add(detalle)
            panel.Controls.Add(nombre)
            Return panel
        End Function

        Private Shared Function BloqueCampo(campo As CampoMantenimiento, ancho As Integer, Optional altoEtiqueta As Integer = 24) As Control
            Dim panel As New Panel With {.Height = campo.Alto + If(altoEtiqueta = 24, 32, 26), .Margin = New Padding(0, 0, 14, 0)}
            If ancho > 0 Then
                panel.Width = ancho
            Else
                panel.Dock = DockStyle.Fill
                panel.Margin = Padding.Empty
            End If
            Dim etiqueta As New Label With {.Text = campo.Etiqueta, .Dock = DockStyle.Top, .Height = altoEtiqueta,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold), .ForeColor = Texto}
            Dim control As Control = campo.Control
            control.Font = New Font("Segoe UI", 10.0F)
            control.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            control.Dock = DockStyle.Top
            control.Location = Point.Empty
            If TypeOf control Is CheckBox Then DirectCast(control, CheckBox).AutoSize = False
            If TypeOf control Is Label Then DirectCast(control, Label).AutoSize = False
            control.Height = campo.Alto
            control.Margin = Padding.Empty
            control.Visible = True
            panel.Controls.Add(control)
            panel.Controls.Add(etiqueta)
            Return panel
        End Function

        Private Shared Sub OcultarContenidoAnterior(formulario As Form)
            For Each control As Control In formulario.Controls
                control.Visible = False
            Next
        End Sub
    End Class
End Namespace
