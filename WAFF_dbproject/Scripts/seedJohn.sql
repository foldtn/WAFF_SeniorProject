DELETE FROM [FILMARTISTS]
DELETE FROM [VOTES]
DELETE FROM [FILMS]
DELETE FROM [BLOCKS]
DELETE FROM [EVENTS]
DELETE FROM [VOTERS]
DELETE FROM [ARTISTS]

DBCC CHECKIDENT ('EVENTS', RESEED, 0)
DBCC CHECKIDENT ('ARTISTS', RESEED, 0)
DBCC CHECKIDENT ('BLOCKS', RESEED, 0)
DBCC CHECKIDENT ('FILMS', RESEED, 0)

INSERT INTO [EVENTS] (EventStartDate, EventEndDate, EventLocation)
VALUES ('2015-10-16','2015-10-18','Jacksonville')

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2015-10-16 10:00', '2015-10-16 11:15', 'Main Library', 'Film', 1)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES ('2015-10-17 10:00', '2015-10-17 12:00', 'Main Library', 'Film', 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('The Switcheroo', 'Comedy', 'The case of the switched items', 20, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('Soda of Doom', 'Animation', 'Would be evil doers try to stop event', 8, 2)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('Adventures of Pelican Pete', 'Animation', 'Pelican Pete finds a hat', 6, 2)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('The Music is Moving', 'Educational', 'A look at the visual side of music', 5, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('Ability: Journey with Rachel', 'Documentory', 'Follow the life of an extraordinary teen', 20, 2)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('The Sad Snow Man', 'Action', 'This simple story is about a boy who makes a snowman’s dream a reality.', 5, 1)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Dani', 'Bowman', NULL, NULL, NULL, NULL, NULL, 0, NULL)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Englewood Elementary', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Adam', 'Ricketts', NULL, NULL, NULL, NULL, NULL, 0, NULL)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Pierre', 'Schantz', NULL, NULL, NULL, NULL, NULL, 0, NULL)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Keaton', 'Bicknell', NULL, NULL, NULL, NULL, NULL, 0, NULL)

INSERT INTO [ARTISTS] (ArtistFName, ArtistLName, ArtistCompany, ArtistEmail, ArtistAddress, ArtistCity, ArtistState, ArtistZip, ArtistPhone)
VALUES ('Kate', 'Duhamel', NULL, NULL, NULL, NULL, NULL, 0, NULL)

INSERT INTO [VOTERS] (VoterID)
VALUES (1)

INSERT INTO [VOTERS] (VoterID)
VALUES (2)

INSERT INTO [VOTERS] (VoterID)
VALUES (3)

INSERT INTO [VOTERS] (VoterID)
VALUES (4)

INSERT INTO [VOTERS] (VoterID)
VALUES (5)

INSERT INTO [VOTERS] (VoterID)
VALUES (6)

INSERT INTO [VOTERS] (VoterID)
VALUES (7)

INSERT INTO [VOTERS] (VoterID)
VALUES (8)

INSERT INTO [VOTERS] (VoterID)
VALUES (9)

INSERT INTO [VOTERS] (VoterID)
VALUES (10)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 1, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 1, 1)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (3, 1, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 1, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (5, 1, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (6, 1, 6)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (7, 1, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (8, 1, 4)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (1, 2, 2)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (2, 2, 2)

SELECT * FROM [EVENTS]
SELECT * FROM [BLOCKS]
SELECT * FROM [FILMS]
SELECT * FROM [ARTISTS]
SELECT * FROM [VOTERS]
SELECT * FROM [VOTES] ORDER BY [BlockId]


SELECT f.FilmID, f.VotesForFilm, b.VotesPerBlock
FROM	(
			SELECT	FilmID, BlockID, COUNT(FilmId) AS [VotesForFilm]
			FROM [VOTES] GROUP BY FilmID, BlockID
		) f
JOIN	(
			SELECT BlockID, COUNT(BlockId) AS [VotesPerBlock]
			FROM [VOTES] GROUP BY BlockID
		) b
ON f.BlockID = b.BlockID