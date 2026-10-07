Imports System.Data
Imports System.Data.SqlClient

'Obtener instancia me da el objeto
'Obtener conexion me da la conexion en si

Public Class categoriaDato

    Private cn As Conexion = Conexion.ObtenerInstancia()
    'SqlCommand es un objeto que permite enviar instrucciones sql en sql server
    Dim cm As New SqlCommand()

    'DataTable es una clase que almacena informacion en tablas
    Public Function Listar() As DataTable
        Dim tabla As New DataTable()
        Try
            Dim strSQL As String = "SELECT id_categoria, nombre_categoria,
                CASE WHEN estado = 1 THEN 'Activo'ELSE 'Inactivo'
                END AS estado
                FROM Categoria"
            'Enviamos un comando a la bd mediante la conexion
            cm.Connection = cn.ObtenerConexion()
            'ComandText indica que instruccion sql se va a usar
            cm.CommandText = strSQL
            'SqlDataAdapter es un objeto para obtener datos de SQL Server
            'cm se pasa como parametro ya se indica que devolvera los valores en base a cm
            Dim da As New SqlDataAdapter(cm)
            'Fill ejecuta y llena los datos en una tabla
            da.Fill(tabla)
        Catch ex As Exception
            Throw New Exception("No se pudo consultar las categorias")
        End Try
        Return tabla
    End Function

    Public Function Insertar(nombre As String, estado As Integer) As Boolean
        Try
            Dim strSQL As String = "INSERT INTO Categoria (nombre_categoria, estado) " & "VALUES (@nombre, @estado)"
            cm.Connection = cn.ObtenerConexion()
            cm.CommandText = strSQL
            cm.Parameters.Clear()
            cm.Parameters.AddWithValue("@nombre", nombre)
            cm.Parameters.AddWithValue("@estado", estado)
            cm.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw New Exception("No se pudo insertar la categoria")
        End Try
    End Function

    Public Function Actualizar(id As Integer, nombre As String, estado As Integer) As Boolean
        Try
            Dim strSQL As String = "UPDATE Categoria " &
                               "SET nombre_categoria = @nombre, estado = @estado " &
                               "WHERE id_categoria = @id"
            cm.Connection = cn.ObtenerConexion()
            cm.CommandText = strSQL
            cm.Parameters.Clear()
            cm.Parameters.AddWithValue("@nombre", nombre)
            cm.Parameters.AddWithValue("@estado", estado)
            cm.Parameters.AddWithValue("@id", id)
            cm.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw New Exception("No se pudo actualizar la categoria")
        End Try
    End Function

    Public Function Eliminar(id As Integer) As Boolean
        Try
            Dim strSQL As String = "UPDATE Categoria SET estado = 0 WHERE id_categoria = @id"
            cm.Connection = cn.ObtenerConexion()
            cm.CommandText = strSQL
            cm.Parameters.Clear()
            cm.Parameters.AddWithValue("@id", id)
            cm.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw New Exception("No se pudo eliminar la categoria")
        End Try
    End Function

    'Boolean? permite que tenga un tercer valor
    Public Function BuscarCategoria(nombre As String) As DataTable
        Dim tabla As New DataTable()
        Try
            Dim strSQL As String = "SELECT id_categoria, nombre_categoria, " &
                               "CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado " &
                               "FROM Categoria " &
                               "WHERE nombre_categoria LIKE @nombre"
            cm.Connection = cn.ObtenerConexion()
            cm.CommandText = strSQL
            cm.Parameters.Clear()
            cm.Parameters.AddWithValue("@nombre", "%" & nombre & "%")
            Dim da As New SqlDataAdapter(cm)
            da.Fill(tabla)
        Catch ex As Exception
            Throw New Exception("Error al buscar categoria")
        End Try
        Return tabla
    End Function

    Public Function ObtenerPorId(id As Integer) As DataTable
        Dim tabla As New DataTable
        Dim consulta As String = "SELECT id_categoria, nombre_categoria, estado " &
                                 "FROM Categoria " &
                                 "WHERE id_categoria = @id"
        Using comando As New SqlCommand(consulta, Conexion.ObtenerInstancia().ObtenerConexion())
            comando.Parameters.AddWithValue("@id", id)
            Using adaptador As New SqlDataAdapter(comando)
                adaptador.Fill(tabla)
            End Using
        End Using
        Return tabla
    End Function

End Class