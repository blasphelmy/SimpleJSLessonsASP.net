CREATE TABLE [dbo].[UserSavedDemos]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[accountHash] VARCHAR(64) NOT NULL,
	[demoHash] VARCHAR(24) not null,
	[demoTitle] varchar(128),
	constraint [fk_demoHash_to_user] foreign key (accountHash) references apiUser(accountHash)
)