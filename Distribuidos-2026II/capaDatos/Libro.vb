Public Class Libro
    Public Property IdLibro As Integer
    Public Property TituloLibro As String
    Public Property EditorialLibro As String
    Public Property AnoPublicacion As Integer?
    Public Property StockTotal As Integer
    Public Property EstadoLibro As Boolean
    Public Property PublicoLibro As String

    ' Propiedades auxiliares para guardar datos traídos desde Autor y Categoria (INNER JOIN)
    Public Property Autor As String
    Public Property Categoria As String
    Public Property NombreAutor As String
    Public Property NombreCategoria As String

    ' Propiedad de solo lectura para mostrar el título y el autor en la pantalla de forma limpia
    Public ReadOnly Property DescripcionCompleta As String
        Get
            Return $"{TituloLibro} - {NombreAutor}".Trim()
        End Get
    End Property
End Class