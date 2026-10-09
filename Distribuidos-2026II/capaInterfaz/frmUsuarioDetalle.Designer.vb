<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUsuarioDetalle
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        txtNombre = New TextBox With {.Name = "txtNombre", .MaxLength = 100}
        txtPaterno = New TextBox With {.Name = "txtPaterno", .MaxLength = 100}
        txtMaterno = New TextBox With {.Name = "txtMaterno", .MaxLength = 100}
        txtCorreo = New TextBox With {.Name = "txtCorreo", .MaxLength = 100}
        txtDni = New TextBox With {.Name = "txtDni", .MaxLength = 8}
        dtNacimiento = New DateTimePicker With {.Name = "dtNacimiento", .Format = DateTimePickerFormat.Short,
            .ShowCheckBox = True, .MaxDate = Date.Today, .Value = Date.Today, .Checked = False}
        cboGenero = New ComboBox With {.Name = "cboGenero", .DropDownStyle = ComboBoxStyle.DropDownList}
        cboGenero.Items.AddRange({"Sin especificar", "Femenino", "Masculino"})
        cboRol = New ComboBox With {.Name = "cboRol", .DropDownStyle = ComboBoxStyle.DropDownList}
        cboEstado = New ComboBox With {.Name = "cboEstado", .DropDownStyle = ComboBoxStyle.DropDownList}
        cboEstado.Items.AddRange({"Activo", "Inactivo"})
        txtClave = New TextBox With {.Name = "txtClave", .UseSystemPasswordChar = True, .MaxLength = 128}
        txtConfirmar = New TextBox With {.Name = "txtConfirmar", .UseSystemPasswordChar = True, .MaxLength = 128}
        txtPregunta = New TextBox With {.Name = "txtPregunta", .MaxLength = 255}
        txtRespuesta = New TextBox With {.Name = "txtRespuesta", .UseSystemPasswordChar = True, .MaxLength = 200}
        btnGuardar = New Button With {.Name = "btnGuardar", .Text = "Guardar"}
        btnCancelar = New Button With {.Name = "btnCancelar", .Text = "Cancelar", .DialogResult = DialogResult.Cancel}
        Dim campos As New List(Of Utiles.CampoMantenimiento) From {
            New Utiles.CampoMantenimiento("Nombres", txtNombre),
            New Utiles.CampoMantenimiento("Apellido paterno", txtPaterno),
            New Utiles.CampoMantenimiento("Apellido materno", txtMaterno),
            New Utiles.CampoMantenimiento("Correo electrónico", txtCorreo),
            New Utiles.CampoMantenimiento("DNI", txtDni),
            New Utiles.CampoMantenimiento("Nacimiento (marca la casilla si lo registras)", dtNacimiento),
            New Utiles.CampoMantenimiento("Género", cboGenero),
            New Utiles.CampoMantenimiento("Rol", cboRol),
            New Utiles.CampoMantenimiento("Estado", cboEstado)}
        If idUsuario = 0 Then
            campos.AddRange({New Utiles.CampoMantenimiento("Contraseña (8 caracteres, mayúscula y número)", txtClave),
                New Utiles.CampoMantenimiento("Confirmar contraseña", txtConfirmar),
                New Utiles.CampoMantenimiento("Pregunta de seguridad", txtPregunta),
                New Utiles.CampoMantenimiento("Respuesta de seguridad", txtRespuesta)})
        End If
        Utiles.MantenimientoUI.ConfigurarDialogo(Me, If(idUsuario = 0, "Agregar usuario", "Editar usuario"),
            "Completa los datos de la cuenta y selecciona sus permisos.", btnGuardar, btnCancelar, campos.ToArray())
    End Sub

    Friend txtNombre, txtPaterno, txtMaterno, txtCorreo, txtDni, txtClave, txtConfirmar, txtPregunta, txtRespuesta As TextBox
    Friend dtNacimiento As DateTimePicker
    Friend cboGenero, cboRol, cboEstado As ComboBox
    Friend WithEvents btnGuardar, btnCancelar As Button
End Class
