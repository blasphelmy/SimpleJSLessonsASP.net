use SimpleJSLessonsAPIData
insert into apiUser(accountHash, username) values('5c51742e338cb353c7cc1078ec9b49cf76dc1e9040ab29e0ce95383da97fcd71', 'davidnguyen')
insert into apiUserInformation(accountHash, firstName, lastName) values ('5c51742e338cb353c7cc1078ec9b49cf76dc1e9040ab29e0ce95383da97fcd71', 'David', 'Nguyen')

insert into apiUser(accountHash, username) values('ef2e2caee2a5c5d49087f4aba93dc1efa509eda12a5546d1bd18898be653bbe3', 'testuser')
insert into apiUserInformation(accountHash, firstName, lastName) values ('ef2e2caee2a5c5d49087f4aba93dc1efa509eda12a5546d1bd18898be653bbe3', 'test', 'user')
insert into SessionModel(sessionID, accountHash) values('key', 'accounthash')

select * from apiUserInformation
select * from apiUser
select * from SessionModel
select * from UserSavedDemos
select * from userSavedLessons

drop database SimpleJSLessonsAPIData