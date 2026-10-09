Public Class SolicitudPrestamo
    Public Property IdSolicitud As Integer
    Public Property IdUsuario As Integer
    Public Property NombreLector As String
    Public Property DniLector As String
    Public Property FechaSolicitud As Date
    Public Property FechaLimiteRetiro As Date
    Public Property EstadoSolicitud As String
    Public Property EstadoActual As String
    Public Property FechaCierre As Date?
    Public Property FechaAprobacion As Date?
    Public Property IdAprobador As Integer?
    Public Property NombreAprobador As String
    Public Property Detalles As New List(Of DetalleSolicitudPrestamo)()

    Public ReadOnly Property Libros As String
        Get
            Return String.Join(", ", Detalles.Select(Function(d) d.TituloLibro))
        End Get
    End Property

    Public Property EstaVigente As Boolean

    Public ReadOnly Property LimiteLocal As Date
        Get
            Return TimeZoneInfo.ConvertTimeFromUtc(Date.SpecifyKind(FechaLimiteRetiro, DateTimeKind.Utc), TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"))
        End Get
    End Property
End Class
