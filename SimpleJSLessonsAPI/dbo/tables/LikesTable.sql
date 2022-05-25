CREATE TABLE [dbo].[LikesTable]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[dataHash] varchar(24) not null,
	[username] varchar(30) not null,
	constraint [unique_likes] unique(dataHash, username),
	constraint [reference_to_realuser] foreign key (username) references apiUser(username)
)
