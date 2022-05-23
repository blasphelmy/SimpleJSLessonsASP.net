CREATE TABLE [dbo].[userSavedLessons]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[accountHash] VARCHAR(64) NOT NULL,
	[lessonHash] VARCHAR(24) not null,
	[lessonTitle] varchar(128),
	constraint [fk_lessonHash_to_user] foreign key (accountHash) references apiUser(accountHash)
)
