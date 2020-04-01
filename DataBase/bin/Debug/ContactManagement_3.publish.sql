﻿/*
Deployment script for ContactManagement

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ContactManagement"
:setvar DefaultFilePrefix "ContactManagement"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating [dbo].[Address]...';


GO
CREATE TABLE [dbo].[Address] (
    [Id]        BIGINT        NOT NULL,
    [Address]   VARCHAR (255) NOT NULL,
    [ZipCode]   VARCHAR (20)  NOT NULL,
    [City]      VARCHAR (50)  NOT NULL,
    [CompanyId] BIGINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Company]...';


GO
CREATE TABLE [dbo].[Company] (
    [Id]            BIGINT       NOT NULL,
    [Name]          VARCHAR (50) NOT NULL,
    [Vat]           VARCHAR (12) NOT NULL,
    [MainAddressId] BIGINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Contact]...';


GO
CREATE TABLE [dbo].[Contact] (
    [Id]            BIGINT       IDENTITY (1, 1) NOT NULL,
    [FirstName]     VARCHAR (50) NOT NULL,
    [LastName]      VARCHAR (50) NOT NULL,
    [PhoneNumber]   VARCHAR (50) NULL,
    [Vat]           VARCHAR (12) NULL,
    [MainAddressId] BIGINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[ContactRole]...';


GO
CREATE TABLE [dbo].[ContactRole] (
    [Id]        BIGINT NOT NULL,
    [CompanyId] BIGINT NOT NULL,
    [ContactId] BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [AK_TransactionID] UNIQUE NONCLUSTERED ([CompanyId] ASC, [ContactId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Address_Company]...';


GO
ALTER TABLE [dbo].[Address] WITH NOCHECK
    ADD CONSTRAINT [FK_Address_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Address] WITH CHECK CHECK CONSTRAINT [FK_Address_Company];


GO
PRINT N'Update complete.';


GO
