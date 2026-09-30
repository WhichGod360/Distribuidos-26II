Imports System.Data
Imports System.Data.SqlClient

Public Class ejemplarDAO
    Private ReadOnly con As Conexion = Conexion.ObtenerInstancia()

    Public Function obtenerDisponible(idLibro As Integer) As Ejemplar
        Dim objEjemplar As Ejemplar = Nothing
        Dim cn As SqlConnection = con.ObtenerConexion()

        Try
            ' Se usa TOP 1 para SQL Server y se corrige el campo a id_ejemplar en la tabla Prestamo
            Dim query As String = "SELECT TOP 1 id_ejemplar, estado_ejemplar, id_libro FROM Ejemplar " &
                                  "WHERE id_libro = @idLibro AND estado_ejemplar = 1 " &
                                  "AND id_ejemplar NOT IN (SELECT id_ejemplar FROM Prestamo WHERE estado_prestamo IN ('PENDIENTE','ACTIVO')) " &
                                  "ORDER BY id_ejemplar"

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
            Dim query As String = "SELECT id_ejemplar FROM Ejemplar " &
                                  "WHERE id_libro = @idLibro AND estado_ejemplar = 1 " &
                                  "AND id_ejemplar NOT IN (SELECT id_ejemplar FROM Prestamo WHERE estado_prestamo = 'ACTIVO') " &
                                  "ORDER BY id_ejemplar"

            Using cmd As New SqlCommand(query, cn)
                If con.EnTransaccion Then cmd.Transaction = con.TransaccionActual
                cmd.Parameters.AddWithValue("@idLibro", idLibro)

                Using rs As SqlDataReader = cmd.ExecuteReader()
                    While rs.Read()
                        Dim objEjemplar As New Ejemplar() With {
                            .IdEjemplar = rs.GetInt32(rs.GetOrdinal("id_ejemplar"))
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
End Class