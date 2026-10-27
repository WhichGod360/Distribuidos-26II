Imports capaDatos

Public NotInheritable Class reglasLibroNegocio
    Implements IReglasLibro

    Public Sub ValidarTituloDuplicado(cantidad As Integer) Implements IReglasLibro.ValidarTituloDuplicado
        If cantidad > 0 Then Throw New InvalidOperationException("Ya existe un libro con ese título.")
    End Sub

    Public Sub ValidarDesactivacion(estado As Boolean?, prestamos As Integer, reservas As Integer, soloActivo As Boolean) Implements IReglasLibro.ValidarDesactivacion
        If soloActivo AndAlso Not estado.GetValueOrDefault() Then Return
        If prestamos > 0 Then Throw New InvalidOperationException("No se puede desactivar el libro porque tiene préstamos registrados.")
        If reservas > 0 Then Throw New InvalidOperationException("No se puede desactivar un libro con reservas vigentes.")
    End Sub
    Public Sub ValidarAltaEjemplar(estadoLibro As Boolean?) Implements IReglasLibro.ValidarAltaEjemplar
        If Not estadoLibro.GetValueOrDefault() Then Throw New InvalidOperationException("El libro no existe o está inactivo.")
    End Sub

    Public Function PuedeCambiarEjemplar(estado As Boolean?, nuevoEstado As Boolean, prestamos As Integer, capacidad As Integer, reservas As Integer) As Boolean Implements IReglasLibro.PuedeCambiarEjemplar
        If Not estado.HasValue OrElse estado.Value = nuevoEstado Then Return False
        If Not nuevoEstado AndAlso (prestamos > 0 OrElse (capacidad <= 0 AndAlso reservas > 0)) Then Return False
        Return True
    End Function
End Class
