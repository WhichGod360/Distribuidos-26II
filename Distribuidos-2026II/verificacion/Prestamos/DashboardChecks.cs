using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using capaDatos;
using capaNegocio;
using capaInterfaz;

internal static partial class Program
{
    private static T ControlOf<T>(object form, string name) where T : Control => (T)Field(form, name).GetValue(form)!;
    private static IEnumerable<Control> Descendants(Control control)
    {
        foreach (Control child in control.Controls)
        {
            yield return child;
            foreach (var descendant in Descendants(child)) yield return descendant;
        }
    }

    private static void LoadForm(Form form)
    {
        _ = form.Handle;
        typeof(Form).GetMethod("OnLoad", BindingFlags.NonPublic | BindingFlags.Instance)!.Invoke(form, new object[] { EventArgs.Empty });
    }

    private static void PumpUntil(Func<bool> ready)
    {
        var timeout = DateTime.UtcNow.AddSeconds(25);
        while (!ready())
        {
            if (DateTime.UtcNow >= timeout) throw new TimeoutException("La interfaz no terminó de cargar.");
            Application.DoEvents();
            Thread.Sleep(10);
        }
        Application.DoEvents();
    }

    private static void VerifyDesignerForms()
    {
        var previous = LicenseManager.CurrentContext;
        LicenseManager.CurrentContext = new DesigntimeLicenseContext();
        try
        {
            var types = new[] { typeof(frmPrincipal), typeof(frmBuscarLector), typeof(frmPrestamos), typeof(frmPrestamoDetalle),
                typeof(frmPrestamoDevolucion), typeof(frmAutor), typeof(frmAutorDetalle), typeof(FrmCategoria),
                typeof(frmAgregarCategoria), typeof(frmEditarCategoria), typeof(FrmLibros), typeof(FrmLibros).Assembly.GetType("capaInterfaz.FrmLibroDetalle")!,
                typeof(frmEjemplares), typeof(frmEjemplarDetalle), typeof(frmPenalizacion), typeof(frmPenalizacionEditar),
                typeof(frmDetallePenalizacion), typeof(frmDetallePenalizacionEditar), typeof(frmSeleccionCatalogo) };
            foreach (var type in types)
            {
                using var form = (Form)Activator.CreateInstance(type)!;
                LoadForm(form);
                var controls = Descendants(form).ToArray();
                Check(controls.OfType<Button>().Any() && controls.OfType<Label>().Any() && controls.OfType<PictureBox>().Any(p => p.Image != null), type.Name + ": constructor vacío, controles e imagen en diseño");
                Render(form, "diseno-" + type.Name + ".png", form.ClientSize);
            }
        }
        finally { LicenseManager.CurrentContext = previous; }
    }

    private static void VerifyDashboardAndReader()
    {
        var dashboard = new dashboardNegocio();
        var loans = new prestamoNegocio();
        var today = DateTime.Today;
        var from = new DateTime(1900, 1, 1);
        var to = new DateTime(2099, 12, 31);
        var initial = dashboard.consultar(from, to, 0, "Todos");
        Check(initial.TotalPrestamos == ScalarSql("SELECT COUNT(*) FROM Prestamo"), "Dashboard: total coincide con SQL del script");
        Check(initial.Devueltos == 2 && initial.Activos == 0 && initial.Vencidos == 0, "Dashboard: estados reales de los préstamos iniciales");
        Check(initial.PorMes.Sum(x => x.Cantidad) == initial.TotalPrestamos, "Gráfico mensual corresponde al total consultado");
        Check(initial.PorCategoria.Single().Etiqueta == "Sin categoría", "Libros del script sin categorías no desaparecen");
        Reject(() => dashboard.consultar(today, today.AddDays(-1), 0, "Todos"), "Dashboard rechaza rango invertido");
        Reject(() => dashboard.consultar(from, to, 0, "Inventado"), "Dashboard rechaza estado desconocido");
        Check(dashboard.consultar(new(1900, 1, 1), new(1900, 1, 2), 0, "Todos").TotalPrestamos == 0, "Periodo vacío devuelve cero real");

        int librarian = ScalarSql("SELECT u.id_usuario FROM Usuario u JOIN RolUsuario r ON r.id_rol_usuario=u.id_rol_usuario WHERE r.nombre_rol_usuario='Bibliotecario'");
        var reader = loans.buscarLectores("70000001").Single();
        var book = new libroNegocio().listarDisponibles().First();
        var copy = new ejemplarNegocio().listarDisponiblesPorLibro(book.IdLibro).First();
        ExecuteSql("INSERT INTO Categoria(nombre_categoria,estado) VALUES ('Prueba dashboard A',1),('Prueba dashboard B',1)");
        int categoryA = ScalarSql("SELECT id_categoria FROM Categoria WHERE nombre_categoria='Prueba dashboard A'");
        int categoryB = ScalarSql("SELECT id_categoria FROM Categoria WHERE nombre_categoria='Prueba dashboard B'");
        ExecuteSql($"INSERT INTO DetalleCategoria(id_libro,id_categoria) VALUES ({book.IdLibro},{categoryA}),({book.IdLibro},{categoryB})");
        int loan = loans.registrar(reader.IdUsuario, librarian, copy.IdEjemplar, today.AddDays(-3), today.AddDays(-1));
        var current = dashboard.consultar(from, to, 0, "Todos");
        Check(current.TotalPrestamos == initial.TotalPrestamos + 1 && current.Activos == 1 && current.Vencidos == 1, "Dashboard cuenta vencidos dentro de activos sin duplicar por categorías");
        Check(current.EjemplaresDisponibles == initial.EjemplaresDisponibles - 1, "Dashboard reduce disponibilidad después del préstamo");
        Check(dashboard.consultar(from, to, categoryA, "Vencidos").Pendientes.Single().IdPrestamo == loan, "Filtros categoría y vencidos aplican a pendientes");
        Check(loans.listarPorLector(reader.IdUsuario).All(p => p.IdUsuario == reader.IdUsuario), "Historial consulta por ID exacto del lector");

        using (var detail = new frmPrestamoDetalle(librarian, "Bibliotecario de prueba", reader))
        {
            LoadForm(detail);
            Check(Convert.ToInt32(ControlOf<ComboBox>(detail, "lector").SelectedValue) == reader.IdUsuario, "Nuevo préstamo conserva el lector seleccionado");
            Check(!ControlOf<DateTimePicker>(detail, "limite").Checked, "Carga del editor no introduce un plazo automático");
        }

        using (var form = new frmPrincipal { IdUsuario = librarian, Usuario = "Bibliotecario de prueba", Rol = "Bibliotecario" })
        {
            LoadForm(form);
            PumpUntil(() => Field(form, "datos").GetValue(form) != null);
            Check(ControlOf<Label>(form, "lblNum1").Text == "1", "Interfaz dashboard muestra el vencido real");
            var number = ControlOf<Label>(form, "lblNum1");
            Check(number.Height >= TextRenderer.MeasureText(number.Text, number.Font).Height, "Tarjetas tienen altura para mostrar números completos");
            form.AbrirModulo("lectores");
            var views = (Dictionary<string, Form>)Field(form, "vistas").GetValue(form)!;
            var search = (frmBuscarLector)views["lectores"];
            LoadForm(search);
            ControlOf<TextBox>(search, "txtBuscar").Text = reader.NumeroDniUsuario;
            typeof(frmBuscarLector).GetMethod("Buscar_Click", BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(search, new object[] { search, EventArgs.Empty });
            PumpUntil(() => !(bool)Field(search, "buscando").GetValue(search)!);
            var readersGrid = ControlOf<DataGridView>(search, "tablaLectores");
            Check(((List<Usuario>)readersGrid.DataSource!).Single().IdUsuario == reader.IdUsuario, "Pantalla buscar lector carga resultado real");
            readersGrid.Rows[0].Selected = true;
            PumpUntil(() => ControlOf<DataGridView>(search, "tablaPrestamos").DataSource is List<Prestamo>);
            Check(ControlOf<Button>(search, "btnNuevo").Enabled, "Bibliotecario puede prestar al lector seleccionado");
            form.MostrarPrestamos("Vencidos", reader.IdUsuario, loan);
            var loanForm = (frmPrestamos)views["prestamos"];
            LoadForm(loanForm);
            Check(((List<Prestamo>)ControlOf<DataGridView>(loanForm, "tabla").DataSource!).Single().IdPrestamo == loan, "Navegación abre el préstamo exacto");
            foreach (var route in new[] { "libros", "autores", "categorias", "penalizaciones" })
            {
                form.AbrirModulo(route);
                LoadForm(views[route]);
                Check(views[route].Parent == ControlOf<Panel>(form, "pnlMain"), "Navegación central: " + route);
            }
            form.AbrirModulo("inicio");
            PumpUntil(() => !(bool)Field(form, "cargando").GetValue(form)!);
            Render(search, "lector-sql.png", new(1050, 720));
            Render(form, "dashboard-sql.png", new(1280, 950));
        }

        using (var admin = new frmPrincipal { IdUsuario = 1, Usuario = "Administrador de prueba", Rol = "Administrador" })
        {
            LoadForm(admin);
            PumpUntil(() => Field(admin, "datos").GetValue(admin) != null);
            Check(ControlOf<Button>(admin, "btnNuevoRapido").Text == "Gestionar autores", "Dashboard administrativo conserva permisos de préstamo existentes");
            Render(admin, "dashboard-admin.png", new(1280, 950));
        }

        using (var scaled = new frmPrincipal { IdUsuario = librarian, Usuario = "Bibliotecario de prueba", Rol = "Bibliotecario" })
        {
            LoadForm(scaled);
            PumpUntil(() => Field(scaled, "datos").GetValue(scaled) != null);
            scaled.Scale(new SizeF(1.25f, 1.25f));
            scaled.ClientSize = new Size(1366, 850);
            scaled.PerformLayout();
            Check(ControlOf<Panel>(scaled, "panelDashboard").AutoScroll, "Dashboard tiene desplazamiento para escala 125 %");
            Render(scaled, "dashboard-125.png", scaled.ClientSize);
        }

        loans.devolver(loan, librarian, today);
        var after = dashboard.consultar(from, to, 0, "Todos");
        Check(after.Activos == 0 && after.DevolucionesHoy == initial.DevolucionesHoy + 1 && after.EjemplaresDisponibles == initial.EjemplaresDisponibles, "Devolución actualiza contadores y disponibilidad");
        // Restaurar las filas de la prueba antes de la regresión del módulo de préstamos.
        ExecuteSql($"DELETE FROM Prestamo WHERE id_prestamo={loan}; DELETE FROM DetalleCategoria WHERE id_categoria IN ({categoryA},{categoryB}); DELETE FROM Categoria WHERE id_categoria IN ({categoryA},{categoryB})");
    }
}
