Imports capaDatos
Imports capaNegocio
Imports Utiles

Public Class frmDetallePenalizacion
    Implements IMantenimientoVista

    Public Event VolverAPenalizaciones()
    Private ReadOnly negocio As New detallePenalizacionNegocio()
    Private ReadOnly negocioPen As New penalizacionNegocio()
    Private listaActual As New List(Of DetallePenalizacion)()
    Private cargando As Boolean = True
    Private ReadOnly idPenalizacionInicial As Integer

    Public Sub New()
        Me.New(0)
    End Sub

    Public Sub New(idPenalizacion As Integer)
        InitializeComponent()
        idPenalizacionInicial = idPenalizacion

        AddHandler buscar.TextChanged, Sub() Filtrar()
        AddHandler DataGridView1.SelectionChanged, Sub() btnEditar.Enabled = Seleccionado() IsNot Nothing
        AddHandler btnAgregar.Click, Sub() AbrirEditor(Nothing)
        AddHandler btnEditar.Click, Sub() AbrirEditor(Seleccionado())
        AddHandler btnVolver.Click, Sub() RaiseEvent VolverAPenalizaciones()
        For Each columna As DataGridViewColumn In DataGridView1.Columns
            columna.MinimumWidth = If(columna.Name = "colDescripcion", 190, 100)
        Next
    End Sub

    Private Sub frmDetallePenalizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ContextoDiseno.Activo(Me) Then Return
        Try
            Dim filtro As New List(Of KeyValuePair(Of Integer, String)) From {New KeyValuePair(Of Integer, String)(0, "Todas")}
            For Each p In negocioPen.listarTodos()
                filtro.Add(New KeyValuePair(Of Integer, String)(p.IdPenalizacion, p.DescripcionCombo))
            Next
            cboFiltroSancion.DisplayMember = "Value"
            cboFiltroSancion.ValueMember = "Key"
            cboFiltroSancion.DataSource = filtro
            cboFiltroSancion.DropDownWidth = 450
            If idPenalizacionInicial > 0 Then cboFiltroSancion.SelectedValue = idPenalizacionInicial
        Catch ex As Exception
            MessageBox.Show("No se pudieron cargar las penalizaciones: " & ex.Message, "Detalle de penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cargando = False
        ActualizarDatos()
    End Sub

    Private Function IdFiltro() As Integer
        If cboFiltroSancion.SelectedValue Is Nothing Then Return idPenalizacionInicial
        Return CInt(cboFiltroSancion.SelectedValue)
    End Function

    Public Sub ActualizarDatos() Implements IMantenimientoVista.ActualizarDatos
        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return
        If cargando Then Return
        Try
            listaActual = negocio.listar(IdFiltro())
            Filtrar()
        Catch ex As Exception
            MessageBox.Show("No se pudieron cargar los detalles: " & ex.Message, "Detalle de penalizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Filtrar()
        If cargando Then Return
        Dim texto = buscar.Text.Trim()
        DataGridView1.Rows.Clear()
        For Each d In listaActual
            If texto <> "" AndAlso (d.NombreUsuario & " " & d.TituloLibro & " " & d.DescripcionDetallePenalizacion & " " & d.IdPrestamo & " " & d.EstadoPagoTexto).IndexOf(texto, StringComparison.OrdinalIgnoreCase) < 0 Then Continue For
            DataGridView1.Rows.Add(d.IdDetallePenalizacion, d.TipoPenalizacion, "S/ " & d.MontoPenalizacion.ToString("N2"),
                d.IdPrestamo, d.NombreUsuario, d.TituloLibro, d.FechaInicio.ToString("dd/MM/yyyy"), d.FechaFin.ToString("dd/MM/yyyy"),
                If(d.FechaRetorno.HasValue, d.FechaRetorno.Value.ToString("dd/MM/yyyy"), "-"), d.DiasRetraso, d.EstadoPrestamo, d.DescripcionDetallePenalizacion, d.EstadoPagoTexto)
        Next
        DataGridView1.ClearSelection()
        btnEditar.Enabled = False
        lblResumen.Text = DataGridView1.Rows.Count & " detalle(s)"
    End Sub

    Private Function Seleccionado() As DetallePenalizacion
        If DataGridView1.SelectedRows.Count = 0 Then Return Nothing
        Dim id = CInt(DataGridView1.SelectedRows(0).Cells("colId").Value)
        Return listaActual.FirstOrDefault(Function(d) d.IdDetallePenalizacion = id)
    End Function

    Private Sub cboFiltroSancion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFiltroSancion.SelectedIndexChanged
        ActualizarDatos()
    End Sub

    Private Sub AbrirEditor(detalle As DetallePenalizacion)
        Using editor As New frmDetallePenalizacionEditar(detalle, IdFiltro())
            If MantenimientoUI.MostrarDialogo(editor, Me) = DialogResult.OK Then ActualizarDatos()
        End Using
    End Sub
End Class
