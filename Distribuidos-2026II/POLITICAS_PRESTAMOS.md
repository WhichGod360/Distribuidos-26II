# Políticas de préstamos y estado de pago

Reglas confirmadas por el equipo el 9 de octubre de 2026:

- Fecha límite = fecha de inicio + **5 días calendario**. La interfaz la calcula y no permite editarla. Negocio y DAO rechazan otra duración. Los préstamos históricos del script no se reescriben.
- Máximo **1 ejemplar sin devolver por lector**, incluido un préstamo vencido. Los estados históricos inconsistentes siguen ocupando una copia hasta su revisión.
- Una penalización **Pendiente** impide recibir otro préstamo. Una penalización **Pagada** no impide prestarlo. Un pago **PorRevisar** exige aclaración antes de autorizar un préstamo; no se supone deuda ni pago.

## Conflicto del esquema original

`bd_biblioteca` contiene `Penalizacion.estado_penalizacion` y la relación `DetallePenalizacion.id_prestamo`, pero **no contiene un estado de pago**. El comentario del INSERT de ejemplo dice que el estado 1 es pendiente de pago. La aclaración del equipo establece que ese campo significa catálogo activo/inactivo; se mantiene esta interpretación en el mantenimiento.

El archivo original no se modificó. El estado de pago se añade explícitamente con `migraciones/001_estado_pago_detalle_penalizacion.sql`, a la tabla que representa la penalización aplicada al préstamo. El lector se obtiene mediante `DetallePenalizacion → Prestamo → Usuario`; no se duplica un indicador en Usuario que pueda quedar desactualizado.

| Columna | Alcance | Valores |
| --- | --- | --- |
| `Penalizacion.estado_penalizacion` | Tipo del catálogo | 1 activo, 0 inactivo |
| `DetallePenalizacion.estado_pago_detalle` | Penalización aplicada | `Pendiente`, `Pagada`, `PorRevisar` |

Desactivar el tipo del catálogo no elimina una penalización pendiente aplicada anteriormente. La comprobación del préstamo no consulta la habilitación del tipo para decidir si existe una deuda.

## Migración y revisión de datos

La migración está preparada, **no aplicada a la base real**. No se ejecuta desde la aplicación, el login ni los formularios.

Para desplegar, el equipo debe seleccionar expresamente su base en SQL Server Management Studio y ejecutar el archivo 001 **una sola vez**, antes de que exista la columna. La versión esencial contiene tres ALTER TABLE: añadir la columna inicializando las filas anteriores, quitar el valor inicial temporal y definir el valor predeterminado y los estados permitidos. No contiene índices ni comprobaciones para volver a ejecutarla. Si ya se aplicó la migración anterior, no hace falta ejecutar esta versión: el esquema requerido por la aplicación es el mismo.

Las filas existentes reciben **PorRevisar**. Las nuevas reciben **Pendiente** por defecto. No se deduce el pago a partir de `estado_penalizacion`, del retraso, del importe o del comentario del script.

Antes de abrir nuevos préstamos a lectores afectados, consultar los registros por revisar:

```sql
SELECT dp.id_detalle_penalizacion, dp.estado_pago_detalle,
       p.id_prestamo, p.id_usuario,
       u.nombre_usuario, u.ap_paterno, u.ap_materno,
       pe.tipo_penalizacion, pe.monto_penalizacion,
       pe.estado_penalizacion AS tipo_catalogo_activo
FROM dbo.DetallePenalizacion dp
JOIN dbo.Prestamo p ON p.id_prestamo = dp.id_prestamo
JOIN dbo.Usuario u ON u.id_usuario = p.id_usuario
JOIN dbo.Penalizacion pe ON pe.id_penalizacion = dp.id_penalizacion
WHERE dp.estado_pago_detalle = 'PorRevisar';
```

Tras comprobar la evidencia de cada caso, el equipo puede abrir **Penalizaciones → Ver detalles → Editar** y seleccionar **Pendiente** o **Pagada**. Se puede conservar **Por revisar** mientras falte información. El listado muestra el estado de pago en una columna separada y admite buscarlo por texto. Cambiar otros datos sin especificar un estado de pago en negocio/DAO conserva el pago registrado.

Este mantenimiento registra el estado manualmente según sus permisos existentes. No procesa cobros, comprobantes ni importes automáticamente. Tampoco genera multas durante el préstamo o la devolución.

Si falta la columna, registrar préstamos devuelve un mensaje indicando la migración 001 necesaria. La aplicación no omite el bloqueo por falta de esquema. Las devoluciones y consultas de préstamos siguen funcionando sin necesitar esa columna.

## Archivos y validaciones

- Datos: `PoliticaPrestamo.vb` centraliza el plazo y el máximo; `DetallePenalizacion.vb` añade el estado de pago separado.
- DAO: `prestamoDAO.vb` valida plazo, usuarios, libro, copia, máximo y pagos en transacción; `EsquemaPago.vb` detecta la columna faltante; `detallePenalizacionDAO.vb` consulta y guarda el estado aplicado.
- Negocio: `prestamoNegocio.vb` calcula el plazo y valida fechas; `detallePenalizacionNegocio.vb` valida los estados de pago permitidos.
- Interfaz: `frmPrestamoDetalle` recalcula el límite al cambiar inicio; el editor y listado de detalles muestran el estado de pago en sus archivos Designer. Dashboard, búsqueda de lectores y devoluciones reutilizan los mismos servicios.

El alta bloquea primero al lector para serializar dos solicitudes sobre copias distintas. También conserva bloqueos del libro y ejemplar y la comprobación de ocupación hasta confirmar la transacción Serializable. La validación de un ejemplar por lector se mantiene dentro de la misma transacción que el INSERT.

Se conservan la validación del operador activo con rol Bibliotecario, la del lector activo Estudiante y las protecciones de libros y ejemplares con cualquier historial de préstamos. Devolver conserva la fecha real, calcula retraso no negativo y rechaza una segunda devolución.

## Verificación realizada

Se compiló la solución con cero errores y se ejecutaron **142 comprobaciones**. SQL Server Express estuvo disponible. El verificador creó una base temporal desde el script real, aplicó una vez la migración esencial 001, ejecutó pruebas y eliminó la base al terminar. No aplicó la migración ni realizó escrituras en `distribuidos-II`.

Se comprobó falta de migración con mensaje explícito, revisión histórica, valores iniciales, rechazo de estados inválidos en SQL y negocio, deuda pendiente, deuda pagada, independencia del catálogo, plazo de cuatro/cinco/seis días, cambio de mes, recálculo visual, préstamo vigente/vencido y devolución. También se probaron tres carreras de dos lectores sobre una misma copia y tres carreras de un lector sobre copias de libros distintos.

Se conservaron las comprobaciones de navegación, dashboard y lectores y las imágenes del verificador. La apertura manual dentro de Visual Studio y una prueba interactiva completa con una persona no se realizaron. Persisten advertencias del proveedor SQL existente y de acceso a la auditoría NuGet.

Registro: `verificacion/Prestamos/resultado-politicas.log`. Para repetir desde la carpeta de la solución:

```powershell
dotnet build Distribuidos-2026II.slnx
dotnet run --project verificacion/Prestamos/Prestamos.csproj -- --sql-integracion
```

La integración requiere permiso para crear/eliminar su base temporal. Las filas de prueba con estado Pagada se revisan explícitamente en esa base; la migración por sí sola no marca pagada ninguna penalización histórica.
