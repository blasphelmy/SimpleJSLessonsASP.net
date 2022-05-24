CREATE TABLE [dbo].[apiUserInformation]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[accountHash] VARCHAR(64) UNIQUE NOT NULL,
	[firstName] VARCHAR(24) NOT NULL,
	[lastName] VARCHAR(24) NOT NULL,
	[email] varchar(64),
	[ctclinkID] varchar(24),
	[datemodified] datetime,
    constraint [fk_userdata_to_user] foreign key (accountHash) references apiUser(accountHash)
)
