// Migración única del código existente. No forma parte de la aplicación.
const fs=require('fs'),path=require('path');
const root=path.resolve(__dirname,'../../capaInterfaz');
const names=['frmPrestamos','frmPrestamoDetalle','frmPrestamoDevolucion','frmAutor','frmAutorDetalle','FrmCategoria','frmAgregarCategoria','frmEditarCategoria','frmEjemplares','frmEjemplarDetalle','FrmLibros','FrmLibroDetalle','frmPenalizacion','frmPenalizacionEditar','frmDetallePenalizacion','frmDetallePenalizacionEditar','frmSeleccionCatalogo'];
function removeCalls(s) {
  const re=/^\s*(?:Utiles\.)?MantenimientoUI\.Configurar(?:Listado|Dialogo)\(/m;
  for(let m; (m=re.exec(s));) {
    let pos=m.index+m[0].length,depth=1,quoted=false;
    for(;pos<s.length&&depth;pos++){const c=s[pos];if(c==='"'){if(quoted&&s[pos+1]==='"'){pos++;continue;}quoted=!quoted;}if(!quoted){if(c==='(')depth++;if(c===')')depth--;}}
    s=s.slice(0,m.index)+'\n'+s.slice(pos).replace(/^\r?\n/,'');
  }return s;
}
for(const name of names) {
 let s=fs.readFileSync(path.join(root,name+'.vb'),'utf8').replaceAll('\r\n','\n');
 s=s.replace(/^\s*Inherits Form\s*$/gm,'');
 s=s.replace(/^    Private ReadOnly \w+ As New (?:TextBox|ComboBox|DataGridView|Label|Button|NumericUpDown|DateTimePicker|CheckBox)\b[^\n]*\n/gm,'');
 s=removeCalls(s);
 s=s.replace(/^\s*(?:filtroEstado|cboEstado|cboFiltroEstado)\.Items\.AddRange\([^\n]*\n/gm,'\n');
 s=s.replace(/^\s*tablaAutores\.Columns\.Add\([^\n]*\n/gm,'\n');
 s=s.replace(/^\s*DataGridViewButtonColumn[12]\.Visible = False\n/gm,'\n');
 s=s.replace(/(    Public Sub ActualizarDatos\(\) Implements IMantenimientoVista\.ActualizarDatos\n)/g,'$1        If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return\n');
 s=s.replace(/(    Private Sub \w+_Load\(sender As Object, e As EventArgs\) Handles MyBase.Load\n)/g,'$1        If ContextoDiseno.Activo(Me) Then Return\n');
 s=s.replace(/(    Private Sub Cargar\(sender As Object, e As EventArgs\)\n)/g,'$1        If ContextoDiseno.Activo(Me) Then Return\n');
 if(name==='frmEditarCategoria') {
   s=s.replace('    Public Sub New(id As Integer)\n        InitializeComponent()', '    Public Sub New()\n        InitializeComponent()\n    End Sub\n\n    Public Sub New(id As Integer)\n        Me.New()');
   s=s.replace(/    Private Sub Label1_Click[^\n]*\n    End Sub\n/g,'');
   s=s.replace('If ContextoDiseno.Activo(Me) Then Return','If ContextoDiseno.Activo(Me) OrElse idCategoria <= 0 Then Return');
 }
 if(name==='FrmLibroDetalle') {
   s=s.replaceAll('lblTituloForm','lblTituloVista').replaceAll('lblSubtitulo','lblDescripcionVista').replaceAll('lblCantidad.Visible','bloque_nudCantidad.Visible').replaceAll('lblEjemplares.Visible','bloque_pnlEjemplares.Visible');
   s=s.replace(/^\s*lblCantidadAyuda.Visible = False\n/m,'\n');
   s=s.replace('Handles btnCancelar.Click, btnCerrar.Click','Handles btnCancelar.Click');
   s=s.replace(/    Private Sub ConfigurarDiseno\(\)[\s\S]*?    End Sub/,`    Private Sub ConfigurarDiseno()
        lblTituloVista.Text = If(_idLibro = 0, "Agregar libro", "Editar libro")
        Text = lblTituloVista.Text
        bloque_nudCantidad.Visible = _idLibro = 0
        bloque_pnlEjemplares.Visible = _idLibro > 0
        btnCancelar.DialogResult = DialogResult.None
    End Sub`);
 }
 if(name==='frmAutorDetalle') {
   s=s.replace(/    Public Sub New\(Optional autor As Autor = Nothing\)[\s\S]*?    End Sub/,`    Public Sub New()
        InitializeComponent()
        AddHandler guardar.Click, AddressOf Guardar_Click
    End Sub

    Public Sub New(autor As Autor)
        Me.New()
        Me.autor = autor
        If autor IsNot Nothing Then
            nombre.Text = autor.NombreAutor
            lblTituloVista.Text = "Editar autor"
            Text = lblTituloVista.Text
        End If
    End Sub`);
 }
 if(name==='frmPenalizacionEditar') {
   s=s.replace('    Public Sub New(Optional penalizacion As Penalizacion = Nothing)\n','    Public Sub New()\n        InitializeComponent()\n        AddHandler guardar.Click, AddressOf Guardar_Click\n    End Sub\n\n    Public Sub New(penalizacion As Penalizacion)\n        Me.New()\n');
   s=s.replace('            tipo.Text = penalizacion.TipoPenalizacion','            lblTituloVista.Text = "Editar penalización"\n            Text = lblTituloVista.Text\n            tipo.Text = penalizacion.TipoPenalizacion');
   s=s.replace('        Dim guardar As New Button With {.Text = "Guardar"}\n        AddHandler guardar.Click, AddressOf Guardar_Click\n','');
 }
 if(name==='frmDetallePenalizacionEditar') {
   s=s.replace(/    Public Sub New\(detalle As DetallePenalizacion, idPenalizacion As Integer\)[\s\S]*?    End Sub/,`    Public Sub New()
        InitializeComponent()
        AddHandler Load, AddressOf Cargar
        AddHandler guardar.Click, AddressOf Guardar_Click
    End Sub

    Public Sub New(detalle As DetallePenalizacion, idPenalizacion As Integer)
        Me.New()
        Me.detalle = detalle
        idInicial = idPenalizacion
        If detalle IsNot Nothing Then lblTituloVista.Text = "Editar detalle"
        Text = lblTituloVista.Text
    End Sub`);
 }
 if(name==='frmEjemplares') {
   s=s.replace(/    Public Sub New\(id As Integer, titulo As String\)[\s\S]*?        AddHandler Load,/,`    Public Sub New()
        InitializeComponent()
        filtroEstado.SelectedIndex = 0
        AddHandler Load,`);
   const end=s.indexOf('    End Sub',s.indexOf('    Public Sub New()'));
   s=s.slice(0,end+11)+`\n
    Public Sub New(id As Integer, titulo As String)
        Me.New()
        If id <= 0 Then Throw New ArgumentOutOfRangeException(NameOf(id))
        idLibro = id
        tituloLibro = titulo
        lblDescripcionVista.Text = "Libro: " & tituloLibro
    End Sub
`+s.slice(end+11);
   s=s.replace('If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated Then Return','If ContextoDiseno.Activo(Me) OrElse Not IsHandleCreated OrElse idLibro <= 0 Then Return');
 }
 if(name==='frmEjemplarDetalle') {
   s=`Imports capaNegocio
Imports Utiles

Public Class frmEjemplarDetalle
    Private ReadOnly idLibro As Integer

    Public Sub New()
        InitializeComponent()
        AddHandler guardar.Click, AddressOf Guardar_Click
    End Sub

    Public Sub New(idLibro As Integer, titulo As String)
        Me.New()
        Me.idLibro = idLibro
        libro.Text = titulo
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs)
        Try
            If Not New ejemplarNegocio().agregar(idLibro) Then Throw New InvalidOperationException("No se pudo agregar el ejemplar.")
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
`;
 }
 if(name==='frmSeleccionCatalogo') {
   s=s.replace(/    Public Sub New\(titulo As String, nombres As IEnumerable\(Of String\)\)[\s\S]*?    End Sub/,`    Public Sub New()
        InitializeComponent()
        AddHandler aceptar.Click, Sub() DialogResult = DialogResult.OK
    End Sub

    Public Sub New(titulo As String, nombres As IEnumerable(Of String))
        Me.New()
        lblTituloVista.Text = titulo
        Text = titulo
        opciones.Items.AddRange(nombres.OrderBy(Function(n) n).Cast(Of Object)().ToArray())
        If opciones.Items.Count > 0 Then opciones.SelectedIndex = 0
        aceptar.Enabled = opciones.Items.Count > 0
    End Sub`);
 }
 fs.writeFileSync(path.join(root,name+'.vb'),s,'utf8');
}
