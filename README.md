# Distribuidos-26II

Sistema de biblioteca en Visual Basic / Windows Forms (.NET 10) con SQL Server.

## Contraseñas

La aplicación guarda PBKDF2-HMAC-SHA256 con 600 000 iteraciones, sal aleatoria de 16 bytes y resultado de 32 bytes en `Usuario.contrasena VARCHAR(255)`. El formato es `PBKDF2-SHA256$iteraciones$salBase64$hashBase64`. Se usa la API criptográfica incorporada en .NET, sin paquetes nuevos. La verificación compara los resultados en tiempo constante.

- El registro y el cambio de contraseña calculan el hash antes de ejecutar INSERT/UPDATE.
- El login busca una cuenta activa por correo y verifica el hash en la aplicación; no compara la contraseña mediante SQL.
- Las bases existentes conservan acceso: una contraseña antigua en texto se verifica de forma exacta y se reemplaza por un hash al primer login correcto. Un login fallido no migra nada. La actualización comprueba también el valor anterior para evitar sobrescribir un cambio concurrente.
- No se cambia el esquema existente: la columna actual soporta el formato. No ejecutar otra vez el script completo sobre una base ya creada.
- Las cuentas que no inicien sesión mantienen sus valores antiguos hasta que se cambie su contraseña. Esta compatibilidad es temporal: completar los cambios de contraseña antes de retirar `VerifyLegacy`.
- `bd_biblioteca` crea cuentas de demostración con hashes distintos. Su contraseña es `DemoBiblioteca2026!`, solo para desarrollo. Las bases antiguas siguen usando su contraseña anterior hasta migrar.
- El hash no se incluye en el objeto Usuario devuelto al iniciar sesión ni en los mensajes.

## Login

El formulario empieza sin credenciales precargadas, permite enviar con Enter, valida campos vacíos y ejecuta la autenticación fuera del hilo de la interfaz. Deshabilita el envío y los enlaces durante la operación. Limpia la contraseña y vuelve a ocultarla después del intento. Los errores de SQL muestran un mensaje general sin revelar detalles de la conexión.

## Ejecución y límites

La conexión actual usa SQL Server Express local (`.\\SQLEXPRESS`), base `distribuidos-II` y autenticación integrada de Windows. Ejecutar `bd_biblioteca` solo al crear una base nueva y abrir el proyecto de presentación con el SDK .NET 10.

Este cambio no sustituye la recuperación por pregunta de seguridad ni agrega permisos por rol. La aplicación de escritorio sigue accediendo directamente a SQL Server; para un despliegue público, esas operaciones deberían pasar por un servicio que aplique autenticación y autorización.

Referencia: [PBKDF2 en .NET](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.rfc2898derivebytes.pbkdf2?view=net-10.0).
