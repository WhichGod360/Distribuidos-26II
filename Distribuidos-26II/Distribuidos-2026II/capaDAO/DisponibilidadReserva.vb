Imports System.Data
Imports System.Data.SqlClient
Imports capaDatos

Friend NotInheritable Class DisponibilidadReserva
    Friend Const VigenteSql As String = "s.estado_solicitud IN ('Pendiente','Aprobada') AND s.fecha_limite_retiro > SYSUTCDATETIME()"

    Friend Shared Sub ExigirEsquema(cn As SqlConnection)
        Try
            Dim query As String = "SELECT OBJECT_ID('dbo.DetalleSolicitudPrestamo','U'), OBJECT_ID('dbo.vw_DisponibilidadLibro','V')"
            Using cmd As New SqlCommand(query, cn)
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    dr.Read()
                    If dr.IsDBNull(0) OrElse dr.IsDBNull(1) Then Throw New InvalidOperationException("Falta la actualización 003 de carrito y aprobación. Aplícala antes de reservar o prestar.")
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "DisponibilidadReserva.ExigirEsquema")
        End Try
    End Sub

    Friend Shared Function LeerUsuario(cn As SqlConnection, tx As SqlTransaction, id As Integer, Optional bloquear As Boolean = False) As Usuario
        Try
            Dim query As String = "SELECT u.id_usuario,u.estado_usuario,u.id_rol_usuario,r.nombre_rol_usuario FROM Usuario u WITH (" &
                If(bloquear, "UPDLOCK,HOLDLOCK", "HOLDLOCK") & ") JOIN RolUsuario r WITH (HOLDLOCK) ON r.id_rol_usuario=u.id_rol_usuario WHERE u.id_usuario=@id"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then Return New Usuario With {.IdUsuario = dr.GetInt32(0), .EstadoUsuario = dr.GetString(1), .IdRolUsuario = dr.GetInt32(2), .NombreRol = dr.GetString(3)}
                End Using
            End Using
            Return Nothing
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "DisponibilidadReserva.LeerUsuario")
        End Try
    End Function

    Friend Shared Function LeerLector(cn As SqlConnection, tx As SqlTransaction, idLector As Integer) As DatosLectorPrestamo
        Try
            Dim datos As New DatosLectorPrestamo With {.Usuario = LeerUsuario(cn, tx, idLector, True)}
            Dim query As String = "SELECT COUNT(*) FROM Prestamo p WITH (HOLDLOCK) WHERE p.id_usuario=@lector AND " & ejemplarDAO.PrestamoOcupaEjemplarSql
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    dr.Read()
                    datos.PrestamosPendientes = dr.GetInt32(0)
                End Using
            End Using
            query = "SELECT dp.estado_pago_detalle FROM DetallePenalizacion dp WITH (HOLDLOCK) JOIN Prestamo p WITH (HOLDLOCK) ON p.id_prestamo=dp.id_prestamo WHERE p.id_usuario=@lector"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        datos.EstadosPago.Add(dr.GetString(0))
                    End While
                End Using
            End Using
            Return datos
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "DisponibilidadReserva.LeerLector")
        End Try
    End Function

    Friend Shared Function Capacidad(cn As SqlConnection, tx As SqlTransaction, idLibro As Integer) As Integer
        Try
            Dim query As String = "SELECT disponibles FROM dbo.vw_DisponibilidadLibro WHERE id_libro=@libro"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@libro", SqlDbType.Int).Value = idLibro
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "DisponibilidadReserva.Capacidad")
        End Try
    End Function

    Friend Shared Function BloquearLibro(cn As SqlConnection, tx As SqlTransaction, idLibro As Integer) As Boolean?
        Try
            Dim query As String = "SELECT estado_libro FROM Libro WITH (UPDLOCK,HOLDLOCK) WHERE id_libro=@libro"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@libro", SqlDbType.Int).Value = idLibro
                Dim valor = cmd.ExecuteScalar()
                Return If(valor Is Nothing, CType(Nothing, Boolean?), CBool(valor))
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "DisponibilidadReserva.BloquearLibro")
        End Try
    End Function

    Friend Shared Sub LeerCobertura(cn As SqlConnection, tx As SqlTransaction, idLibro As Integer, reglas As IReglasCirculacion)
        Try
            Dim query As String = "SELECT l.estado_libro,v.ejemplares_libres,v.reservas_vigentes FROM vw_DisponibilidadLibro v JOIN Libro l ON l.id_libro=v.id_libro WHERE v.id_libro=@id"
            Using cmd As New SqlCommand(query, cn, tx)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idLibro
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    Dim activo As Boolean, libres As Integer, reservas As Integer
                    If dr.Read() Then
                        activo = dr.GetBoolean(0)
                        libres = dr.GetInt32(1)
                        reservas = dr.GetInt32(2)
                    End If
                    ' El lector se cierra antes de ejecutar la regla; la transacción conserva sus bloqueos.
                    dr.Close()
                    reglas.ValidarCoberturaReserva(activo, libres, reservas)
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "DisponibilidadReserva.LeerCobertura")
        End Try
    End Sub
End Class
