using capaDatos;
using capaNegocio;
using capaInterfaz;

internal static partial class Program
{
    private static void RejectMessage(Action action, string expected, string name)
    {
        try { action(); }
        catch (InvalidOperationException ex)
        {
            Check(ex.Message.Contains(expected, StringComparison.OrdinalIgnoreCase), name + ": " + ex.Message);
            return;
        }
        throw new InvalidOperationException("Se aceptó: " + name);
    }

    private static void VerifyLoanPolicies()
    {
        var today = DateTime.Today;
        var loans = new prestamoNegocio();
        var details = new detallePenalizacionNegocio();
        int librarian = ScalarSql("SELECT u.id_usuario FROM Usuario u JOIN RolUsuario r ON r.id_rol_usuario=u.id_rol_usuario WHERE r.nombre_rol_usuario='Bibliotecario'");
        int reader = loans.buscarLectores("70000001").Single().IdUsuario;
        int debtor = loans.buscarLectores("70000002").Single().IdUsuario;
        var copies = new libroNegocio().listarDisponibles().SelectMany(b => new ejemplarNegocio().listarDisponiblesPorLibro(b.IdLibro)).ToArray();
        var one = copies[0];
        var two = copies.First(e => e.IdLibro != one.IdLibro);
        Check(PoliticaPrestamo.FechaLimite(new(2026, 1, 28)) == new DateTime(2026, 2, 2), "Cinco días atraviesan el cambio de mes");
        Reject(() => prestamoNegocio.ValidarFechasPrestamo(today, today.AddDays(4), today), "Rechaza plazo de cuatro días");
        Reject(() => prestamoNegocio.ValidarFechasPrestamo(today, today.AddDays(6), today), "Rechaza plazo de seis días");
        Reject(() => new capaDAO.prestamoDAO().registrar(reader, librarian, one.IdEjemplar, today, today.AddDays(6)), "DAO también impide saltarse el plazo");

        var legacy = details.listar(0).Single();
        Check(legacy.EstadoPago == DetallePenalizacion.PagoPorRevisar, "Migración conserva el pago histórico como desconocido");
        Check(ScalarSql("SELECT CONVERT(int,estado_penalizacion) FROM Penalizacion WHERE id_penalizacion=1") == 1, "Migración conserva habilitación del catálogo");
        RejectMessage(() => loans.registrar(debtor, librarian, one.IdEjemplar, today), "por revisar", "Pago histórico exige revisión explícita");
        details.actualizarDetalle(legacy.IdDetallePenalizacion, legacy.DescripcionDetallePenalizacion, legacy.IdPenalizacion, legacy.IdPrestamo, DetallePenalizacion.PagoPagada);
        using (var editor = new frmDetallePenalizacionEditar(details.listar(0).Single(), legacy.IdPenalizacion))
        {
            LoadForm(editor);
            Check((string)ControlOf<ComboBox>(editor, "cboPago").SelectedItem! == "Pagada", "Editor muestra el pago separado del catálogo");
            Render(editor, "pago-penalizacion.png", editor.ClientSize);
        }
        details.actualizarDetalle(legacy.IdDetallePenalizacion, "Revisión manual en prueba temporal", legacy.IdPenalizacion, legacy.IdPrestamo);
        Check(details.listar(0).Single().EstadoPago == DetallePenalizacion.PagoPagada, "Editar descripción sin pago conserva el estado pagado");

        int loan = loans.registrar(reader, librarian, one.IdEjemplar, today);
        var stored = loans.listarPorLector(reader).Single(p => p.IdPrestamo == loan);
        Check(stored.FechaFin == today.AddDays(5) && stored.IdBibliotecario == librarian, "Alta calcula cinco días y conserva bibliotecario");
        RejectMessage(() => loans.registrar(reader, librarian, two.IdEjemplar, today), "máximo es uno", "Un préstamo vigente bloquea otra copia");
        Check(loans.devolver(loan, librarian, today) == 0, "Devolución anticipada conserva retraso cero");
        RejectMessage(() => loans.devolver(loan, librarian, today), "ya fue devuelto", "Rechaza segunda devolución");
        int overdue = loans.registrar(reader, librarian, one.IdEjemplar, today.AddDays(-6));
        RejectMessage(() => loans.registrar(reader, librarian, two.IdEjemplar, today), "máximo es uno", "Un préstamo vencido también bloquea otra copia");
        Check(loans.devolver(overdue, librarian, today) == 1, "Devolución tardía calcula un día sin cambiar plazo");
        ExecuteSql($"DELETE FROM Prestamo WHERE id_prestamo IN ({loan},{overdue})");

        int historicalLoan = loans.listarPorLector(reader).Single().IdPrestamo;
        Check(details.agregarDetalle("Penalización manual de prueba", legacy.IdPenalizacion, historicalLoan), "Asignación manual crea la penalización aplicada");
        var penalty = details.listar(0).Single(d => d.IdPrestamo == historicalLoan);
        Check(penalty.EstadoPago == DetallePenalizacion.PagoPendiente, "Nueva penalización tiene estado Pendiente explícito");
        RejectMessage(() => loans.registrar(reader, librarian, one.IdEjemplar, today), "pendiente de pago", "Penalización pendiente bloquea otro préstamo");
        ExecuteSql($"UPDATE Penalizacion SET estado_penalizacion=0 WHERE id_penalizacion={legacy.IdPenalizacion}");
        RejectMessage(() => loans.registrar(reader, librarian, one.IdEjemplar, today), "pendiente de pago", "Desactivar tipo de catálogo no elimina una deuda pendiente");
        details.actualizarDetalle(penalty.IdDetallePenalizacion, penalty.DescripcionDetallePenalizacion, penalty.IdPenalizacion, penalty.IdPrestamo, DetallePenalizacion.PagoPagada);
        int afterPayment = loans.registrar(reader, librarian, one.IdEjemplar, today);
        Check(afterPayment > 0, "Penalización pagada permite préstamo aunque catálogo esté inactivo");
        loans.devolver(afterPayment, librarian, today);
        ExecuteSql($"DELETE FROM DetallePenalizacion WHERE id_detalle_penalizacion={penalty.IdDetallePenalizacion}; DELETE FROM Prestamo WHERE id_prestamo={afterPayment}; UPDATE Penalizacion SET estado_penalizacion=1 WHERE id_penalizacion={legacy.IdPenalizacion}");
        Reject(() => details.agregarDetalle("", 1, historicalLoan, "Activo"), "Activo no es un estado de pago válido");

        // El INSERT sin estado usa Pendiente; las filas anteriores continúan teniendo su valor revisado.
        ExecuteSql($"INSERT INTO DetallePenalizacion(id_penalizacion,id_prestamo) VALUES ({legacy.IdPenalizacion},{historicalLoan})");
        var defaultPayment = details.listar(0).Single(d => d.IdPrestamo == historicalLoan);
        Check(defaultPayment.EstadoPago == DetallePenalizacion.PagoPendiente, "Default SQL para nuevas filas es Pendiente");
        try
        {
            ExecuteSql($"UPDATE DetallePenalizacion SET estado_pago_detalle='Activo' WHERE id_detalle_penalizacion={defaultPayment.IdDetallePenalizacion}");
            throw new InvalidOperationException("El esquema aceptó Activo como pago.");
        }
        catch (System.Data.SqlClient.SqlException ex) when (ex.Number == 547) { Check(true, "CHECK SQL impide estados de pago inválidos"); }
        ExecuteSql($"DELETE FROM DetallePenalizacion WHERE id_detalle_penalizacion={defaultPayment.IdDetallePenalizacion}");

        for (int attempt = 0; attempt < 3; attempt++)
        {
            using var gate = new ManualResetEventSlim(false);
            Task<(int id, Exception? error)> Borrow(int copy) => Task.Run(() =>
            {
                gate.Wait();
                try { return (new prestamoNegocio().registrar(reader, librarian, copy, today), (Exception?)null); }
                catch (Exception ex) { return (0, ex); }
            });
            var first = Borrow(one.IdEjemplar);
            var second = Borrow(two.IdEjemplar);
            gate.Set();
            Task.WaitAll(first, second);
            var results = new[] { first.Result, second.Result };
            Check(results.Count(r => r.id > 0) == 1 && results.Count(r => r.error is InvalidOperationException) == 1, $"Carrera lector {attempt + 1}: solo obtiene una copia de dos libros distintos");
            Check(ScalarSql($"SELECT COUNT(*) FROM Prestamo WHERE id_usuario={reader} AND fecha_retorno_prestamo IS NULL") == 1, "Transacción mantiene máximo de una copia por lector");
            int id = results.Single(r => r.id > 0).id;
            loans.devolver(id, librarian, today);
            ExecuteSql($"DELETE FROM Prestamo WHERE id_prestamo={id}");
        }
    }
}
