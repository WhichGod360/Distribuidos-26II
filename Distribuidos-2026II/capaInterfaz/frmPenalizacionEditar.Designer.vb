<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPenalizacionEditar
    Inherits Form
    Private components As System.ComponentModel.IContainer

    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub InitializeComponent()
        components=New System.ComponentModel.Container()
        tipo=New TextBox With {.Name="tipo",.MaxLength=30}
        monto=New NumericUpDown With {.Name="monto",.DecimalPlaces=2,.Maximum=99999.99D,.ThousandsSeparator=True}
        descripcion=New TextBox With {.Name="descripcion",.Multiline=True,.ScrollBars=ScrollBars.Vertical,.Height=80}
        activo=New CheckBox With {.Name="activo",.Text="Disponible para nuevos cargos",.Checked=True}
        esMora=New CheckBox With {.Name="esMora",.Text="Mora por retraso de devolución"}
        diasDesde=New NumericUpDown With {.Name="diasDesde",.Minimum=1,.Maximum=100000,.Value=1,.Enabled=False}
        guardar=New Button With {.Name="guardar",.Text="Guardar"}
        cancelar=New Button With {.Name="cancelar",.Text="Cancelar",.DialogResult=DialogResult.Cancel}
        Utiles.MantenimientoUI.ConfigurarDialogo(Me,"Penalización del catálogo",
            "El monto es fijo. En mora se usa el mayor tramo alcanzado; no se suman los tramos.",
            guardar,cancelar,
            New Utiles.CampoMantenimiento("Tipo",tipo),
            New Utiles.CampoMantenimiento("Importe fijo (S/)",monto),
            New Utiles.CampoMantenimiento("Clase de penalización",esMora),
            New Utiles.CampoMantenimiento("Aplicar desde estos días de retraso",diasDesde),
            New Utiles.CampoMantenimiento("Descripción",descripcion,80),
            New Utiles.CampoMantenimiento("Estado",activo))
    End Sub
    Friend tipo,descripcion As TextBox
    Friend monto,diasDesde As NumericUpDown
    Friend activo,esMora As CheckBox
    Friend WithEvents guardar,cancelar As Button
End Class
