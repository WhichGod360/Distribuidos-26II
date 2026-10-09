Imports System.Data
Imports System.Data.SqlClient
Imports capaConexion
Imports capaDatos

Public Class dashboardDAO
    Public Function listarCategorias() As List(Of Categoria)
        Dim resultado As New List(Of Categoria)()
        Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand("SELECT id_categoria, nombre_categoria FROM Categoria ORDER BY nombre_categoria", cn)
            Using rs = cmd.ExecuteReader()
                While rs.Read()
                    resultado.Add(New Categoria With {.IdCategoria = rs.GetInt32(0), .NombreCategoria = rs.GetString(1)})
                End While
            End Using
        End Using
        Return resultado
    End Function

    Public Function consultar(desde As Date, hasta As Date, idCategoria As Integer, estado As String, hoy As Date) As DashboardResumen
        Dim resultado As New DashboardResumen()
        ' Una selección materializada sirve a las tarjetas, gráficos y lista del periodo.
        Dim sql = "SELECT p.id_prestamo, p.id_usuario, e.id_libro, p.fecha_inicio_prestamo, p.fecha_fin_prestamo, " &
            "u.nombre_usuario + ' ' + u.ap_paterno + ' ' + u.ap_materno AS lector, l.titulo_libro, " &
            "CASE WHEN UPPER(LTRIM(RTRIM(p.estado_prestamo))) = 'DEVUELTO' AND p.fecha_retorno_prestamo IS NOT NULL THEN 'Devuelto' " &
            "WHEN UPPER(LTRIM(RTRIM(p.estado_prestamo))) = 'ACTIVO' AND p.fecha_retorno_prestamo IS NULL " &
            "THEN CASE WHEN p.fecha_fin_prestamo < @hoy THEN 'Vencido' ELSE 'Vigente' END ELSE 'Por revisar' END AS estado " &
            "INTO #Periodo FROM Prestamo p INNER JOIN Ejemplar e ON e.id_ejemplar = p.id_ejemplar " &
            "INNER JOIN Libro l ON l.id_libro = e.id_libro INNER JOIN Usuario u ON u.id_usuario = p.id_usuario " &
            "WHERE p.fecha_inicio_prestamo >= @desde AND p.fecha_inicio_prestamo <= @hasta " &
            "AND (@categoria = 0 OR EXISTS (SELECT 1 FROM DetalleCategoria dc WHERE dc.id_libro = e.id_libro AND dc.id_categoria = @categoria)); " &
            "DELETE FROM #Periodo WHERE NOT (@estado = 'Todos' OR (@estado = 'Activos' AND estado IN ('Vigente','Vencido')) " &
            "OR (@estado = 'Vencidos' AND estado = 'Vencido') OR (@estado = 'Devueltos' AND estado = 'Devuelto')); " &
            "SELECT COUNT(*) AS total, COUNT(DISTINCT id_usuario) AS lectores, COUNT(DISTINCT id_libro) AS libros, " &
            "COALESCE(SUM(CASE WHEN estado IN ('Vigente','Vencido') THEN 1 ELSE 0 END),0) AS activos, " &
            "COALESCE(SUM(CASE WHEN estado = 'Vencido' THEN 1 ELSE 0 END),0) AS vencidos, " &
            "COALESCE(SUM(CASE WHEN estado = 'Devuelto' THEN 1 ELSE 0 END),0) AS devueltos, " &
            "COALESCE(SUM(CASE WHEN estado = 'Por revisar' THEN 1 ELSE 0 END),0) AS revisar FROM #Periodo; " &
            "SELECT COUNT(*) FROM Ejemplar e INNER JOIN Libro l ON l.id_libro = e.id_libro " &
            "WHERE e.estado_ejemplar = 1 AND l.estado_libro = 1 " &
            "AND (@categoria = 0 OR EXISTS (SELECT 1 FROM DetalleCategoria dc WHERE dc.id_libro = e.id_libro AND dc.id_categoria = @categoria)) " &
            "AND NOT EXISTS (SELECT 1 FROM Prestamo p WHERE p.id_ejemplar = e.id_ejemplar AND " & ejemplarDAO.PrestamoOcupaEjemplarSql & "); " &
            "SELECT COUNT(*) FROM Prestamo p INNER JOIN Ejemplar e ON e.id_ejemplar = p.id_ejemplar " &
            "WHERE UPPER(LTRIM(RTRIM(p.estado_prestamo))) = 'DEVUELTO' AND p.fecha_retorno_prestamo = @hoy " &
            "AND (@categoria = 0 OR EXISTS (SELECT 1 FROM DetalleCategoria dc WHERE dc.id_libro = e.id_libro AND dc.id_categoria = @categoria)); " &
            "SELECT COUNT(*) FROM Usuario u INNER JOIN RolUsuario r ON r.id_rol_usuario = u.id_rol_usuario " &
            "WHERE UPPER(LTRIM(RTRIM(u.estado_usuario))) = 'ACTIVO' AND UPPER(LTRIM(RTRIM(r.nombre_rol_usuario))) = 'ESTUDIANTE'; " &
            "SELECT COUNT(*) FROM Libro l WHERE l.estado_libro = 1 " &
            "AND (@categoria = 0 OR EXISTS (SELECT 1 FROM DetalleCategoria dc WHERE dc.id_libro = l.id_libro AND dc.id_categoria = @categoria)); " &
            "SELECT CONVERT(char(7),fecha_inicio_prestamo,120) AS etiqueta, COUNT(*) AS cantidad " &
            "FROM #Periodo GROUP BY CONVERT(char(7),fecha_inicio_prestamo,120) ORDER BY etiqueta; " &
            "SELECT COALESCE(c.nombre_categoria,'Sin categoría') AS etiqueta, COUNT(DISTINCT p.id_prestamo) AS cantidad " &
            "FROM #Periodo p LEFT JOIN DetalleCategoria dc ON dc.id_libro = p.id_libro " &
            "LEFT JOIN Categoria c ON c.id_categoria = dc.id_categoria " &
            "WHERE @categoria = 0 OR c.id_categoria = @categoria " &
            "GROUP BY c.id_categoria, c.nombre_categoria ORDER BY cantidad DESC, etiqueta; " &
            "SELECT TOP (8) id_prestamo, lector, titulo_libro, fecha_fin_prestamo, estado " &
            "FROM #Periodo WHERE estado IN ('Vigente','Vencido') ORDER BY fecha_fin_prestamo, id_prestamo;"
        Using cn = Conexion.ObtenerInstancia().CrearConexionIndependiente(), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@desde", SqlDbType.Date).Value = desde.Date
            cmd.Parameters.Add("@hasta", SqlDbType.Date).Value = hasta.Date
            cmd.Parameters.Add("@hoy", SqlDbType.Date).Value = hoy.Date
            cmd.Parameters.Add("@categoria", SqlDbType.Int).Value = idCategoria
            cmd.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = estado
            Using rs = cmd.ExecuteReader()
                rs.Read()
                resultado.TotalPrestamos = CInt(rs("total"))
                resultado.Activos = CInt(rs("activos"))
                resultado.Vencidos = CInt(rs("vencidos"))
                resultado.Devueltos = CInt(rs("devueltos"))
                resultado.PorRevisar = CInt(rs("revisar"))
                resultado.LectoresAtendidos = CInt(rs("lectores"))
                resultado.LibrosPrestados = CInt(rs("libros"))
                rs.NextResult() : rs.Read() : resultado.EjemplaresDisponibles = rs.GetInt32(0)
                rs.NextResult() : rs.Read() : resultado.DevolucionesHoy = rs.GetInt32(0)
                rs.NextResult() : rs.Read() : resultado.LectoresActivos = rs.GetInt32(0)
                rs.NextResult() : rs.Read() : resultado.LibrosHabilitados = rs.GetInt32(0)
                rs.NextResult()
                While rs.Read()
                    resultado.PorMes.Add(New DatoGrafico With {.Etiqueta = CStr(rs("etiqueta")), .Cantidad = CInt(rs("cantidad"))})
                End While
                rs.NextResult()
                While rs.Read()
                    resultado.PorCategoria.Add(New DatoGrafico With {.Etiqueta = CStr(rs("etiqueta")), .Cantidad = CInt(rs("cantidad"))})
                End While
                rs.NextResult()
                While rs.Read()
                    resultado.Pendientes.Add(New PendienteDashboard With {
                        .IdPrestamo = CInt(rs("id_prestamo")), .Lector = CStr(rs("lector")), .Libro = CStr(rs("titulo_libro")),
                        .FechaLimite = CDate(rs("fecha_fin_prestamo")), .Estado = CStr(rs("estado"))})
                End While
            End Using
        End Using
        Return resultado
    End Function
End Class
