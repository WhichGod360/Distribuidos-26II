Public Class DashboardResumen
    Public Property TotalPrestamos As Integer
    Public Property Activos As Integer
    Public Property Vencidos As Integer
    Public Property Devueltos As Integer
    Public Property PorRevisar As Integer
    Public Property LectoresAtendidos As Integer
    Public Property LibrosPrestados As Integer
    Public Property EjemplaresDisponibles As Integer
    Public Property DevolucionesHoy As Integer
    Public Property LectoresActivos As Integer
    Public Property LibrosHabilitados As Integer
    Public Property PorMes As New List(Of DatoGrafico)()
    Public Property PorCategoria As New List(Of DatoGrafico)()
    Public Property Pendientes As New List(Of PendienteDashboard)()
End Class

Public Class DatoGrafico
    Public Property Etiqueta As String
    Public Property Cantidad As Integer
End Class

Public Class PendienteDashboard
    Public Property IdPrestamo As Integer
    Public Property Lector As String
    Public Property Libro As String
    Public Property FechaLimite As Date
    Public Property Estado As String
End Class
