IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE TABLE [Especialidades] (
        [Id] int NOT NULL IDENTITY,
        [Descripcion] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Especialidades] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE TABLE [Pacientes] (
        [Id] int NOT NULL IDENTITY,
        [ObraSocial] bit NOT NULL DEFAULT CAST(0 AS bit),
        [Activo] bit NOT NULL DEFAULT CAST(1 AS bit),
        [Nombre] nvarchar(max) NOT NULL,
        [Apellido] nvarchar(max) NOT NULL,
        [Dni] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [FechaNac] date NULL,
        [Telefono] nvarchar(max) NULL,
        [Direccion] nvarchar(max) NULL,
        CONSTRAINT [PK_Pacientes] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE TABLE [Paquetes] (
        [Id] int NOT NULL IDENTITY,
        [Precio] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Paquetes] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE TABLE [Servicios] (
        [Id] int NOT NULL IDENTITY,
        [Codigo] nvarchar(max) NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Precio] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Servicios] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE TABLE [Medicos] (
        [Id] int NOT NULL IDENTITY,
        [EspecialidadId] int NOT NULL,
        [Sueldo] decimal(18,2) NULL,
        [Activo] bit NOT NULL DEFAULT CAST(1 AS bit),
        [Nombre] nvarchar(max) NOT NULL,
        [Apellido] nvarchar(max) NOT NULL,
        [Dni] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [FechaNac] date NULL,
        [Telefono] nvarchar(max) NULL,
        [Direccion] nvarchar(max) NULL,
        CONSTRAINT [PK_Medicos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Medicos_Especialidades_EspecialidadId] FOREIGN KEY ([EspecialidadId]) REFERENCES [Especialidades] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE TABLE [PaquetesServicios] (
        [PaqueteId] int NOT NULL,
        [ServicioId] int NOT NULL,
        CONSTRAINT [PK_PaquetesServicios] PRIMARY KEY ([PaqueteId], [ServicioId]),
        CONSTRAINT [FK_PaquetesServicios_Paquetes_PaqueteId] FOREIGN KEY ([PaqueteId]) REFERENCES [Paquetes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_PaquetesServicios_Servicios_ServicioId] FOREIGN KEY ([ServicioId]) REFERENCES [Servicios] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE TABLE [CitasMedicas] (
        [Id] int NOT NULL IDENTITY,
        [FechaConsulta] datetime2 NOT NULL,
        [HoraConsulta] datetime2 NOT NULL,
        [Precio] decimal(18,2) NOT NULL,
        [Abonado] bit NOT NULL,
        [PacienteId] int NOT NULL,
        [MedicoId] int NOT NULL,
        [PaqueteId] int NULL,
        CONSTRAINT [PK_CitasMedicas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CitasMedicas_Medicos_MedicoId] FOREIGN KEY ([MedicoId]) REFERENCES [Medicos] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CitasMedicas_Pacientes_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Pacientes] ([Id]),
        CONSTRAINT [FK_CitasMedicas_Paquetes_PaqueteId] FOREIGN KEY ([PaqueteId]) REFERENCES [Paquetes] ([Id]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE TABLE [Horarios] (
        [Id] int NOT NULL IDENTITY,
        [FechaHoraInicio] datetime2 NOT NULL,
        [FechaHoraFin] datetime2 NOT NULL,
        [Disponible] bit NOT NULL,
        [MedicoId] int NOT NULL,
        CONSTRAINT [PK_Horarios] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Horarios_Medicos_MedicoId] FOREIGN KEY ([MedicoId]) REFERENCES [Medicos] ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE INDEX [IX_CitasMedicas_MedicoId] ON [CitasMedicas] ([MedicoId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE INDEX [IX_CitasMedicas_PacienteId] ON [CitasMedicas] ([PacienteId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE INDEX [IX_CitasMedicas_PaqueteId] ON [CitasMedicas] ([PaqueteId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE INDEX [IX_Horarios_MedicoId] ON [Horarios] ([MedicoId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE INDEX [IX_Medicos_EspecialidadId] ON [Medicos] ([EspecialidadId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    CREATE INDEX [IX_PaquetesServicios_ServicioId] ON [PaquetesServicios] ([ServicioId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250127193554_2701'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250127193554_2701', N'9.0.1');
END;

COMMIT;
GO

