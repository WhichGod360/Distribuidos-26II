Public Module ErroresMantenimiento
    Public Function TieneMensaje(ex As Exception) As Boolean
        Return TypeOf ex Is ArgumentException OrElse
               TypeOf ex Is InvalidOperationException OrElse
               TypeOf ex Is UnauthorizedAccessException
    End Function
End Module
