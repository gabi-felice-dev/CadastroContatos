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

CREATE TABLE [Contatos] (
    [Id] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NULL,
    [UpdatedAt] datetime2 NULL,
    [Nome] nvarchar(max) NULL,
    [Email] nvarchar(450) NULL,
    [Telefone] nvarchar(450) NULL,
    CONSTRAINT [PK_Contatos] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Contatos_Email] ON [Contatos] ([Email]) WHERE [Email] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_Contatos_Telefone] ON [Contatos] ([Telefone]) WHERE [Telefone] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220705005336_Initial', N'6.0.6');
GO

COMMIT;
GO

