CREATE TABLE [dbo].[UserSavedDemos]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[accountHash] VARCHAR(64) NOT NULL,
	[demoHash] VARCHAR(24) not null,
	[demoTitle] varchar(128),
	constraint [fk_accountHash_to_user] foreign key (accountHash) references apiUser(accountHash),
	constraint [fk_demohash_to_dataTable] foreign key (demohash) references DataTable(dataHash),
	constraint [unique_demo_to_user] unique(accountHash, demoHash)
)