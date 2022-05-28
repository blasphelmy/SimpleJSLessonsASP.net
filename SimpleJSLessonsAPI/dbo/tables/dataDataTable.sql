CREATE TABLE [dbo].[dataDataTable]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[imageData] varchar(max) not null,
	[dataHash] varchar(24) not null,
	[uploadedBy] varchar(24),
	[title] varchar(128),
	[isPublic] int not null,
	[uploadDate] date not null,
	constraint [uniqueImgToData] unique(uploadedBy, dataHash),
	constraint [validDataReference] foreign key (dataHash) references DataTable(dataHash),
)
