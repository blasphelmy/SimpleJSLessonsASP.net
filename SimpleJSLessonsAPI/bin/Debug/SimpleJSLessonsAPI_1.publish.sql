﻿/*
Deployment script for SimpleJSLessonsAPIData

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SimpleJSLessonsAPIData"
:setvar DefaultFilePrefix "SimpleJSLessonsAPIData"
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
USE [$(DatabaseName)];


GO
PRINT N'Dropping [dbo].[fk_userdata_to_user]...';


GO
ALTER TABLE [dbo].[apiUserInformation] DROP CONSTRAINT [fk_userdata_to_user];


GO
PRINT N'Dropping [dbo].[fk_lessonHash_to_user]...';


GO
ALTER TABLE [dbo].[userSavedLessons] DROP CONSTRAINT [fk_lessonHash_to_user];


GO
PRINT N'Starting rebuilding table [dbo].[apiUserInformation]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_apiUserInformation] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [accountHash] VARCHAR (64) NOT NULL,
    [firstName]   VARCHAR (24) NOT NULL,
    [lastName]    VARCHAR (24) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([accountHash] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[apiUserInformation])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_apiUserInformation] ([accountHash], [firstName], [lastName])
        SELECT [accountHash],
               [firstName],
               [lastName]
        FROM   [dbo].[apiUserInformation];
    END

DROP TABLE [dbo].[apiUserInformation];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_apiUserInformation]', N'apiUserInformation';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[userSavedLessons]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_userSavedLessons] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [accountHash] VARCHAR (64) NOT NULL,
    [lessonHash]  INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[userSavedLessons])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_userSavedLessons] ([accountHash], [lessonHash])
        SELECT [accountHash],
               [lessonHash]
        FROM   [dbo].[userSavedLessons];
    END

DROP TABLE [dbo].[userSavedLessons];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_userSavedLessons]', N'userSavedLessons';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[fk_userdata_to_user]...';


GO
ALTER TABLE [dbo].[apiUserInformation] WITH NOCHECK
    ADD CONSTRAINT [fk_userdata_to_user] FOREIGN KEY ([accountHash]) REFERENCES [dbo].[apiUser] ([accountHash]);


GO
PRINT N'Creating [dbo].[fk_lessonHash_to_user]...';


GO
ALTER TABLE [dbo].[userSavedLessons] WITH NOCHECK
    ADD CONSTRAINT [fk_lessonHash_to_user] FOREIGN KEY ([accountHash]) REFERENCES [dbo].[apiUser] ([accountHash]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[apiUserInformation] WITH CHECK CHECK CONSTRAINT [fk_userdata_to_user];

ALTER TABLE [dbo].[userSavedLessons] WITH CHECK CHECK CONSTRAINT [fk_lessonHash_to_user];


GO
PRINT N'Update complete.';


GO
