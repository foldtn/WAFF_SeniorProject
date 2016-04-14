USE [WAFF]
DELETE FROM [USERS]
DELETE FROM [FILMARTISTS]
DELETE FROM [FILMBLOCKS]
DELETE FROM [VOTES]
DELETE FROM [FILMS]
DELETE FROM [BLOCKS]
DELETE FROM [EVENTS]
DELETE FROM [VOTERS]
DELETE FROM [ARTISTS]

DBCC CHECKIDENT ('USERS', RESEED, 0)
DBCC CHECKIDENT ('EVENTS', RESEED, 0)
DBCC CHECKIDENT ('ARTISTS', RESEED, 0)
DBCC CHECKIDENT ('BLOCKS', RESEED, 0)
DBCC CHECKIDENT ('FILMS', RESEED, 0)

INSERT INTO [USERS] (UserEmail, UserPassword)
VALUES ('email@unf.edu', 'password')

INSERT INTO [EVENTS] (EventStartDate, EventEndDate, EventLocation)
VALUES ('2015-10-16','2015-10-18','Jacksonville')

INSERT INTO [EVENTS] (EventStartDate, EventEndDate, EventLocation)
VALUES (CONVERT (date, GETDATE()-1), CONVERT (date, GETDATE()+1), 'Jacksonville')

INSERT INTO [EVENTS] (EventStartDate, EventEndDate, EventLocation)
VALUES ('2016-10-16','2016-10-18','Jacksonville')

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2015-10-16 10:00', '2015-10-16 11:15', 'Main Library', 'Voting', 1)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2015-10-16 11:30', '2015-10-16 12:30', 'Main Library', 'Voting', 1)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2015-10-16 13:00', '2015-10-16 14:15', 'Main Library', 'Voting', 1)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2015-10-17 10:00', '2015-10-17 12:00', 'Main Library', 'Voting', 1)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2015-10-17 12:30', '2015-10-17 13:30', 'Main Library', 'Voting', 1)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2015-10-17 13:45', '2015-10-17 15:00', 'Main Library', 'Voting', 1)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2015-10-17 16:00', '2015-10-17 17:25', 'Main Library', 'Voting', 1)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2016-10-16 11:30', '2016-10-16 12:30', 'Main Library', 'Voting', 2)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2016-10-16 13:00', '2016-10-16 14:15', 'Main Library', 'Voting', 2)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2016-10-17 10:00', '2016-10-17 12:00', 'Main Library', 'Voting', 2)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2016-10-17 12:30', '2016-10-17 13:30', 'Main Library', 'Voting', 2)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('The Switcheroo', 'Experimental', 'The case of the switched items', 20)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('Soda of Doom', 'Animation', 'Would be evil doers try to stop event', 8)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('Adventures of Pelican Pete', 'Animation', 'Pelican Pete finds a hat', 6)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('The Music is Moving', 'Student', 'A look at the visual side of music', 5)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('Ability: Journey with Rachel', 'Documentory', 'Follow the life of an extraordinary teen', 20)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('The Sad Snow Man', 'New Media', 'This simple story is about a boy who makes a snowman’s dream a reality.', 5)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('The Great Codesby', 'Documentory', 'Dummy film 7', 7)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('Coding 101', 'Student', 'Dummy film 8', 4)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('To Code or Not to code', 'Animation', 'Dummy film 9', 3)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('The Art of Coding', 'Student', 'Dummy film 10', 8)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength)
VALUES ('Harry Coder and the Coders Code', 'New Media', 'Dummy film 11', 14)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Dani', 'Bowman', NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Englewood Elementary', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Adam', 'Ricketts', NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Pierre', 'Schantz', NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Keaton', 'Bicknell', NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Kate', 'Duhamel', NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (1, 1)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (1, 3)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (1, 5)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (1, 7)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (2, 1)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (2, 2)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (2, 4)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (2, 6)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (3, 1)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (3, 2)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (3, 8)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (3, 9)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (4, 1)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (4, 3)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (4, 4)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (4, 10)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (5, 1)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (5, 3)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (5, 4)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (5, 5)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (6, 1)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (6, 4)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (6, 6)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (6, 11)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (7, 1)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (7, 6)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (8, 1)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (8, 2)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (8, 5)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (8, 6)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (9, 1)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (9, 5)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (10, 1)

INSERT INTO [FILMBLOCKS] (BlockID, FilmID)
VALUES (10, 3)

INSERT INTO [FILMARTISTS] (ArtistID, FilmID)
VALUES (1, 1)

INSERT INTO [FILMARTISTS] (ArtistID, FilmID)
VALUES (1, 4)

INSERT INTO [FILMARTISTS] (ArtistID, FilmID)
VALUES (2, 2)

INSERT INTO [FILMARTISTS] (ArtistID, FilmID)
VALUES (3, 3)

INSERT INTO [FILMARTISTS] (ArtistID, FilmID)
VALUES (4, 4)

INSERT INTO [FILMARTISTS] (ArtistID, FilmID)
VALUES (4, 6)

INSERT INTO [FILMARTISTS] (ArtistID, FilmID)
VALUES (5, 5)

INSERT INTO [FILMARTISTS] (ArtistID, FilmID)
VALUES (6, 6)

INSERT INTO [VOTERS] (VoterID, VoterAge, VoterEthnicity, VoterEducation, VoterIncome)
VALUES (1, 29, 'NativeAmerican/Alaska Native', 'Some College', '$29,000')

INSERT INTO [VOTERS] (VoterID, VoterAge, VoterEthnicity, VoterEducation, VoterIncome)
VALUES (2, 35, 'Cacasian', 'Bachelor''s', '$35,000')

INSERT INTO [VOTERS] (VoterID)
VALUES (3)

INSERT INTO [VOTERS] (VoterID, VoterAge, VoterEthnicity, VoterEducation, VoterIncome)
VALUES (4, 54, 'Hispanic', 'Master''s', '$200,001')

INSERT INTO [VOTERS] (VoterID)
VALUES (5)

INSERT INTO [VOTERS] (VoterID, VoterAge, VoterEthnicity, VoterEducation, VoterIncome)
VALUES (6, 55, 'Asian/Pacific Islander', 'Some College', '$123,000.23')

INSERT INTO [VOTERS] (VoterID, VoterAge, VoterEthnicity, VoterEducation, VoterIncome)
VALUES (7, 18, 'Asian/Pacific Islander', 'Doctorate', '$15,231,021')

INSERT INTO [VOTERS] (VoterID)
VALUES (8)

INSERT INTO [VOTERS] (VoterID, VoterAge, VoterEthnicity, VoterEducation, VoterIncome)
VALUES (9, 21, 'Prefer Not to Answer', 'High School Diploma', '$33,020')

INSERT INTO [VOTERS] (VoterID, VoterAge, VoterEthnicity, VoterEducation)
VALUES (10, 32, 'Caucasian', 'Master''s')

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 1, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 1, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (3, 1, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 1, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (5, 1, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (6, 1, 3)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (7, 1, 3)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (8, 1, 5)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (9, 1, 7)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (10, 1, 7)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 2, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 2, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (3, 2, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 2, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (5, 2, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (6, 2, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (7, 2, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (8, 2, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (9, 2, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (10, 2, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 3, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 3, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (3, 3, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 3, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (5, 3, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (6, 3, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (7, 3, 8)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (8, 3, 9)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (9, 3, 9)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (10, 3, 9)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 4, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 4, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (3, 4, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 4, 3)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (5, 4, 3)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (6, 4, 3)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (7, 4, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (8, 4, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (9, 4, 4)


INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (10, 4, 10)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 5, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 5, 3)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (3, 5, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 5, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (5, 5, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (6, 5, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (7, 5, 5)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (8, 5, 5)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (9, 5, 5)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 6, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 6, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (3, 6, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 6, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (5, 6, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (6, 6, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (7, 6, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (8, 6, 11)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (9, 6, 11)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (10, 6, 11)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 7, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 7, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (3, 7, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 7, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (5, 7, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (6, 7, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (7, 7, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 8, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 8, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (3, 8, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 8, 5)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (5, 8, 5)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (6, 8, 5)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 9, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 9, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 10, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 10, 3)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (3, 10, 3)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 10, 3)

SELECT * FROM [USERS]
SELECT * FROM [EVENTS]
SELECT * FROM [BLOCKS]
SELECT * FROM [FILMS]
SELECT * FROM [FILMBLOCKS] ORDER BY BlockID, FilmID
SELECT * FROM [ARTISTS]
SELECT * FROM [FILMARTISTS]
SELECT * FROM [VOTERS]
SELECT * FROM [VOTES] ORDER BY [BlockId]
