// Herramienta de migración, de ejecución manual. El resultado son Designer.vb
// estáticos y editables en Visual Studio; la aplicación no ejecuta este archivo.
const fs = require('fs');
const path = require('path');
const root = path.resolve(__dirname, '../../capaInterfaz');
const q = s => '"' + s.replaceAll('"','""') + '"';
const color = s => `System.Drawing.Color.FromArgb(${s})`;
const blue = color('72, 101, 244'), ink = color('28, 36, 55'), muted = color('105, 116, 140');
class Designer {
  constructor(name) { this.name=name; this.items=new Map(); this.lines=[]; }
  add(n,t,props={}) {if(this.items.has(n))throw Error(n); this.items.set(n,t); this.set(n,{Name:q(n),...props}); return n;}
  set(n,p) { for(const [k,v] of Object.entries(p))this.lines.push(`Me.${n}.${k} = ${v}`); }
  line(s) {this.lines.push(s);}
  child(parent,child,c,r) { this.line(`Me.${parent}.Controls.Add(Me.${child}${c===undefined?'':`, ${c}, ${r}`})`); }
  label(n,text,props={}) {return this.add(n,'Label',{Text:q(text),ForeColor:ink,AutoSize:'False',...props});}
  button(n,text,primary=false,props={}) {return this.add(n,'Button',{Text:q(text),Size:'New System.Drawing.Size(170, 38)',AutoSize:'False',FlatStyle:'System.Windows.Forms.FlatStyle.Flat','FlatAppearance.BorderSize':primary?'0':'1','FlatAppearance.BorderColor':color('215, 222, 237'),BackColor:primary?blue:'System.Drawing.Color.White',ForeColor:primary?'System.Drawing.Color.White':blue,Font:'New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)',Cursor:'System.Windows.Forms.Cursors.Hand',Margin:'New System.Windows.Forms.Padding(0, 0, 10, 4)',UseVisualStyleBackColor:'False',...props});}
  combo(n,items=[],props={}) {this.add(n,'ComboBox',{DropDownStyle:'System.Windows.Forms.ComboBoxStyle.DropDownList',...props}); if(items.length)this.line(`Me.${n}.Items.AddRange(New Object() {${items.map(q).join(', ')}})`);}
  style(n,props) { this.items.set(n,'DataGridViewCellStyle'); this.set(n,props); return `Me.${n}`; }
  grid(n,cols,fill=false) {
    this.add(n,'DataGridView',{Dock:'System.Windows.Forms.DockStyle.Fill',ReadOnly:'True',AllowUserToAddRows:'False',AllowUserToDeleteRows:'False',MultiSelect:'False',SelectionMode:'System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect',RowHeadersVisible:'False',AutoGenerateColumns:'False',AutoSizeColumnsMode:`System.Windows.Forms.DataGridViewAutoSizeColumnsMode.${fill?'Fill':'None'}`,BackgroundColor:'System.Drawing.Color.White',BorderStyle:'System.Windows.Forms.BorderStyle.None',GridColor:color('231, 235, 246'),EnableHeadersVisualStyles:'False',ColumnHeadersHeight:'40','RowTemplate.Height':'36',Margin:'New System.Windows.Forms.Padding(0)',AccessibleName:q('Tabla de resultados')});
    this.set(n,{ColumnHeadersDefaultCellStyle:this.style(n+'Cabecera',{BackColor:color('234, 239, 255'),ForeColor:ink,Font:'New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)'}),DefaultCellStyle:this.style(n+'Celdas',{SelectionBackColor:color('222, 229, 255'),SelectionForeColor:ink,NullValue:q('—')}),AlternatingRowsDefaultCellStyle:this.style(n+'Alternas',{BackColor:color('248, 250, 255')})});
    for(const [field,text,prop,width,format='',name=field] of cols) {
      this.add(field,'DataGridViewTextBoxColumn',{Name:q(name),HeaderText:q(text),DataPropertyName:q(prop),Width:String(width),FillWeight:String(width),ReadOnly:'True',SortMode:'System.Windows.Forms.DataGridViewColumnSortMode.NotSortable'});
      if(format)this.set(field,{DefaultCellStyle:this.style(field+'Formato',{Format:q(format),NullValue:q('—')})});
      this.line(`Me.${n}.Columns.Add(Me.${field})`);
    }
  }
  table(n,rows,cols=[100],props={}) {
    this.add(n,'TableLayoutPanel',{Dock:'System.Windows.Forms.DockStyle.Fill',RowCount:String(rows.length),ColumnCount:String(cols.length),Margin:'New System.Windows.Forms.Padding(0)',...props});
    cols.forEach(v=>this.line(`Me.${n}.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.${typeof v==='number'?'Percent':'Absolute'}, ${parseFloat(v)}!))`));
    rows.forEach(v=>this.line(`Me.${n}.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.${v==='auto'?'AutoSize':typeof v==='number'?'Absolute':'Percent'}${v==='auto'?'':`, ${parseFloat(v)}!`}))`));
  }
  header(title,desc) {
    this.title=title;
    this.table('encabezado',[80],['72px',100]);
    this.add('imagenModulo','PictureBox',{Dock:'System.Windows.Forms.DockStyle.Fill',Image:'Global.capaInterfaz.My.Resources.Resources.no',SizeMode:'System.Windows.Forms.PictureBoxSizeMode.Zoom',Margin:'New System.Windows.Forms.Padding(0, 0, 16, 10)',TabStop:'False',AccessibleName:q('Lecturae, biblioteca y comunidad')});
    this.add('textoEncabezado','Panel',{Dock:'System.Windows.Forms.DockStyle.Fill'});
    this.label('lblTituloVista',title,{Dock:'System.Windows.Forms.DockStyle.Top',Height:'38',Font:'New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold)'});
    this.label('lblDescripcionVista',desc,{Dock:'System.Windows.Forms.DockStyle.Fill',ForeColor:muted});
    this.child('textoEncabezado','lblDescripcionVista');this.child('textoEncabezado','lblTituloVista');
    this.child('encabezado','imagenModulo',0,0);this.child('encabezado','textoEncabezado',1,0);
  }
  field(parent,n,t,label,items=[],props={},height=30,width=0) {
    if(!this.items.has(n)) {if(t==='ComboBox')this.combo(n,items,props);else this.add(n,t,props);}
    const block='bloque_'+n, caption='etiqueta_'+n;
    this.add(block,'Panel',{Dock:width?'System.Windows.Forms.DockStyle.None':'System.Windows.Forms.DockStyle.Fill',Size:`New System.Drawing.Size(${width||550}, ${height+28})`,Margin:'New System.Windows.Forms.Padding(0, 0, 12, 6)'});
    this.label(caption,label,{Dock:'System.Windows.Forms.DockStyle.Top',Height:'24',Font:'New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)'});
    this.set(n,{Dock:'System.Windows.Forms.DockStyle.Top',Height:String(height)});
    this.child(block,n);this.child(block,caption);
    this.child(parent,block);
    return block;
  }
  save(width=1100,height=680,dialog=false) {
    const init=this.items, containers=[...init].filter(([n,t])=>/Panel$/.test(t)).map(([n])=>n);
    const begin=[...init].filter(([n,t])=>['DataGridView','NumericUpDown','PictureBox'].includes(t)).map(([n])=>n);
    const head=`<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>\nPartial Class ${this.name}\n    Inherits System.Windows.Forms.Form\n\n    Private components As System.ComponentModel.IContainer\n    <System.Diagnostics.DebuggerNonUserCode()>\n    Protected Overrides Sub Dispose(disposing As Boolean)\n        Try\n            If disposing AndAlso components IsNot Nothing Then components.Dispose()\n        Finally\n            MyBase.Dispose(disposing)\n        End Try\n    End Sub\n\n    <System.Diagnostics.DebuggerStepThrough()>\n    Private Sub InitializeComponent()\n        Me.components = New System.ComponentModel.Container()\n`;
    const out=[...init].map(([n,t])=>`Me.${n} = New System.Windows.Forms.${t}()`);
    out.push(...begin.map(n=>`CType(Me.${n}, System.ComponentModel.ISupportInitialize).BeginInit()`),...containers.map(n=>`Me.${n}.SuspendLayout()`),'Me.SuspendLayout()',...this.lines);
    out.push('Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)','Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi','Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)','Me.BackColor = System.Drawing.Color.White',`Me.ClientSize = New System.Drawing.Size(${width}, ${height})`,`Me.Name = ${q(this.name)}`,`Me.Text = ${q(this.title||this.name)}`);
    if(dialog)out.push('Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable','Me.MinimizeBox = False','Me.MaximizeBox = False','Me.ShowInTaskbar = False','Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent', 'Me.MinimumSize = New System.Drawing.Size(500, 360)');
    out.push(...begin.map(n=>`CType(Me.${n}, System.ComponentModel.ISupportInitialize).EndInit()`),...containers.reverse().flatMap(n=>[`Me.${n}.ResumeLayout(False)`,`Me.${n}.PerformLayout()`]),'Me.ResumeLayout(False)');
    fs.writeFileSync(path.join(root,this.name+'.Designer.vb'),head+out.map(s=>'        '+s).join('\n')+'\n    End Sub\n\n'+[...init].map(([n,t])=>`    Friend WithEvents ${n} As System.Windows.Forms.${t}`).join('\n')+'\nEnd Class\n','utf8');
    const resx=path.join(root,this.name+'.resx');
    if(!fs.existsSync(resx))fs.writeFileSync(resx,'<?xml version="1.0" encoding="utf-8"?>\n<root>\n<resheader name="resmimetype"><value>text/microsoft-resx</value></resheader>\n<resheader name="version"><value>2.0</value></resheader>\n<resheader name="reader"><value>System.Resources.ResXResourceReader, System.Windows.Forms</value></resheader>\n<resheader name="writer"><value>System.Resources.ResXResourceWriter, System.Windows.Forms</value></resheader>\n</root>\n');
  }
}

function list(name,title,desc,grid,search,buttons,summary,filters,columns,extra) {
 const d=new Designer(name); d.header(title,desc);
 d.table('layoutVista',[84,'auto','auto','100%',52],[100],{Padding:'New System.Windows.Forms.Padding(24, 18, 24, 12)'});
 d.add('barraFiltros','FlowLayoutPanel',{Dock:'System.Windows.Forms.DockStyle.Fill',AutoSize:'True',WrapContents:'True'});
 d.field('barraFiltros',search,'TextBox','Buscar',[],{PlaceholderText:q('Buscar...')},30,320);
 for(const [n,label,items]of filters)d.field('barraFiltros',n,'ComboBox',label,items,{},30,180);
 d.add('barraAcciones','FlowLayoutPanel',{Dock:'System.Windows.Forms.DockStyle.Fill',AutoSize:'True',WrapContents:'True',Margin:'New System.Windows.Forms.Padding(0, 4, 0, 10)'});
 buttons.forEach(([n,text,enabled=true],i)=>{d.button(n,text,i===0,{Enabled:enabled?'True':'False'});d.child('barraAcciones',n)});
 d.grid(grid,columns,columns.length<=6);
 d.label(summary,'Sin datos cargados. Abre la pantalla para consultar.',{Dock:'System.Windows.Forms.DockStyle.Fill',ForeColor:muted,TextAlign:'System.Drawing.ContentAlignment.MiddleLeft',AutoEllipsis:'True'});
 d.child('layoutVista','encabezado',0,0);d.child('layoutVista','barraFiltros',0,1);d.child('layoutVista','barraAcciones',0,2);d.child('layoutVista',grid,0,3);d.child('layoutVista',summary,0,4);
 if(extra)extra(d);
 d.line('Me.Controls.Add(Me.layoutVista)');d.save();
}
const loanCols=[['colPrestamo','Préstamo','IdPrestamo',75,'','IdPrestamo'],['colLector','Lector','NombreLector',190,'','NombreLector'],['colEjemplar','Ejemplar','IdEjemplar',75,'','IdEjemplar'],['colLibro','Libro','TituloLibro',200,'','TituloLibro'],['colFin','Fecha límite','FechaFin',100,'dd/MM/yyyy','FechaFin'],['colEstado','Estado','EstadoPrestamo',95,'','EstadoPrestamo'],['colRetorno','Devolución','FechaRetorno',100,'dd/MM/yyyy','FechaRetorno'],['colDias','Días de retraso','DiasRetraso',90,'','DiasRetraso'],['colInicio','Inicio','FechaInicio',100,'dd/MM/yyyy','FechaInicio'],['colDni','DNI','DniLector',90,'','DniLector'],['colCorreo','Correo','CorreoLector',220,'','CorreoLector'],['colBibliotecario','Bibliotecario','NombreBibliotecario',210,'','NombreBibliotecario']];
list('frmPrestamos','Préstamos','Préstamos y devoluciones de copias físicas.','tabla','buscar',[['btnNuevo','Nuevo préstamo',false],['btnDevolver','Registrar devolución',false],['btnActualizar','Actualizar']],'resumen',[['filtroEstado','Estado',['Todos','Activos','Vencidos','Devueltos']]],loanCols);
list('frmAutor','Autores','Organiza los autores del catálogo.','tablaAutores','txtBuscarAutor',[['btnAgregar','Agregar autor'],['btnEditar','Editar',false],['btnEliminar','Eliminar',false]],'lblResumen',[],[['colIdAutor','ID','IdAutor',15],['colNombreAutor','Nombre del autor','NombreAutor',85]]);
list('FrmCategoria','Categorías','Clasifica los libros de la biblioteca.','tbCategoria','txtBuscar',[['Button10','Agregar categoría'],['Button11','Editar',false]],'lblResumen',[['cboEstado','Estado',['Todos','Activo','Inactivo']]],[['colIdCategoria','ID','id_categoria',15,'','id_categoria'],['colNombreCategoria','Nombre de la categoría','nombre_categoria',60,'','nombre_categoria'],['colEstadoCategoria','Estado','estado',25,'','estado']]);
list('frmEjemplares','Ejemplares','Selecciona un libro desde el catálogo para consultar sus copias.','tabla','buscar',[['btnAgregar','Agregar ejemplar'],['btnEstado','Desactivar',false],['btnVolver','Volver a libros']],'lblResumen',[['filtroEstado','Estado',['Todos','Disponible','Prestado','Inactivo']]],[['colIdEjemplar','ID del ejemplar','id_ejemplar',30,'','id_ejemplar'],['colActivo','Habilitado','activo',20,'','activo'],['colEstadoEjemplar','Estado','estado',50,'','estado']],d=>d.set('colActivo',{Visible:'False'}));
list('frmPenalizacion','Penalizaciones','Administra las sanciones, sus montos y su estado.','DataGridView1','txtBuscar',[['btnNuevo','Agregar penalización'],['btnGuardar','Editar',false],['btnCambiarEstado','Desactivar',false],['btnVerDetalles','Ver detalles',false]],'lblResumen',[['cboFiltroEstado','Estado',['Todos','Activo','Inactivo']]],[['colId','ID','',10],['colTipo','Tipo','',23],['colMonto','Monto','',12],['colDescripcion','Descripción','',37],['colEstado','Estado','',18]]);
list('frmDetallePenalizacion','Detalle de penalizaciones','Consulta las sanciones asociadas a los préstamos.','DataGridView1','buscar',[['btnAgregar','Agregar detalle'],['btnEditar','Editar',false],['btnVolver','Volver a penalizaciones']],'lblResumen',[['cboFiltroSancion','Penalización',[]]],[['colId','ID','',55],['colSancion','Penalización','',160],['colMonto','Monto','',85],['colIdPrestamo','Préstamo','',85],['colUsuario','Lector','',180],['colLibro','Libro','',180],['colInicio','Inicio','',100],['colVence','Vence','',100],['colRetorno','Retorno','',100],['colDias','Retraso','',80],['colEstadoPrestamo','Estado','',95],['colDescripcion','Descripción','',220]]);
list('FrmLibros','Libros','Administra el catálogo y las copias de cada libro.','DataGridView1','txtBuscar',[['btnAgregar','Agregar libro'],['btnEditar','Editar',false],['btnDesactivar','Desactivar',false],['btnEjemplares','Ver ejemplares',false]],'lblRegistros',[['cboEstado','Estado',['Todos','Activo','Inactivo']],['cboOrden','Ordenar',['Título A–Z','Título Z–A','Año ascendente','Año descendente']]],[['colId','ID','id',10],['colTitulo','Título','titulo',34],['colEditorial','Editorial','editorial',20],['colAnio','Año','anio',10],['colStock','Ejemplares','stock',10],['colEstado','Estado','estado',16]],d=>{
 d.add('pnlPaginacion','FlowLayoutPanel',{Dock:'System.Windows.Forms.DockStyle.Right',Width:'330',WrapContents:'False'});d.button('btnPagPrev','‹',false,{Width:'40'});d.add('flpNumeros','FlowLayoutPanel',{Width:'205',Height:'40'});d.button('btnPagNext','›',false,{Width:'40'});d.child('pnlPaginacion','btnPagPrev');d.child('pnlPaginacion','flpNumeros');d.child('pnlPaginacion','btnPagNext');
 d.add('pieListado','Panel',{Dock:'System.Windows.Forms.DockStyle.Fill'});d.lines=d.lines.filter(line=>line!=='Me.layoutVista.Controls.Add(Me.lblRegistros, 0, 4)');d.child('pieListado','lblRegistros');d.child('pieListado','pnlPaginacion');d.child('layoutVista','pieListado',0,4);
});

function dialog(name,title,desc,fields,save='guardar',cancel='cancelar',extra) {
 const d=new Designer(name);d.header(title,desc);d.table('layoutEditor',[84,'100%',58],[100],{Padding:'New System.Windows.Forms.Padding(24, 18, 24, 12)'});
 d.add('cuerpoEditor','Panel',{Dock:'System.Windows.Forms.DockStyle.Fill',AutoScroll:'True'});
 d.table('camposEditor',fields.map(f=>(f[5]||30)+34),[100],{Dock:'System.Windows.Forms.DockStyle.Top',AutoSize:'True'});
 for(const [n,t,label,props={},items=[],height=30]of fields)d.field('camposEditor',n,t,label,items,props,height);
 d.add('accionesEditor','FlowLayoutPanel',{Dock:'System.Windows.Forms.DockStyle.Fill',FlowDirection:'System.Windows.Forms.FlowDirection.RightToLeft',Padding:'New System.Windows.Forms.Padding(0, 12, 0, 0)'});
 d.button(save,'Guardar',true,{Width:'155'});d.button(cancel,'Cancelar',false,{Width:'140',DialogResult:'System.Windows.Forms.DialogResult.Cancel'});
 d.child('accionesEditor',save);d.child('accionesEditor',cancel);d.child('cuerpoEditor','camposEditor');d.child('layoutEditor','encabezado',0,0);d.child('layoutEditor','cuerpoEditor',0,1);d.child('layoutEditor','accionesEditor',0,2);
 d.line('Me.Controls.Add(Me.layoutEditor)');d.line(`Me.AcceptButton = Me.${save}`);d.line(`Me.CancelButton = Me.${cancel}`);if(extra)extra(d);
 d.save(660,Math.min(730,190+fields.reduce((a,f)=>a+(f[5]||30)+34,0)),true);
}
dialog('frmAutorDetalle','Agregar autor','Completa el nombre del autor del catálogo.',[['nombre','TextBox','Nombre del autor',{MaxLength:'255'}]]);
for(const [n,title]of [['frmAgregarCategoria','Agregar categoría'],['frmEditarCategoria','Editar categoría']])dialog(n,title,'Completa el nombre y el estado de la categoría.',[['txtNombre','TextBox','Nombre',{MaxLength:'30'}],['chkEstado','CheckBox','Estado',{Text:q('Activo'),Checked:'True'}]],'Button10','Button11');
dialog('frmEjemplarDetalle','Agregar ejemplar','Registra una nueva copia física del libro.',[['libro','TextBox','Libro',{ReadOnly:'True',PlaceholderText:q('Libro seleccionado en el catálogo')}],['estado','Label','Estado inicial',{Text:q('Se registrará un ejemplar habilitado.') }]]);
dialog('frmPenalizacionEditar','Agregar penalización','Define el tipo de sanción y su monto en soles.',[['tipo','TextBox','Tipo',{MaxLength:'30'}],['monto','NumericUpDown','Monto (S/)',{DecimalPlaces:'2',Maximum:'99999.99D',Minimum:'0D',ThousandsSeparator:'True'}],['descripcion','TextBox','Descripción',{Multiline:'True',ScrollBars:'System.Windows.Forms.ScrollBars.Vertical'},[],76],['activo','CheckBox','Estado',{Text:q('Activo'),Checked:'True'}]]);
dialog('frmDetallePenalizacionEditar','Agregar detalle','Vincula una penalización con un préstamo.',[['sancion','ComboBox','Penalización',{DropDownWidth:'520'}],['prestamo','ComboBox','Préstamo',{DropDownWidth:'800'}],['descripcion','TextBox','Descripción',{Multiline:'True',ScrollBars:'System.Windows.Forms.ScrollBars.Vertical'},[],76]]);
dialog('frmSeleccionCatalogo','Seleccionar registro','Selecciona un registro existente del catálogo.',[['opciones','ComboBox','Registro']],'aceptar','cancelar',d=>d.set('aceptar',{Text:q('Seleccionar')}));
dialog('frmPrestamoDetalle','Nuevo préstamo','Selecciona al lector y una copia física disponible.',[
 ['txtBibliotecario','TextBox','Bibliotecario',{ReadOnly:'True',PlaceholderText:q('Cuenta autenticada')}],
 ['busqueda','Panel','Buscar lector activo (rol Estudiante)'],
 ['lector','ComboBox','Lector · DNI · correo',{DropDownWidth:'850'}],['libro','ComboBox','Libro habilitado',{DropDownWidth:'850'}],['ejemplar','ComboBox','Ejemplar disponible'],
 ['inicio','DateTimePicker','Fecha de inicio',{Format:'System.Windows.Forms.DateTimePickerFormat.Short'}],['limite','DateTimePicker','Fecha límite: marcar y elegir',{Format:'System.Windows.Forms.DateTimePickerFormat.Short',ShowCheckBox:'True',Checked:'False'}],
 ['lblPlazo','Label','Plazo',{Text:q('Elige la fecha límite. No hay un plazo predeterminado.'),ForeColor:muted}]
],'guardar','cancelar',d=>{d.add('buscar','TextBox',{Dock:'System.Windows.Forms.DockStyle.Fill',PlaceholderText:q('Nombre, apellido, DNI o correo'),MaxLength:'300'});d.button('btnBuscar','Buscar lectores',false,{Dock:'System.Windows.Forms.DockStyle.Right',Width:'155'});d.child('busqueda','buscar');d.child('busqueda','btnBuscar');d.set('guardar',{Text:q('Registrar')});});
dialog('frmPrestamoDevolucion','Registrar devolución','Confirma la fecha real de devolución de la copia.',[
 ['txtBibliotecario','TextBox','Bibliotecario que realiza la operación',{ReadOnly:'True',PlaceholderText:q('Cuenta autenticada')}],
 ['txtPrestamo','TextBox','Préstamo y lector',{ReadOnly:'True',PlaceholderText:q('Selecciona un préstamo en el listado')}],['txtEjemplar','TextBox','Ejemplar y libro',{ReadOnly:'True'}],['lblFechas','Label','Inicio y fecha límite'],
 ['retorno','DateTimePicker','Fecha real de devolución',{Format:'System.Windows.Forms.DateTimePickerFormat.Short'}],['retraso','Label','Días de retraso',{Text:q('—')}]
],'guardar','cancelar',d=>d.set('guardar',{Text:q('Devolver')}));

// El editor de libros conserva controles y eventos originales; sus contenedores
// de autores/categorías quedan visibles antes de cargar relaciones desde SQL.
dialog('FrmLibroDetalle','Agregar libro','Completa los datos del catálogo y sus relaciones.',[
 ['txtTitulo','TextBox','Título',{MaxLength:'255'}],['txtEditorial','TextBox','Editorial',{MaxLength:'255'}],['dtpAnio','DateTimePicker','Año de publicación',{Format:'System.Windows.Forms.DateTimePickerFormat.Custom',CustomFormat:q('yyyy'),ShowUpDown:'True'}],
 ['flpAutores','FlowLayoutPanel','Autores',{AutoScroll:'True'},[],60],['flpCategorias','FlowLayoutPanel','Categorías',{AutoScroll:'True'},[],60],['cboPublico','ComboBox','Público objetivo',{},['General','Universitario','Infantil','Juvenil']],
 ['nudCantidad','NumericUpDown','Cantidad inicial de ejemplares',{Maximum:'500D',Minimum:'0D'}],['pnlEjemplares','Panel','Ejemplares del libro'],['chkActivo','CheckBox','Estado',{Text:q('Habilitado'),Checked:'True'}]
],'btnGuardar','btnCancelar',d=>{
 d.button('btnAddAutor','Añadir autor',false,{Size:'New System.Drawing.Size(155, 32)'});d.button('btnAddCategoria','Añadir categoría',false,{Size:'New System.Drawing.Size(175, 32)'});d.child('flpAutores','btnAddAutor');d.child('flpCategorias','btnAddCategoria');
 d.label('lblEjemplaresInfo','Se mostrará el total al editar un libro.',{Dock:'System.Windows.Forms.DockStyle.Fill'});d.add('lnkGestionar','LinkLabel',{Text:q('Gestionar'),Dock:'System.Windows.Forms.DockStyle.Right',Width:'100'});d.child('pnlEjemplares','lblEjemplaresInfo');d.child('pnlEjemplares','lnkGestionar');d.set('btnCancelar',{DialogResult:'System.Windows.Forms.DialogResult.None'});
});

module.exports = { Designer, list, dialog, loanCols, q, color, blue, ink, muted, root };
