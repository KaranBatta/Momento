
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/11/2013 16:39:28
-- Generated from EDMX file: C:\Users\KaranB\Documents\Visual Studio 2012\Projects\Git\LoginApi\trunk\LoginApiApplication\LoginApiApplication\Subscriber.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LoginApiTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsersUserAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAccounts] DROP CONSTRAINT [FK_UsersUserAccount];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UserAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAccounts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] uniqueidentifier  NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Company] nvarchar(max)  NULL,
    [PhoneNumber] int  NULL,
    [DateOfBirth] datetime  NULL
);
GO

-- Creating table 'UserAccounts'
CREATE TABLE [dbo].[UserAccounts] (
    [UserAccountId] uniqueidentifier  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [LoginAttempts] int  NOT NULL,
    [Locked] bit  NOT NULL,
    [IsAdmin] bit  NOT NULL,
    [ConfirmedEmail] bit  NOT NULL,
    [IsAuthorized] bit  NOT NULL,
    [LastLogin] datetime  NOT NULL,
    [SignupDate] datetime  NOT NULL,
    [UserUserId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserAccountId] in table 'UserAccounts'
ALTER TABLE [dbo].[UserAccounts]
ADD CONSTRAINT [PK_UserAccounts]
    PRIMARY KEY CLUSTERED ([UserAccountId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserUserId] in table 'UserAccounts'
ALTER TABLE [dbo].[UserAccounts]
ADD CONSTRAINT [FK_UsersUserAccount]
    FOREIGN KEY ([UserUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersUserAccount'
CREATE INDEX [IX_FK_UsersUserAccount]
ON [dbo].[UserAccounts]
    ([UserUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------