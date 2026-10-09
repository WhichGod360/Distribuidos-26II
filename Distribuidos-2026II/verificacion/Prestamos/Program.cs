using System.Reflection;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using capaDatos;
using capaNegocio;
using capaInterfaz;

internal static partial class Program
{
    private static int checks;

    [STAThread]
    private static int Main(string[] args)
    {
        try
        {
            using var database = args.Contains("--sql-integracion") ? new TemporaryDatabase() : null;
            var today = DateTime.Today;
            var start = new DateTime(2026, 8, 1);
            var limit = new DateTime(2026, 8, 8);
            var reference = new DateTime(2026, 8, 20);
            Check(prestamoNegocio.CalcularDiasRetraso(start, limit, new(2026, 8, 7), reference) == 0, "Devolución anticipada del script: 0 días");
            Check(prestamoNegocio.CalcularDiasRetraso(start, limit, limit, reference) == 0, "Devolución en la fecha límite: 0 días");
            Check(prestamoNegocio.CalcularDiasRetraso(start, limit, new(2026, 8, 13), reference) == 5, "Devolución tardía del script: 5 días");
            Check(prestamoNegocio.CalcularDiasRetraso(new(2024, 2, 28), new(2024, 2, 29), new(2024, 3, 1), new(2024, 3, 1)) == 1, "Retraso durante año bisiesto");
            Reject(() => prestamoNegocio.CalcularDiasRetraso(start, limit, start.AddDays(-1), reference), "Devolución anterior al inicio");
            Reject(() => prestamoNegocio.CalcularDiasRetraso(start, limit, reference.AddDays(1), reference), "Devolución futura");
            Reject(() => prestamoNegocio.ValidarFechasPrestamo(start, start, reference), "Límite igual al inicio, según CHECK del esquema");
            Reject(() => prestamoNegocio.ValidarFechasPrestamo(start, start.AddDays(-1), reference), "Límite anterior al inicio");
            Reject(() => prestamoNegocio.ValidarFechasPrestamo(reference.AddDays(1), reference.AddDays(2), reference), "Inicio futuro");
            var service = new prestamoNegocio();
            Reject(() => service.registrar(0, 2, 1, today, today.AddDays(1)), "Registro sin lector");
            Reject(() => service.registrar(3, 0, 1, today, today.AddDays(1)), "Registro sin sesión de bibliotecario");
            Reject(() => service.registrar(3, 2, 0, today, today.AddDays(1)), "Registro sin ejemplar");
            Reject(() => service.registrar(3, 2, 1, today, today), "Alta inválida se rechaza antes de acceder a SQL");
            Reject(() => service.devolver(1, 2, today.AddDays(1)), "Devolución futura se rechaza antes de acceder a SQL");
            Reject(() => service.listar("Pendiente", ""), "No se agrega filtro con estado no documentado");

            var loan = Loan(1, today);
            Check(loan.EstaActivo && !loan.EstaVencido(today), "Vence hoy: activo, todavía no vencido");
            Check(loan.EstaVencido(today.AddDays(1)), "Vence ayer: vencido calculado");
            Check(loan.EstadoParaMostrar(today.AddDays(1)) == "Vencido" && loan.EstadoPrestamo == "Activo", "Mostrar Vencido conserva el estado persistido");
            loan.EstadoPrestamo = " ACTIVO ";
            Check(loan.EstaActivo, "Compatibilidad con mayúsculas y espacios del código anterior");
            loan.FechaRetorno = today;
            Check(!loan.EstaActivo && !loan.EstaVencido(today.AddDays(1)), "Fecha de retorno impide otra devolución desde la interfaz");
            loan.EstadoPrestamo = "Devuelto";
            Check(loan.EstadoParaMostrar(today.AddDays(1)) == "Devuelto", "Devuelto sigue devuelto después del vencimiento");
            loan.FechaRetorno = null;
            loan.EstadoPrestamo = "Pendiente";
            Check(!loan.EstaActivo, "Estados antiguos requieren revisión explícita");

            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VerifyForms(today);
            VerifyDesignerForms();
            Console.WriteLine($"RESULTADO: {checks} comprobaciones correctas sin escrituras en SQL.");
            if (args.Contains("--sql-lectura")) ProbeSql();
            if (database is not null)
            {
                VerifyLoanPolicies();
                VerifyDashboardAndReader();
                VerifySqlOperations();
            }
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("ERROR: " + ex);
            return 1;
        }
    }

    private static Prestamo Loan(int id, DateTime limit) => new()
    {
        IdPrestamo = id, IdUsuario = 3, IdBibliotecario = 2, IdEjemplar = id + 3,
        IdLibro = 2, NombreLector = "Altair Lachos Briones", DniLector = "70000001",
        CorreoLector = "altair.lachos@usat.pe", NombreBibliotecario = "Maria Torres Vega",
        TituloLibro = "Clean Code", FechaInicio = limit.AddDays(-7), FechaFin = limit,
        EstadoPrestamo = Prestamo.EstadoActivo
    };

    private static void VerifyForms(DateTime today)
    {
        using var list = new frmPrestamos(2, "Maria Torres Vega", "Bibliotecario");
        var overdue = Loan(2, today.AddDays(-1));
        var returned = Loan(3, today.AddDays(-2));
        returned.FechaRetorno = today;
        returned.EstadoPrestamo = Prestamo.EstadoDevuelto;
        returned.DiasRetraso = 2;
        Field(list, "datos").SetValue(list, new List<Prestamo> { Loan(1, today), overdue, returned });
        Filter(list);
        var grid = (DataGridView)Field(list, "tabla").GetValue(list)!;
        var state = (ComboBox)Field(list, "filtroEstado").GetValue(list)!;
        var search = (TextBox)Field(list, "buscar").GetValue(list)!;
        Check(((List<Prestamo>)grid.DataSource!).Count == 3, "Listado Todos");
        state.SelectedItem = "Activos";
        Check(((List<Prestamo>)grid.DataSource!).Count == 2, "Activos incluye vencidos");
        state.SelectedItem = "Vencidos";
        Check(((List<Prestamo>)grid.DataSource!).Single().IdPrestamo == 2, "Filtro Vencidos");
        state.SelectedItem = "Devueltos";
        Check(((List<Prestamo>)grid.DataSource!).Single().IdPrestamo == 3, "Filtro Devueltos");
        state.SelectedItem = "Todos";
        search.Text = "70000001";
        Check(((List<Prestamo>)grid.DataSource!).Count == 3, "Filtro por DNI");
        search.Text = "lector inexistente";
        Check(((List<Prestamo>)grid.DataSource!).Count == 0, "Búsqueda sin resultados limpia la selección");
        search.Clear();
        Check(grid.Columns["FechaRetorno"].DefaultCellStyle.Format == "dd/MM/yyyy", "Formato de fechas de retorno nullable");
        Render(list, "listado.png", new(1100, 720));
        using var editor = new frmPrestamoDetalle(2, "Maria Torres Vega");
        var automaticLimit = (DateTimePicker)Field(editor, "limite").GetValue(editor)!;
        Check(!automaticLimit.Enabled && !automaticLimit.ShowCheckBox && automaticLimit.Value.Date == today.AddDays(5), "Fecha límite automática de cinco días sin edición manual");
        var initialDate = (DateTimePicker)Field(editor, "inicio").GetValue(editor)!;
        initialDate.Value = today.AddDays(-1);
        Check(automaticLimit.Value.Date == today.AddDays(4), "Cambiar inicio recalcula la fecha límite");
        Render(editor, "registro.png", editor.ClientSize);
        using var giveBack = new frmPrestamoDevolucion(overdue, 2, "Maria Torres Vega");
        Check(((Label)Field(giveBack, "retraso").GetValue(giveBack)!).Text == "1", "Vista previa de retraso en devolución");
        Render(giveBack, "devolucion.png", giveBack.ClientSize);
        using var reader = new frmPrestamos(3, "Altair Lachos Briones", "Estudiante");
        Check(!((Button)Field(reader, "btnNuevo").GetValue(reader)!).Enabled, "Estudiante no registra préstamos");
        using var missingSession = new frmPrestamos(0, "Invitado", "Bibliotecario");
        Check(!((Button)Field(missingSession, "btnNuevo").GetValue(missingSession)!).Enabled, "No se registra sin ID autenticado");
    }

    private static FieldInfo Field(object obj, string name) => obj.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance) ?? obj.GetType().GetField("_" + name, BindingFlags.NonPublic | BindingFlags.Instance)!;
    private static void Filter(frmPrestamos form) => typeof(frmPrestamos).GetMethod("Filtrar", BindingFlags.NonPublic | BindingFlags.Instance)!.Invoke(form, null);

    private static void Render(Form form, string file, Size size)
    {
        Directory.CreateDirectory("verificacion/Prestamos/evidencia");
        form.ClientSize = size;
        // Renderizar el contenido desprendido evita mostrar ventanas y disparar Load/consultas.
        var content = form.Controls[0];
        form.Controls.Remove(content);
        using var surface = new Panel { Size = size, BackColor = Color.White, Font = form.Font };
        surface.Controls.Add(content);
        surface.CreateControl();
        content.CreateControl();
        surface.PerformLayout();
        using var bitmap = new Bitmap(size.Width, size.Height);
        surface.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
        bitmap.Save(Path.Combine("verificacion/Prestamos/evidencia", file));
    }

    private static void ProbeSql()
    {
        try
        {
            using var cn = capaConexion.Conexion.ObtenerInstancia().CrearConexionIndependiente();
            Console.WriteLine("SQL DISPONIBLE: conexión abierta. Se comprobarán solo consultas.");
            var service = new prestamoNegocio();
            var readers = service.buscarLectores("");
            Check(readers.All(u => u.EstadoUsuario.Trim().Equals("Activo", StringComparison.OrdinalIgnoreCase) && u.NombreRol.Trim().Equals("Estudiante", StringComparison.OrdinalIgnoreCase)), "Consulta solo devuelve estudiantes activos");
            foreach (var filter in new[] { "Todos", "Activos", "Vencidos", "Devueltos" })
                Console.WriteLine($"SQL lectura {filter}: {service.listar(filter, "").Count} préstamo(s)");
            Console.WriteLine("No se ejecutaron altas, devoluciones ni concurrencia en SQL.");
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            Console.WriteLine($"SQL NO DISPONIBLE O CONSULTA FALLIDA ({ex.Number}): {ex.Message}");
            Console.WriteLine("Altas, devoluciones y concurrencia en la base real SIN VERIFICAR.");
        }
    }

    private static void Check(bool condition, string name)
    {
        if (!condition) throw new InvalidOperationException(name);
        checks++;
        Console.WriteLine("OK: " + name);
    }

    private static void Reject(Action action, string name)
    {
        try { action(); }
        catch (ArgumentException) { Check(true, name); return; }
        throw new InvalidOperationException("Se aceptó: " + name);
    }

    private static void RejectOperation(Action action, string name)
    {
        try { action(); }
        catch (InvalidOperationException) { Check(true, name); return; }
        catch (ArgumentException) { Check(true, name); return; }
        throw new InvalidOperationException("Se aceptó: " + name);
    }

    private static void ExecuteSql(string sql)
    {
        using var cn = capaConexion.Conexion.ObtenerInstancia().CrearConexionIndependiente();
        using var cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
    }

    private static int ScalarSql(string sql)
    {
        using var cn = capaConexion.Conexion.ObtenerInstancia().CrearConexionIndependiente();
        using var cmd = new SqlCommand(sql, cn);
        return Convert.ToInt32(cmd.ExecuteScalar());
    }

    private static void VerifySqlOperations()
    {
        Console.WriteLine("INTEGRACIÓN SQL: exclusivamente en la base temporal de verificación.");
        var service = new prestamoNegocio();
        var copies = new ejemplarNegocio();
        var books = new libroNegocio();
        var today = DateTime.Today;
        int librarian = ScalarSql("SELECT u.id_usuario FROM Usuario u INNER JOIN RolUsuario r ON r.id_rol_usuario=u.id_rol_usuario WHERE r.nombre_rol_usuario='Bibliotecario'");
        int reader = service.buscarLectores("70000001").Single().IdUsuario;
        int reader2 = service.buscarLectores("70000002").Single().IdUsuario;
        var book = books.listarDisponibles().First();
        var copy = copies.listarDisponiblesPorLibro(book.IdLibro).First();
        Check(service.buscarLectores("Altair").Single().IdUsuario == reader, "SQL busca por nombre");
        Check(service.buscarLectores("Lachos").Single().IdUsuario == reader, "SQL busca por apellido");
        Check(service.buscarLectores("altair.lachos@usat.pe").Single().IdUsuario == reader, "SQL busca por correo");
        Check(service.buscarLectores("10000002").Count == 0, "SQL excluye bibliotecarios de la búsqueda de lectores");
        ExecuteSql($"UPDATE Usuario SET estado_usuario='Inactivo' WHERE id_usuario={reader}");
        Check(service.buscarLectores("70000001").Count == 0, "SQL excluye lectores inactivos");
        RejectOperation(() => service.registrar(reader, librarian, copy.IdEjemplar, today.AddDays(-7), today.AddDays(-2)), "SQL revalida lector inactivo en el alta");
        ExecuteSql($"UPDATE Usuario SET estado_usuario='Activo' WHERE id_usuario={reader}; UPDATE Usuario SET estado_usuario='Inactivo' WHERE id_usuario={librarian}");
        RejectOperation(() => service.registrar(reader, librarian, copy.IdEjemplar, today.AddDays(-7), today.AddDays(-2)), "SQL revalida bibliotecario inactivo");
        ExecuteSql($"UPDATE Usuario SET estado_usuario='Activo' WHERE id_usuario={librarian}");
        RejectOperation(() => service.registrar(librarian, librarian, copy.IdEjemplar, today.AddDays(-7), today.AddDays(-2)), "SQL exige rol Estudiante al lector");
        RejectOperation(() => service.registrar(reader, reader2, copy.IdEjemplar, today.AddDays(-7), today.AddDays(-2)), "SQL exige rol Bibliotecario al operador");
        ExecuteSql($"UPDATE Libro SET estado_libro=0 WHERE id_libro={book.IdLibro}");
        Check(copies.listarDisponiblesPorLibro(book.IdLibro).Count == 0, "SQL no ofrece copias de libro inactivo");
        RejectOperation(() => service.registrar(reader, librarian, copy.IdEjemplar, today.AddDays(-7), today.AddDays(-2)), "SQL rechaza libro inactivo");
        ExecuteSql($"UPDATE Libro SET estado_libro=1 WHERE id_libro={book.IdLibro}; UPDATE Ejemplar SET estado_ejemplar=0 WHERE id_ejemplar={copy.IdEjemplar}");
        RejectOperation(() => service.registrar(reader, librarian, copy.IdEjemplar, today.AddDays(-7), today.AddDays(-2)), "SQL rechaza ejemplar inactivo");
        ExecuteSql($"UPDATE Ejemplar SET estado_ejemplar=1 WHERE id_ejemplar={copy.IdEjemplar}");

        int loan = service.registrar(reader, librarian, copy.IdEjemplar, today.AddDays(-7), today.AddDays(-2));
        var stored = service.listar("Vencidos", loan.ToString()).Single(p => p.IdPrestamo == loan);
        Check(stored.IdUsuario == reader && stored.IdBibliotecario == librarian && stored.IdEjemplar == copy.IdEjemplar, "SQL conserva lector, ID bibliotecario y copia");
        Check(stored.EstadoPrestamo == "Activo" && stored.FechaRetorno is null && stored.DiasRetraso == 0, "SQL registra Activo sin estado Vencido persistido");
        Check(!copies.listarDisponiblesPorLibro(book.IdLibro).Any(e => e.IdEjemplar == copy.IdEjemplar), "SQL reserva la copia");
        RejectOperation(() => service.registrar(reader2, librarian, copy.IdEjemplar, today.AddDays(-7), today.AddDays(-2)), "SQL rechaza copia ya prestada");
        Check(!copies.cambiarEstado(book.IdLibro, copy.IdEjemplar, false), "SQL bloquea desactivación de copia prestada");
        RejectOperation(() => books.eliminarLibro(book.IdLibro), "SQL bloquea desactivación de libro relacionado");
        RejectOperation(() => service.devolver(loan, librarian, today.AddDays(-8)), "SQL rechaza retorno anterior al inicio");
        int days = service.devolver(loan, librarian, today);
        stored = service.listar("Devueltos", loan.ToString()).Single(p => p.IdPrestamo == loan);
        Check(days == 2 && stored.DiasRetraso == 2 && stored.FechaRetorno == today && stored.EstadoPrestamo == "Devuelto", "SQL guarda fecha real y 2 días de retraso");
        RejectOperation(() => service.devolver(loan, librarian, today), "SQL rechaza doble devolución");
        Check(copies.listarDisponiblesPorLibro(book.IdLibro).Any(e => e.IdEjemplar == copy.IdEjemplar), "SQL libera la disponibilidad al devolver");
        Check(!copies.cambiarEstado(book.IdLibro, copy.IdEjemplar, false), "SQL conserva protección de ejemplar con historial devuelto");
        RejectOperation(() => books.eliminarLibro(book.IdLibro), "SQL conserva protección de libro con historial devuelto");
        Check(ScalarSql("SELECT COUNT(*) FROM Penalizacion") == 1 && ScalarSql("SELECT COUNT(*) FROM DetallePenalizacion") == 1, "SQL no genera penalizaciones ni cambia su semántica");

        int early = service.registrar(reader, librarian, copy.IdEjemplar, today.AddDays(-1), today.AddDays(4));
        Check(service.devolver(early, librarian, today) == 0, "SQL devolución anticipada guarda cero");
        int onTime = service.registrar(reader, librarian, copy.IdEjemplar, today.AddDays(-5), today);
        Check(service.devolver(onTime, librarian, today) == 0, "SQL devolución en límite guarda cero");

        for (int attempt = 0; attempt < 3; attempt++)
        {
            using var gate = new ManualResetEventSlim(false);
            Task<(int id, Exception? error)> Borrow(int borrower) => Task.Run(() =>
            {
                gate.Wait();
                try { return (new prestamoNegocio().registrar(borrower, librarian, copy.IdEjemplar, today, today.AddDays(5)), (Exception?)null); }
                catch (Exception ex) { return (0, (Exception?)ex); }
            });
            var one = Borrow(reader);
            var two = Borrow(reader2);
            gate.Set();
            Task.WaitAll(one, two);
            var results = new[] { one.Result, two.Result };
            Check(results.Count(r => r.id > 0) == 1 && results.Count(r => r.error is InvalidOperationException) == 1, $"SQL carrera {attempt + 1}: una sola operación presta la copia");
            Check(ScalarSql($"SELECT COUNT(*) FROM Prestamo WHERE id_ejemplar={copy.IdEjemplar} AND fecha_retorno_prestamo IS NULL") == 1, "SQL mantiene una sola fila sin devolver por copia");
            service.devolver(results.Single(r => r.id > 0).id, librarian, today);
        }
        Console.WriteLine($"RESULTADO FINAL: {checks} comprobaciones correctas, incluidas operaciones y concurrencia en SQL temporal.");
    }

    private sealed class TemporaryDatabase : IDisposable
    {
        private readonly string name = "Biblioteca_Verificacion_" + Guid.NewGuid().ToString("N");
        private readonly string master;
        private readonly string? previous = Environment.GetEnvironmentVariable("BIBLIOTECA_CONNECTION_STRING");

        public TemporaryDatabase()
        {
            var builder = new SqlConnectionStringBuilder(previous ?? @"Data Source=.\SQLEXPRESS;Initial Catalog=distribuidos-II;Integrated Security=SSPI;TrustServerCertificate=True;") { InitialCatalog = "master" };
            master = builder.ConnectionString;
            using (var cn = new SqlConnection(master))
            {
                cn.Open();
                using var cmd = new SqlCommand($"CREATE DATABASE [{name}]", cn);
                cmd.ExecuteNonQuery();
            }
            try
            {
                builder.InitialCatalog = name;
                Environment.SetEnvironmentVariable("BIBLIOTECA_CONNECTION_STRING", builder.ConnectionString);
                using var cn = new SqlConnection(builder.ConnectionString);
                cn.Open();
                string schema = File.ReadAllText(Path.GetFullPath("../bd_biblioteca"));
                foreach (string batch in Regex.Split(schema, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase))
                {
                    if (string.IsNullOrWhiteSpace(batch)) continue;
                    using var cmd = new SqlCommand(batch, cn);
                    cmd.ExecuteNonQuery();
                }
                var service = new prestamoNegocio();
                RejectMessage(() => service.registrar(3, 2, 1, DateTime.Today), "migración 001", "Base sin migración rechaza el préstamo con explicación");
                string migration = File.ReadAllText("migraciones/001_estado_pago_detalle_penalizacion.sql");
                foreach (string batch in Regex.Split(migration, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase))
                {
                    if (string.IsNullOrWhiteSpace(batch)) continue;
                    using var cmd = new SqlCommand(batch, cn);
                    cmd.ExecuteNonQuery();
                }
                Check(true, "Migración esencial ejecutada una vez solo en SQL temporal");
                Console.WriteLine("Base temporal creada con bd_biblioteca; se eliminará al terminar.");
            }
            catch { Dispose(); throw; }
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable("BIBLIOTECA_CONNECTION_STRING", previous);
            SqlConnection.ClearAllPools();
            if (!Regex.IsMatch(name, @"^Biblioteca_Verificacion_[a-f0-9]{32}$")) throw new InvalidOperationException("Nombre temporal inválido.");
            using var cn = new SqlConnection(master);
            cn.Open();
            using var cmd = new SqlCommand($"ALTER DATABASE [{name}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{name}]", cn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Base temporal eliminada. La base distribuidos-II no fue modificada.");
        }
    }
}
