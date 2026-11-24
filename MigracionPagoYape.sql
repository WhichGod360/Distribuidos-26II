-- Ejecutar en la base de Lecturae seleccionada en Somee o SSMS.
-- Migración de reportes manuales de Yape. Puede ejecutarse nuevamente.
SET NOCOUNT ON;
SET XACT_ABORT ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;

IF OBJECT_ID(N'dbo.DetallePenalizacion', N'U') IS NULL
   OR COL_LENGTH(N'dbo.DetallePenalizacion', N'monto_aplicado') IS NULL
   OR COL_LENGTH(N'dbo.DetallePenalizacion', N'estado_pago_detalle') IS NULL
   OR OBJECT_ID(N'dbo.Prestamo', N'U') IS NULL
   OR OBJECT_ID(N'dbo.Usuario', N'U') IS NULL
   OR OBJECT_ID(N'dbo.RolUsuario', N'U') IS NULL
    THROW 51000, N'Selecciona la base de Lecturae que contiene las tablas de usuarios, préstamos y penalizaciones.', 1;

BEGIN TRY
    BEGIN TRANSACTION;

    -- La versión actual de la web lee este identificador al consultar los préstamos del lector.
    IF COL_LENGTH(N'dbo.Prestamo', N'id_operacion') IS NULL
        ALTER TABLE dbo.Prestamo ADD id_operacion uniqueidentifier NULL;

    IF EXISTS (
        SELECT 1 FROM sys.columns
        WHERE object_id = OBJECT_ID(N'dbo.Prestamo') AND name = N'id_operacion'
          AND system_type_id <> TYPE_ID(N'uniqueidentifier'))
        THROW 51000, N'La columna Prestamo.id_operacion tiene un tipo distinto al esperado por la web.', 1;

    IF NOT EXISTS (
        SELECT 1 FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.Prestamo') AND name = N'IX_Prestamo_Operacion')
        EXEC(N'CREATE INDEX IX_Prestamo_Operacion ON dbo.Prestamo(id_operacion, id_prestamo) WHERE id_operacion IS NOT NULL;');

    IF OBJECT_ID(N'dbo.PagoWebPenalizacion', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.PagoWebPenalizacion (
            id_pago int IDENTITY(1,1) CONSTRAINT PK_PagoWebPenalizacion PRIMARY KEY,
            id_detalle_penalizacion int NOT NULL,
            id_lector int NOT NULL,
            monto decimal(7,2) NOT NULL,
            nombre_yape nvarchar(120) NOT NULL,
            celular_yape varchar(9) NOT NULL,
            codigo_yape varchar(3) NOT NULL,
            estado varchar(12) NOT NULL CONSTRAINT DF_PagoWebPenalizacion_Estado DEFAULT ('EnRevision'),
            fecha_reporte_utc datetime2(0) NOT NULL CONSTRAINT DF_PagoWebPenalizacion_Fecha DEFAULT (SYSUTCDATETIME()),
            id_revisor int NULL,
            fecha_revision_utc datetime2(0) NULL,
            motivo_denegacion nvarchar(255) NULL,
            CONSTRAINT FK_PagoWebPenalizacion_Detalle FOREIGN KEY (id_detalle_penalizacion)
                REFERENCES dbo.DetallePenalizacion(id_detalle_penalizacion),
            CONSTRAINT FK_PagoWebPenalizacion_Lector FOREIGN KEY (id_lector) REFERENCES dbo.Usuario(id_usuario),
            CONSTRAINT FK_PagoWebPenalizacion_Revisor FOREIGN KEY (id_revisor) REFERENCES dbo.Usuario(id_usuario),
            CONSTRAINT CK_PagoWebPenalizacion_Monto CHECK (monto > 0),
            CONSTRAINT CK_PagoWebPenalizacion_Estado CHECK (estado COLLATE Latin1_General_100_BIN2 IN ('EnRevision','Confirmado','Denegado')),
            CONSTRAINT CK_PagoWebPenalizacion_Nombre CHECK (LEN(LTRIM(RTRIM(nombre_yape))) > 0),
            CONSTRAINT CK_PagoWebPenalizacion_Celular CHECK (
                DATALENGTH(celular_yape) = 9 AND celular_yape LIKE '9%'
                AND celular_yape COLLATE Latin1_General_100_BIN2 NOT LIKE '%[^0-9]%'),
            CONSTRAINT CK_PagoWebPenalizacion_Codigo CHECK (
                DATALENGTH(codigo_yape) = 3 AND codigo_yape COLLATE Latin1_General_100_BIN2 NOT LIKE '%[^0-9]%'),
            CONSTRAINT CK_PagoWebPenalizacion_Revision CHECK (
                (estado = 'EnRevision' AND id_revisor IS NULL AND fecha_revision_utc IS NULL AND motivo_denegacion IS NULL)
                OR (estado = 'Confirmado' AND id_revisor IS NOT NULL AND fecha_revision_utc IS NOT NULL AND motivo_denegacion IS NULL)
                OR (estado = 'Denegado' AND id_revisor IS NOT NULL AND fecha_revision_utc IS NOT NULL
                    AND motivo_denegacion IS NOT NULL AND LEN(LTRIM(RTRIM(motivo_denegacion))) > 0))
        );

        CREATE UNIQUE INDEX UX_PagoWebPenalizacion_EnRevision ON dbo.PagoWebPenalizacion(id_detalle_penalizacion)
            WHERE estado = 'EnRevision';
        CREATE UNIQUE INDEX UX_PagoWebPenalizacion_Confirmado ON dbo.PagoWebPenalizacion(id_detalle_penalizacion)
            WHERE estado = 'Confirmado';
        CREATE INDEX IX_PagoWebPenalizacion_Lector ON dbo.PagoWebPenalizacion(id_lector, id_detalle_penalizacion, id_pago);
        CREATE INDEX IX_PagoWebPenalizacion_Revision ON dbo.PagoWebPenalizacion(estado, id_pago);
    END
    ELSE IF COL_LENGTH(N'dbo.PagoWebPenalizacion', N'codigo_yape') IS NULL
        THROW 51000, N'Ya existe una tabla PagoWebPenalizacion de otro flujo. Revisa su estructura antes de aplicar esta migración.', 1;

    -- Cada definición se compila en su propio lote dentro de la transacción.
    EXEC sys.sp_executesql N'CREATE OR ALTER PROCEDURE dbo.RegistrarReporteYape
    @id_lector int,
    @id_detalle int,
    @importe_mostrado decimal(7,2),
    @nombre nvarchar(4000),
    @celular varchar(100),
    @codigo varchar(100)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @nombre IS NULL OR LEN(LTRIM(RTRIM(@nombre))) NOT BETWEEN 1 AND 120
        THROW 51002, N''Ingresa el nombre que aparece en el comprobante de Yape.'', 1;
    IF @celular IS NULL OR DATALENGTH(@celular) <> 9 OR @celular NOT LIKE ''9%''
       OR @celular COLLATE Latin1_General_100_BIN2 LIKE ''%[^0-9]%''
        THROW 51002, N''Ingresa el celular de quien envió el Yape (9 dígitos).'', 1;
    IF @codigo IS NULL OR DATALENGTH(@codigo) <> 3
       OR @codigo COLLATE Latin1_General_100_BIN2 LIKE ''%[^0-9]%''
        THROW 51002, N''Ingresa el código de seguridad de 3 dígitos del comprobante.'', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (
            SELECT 1 FROM dbo.Usuario u
            JOIN dbo.RolUsuario r ON r.id_rol_usuario = u.id_rol_usuario
            WHERE u.id_usuario = @id_lector AND u.estado_usuario = ''Activo''
              AND r.nombre_rol_usuario IN (''Estudiante'',''Lector''))
            THROW 51001, N''Solo un lector activo puede registrar su pago.'', 1;

        DECLARE @monto decimal(7,2), @estado varchar(12);
        SELECT @monto = dp.monto_aplicado, @estado = dp.estado_pago_detalle
        FROM dbo.DetallePenalizacion dp WITH (UPDLOCK, HOLDLOCK)
        JOIN dbo.Prestamo p WITH (HOLDLOCK) ON p.id_prestamo = dp.id_prestamo
        WHERE dp.id_detalle_penalizacion = @id_detalle AND p.id_usuario = @id_lector;

        IF @estado IS NULL OR @estado <> ''Pendiente'' OR @monto <= 0
            THROW 51003, N''El cargo ya no admite un reporte nuevo. Actualiza Mis penalizaciones y revisa su estado.'', 1;
        IF @importe_mostrado IS NULL OR @monto <> @importe_mostrado
            THROW 51004, N''El importe del cargo cambió. Si ya hiciste el Yape, consulta con la biblioteca antes de volver a pagar.'', 1;

        INSERT dbo.PagoWebPenalizacion (id_detalle_penalizacion, id_lector, monto, nombre_yape, celular_yape, codigo_yape)
        VALUES (@id_detalle, @id_lector, @monto, LTRIM(RTRIM(@nombre)), @celular, @codigo);

        UPDATE dbo.DetallePenalizacion SET estado_pago_detalle = ''PorRevisar''
        WHERE id_detalle_penalizacion = @id_detalle;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;';

    EXEC sys.sp_executesql N'CREATE OR ALTER PROCEDURE dbo.RevisarReporteYape
    @id_revisor int,
    @id_pago int,
    @confirmar bit,
    @motivo nvarchar(4000) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @confirmar IS NULL
        THROW 51002, N''Selecciona una decisión para el reporte.'', 1;
    IF @confirmar = 0 AND (@motivo IS NULL OR LEN(LTRIM(RTRIM(@motivo))) NOT BETWEEN 1 AND 255)
        THROW 51002, N''Escribe un motivo de denegación de hasta 255 caracteres.'', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (
            SELECT 1 FROM dbo.Usuario u
            JOIN dbo.RolUsuario r ON r.id_rol_usuario = u.id_rol_usuario
            WHERE u.id_usuario = @id_revisor AND u.estado_usuario = ''Activo''
              AND r.nombre_rol_usuario IN (''Administrador'',''Bibliotecario''))
            THROW 51001, N''Solo un bibliotecario o administrador activo puede revisar los pagos.'', 1;

        DECLARE @id_detalle int, @importe decimal(7,2), @estado_cargo varchar(12), @id_lector int;
        SELECT @id_detalle = id_detalle_penalizacion FROM dbo.PagoWebPenalizacion WHERE id_pago = @id_pago;

        -- Se toma primero el bloqueo del cargo, igual que al registrar un reporte.
        SELECT @importe = dp.monto_aplicado, @estado_cargo = dp.estado_pago_detalle, @id_lector = p.id_usuario
        FROM dbo.DetallePenalizacion dp WITH (UPDLOCK, HOLDLOCK)
        JOIN dbo.Prestamo p WITH (HOLDLOCK) ON p.id_prestamo = dp.id_prestamo
        WHERE dp.id_detalle_penalizacion = @id_detalle;

        IF @estado_cargo IS NULL OR @estado_cargo <> ''PorRevisar''
            THROW 51005, N''El reporte ya fue atendido o el cargo cambió. Actualiza la bandeja.'', 1;

        UPDATE dbo.PagoWebPenalizacion
        SET estado = CASE WHEN @confirmar = 1 THEN ''Confirmado'' ELSE ''Denegado'' END,
            id_revisor = @id_revisor,
            fecha_revision_utc = SYSUTCDATETIME(),
            motivo_denegacion = CASE WHEN @confirmar = 0 THEN LTRIM(RTRIM(@motivo)) END
        WHERE id_pago = @id_pago AND estado = ''EnRevision'' AND monto = @importe AND id_lector = @id_lector;

        IF @@ROWCOUNT <> 1
            THROW 51005, N''El reporte ya fue atendido o el cargo cambió. Actualiza la bandeja.'', 1;

        UPDATE dbo.DetallePenalizacion
        SET estado_pago_detalle = CASE WHEN @confirmar = 1 THEN ''Pagada'' ELSE ''Pendiente'' END
        WHERE id_detalle_penalizacion = @id_detalle;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;';

    EXEC sys.sp_executesql N'CREATE OR ALTER TRIGGER dbo.TR_DetallePenalizacion_ProtegerYape
ON dbo.DetallePenalizacion
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN deleted d ON d.id_detalle_penalizacion = i.id_detalle_penalizacion
        JOIN dbo.PagoWebPenalizacion p ON p.id_detalle_penalizacion = i.id_detalle_penalizacion
        WHERE p.estado IN (''EnRevision'',''Confirmado'')
          AND (i.id_prestamo <> d.id_prestamo OR i.monto_aplicado <> p.monto
               OR (p.estado = ''EnRevision'' AND i.estado_pago_detalle <> ''PorRevisar'')
               OR (p.estado = ''Confirmado'' AND i.estado_pago_detalle <> ''Pagada'')))
        THROW 51006, N''El estado de este cargo está vinculado a un reporte de Yape. Consúltalo en Revisar pagos por Yape.'', 1;
END;';

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;

SELECT DB_NAME() AS Base, N'Migración de Yape aplicada' AS Resultado;
