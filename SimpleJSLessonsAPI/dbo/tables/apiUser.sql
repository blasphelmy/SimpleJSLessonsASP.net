CREATE TABLE [dbo].[apiUser]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [accountHash] VARCHAR(64) UNIQUE NOT NULL,
    [username] VARCHAR(30) UNIQUE NOT NULL,
    [dateCreated] DATETIME not null,
    [profileData] varchar(max),
)
