# Módulo de préstamos

Implementado conservando `Distribuidos-2026II.slnx` y sus cinco capas. Referencia: el archivo `../bd_biblioteca`, revisado antes de modificar código. No se cambió el script ni se requiere una migración.

## Archivos y responsabilidades

| Capa | Archivos | Responsabilidad |
| --- | --- | --- |
| Conexión | `capaConexion/Conexion.vb` | Conexiones independientes para que cada operación sea dueña de su transacción. Mantiene los métodos existentes. |
| Datos | `capaDatos/Prestamo.vb` | Claves, fechas, estado, retraso y datos de lector, bibliotecario y libro para las consultas. Vencido es un cálculo, no una columna. |
| DAO | `capaDAO/prestamoDAO.vb` | Consultas parametrizadas, comprobación de roles y estados, alta y devolución transaccionales. |
| DAO | `capaDAO/ejemplarDAO.vb`, `capaDAO/libroDAO.vb` | Disponibilidad consistente de copias y protección contra la desactivación con préstamos relacionados. |
| DAO | `capaDAO/usuarioDAO.vb` | Comparación de `Activo` compatible con el script y con los valores en mayúsculas del código anterior. |
| Negocio | `capaNegocio/prestamoNegocio.vb` | Validación de claves, fechas y filtros; cálculo de retraso para la vista previa. |
| Interfaz | `capaInterfaz/Login.vb`, `capaInterfaz/frmPrincipal.vb` | Conservan `IdUsuario`, nombre y rol desde la autenticación y conectan Préstamos al panel central. |
| Interfaz | `capaInterfaz/frmPrestamos.vb` | Listado, búsqueda y filtros; usa `MantenimientoUI` e `IMantenimientoVista`. |
| Interfaz | `capaInterfaz/frmPrestamoDetalle.vb`, `capaInterfaz/frmPrestamoDevolucion.vb` | Selección del lector y copia, alta y devolución con el estilo común de los mantenimientos. |

## Flujos

1. Iniciar sesión con una cuenta activa de rol `Bibliotecario`. El ID viene del objeto `Usuario` autenticado, sin buscar al bibliotecario por su nombre ni usar un ID fijo.
2. Abrir Préstamos. El encabezado muestra el nombre y el ID de la sesión. Nuevo préstamo y devolución requieren el rol Bibliotecario; el DAO vuelve a verificarlo en SQL. No se asigna autorización de bibliotecario automáticamente a un administrador.
3. En Nuevo préstamo, buscar por nombre, apellido, DNI o correo y seleccionar explícitamente al lector. La consulta une `Usuario` y `RolUsuario`: exige `nombre_rol_usuario = Estudiante` y `estado_usuario = Activo`, sin depender del número fijo del rol.
4. Elegir un libro habilitado y una copia disponible. Se reutiliza `ejemplarNegocio.listarDisponiblesPorLibro`. La consulta inicial solo orienta la selección; el alta vuelve a comprobar la disponibilidad bajo bloqueo.
5. Elegir la fecha de inicio y marcar y elegir la fecha límite. El límite debe ser estrictamente posterior al inicio, como exige `CHK_Prestamo_Fechas`. No se admiten inicios futuros. Las fechas se guardan como `DATE`, sin horas.
6. Registrar. Una fila representa una copia: se guardan `id_usuario`, `id_bibliotecario`, `id_ejemplar`, `fecha_inicio_prestamo`, `fecha_fin_prestamo`, retorno nulo, `Activo` y cero días de retraso.
7. Filtrar por Todos, Activos, Vencidos o Devueltos. Activos incluye los vencidos: son préstamos activos sin retorno cuya fecha límite es anterior a hoy. Una copia que vence hoy todavía no está vencida. El listado también busca por lector, DNI, correo, libro e ID del préstamo o ejemplar. Actualizar recarga los datos, y cambiar de módulo y regresar también los recarga.
8. Seleccionar un préstamo activo y registrar la fecha real de devolución. No puede ser anterior al inicio ni posterior a hoy. Se guarda `Devuelto` y `MAX(0, fecha_retorno - fecha_fin)` en días calendario. La comprobación en SQL impide devolver otra vez el mismo préstamo.

El esquema solo guarda el bibliotecario del alta. La devolución valida la cuenta que la realiza, pero no sobrescribe `id_bibliotecario`; guardar un auditor de devolución requeriría otra columna o un registro de auditoría.

## Transacciones y disponibilidad

- Altas y devoluciones usan su propia conexión y una transacción `Serializable`; no comparten la transacción global del singleton entre solicitudes.
- El alta bloquea el libro y luego la copia con `UPDLOCK, HOLDLOCK`, revalida los usuarios y comprueba los préstamos relacionados antes del INSERT. El bloqueo dura hasta COMMIT. Los fallos revierten la transacción al disponerla.
- La devolución bloquea la copia y la fila del préstamo, revalida al operador y actualiza con una condición que exige que aún siga activo y sin retorno.
- `estado_ejemplar` indica habilitación de la copia. Prestar y devolver no cambian esa columna ni `stock_total`; la disponibilidad se deduce de los préstamos. Una devolución completa libera la copia.
- Las desactivaciones toman el bloqueo del libro antes de comprobar las relaciones. No se permite desactivar un libro ni un ejemplar con cualquier préstamo registrado, incluidos los devueltos.
- Las consultas de disponibilidad bloquean conservadoramente copias con registros incoherentes o estados antiguos: solo liberan un préstamo con estado Devuelto **y** fecha de retorno informada. Esto evita prestar sobre un registro sin cerrar; esos datos requieren revisión, no una conversión automática.

## Conflictos encontrados y decisiones de esquema

- El script declara `estado_prestamo VARCHAR(30)` sin catálogo ni CHECK de estados y sus ejemplos usan `Devuelto`. El código anterior reconocía `ACTIVO` y, en algunas consultas, también `PENDIENTE`. Se conserva el estado activo existente como `Activo`, se usa `Devuelto` del script y no se crea un estado persistido Vencido ni Pendiente. Las comparaciones toleran mayúsculas y espacios. Si existen otros estados históricos, se muestran en Todos, bloquean la disponibilidad y requieren revisión antes de devolverlos.
- El script inserta usuarios con `Activo`; las consultas anteriores buscaban literalmente `ACTIVO`. Se normaliza la comparación para funcionar también en bases con distinción de mayúsculas.
- Los libros de demostración del script no tienen relaciones de categoría. Los INNER JOIN anteriores en `listarDisponibles` los ocultaban. Ahora autores y categorías se consultan sin excluir libros que no tengan esas relaciones. La disponibilidad depende de las copias físicas, no del contador de stock.
- `estado_penalizacion = 1` figura como pendiente de pago en el comentario del script; el mantenimiento lo llama activo. Esa ambigüedad sigue pendiente: el módulo no cambia penalizaciones ni genera multas.

## Políticas pendientes

Se revisaron el script, el README del repositorio y el código; no se encontró una política general documentada para estos puntos. El ejemplo de siete días y S/1 por mora del script es un caso de demostración, no una regla institucional.

| Decisión pendiente | Comportamiento actual |
| --- | --- |
| Duración del préstamo | Sin plazo automático. El bibliotecario debe elegir explícitamente la fecha límite. |
| Máximo de ejemplares simultáneos por lector | No se aplica un máximo inventado. Falta definir el límite y su alcance. |
| Bloqueo por multas pendientes | No se aplica. Primero debe resolverse la semántica de penalizaciones y la política de bloqueo. |
| Cálculo o generación automática de multas | Fuera del alcance solicitado. Solo se guardan los días de retraso. |

## Configuración

La conexión predeterminada permanece en `.\SQLEXPRESS`, base `distribuidos-II`, autenticación integrada. Opcionalmente se puede configurar `BIBLIOTECA_CONNECTION_STRING` **antes** de iniciar el proceso. La verificación usa esta opción para aislar los datos en una base temporal; no se cambia la conexión predeterminada.

## Verificación

El proyecto auxiliar `verificacion/Prestamos/Prestamos.csproj` no se agregó a la solución ni representa otra capa. No usa paquetes nuevos de pruebas.

Desde la carpeta de la solución:

```powershell
dotnet build Distribuidos-2026II.slnx
dotnet run --project verificacion/Prestamos/Prestamos.csproj
dotnet run --project verificacion/Prestamos/Prestamos.csproj -- --sql-lectura
dotnet run --project verificacion/Prestamos/Prestamos.csproj -- --sql-integracion
```

- Sin opciones: 33 comprobaciones de fechas, retraso, estados, filtros, ausencia de plazo automático y restricciones de la interfaz; genera imágenes sin mostrar ventanas ni ejecutar Load.
- `--sql-lectura`: abre la conexión configurada y comprueba búsquedas y listados sin escrituras.
- `--sql-integracion`: requiere permisos para crear y eliminar una base en el servidor configurado. Crea `Biblioteca_Verificacion_<GUID>`, ejecuta el **script real** `../bd_biblioteca`, dirige todas las operaciones a esa base y la elimina al terminar, también ante fallos.

Resultado comprobado: **66 comprobaciones correctas** con SQL Server Express disponible, incluyendo búsquedas por nombre, apellido, DNI y correo; lectores y bibliotecarios inactivos o de rol incorrecto; libros y copias inactivos; alta y reserva; devolución tardía, anticipada y en el límite; doble devolución; desactivación con historial; penalizaciones sin modificaciones; y tres carreras de dos solicitudes sobre la misma copia, con un solo alta exitosa por carrera. La base temporal se eliminó. En `distribuidos-II` solo se hicieron consultas de lectura.

Se revisaron las imágenes de listado, registro y devolución generadas en `verificacion/Prestamos/evidencia`. La compilación de la solución debe terminar con cero errores. Persisten avisos del proveedor existente `System.Data.SqlClient` obsoleto, advertencias previas de relanzamiento de excepciones y fallos de acceso a la auditoría de NuGet; no se cambió el proveedor ni se pudo completar esa auditoría remota. No se hizo una prueba manual completa del login y los botones con una persona, ni una prueba de carga distribuida o de escritores externos que omitan estos bloqueos.
