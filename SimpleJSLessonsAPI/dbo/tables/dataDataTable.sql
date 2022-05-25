CREATE TABLE [dbo].[dataDataTable]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[imageData] varchar(max) not null,
	[dataHash] varchar(24) not null,
	[uploadedBy] varchar(30),
	[title] varchar(128),
	constraint [uniqueImgToData] unique(uploadedBy, dataHash),
	constraint [validDataReference] foreign key (dataHash) references DataTable(dataHash)
)
