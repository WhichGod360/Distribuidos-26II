# Guía del repositorio

## Estructura del proyecto

Biblioteca en Windows Forms con VB.NET, .NET 10 y SQL Server. Mantén la lógica en VB.NET y T-SQL.

- `capaConexion/`: configuración de conexiones y soporte de transacciones.
- `capaDatos/`: entidades, DTO y contratos de validación.
- `capaDAO/`: SQL parametrizado, lectores, persistencia y transacciones.
- `capaNegocio/`: reglas de negocio, autorización, hashes y flujos.
- `capaInterfaz/`: formularios, captura de datos, llamadas a Negocio y presentación.
- `Utiles/`: auxiliares visuales en VB.NET, incluidos por Interfaz.
- `Recursos/` y `capaInterfaz/My Project/Resources.resx`: imágenes y recursos incrustados.
- `sql/bd_fdinal_biblioteca.sql`: esquema consolidado y datos de demostración.

Conserva las cinco capas. Los formularios llaman a Negocio, nunca directamente a DAO o Conexión. Evalúa reglas transaccionales mediante contratos de Negocio mientras DAO mantiene los bloqueos.

## Compilación y ejecución

Ejecuta desde la carpeta de la solución en Windows, con el SDK .NET 10:

```powershell
dotnet restore Distribuidos-2026II.slnx
dotnet build Distribuidos-2026II.slnx --no-restore
dotnet run --project capaInterfaz/capaInterfaz.vbproj
```

Los comandos restauran dependencias, compilan y abren el inicio de sesión. En Visual Studio, selecciona `capaInterfaz` como proyecto de inicio.

Crea una base vacía en SQL Server y ejecuta el script consolidado en SSMS. Este script no actualiza bases existentes.

## Estilo de código y nombres

Usa cuatro espacios de sangría y conserva los identificadores: `usuarioDAO`, `usuarioNegocio`, `frmUsuarios` e `IdUsuario`. Mantén asociados los formularios, `.Designer.vb` y `.resx`.

Sigue el patrón de `usuarioDAO`: `query`, `cn`, `cmd`, `dr`, parámetros tipados y `dr.Read()`. Libera recursos propios con `Using`; traduce `SqlException` mediante `ErroresDAO`. Mantén las validaciones de negocio en `capaNegocio`. No hay formateador ni analizador configurados.

## Pruebas

No hay proyecto de pruebas automatizadas ni cobertura mínima configurados. Añade o ejecuta pruebas solo cuando se soliciten. Verifica permisos, solicitudes de varios libros, aprobación previa a entrega, caducidad de reservas en cinco días, límite de cinco ejemplares, devoluciones y penalizaciones fijas por tramo. Usa una base aislada y registra resultados.

## Commits y solicitudes de integración

Convenciones del historial sin verificar. Usa mensajes breves en imperativo: `Corrige validación de devolución`. Mantén cada commit enfocado. Describe en las PR las capas afectadas, cambios de base, verificaciones e incidencias relacionadas; incluye capturas para cambios de interfaz.

## Seguridad y configuración

La cadena de conexión a Somee se configura directamente en `capaConexion/Conexion.vb`, según lo acordado para este proyecto. Conserva los hashes de contraseñas y respuestas de seguridad. Excluye `bin/`, `obj/`, `.vs/`, registros y archivos locales de bases de datos.
