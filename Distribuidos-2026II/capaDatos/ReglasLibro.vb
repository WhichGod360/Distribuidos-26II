Public Interface IReglasLibro
    Sub ValidarTituloDuplicado(cantidad As Integer)
    Sub ValidarDesactivacion(estado As Boolean?, prestamos As Integer, reservas As Integer, soloActivo As Boolean)
    Sub ValidarAltaEjemplar(estadoLibro As Boolean?)
    Function PuedeCambiarEjemplar(estado As Boolean?, nuevoEstado As Boolean, prestamos As Integer, capacidad As Integer, reservas As Integer) As Boolean
End Interface
