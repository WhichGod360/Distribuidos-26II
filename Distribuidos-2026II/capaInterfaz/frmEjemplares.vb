Imports System.Data
Imports capaNegocio
Imports Utiles

Public Class frmEjemplares

    Implements IMantenimientoVista

    Public Event VolverALibros()
    Private ReadOnly negocio As New ejemplarNegocio()
    Private ReadOnly idLibro As Integer
    Private ReadOnly tituloLibro As String
    Private datos As DataTable
    Private textoBuscado As String = ""
    Private estadoBuscado As String = ""

    Public Sub New()
        InitializeComponent()
        cboEstado.SelectedIndex = 0
    End Sub

    Public Sub New(id As Integer, titulo As String)
        Me.New()
        If id <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(id))
        idLibro = id
        tituloLibro = titulo
        lblDescripcionVista.Text = "Libro: " & tituloLibro
    End Sub

    Private Sub frmEjemplares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarEjemplares()
    End Sub

    Public Sub ListarEjemplares() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated OrElse idLibro <= 0 Then Return
        Try
            datos = negocio.listarPorLibro(idLibro)
            Filtrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        textoBuscado = txtBuscar.Text.Trim()
        estadoBuscado = If(cboEstado.SelectedIndex > 0, CStr(cboEstado.SelectedItem), "")
        Filtrar()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Using editor As New frmEjemplarDetalle(idLibro, tituloLibro)
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ListarEjemplares()
        End Using
    End Sub

    Private Sub btnEstado_Click(sender As Object, e As EventArgs) Handles btnEstado.Click
        Dim fila = EjemplarSeleccionado()
        If fila Is Nothing Then Return
        Dim nuevoEstado = Not Convert.ToBoolean(fila("activo"))
        If MessageBox.Show("¿Deseas " & If(nuevoEstado, "activar", "desactivar") & " este ejemplar?", "Ejemplares",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            If Not negocio.cambiarEstado(idLibro, CInt(fila("id_ejemplar")), nuevoEstado) Then
                MessageBox.Show("No se pudo cambiar el estado. No se pueden desactivar ejemplares con préstamos registrados, incluso devueltos, o que ya tengan ese estado.",
                    "Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            ListarEjemplares()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        RaiseEvent VolverALibros()
    End Sub

    Private Sub Filtrar()
        If datos Is Nothing Then Return
        Dim resultados = datos.Clone()
        For Each fila As DataRow In datos.Rows
            Dim estado = CStr(fila("estado"))
            Dim id = fila("id_ejemplar").ToString()
            If estadoBuscado <> "" AndAlso estado <> estadoBuscado Then Continue For
            If id.Contains(textoBuscado) OrElse estado.Contains(textoBuscado, StringComparison.CurrentCultureIgnoreCase) Then
                resultados.ImportRow(fila)
            End If
        Next
        tabla.DataSource = resultados
        tabla.ClearSelection()
        lblResumen.Text = resultados.Rows.Count & " ejemplar(es) · Libro N.º " & idLibro
    End Sub

    Private Function EjemplarSeleccionado() As DataRow
        If tabla.SelectedRows.Count = 0 Then Return Nothing
        Dim vista = TryCast(tabla.SelectedRows(0).DataBoundItem, DataRowView)
        Return If(vista Is Nothing, Nothing, vista.Row)
    End Function

    Private Sub tabla_SelectionChanged(sender As Object, e As EventArgs) Handles tabla.SelectionChanged
        Dim fila = EjemplarSeleccionado()
        btnEstado.Enabled = fila IsNot Nothing
        btnEstado.Text = If(fila IsNot Nothing AndAlso Not Convert.ToBoolean(fila("activo")), "Activar", "Desactivar")
    End Sub
End Class
