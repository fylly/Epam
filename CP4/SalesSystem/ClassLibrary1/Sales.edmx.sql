
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/23/2015 23:45:41
-- Generated from EDMX file: D:\!Home Data\Documents\CP4\SalesSystem\ClassLibrary1\Sales.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SalesSystemDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientSaleItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleItemSet] DROP CONSTRAINT [FK_ClientSaleItem];
GO
IF OBJECT_ID(N'[dbo].[FK_GoodsSaleItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleItemSet] DROP CONSTRAINT [FK_GoodsSaleItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerSaleItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleItemSet] DROP CONSTRAINT [FK_ManagerSaleItem];
GO
IF OBJECT_ID(N'[dbo].[FK_InputFileSaleItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleItemSet] DROP CONSTRAINT [FK_InputFileSaleItem];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientSet];
GO
IF OBJECT_ID(N'[dbo].[GoodsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GoodsSet];
GO
IF OBJECT_ID(N'[dbo].[ManagerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManagerSet];
GO
IF OBJECT_ID(N'[dbo].[SaleItemSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SaleItemSet];
GO
IF OBJECT_ID(N'[dbo].[InputFileSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InputFileSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Barcode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Managers'
CREATE TABLE [dbo].[Managers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ManagerName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SaleItems'
CREATE TABLE [dbo].[SaleItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SaleDate] nvarchar(max)  NOT NULL,
    [SaleSum] float  NOT NULL,
    [Client_Id] int  NOT NULL,
    [Good_Id] int  NOT NULL,
    [Manager_Id] int  NOT NULL,
    [InputFile_Id] int  NOT NULL
);
GO

-- Creating table 'InputFiles'
CREATE TABLE [dbo].[InputFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileTitle] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Managers'
ALTER TABLE [dbo].[Managers]
ADD CONSTRAINT [PK_Managers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SaleItems'
ALTER TABLE [dbo].[SaleItems]
ADD CONSTRAINT [PK_SaleItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InputFiles'
ALTER TABLE [dbo].[InputFiles]
ADD CONSTRAINT [PK_InputFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Client_Id] in table 'SaleItems'
ALTER TABLE [dbo].[SaleItems]
ADD CONSTRAINT [FK_ClientSaleItem]
    FOREIGN KEY ([Client_Id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientSaleItem'
CREATE INDEX [IX_FK_ClientSaleItem]
ON [dbo].[SaleItems]
    ([Client_Id]);
GO

-- Creating foreign key on [Good_Id] in table 'SaleItems'
ALTER TABLE [dbo].[SaleItems]
ADD CONSTRAINT [FK_GoodsSaleItem]
    FOREIGN KEY ([Good_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GoodsSaleItem'
CREATE INDEX [IX_FK_GoodsSaleItem]
ON [dbo].[SaleItems]
    ([Good_Id]);
GO

-- Creating foreign key on [Manager_Id] in table 'SaleItems'
ALTER TABLE [dbo].[SaleItems]
ADD CONSTRAINT [FK_ManagerSaleItem]
    FOREIGN KEY ([Manager_Id])
    REFERENCES [dbo].[Managers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerSaleItem'
CREATE INDEX [IX_FK_ManagerSaleItem]
ON [dbo].[SaleItems]
    ([Manager_Id]);
GO

-- Creating foreign key on [InputFile_Id] in table 'SaleItems'
ALTER TABLE [dbo].[SaleItems]
ADD CONSTRAINT [FK_InputFileSaleItem]
    FOREIGN KEY ([InputFile_Id])
    REFERENCES [dbo].[InputFiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InputFileSaleItem'
CREATE INDEX [IX_FK_InputFileSaleItem]
ON [dbo].[SaleItems]
    ([InputFile_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------