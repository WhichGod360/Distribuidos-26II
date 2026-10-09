--LLAMEN A LA BD distribuidos-II


-- bd_fdinal_biblioteca.sql: versión consolidada, únicamente para una BASE NUEVA Y VACÍA.
-- BD existente: aplicar migraciones/005_mora_tramos_monto_aplicado.sql después de 004.
-- Contiene todos los cambios de 002-005 incorporados en CREATE, sin repetir ALTER obsoletos.
-- Contraseña de todos los usuarios activos de prueba: DemoBiblioteca2026!  Respuesta: no.
-- Cuentas principales: admin@biblioteca.usat.edu.pe / bibliotecaria@biblioteca.usat.edu.pe / altair.lachos@usat.pe.
-- Casos: Ana pendiente; Hugo aprobada; Bruno entregada; Carla vencida; Diego cancelada;
-- Elena devuelta a tiempo; Felipe mora pendiente; Gabriela rechazada; Renzo pago por revisar;
-- cinco.libros con 5 préstamos; mora.por.devolver vencido; Altair cargo pagado.
-- Tarifas ilustrativas; deben ajustarse en Penalizaciones según lo acordado por tu equipo.
SET XACT_ABORT ON;
IF EXISTS(SELECT 1 FROM sys.tables WHERE is_ms_shipped=0)
BEGIN
    RAISERROR('Selecciona una base NUEVA y vacía. Para actualizar tu base actual usa la migración 005.',16,1);
    SET NOEXEC ON;
END;
GO
BEGIN TRANSACTION;
GO
-- Biblioteca universitaria. Ejecutar en una base NUEVA y vacía seleccionada en SSMS.
-- Base existente: aplicar 002 si aún falta, luego 003_carrito_aprobacion.sql , 004_respuesta_seguridad_hash.sql y 005_mora_tramos_monto_aplicado.sql.
-- Reserva: cinco días desde la solicitud (fecha y hora UTC).
-- Préstamo: cinco días calendario desde la entrega presencial.
-- Una solicitud contiene varios títulos, con aprobación previa y entrega completa.
-- Máximo cinco ejemplares pendientes de devolución por lector, entre todos sus préstamos.
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE dbo.RolUsuario (
    id_rol_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre_rol_usuario VARCHAR(50) NOT NULL UNIQUE,
    CONSTRAINT CK_RolUsuario_Nombre CHECK (LEN(LTRIM(RTRIM(nombre_rol_usuario))) > 0)
);
GO
CREATE TABLE dbo.Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    email_usuario VARCHAR(100) NOT NULL UNIQUE,
    nombre_usuario VARCHAR(100) NOT NULL,
    ap_paterno VARCHAR(100) NOT NULL,
    ap_materno VARCHAR(100) NOT NULL,
    numero_dni_usuario VARCHAR(8) NOT NULL UNIQUE,
    fecha_nacimiento_usuario DATE NULL,
    genero_usuario BIT NULL,
    estado_usuario VARCHAR(30) NOT NULL,
    contrasena VARCHAR(255) NOT NULL,
    id_rol_usuario INT NOT NULL,
    preguntasegura VARCHAR(255) NOT NULL,
    rptasegura VARCHAR(255) NOT NULL,
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (id_rol_usuario) REFERENCES dbo.RolUsuario(id_rol_usuario),
    CONSTRAINT CK_Usuario_Dni CHECK (LEN(numero_dni_usuario) = 8 AND numero_dni_usuario COLLATE Latin1_General_100_BIN2 NOT LIKE '%[^0-9]%'),
    CONSTRAINT CK_Usuario_Email CHECK (email_usuario LIKE '_%@_%._%' AND email_usuario NOT LIKE '% %'),
    CONSTRAINT CK_Usuario_Nombres CHECK (LEN(LTRIM(RTRIM(nombre_usuario))) > 0 AND LEN(LTRIM(RTRIM(ap_paterno))) > 0 AND LEN(LTRIM(RTRIM(ap_materno))) > 0),
    CONSTRAINT CK_Usuario_Estado CHECK (UPPER(LTRIM(RTRIM(estado_usuario))) IN ('ACTIVO','INACTIVO')),
    CONSTRAINT CK_Usuario_Contrasena CHECK (LEN(LTRIM(RTRIM(contrasena))) > 0),
    CONSTRAINT CK_Usuario_Nacimiento CHECK (fecha_nacimiento_usuario IS NULL OR fecha_nacimiento_usuario <= CONVERT(date, GETDATE()))
);
GO
CREATE TABLE dbo.Autor (
    id_autor INT IDENTITY(1,1) PRIMARY KEY,
    nombre_autor VARCHAR(255) NOT NULL,
    CONSTRAINT CK_Autor_Nombre CHECK (LEN(LTRIM(RTRIM(nombre_autor))) > 0)
);
GO
CREATE TABLE dbo.Libro (
    id_libro INT IDENTITY(1,1) PRIMARY KEY,
    titulo_libro VARCHAR(255) NOT NULL,
    editorial_libro VARCHAR(255) NULL,
    ano_publicacion SMALLINT NULL,
    stock_total INT NOT NULL DEFAULT 0,
    estado_libro BIT NOT NULL DEFAULT 1,
    publico_libro VARCHAR(30) NULL,
    CONSTRAINT CK_Libro_Titulo CHECK (LEN(LTRIM(RTRIM(titulo_libro))) > 0),
    CONSTRAINT CK_Libro_Stock CHECK (stock_total >= 0),
    CONSTRAINT CK_Libro_Ano CHECK (ano_publicacion IS NULL OR ano_publicacion BETWEEN 1 AND 9999)
);
GO
CREATE TABLE dbo.DetalleLibro (
    id_detalle_libro INT IDENTITY(1,1) PRIMARY KEY,
    id_libro INT NOT NULL,
    id_autor INT NOT NULL,
    CONSTRAINT FK_DetalleLibro_Libro FOREIGN KEY (id_libro) REFERENCES dbo.Libro(id_libro),
    CONSTRAINT FK_DetalleLibro_Autor FOREIGN KEY (id_autor) REFERENCES dbo.Autor(id_autor),
    CONSTRAINT UQ_Libro_Autor UNIQUE (id_libro, id_autor)
);
GO
CREATE TABLE dbo.Categoria (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre_categoria VARCHAR(30) NOT NULL,
    estado BIT NOT NULL DEFAULT 1,
    CONSTRAINT CK_Categoria_Nombre CHECK (LEN(LTRIM(RTRIM(nombre_categoria))) > 0)
);
GO
CREATE TABLE dbo.DetalleCategoria (
    id_detalleCategoria INT IDENTITY(1,1) PRIMARY KEY,
    id_libro INT NOT NULL,
    id_categoria INT NOT NULL,
    CONSTRAINT FK_DetalleCategoria_Libro FOREIGN KEY (id_libro) REFERENCES dbo.Libro(id_libro),
    CONSTRAINT FK_DetalleCategoria_Categoria FOREIGN KEY (id_categoria) REFERENCES dbo.Categoria(id_categoria),
    CONSTRAINT UQ_Libro_Categoria UNIQUE (id_libro, id_categoria)
);
GO
CREATE TABLE dbo.Ejemplar (
    id_ejemplar INT IDENTITY(1,1) PRIMARY KEY,
    estado_ejemplar BIT NOT NULL DEFAULT 1,
    id_libro INT NOT NULL,
    CONSTRAINT FK_Ejemplar_Libro FOREIGN KEY (id_libro) REFERENCES dbo.Libro(id_libro)
);
GO
CREATE TABLE dbo.Prestamo (
    id_prestamo INT IDENTITY(1,1) PRIMARY KEY,
    fecha_inicio_prestamo DATE NOT NULL,
    fecha_fin_prestamo DATE NOT NULL,
    fecha_retorno_prestamo DATE NULL,
    estado_prestamo VARCHAR(30) NOT NULL,
    dias_retraso_prestamo INT NOT NULL DEFAULT 0,
    id_usuario INT NOT NULL,
    id_bibliotecario INT NOT NULL,
    id_ejemplar INT NOT NULL,
    CONSTRAINT FK_Prestamo_Usuario FOREIGN KEY (id_usuario) REFERENCES dbo.Usuario(id_usuario),
    CONSTRAINT FK_Prestamo_Bibliotecario FOREIGN KEY (id_bibliotecario) REFERENCES dbo.Usuario(id_usuario),
    CONSTRAINT FK_Prestamo_Ejemplar FOREIGN KEY (id_ejemplar) REFERENCES dbo.Ejemplar(id_ejemplar),
    CONSTRAINT CHK_Prestamo_Fechas CHECK (fecha_fin_prestamo > fecha_inicio_prestamo),
    CONSTRAINT CK_Prestamo_Retorno CHECK (fecha_retorno_prestamo IS NULL OR fecha_retorno_prestamo >= fecha_inicio_prestamo),
    CONSTRAINT CK_Prestamo_Inicio CHECK (fecha_inicio_prestamo <= CONVERT(date, GETDATE())),
    CONSTRAINT CK_Prestamo_RetornoFuturo CHECK (fecha_retorno_prestamo IS NULL OR fecha_retorno_prestamo <= CONVERT(date, GETDATE())),
    CONSTRAINT CK_Prestamo_Estado CHECK ((UPPER(LTRIM(RTRIM(estado_prestamo))) = 'ACTIVO' AND fecha_retorno_prestamo IS NULL) OR (UPPER(LTRIM(RTRIM(estado_prestamo))) = 'DEVUELTO' AND fecha_retorno_prestamo IS NOT NULL)),
    CONSTRAINT CK_Prestamo_Retraso CHECK (dias_retraso_prestamo IS NOT NULL AND dias_retraso_prestamo = CASE WHEN fecha_retorno_prestamo > fecha_fin_prestamo THEN DATEDIFF(day, fecha_fin_prestamo, fecha_retorno_prestamo) ELSE 0 END),
    CONSTRAINT CK_Prestamo_Personas CHECK (id_usuario <> id_bibliotecario)
);
GO
-- Una copia no puede tener dos préstamos abiertos. Una solicitud admite varios libros.
CREATE UNIQUE INDEX UX_Prestamo_EjemplarAbierto ON dbo.Prestamo(id_ejemplar) WHERE fecha_retorno_prestamo IS NULL;
CREATE INDEX IX_Prestamo_LectorCirculacion ON dbo.Prestamo(id_usuario,fecha_retorno_prestamo) INCLUDE(id_ejemplar,estado_prestamo);
GO
-- El plazo se valida en negocio para conservar préstamos históricos en bases existentes.
-- Este script y todos los inserts nuevos usan cinco días.
CREATE TABLE dbo.Penalizacion (
    id_penalizacion INT IDENTITY(1,1) PRIMARY KEY,
    tipo_penalizacion VARCHAR(30) NOT NULL,
    descripcion_penalizacion VARCHAR(MAX) NULL,
    monto_penalizacion DECIMAL(7,2) NOT NULL DEFAULT 0.00,
    estado_penalizacion BIT NOT NULL DEFAULT 1, -- catálogo: 1 activo, 0 inactivo
    dias_desde INT NULL, -- NULL: daño/pérdida; positivo: umbral de mora en días
    CONSTRAINT CK_Penalizacion_DiasDesde CHECK(dias_desde IS NULL OR dias_desde>=1),
    CONSTRAINT CHK_Penalizacion_Monto CHECK (monto_penalizacion >= 0),
    CONSTRAINT CK_Penalizacion_Tipo CHECK (LEN(LTRIM(RTRIM(tipo_penalizacion))) > 0)
);
GO
CREATE UNIQUE INDEX UX_Penalizacion_TramoActivo ON dbo.Penalizacion(dias_desde) WHERE dias_desde IS NOT NULL AND estado_penalizacion=1;
GO
CREATE TABLE dbo.DetallePenalizacion (
    id_detalle_penalizacion INT IDENTITY(1,1) PRIMARY KEY,
    descripcion_detallepenalizacion VARCHAR(MAX) NULL,
    id_penalizacion INT NOT NULL,
    id_prestamo INT NOT NULL,
    estado_pago_detalle VARCHAR(12) NOT NULL CONSTRAINT DF_DetallePenalizacion_EstadoPago DEFAULT ('Pendiente'),
    monto_aplicado DECIMAL(7,2) NOT NULL, -- copia del monto fijo al aplicar el cargo
    CONSTRAINT CK_DetallePenalizacion_MontoAplicado CHECK(monto_aplicado>=0),
    CONSTRAINT FK_DetallePenalizacion_Penalizacion FOREIGN KEY (id_penalizacion) REFERENCES dbo.Penalizacion(id_penalizacion),
    CONSTRAINT FK_DetallePenalizacion_Prestamo FOREIGN KEY (id_prestamo) REFERENCES dbo.Prestamo(id_prestamo),
    CONSTRAINT CK_DetallePenalizacion_EstadoPago CHECK (estado_pago_detalle COLLATE Latin1_General_100_BIN2 IN ('Pendiente','Pagada','PorRevisar'))
);
GO
CREATE INDEX IX_DetallePenalizacion_Prestamo ON dbo.DetallePenalizacion(id_prestamo,id_penalizacion);
GO
CREATE TABLE dbo.SolicitudPrestamo (
    id_solicitud INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    fecha_solicitud DATETIME2(0) NOT NULL CONSTRAINT DF_Solicitud_Fecha DEFAULT (SYSUTCDATETIME()),
    fecha_limite_retiro AS DATEADD(day, 5, fecha_solicitud) PERSISTED,
    estado_solicitud VARCHAR(12) NOT NULL CONSTRAINT DF_Solicitud_Estado DEFAULT ('Pendiente'),
    fecha_cierre DATETIME2(0) NULL,
    fecha_aprobacion DATETIME2(0) NULL,
    id_aprobador INT NULL,
    CONSTRAINT FK_Solicitud_Usuario FOREIGN KEY (id_usuario) REFERENCES dbo.Usuario(id_usuario),
    CONSTRAINT FK_Solicitud_Aprobador FOREIGN KEY (id_aprobador) REFERENCES dbo.Usuario(id_usuario),
    CONSTRAINT CK_Solicitud_Fecha CHECK (fecha_cierre IS NULL OR fecha_cierre >= fecha_solicitud),
    CONSTRAINT CK_Solicitud_Aprobacion CHECK (
        (fecha_aprobacion IS NULL AND id_aprobador IS NULL) OR
        (fecha_aprobacion IS NOT NULL AND id_aprobador IS NOT NULL AND fecha_aprobacion >= fecha_solicitud
         AND fecha_aprobacion < fecha_limite_retiro AND (fecha_cierre IS NULL OR fecha_cierre >= fecha_aprobacion))),
    CONSTRAINT CK_Solicitud_Estado CHECK (
        (estado_solicitud = 'Pendiente' AND fecha_cierre IS NULL AND fecha_aprobacion IS NULL)
        OR (estado_solicitud = 'Aprobada' AND fecha_cierre IS NULL AND fecha_aprobacion IS NOT NULL)
        OR (estado_solicitud = 'Atendida' AND fecha_cierre IS NOT NULL AND fecha_cierre < fecha_limite_retiro AND fecha_aprobacion IS NOT NULL)
        OR (estado_solicitud IN ('Cancelada','Rechazada') AND fecha_cierre IS NOT NULL)
        OR (estado_solicitud = 'Vencida' AND fecha_cierre IS NOT NULL AND fecha_cierre >= fecha_limite_retiro)
    )
);
GO
CREATE TABLE dbo.DetalleSolicitudPrestamo (
    id_detalle_solicitud INT IDENTITY(1,1) PRIMARY KEY,
    id_solicitud INT NOT NULL,
    id_libro INT NOT NULL,
    id_prestamo INT NULL,
    CONSTRAINT FK_DetalleSolicitud_Solicitud FOREIGN KEY(id_solicitud) REFERENCES dbo.SolicitudPrestamo(id_solicitud),
    CONSTRAINT FK_DetalleSolicitud_Libro FOREIGN KEY(id_libro) REFERENCES dbo.Libro(id_libro),
    CONSTRAINT FK_DetalleSolicitud_Prestamo FOREIGN KEY(id_prestamo) REFERENCES dbo.Prestamo(id_prestamo),
    CONSTRAINT UQ_DetalleSolicitud_Libro UNIQUE(id_solicitud,id_libro)
);
GO
CREATE UNIQUE INDEX UX_DetalleSolicitud_Prestamo ON dbo.DetalleSolicitudPrestamo(id_prestamo) WHERE id_prestamo IS NOT NULL;
CREATE INDEX IX_DetalleSolicitud_Libro ON dbo.DetalleSolicitudPrestamo(id_libro,id_solicitud);
CREATE INDEX IX_Solicitud_Lector ON dbo.SolicitudPrestamo(id_usuario,estado_solicitud,fecha_limite_retiro);
CREATE INDEX IX_Solicitud_Vigencia ON dbo.SolicitudPrestamo(estado_solicitud,fecha_limite_retiro);
GO
CREATE VIEW dbo.vw_DisponibilidadLibro AS
SELECT l.id_libro,
       f.libres AS ejemplares_libres,
       r.reservas AS reservas_vigentes,
       CASE WHEN l.estado_libro = 1 AND f.libres > r.reservas THEN f.libres - r.reservas ELSE 0 END AS disponibles
FROM dbo.Libro l
CROSS APPLY (SELECT COUNT(*) AS libres FROM dbo.Ejemplar e WHERE e.id_libro = l.id_libro AND e.estado_ejemplar = 1
    AND NOT EXISTS (SELECT 1 FROM dbo.Prestamo p WHERE p.id_ejemplar = e.id_ejemplar AND (p.fecha_retorno_prestamo IS NULL OR UPPER(LTRIM(RTRIM(p.estado_prestamo))) <> 'DEVUELTO'))) f
CROSS APPLY (SELECT COUNT(*) AS reservas FROM dbo.DetalleSolicitudPrestamo d JOIN dbo.SolicitudPrestamo s ON s.id_solicitud=d.id_solicitud
    WHERE d.id_libro = l.id_libro AND d.id_prestamo IS NULL
    AND s.estado_solicitud IN ('Pendiente','Aprobada') AND s.fecha_limite_retiro > SYSUTCDATETIME()) r;
GO

-- DATOS DE PRUEBA. Contraseña de demostración: DemoBiblioteca2026!
-- Contraseñas y respuestas de seguridad almacenadas con PBKDF2-SHA256.
-- Respuesta de demostración: no. No usar estas cuentas en producción.
INSERT INTO dbo.RolUsuario(nombre_rol_usuario) VALUES ('Administrador'),('Bibliotecario'),('Estudiante');
INSERT INTO dbo.Usuario (email_usuario, nombre_usuario, ap_paterno, ap_materno, numero_dni_usuario, fecha_nacimiento_usuario, genero_usuario, estado_usuario, contrasena, id_rol_usuario, preguntasegura, rptasegura) VALUES
('admin@biblioteca.usat.edu.pe', 'Carlos', 'Diaz', 'Perez', '10000001', '1985-03-10', 1, 'Activo', 'PBKDF2-SHA256$600000$/rNxmCw9O1dg0weRfPlneg==$mJ9NI9MQWIJJdGED/Ts/qJvcHgFzjrEtL+cBfv7Wt2c=', 1, 'Pregunta de demostración si o no', 'PBKDF2-SHA256$600000$oZgexbaB4fMbbzLSs6HGQA==$iwvNEFiupRxZeKMk2TrG7haGcxKy6/h309PXcM1hJAE='),
('bibliotecaria@biblioteca.usat.edu.pe', 'Maria', 'Torres', 'Vega', '10000002', '1990-07-22', 0, 'Activo', 'PBKDF2-SHA256$600000$l4bBlP/8LexcQQBKcLUGug==$cMnF1rDwZMuqzW4nanlhGxT+F0OaKi5PNhBaBFmBi6w=', 2, 'Pregunta de demostración si o no', 'PBKDF2-SHA256$600000$WC75YjtJMqIt/+IG3glLUQ==$iCjn6tWpaSEs9RpcGPW0ghkxhe48Z355oubmTHipaGI='),
('altair.lachos@usat.pe', 'Altair', 'Lachos', 'Briones', '70000001', '2003-01-15', 1, 'Activo', 'PBKDF2-SHA256$600000$bj+zxgI39U42kYUZKRcXdw==$HSKItzaw7r9A/LewPstzTUSPiCG6GkuW2vJiqtXg0qk=', 3, 'Pregunta de demostración si o no', 'PBKDF2-SHA256$600000$In+e5M/JoHp/40a4Yr6ulg==$wZwlRHPACG51xqBYHq3sSP8xUM+JbNp9X8PIlQFusz4='),
('renzo.gonzales@usat.pe', 'Renzo', 'Gonzales', 'Campos', '70000002', '2003-05-20', 1, 'Activo', 'PBKDF2-SHA256$600000$PdL47nzI8eqsDGDSCquK9Q==$3dvmKkWYVXHLiOildvuh5sD5k2LsovXJE45gEHwiNMA=', 3, 'Pregunta de demostración si o no', 'PBKDF2-SHA256$600000$YGz0MIeFEo1c9honay+qBQ==$vEgXhLIiFKr8wBYrmOpP8F2ZQdTb2ahZg4F0z6AZePg=');
GO
INSERT INTO dbo.Autor(nombre_autor) VALUES ('Gabriel Garcia Marquez'),('Robert C. Martin'),('Martin Fowler');
INSERT INTO dbo.Libro(titulo_libro,editorial_libro,ano_publicacion,stock_total,estado_libro,publico_libro) VALUES
('Cien Anios de Soledad','Sudamericana',1967,3,1,'General'),
('Clean Code','Prentice Hall',2008,2,1,'Universitario'),
('Refactoring','Addison-Wesley',1999,2,1,'Universitario');
INSERT INTO dbo.DetalleLibro(id_libro,id_autor) VALUES (1,1),(2,2),(3,3);
INSERT INTO dbo.Ejemplar(estado_ejemplar,id_libro) VALUES (1,1),(1,1),(1,1),(1,2),(0,2),(1,3),(1,3);
-- Devuelto a tiempo: inicio 1 de agosto, límite 6 de agosto, retorno 5 de agosto.
INSERT INTO dbo.Prestamo(fecha_inicio_prestamo,fecha_fin_prestamo,fecha_retorno_prestamo,estado_prestamo,dias_retraso_prestamo,id_usuario,id_bibliotecario,id_ejemplar)
VALUES ('20260801','20260806','20260805','Devuelto',0,3,2,6);
-- Devuelto con cinco días de retraso: límite 6 de agosto, retorno 11 de agosto.
INSERT INTO dbo.Prestamo(fecha_inicio_prestamo,fecha_fin_prestamo,fecha_retorno_prestamo,estado_prestamo,dias_retraso_prestamo,id_usuario,id_bibliotecario,id_ejemplar)
VALUES ('20260801','20260806','20260811','Devuelto',5,4,2,4);
INSERT INTO dbo.Penalizacion(tipo_penalizacion,descripcion_penalizacion,monto_penalizacion,estado_penalizacion,dias_desde)
VALUES ('Mora','Importe fijo desde un día de retraso. Tarifa de demostración.',5.00,1,1);
-- TARIFAS DE DEMOSTRACIÓN: sustituir por importes aprobados por la biblioteca.
-- No se multiplica por días y no se suman tramos. El mayor umbral alcanzado manda.
INSERT INTO dbo.Penalizacion(tipo_penalizacion,descripcion_penalizacion,monto_penalizacion,estado_penalizacion,dias_desde) VALUES
('Mora 2 días','Importe fijo de demostración.',7,1,2),
('Mora 3 días','Importe fijo de demostración.',9,1,3),
('Mora 4 días','Importe fijo de demostración; hasta antes de 7 días.',12,1,4),
('Mora 1 semana','Importe fijo de demostración; hasta antes de 14 días.',20,1,7),
('Mora 2 semanas','Importe fijo de demostración; hasta antes de 30 días.',30,1,14),
('Mora 1 mes','30 días como umbral de demostración.',50,1,30),
('Mora 1 año','365 días como umbral de demostración.',100,1,365),
('Mora 2 años','730 días. Este monto se mantiene si no hay un tramo superior.',150,1,730),
('Daño menor','Desperfecto físico verificado por el personal.',15,1,NULL),
('Pérdida','Importe fijo de demostración por pérdida.',80,1,NULL),
('Tipo retirado','Ejemplo de catálogo inactivo; no se aplica a cargos nuevos.',4,0,NULL);
GO
-- PorRevisar representa un pago cuyo estado aún no se ha confirmado.
INSERT INTO dbo.DetallePenalizacion(descripcion_detallepenalizacion,id_penalizacion,id_prestamo,estado_pago_detalle,monto_aplicado)
VALUES ('Cinco días de retraso. Tramo de demostración desde cuatro días, S/ 12.00. Pago por confirmar.',(SELECT id_penalizacion FROM dbo.Penalizacion WHERE dias_desde=4 AND estado_penalizacion=1),2,'PorRevisar',12.00);
GO
GO
-- Ejecutar una vez después de bd_biblioteca actualizado, en una base de demostración.
-- Ocho casos de escritorio: carrito, aprobación, entrega, vencimiento y devoluciones.
-- Cada título representa una copia. Los préstamos solo existen después de la entrega.
SET XACT_ABORT ON;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
BEGIN TRY
    BEGIN TRANSACTION;
    IF EXISTS(SELECT 1 FROM dbo.Usuario WHERE numero_dni_usuario LIKE '7100000%')
        THROW 51020, 'Estos casos simulados ya fueron cargados. No los repitas en la misma base.', 1;
    DECLARE @utc DATETIME2(0)=SYSUTCDATETIME(), @hoy DATE=CONVERT(date,SYSDATETIME());
    DECLARE @rol INT=(SELECT id_rol_usuario FROM dbo.RolUsuario WHERE nombre_rol_usuario='Estudiante');
    DECLARE @operador INT=(SELECT MIN(u.id_usuario) FROM dbo.Usuario u JOIN dbo.RolUsuario r ON r.id_rol_usuario=u.id_rol_usuario WHERE r.nombre_rol_usuario='Bibliotecario');
    DECLARE @hash VARCHAR(255)=(SELECT contrasena FROM dbo.Usuario WHERE numero_dni_usuario='70000001');
    INSERT INTO dbo.Usuario(email_usuario,nombre_usuario,ap_paterno,ap_materno,numero_dni_usuario,estado_usuario,contrasena,id_rol_usuario,preguntasegura,rptasegura)
    SELECT v.correo,v.nombre,'Simulación','Biblioteca',v.dni,'Activo',@hash,@rol,'Pregunta de demostración si o no',v.respuesta_hash
    FROM(VALUES
        ('ana.simulada@biblioteca.edu.pe','Ana','71000001','PBKDF2-SHA256$600000$VjVF3EDpv9pwYbC+3MmHLA==$E/1Z/B5qQrmLiiNssc3BhpuXN4OAQmpLcN6JWq0iSNg='),
        ('bruno.simulado@biblioteca.edu.pe','Bruno','71000002','PBKDF2-SHA256$600000$UqqRb0/t84GdAe08wza1cg==$uUl1oBbcL3qx8wJjlP5dI2vmLHSZ9CXKcNpo0JqT04A='),
        ('carla.simulada@biblioteca.edu.pe','Carla','71000003','PBKDF2-SHA256$600000$45eBqcc+5C97XkDgnOXBJA==$+hrDPO/BwW/wgDu+27yA3twmrkQFiOW+JuaRvnFFzVQ='),
        ('diego.simulado@biblioteca.edu.pe','Diego','71000004','PBKDF2-SHA256$600000$fxYExoo2jr9bA97uqxPX8Q==$LkU7xcuXxPR8VKR6JFEbH6X43DUf0VnLmrriICBPEr0='),
        ('elena.simulada@biblioteca.edu.pe','Elena','71000005','PBKDF2-SHA256$600000$dz11N0PW5VXgoLODUR/8Xw==$mS9jD8+bKy/psD80sWBTP6dSML3Q0OsHm9LBsAsPj24='),
        ('felipe.simulado@biblioteca.edu.pe','Felipe','71000006','PBKDF2-SHA256$600000$YPJJrkXJZBG/j11SsswrPQ==$xPrLmpbEmQewhFWGl7zX884qxmxJKnwijVt6p/ZsLGE='),
        ('gabriela.simulada@biblioteca.edu.pe','Gabriela','71000007','PBKDF2-SHA256$600000$6ZnmIYmKR/602gCQw4wsoQ==$d+b48UDn3KrUsNxG+A3bBu1mcZP8vAt3uRn1spQKtLE='),
        ('hugo.simulado@biblioteca.edu.pe','Hugo','71000008','PBKDF2-SHA256$600000$EU0toxmSkaM4E6MOD9w02g==$32DYuCiNqfgFFCCZ5juj90W77GHitz8PAdJ/v0LNL1Q=')
    )v(correo,nombre,dni,respuesta_hash);
    DECLARE @ana INT=(SELECT id_usuario FROM dbo.Usuario WHERE numero_dni_usuario='71000001');
    DECLARE @bruno INT=(SELECT id_usuario FROM dbo.Usuario WHERE numero_dni_usuario='71000002');
    DECLARE @carla INT=(SELECT id_usuario FROM dbo.Usuario WHERE numero_dni_usuario='71000003');
    DECLARE @diego INT=(SELECT id_usuario FROM dbo.Usuario WHERE numero_dni_usuario='71000004');
    DECLARE @elena INT=(SELECT id_usuario FROM dbo.Usuario WHERE numero_dni_usuario='71000005');
    DECLARE @felipe INT=(SELECT id_usuario FROM dbo.Usuario WHERE numero_dni_usuario='71000006');
    DECLARE @gabriela INT=(SELECT id_usuario FROM dbo.Usuario WHERE numero_dni_usuario='71000007');
    DECLARE @hugo INT=(SELECT id_usuario FROM dbo.Usuario WHERE numero_dni_usuario='71000008');
    INSERT INTO dbo.Libro(titulo_libro,stock_total,publico_libro) VALUES('Simulación Reserva y entrega',4,'Universitario');
    DECLARE @libroA INT=SCOPE_IDENTITY();
    INSERT INTO dbo.Libro(titulo_libro,stock_total,publico_libro) VALUES('Simulación Vencimiento',3,'Universitario');
    DECLARE @libroB INT=SCOPE_IDENTITY();
    INSERT INTO dbo.Libro(titulo_libro,stock_total,publico_libro) VALUES('Simulación Devolución con mora',1,'Universitario');
    DECLARE @libroC INT=SCOPE_IDENTITY();
    INSERT INTO dbo.Ejemplar(id_libro) VALUES(@libroA),(@libroA),(@libroA),(@libroA),(@libroB),(@libroB),(@libroB),(@libroC);
    DECLARE @copiaA1 INT=(SELECT MIN(id_ejemplar) FROM dbo.Ejemplar WHERE id_libro=@libroA);
    DECLARE @copiaA2 INT=(SELECT MIN(id_ejemplar) FROM dbo.Ejemplar WHERE id_libro=@libroA AND id_ejemplar<>@copiaA1);
    DECLARE @copiaC INT=(SELECT id_ejemplar FROM dbo.Ejemplar WHERE id_libro=@libroC);
    DECLARE @solicitud INT;

    -- 1. Ana: una solicitud pendiente con dos títulos. Bloquea una unidad de A y B.
    INSERT INTO dbo.SolicitudPrestamo(id_usuario,fecha_solicitud) VALUES(@ana,DATEADD(day,-1,@utc));
    SET @solicitud=SCOPE_IDENTITY();
    INSERT INTO dbo.DetalleSolicitudPrestamo(id_solicitud,id_libro) VALUES(@solicitud,@libroA),(@solicitud,@libroB);

    -- 2. Bruno: solicitud aprobada ayer y entregada hoy. Préstamo de hoy a hoy+5.
    INSERT INTO dbo.Prestamo(fecha_inicio_prestamo,fecha_fin_prestamo,estado_prestamo,id_usuario,id_bibliotecario,id_ejemplar)
    VALUES(@hoy,DATEADD(day,5,@hoy),'Activo',@bruno,@operador,@copiaA1);
    DECLARE @prestamoBruno INT=SCOPE_IDENTITY();
    INSERT INTO dbo.SolicitudPrestamo(id_usuario,fecha_solicitud,estado_solicitud,fecha_aprobacion,id_aprobador,fecha_cierre)
    VALUES(@bruno,DATEADD(day,-1,@utc),'Atendida',DATEADD(hour,-2,@utc),@operador,@utc);
    SET @solicitud=SCOPE_IDENTITY();
    INSERT INTO dbo.DetalleSolicitudPrestamo(id_solicitud,id_libro,id_prestamo) VALUES(@solicitud,@libroA,@prestamoBruno);

    -- 3. Carla: seis días desde la solicitud. Se muestra Vencida y libera stock.
    INSERT INTO dbo.SolicitudPrestamo(id_usuario,fecha_solicitud) VALUES(@carla,DATEADD(day,-6,@utc));
    SET @solicitud=SCOPE_IDENTITY();
    INSERT INTO dbo.DetalleSolicitudPrestamo(id_solicitud,id_libro) VALUES(@solicitud,@libroB);

    -- 4. Diego: cancelación; sin préstamo y sin bloquear stock.
    INSERT INTO dbo.SolicitudPrestamo(id_usuario,fecha_solicitud,estado_solicitud,fecha_cierre)
    VALUES(@diego,DATEADD(day,-2,@utc),'Cancelada',DATEADD(day,-1,@utc));
    SET @solicitud=SCOPE_IDENTITY();
    INSERT INTO dbo.DetalleSolicitudPrestamo(id_solicitud,id_libro) VALUES(@solicitud,@libroA);

    -- 5. Elena: entrega y devolución antes del vencimiento; cero días de retraso.
    INSERT INTO dbo.Prestamo(fecha_inicio_prestamo,fecha_fin_prestamo,fecha_retorno_prestamo,estado_prestamo,dias_retraso_prestamo,id_usuario,id_bibliotecario,id_ejemplar)
    VALUES(DATEADD(day,-6,@hoy),DATEADD(day,-1,@hoy),DATEADD(day,-2,@hoy),'Devuelto',0,@elena,@operador,@copiaA2);
    DECLARE @prestamoElena INT=SCOPE_IDENTITY();
    INSERT INTO dbo.SolicitudPrestamo(id_usuario,fecha_solicitud,estado_solicitud,fecha_aprobacion,id_aprobador,fecha_cierre)
    VALUES(@elena,DATEADD(day,-7,@utc),'Atendida',DATEADD(hour,-150,@utc),@operador,DATEADD(day,-6,@utc));
    SET @solicitud=SCOPE_IDENTITY();
    INSERT INTO dbo.DetalleSolicitudPrestamo(id_solicitud,id_libro,id_prestamo) VALUES(@solicitud,@libroA,@prestamoElena);

    -- 6. Felipe: devolución cinco días tarde y pago pendiente de regularizar.
    INSERT INTO dbo.Prestamo(fecha_inicio_prestamo,fecha_fin_prestamo,fecha_retorno_prestamo,estado_prestamo,dias_retraso_prestamo,id_usuario,id_bibliotecario,id_ejemplar)
    VALUES(DATEADD(day,-11,@hoy),DATEADD(day,-6,@hoy),DATEADD(day,-1,@hoy),'Devuelto',5,@felipe,@operador,@copiaC);
    DECLARE @prestamoFelipe INT=SCOPE_IDENTITY();
    DECLARE @penalizacion INT=(SELECT TOP(1) id_penalizacion FROM dbo.Penalizacion WHERE estado_penalizacion=1 AND dias_desde<=5 ORDER BY dias_desde DESC);
    DECLARE @importe DECIMAL(7,2)=(SELECT monto_penalizacion FROM dbo.Penalizacion WHERE id_penalizacion=@penalizacion);
    INSERT INTO dbo.DetallePenalizacion(descripcion_detallepenalizacion,id_penalizacion,id_prestamo,estado_pago_detalle,monto_aplicado)
    VALUES('Devolución con cinco días de retraso. Tramo fijo de demostración.',@penalizacion,@prestamoFelipe,'Pendiente',@importe);

    -- 7. Gabriela: solicitud rechazada; todos los títulos liberan stock.
    INSERT INTO dbo.SolicitudPrestamo(id_usuario,fecha_solicitud,estado_solicitud,fecha_cierre)
    VALUES(@gabriela,DATEADD(day,-1,@utc),'Rechazada',@utc);
    SET @solicitud=SCOPE_IDENTITY();
    INSERT INTO dbo.DetalleSolicitudPrestamo(id_solicitud,id_libro) VALUES(@solicitud,@libroA);

    -- 8. Hugo: dos títulos aprobados, todavía sin préstamos ni copias asignadas.
    INSERT INTO dbo.SolicitudPrestamo(id_usuario,fecha_solicitud,estado_solicitud,fecha_aprobacion,id_aprobador)
    VALUES(@hugo,DATEADD(day,-1,@utc),'Aprobada',DATEADD(hour,-1,@utc),@operador);
    SET @solicitud=SCOPE_IDENTITY();
    INSERT INTO dbo.DetalleSolicitudPrestamo(id_solicitud,id_libro) VALUES(@solicitud,@libroA),(@solicitud,@libroB);
    COMMIT;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT>0 ROLLBACK;
    THROW;
END CATCH;

SELECT u.nombre_usuario,s.id_solicitud,l.titulo_libro,
    CASE WHEN s.estado_solicitud IN ('Pendiente','Aprobada') AND s.fecha_limite_retiro<=SYSUTCDATETIME() THEN 'Vencida' ELSE s.estado_solicitud END AS estado_actual,
    s.fecha_solicitud,s.fecha_limite_retiro,s.fecha_aprobacion,p.id_prestamo,p.fecha_inicio_prestamo,p.fecha_fin_prestamo,p.fecha_retorno_prestamo
FROM dbo.SolicitudPrestamo s JOIN dbo.Usuario u ON u.id_usuario=s.id_usuario
JOIN dbo.DetalleSolicitudPrestamo d ON d.id_solicitud=s.id_solicitud JOIN dbo.Libro l ON l.id_libro=d.id_libro
LEFT JOIN dbo.Prestamo p ON p.id_prestamo=d.id_prestamo
WHERE u.numero_dni_usuario LIKE '7100000%' ORDER BY s.id_solicitud,d.id_detalle_solicitud;
SELECT l.titulo_libro,v.ejemplares_libres,v.reservas_vigentes,v.disponibles
FROM dbo.vw_DisponibilidadLibro v JOIN dbo.Libro l ON l.id_libro=v.id_libro WHERE l.titulo_libro LIKE 'Simulación %';
GO
-- Categorías y títulos adicionales para probar carritos y el límite total de cinco libros.
INSERT INTO dbo.Categoria(nombre_categoria,estado) VALUES ('Literatura',1),('Programación',1),('Bases de datos',1),('Matemática',1),('Categoría retirada',0);
INSERT INTO dbo.DetalleCategoria(id_libro,id_categoria) VALUES(1,1),(2,2),(3,2);
DECLARE @i INT=1;
WHILE @i<=6
BEGIN
    INSERT INTO dbo.Libro(titulo_libro,editorial_libro,ano_publicacion,stock_total,estado_libro,publico_libro)
    VALUES(CONCAT('Libro de práctica ',@i),'Editorial Universidad',2024,3,1,'Universitario');
    DECLARE @libro INT=SCOPE_IDENTITY();
    INSERT INTO dbo.Ejemplar(id_libro,estado_ejemplar) VALUES(@libro,1),(@libro,1),(@libro,1);
    INSERT INTO dbo.DetalleCategoria(id_libro,id_categoria) VALUES(@libro,3);
    INSERT INTO dbo.DetalleLibro(id_libro,id_autor) VALUES(@libro,2);
    SET @i+=1;
END;
-- Los títulos de las solicitudes simuladas también se ven al filtrar por categoría.
INSERT INTO dbo.DetalleCategoria(id_libro,id_categoria)
SELECT id_libro,3 FROM dbo.Libro WHERE titulo_libro LIKE 'Simulación%';
-- Lector sin movimientos e inactivo para probar acceso y mantenimiento.
INSERT INTO dbo.Usuario(email_usuario,nombre_usuario,ap_paterno,ap_materno,numero_dni_usuario,estado_usuario,contrasena,id_rol_usuario,preguntasegura,rptasegura)
SELECT 'lector.inactivo@biblioteca.edu.pe','Lector','Inactivo','Demo','72000001','Inactivo',contrasena,id_rol_usuario,preguntasegura,rptasegura FROM dbo.Usuario WHERE numero_dni_usuario='70000001';
-- Lector con cinco préstamos distintos: la sexta entrega debe ser rechazada.
INSERT INTO dbo.Usuario(email_usuario,nombre_usuario,ap_paterno,ap_materno,numero_dni_usuario,estado_usuario,contrasena,id_rol_usuario,preguntasegura,rptasegura)
SELECT 'cinco.libros@biblioteca.edu.pe','Lector','Cinco','Libros','72000002','Activo',contrasena,id_rol_usuario,preguntasegura,rptasegura FROM dbo.Usuario WHERE numero_dni_usuario='70000001';
DECLARE @lectorCinco INT=SCOPE_IDENTITY();
INSERT INTO dbo.Prestamo(fecha_inicio_prestamo,fecha_fin_prestamo,estado_prestamo,dias_retraso_prestamo,id_usuario,id_bibliotecario,id_ejemplar)
SELECT CONVERT(date,GETDATE()),DATEADD(day,5,CONVERT(date,GETDATE())),'Activo',0,@lectorCinco,2,MIN(e.id_ejemplar)
FROM dbo.Libro l JOIN dbo.Ejemplar e ON e.id_libro=l.id_libro
WHERE l.titulo_libro IN ('Libro de práctica 1','Libro de práctica 2','Libro de práctica 3','Libro de práctica 4','Libro de práctica 5')
GROUP BY l.id_libro;
-- Préstamo vencido todavía sin devolver: previsualiza la mora y confirma en ventanilla.
INSERT INTO dbo.Usuario(email_usuario,nombre_usuario,ap_paterno,ap_materno,numero_dni_usuario,estado_usuario,contrasena,id_rol_usuario,preguntasegura,rptasegura)
SELECT 'mora.por.devolver@biblioteca.edu.pe','Lector','Mora','Pendiente','72000003','Activo',contrasena,id_rol_usuario,preguntasegura,rptasegura FROM dbo.Usuario WHERE numero_dni_usuario='70000001';
DECLARE @lectorMora INT=SCOPE_IDENTITY();
INSERT INTO dbo.Prestamo(fecha_inicio_prestamo,fecha_fin_prestamo,estado_prestamo,dias_retraso_prestamo,id_usuario,id_bibliotecario,id_ejemplar)
SELECT DATEADD(day,-13,CONVERT(date,GETDATE())),DATEADD(day,-8,CONVERT(date,GETDATE())),'Activo',0,@lectorMora,2,MIN(e.id_ejemplar)
FROM dbo.Libro l JOIN dbo.Ejemplar e ON e.id_libro=l.id_libro WHERE l.titulo_libro='Libro de práctica 6';
-- Un cargo pagado: visible en el historial, permite nuevas solicitudes.
INSERT INTO dbo.DetallePenalizacion(descripcion_detallepenalizacion,id_penalizacion,id_prestamo,estado_pago_detalle,monto_aplicado)
VALUES('Daño menor confirmado y pagado. Cargo fijo de prueba.',
    (SELECT id_penalizacion FROM dbo.Penalizacion WHERE tipo_penalizacion='Daño menor'),1,'Pagada',15);
GO
COMMIT TRANSACTION;
PRINT 'Base final creada con 13 tablas, catálogo por tramos y escenarios de demostración.';
SET NOEXEC OFF;
GO

