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
            Dim strSQL As String = "INSERT INTO Categoria (nombre_categoria) VALUES (@nombre)"
            cm.Connection = cn.ObtenerConexion()
            cm.CommandText = strSQL
            'Parameters es una coleccion de parametros
            'Clear se usa ya que en este tipo de datos no se reasigna el valor, solo se agrega uno mas
            cm.Parameters.Clear()
            cm.Parameters.AddWithValue("@nombre", nombre)
            'Ejecuta un comando
            cm.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            'Throw termina la funcion, por eso no necesitamos un return false
            Throw New Exception("No se pudo insertar la categoria")
        End Try
    End Function

    Public Function Actualizar(id As Integer, nombre As String) As Boolean
        Try
            Dim strSQL As String = "UPDATE Categoria SET nombre_categoria = @nombre WHERE id_categoria = @id"
            cm.Connection = cn.ObtenerConexion()
            cm.CommandText = strSQL
            cm.Parameters.Clear()
            cm.Parameters.AddWithValue("@nombre", nombre)
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
    Public Function BuscarCategoria(nombre As String, estado As Boolean?) As DataTable
        Dim strSQL As String = ""
        Dim tabla As DataTable
        If nombre = "" Then
            If estado = True Then
                strSQL = "Select * from categoria where estado = 1"
            ElseIf estado = False Then
                strSQL = "Select * from categoria where estado = 0"
            Else
                strSQL = "Select * from categoria"
            End If
        Else
            If estado = True Then
                strSQL = "SELECT * FROM Categoria WHERE estado = 1 AND nombre_categoria = @nombre"
            ElseIf estado = False Then
                strSQL = "SELECT * FROM Categoria WHERE estado = 0 AND nombre_categoria = @nombre"
            Else
                strSQL = "SELECT * FROM Categoria WHERE nombre_categoria = @nombre"
            End If
        End If
        Try
            cm.Connection = cn.ObtenerConexion()
            cm.CommandText = strSQL
            Dim da As New SqlDataAdapter(cm)
            da.Fill(tabla)
        Catch ex As Exception
            Throw New Exception("Error al buscar categoria")
        End Try
        Return tabla
    End Function

End Class