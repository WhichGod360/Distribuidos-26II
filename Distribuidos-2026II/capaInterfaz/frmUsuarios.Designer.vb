<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUsuarios
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
        Me.Text = "Gestión de usuarios"
        Me.Size = New Size(1050, 680)
        txtBuscar = New TextBox With {.Name = "txtBuscar", .PlaceholderText = "Nombre, correo o DNI", .MaxLength = 100}
        cboRol = New ComboBox With {.Name = "cboRol", .DropDownStyle = ComboBoxStyle.DropDownList}
        cboEstado = New ComboBox With {.Name = "cboEstado", .DropDownStyle = ComboBoxStyle.DropDownList}
        cboEstado.Items.AddRange({"Todos", "Activo", "Inactivo"})
        btnAgregar = New Button With {.Name = "btnAgregar", .Text = "Agregar usuario"}
        btnEditar = New Button With {.Name = "btnEditar", .Text = "Editar", .Enabled = False}
        btnEstado = New Button With {.Name = "btnEstado", .Text = "Activar / desactivar", .Enabled = False}
        btnActualizar = New Button With {.Name = "btnActualizar", .Text = "Actualizar"}
        lblResumen = New Label With {.Name = "lblResumen"}
        tablaUsuarios = New DataGridView With {.Name = "tablaUsuarios", .AutoGenerateColumns = False}
        For Each campo In New String()() {
            New String() {"IdUsuario", "ID"}, New String() {"NombreCompleto", "Usuario"},
            New String() {"EmailUsuario", "Correo"}, New String() {"NumeroDniUsuario", "DNI"},
            New String() {"NombreRol", "Rol"}, New String() {"EstadoUsuario", "Estado"}}
            tablaUsuarios.Columns.Add(New DataGridViewTextBoxColumn With {.Name = campo(0), .DataPropertyName = campo(0), .HeaderText = campo(1)})
        Next
        tablaUsuarios.Columns("IdUsuario").FillWeight = 35
        tablaUsuarios.Columns("NombreCompleto").FillWeight = 170
        tablaUsuarios.Columns("EmailUsuario").FillWeight = 160
        Utiles.MantenimientoUI.ConfigurarListado(Me, "Usuarios", "Administra las cuentas y los permisos de la biblioteca.",
            tablaUsuarios, txtBuscar, {btnAgregar, btnEditar, btnEstado, btnActualizar}, lblResumen,
            {New Utiles.CampoMantenimiento("Rol", cboRol), New Utiles.CampoMantenimiento("Estado", cboEstado)})
    End Sub

    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents cboRol, cboEstado As ComboBox
    Friend WithEvents btnAgregar, btnEditar, btnEstado, btnActualizar As Button
    Friend WithEvents tablaUsuarios As DataGridView
    Friend lblResumen As Label
End Class
