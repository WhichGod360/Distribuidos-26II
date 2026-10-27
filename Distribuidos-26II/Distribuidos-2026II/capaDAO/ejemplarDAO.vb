Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class ejemplarDAO

    ' Solo una devolución completa libera la copia. Los registros incoherentes o
    ' con estados antiguos/desconocidos se bloquean hasta su revisión, sin migrarlos.
    Friend Const PrestamoOcupaEjemplarSql As String =
        "(p.fecha_retorno_prestamo IS NULL OR UPPER(LTRIM(RTRIM(p.estado_prestamo))) <> 'DEVUELTO')"

    Public Function obtenerDisponible(idLibro As Integer) As Ejemplar
        Try
            Dim objEjemplar As Ejemplar = Nothing
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim query As String = "SELECT TOP 1 e.id_ejemplar, e.estado_ejemplar, e.id_libro FROM Ejemplar e " &
                                      "INNER JOIN Libro l ON l.id_libro = e.id_libro " &
                                      "WHERE e.id_libro = @idLibro AND e.estado_ejemplar = 1 AND l.estado_libro = 1 " &
                                      "AND EXISTS (SELECT 1 FROM dbo.vw_DisponibilidadLibro d WHERE d.id_libro=e.id_libro AND d.disponibles > 0) " &
                                      "AND NOT EXISTS (SELECT 1 FROM Prestamo p WHERE p.id_ejemplar = e.id_ejemplar AND " & PrestamoOcupaEjemplarSql & ") " &
                                      "ORDER BY e.id_ejemplar"

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro

                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            objEjemplar = New Ejemplar() With {
                                .IdEjemplar = dr.GetInt32(dr.GetOrdinal("id_ejemplar")),
                                .EstadoEjemplar = dr.GetBoolean(dr.GetOrdinal("estado_ejemplar")),
                                .IdLibro = dr.GetInt32(dr.GetOrdinal("id_libro"))
                            }
                        End If
                    End Using
                End Using
            End Using

            Return objEjemplar
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "ejemplarDAO.obtenerDisponible")
        End Try
    End Function

    Public Function listarDisponiblesPorLibro(idLibro As Integer, Optional idLector As Integer = 0) As List(Of Ejemplar)
        Try
            Dim lista As New List(Of Ejemplar)()
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                DisponibilidadReserva.ExigirEsquema(cn)
                Dim query As String = "SELECT e.id_ejemplar, e.id_libro, e.estado_ejemplar FROM Ejemplar e " &
                                      "INNER JOIN Libro l ON l.id_libro = e.id_libro " &
                                      "WHERE e.id_libro = @idLibro AND e.estado_ejemplar = 1 AND l.estado_libro = 1 " &
                                      "AND EXISTS (SELECT 1 FROM dbo.vw_DisponibilidadLibro d WHERE d.id_libro=e.id_libro AND " &
                                      "(d.disponibles > 0 OR EXISTS (SELECT 1 FROM SolicitudPrestamo s JOIN DetalleSolicitudPrestamo ds ON ds.id_solicitud=s.id_solicitud WHERE ds.id_libro=e.id_libro AND s.id_usuario=@lector AND " & DisponibilidadReserva.VigenteSql & "))) " &
                                      "AND NOT EXISTS (SELECT 1 FROM Prestamo p WHERE p.id_ejemplar = e.id_ejemplar AND " & PrestamoOcupaEjemplarSql & ") " &
                                      "ORDER BY e.id_ejemplar"

                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                    cmd.Parameters.Add("@lector", SqlDbType.Int).Value = idLector

                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            Dim objEjemplar As New Ejemplar() With {
                                .IdEjemplar = dr.GetInt32(dr.GetOrdinal("id_ejemplar")),
                                .IdLibro = dr.GetInt32(dr.GetOrdinal("id_libro")),
                                .EstadoEjemplar = dr.GetBoolean(dr.GetOrdinal("estado_ejemplar"))
                            }
                            lista.Add(objEjemplar)
                        End While
                    End Using
                End Using
            End Using

            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "ejemplarDAO.listarDisponiblesPorLibro")
        End Try
    End Function

    Public Function listarPorLibro(idLibro As Integer) As DataTable
        Try
            Dim tabla As New DataTable()
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim query As String = "SELECT e.id_ejemplar, e.estado_ejemplar AS activo, " &
                                    "CASE WHEN e.estado_ejemplar = 0 THEN 'Inactivo' " &
                                    "WHEN EXISTS (SELECT 1 FROM Prestamo p WHERE p.id_ejemplar = e.id_ejemplar AND " & PrestamoOcupaEjemplarSql & ") THEN 'Prestado' " &
                                    "ELSE 'Disponible' END AS estado " &
                                    "FROM Ejemplar e WHERE e.id_libro = @idLibro ORDER BY e.id_ejemplar"
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = idLibro
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        LecturaDAO.CargarTabla(dr, tabla)
                    End Using
                End Using
            End Using
            Return tabla
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "ejemplarDAO.listarPorLibro")
        End Try
    End Function

    Public Function agregar(idLibro As Integer, reglas As IReglasLibro) As Boolean
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    reglas.ValidarAltaEjemplar(DisponibilidadReserva.BloquearLibro(cn, tx, idLibro))
                    Dim query As String = "INSERT INTO Ejemplar(estado_ejemplar,id_libro) VALUES(1,@libro); UPDATE Libro SET stock_total=stock_total+1 WHERE id_libro=@libro"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@libro", SqlDbType.Int).Value = idLibro
                        cmd.ExecuteNonQuery()
                    End Using
                    tx.Commit()
                    Return True
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "ejemplarDAO.agregar")
        End Try
    End Function

    Public Function cambiarEstado(idLibro As Integer, idEjemplar As Integer, activo As Boolean, reglas As IReglasLibro) As Boolean
        Try
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                    Dim estadoLibro = DisponibilidadReserva.BloquearLibro(cn, tx, idLibro)
                    Dim estado As Boolean? = Nothing
                    Dim prestamos, reservas As Integer
                    Dim query As String = "SELECT e.estado_ejemplar,(SELECT COUNT(*) FROM Prestamo p WITH (HOLDLOCK) WHERE p.id_ejemplar=e.id_ejemplar) AS prestamos FROM Ejemplar e WITH (UPDLOCK,HOLDLOCK) WHERE e.id_ejemplar=@ejemplar AND e.id_libro=@libro"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@ejemplar", SqlDbType.Int).Value = idEjemplar
                        cmd.Parameters.Add("@libro", SqlDbType.Int).Value = idLibro
                        Using dr As SqlDataReader = cmd.ExecuteReader()
                            If dr.Read() Then
                                estado = dr.GetBoolean(0)
                                prestamos = dr.GetInt32(1)
                            End If
                        End Using
                    End Using
                    query = "SELECT COUNT(*) FROM SolicitudPrestamo s WITH (HOLDLOCK) JOIN DetalleSolicitudPrestamo ds WITH (HOLDLOCK) ON ds.id_solicitud=s.id_solicitud WHERE ds.id_libro=@libro AND " & DisponibilidadReserva.VigenteSql
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@libro", SqlDbType.Int).Value = idLibro
                        reservas = CInt(cmd.ExecuteScalar())
                    End Using
                    If Not reglas.PuedeCambiarEjemplar(estado, activo, prestamos, DisponibilidadReserva.Capacidad(cn, tx, idLibro), reservas) Then Return False
                    query = "UPDATE Ejemplar SET estado_ejemplar=@activo WHERE id_ejemplar=@ejemplar AND id_libro=@libro AND estado_ejemplar<>@activo; UPDATE Libro SET stock_total=CASE WHEN @activo=1 THEN stock_total+1 WHEN stock_total>0 THEN stock_total-1 ELSE 0 END WHERE id_libro=@libro"
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@activo", SqlDbType.Bit).Value = activo
                        cmd.Parameters.Add("@ejemplar", SqlDbType.Int).Value = idEjemplar
                        cmd.Parameters.Add("@libro", SqlDbType.Int).Value = idLibro
                        cmd.ExecuteNonQuery()
                    End Using
                    tx.Commit()
                    Return True
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "ejemplarDAO.cambiarEstado")
        End Try
    End Function
End Class
