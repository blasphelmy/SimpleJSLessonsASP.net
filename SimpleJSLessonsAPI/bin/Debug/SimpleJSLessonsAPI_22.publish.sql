﻿/*
Deployment script for SimpleJSLessons

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SimpleJSLessons"
:setvar DefaultFilePrefix "SimpleJSLessons"
:setvar DefaultDataPath "C:\Users\David Nguyen\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\David Nguyen\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Table [dbo].[apiUser]...';


GO
CREATE TABLE [dbo].[apiUser] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [accountHash] VARCHAR (64)  NOT NULL,
    [username]    VARCHAR (30)  NOT NULL,
    [dateCreated] DATETIME      NOT NULL,
    [profileData] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([accountHash] ASC),
    UNIQUE NONCLUSTERED ([username] ASC)
);


GO
PRINT N'Creating Table [dbo].[apiUserInformation]...';


GO
CREATE TABLE [dbo].[apiUserInformation] (
    [ID]           INT          IDENTITY (1, 1) NOT NULL,
    [accountHash]  VARCHAR (64) NOT NULL,
    [firstName]    VARCHAR (24) NOT NULL,
    [lastName]     VARCHAR (24) NOT NULL,
    [email]        VARCHAR (64) NULL,
    [ctclinkID]    VARCHAR (24) NULL,
    [datemodified] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([accountHash] ASC)
);


GO
PRINT N'Creating Table [dbo].[Authors]...';


GO
CREATE TABLE [dbo].[Authors] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [dataHash]     VARCHAR (24) NOT NULL,
    [username]     VARCHAR (20) NOT NULL,
    [dateAuthored] DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[dataDataTable]...';


GO
CREATE TABLE [dbo].[dataDataTable] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [imageData]  VARCHAR (MAX) NOT NULL,
    [dataHash]   VARCHAR (24)  NOT NULL,
    [uploadedBy] VARCHAR (30)  NULL,
    [title]      VARCHAR (128) NULL,
    [isPublic]   INT           NOT NULL,
    [uploadDate] DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [uniqueImgToData] UNIQUE NONCLUSTERED ([uploadedBy] ASC, [dataHash] ASC)
);


GO
PRINT N'Creating Table [dbo].[DataTable]...';


GO
CREATE TABLE [dbo].[DataTable] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [dataHash]    VARCHAR (24)  NOT NULL,
    [data]        VARCHAR (MAX) NOT NULL,
    [title]       VARCHAR (128) NULL,
    [dateCreated] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([dataHash] ASC)
);


GO
PRINT N'Creating Table [dbo].[LikesTable]...';


GO
CREATE TABLE [dbo].[LikesTable] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [dataHash] VARCHAR (24) NOT NULL,
    [username] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [unique_likes] UNIQUE NONCLUSTERED ([dataHash] ASC, [username] ASC)
);


GO
PRINT N'Creating Table [dbo].[SessionModel]...';


GO
CREATE TABLE [dbo].[SessionModel] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [sessionID]   VARCHAR (64) NOT NULL,
    [accountHash] VARCHAR (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[UserSavedDemos]...';


GO
CREATE TABLE [dbo].[UserSavedDemos] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [accountHash] VARCHAR (64)  NOT NULL,
    [demoHash]    VARCHAR (24)  NOT NULL,
    [demoTitle]   VARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [unique_demo_to_user] UNIQUE NONCLUSTERED ([accountHash] ASC, [demoHash] ASC)
);


GO
PRINT N'Creating Table [dbo].[userSavedLessons]...';


GO
CREATE TABLE [dbo].[userSavedLessons] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [accountHash] VARCHAR (64)  NOT NULL,
    [lessonHash]  VARCHAR (24)  NOT NULL,
    [lessonTitle] VARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [unique_lesson_to_user] UNIQUE NONCLUSTERED ([accountHash] ASC, [lessonHash] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[fk_userdata_to_user]...';


GO
ALTER TABLE [dbo].[apiUserInformation]
    ADD CONSTRAINT [fk_userdata_to_user] FOREIGN KEY ([accountHash]) REFERENCES [dbo].[apiUser] ([accountHash]);


GO
PRINT N'Creating Foreign Key [dbo].[AuthorsToData]...';


GO
ALTER TABLE [dbo].[Authors]
    ADD CONSTRAINT [AuthorsToData] FOREIGN KEY ([dataHash]) REFERENCES [dbo].[DataTable] ([dataHash]);


GO
PRINT N'Creating Foreign Key [dbo].[validDataReference]...';


GO
ALTER TABLE [dbo].[dataDataTable]
    ADD CONSTRAINT [validDataReference] FOREIGN KEY ([dataHash]) REFERENCES [dbo].[DataTable] ([dataHash]);


GO
PRINT N'Creating Foreign Key [dbo].[reference_to_realuser]...';


GO
ALTER TABLE [dbo].[LikesTable]
    ADD CONSTRAINT [reference_to_realuser] FOREIGN KEY ([username]) REFERENCES [dbo].[apiUser] ([username]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_SessionModel_to_apiUser]...';


GO
ALTER TABLE [dbo].[SessionModel]
    ADD CONSTRAINT [fk_SessionModel_to_apiUser] FOREIGN KEY ([accountHash]) REFERENCES [dbo].[apiUser] ([accountHash]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_accountHash_to_user]...';


GO
ALTER TABLE [dbo].[UserSavedDemos]
    ADD CONSTRAINT [fk_accountHash_to_user] FOREIGN KEY ([accountHash]) REFERENCES [dbo].[apiUser] ([accountHash]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_demohash_to_dataTable]...';


GO
ALTER TABLE [dbo].[UserSavedDemos]
    ADD CONSTRAINT [fk_demohash_to_dataTable] FOREIGN KEY ([demoHash]) REFERENCES [dbo].[DataTable] ([dataHash]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_lessonHash_to_user]...';


GO
ALTER TABLE [dbo].[userSavedLessons]
    ADD CONSTRAINT [fk_lessonHash_to_user] FOREIGN KEY ([accountHash]) REFERENCES [dbo].[apiUser] ([accountHash]);


GO
PRINT N'Creating Foreign Key [dbo].[fk_lessonHash_to_dataTable]...';


GO
ALTER TABLE [dbo].[userSavedLessons]
    ADD CONSTRAINT [fk_lessonHash_to_dataTable] FOREIGN KEY ([lessonHash]) REFERENCES [dbo].[DataTable] ([dataHash]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '51cc19c4-4401-495e-a81d-549a2f375cb5')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('51cc19c4-4401-495e-a81d-549a2f375cb5')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '1b02359b-3af4-471d-b8f2-99f9e3c7583a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('1b02359b-3af4-471d-b8f2-99f9e3c7583a')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c2cc0194-d326-4b9a-8c3b-4f8fda3bf0be')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c2cc0194-d326-4b9a-8c3b-4f8fda3bf0be')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'af476e26-774d-42ac-b208-fac1078f679e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('af476e26-774d-42ac-b208-fac1078f679e')

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO