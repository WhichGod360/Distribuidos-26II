Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class categoriaDAO

    Public Function listarTabla(Optional estado As Integer? = Nothing, Optional bitacora As IContextoBitacora = Nothing) As DataTable
        Try
            Dim tabla As New DataTable()
            Dim query As String = "SELECT id_categoria, nombre_categoria, CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado FROM Categoria WHERE (@estado IS NULL OR estado = @estado) ORDER BY nombre_categoria"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = If(estado.HasValue, CObj(estado.Value), DBNull.Value)

                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        LecturaDAO.CargarTabla(dr, tabla)
                    End Using
                    BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                End Using
            End Using
            Return tabla
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "categoriaDAO.listarTabla")
        End Try
    End Function

    Public Function insertar(nombre As String, estado As Integer, Optional bitacora As IContextoBitacora = Nothing) As Boolean
        Try
            Dim query As String = "INSERT INTO Categoria (nombre_categoria, estado) VALUES (@nombre, @estado)"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction()
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado

                        Dim resultado As Boolean = cmd.ExecuteNonQuery() > 0
                        BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                        tx.Commit()
                        Return resultado
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "categoriaDAO.insertar")
        End Try
    End Function

    Public Function actualizar(id As Integer, nombre As String, estado As Integer, Optional bitacora As IContextoBitacora = Nothing) As Boolean
        Try
            Dim query As String = "UPDATE Categoria SET nombre_categoria = @nombre, estado = @estado WHERE id_categoria = @id"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction()
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                        cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id

                        Dim resultado As Boolean = cmd.ExecuteNonQuery() > 0
                        BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                        tx.Commit()
                        Return resultado
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "categoriaDAO.actualizar")
        End Try
    End Function

    Public Function desactivar(id As Integer, Optional bitacora As IContextoBitacora = Nothing) As Boolean
        Try
            Dim query As String = "UPDATE Categoria SET estado = 0 WHERE id_categoria = @id"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using tx As SqlTransaction = cn.BeginTransaction()
                    Using cmd As New SqlCommand(query, cn, tx)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                        Dim resultado As Boolean = cmd.ExecuteNonQuery() > 0
                        BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                        tx.Commit()
                        Return resultado
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "categoriaDAO.desactivar")
        End Try
    End Function

    Public Function buscarTabla(nombre As String, Optional estado As Integer? = Nothing, Optional bitacora As IContextoBitacora = Nothing) As DataTable
        Try
            Dim tabla As New DataTable()
            Dim query As String = "SELECT id_categoria, nombre_categoria, CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado FROM Categoria WHERE nombre_categoria LIKE @nombre AND (@estado IS NULL OR estado = @estado) ORDER BY nombre_categoria"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = "%" & nombre & "%"
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = If(estado.HasValue, CObj(estado.Value), DBNull.Value)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        LecturaDAO.CargarTabla(dr, tabla)
                    End Using
                    BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                End Using
            End Using
            Return tabla
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "categoriaDAO.buscarTabla")
        End Try
    End Function

    Public Function obtenerTablaPorId(id As Integer, Optional bitacora As IContextoBitacora = Nothing) As DataTable
        Try
            Dim tabla As New DataTable()
            Dim query As String = "SELECT id_categoria, nombre_categoria, estado FROM Categoria WHERE id_categoria = @id"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        LecturaDAO.CargarTabla(dr, tabla)
                    End Using
                    BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                End Using
            End Using
            Return tabla
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "categoriaDAO.obtenerTablaPorId")
        End Try
    End Function

    Public Function listarTodos(Optional bitacora As IContextoBitacora = Nothing) As List(Of Categoria)
        Try
            Dim lista As New List(Of Categoria)()
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                ' Se especifican las columnas exactas en lugar de usar SELECT *
                Dim query As String = "SELECT id_categoria, nombre_categoria FROM Categoria ORDER BY nombre_categoria"
                Using cmd As New SqlCommand(query, cn)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Categoria() With {
                                .IdCategoria = dr.GetInt32(dr.GetOrdinal("id_categoria")),
                                .NombreCategoria = dr.GetString(dr.GetOrdinal("nombre_categoria"))
                            })
                        End While
                    End Using
                    BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                End Using
            End Using
            Return lista
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "categoriaDAO.listarTodos")
        End Try
    End Function

    Public Function buscarPorId(idCategoria As Integer, Optional bitacora As IContextoBitacora = Nothing) As Categoria
        Try
            Dim objCategoria As Categoria = Nothing
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim query As String = "SELECT id_categoria, nombre_categoria FROM Categoria WHERE id_categoria = @idCategoria"
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            objCategoria = New Categoria() With {
                                .IdCategoria = dr.GetInt32(dr.GetOrdinal("id_categoria")),
                                .NombreCategoria = dr.GetString(dr.GetOrdinal("nombre_categoria"))
                            }
                        End If
                    End Using
                    BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                End Using
            End Using
            Return objCategoria
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "categoriaDAO.buscarPorId")
        End Try
    End Function

    Public Function buscarPorNombre(nombre As String, Optional bitacora As IContextoBitacora = Nothing) As Categoria
        Try
            Dim objCategoria As Categoria = Nothing
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Dim query As String = "SELECT id_categoria, nombre_categoria FROM Categoria WHERE nombre_categoria = @nombre"
                Using cmd As New SqlCommand(query, cn)
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            objCategoria = New Categoria() With {
                                .IdCategoria = dr.GetInt32(dr.GetOrdinal("id_categoria")),
                                .NombreCategoria = dr.GetString(dr.GetOrdinal("nombre_categoria"))
                            }
                        End If
                    End Using
                    BitacoraMantenimientoDAO.Registrar(cmd, bitacora)
                End Using
            End Using
            Return objCategoria
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex, "categoriaDAO.buscarPorNombre")
        End Try
    End Function
End Class
