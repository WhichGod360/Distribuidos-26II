Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports System.Windows

Public Class frmPrincipal

    Public Property Usuario As String = "Invitado"
    Public Property Rol As String = "Bibliotecario"   ' Usa "Administrador" para habilitar el menú de admin

    ' ---------- Colores ----------
    Private ReadOnly Azul As Color = Color.FromArgb(72, 101, 244)
    Private ReadOnly AzulClaro As Color = Color.FromArgb(193, 200, 255)
    Private ReadOnly GrisClaro As Color = Color.FromArgb(232, 232, 232)
    Private ReadOnly Borde As Color = Color.FromArgb(222, 225, 236)
    Private ReadOnly FondoSide As Color = Color.FromArgb(245, 246, 252)
    Private ReadOnly Texto As Color = Color.FromArgb(20, 20, 30)
    Private ReadOnly Suave As Color = Color.FromArgb(110, 115, 130)
    Private ReadOnly Bloqueado As Color = Color.FromArgb(150, 155, 170)

    ' ---------- Datos (cámbialos desde tu capa de negocio) ----------
    Private prestamosPorMes() As Integer = {38, 52, 32, 62, 74, 56, 42, 66, 80, 54, 70, 88}
    Private estados() As Integer = {50, 30, 20}                  ' Activos, Devueltos, Con retraso
    Private catNombres() As String = {"Novela", "Ciencia", "Historia", "Infantil"}
    Private catValores() As Integer = {100, 75, 55, 40}

    Private menuBtns As New List(Of Button)

    ' =====================================================================
    '  INICIO
    ' =====================================================================
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Evita parpadeo en los paneles dibujados a mano
        For Each c As Control In {pnlBarras, pnlDona, pnlCats, pnlAvatar, cardStat0, cardStat1, cardStat2,
                                  cardStat3, cardBarras, cardDona, cardCats, cardNotif}
            GetType(Control).GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(c, True)
        Next

        lblNombre.Text = Usuario
        lblRol.Text = " " & Rol & " "
        dtDesde.Value = New Date(Date.Now.Year, 1, 1)
        dtHasta.Value = New Date(Date.Now.Year, 12, 31)
        cboCat.SelectedIndex = 0
        cboEst.SelectedIndex = 0

        menuBtns.AddRange({btnInicio, btnBuscar, btnUsuarios, btnPrestamos, btnReportes,
                           btnLibros, btnAutores, btnCategorias, btnPenalizaciones,
                           btnRoles, btnBibliotecarios, btnConfig})

        ' Menú de administrador
        Dim esAdmin As Boolean = (Rol = "Administrador")
        For Each b In {btnRoles, btnBibliotecarios, btnConfig}
            b.Enabled = esAdmin
            If esAdmin Then b.Text = b.Tag.ToString()
        Next

        ' Cerrar sesión desde el avatar
        Dim cms As New ContextMenuStrip()
        cms.Items.Add("Cerrar sesión", Nothing, Sub() Application.Restart())
        AddHandler pnlAvatar.Click, Sub() cms.Show(pnlAvatar, 0, pnlAvatar.Height)

        SeleccionarMenu(btnInicio)
    End Sub

    Private Sub frmPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    ' Llama a esto para llenar las tarjetas con datos reales
    Public Sub SetEstadisticas(activos As Integer, porVencer As Integer, retraso As Integer, penalizados As Integer)
        lblNum0.Text = activos.ToString()
        lblNum1.Text = porVencer.ToString()
        lblNum2.Text = retraso.ToString()
        lblNum3.Text = penalizados.ToString()
    End Sub

    ' =====================================================================
    '  MENÚ
    ' =====================================================================
    Private Sub MenuClick(sender As Object, e As EventArgs) Handles btnInicio.Click, btnBuscar.Click,
            btnUsuarios.Click, btnPrestamos.Click, btnReportes.Click, btnLibros.Click, btnAutores.Click,
            btnCategorias.Click, btnPenalizaciones.Click, btnRoles.Click, btnBibliotecarios.Click, btnConfig.Click
        Dim b = DirectCast(sender, Button)
        SeleccionarMenu(b)
        AbrirModulo(b.Tag.ToString())
        Dim formulario As New frmCategoria()
        formulario.Show()
    End Sub

    Private Sub btnMant_Click(sender As Object, e As EventArgs) Handles btnMant.Click
        flpSub.Visible = Not flpSub.Visible
        btnMant.Text = "🛠  Mantenimientos   " & If(flpSub.Visible, "▾", "▸")
    End Sub

    Private Sub SeleccionarMenu(sel As Button)
        For Each b In menuBtns
            b.BackColor = FondoSide
            If Not b.Enabled Then
                b.ForeColor = Bloqueado
            ElseIf b.Height = 28 Then
                b.ForeColor = Suave
            Else
                b.ForeColor = Texto
            End If
        Next
        sel.BackColor = Azul
        sel.ForeColor = Color.White
    End Sub

    Private Sub AbrirModulo(clave As String)
        ' TODO: aquí abres el formulario o carga el módulo según la clave:
        ' "inicio", "buscar", "usuarios", "prestamos", "reportes",
        ' "Libros y ejemplares", "Autores", "Categorías", "Penalizaciones",
        ' "Roles y permisos", "Gestionar bibliotecarios", "Configuración"
    End Sub

    ' =====================================================================
    '  FILTROS
    ' =====================================================================
    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        ' TODO: consulta a la capa de negocio con dtDesde, dtHasta, cboCat, cboEst
        ' y luego SetEstadisticas(...) y actualiza los arreglos de datos.
        pnlBarras.Invalidate()
        pnlDona.Invalidate()
        pnlCats.Invalidate()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        dtDesde.Value = New Date(Date.Now.Year, 1, 1)
        dtHasta.Value = New Date(Date.Now.Year, 12, 31)
        cboCat.SelectedIndex = 0
        cboEst.SelectedIndex = 0
    End Sub

    ' =====================================================================
    '  DIBUJO (bordes redondeados, avatar, gráficos)
    ' =====================================================================
    Private Sub Redibujar(sender As Object, e As EventArgs) Handles pnlBarras.Resize, pnlDona.Resize, pnlCats.Resize,
            cardStat0.Resize, cardStat1.Resize, cardStat2.Resize, cardStat3.Resize, cardBarras.Resize,
            cardDona.Resize, cardCats.Resize, cardNotif.Resize
        DirectCast(sender, Control).Invalidate()
    End Sub

    Private Sub DibujarCard(sender As Object, e As PaintEventArgs) Handles cardStat0.Paint, cardStat1.Paint,
            cardStat2.Paint, cardStat3.Paint, cardBarras.Paint, cardDona.Paint, cardCats.Paint, cardNotif.Paint
        Dim p = DirectCast(sender, Control)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using pen As New Pen(Borde, 1.5F), path = RoundRect(New RectangleF(0.5F, 0.5F, p.Width - 2, p.Height - 2), 12)
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    Private Sub DibujarLinea(sender As Object, e As PaintEventArgs) Handles pnlHeader.Paint, pnlFiltros.Paint
        Dim p = DirectCast(sender, Control)
        Using pen As New Pen(Borde)
            e.Graphics.DrawLine(pen, 0, p.Height - 2, p.Width, p.Height - 2)
        End Using
    End Sub

    Private Sub DibujarAvatar(sender As Object, e As PaintEventArgs) Handles pnlAvatar.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using br As New SolidBrush(AzulClaro), pen As New Pen(Azul, 2)
            e.Graphics.FillEllipse(br, 2, 2, 36, 36)
            e.Graphics.DrawEllipse(pen, 2, 2, 36, 36)
        End Using
    End Sub

    Private Sub DibujarBarras(sender As Object, e As PaintEventArgs) Handles pnlBarras.Paint
        Dim p = DirectCast(sender, Control)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim mx As Integer = Math.Max(1, prestamosPorMes.Max())
        Dim baseY As Single = p.Height - 22
        Dim slot As Single = p.Width / 12.0F
        Dim bw As Single = slot * 0.55F
        Dim letras As String = "EFMAMJJASOND"
        Dim fmt As New StringFormat With {.Alignment = StringAlignment.Center}

        For i = 0 To 11
            Dim h As Single = (baseY - 6) * prestamosPorMes(i) / mx
            Dim x As Single = i * slot + (slot - bw) / 2
            Using path = RoundRect(New RectangleF(x, baseY - h, bw, h), 5),
                  br As New SolidBrush(If(i = Date.Now.Month - 1, Azul, AzulClaro))
                g.FillPath(br, path)
            End Using
            Using br As New SolidBrush(Suave), f As New Font("Segoe UI", 8)
                g.DrawString(letras(i).ToString(), f, br, x + bw / 2, baseY + 5, fmt)
            End Using
        Next
        Using pen As New Pen(Borde)
            g.DrawLine(pen, 0, baseY + 1, p.Width, baseY + 1)
        End Using
    End Sub

    Private Sub DibujarDona(sender As Object, e As PaintEventArgs) Handles pnlDona.Paint
        Dim p = DirectCast(sender, Control)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim d As Integer = Math.Max(60, Math.Min(p.Height - 8, 130))
        Dim grosor As Integer = 26
        Dim rc As New Rectangle(grosor \ 2 + 4, (p.Height - d) \ 2 + grosor \ 2, d - grosor, d - grosor)
        Dim colores() As Color = {Azul, AzulClaro, GrisClaro}
        Dim nombres() As String = {"Activos", "Devueltos", "Con retraso"}
        Dim total As Integer = estados.Sum()

        If total = 0 Then
            Using pen As New Pen(GrisClaro, grosor)
                g.DrawEllipse(pen, rc)
            End Using
        Else
            Dim inicio As Single = -90
            For i = 0 To 2
                Dim barrido As Single = 360.0F * estados(i) / total
                Using pen As New Pen(colores(i), grosor)
                    g.DrawArc(pen, rc, inicio, barrido)
                End Using
                inicio += barrido
            Next
        End If

        Dim y As Integer = (p.Height - 3 * 24) \ 2
        For i = 0 To 2
            Using br As New SolidBrush(colores(i))
                g.FillRectangle(br, d + 24, y + i * 24 + 3, 12, 12)
            End Using
            Using br As New SolidBrush(Texto), f As New Font("Segoe UI", 10)
                g.DrawString(nombres(i), f, br, d + 42, y + i * 24 - 1)
            End Using
        Next
    End Sub

    Private Sub DibujarCategorias(sender As Object, e As PaintEventArgs) Handles pnlCats.Paint
        Dim p = DirectCast(sender, Control)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim n As Integer = catNombres.Length
        Dim filaH As Single = p.Height / n
        Dim mx As Integer = Math.Max(1, catValores.Max())
        For i = 0 To n - 1
            Dim y As Single = i * filaH
            Using br As New SolidBrush(Texto), f As New Font("Segoe UI", 9.5F)
                g.DrawString(catNombres(i), f, br, 0, y)
            End Using
            Dim barY As Single = y + 21
            Dim ancho As Single = p.Width - 4
            Using path = RoundRect(New RectangleF(0, barY, ancho, 10), 5), br As New SolidBrush(GrisClaro)
                g.FillPath(br, path)
            End Using
            Dim w As Single = Math.Max(10, ancho * catValores(i) / mx)
            Using path = RoundRect(New RectangleF(0, barY, w, 10), 5), br As New SolidBrush(Azul)
                g.FillPath(br, path)
            End Using
        Next
    End Sub

    Private Function RoundRect(r As RectangleF, rad As Single) As GraphicsPath
        Dim d As Single = Math.Min(rad * 2, Math.Min(r.Width, r.Height))
        Dim path As New GraphicsPath()
        If d <= 0 Then
            path.AddRectangle(r)
            Return path
        End If
        path.AddArc(r.X, r.Y, d, d, 180, 90)
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90)
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

End Class
