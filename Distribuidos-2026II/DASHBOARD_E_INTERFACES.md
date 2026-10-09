# Dashboard e interfaces de biblioteca

## Resultado

Se conserva la solución `Distribuidos-2026II.slnx` y sus cinco capas. El dashboard consulta SQL Server; no contiene series de ejemplo ni contadores simulados. El login conserva ID, nombre y rol. El registro de préstamos conserva el ID del bibliotecario autenticado.

El menú central abre Inicio, Buscar lectores, Préstamos, Libros y ejemplares, Autores, Categorías y Penalizaciones. Los ejemplares se abren desde un libro y los detalles de penalizaciones desde una penalización. Los botones del menú no anuncian módulos pendientes. No se implementaron módulos nuevos de usuarios, roles, reportes o configuración; los accesos anteriores sin flujo funcional no se ofrecen en este dashboard.

El bibliotecario dispone de Nuevo préstamo, Registrar devolución, Buscar lector y Consultar libros. El administrador tiene un resumen de préstamos, lectores atendidos, libros prestados y disponibilidad; sus primeros accesos son Autores y Categorías. Se conserva la regla existente de registrar préstamos y devoluciones solo como Bibliotecario; no se concedió ese permiso al Administrador. Los mantenimientos conservan sus reglas existentes.

## Por qué había formularios aparentemente vacíos

Había dos causas: formularios sin archivo Designer que construían los controles durante la ejecución, y formularios con un Designer anterior cuyo contenido se ocultaba y reemplazaba mediante `MantenimientoUI.ConfigurarListado` o `ConfigurarDialogo`. Visual Studio no ejecuta esos montajes como un diseño editable.

Se trasladó la estructura estable a `InitializeComponent` en los archivos `.Designer.vb`, con controles, imágenes, tablas, tarjetas y contenedores. Los formularios tienen constructor sin argumentos y protección de modo de diseño; las consultas se ejecutan al utilizar la aplicación. El proyecto declara la relación entre `.vb`, `.Designer.vb` y `.resx`.

| Grupo | Formularios revisados |
| --- | --- |
| Dashboard y lectores | `frmPrincipal`, `frmBuscarLector` |
| Préstamos | `frmPrestamos`, `frmPrestamoDetalle`, `frmPrestamoDevolucion` |
| Autores | `frmAutor`, `frmAutorDetalle` |
| Categorías | `FrmCategoria`, `frmAgregarCategoria`, `frmEditarCategoria` |
| Libros y ejemplares | `FrmLibros`, `FrmLibroDetalle`, `frmEjemplares`, `frmEjemplarDetalle`, `frmSeleccionCatalogo` |
| Penalizaciones | `frmPenalizacion`, `frmPenalizacionEditar`, `frmDetallePenalizacion`, `frmDetallePenalizacionEditar` |

El antiguo `frmLibro` singular es un prototipo con controles estáticos y eventos vacíos. No está conectado al menú y no sustituye al mantenimiento funcional `FrmLibros` plural. Se conserva para no borrar trabajo anterior. Las pantallas de autenticación y recuperación ya tenían Designer y no se rediseñaron en esta tarea.

El logo Lecturae y la imagen de usuario provienen de los recursos existentes. Las imágenes usan proporción conservada y nombre accesible. La estructura de los gráficos existe en el diseñador: muestra una leyenda de vista de diseño; en ejecución se dibujan únicamente los resultados de SQL. Las filas, las relaciones de autores/categorías y los números de página son contenido variable y se cargan al ejecutar.

Se utiliza escalado DPI, filtros que cambian de fila, áreas con desplazamiento, editores redimensionables y límites según el área de pantalla. Se corrigieron el recorte de números de tarjetas y la distribución de la paginación de libros.

## Datos y filtros

`capaDatos/DashboardResumen.vb` transporta los resultados; `capaDAO/dashboardDAO.vb` consulta con parámetros y conexión independiente; `capaNegocio/dashboardNegocio.vb` valida los filtros. La interfaz no contiene SQL.

- Fechas: intervalo inclusivo de **inicio del préstamo**. El filtro inicial es del 1 de enero del año actual a hoy; no establece duración de los préstamos.
- Activos: estado `Activo`, sin fecha de retorno. Incluye vencidos.
- Vencidos: activos cuya fecha límite es anterior a hoy. No se guarda un estado adicional.
- Devueltos: estado `Devuelto` con fecha real de retorno.
- Por revisar: combinaciones históricas inconsistentes de estado/retorno; se identifican en el resumen sin corregir datos silenciosamente.
- Fechas, categoría y estado filtran las tarjetas del periodo, gráfico mensual, distribución de estados y próximos préstamos a devolver.
- Disponibilidad: copias habilitadas de libros habilitados sin préstamo que ocupe la copia, para la categoría elegida. Representa disponibilidad **actual**, independiente del periodo y del filtro de estado.
- Devoluciones de hoy: retornos de hoy para la categoría elegida, independientes del periodo de inicio y del filtro de estado. Se muestran en la línea «Hoy».
- Lectores activos: estudiantes activos en toda la biblioteca. Libros habilitados: los de la categoría elegida. Sus etiquetas distinguen estos alcances.
- Un préstamo de un libro con varias categorías cuenta una sola vez en totales; puede figurar en varias categorías en el desglose. Los libros sin categoría también se cuentan.

Las tarjetas abren el módulo correspondiente; su navegación utiliza el estado asociado, sin trasladar el intervalo del dashboard al listado general. El doble clic en un pendiente abre su ID exacto. Actualizar en Préstamos quita el contexto de lector/préstamo y vuelve al listado general con sus filtros de texto y estado.

## Buscar lector y préstamos

`frmBuscarLector` busca nombre, apellidos, DNI o correo. La consulta exige usuario activo y rol `Estudiante` mediante las claves reales. Al seleccionar un resultado, consulta el historial por **ID exacto**, evitando mezclar lectores con el mismo nombre. Ofrece nuevo préstamo con el lector preseleccionado, navegación al listado y devolución del préstamo seleccionado según permisos.

Las consultas de búsqueda e historial se realizan fuera del hilo visual, limpian resultados anteriores y descartan respuestas obsoletas. Los errores de conexión se distinguen de un resultado vacío. El dashboard actualiza su información al volver a Inicio y después de préstamos/devoluciones.

Se reutilizan las transacciones y validaciones del módulo de préstamos: copia reservada dentro de la transacción, usuario/operador activos y con rol correcto, libro habilitado, fechas válidas, retraso no negativo y rechazo de doble devolución. Sigue bloqueada la desactivación de libros o ejemplares con préstamos relacionados, incluso devueltos.

## Políticas confirmadas

El equipo confirmó plazo de cinco días calendario, máximo un ejemplar sin devolver y bloqueo por penalizaciones pendientes de pago. El editor calcula la fecha límite automáticamente. El estado del catálogo sigue indicando activo/inactivo. El pago se guarda por separado mediante la migración 001, que deja las filas antiguas PorRevisar. No se generan multas automáticamente. Ver POLITICAS_PRESTAMOS.md para la migración, revisión de datos y verificación.

## Abrir y ejecutar

1. Abrir `Distribuidos-2026II.slnx` en Visual Studio con soporte para .NET 10 y desarrollo de escritorio.
2. Compilar la solución. En `capaInterfaz`, seleccionar **el archivo `.vb` del formulario** y pulsar **Shift+F7 / Ver diseñador**. No abrir `.Designer.vb` como si fuese el formulario principal.
3. Por ejemplo, abrir `frmPrincipal.vb`, `frmBuscarLector.vb` o `frmPrestamoDetalle.vb`: la estructura e imágenes ya están en sus Designer. Los datos operativos se cargan únicamente al ejecutar.
4. Establecer `capaInterfaz` como proyecto de inicio y ejecutar con F5; entrar mediante Login para conservar la sesión. Abrir directamente un formulario sin sesión no habilita préstamos.
5. La conexión existente se conserva. `BIBLIOTECA_CONNECTION_STRING`, si se define antes de iniciar el proceso, permite seleccionar una base diferente. Las pruebas lo utilizan exclusivamente para su base temporal.

Los scripts de `verificacion/Diseno` son herramientas de migración manual, no dependencias de ejecución. No deben volver a ejecutarse después de editar visualmente los formularios sin revisar sus cambios: regeneran archivos Designer.

## Verificación y límites

La solución compila. El verificador de `verificacion/Prestamos` cubre 142 comprobaciones, incluidas las políticas confirmadas: reglas de fechas, interfaz de préstamos, construcción y carga en contexto de diseño de 19 formularios, consultas del dashboard, filtros, categorías múltiples, búsqueda/historial, lector preseleccionado, navegación, roles, devolución y tres carreras simultáneas de reserva.

SQL Server Express estuvo disponible. Las pruebas de escritura crearon una base temporal con el script real `../bd_biblioteca` y la eliminaron al terminar. No modificaron la base `distribuidos-II`. Las imágenes `verificacion/Prestamos/evidencia` y los registros `resultado-dashboard.log` y `resultado-politicas.log` documentan las comprobaciones; los registros de prueba que aparecen en imágenes solo existieron en esa base temporal.

Se renderizaron controles WinForms y se comprobó una escala geométrica de 125 %. **No se abrió el diseñador real de Visual Studio ni se cambió la escala nativa de Windows**: su validación interactiva queda pendiente. Algunas partes nativas de ComboBox no pintan su texto en estas capturas sin ventana visible; las selecciones se comprobaron mediante sus valores. No se simularon datos operativos para la aplicación.

Persisten avisos de dependencias anteriores sobre `System.Data.SqlClient` obsoleto y de auditoría NuGet cuando su servicio no es accesible. No se migró el proveedor SQL en este cambio de interfaz. No se probaron manualmente todos los mantenimientos ni los flujos de correo/recuperación, que están fuera de este cambio.

Para repetir la integración desde la raíz del proyecto:

```powershell
dotnet run --project verificacion/Prestamos/Prestamos.csproj -- --sql-integracion
```

El usuario de SQL debe poder crear y eliminar la base temporal. Nunca sustituir ese aislamiento por escrituras de prueba en la base real.
