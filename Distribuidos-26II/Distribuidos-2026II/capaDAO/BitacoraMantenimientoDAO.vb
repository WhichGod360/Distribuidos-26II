Imports System.Data.SqlClient
Imports System.Globalization
Imports capaDatos

Friend NotInheritable Class BitacoraMantenimientoDAO
    Private Sub New()
    End Sub

    Friend Shared Sub Registrar(cmd As SqlCommand, contexto As IContextoBitacora)
        If contexto Is Nothing Then Return
        Dim registro As Bitacora = contexto.Preparar(Describir(cmd))
        Dim dao As New bitacoraDAO()
        If cmd.Transaction IsNot Nothing Then
            dao.Registrar(registro, cmd.Connection, cmd.Transaction)
        Else
            ' Los lectores deben estar cerrados antes de registrar la consulta.
            Using tx As SqlTransaction = cmd.Connection.BeginTransaction()
                dao.Registrar(registro, cmd.Connection, tx)
                tx.Commit()
            End Using
        End If
    End Sub

    Private Shared Function Describir(cmd As SqlCommand) As String
        Dim parametros As New List(Of String)()
        For Each parametro As SqlParameter In cmd.Parameters.Cast(Of SqlParameter)().
            OrderBy(Function(p) If(p.ParameterName.StartsWith("@id", StringComparison.OrdinalIgnoreCase), 0, 1))
            parametros.Add(parametro.ParameterName & "=" & Formatear(parametro))
        Next
        If parametros.Count = 0 Then Return cmd.CommandText
        ' Los parámetros van primero para conservar el ID o criterio buscado
        ' cuando Negocio aplica el límite de 255 caracteres de la tabla.
        Return "/* " & String.Join("; ", parametros) & " */ " & cmd.CommandText
    End Function

    Private Shared Function Formatear(parametro As SqlParameter) As String
        Dim nombre As String = parametro.ParameterName.ToLowerInvariant()
        If nombre.Contains("clave") OrElse nombre.Contains("contrasena") OrElse nombre.Contains("password") OrElse
            nombre.Contains("hash") OrElse nombre.Contains("respuesta") OrElse nombre.Contains("rpta") OrElse
            nombre.Contains("pregunta") OrElse nombre.Contains("token") OrElse nombre = "@anterior" Then
            Return "[OCULTO]"
        End If
        Dim valor As Object = parametro.Value
        If valor Is Nothing OrElse Convert.IsDBNull(valor) Then Return "NULL"
        If TypeOf valor Is Date Then
            Return "'" & DirectCast(valor, Date).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) & "'"
        End If
        If TypeOf valor Is Boolean Then Return If(CBool(valor), "1", "0")
        If TypeOf valor Is String Then
            Return "'" & CStr(valor).Replace("'", "''").Replace("*/", "* /").
                Replace(vbCr, "\r").Replace(vbLf, "\n") & "'"
        End If
        If TypeOf valor Is Byte() Then Return "[BINARIO]"
        Return Convert.ToString(valor, CultureInfo.InvariantCulture)
    End Function
End Class
