<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUsuarioDetalle
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        layoutEditor = New TableLayoutPanel()
        encabezado = New Panel()
        lblTituloVista = New Label()
        lblDescripcionVista = New Label()
        cuerpoEditor = New Panel()
        accionesEditor = New FlowLayoutPanel()
        btnCancelar = New Button()
        btnGuardar = New Button()
        listaCampos = New TableLayoutPanel()
        camposCuenta = New TableLayoutPanel()
        camposAcceso = New TableLayoutPanel()
        bloque_txtNombre = New Panel()
        etiqueta_txtNombre = New Label()
        txtNombre = New TextBox()
        bloque_txtPaterno = New Panel()
        etiqueta_txtPaterno = New Label()
        txtPaterno = New TextBox()
        bloque_txtMaterno = New Panel()
        etiqueta_txtMaterno = New Label()
        txtMaterno = New TextBox()
        bloque_txtCorreo = New Panel()
        etiqueta_txtCorreo = New Label()
        txtCorreo = New TextBox()
        bloque_txtDni = New Panel()
        etiqueta_txtDni = New Label()
        txtDni = New TextBox()
        bloque_dtNacimiento = New Panel()
        etiqueta_dtNacimiento = New Label()
        dtNacimiento = New DateTimePicker()
        bloque_cboGenero = New Panel()
        etiqueta_cboGenero = New Label()
        cboGenero = New ComboBox()
        bloque_cboRol = New Panel()
        etiqueta_cboRol = New Label()
        cboRol = New ComboBox()
        bloque_cboEstado = New Panel()
        etiqueta_cboEstado = New Label()
        cboEstado = New ComboBox()
        bloque_txtClave = New Panel()
        etiqueta_txtClave = New Label()
        txtClave = New TextBox()
        bloque_txtConfirmar = New Panel()
        etiqueta_txtConfirmar = New Label()
        txtConfirmar = New TextBox()
        bloque_txtPregunta = New Panel()
        etiqueta_txtPregunta = New Label()
        txtPregunta = New TextBox()
        bloque_txtRespuesta = New Panel()
        etiqueta_txtRespuesta = New Label()
        txtRespuesta = New TextBox()
        layoutEditor.SuspendLayout()
        encabezado.SuspendLayout()
        cuerpoEditor.SuspendLayout()
        accionesEditor.SuspendLayout()
        listaCampos.SuspendLayout()
        camposCuenta.SuspendLayout()
        camposAcceso.SuspendLayout()
        bloque_txtNombre.SuspendLayout()
        bloque_txtPaterno.SuspendLayout()
        bloque_txtMaterno.SuspendLayout()
        bloque_txtCorreo.SuspendLayout()
        bloque_txtDni.SuspendLayout()
        bloque_dtNacimiento.SuspendLayout()
        bloque_cboGenero.SuspendLayout()
        bloque_cboRol.SuspendLayout()
        bloque_cboEstado.SuspendLayout()
        bloque_txtClave.SuspendLayout()
        bloque_txtConfirmar.SuspendLayout()
        bloque_txtPregunta.SuspendLayout()
        bloque_txtRespuesta.SuspendLayout()

        SuspendLayout()
        '
        ' layoutEditor
        '
        layoutEditor.Name = "layoutEditor"
        layoutEditor.ColumnCount = 1
        layoutEditor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        layoutEditor.RowCount = 3
        layoutEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 80.0F))
        layoutEditor.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        layoutEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 54.0F))
        layoutEditor.Dock = DockStyle.Fill
        layoutEditor.Padding = New Padding(24, 18, 24, 16)
        layoutEditor.Size = New Size(820, 650)
        layoutEditor.Controls.Add(encabezado, 0, 0)
        layoutEditor.Controls.Add(cuerpoEditor, 0, 1)
        layoutEditor.Controls.Add(accionesEditor, 0, 2)
        layoutEditor.TabIndex = 0
        '
        ' encabezado
        '
        encabezado.Name = "encabezado"
        encabezado.Dock = DockStyle.Fill
        encabezado.Margin = New Padding(0)
        encabezado.Controls.Add(lblDescripcionVista)
        encabezado.Controls.Add(lblTituloVista)
        '
        ' lblTituloVista
        '
        lblTituloVista.Name = "lblTituloVista"
        lblTituloVista.Text = "Agregar usuario"
        lblTituloVista.Dock = DockStyle.Top
        lblTituloVista.Height = 37
        lblTituloVista.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblTituloVista.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' lblDescripcionVista
        '
        lblDescripcionVista.Name = "lblDescripcionVista"
        lblDescripcionVista.Text = "Completa los datos de la cuenta y selecciona sus permisos."
        lblDescripcionVista.Dock = DockStyle.Fill
        lblDescripcionVista.AutoEllipsis = True
        lblDescripcionVista.ForeColor = Color.FromArgb(120, 120, 120)
        '
        ' cuerpoEditor
        '
        cuerpoEditor.Name = "cuerpoEditor"
        cuerpoEditor.Dock = DockStyle.Fill
        cuerpoEditor.AutoScroll = True
        cuerpoEditor.Margin = New Padding(0)
        cuerpoEditor.TabIndex = 1
        '
        ' accionesEditor
        '
        accionesEditor.Name = "accionesEditor"
        accionesEditor.Dock = DockStyle.Fill
        accionesEditor.Margin = New Padding(0)
        accionesEditor.Padding = New Padding(0, 12, 0, 0)
        accionesEditor.FlowDirection = FlowDirection.RightToLeft
        accionesEditor.WrapContents = False
        accionesEditor.Controls.Add(btnCancelar)
        accionesEditor.Controls.Add(btnGuardar)
        accionesEditor.TabIndex = 2
        '
        ' btnCancelar
        '
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Text = "Cancelar"
        btnCancelar.Size = New Size(138, 36)
        btnCancelar.Margin = New Padding(10, 0, 0, 0)
        btnCancelar.TabIndex = 1
        btnCancelar.Cursor = Cursors.Hand
        btnCancelar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.UseVisualStyleBackColor = False
        btnCancelar.BackColor = Color.White
        btnCancelar.ForeColor = Color.FromArgb(59, 91, 115)
        btnCancelar.FlatAppearance.BorderSize = 1
        btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 244, 247)
        btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 232, 238)
        btnCancelar.DialogResult = DialogResult.Cancel
        '
        ' btnGuardar
        '
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Text = "Guardar"
        btnGuardar.Size = New Size(138, 36)
        btnGuardar.Margin = New Padding(10, 0, 0, 0)
        btnGuardar.TabIndex = 0
        btnGuardar.Cursor = Cursors.Hand
        btnGuardar.Font = New Font("Segoe UI Semibold", 10.0F)
        btnGuardar.FlatStyle = FlatStyle.Flat
        btnGuardar.UseVisualStyleBackColor = False
        btnGuardar.BackColor = Color.FromArgb(59, 91, 115)
        btnGuardar.ForeColor = Color.White
        btnGuardar.FlatAppearance.BorderSize = 0
        btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(59, 91, 115)
        btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(47, 72, 92)
        btnGuardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 56, 72)
        '
        ' Me
        '
        Me.AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 10.0F)
        Me.ClientSize = New Size(820, 650)
        Me.Text = "Agregar usuario"
        Me.Name = "frmUsuarioDetalle"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.AcceptButton = btnGuardar
        Me.CancelButton = btnCancelar
        Me.Controls.Add(layoutEditor)
        '
        ' listaCampos
        '
        listaCampos.Name = "listaCampos"
        listaCampos.Dock = DockStyle.Top
        listaCampos.AutoSize = True
        listaCampos.AutoSizeMode = AutoSizeMode.GrowAndShrink
        listaCampos.Margin = New Padding(0)
        listaCampos.ColumnCount = 1
        listaCampos.RowCount = 2
        listaCampos.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        listaCampos.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        listaCampos.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        listaCampos.Controls.Add(camposCuenta, 0, 0)
        listaCampos.Controls.Add(camposAcceso, 0, 1)
        '
        ' cuerpoEditor
        '
        cuerpoEditor.Controls.Add(listaCampos)
        '
        ' camposCuenta
        '
        camposCuenta.Name = "camposCuenta"
        camposCuenta.Dock = DockStyle.Top
        camposCuenta.AutoSize = True
        camposCuenta.AutoSizeMode = AutoSizeMode.GrowAndShrink
        camposCuenta.Margin = New Padding(0)
        camposCuenta.ColumnCount = 2
        camposCuenta.RowCount = 5
        camposCuenta.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        camposCuenta.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        camposCuenta.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        camposCuenta.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        camposCuenta.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        camposCuenta.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        camposCuenta.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        '
        ' camposAcceso
        '
        camposAcceso.Name = "camposAcceso"
        camposAcceso.Dock = DockStyle.Top
        camposAcceso.AutoSize = True
        camposAcceso.AutoSizeMode = AutoSizeMode.GrowAndShrink
        camposAcceso.Margin = New Padding(0)
        camposAcceso.ColumnCount = 2
        camposAcceso.RowCount = 2
        camposAcceso.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        camposAcceso.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        camposAcceso.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        camposAcceso.RowStyles.Add(New RowStyle(SizeType.Absolute, 64.0F))
        '
        ' bloque_txtNombre
        '
        bloque_txtNombre.Name = "bloque_txtNombre"
        bloque_txtNombre.Dock = DockStyle.Fill
        bloque_txtNombre.Margin = New Padding(0, 0, 14, 0)
        bloque_txtNombre.Size = New Size(360, 64)
        bloque_txtNombre.TabIndex = 0
        bloque_txtNombre.Controls.Add(txtNombre)
        bloque_txtNombre.Controls.Add(etiqueta_txtNombre)
        '
        ' etiqueta_txtNombre
        '
        etiqueta_txtNombre.Name = "etiqueta_txtNombre"
        etiqueta_txtNombre.Text = "Nombres"
        etiqueta_txtNombre.Dock = DockStyle.Top
        etiqueta_txtNombre.Height = 24
        etiqueta_txtNombre.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_txtNombre.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' txtNombre
        '
        txtNombre.Name = "txtNombre"
        txtNombre.Dock = DockStyle.Top
        txtNombre.TabIndex = 0
        txtNombre.MaxLength = 100
        '
        ' camposCuenta
        '
        camposCuenta.Controls.Add(bloque_txtNombre, 0, 0)
        '
        ' bloque_txtPaterno
        '
        bloque_txtPaterno.Name = "bloque_txtPaterno"
        bloque_txtPaterno.Dock = DockStyle.Fill
        bloque_txtPaterno.Margin = New Padding(0, 0, 14, 0)
        bloque_txtPaterno.Size = New Size(360, 64)
        bloque_txtPaterno.TabIndex = 1
        bloque_txtPaterno.Controls.Add(txtPaterno)
        bloque_txtPaterno.Controls.Add(etiqueta_txtPaterno)
        '
        ' etiqueta_txtPaterno
        '
        etiqueta_txtPaterno.Name = "etiqueta_txtPaterno"
        etiqueta_txtPaterno.Text = "Apellido paterno"
        etiqueta_txtPaterno.Dock = DockStyle.Top
        etiqueta_txtPaterno.Height = 24
        etiqueta_txtPaterno.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_txtPaterno.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' txtPaterno
        '
        txtPaterno.Name = "txtPaterno"
        txtPaterno.Dock = DockStyle.Top
        txtPaterno.TabIndex = 0
        txtPaterno.MaxLength = 100
        '
        ' camposCuenta
        '
        camposCuenta.Controls.Add(bloque_txtPaterno, 1, 0)
        '
        ' bloque_txtMaterno
        '
        bloque_txtMaterno.Name = "bloque_txtMaterno"
        bloque_txtMaterno.Dock = DockStyle.Fill
        bloque_txtMaterno.Margin = New Padding(0, 0, 14, 0)
        bloque_txtMaterno.Size = New Size(360, 64)
        bloque_txtMaterno.TabIndex = 2
        bloque_txtMaterno.Controls.Add(txtMaterno)
        bloque_txtMaterno.Controls.Add(etiqueta_txtMaterno)
        '
        ' etiqueta_txtMaterno
        '
        etiqueta_txtMaterno.Name = "etiqueta_txtMaterno"
        etiqueta_txtMaterno.Text = "Apellido materno"
        etiqueta_txtMaterno.Dock = DockStyle.Top
        etiqueta_txtMaterno.Height = 24
        etiqueta_txtMaterno.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_txtMaterno.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' txtMaterno
        '
        txtMaterno.Name = "txtMaterno"
        txtMaterno.Dock = DockStyle.Top
        txtMaterno.TabIndex = 0
        txtMaterno.MaxLength = 100
        '
        ' camposCuenta
        '
        camposCuenta.Controls.Add(bloque_txtMaterno, 0, 1)
        '
        ' bloque_txtCorreo
        '
        bloque_txtCorreo.Name = "bloque_txtCorreo"
        bloque_txtCorreo.Dock = DockStyle.Fill
        bloque_txtCorreo.Margin = New Padding(0, 0, 14, 0)
        bloque_txtCorreo.Size = New Size(360, 64)
        bloque_txtCorreo.TabIndex = 3
        bloque_txtCorreo.Controls.Add(txtCorreo)
        bloque_txtCorreo.Controls.Add(etiqueta_txtCorreo)
        '
        ' etiqueta_txtCorreo
        '
        etiqueta_txtCorreo.Name = "etiqueta_txtCorreo"
        etiqueta_txtCorreo.Text = "Correo electrónico"
        etiqueta_txtCorreo.Dock = DockStyle.Top
        etiqueta_txtCorreo.Height = 24
        etiqueta_txtCorreo.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_txtCorreo.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' txtCorreo
        '
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Dock = DockStyle.Top
        txtCorreo.TabIndex = 0
        txtCorreo.MaxLength = 100
        '
        ' camposCuenta
        '
        camposCuenta.Controls.Add(bloque_txtCorreo, 1, 1)
        '
        ' bloque_txtDni
        '
        bloque_txtDni.Name = "bloque_txtDni"
        bloque_txtDni.Dock = DockStyle.Fill
        bloque_txtDni.Margin = New Padding(0, 0, 14, 0)
        bloque_txtDni.Size = New Size(360, 64)
        bloque_txtDni.TabIndex = 4
        bloque_txtDni.Controls.Add(txtDni)
        bloque_txtDni.Controls.Add(etiqueta_txtDni)
        '
        ' etiqueta_txtDni
        '
        etiqueta_txtDni.Name = "etiqueta_txtDni"
        etiqueta_txtDni.Text = "DNI"
        etiqueta_txtDni.Dock = DockStyle.Top
        etiqueta_txtDni.Height = 24
        etiqueta_txtDni.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_txtDni.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' txtDni
        '
        txtDni.Name = "txtDni"
        txtDni.Dock = DockStyle.Top
        txtDni.TabIndex = 0
        txtDni.MaxLength = 8
        '
        ' camposCuenta
        '
        camposCuenta.Controls.Add(bloque_txtDni, 0, 2)
        '
        ' bloque_dtNacimiento
        '
        bloque_dtNacimiento.Name = "bloque_dtNacimiento"
        bloque_dtNacimiento.Dock = DockStyle.Fill
        bloque_dtNacimiento.Margin = New Padding(0, 0, 14, 0)
        bloque_dtNacimiento.Size = New Size(360, 64)
        bloque_dtNacimiento.TabIndex = 5
        bloque_dtNacimiento.Controls.Add(dtNacimiento)
        bloque_dtNacimiento.Controls.Add(etiqueta_dtNacimiento)
        '
        ' etiqueta_dtNacimiento
        '
        etiqueta_dtNacimiento.Name = "etiqueta_dtNacimiento"
        etiqueta_dtNacimiento.Text = "Nacimiento (marca la casilla si lo registras)"
        etiqueta_dtNacimiento.Dock = DockStyle.Top
        etiqueta_dtNacimiento.Height = 24
        etiqueta_dtNacimiento.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_dtNacimiento.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' dtNacimiento
        '
        dtNacimiento.Name = "dtNacimiento"
        dtNacimiento.Dock = DockStyle.Top
        dtNacimiento.TabIndex = 0
        dtNacimiento.Format = DateTimePickerFormat.Short
        dtNacimiento.ShowCheckBox = True
        dtNacimiento.Checked = False
        '
        ' camposCuenta
        '
        camposCuenta.Controls.Add(bloque_dtNacimiento, 1, 2)
        '
        ' bloque_cboGenero
        '
        bloque_cboGenero.Name = "bloque_cboGenero"
        bloque_cboGenero.Dock = DockStyle.Fill
        bloque_cboGenero.Margin = New Padding(0, 0, 14, 0)
        bloque_cboGenero.Size = New Size(360, 64)
        bloque_cboGenero.TabIndex = 6
        bloque_cboGenero.Controls.Add(cboGenero)
        bloque_cboGenero.Controls.Add(etiqueta_cboGenero)
        '
        ' etiqueta_cboGenero
        '
        etiqueta_cboGenero.Name = "etiqueta_cboGenero"
        etiqueta_cboGenero.Text = "Género"
        etiqueta_cboGenero.Dock = DockStyle.Top
        etiqueta_cboGenero.Height = 24
        etiqueta_cboGenero.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_cboGenero.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' cboGenero
        '
        cboGenero.Name = "cboGenero"
        cboGenero.Dock = DockStyle.Top
        cboGenero.TabIndex = 0
        cboGenero.DropDownStyle = ComboBoxStyle.DropDownList
        cboGenero.Items.AddRange(New Object() {"Sin especificar", "Femenino", "Masculino"})
        '
        ' camposCuenta
        '
        camposCuenta.Controls.Add(bloque_cboGenero, 0, 3)
        '
        ' bloque_cboRol
        '
        bloque_cboRol.Name = "bloque_cboRol"
        bloque_cboRol.Dock = DockStyle.Fill
        bloque_cboRol.Margin = New Padding(0, 0, 14, 0)
        bloque_cboRol.Size = New Size(360, 64)
        bloque_cboRol.TabIndex = 7
        bloque_cboRol.Controls.Add(cboRol)
        bloque_cboRol.Controls.Add(etiqueta_cboRol)
        '
        ' etiqueta_cboRol
        '
        etiqueta_cboRol.Name = "etiqueta_cboRol"
        etiqueta_cboRol.Text = "Rol"
        etiqueta_cboRol.Dock = DockStyle.Top
        etiqueta_cboRol.Height = 24
        etiqueta_cboRol.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_cboRol.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' cboRol
        '
        cboRol.Name = "cboRol"
        cboRol.Dock = DockStyle.Top
        cboRol.TabIndex = 0
        cboRol.DropDownStyle = ComboBoxStyle.DropDownList
        '
        ' camposCuenta
        '
        camposCuenta.Controls.Add(bloque_cboRol, 1, 3)
        '
        ' bloque_cboEstado
        '
        bloque_cboEstado.Name = "bloque_cboEstado"
        bloque_cboEstado.Dock = DockStyle.Fill
        bloque_cboEstado.Margin = New Padding(0, 0, 14, 0)
        bloque_cboEstado.Size = New Size(360, 64)
        bloque_cboEstado.TabIndex = 8
        bloque_cboEstado.Controls.Add(cboEstado)
        bloque_cboEstado.Controls.Add(etiqueta_cboEstado)
        '
        ' etiqueta_cboEstado
        '
        etiqueta_cboEstado.Name = "etiqueta_cboEstado"
        etiqueta_cboEstado.Text = "Estado"
        etiqueta_cboEstado.Dock = DockStyle.Top
        etiqueta_cboEstado.Height = 24
        etiqueta_cboEstado.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_cboEstado.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' cboEstado
        '
        cboEstado.Name = "cboEstado"
        cboEstado.Dock = DockStyle.Top
        cboEstado.TabIndex = 0
        cboEstado.DropDownStyle = ComboBoxStyle.DropDownList
        cboEstado.Items.AddRange(New Object() {"Activo", "Inactivo"})
        '
        ' camposCuenta
        '
        camposCuenta.Controls.Add(bloque_cboEstado, 0, 4)
        '
        ' bloque_txtClave
        '
        bloque_txtClave.Name = "bloque_txtClave"
        bloque_txtClave.Dock = DockStyle.Fill
        bloque_txtClave.Margin = New Padding(0, 0, 14, 0)
        bloque_txtClave.Size = New Size(360, 64)
        bloque_txtClave.TabIndex = 0
        bloque_txtClave.Controls.Add(txtClave)
        bloque_txtClave.Controls.Add(etiqueta_txtClave)
        '
        ' etiqueta_txtClave
        '
        etiqueta_txtClave.Name = "etiqueta_txtClave"
        etiqueta_txtClave.Text = "Contraseña (8 caracteres, mayúscula y número)"
        etiqueta_txtClave.Dock = DockStyle.Top
        etiqueta_txtClave.Height = 24
        etiqueta_txtClave.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_txtClave.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' txtClave
        '
        txtClave.Name = "txtClave"
        txtClave.Dock = DockStyle.Top
        txtClave.TabIndex = 0
        txtClave.MaxLength = 128
        txtClave.UseSystemPasswordChar = True
        '
        ' camposAcceso
        '
        camposAcceso.Controls.Add(bloque_txtClave, 0, 0)
        '
        ' bloque_txtConfirmar
        '
        bloque_txtConfirmar.Name = "bloque_txtConfirmar"
        bloque_txtConfirmar.Dock = DockStyle.Fill
        bloque_txtConfirmar.Margin = New Padding(0, 0, 14, 0)
        bloque_txtConfirmar.Size = New Size(360, 64)
        bloque_txtConfirmar.TabIndex = 1
        bloque_txtConfirmar.Controls.Add(txtConfirmar)
        bloque_txtConfirmar.Controls.Add(etiqueta_txtConfirmar)
        '
        ' etiqueta_txtConfirmar
        '
        etiqueta_txtConfirmar.Name = "etiqueta_txtConfirmar"
        etiqueta_txtConfirmar.Text = "Confirmar contraseña"
        etiqueta_txtConfirmar.Dock = DockStyle.Top
        etiqueta_txtConfirmar.Height = 24
        etiqueta_txtConfirmar.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_txtConfirmar.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' txtConfirmar
        '
        txtConfirmar.Name = "txtConfirmar"
        txtConfirmar.Dock = DockStyle.Top
        txtConfirmar.TabIndex = 0
        txtConfirmar.MaxLength = 128
        txtConfirmar.UseSystemPasswordChar = True
        '
        ' camposAcceso
        '
        camposAcceso.Controls.Add(bloque_txtConfirmar, 1, 0)
        '
        ' bloque_txtPregunta
        '
        bloque_txtPregunta.Name = "bloque_txtPregunta"
        bloque_txtPregunta.Dock = DockStyle.Fill
        bloque_txtPregunta.Margin = New Padding(0, 0, 14, 0)
        bloque_txtPregunta.Size = New Size(360, 64)
        bloque_txtPregunta.TabIndex = 2
        bloque_txtPregunta.Controls.Add(txtPregunta)
        bloque_txtPregunta.Controls.Add(etiqueta_txtPregunta)
        '
        ' etiqueta_txtPregunta
        '
        etiqueta_txtPregunta.Name = "etiqueta_txtPregunta"
        etiqueta_txtPregunta.Text = "Pregunta de seguridad"
        etiqueta_txtPregunta.Dock = DockStyle.Top
        etiqueta_txtPregunta.Height = 24
        etiqueta_txtPregunta.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_txtPregunta.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' txtPregunta
        '
        txtPregunta.Name = "txtPregunta"
        txtPregunta.Dock = DockStyle.Top
        txtPregunta.TabIndex = 0
        txtPregunta.MaxLength = 255
        txtPregunta.UseSystemPasswordChar = False
        '
        ' camposAcceso
        '
        camposAcceso.Controls.Add(bloque_txtPregunta, 0, 1)
        '
        ' bloque_txtRespuesta
        '
        bloque_txtRespuesta.Name = "bloque_txtRespuesta"
        bloque_txtRespuesta.Dock = DockStyle.Fill
        bloque_txtRespuesta.Margin = New Padding(0, 0, 14, 0)
        bloque_txtRespuesta.Size = New Size(360, 64)
        bloque_txtRespuesta.TabIndex = 3
        bloque_txtRespuesta.Controls.Add(txtRespuesta)
        bloque_txtRespuesta.Controls.Add(etiqueta_txtRespuesta)
        '
        ' etiqueta_txtRespuesta
        '
        etiqueta_txtRespuesta.Name = "etiqueta_txtRespuesta"
        etiqueta_txtRespuesta.Text = "Respuesta de seguridad"
        etiqueta_txtRespuesta.Dock = DockStyle.Top
        etiqueta_txtRespuesta.Height = 24
        etiqueta_txtRespuesta.Font = New Font("Segoe UI Semibold", 9.0F)
        etiqueta_txtRespuesta.ForeColor = Color.FromArgb(47, 72, 92)
        '
        ' txtRespuesta
        '
        txtRespuesta.Name = "txtRespuesta"
        txtRespuesta.Dock = DockStyle.Top
        txtRespuesta.TabIndex = 0
        txtRespuesta.MaxLength = 200
        txtRespuesta.UseSystemPasswordChar = True
        '
        ' camposAcceso
        '
        camposAcceso.Controls.Add(bloque_txtRespuesta, 1, 1)
        layoutEditor.ResumeLayout(False)
        layoutEditor.PerformLayout()
        encabezado.ResumeLayout(False)
        encabezado.PerformLayout()
        cuerpoEditor.ResumeLayout(False)
        cuerpoEditor.PerformLayout()
        accionesEditor.ResumeLayout(False)
        accionesEditor.PerformLayout()
        listaCampos.ResumeLayout(False)
        listaCampos.PerformLayout()
        camposCuenta.ResumeLayout(False)
        camposCuenta.PerformLayout()
        camposAcceso.ResumeLayout(False)
        camposAcceso.PerformLayout()
        bloque_txtNombre.ResumeLayout(False)
        bloque_txtNombre.PerformLayout()
        bloque_txtPaterno.ResumeLayout(False)
        bloque_txtPaterno.PerformLayout()
        bloque_txtMaterno.ResumeLayout(False)
        bloque_txtMaterno.PerformLayout()
        bloque_txtCorreo.ResumeLayout(False)
        bloque_txtCorreo.PerformLayout()
        bloque_txtDni.ResumeLayout(False)
        bloque_txtDni.PerformLayout()
        bloque_dtNacimiento.ResumeLayout(False)
        bloque_dtNacimiento.PerformLayout()
        bloque_cboGenero.ResumeLayout(False)
        bloque_cboGenero.PerformLayout()
        bloque_cboRol.ResumeLayout(False)
        bloque_cboRol.PerformLayout()
        bloque_cboEstado.ResumeLayout(False)
        bloque_cboEstado.PerformLayout()
        bloque_txtClave.ResumeLayout(False)
        bloque_txtClave.PerformLayout()
        bloque_txtConfirmar.ResumeLayout(False)
        bloque_txtConfirmar.PerformLayout()
        bloque_txtPregunta.ResumeLayout(False)
        bloque_txtPregunta.PerformLayout()
        bloque_txtRespuesta.ResumeLayout(False)
        bloque_txtRespuesta.PerformLayout()

        ResumeLayout(False)
    End Sub

    Friend WithEvents layoutEditor As TableLayoutPanel
    Friend WithEvents encabezado As Panel
    Friend WithEvents lblTituloVista As Label
    Friend WithEvents lblDescripcionVista As Label
    Friend WithEvents cuerpoEditor As Panel
    Friend WithEvents accionesEditor As FlowLayoutPanel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents listaCampos As TableLayoutPanel
    Friend WithEvents camposCuenta As TableLayoutPanel
    Friend WithEvents camposAcceso As TableLayoutPanel
    Friend WithEvents bloque_txtNombre As Panel
    Friend WithEvents etiqueta_txtNombre As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents bloque_txtPaterno As Panel
    Friend WithEvents etiqueta_txtPaterno As Label
    Friend WithEvents txtPaterno As TextBox
    Friend WithEvents bloque_txtMaterno As Panel
    Friend WithEvents etiqueta_txtMaterno As Label
    Friend WithEvents txtMaterno As TextBox
    Friend WithEvents bloque_txtCorreo As Panel
    Friend WithEvents etiqueta_txtCorreo As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents bloque_txtDni As Panel
    Friend WithEvents etiqueta_txtDni As Label
    Friend WithEvents txtDni As TextBox
    Friend WithEvents bloque_dtNacimiento As Panel
    Friend WithEvents etiqueta_dtNacimiento As Label
    Friend WithEvents dtNacimiento As DateTimePicker
    Friend WithEvents bloque_cboGenero As Panel
    Friend WithEvents etiqueta_cboGenero As Label
    Friend WithEvents cboGenero As ComboBox
    Friend WithEvents bloque_cboRol As Panel
    Friend WithEvents etiqueta_cboRol As Label
    Friend WithEvents cboRol As ComboBox
    Friend WithEvents bloque_cboEstado As Panel
    Friend WithEvents etiqueta_cboEstado As Label
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents bloque_txtClave As Panel
    Friend WithEvents etiqueta_txtClave As Label
    Friend WithEvents txtClave As TextBox
    Friend WithEvents bloque_txtConfirmar As Panel
    Friend WithEvents etiqueta_txtConfirmar As Label
    Friend WithEvents txtConfirmar As TextBox
    Friend WithEvents bloque_txtPregunta As Panel
    Friend WithEvents etiqueta_txtPregunta As Label
    Friend WithEvents txtPregunta As TextBox
    Friend WithEvents bloque_txtRespuesta As Panel
    Friend WithEvents etiqueta_txtRespuesta As Label
    Friend WithEvents txtRespuesta As TextBox
End Class
