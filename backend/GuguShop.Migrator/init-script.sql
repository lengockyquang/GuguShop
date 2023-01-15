CREATE DATABASE GuguShop
GO

USE GuguShop
GO

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

CREATE TABLE [Category] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Manufacturer] (
    [Id] uniqueidentifier NOT NULL,
    [Code] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Manufacturer] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Product] (
    [Id] uniqueidentifier NOT NULL,
    [Code] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [ManufacturerId] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_Manufacturer_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturer] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [CategoryProduct] (
    [CategoriesId] uniqueidentifier NOT NULL,
    [ProductsId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_CategoryProduct] PRIMARY KEY ([CategoriesId], [ProductsId]),
    CONSTRAINT [FK_CategoryProduct_Category_CategoriesId] FOREIGN KEY ([CategoriesId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CategoryProduct_Product_ProductsId] FOREIGN KEY ([ProductsId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_CategoryProduct_ProductsId] ON [CategoryProduct] ([ProductsId]);
GO

CREATE UNIQUE INDEX [IX_Manufacturer_Code] ON [Manufacturer] ([Code]);
GO

CREATE UNIQUE INDEX [IX_Product_Code] ON [Product] ([Code]);
GO

CREATE INDEX [IX_Product_ManufacturerId] ON [Product] ([ManufacturerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220405155623_init', N'6.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [CategoryProduct];
GO

ALTER TABLE [Product] ADD [CategoryId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
GO

CREATE INDEX [IX_Product_CategoryId] ON [Product] ([CategoryId]);
GO

ALTER TABLE [Product] ADD CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220406152700_UpdateCategoryRelation', N'6.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_Product_Code] ON [Product];
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Product]') AND [c].[name] = N'Code');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Product] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Product] ALTER COLUMN [Code] nvarchar(100) NOT NULL;
CREATE UNIQUE INDEX [IX_Product_Code] ON [Product] ([Code]);
GO

DROP INDEX [IX_Manufacturer_Code] ON [Manufacturer];
DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Manufacturer]') AND [c].[name] = N'Code');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Manufacturer] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Manufacturer] ALTER COLUMN [Code] nvarchar(100) NOT NULL;
CREATE UNIQUE INDEX [IX_Manufacturer_Code] ON [Manufacturer] ([Code]);
GO

ALTER TABLE [Category] ADD [Code] nvarchar(100) NOT NULL DEFAULT N'';
GO

CREATE UNIQUE INDEX [IX_Category_Code] ON [Category] ([Code]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220406153252_UpdateTableUniqueIndex', N'6.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Tag] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ProductTag] (
    [ProductsId] uniqueidentifier NOT NULL,
    [TagsId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ProductTag] PRIMARY KEY ([ProductsId], [TagsId]),
    CONSTRAINT [FK_ProductTag_Product_ProductsId] FOREIGN KEY ([ProductsId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductTag_Tag_TagsId] FOREIGN KEY ([TagsId]) REFERENCES [Tag] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ProductTag_TagsId] ON [ProductTag] ([TagsId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220411151736_AddProductTag', N'6.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'ums') IS NULL EXEC(N'CREATE SCHEMA [ums];');
GO

CREATE TABLE [ums].[Role] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [NormalizedName] nvarchar(450) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ums].[User] (
    [Id] uniqueidentifier NOT NULL,
    [UserName] nvarchar(max) NULL,
    [NormalizedUserName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [NormalizedEmail] nvarchar(max) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ums].[UserClaim] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_UserClaim] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ums].[UserLogin] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    CONSTRAINT [PK_UserLogin] PRIMARY KEY ([UserId], [LoginProvider], [ProviderKey])
);
GO

CREATE TABLE [ums].[UserToken] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_UserToken] PRIMARY KEY ([UserId], [LoginProvider], [Name])
);
GO

CREATE TABLE [ums].[RoleClaim] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_RoleClaim] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RoleClaim_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [ums].[Role] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ums].[UserRole] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([RoleId], [UserId]),
    CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [ums].[Role] ([Id]),
    CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [ums].[User] ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Role_NormalizedName] ON [ums].[Role] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_RoleClaim_RoleId] ON [ums].[RoleClaim] ([RoleId]);
GO

CREATE INDEX [IX_UserRole_UserId] ON [ums].[UserRole] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220618130306_AddUms', N'6.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ums].[UserRole] DROP CONSTRAINT [PK_UserRole];
GO

DROP INDEX [IX_UserRole_UserId] ON [ums].[UserRole];
GO

ALTER TABLE [ums].[UserLogin] DROP CONSTRAINT [PK_UserLogin];
GO

IF SCHEMA_ID(N'file') IS NULL EXEC(N'CREATE SCHEMA [file];');
GO

EXEC sp_rename N'[ums].[Role].[IX_Role_NormalizedName]', N'RoleNameIndex', N'INDEX';
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ums].[User]') AND [c].[name] = N'UserName');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ums].[User] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [ums].[User] ALTER COLUMN [UserName] nvarchar(256) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ums].[User]') AND [c].[name] = N'NormalizedUserName');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ums].[User] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [ums].[User] ALTER COLUMN [NormalizedUserName] nvarchar(256) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ums].[User]') AND [c].[name] = N'NormalizedEmail');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ums].[User] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [ums].[User] ALTER COLUMN [NormalizedEmail] nvarchar(256) NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ums].[User]') AND [c].[name] = N'Email');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ums].[User] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [ums].[User] ALTER COLUMN [Email] nvarchar(256) NULL;
GO

DROP INDEX [RoleNameIndex] ON [ums].[Role];
DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ums].[Role]') AND [c].[name] = N'NormalizedName');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ums].[Role] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [ums].[Role] ALTER COLUMN [NormalizedName] nvarchar(256) NULL;
CREATE UNIQUE INDEX [RoleNameIndex] ON [ums].[Role] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ums].[Role]') AND [c].[name] = N'Name');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [ums].[Role] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [ums].[Role] ALTER COLUMN [Name] nvarchar(256) NULL;
GO

ALTER TABLE [ums].[UserRole] ADD CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]);
GO

ALTER TABLE [ums].[UserLogin] ADD CONSTRAINT [PK_UserLogin] PRIMARY KEY ([LoginProvider], [ProviderKey]);
GO

CREATE TABLE [file].[FileEntity] (
    [Id] uniqueidentifier NOT NULL,
    [FileName] nvarchar(max) NULL,
    [Extensions] nvarchar(max) NULL,
    [Size] int NOT NULL,
    [Location] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_FileEntity] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_UserRole_RoleId] ON [ums].[UserRole] ([RoleId]);
GO

CREATE INDEX [IX_UserLogin_UserId] ON [ums].[UserLogin] ([UserId]);
GO

CREATE INDEX [IX_UserClaim_UserId] ON [ums].[UserClaim] ([UserId]);
GO

CREATE INDEX [EmailIndex] ON [ums].[User] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [ums].[User] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

ALTER TABLE [ums].[UserClaim] ADD CONSTRAINT [FK_UserClaim_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [ums].[User] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [ums].[UserLogin] ADD CONSTRAINT [FK_UserLogin_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [ums].[User] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [ums].[UserToken] ADD CONSTRAINT [FK_UserToken_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [ums].[User] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221224175626_AddFileEntity', N'6.0.6');
GO

COMMIT;
GO

