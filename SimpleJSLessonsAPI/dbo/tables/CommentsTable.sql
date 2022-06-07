CREATE TABLE [dbo].[CommentsTable]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[datahash] varchar(24) not null,
	[commentAuthorUsername] varchar(30) not null,
	[comment] varchar(255) not null,
	constraint [reference_to_realuser_fromCommentsTable] foreign key ([commentAuthorUsername]) references apiUser(username)
)
