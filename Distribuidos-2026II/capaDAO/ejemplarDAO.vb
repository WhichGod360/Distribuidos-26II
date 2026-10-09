Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class ejemplarDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    ' Solo una devolución completa libera la copia. Los registros incoherentes o
    ' con estados antiguos/desconocidos se bloquean hasta su revisión, sin migrarlos.
    Friend Const PrestamoOcupaEjemplarSql As String =
        "(p.fecha_retorno_prestamo IS NULL OR UPPER(LTRIM(RTRIM(p.estado_prestamo))) <> 'DEVUELTO')"

    Public Function obtenerDisponible(idLibro As Integer) As Ejemplar
        Dim objEjemplar As Ejemplar = Nothing
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT TOP 1 e.id_ejemplar, e.estado_ejemplar, e.id_libro FROM Ejemplar e " &
                                  "INNER JOIN Libro l ON l.id_libro = e.id_libro " &
                                  "WHERE e.id_libro = @idLibro AND e.estado_ejemplar = 1 AND l.estado_libro = 1 " &
                                  "AND NOT EXISTS (SELECT 1 FROM Prestamo p WHERE p.id_ejemplar = e.id_ejemplar AND " & PrestamoOcupaEjemplarSql & ") " &
                                  "ORDER BY e.id_ejemplar"

            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@idLibro", idLibro)

                Using rs As SqlDataReader = cmd.ExecuteReader()
                    If rs.Read() Then
                        objEjemplar = New Ejemplar() With {
                            .IdEjemplar = rs.GetInt32(rs.GetOrdinal("id_ejemplar")),
                            .EstadoEjemplar = rs.GetBoolean(rs.GetOrdinal("estado_ejemplar")),
                            .IdLibro = rs.GetInt32(rs.GetOrdinal("id_libro"))
                        }
                    End If
                End Using
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try

        Return objEjemplar
    End Function

    Public Function listarDisponiblesPorLibro(idLibro As Integer) As List(Of Ejemplar)
        Dim lista As New List(Of Ejemplar)()
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            Dim query As String = "SELECT e.id_ejemplar, e.id_libro, e.estado_ejemplar FROM Ejemplar e " &
                                  "INNER JOIN Libro l ON l.id_libro = e.id_libro " &
                                  "WHERE e.id_libro = @idLibro AND e.estado_ejemplar = 1 AND l.estado_libro = 1 " &
                                  "AND NOT EXISTS (SELECT 1 FROM Prestamo p WHERE p.id_ejemplar = e.id_ejemplar AND " & PrestamoOcupaEjemplarSql & ") " &
                                  "ORDER BY e.id_ejemplar"

            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@idLibro", idLibro)

                Using rs As SqlDataReader = cmd.ExecuteReader()
                    While rs.Read()
                        Dim objEjemplar As New Ejemplar() With {
                            .IdEjemplar = rs.GetInt32(rs.GetOrdinal("id_ejemplar")),
                            .IdLibro = rs.GetInt32(rs.GetOrdinal("id_libro")),
                            .EstadoEjemplar = rs.GetBoolean(rs.GetOrdinal("estado_ejemplar"))
                        }
                        lista.Add(objEjemplar)
                    End While
                End Using
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try

        Return lista
    End Function

    Public Function listarPorLibro(idLibro As Integer) As DataTable
        Dim tabla As New DataTable()
        Dim cn As SqlConnection = con.ObtenerConexion()
        Try
            Dim sql As String = "SELECT e.id_ejemplar, e.estado_ejemplar AS activo, " &
                                "CASE WHEN e.estado_ejemplar = 0 THEN 'Inactivo' " &
                                "WHEN EXISTS (SELECT 1 FROM Prestamo p WHERE p.id_ejemplar = e.id_ejemplar AND " & PrestamoOcupaEjemplarSql & ") THEN 'Prestado' " &
                                "ELSE 'Disponible' END AS estado " &
                                "FROM Ejemplar e WHERE e.id_libro = @idLibro ORDER BY e.id_ejemplar"
            Using cmd As New SqlCommand(sql, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(tabla)
                End Using
            End Using
        Finally
            If Not con.EnTransaccion AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
                cn.Dispose()
            End If
        End Try
        Return tabla
    End Function

    Public Function agregar(idLibro As Integer) As Boolean
        con.IniciarTransaccion()
        Dim cn As SqlConnection = con.ObtenerConexion()
        Dim tx As SqlTransaction = con.TransaccionActual
        Try
            Using cmd As New SqlCommand("IF NOT EXISTS (SELECT 1 FROM Libro WHERE id_libro = @idLibro AND estado_libro = 1) " &
                                        "THROW 50002, 'El libro no existe o está inactivo.', 1; " &
                                        "INSERT INTO Ejemplar (estado_ejemplar, id_libro) VALUES (1, @idLibro); " &
                                        "UPDATE Libro SET stock_total = stock_total + 1 WHERE id_libro = @idLibro", cn, tx)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                cmd.ExecuteNonQuery()
            End Using
            con.ConfirmarTransaccion()
            Return True
        Catch
            con.CancelarTransaccion()
            Throw
        End Try
    End Function

    Public Function cambiarEstado(idLibro As Integer, idEjemplar As Integer, activo As Boolean) As Boolean
        Using cn = con.CrearConexionIndependiente(), tx = cn.BeginTransaction(IsolationLevel.Serializable)
            ' Mismo orden de bloqueo que el registro de préstamos.
            Using cmd As New SqlCommand("SELECT id_libro FROM Libro WITH (UPDLOCK, HOLDLOCK) WHERE id_libro = @idLibro", cn, tx)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                If cmd.ExecuteScalar() Is Nothing Then Return False
            End Using
            Using cmd As New SqlCommand("UPDATE Ejemplar SET estado_ejemplar = @activo " &
                                        "WHERE id_ejemplar = @idEjemplar AND id_libro = @idLibro AND estado_ejemplar <> @activo " &
                                        "AND (@activo = 1 OR NOT EXISTS (SELECT 1 FROM Prestamo p WHERE p.id_ejemplar = Ejemplar.id_ejemplar))", cn, tx)
                cmd.Parameters.AddWithValue("@activo", activo)
                cmd.Parameters.AddWithValue("@idEjemplar", idEjemplar)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                If cmd.ExecuteNonQuery() = 0 Then
                    Return False
                End If
            End Using
            Using cmd As New SqlCommand("UPDATE Libro SET stock_total = CASE WHEN @activo = 1 THEN stock_total + 1 " &
                                        "WHEN stock_total > 0 THEN stock_total - 1 ELSE 0 END WHERE id_libro = @idLibro", cn, tx)
                cmd.Parameters.AddWithValue("@activo", activo)
                cmd.Parameters.AddWithValue("@idLibro", idLibro)
                cmd.ExecuteNonQuery()
            End Using
            tx.Commit()
            Return True
        End Using
    End Function
End Class
