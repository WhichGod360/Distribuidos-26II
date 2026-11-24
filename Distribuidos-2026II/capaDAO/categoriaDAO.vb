Imports System.Data
Imports System.Data.SqlClient
Imports capaDatos

Public Class categoriaDAO
    Private Const ConsultaListado As String =
        "SELECT id_categoria, nombre_categoria, CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado FROM Categoria"

    Private Shared Function LeerCategoria(dr As SqlDataReader) As Categoria
        Try
            Return New Categoria With {
                .IdCategoria = CInt(dr("id_categoria")),
                .NombreCategoria = CStr(dr("nombre_categoria"))
            }
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "categoriaDAO.LeerCategoria")
        End Try
    End Function

    Public Function listarTabla(Optional estado As Integer? = Nothing) As DataTable
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As New DataTable()
            Dim query As String = ConsultaListado & " WHERE (@estado IS NULL OR estado = @estado) ORDER BY nombre_categoria"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = If(estado.HasValue, CObj(estado.Value), DBNull.Value)
                Using dr = cmd.ExecuteReader()
                    LecturaDAO.CargarTabla(dr, resultado)
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Categoria", If(estado.HasValue, "BUSQUEDA", "LISTADO"), "Consultar categorías y estado")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "categoriaDAO.listarTabla")
        End Try
    End Function

    Public Function insertar(nombre As String, estado As Integer, idOperador As Integer) As Boolean
        Try
            Dim query As String = "INSERT INTO Categoria (nombre_categoria, estado) VALUES (@nombre, @estado)"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), tx = cn.BeginTransaction()
                Using cmd As New SqlCommand(query, cn, tx)
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado
                    If cmd.ExecuteNonQuery() <= 0 Then Return False
                End Using
                AuditoriaDAO.Registrar(cn, tx, idOperador, "Categoria", "INSERT", "Registrar categoría")
                tx.Commit()
            End Using
            Return True
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "categoriaDAO.insertar")
        End Try
    End Function

    Public Function actualizar(id As Integer, nombre As String, estado As Integer, idOperador As Integer) As Boolean
        Try
            Dim query As String = "UPDATE Categoria SET nombre_categoria = @nombre, estado = @estado WHERE id_categoria = @id"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), tx = cn.BeginTransaction()
                Using cmd As New SqlCommand(query, cn, tx)
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                    If cmd.ExecuteNonQuery() <= 0 Then Return False
                End Using
                AuditoriaDAO.Registrar(cn, tx, idOperador, "Categoria", "UPDATE", $"Actualizar categoría | ID={id}; estado={estado}")
                tx.Commit()
            End Using
            Return True
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "categoriaDAO.actualizar")
        End Try
    End Function

    Public Function desactivar(id As Integer, idOperador As Integer) As Boolean
        Try
            Dim query As String = "UPDATE Categoria SET estado = 0 WHERE id_categoria = @id"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), tx = cn.BeginTransaction()
                Using cmd As New SqlCommand(query, cn, tx)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                    If cmd.ExecuteNonQuery() <= 0 Then Return False
                End Using
                AuditoriaDAO.Registrar(cn, tx, idOperador, "Categoria", "UPDATE", $"Desactivar categoría | ID={id}")
                tx.Commit()
            End Using
            Return True
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "categoriaDAO.desactivar")
        End Try
    End Function

    Public Function buscarTabla(nombre As String, Optional estado As Integer? = Nothing) As DataTable
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As New DataTable()
            Dim query As String = ConsultaListado & " WHERE nombre_categoria LIKE @nombre AND (@estado IS NULL OR estado = @estado) ORDER BY nombre_categoria"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = LecturaDAO.PatronContiene(nombre)
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = If(estado.HasValue, CObj(estado.Value), DBNull.Value)
                Using dr = cmd.ExecuteReader()
                    LecturaDAO.CargarTabla(dr, resultado)
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Categoria", "BUSQUEDA", "Buscar categorías")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "categoriaDAO.buscarTabla")
        End Try
    End Function

    Public Function obtenerTablaPorId(id As Integer) As DataTable
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As New DataTable()
            Dim query As String = "SELECT id_categoria, nombre_categoria, estado FROM Categoria WHERE id_categoria = @id"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
                Using dr = cmd.ExecuteReader()
                    LecturaDAO.CargarTabla(dr, resultado)
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Categoria", "BUSQUEDA", $"Consultar categoría | ID={id}")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "categoriaDAO.obtenerTablaPorId")
        End Try
    End Function

    Public Function listarTodos() As List(Of Categoria)
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As New List(Of Categoria)()
            Dim query As String = "SELECT id_categoria, nombre_categoria FROM Categoria ORDER BY nombre_categoria"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                Using dr = cmd.ExecuteReader()
                    While dr.Read()
                        resultado.Add(LeerCategoria(dr))
                    End While
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Categoria", "LISTADO", "Listar categorías")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "categoriaDAO.listarTodos")
        End Try
    End Function

    Public Function buscarPorId(idCategoria As Integer) As Categoria
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As Categoria = Nothing
            Dim query As String = "SELECT id_categoria, nombre_categoria FROM Categoria WHERE id_categoria = @idCategoria"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria
                Using dr = cmd.ExecuteReader()
                    If dr.Read() Then resultado = LeerCategoria(dr)
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Categoria", "BUSQUEDA", $"Consultar categoría | ID={idCategoria}")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "categoriaDAO.buscarPorId")
        End Try
    End Function

    Public Function buscarPorNombre(nombre As String) As Categoria
        Try
            Dim actor = SesionUsuario.IdUsuario
            Dim resultado As Categoria = Nothing
            Dim query As String = "SELECT id_categoria, nombre_categoria FROM Categoria WHERE nombre_categoria = @nombre"
            Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(query, cn)
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, -1).Value = nombre
                Using dr = cmd.ExecuteReader()
                    If dr.Read() Then resultado = LeerCategoria(dr)
                End Using
            End Using
            AuditoriaDAO.RegistrarEvento(actor, "Categoria", "BUSQUEDA", "Buscar categoría por nombre")
            Return resultado
        Catch ex As Exception
            If ErroresMantenimiento.TieneMensaje(ex) Then Throw
            Throw ErroresDAO.ParaMantenimiento(ex, "categoriaDAO.buscarPorNombre")
        End Try
    End Function
End Class
