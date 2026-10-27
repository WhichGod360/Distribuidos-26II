Imports System.Threading.Tasks
Imports capaDatos
Imports capaNegocio

Public Class frmBitacora
    Implements IMantenimientoVista

    Private ReadOnly negocio As New bitacoraNegocio()
    Private cargado As Boolean
    Private cargando As Boolean
    Private cerrado As Boolean
    Private actualizacionFallida As Boolean
    Private fechaDesdeFiltro As Date?
    Private fechaHastaFiltro As Date?
    Private usuarioFiltro As Integer?
    Private objetoFiltro As String
    Private accionFiltro As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Async Sub Formulario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        cboAccion.SelectedIndex = 0
        dtDesde.Value = Date.Today
        dtHasta.Value = Date.Today
        dtDesde.Checked = False
        dtHasta.Checked = False
        cargado = True
        Await CargarAsync()
    End Sub

    Public Async Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        Await CargarAsync()
    End Sub

    Private Async Function CargarAsync() As Task
        If Not cargado OrElse cargando OrElse cerrado OrElse IsDisposed OrElse ContextoDiseno.Activo(Me) Then Return
        cargando = True
        actualizador.Stop()
        barraFiltros.Enabled = False
        barraAcciones.Enabled = False
        UseWaitCursor = True
        lblResumen.Text = "Consultando los movimientos..."

        Dim desde As Date? = fechaDesdeFiltro
        Dim hasta As Date? = fechaHastaFiltro
        Dim usuario As Integer? = usuarioFiltro
        Dim objeto As String = objetoFiltro
        Dim accion As String = accionFiltro
        Dim seleccionado As Bitacora = TryCast(tablaBitacora.CurrentRow?.DataBoundItem, Bitacora)
        Dim idSeleccionado As Integer = If(seleccionado Is Nothing, 0, seleccionado.IdMan)
        Try
            Dim movimientos = Await Task.Run(Function() negocio.Listar(desde, hasta, usuario, objeto, accion))
            If cerrado OrElse IsDisposed Then Return
            tablaBitacora.DataSource = movimientos
            tablaBitacora.ClearSelection()
            If movimientos.Count > 0 Then
                Dim fila As DataGridViewRow = tablaBitacora.Rows.Cast(Of DataGridViewRow)().
                    FirstOrDefault(Function(f) DirectCast(f.DataBoundItem, Bitacora).IdMan = idSeleccionado)
                If fila Is Nothing Then fila = tablaBitacora.Rows(0)
                tablaBitacora.CurrentCell = fila.Cells(0)
                fila.Selected = True
            End If
            MostrarCadena()
            actualizacionFallida = False
            lblResumen.Text = movimientos.Count & " movimiento(s) · Actualizado " & Date.Now.ToString("HH:mm:ss") &
                If(chkAutomatico.Checked, " · Actualización automática cada 3 segundos", " · Actualización automática desactivada")
        Catch ex As Exception
            If cerrado OrElse IsDisposed Then Return
            actualizacionFallida = True
            tablaBitacora.DataSource = Nothing
            txtCadena.Clear()
            lblResumen.Text = "No se pudo actualizar. Pulsa Actualizar para reintentar."
            MessageBox.Show(ex.Message, "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            cargando = False
            If Not cerrado AndAlso Not IsDisposed Then
                barraFiltros.Enabled = True
                barraAcciones.Enabled = True
                UseWaitCursor = False
                ActualizarTemporizador()
            End If
        End Try
    End Function

    Private Sub MostrarCadena()
        Dim registro As Bitacora = TryCast(tablaBitacora.CurrentRow?.DataBoundItem, Bitacora)
        txtCadena.Text = If(registro Is Nothing, "", If(registro.CadenaMan, ""))
    End Sub

    Private Sub ActualizarTemporizador()
        actualizador.Stop()
        If cargado AndAlso Not cargando AndAlso Not cerrado AndAlso Not IsDisposed AndAlso
            Not actualizacionFallida AndAlso Visible AndAlso chkAutomatico.Checked AndAlso
            Not ContextoDiseno.Activo(Me) Then
            actualizador.Start()
        End If
    End Sub

    Private Async Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        If cargando Then Return
        fechaDesdeFiltro = If(dtDesde.Checked, CType(dtDesde.Value.Date, Date?), Nothing)
        fechaHastaFiltro = If(dtHasta.Checked, CType(dtHasta.Value.Date, Date?), Nothing)
        usuarioFiltro = If(chkUsuario.Checked, CType(CInt(numUsuario.Value), Integer?), Nothing)
        objetoFiltro = txtObjeto.Text
        accionFiltro = If(cboAccion.SelectedIndex <= 0, Nothing, CStr(cboAccion.SelectedItem))
        Await CargarAsync()
    End Sub

    Private Async Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If cargando Then Return
        dtDesde.Checked = False
        dtHasta.Checked = False
        chkUsuario.Checked = False
        numUsuario.Value = 0
        txtObjeto.Clear()
        cboAccion.SelectedIndex = 0
        fechaDesdeFiltro = Nothing
        fechaHastaFiltro = Nothing
        usuarioFiltro = Nothing
        objetoFiltro = Nothing
        accionFiltro = Nothing
        Await CargarAsync()
    End Sub

    Private Async Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Await CargarAsync()
    End Sub

    Private Sub chkUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsuario.CheckedChanged
        numUsuario.Enabled = chkUsuario.Checked
    End Sub

    Private Sub chkAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutomatico.CheckedChanged
        If Not cargado OrElse ContextoDiseno.Activo(Me) Then Return
        ActualizarTemporizador()
        If Not cargando AndAlso Not actualizacionFallida Then
            lblResumen.Text = If(chkAutomatico.Checked,
                "Actualización automática",
                "Actualización automática desactivada.")
        End If
    End Sub

    Private Async Sub actualizador_Tick(sender As Object, e As EventArgs) Handles actualizador.Tick
        If Not Visible OrElse (FindForm() IsNot Nothing AndAlso FindForm().WindowState = FormWindowState.Minimized) Then Return
        Await CargarAsync()
    End Sub

    Private Sub Formulario_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not cargado OrElse cerrado OrElse IsDisposed OrElse ContextoDiseno.Activo(Me) Then Return
        ActualizarTemporizador()
    End Sub

    Private Sub tablaBitacora_SelectionChanged(sender As Object, e As EventArgs) Handles tablaBitacora.SelectionChanged
        If Not IsHandleCreated Then Return
        MostrarCadena()
    End Sub

    Private Sub Formulario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        cerrado = True
        actualizador.Stop()
    End Sub

    Private Sub Formulario_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
        cerrado = True
    End Sub
End Class
