CREATE TABLE [dbo].[apiUserInformation]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[accountHash] VARCHAR(64) UNIQUE NOT NULL,
	[firstName] VARCHAR(24) NOT NULL,
	[lastName] VARCHAR(24) NOT NULL,
	constraint [fk_userdata_to_user] foreign key (accountHash) references apiUser(accountHash)
)
