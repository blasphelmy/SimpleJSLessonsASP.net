CREATE TABLE [dbo].[Authors]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[dataHash] varchar(24) not null,
	[username] varchar(20) not null,
	[dateAuthored] datetime not null,
	constraint [AuthorsToData] foreign key (dataHash) references DataTable(dataHash),
)
