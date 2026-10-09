Imports capaDatos

Public Class prestamoNegocio
    Private ReadOnly dao As New prestamoDAO()
    Private ReadOnly reglas As IReglasCirculacion = New reglasCirculacionNegocio()

    Public Function buscarLectores(texto As String) As List(Of Usuario)
        seguridadNegocio.ExigirPersonal()
        Return dao.buscarLectores(If(texto, "").Trim())
    End Function

    Public Function listarPorLector(idLector As Integer) As List(Of Prestamo)
        seguridadNegocio.ExigirAccesoLector(idLector)
        Return PrepararConsulta(dao.listar("Todos", "", Date.Today, idLector))
    End Function

    Public Function listar(Optional filtro As String = "Todos", Optional texto As String = "") As List(Of Prestamo)
        seguridadNegocio.ExigirPersonal()
        Dim estados = {"Todos", "Activos", "Vencidos", "Devueltos"}
        If Not estados.Contains(filtro) Then Throw New ArgumentException("El filtro de préstamos no es válido.")
        Return PrepararConsulta(dao.listar(filtro, If(texto, "").Trim(), Date.Today))
    End Function

    Public Function registrar(idLector As Integer, idBibliotecario As Integer, idEjemplar As Integer,
                              fechaInicio As Date, fechaFin As Date) As Integer
        seguridadNegocio.ExigirAccesoLector(idLector)
        seguridadNegocio.ExigirOperador(idBibliotecario)
        If idEjemplar <= 0 Then Throw New ArgumentException("Selecciona un ejemplar disponible.")
        ValidarFechasPrestamo(fechaInicio, fechaFin, Date.Today)
        Return dao.registrar(idLector, idBibliotecario, idEjemplar, fechaInicio.Date, fechaFin.Date, reglas)
    End Function

    Public Function registrar(idLector As Integer, idBibliotecario As Integer, idEjemplar As Integer, fechaInicio As Date) As Integer
        Return registrar(idLector, idBibliotecario, idEjemplar, fechaInicio, PoliticaPrestamo.FechaLimite(fechaInicio))
    End Function

    Public Function devolver(idPrestamo As Integer, idBibliotecario As Integer, fechaRetorno As Date) As Integer
        If idPrestamo <= 0 Then Throw New ArgumentException("Selecciona un préstamo.")
        seguridadNegocio.ExigirOperador(idBibliotecario)
        If fechaRetorno.Date > Date.Today Then Throw New ArgumentException("La devolución no puede tener una fecha futura.")
        Dim calculo = dao.PrevisualizarDevolucion(idPrestamo, fechaRetorno.Date, reglas)
        Return dao.DevolverConfirmado(idPrestamo, idBibliotecario, fechaRetorno.Date, calculo, reglas).DiasRetraso
    End Function

    Public Function PrevisualizarDevolucion(idPrestamo As Integer,fechaRetorno As Date) As DevolucionCalculada
        seguridadNegocio.ExigirPersonal()
        If idPrestamo<=0 Then Throw New ArgumentException("Selecciona un préstamo.")
        Return dao.PrevisualizarDevolucion(idPrestamo,fechaRetorno.Date, reglas)
    End Function

    Public Function DevolverConfirmado(calculo As DevolucionCalculada) As DevolucionCalculada
        seguridadNegocio.ExigirOperador(SesionUsuario.IdUsuario)
        If calculo Is Nothing Then Throw New ArgumentException("Actualiza el cálculo de devolución.")
        Return dao.DevolverConfirmado(calculo.IdPrestamo,SesionUsuario.IdUsuario,calculo.FechaRetorno,calculo, reglas)
    End Function

    Private Shared Function PrepararConsulta(prestamos As List(Of Prestamo)) As List(Of Prestamo)
        For Each prestamo In prestamos
            prestamo.EstaActivo = PuedeDevolver(prestamo)
        Next
        Return prestamos
    End Function

    Public Shared Function PuedeDevolver(prestamo As Prestamo) As Boolean
        Return prestamo IsNot Nothing AndAlso Not prestamo.FechaRetorno.HasValue AndAlso
            String.Equals(If(prestamo.EstadoPrestamo, "").Trim(), Prestamo.EstadoActivo, StringComparison.OrdinalIgnoreCase)
    End Function

    Public Shared Function EstaVencido(prestamo As Prestamo, hoy As Date) As Boolean
        Return PuedeDevolver(prestamo) AndAlso prestamo.FechaFin.Date < hoy.Date
    End Function

    Public Shared Function FiltrarConsulta(prestamos As IEnumerable(Of Prestamo), filtro As String, texto As String,
                                           idLector As Integer, idPrestamo As Integer, hoy As Date) As List(Of Prestamo)
        Return prestamos.Where(Function(p)
                                   If idLector > 0 AndAlso p.IdUsuario <> idLector Then Return False
                                   If idPrestamo > 0 AndAlso p.IdPrestamo <> idPrestamo Then Return False
                                   Select Case filtro
                                       Case "Activos"
                                           If Not PuedeDevolver(p) Then Return False
                                       Case "Vencidos"
                                           If Not EstaVencido(p, hoy) Then Return False
                                       Case "Devueltos"
                                           If Not p.FechaRetorno.HasValue OrElse Not String.Equals(If(p.EstadoPrestamo, "").Trim(), Prestamo.EstadoDevuelto, StringComparison.OrdinalIgnoreCase) Then Return False
                                   End Select
                                   Dim contenido = $"{p.IdPrestamo} {p.NombreLector} {p.DniLector} {p.CorreoLector} {p.IdEjemplar} {p.TituloLibro}"
                                   Return contenido.IndexOf(If(texto, ""), StringComparison.OrdinalIgnoreCase) >= 0
                               End Function).ToList()
    End Function

    Public Shared Function EstadoParaMostrar(prestamo As Prestamo, hoy As Date) As String
        Return If(EstaVencido(prestamo, hoy), "Vencido", prestamo.EstadoPrestamo)
    End Function

    Public Shared Function FechaLimite(inicio As Date) As Date
        Return PoliticaPrestamo.FechaLimite(inicio)
    End Function

    Public Shared Sub ValidarFechasPrestamo(inicio As Date, limite As Date, hoy As Date)
        If inicio.Date > hoy.Date Then Throw New ArgumentException("El inicio no puede tener una fecha futura.")
        If limite.Date <= inicio.Date Then Throw New ArgumentException("La fecha límite debe ser posterior al inicio.")
        If limite.Date <> PoliticaPrestamo.FechaLimite(inicio) Then Throw New ArgumentException("El préstamo debe durar exactamente cinco días después de la fecha de inicio.")
    End Sub

    Public Shared Function CalcularDiasRetraso(inicio As Date, limite As Date, retorno As Date, hoy As Date) As Integer
        If retorno.Date < inicio.Date Then Throw New ArgumentException("La devolución no puede ser anterior al inicio.")
        If retorno.Date > hoy.Date Then Throw New ArgumentException("La devolución no puede tener una fecha futura.")
        Return Math.Max(0, (retorno.Date - limite.Date).Days)
    End Function
End Class
