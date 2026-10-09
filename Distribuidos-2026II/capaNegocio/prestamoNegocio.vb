Imports capaDatos

Public Class prestamoNegocio
    Private ReadOnly dao As New prestamoDAO()

    Public Function buscarLectores(texto As String) As List(Of Usuario)
        Return dao.buscarLectores(If(texto, "").Trim())
    End Function

    Public Function listarPorLector(idLector As Integer) As List(Of Prestamo)
        If idLector <= 0 Then Throw New ArgumentException("Selecciona un lector.")
        Return dao.listar("Todos", "", Date.Today, idLector)
    End Function

    Public Function listar(Optional filtro As String = "Todos", Optional texto As String = "") As List(Of Prestamo)
        Dim estados = {"Todos", "Activos", "Vencidos", "Devueltos"}
        If Not estados.Contains(filtro) Then Throw New ArgumentException("El filtro de préstamos no es válido.")
        Return dao.listar(filtro, If(texto, "").Trim(), Date.Today)
    End Function

    Public Function registrar(idLector As Integer, idBibliotecario As Integer, idEjemplar As Integer,
                              fechaInicio As Date, fechaFin As Date) As Integer
        If idLector <= 0 Then Throw New ArgumentException("Selecciona un lector.")
        If idBibliotecario <= 0 Then Throw New ArgumentException("La sesión no identifica al bibliotecario.")
        If idEjemplar <= 0 Then Throw New ArgumentException("Selecciona un ejemplar disponible.")
        ValidarFechasPrestamo(fechaInicio, fechaFin, Date.Today)
        Return dao.registrar(idLector, idBibliotecario, idEjemplar, fechaInicio.Date, fechaFin.Date)
    End Function

    Public Function devolver(idPrestamo As Integer, idBibliotecario As Integer, fechaRetorno As Date) As Integer
        If idPrestamo <= 0 Then Throw New ArgumentException("Selecciona un préstamo.")
        If idBibliotecario <= 0 Then Throw New ArgumentException("La sesión no identifica al bibliotecario.")
        If fechaRetorno.Date > Date.Today Then Throw New ArgumentException("La devolución no puede tener una fecha futura.")
        Return dao.devolver(idPrestamo, idBibliotecario, fechaRetorno.Date)
    End Function

    Public Shared Sub ValidarFechasPrestamo(inicio As Date, limite As Date, hoy As Date)
        If inicio.Date > hoy.Date Then Throw New ArgumentException("El inicio no puede tener una fecha futura.")
        If limite.Date <= inicio.Date Then Throw New ArgumentException("La fecha límite debe ser posterior al inicio.")
    End Sub

    Public Shared Function CalcularDiasRetraso(inicio As Date, limite As Date, retorno As Date, hoy As Date) As Integer
        If retorno.Date < inicio.Date Then Throw New ArgumentException("La devolución no puede ser anterior al inicio.")
        If retorno.Date > hoy.Date Then Throw New ArgumentException("La devolución no puede tener una fecha futura.")
        Return Math.Max(0, (retorno.Date - limite.Date).Days)
    End Function
End Class
