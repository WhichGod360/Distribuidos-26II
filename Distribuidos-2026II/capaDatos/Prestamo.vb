Public Class Prestamo
    ' El script ejemplifica Devuelto; Activo conserva el valor del código existente.
    Public Const EstadoActivo As String = "Activo"
    Public Const EstadoDevuelto As String = "Devuelto"

    Public Property IdPrestamo As Integer
    Public Property FechaInicio As Date
    Public Property FechaFin As Date
    Public Property FechaRetorno As Date?
    Public Property EstadoPrestamo As String
    Public Property DiasRetraso As Integer
    Public Property IdUsuario As Integer
    Public Property IdBibliotecario As Integer
    Public Property IdEjemplar As Integer

    ' Datos de consulta; no agregan columnas a Prestamo.
    Public Property NombreLector As String
    Public Property DniLector As String
    Public Property CorreoLector As String
    Public Property NombreBibliotecario As String
    Public Property IdLibro As Integer
    Public Property TituloLibro As String

    ' Estado calculado por Negocio para mostrarlo en las consultas.
    Public Property EstaActivo As Boolean
End Class
