' Contratos y datos: DAO obtiene hechos bajo bloqueo; Negocio decide antes del COMMIT.
Public Interface IReglasCirculacion
    Sub ValidarUsuario(usuario As Usuario, rol As String, mensaje As String)
    Sub ValidarLector(datos As DatosLectorPrestamo, cantidadNueva As Integer)
    Sub ValidarLibro(estado As Boolean?)
    Sub ValidarEjemplar(estado As Boolean?, prestamosAbiertos As Integer)
    Sub ValidarVentanilla(solicitudesVigentes As Integer, capacidad As Integer)
    Sub ValidarNuevaSolicitud(solicitudesVigentes As Integer)
    Sub ValidarDisponibilidad(capacidad As Integer)
    Sub ValidarCoberturaReserva(activo As Boolean, libres As Integer, reservas As Integer)
    Sub ValidarTitularSolicitud(lector As Integer, operador As Integer, personal As Boolean)
    Sub ValidarEntregaCompleta(libros As IList(Of Integer), seleccion As IDictionary(Of Integer, Integer))
    Sub ValidarSolicitudParaEntrega(solicitud As SolicitudPrestamo, ahoraUtc As Date)
    Function CalcularDevolucion(datos As DatosDevolucion) As DevolucionCalculada
    Sub ValidarConfirmacion(actual As DevolucionCalculada, confirmado As DevolucionCalculada)
End Interface

Public Class DatosLectorPrestamo
    Public Property Usuario As Usuario
    Public Property PrestamosPendientes As Integer
    Public Property EstadosPago As New List(Of String)
End Class

Public Class DatosDevolucion
    Public Property Prestamo As Prestamo
    Public Property FechaRetorno As Date
    Public Property Tramos As New List(Of Penalizacion)
    Public Property CargoAnterior As DevolucionCalculada
End Class

Public Interface IReglasPenalizacion
    Sub ValidarPersonal(usuario As Usuario)
    Sub ValidarCambioTramo(anterior As Integer?, nuevo As Integer?, cargos As Integer)
    Sub ValidarCargo(tipo As Penalizacion, prestamo As Prestamo, tramos As IList(Of Penalizacion), cargos As IList(Of Penalizacion))
End Interface

Public Class DatosCambioUsuario
    Public Property Actual As Usuario
    Public Property NuevoRol As String
    Public Property NuevoEstado As String
    Public Property IdAdministrador As Integer
    Public Property AdministradoresActivos As Integer
    Public Property MovimientosPendientes As Integer
End Class

Public Interface IReglasUsuario
    Sub ValidarAdministrador(usuario As Usuario)
    Sub ValidarRol(rol As String)
    Sub ValidarCambio(datos As DatosCambioUsuario)
End Interface
