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
GO

CREATE TABLE [TipoLancamentos] (
    [Id] int NOT NULL IDENTITY,
    [DescricaoLancamento] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TipoLancamentos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [CPF] nvarchar(max) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Lancamentos] (
    [Id] int NOT NULL IDENTITY,
    [Valor] float NOT NULL,
    [TipoLancamentoId] int NULL,
    [LancamentoId] int NOT NULL,
    [UsuarioId] int NOT NULL,
    CONSTRAINT [PK_Lancamentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Lancamentos_TipoLancamentos_TipoLancamentoId] FOREIGN KEY ([TipoLancamentoId]) REFERENCES [TipoLancamentos] ([Id]),
    CONSTRAINT [FK_Lancamentos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DescricaoLancamento') AND [object_id] = OBJECT_ID(N'[TipoLancamentos]'))
    SET IDENTITY_INSERT [TipoLancamentos] ON;
INSERT INTO [TipoLancamentos] ([Id], [DescricaoLancamento])
VALUES (1, N'Entrada');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DescricaoLancamento') AND [object_id] = OBJECT_ID(N'[TipoLancamentos]'))
    SET IDENTITY_INSERT [TipoLancamentos] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DescricaoLancamento') AND [object_id] = OBJECT_ID(N'[TipoLancamentos]'))
    SET IDENTITY_INSERT [TipoLancamentos] ON;
INSERT INTO [TipoLancamentos] ([Id], [DescricaoLancamento])
VALUES (2, N'Saída');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DescricaoLancamento') AND [object_id] = OBJECT_ID(N'[TipoLancamentos]'))
    SET IDENTITY_INSERT [TipoLancamentos] OFF;
GO

CREATE INDEX [IX_Lancamentos_TipoLancamentoId] ON [Lancamentos] ([TipoLancamentoId]);
GO

CREATE INDEX [IX_Lancamentos_UsuarioId] ON [Lancamentos] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220812191847_inicial', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Logins] (
    [Id] bigint NOT NULL IDENTITY,
    [UserName] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [RefreshToken] nvarchar(max) NOT NULL,
    [RefreshTokenExpiryTibe] datetime2 NOT NULL,
    CONSTRAINT [PK_Logins] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220812192623_Migration_login', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Lancamentos] DROP CONSTRAINT [FK_Lancamentos_TipoLancamentos_TipoLancamentoId];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lancamentos]') AND [c].[name] = N'LancamentoId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Lancamentos] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Lancamentos] DROP COLUMN [LancamentoId];
GO

DROP INDEX [IX_Lancamentos_TipoLancamentoId] ON [Lancamentos];
DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lancamentos]') AND [c].[name] = N'TipoLancamentoId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Lancamentos] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Lancamentos] ALTER COLUMN [TipoLancamentoId] int NOT NULL;
ALTER TABLE [Lancamentos] ADD DEFAULT 0 FOR [TipoLancamentoId];
CREATE INDEX [IX_Lancamentos_TipoLancamentoId] ON [Lancamentos] ([TipoLancamentoId]);
GO

ALTER TABLE [Lancamentos] ADD CONSTRAINT [FK_Lancamentos_TipoLancamentos_TipoLancamentoId] FOREIGN KEY ([TipoLancamentoId]) REFERENCES [TipoLancamentos] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220812202345_correcao', N'6.0.8');
GO

COMMIT;
GO

