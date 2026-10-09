Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion

Public Class seguridadDAO
    Public Function ObtenerRolActivo(idUsuario As Integer) As String
        Try
            Dim query As String = "SELECT r.nombre_rol_usuario FROM Usuario u JOIN RolUsuario r ON r.id_rol_usuario=u.id_rol_usuario WHERE u.id_usuario=@id AND UPPER(LTRIM(RTRIM(u.estado_usuario)))='ACTIVO'"
            Using cn As SqlConnection = Conexion.ObtenerInstancia().CrearConexionIndependiente()
                Using cmd As New SqlCommand(query,cn)
                    cmd.Parameters.Add("@id",SqlDbType.Int).Value=idUsuario
                    Using dr As SqlDataReader=cmd.ExecuteReader()
                        If dr.Read() Then Return dr.GetString(0)
                    End Using
                End Using
            End Using
            Return Nothing
        Catch ex As SqlException
            Throw ErroresDAO.Traducir(ex,"seguridadDAO.ObtenerRolActivo")
        End Try
    End Function
End Class
