INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES (DATEADD(HH, 1, GETUTCDATE()),DATEADD(HH, 2, GETUTCDATE()), 'MainLibrary', 'Film', 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film1', 'horror', 'stuff1', 5, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film2', 'sci-fi', 'stuff2', 10, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film3', 'sci-fi', 'stuff3', 8, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film4', 'comedy', 'stuff4', 20, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film5', 'comedy', 'stuff5', 9, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film6', 'action', 'stuff6', 6, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film7', 'romance', 'stuff7', 3, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film8', 'action', 'stuff8', 5, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film9', 'sci-fi', 'stuff9', 22, 2)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film10', 'bibliography', 'stuff10',30, 2)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film11', 'animation', 'stuff11', 11, 2)

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

INSERT INTO [VOTERS] (VoterID)
VALUES (11)

INSERT INTO [VOTERS] (VoterID)
VALUES (12)

INSERT INTO [VOTERS] (VoterID)
VALUES (13)

INSERT INTO [VOTERS] (VoterID)
VALUES (14)

INSERT INTO [VOTERS] (VoterID)
VALUES (15)

INSERT INTO [VOTERS] (VoterID)
VALUES (16)

INSERT INTO [VOTERS] (VoterID)
VALUES (17)

INSERT INTO [VOTERS] (VoterID)
VALUES (18)

INSERT INTO [VOTERS] (VoterID)
VALUES (19)

INSERT INTO [VOTERS] (VoterID)
VALUES (20)


SELECT * FROM [EVENTS]
SELECT * FROM [BLOCKS]e
SELECT * FROM [FILMS]
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
