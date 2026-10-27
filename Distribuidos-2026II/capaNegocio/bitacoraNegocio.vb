Imports System.Globalization
Imports capaDatos

Public Class bitacoraNegocio
    Private ReadOnly dao As New bitacoraDAO()

    Public Function Registrar(objeto As String, accion As String, cadena As String) As Integer
        Try
            Dim registro As Bitacora = Preparar(objeto, accion, cadena)
            Return dao.Registrar(registro)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al registrar el movimiento en la bitácora.", ex)
        End Try
    End Function

    ' Prepara el registro sin guardarlo, para poder compartir la transacción
    ' del mantenimiento cuando se integre la bitácora con los demás módulos.
    Public Function Preparar(objeto As String, accion As String, cadena As String) As Bitacora
        Return PrepararRegistro(objeto, accion, cadena, SesionUsuario.IdUsuario)
    End Function

    Public Function CrearContexto(objeto As String, accion As String) As IContextoBitacora
        Return CrearContexto(objeto, accion, SesionUsuario.IdUsuario)
    End Function

    Friend Function CrearContexto(objeto As String, accion As String, idUsuario As Integer) As IContextoBitacora
        Return New ContextoBitacora(NormalizarObjeto(objeto, True), NormalizarAccion(accion, True), idUsuario)
    End Function

    Private Shared Function PrepararRegistro(objeto As String, accion As String, cadena As String, idUsuario As Integer) As Bitacora
        Dim objetoMan As String = NormalizarObjeto(objeto, True)
        Dim accionMan As String = NormalizarAccion(accion, True)
        If idUsuario < 0 Then Throw New InvalidOperationException("El identificador del usuario de la sesión no es válido.")

        Dim cadenaMan As String = cadena
        If cadenaMan IsNot Nothing AndAlso cadenaMan.Length > 255 Then
            cadenaMan = cadenaMan.Substring(0, 255)
        End If

        Dim instante As Date = Date.Now
        Return New Bitacora With {
            .FechaMan = instante.Date,
            .HoraMan = instante.ToString("HH:mm:ss", CultureInfo.InvariantCulture),
            .IdUsuario = idUsuario,
            .Objeto = objetoMan,
            .Accion = accionMan,
            .CadenaMan = cadenaMan
        }
    End Function

    ' Conserva el actor que inició la operación, incluso si se cierra la sesión
    ' mientras termina una tarea de guardado en segundo plano.
    Private NotInheritable Class ContextoBitacora
        Implements IContextoBitacora

        Private ReadOnly objeto As String
        Private ReadOnly accion As String
        Private ReadOnly idUsuario As Integer

        Public Sub New(objeto As String, accion As String, idUsuario As Integer)
            Me.objeto = objeto
            Me.accion = accion
            Me.idUsuario = idUsuario
        End Sub

        Public Function Preparar(cadena As String) As Bitacora Implements IContextoBitacora.Preparar
            Return PrepararRegistro(objeto, accion, cadena, idUsuario)
        End Function
    End Class

    Public Function Listar(Optional fechaDesde As Date? = Nothing,
                           Optional fechaHasta As Date? = Nothing,
                           Optional idUsuario As Integer? = Nothing,
                           Optional objeto As String = Nothing,
                           Optional accion As String = Nothing,
                           Optional despuesDeId As Integer? = Nothing) As List(Of Bitacora)
        Try
            seguridadNegocio.ExigirAdministrador()
            If fechaDesde.HasValue Then fechaDesde = fechaDesde.Value.Date
            If fechaHasta.HasValue Then fechaHasta = fechaHasta.Value.Date
            If fechaDesde.HasValue AndAlso fechaHasta.HasValue AndAlso fechaDesde.Value > fechaHasta.Value Then
                Throw New ArgumentException("La fecha inicial no puede ser posterior a la fecha final.")
            End If
            If idUsuario.HasValue AndAlso idUsuario.Value < 0 Then
                Throw New ArgumentException("El ID del usuario debe ser cero o un número positivo.")
            End If
            If despuesDeId.HasValue AndAlso despuesDeId.Value < 0 Then
                Throw New ArgumentException("El último ID de la bitácora no puede ser negativo.")
            End If

            Dim objetoMan As String = NormalizarObjeto(objeto, False)
            Dim accionMan As String = NormalizarAccion(accion, False)
            Return dao.Listar(fechaDesde, fechaHasta, idUsuario, objetoMan, accionMan, despuesDeId)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar la bitácora.", ex)
        End Try
    End Function

    Public Function ObtenerPorId(idMan As Integer) As Bitacora
        Try
            seguridadNegocio.ExigirAdministrador()
            If idMan <= 0 Then Throw New ArgumentException("El ID del movimiento debe ser un número positivo.")
            Return dao.ObtenerPorId(idMan)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is UnauthorizedAccessException
            Throw
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al consultar el movimiento de la bitácora.", ex)
        End Try
    End Function

    Private Shared Function NormalizarObjeto(objeto As String, requerido As Boolean) As String
        If String.IsNullOrWhiteSpace(objeto) Then
            If requerido Then Throw New ArgumentException("Indica el objeto o mantenimiento de la operación.")
            Return Nothing
        End If

        Dim nombre As String = objeto.Trim()
        If nombre.Length > 30 Then Throw New ArgumentException("El objeto de la bitácora admite hasta 30 caracteres.")
        Return nombre
    End Function

    Private Shared Function NormalizarAccion(accion As String, requerido As Boolean) As String
        If String.IsNullOrWhiteSpace(accion) Then
            If requerido Then Throw New ArgumentException("Indica la acción realizada en el mantenimiento.")
            Return Nothing
        End If

        Select Case accion.Trim().ToUpperInvariant()
            Case "1", "INSERT"
                Return "INSERT"
            Case "2", "UPDATE"
                Return "UPDATE"
            Case "3", "DELETE"
                Return "DELETE"
            Case "4", "SELECT"
                Return "SELECT"
            Case "5", "BUSQUEDA", "BÚSQUEDA"
                Return "BUSQUEDA"
            Case "6", "LISTADO"
                Return "LISTADO"
            Case Else
                Throw New ArgumentException("La acción debe ser INSERT, UPDATE, DELETE, SELECT, BUSQUEDA o LISTADO.")
        End Select
    End Function
End Class
