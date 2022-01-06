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

IF SCHEMA_ID(N'Catalog') IS NULL EXEC(N'CREATE SCHEMA [Catalog];');
GO

CREATE SEQUENCE [Catalog].[ProductSeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
GO

CREATE TABLE [Catalog].[Product] (
    [Id] int NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [Price] int NOT NULL,
    [Description] nvarchar(500) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Catalog].[Image] (
    [Id] int NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [ProductId] int NOT NULL,
    [ProductId1] int NULL,
    CONSTRAINT [PK_Image] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Image_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Catalog].[Product] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Image_Product_ProductId1] FOREIGN KEY ([ProductId1]) REFERENCES [Catalog].[Product] ([Id])
);
GO

CREATE INDEX [IX_Image_ProductId] ON [Catalog].[Image] ([ProductId]);
GO

CREATE INDEX [IX_Image_ProductId1] ON [Catalog].[Image] ([ProductId1]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211229061455_initial', N'6.0.1');
GO

COMMIT;
GO

