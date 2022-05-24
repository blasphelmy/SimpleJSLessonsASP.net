CREATE TABLE [dbo].[DataTable]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
	[dataHash] varchar(24) not null unique,
	[data] varchar(max) not null,
	[title] varchar(128),
	[dateCreated] dateTime not null,
)
