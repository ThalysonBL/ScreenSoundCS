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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110171503_projetoInicial')
BEGIN
    CREATE TABLE [Artistas] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NOT NULL,
        [FotoPerfil] nvarchar(max) NOT NULL,
        [Bio] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Artistas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110171503_projetoInicial')
BEGIN
    CREATE TABLE [Musicas] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Musicas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110171503_projetoInicial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231110171503_projetoInicial', N'7.0.14');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110180103_PopularTabela')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] ON;
    EXEC(N'INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
    VALUES (N''Djavan'', N''Djavan Caetano Viana é um cantor, compositor, arranjador, produtor musical, empresário, violonista e ex-futebolista brasileiro.'', N''https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110180103_PopularTabela')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] ON;
    EXEC(N'INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
    VALUES (N''Foo Fighters'', N''Foo Fighters é uma banda de rock alternativo americana formada por Dave Grohl em 1995.'', N''https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110180103_PopularTabela')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] ON;
    EXEC(N'INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
    VALUES (N''Pitty'', N''Priscilla Novaes Leone, mais conhecida como Pitty, é uma cantora, compositora, produtora, escritora, empresária, apresentadora e multi-instrumentista brasileira.'', N''https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110180103_PopularTabela')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] ON;
    EXEC(N'INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
    VALUES (N''Gilberto Gil'', N''Gilberto Passos Gil Moreira é um cantor, compositor, multi-instrumentista, produtor musical, político e escritor brasileiro.'', N''https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110180103_PopularTabela')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] ON;
    EXEC(N'INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
    VALUES (N''Foo Fighters'', N''Foo Fighters é uma banda de rock alternativo americana formada por Dave Grohl em 1995.'', N''https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110180103_PopularTabela')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] ON;
    EXEC(N'INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
    VALUES (N''Pitty'', N''Priscilla Novaes Leone, mais conhecida como Pitty, é uma cantora, compositora, produtora, escritora, empresária, apresentadora e multi-instrumentista brasileira.'', N''https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110180103_PopularTabela')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] ON;
    EXEC(N'INSERT INTO [Artistas] ([Nome], [Bio], [FotoPerfil])
    VALUES (N''Roque Abílio'', N''Recriando músicas famosas com uma reviravolta rockabilly, a Roque Abílio cativa o público com uma explosão autêntica do passado que ainda faz todo mundo dançar no presente.'', N''https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'Bio', N'FotoPerfil') AND [object_id] = OBJECT_ID(N'[Artistas]'))
        SET IDENTITY_INSERT [Artistas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110180103_PopularTabela')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231110180103_PopularTabela', N'7.0.14');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110182035_AdicionarColunaAnoLancamento')
BEGIN
    ALTER TABLE [Musicas] ADD [AnoLancamento] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231110182035_AdicionarColunaAnoLancamento')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231110182035_AdicionarColunaAnoLancamento', N'7.0.14');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113194025_PopularMusicas')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
        SET IDENTITY_INSERT [Musicas] ON;
    EXEC(N'INSERT INTO [Musicas] ([Nome], [AnoLancamento])
    VALUES (N''Oceano'', 1989)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
        SET IDENTITY_INSERT [Musicas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113194025_PopularMusicas')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
        SET IDENTITY_INSERT [Musicas] ON;
    EXEC(N'INSERT INTO [Musicas] ([Nome], [AnoLancamento])
    VALUES (N''Flor de Lis'', 1976)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
        SET IDENTITY_INSERT [Musicas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113194025_PopularMusicas')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
        SET IDENTITY_INSERT [Musicas] ON;
    EXEC(N'INSERT INTO [Musicas] ([Nome], [AnoLancamento])
    VALUES (N''Samurai'', 1982)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
        SET IDENTITY_INSERT [Musicas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113194025_PopularMusicas')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
        SET IDENTITY_INSERT [Musicas] ON;
    EXEC(N'INSERT INTO [Musicas] ([Nome], [AnoLancamento])
    VALUES (N''Se'', 1992)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Nome', N'AnoLancamento') AND [object_id] = OBJECT_ID(N'[Musicas]'))
        SET IDENTITY_INSERT [Musicas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113194025_PopularMusicas')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231113194025_PopularMusicas', N'7.0.14');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113203016_RelacionarArtistaMusica')
BEGIN
    ALTER TABLE [Musicas] ADD [ArtistaId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113203016_RelacionarArtistaMusica')
BEGIN
    CREATE INDEX [IX_Musicas_ArtistaId] ON [Musicas] ([ArtistaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113203016_RelacionarArtistaMusica')
BEGIN
    ALTER TABLE [Musicas] ADD CONSTRAINT [FK_Musicas_Artistas_ArtistaId] FOREIGN KEY ([ArtistaId]) REFERENCES [Artistas] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113203016_RelacionarArtistaMusica')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231113203016_RelacionarArtistaMusica', N'7.0.14');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20251001211246_adicaoTabelaGeneros')
BEGIN
    CREATE TABLE [Generos] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        [Descricao] nvarchar(max) NULL,
        CONSTRAINT [PK_Generos] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20251001211246_adicaoTabelaGeneros')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251001211246_adicaoTabelaGeneros', N'7.0.14');
END;
GO

COMMIT;
GO

