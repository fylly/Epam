
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/28/2015 23:32:08
-- Generated from EDMX file: D:\!Work\!GitHub-Fylly\Epam\CP4\SalesSystem\ClassLibrary1\Sales.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Managers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Managers];
GO
IF OBJECT_ID(N'[dbo].[InputFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InputFiles];
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

-- Creating table 'InputFiles'
CREATE TABLE [dbo].[InputFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileTitle] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SaleItems'
CREATE TABLE [dbo].[SaleItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SaleDate] datetime  NOT NULL,
    [SaleSum] float  NOT NULL,
    [Customer_Id] int  NOT NULL,
    [Product_Id] int  NOT NULL,
    [Manager_Id] int  NOT NULL,
    [InputFile_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'InputFiles'
ALTER TABLE [dbo].[InputFiles]
ADD CONSTRAINT [PK_InputFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SaleItems'
ALTER TABLE [dbo].[SaleItems]
ADD CONSTRAINT [PK_SaleItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Customer_Id] in table 'SaleItems'
ALTER TABLE [dbo].[SaleItems]
ADD CONSTRAINT [FK_CustomerSaleItem]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerSaleItem'
CREATE INDEX [IX_FK_CustomerSaleItem]
ON [dbo].[SaleItems]
    ([Customer_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'SaleItems'
ALTER TABLE [dbo].[SaleItems]
ADD CONSTRAINT [FK_ProductSaleItem]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductSaleItem'
CREATE INDEX [IX_FK_ProductSaleItem]
ON [dbo].[SaleItems]
    ([Product_Id]);
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