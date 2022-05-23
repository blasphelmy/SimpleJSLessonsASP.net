CREATE TABLE [dbo].[SessionModel]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[sessionID] varchar(64) not null,
	[accountHash] varchar(64) not null
)
