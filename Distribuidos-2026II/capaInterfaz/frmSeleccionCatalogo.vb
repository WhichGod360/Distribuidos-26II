Imports Utiles

Public Class frmSeleccionCatalogo


    Public ReadOnly Property NombreSeleccionado As String
        Get
            Return Convert.ToString(opciones.SelectedItem)
        End Get
    End Property

    Public Sub New()
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
    End Sub
End Class
