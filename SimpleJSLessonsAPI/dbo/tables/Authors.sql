CREATE TABLE [dbo].[Authors]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[dataHash] varchar(24) not null,
	[username] varchar(20) not null,
	constraint [AuthorsToData] foreign key (dataHash) references DataTable(dataHash),
)
