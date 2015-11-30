﻿DELETE FROM [FILMARTISTS]
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
VALUES (GETUTCDATE(),DATEADD(d, 3, GETUTCDATE()),'Jacksonville')

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES (GETUTCDATE(),DATEADD(HH, 1, GETUTCDATE()), 'MainLibrary', 'Film', 1)

INSERT INTO [BLOCKS] (BlockStart, BlockEnd, BlockLocation, BlockType, EventID)
VALUES (DATEADD(HH, 1, GETUTCDATE()),DATEADD(HH, 2, GETUTCDATE()), 'MainLibrary', 'Film', 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film1', 'horror', 'stuff1', 5, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film2', 'sci-fi', 'stuff2', 10, 2)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film3', 'sci-fi', 'stuff3', 8, 2)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film4', 'comedy', 'stuff4', 20, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film5', 'comedy', 'stuff5', 9, 1)

INSERT INTO [FILMS] (FilmName, FilmGenre, FilmDesc, FilmLength, BlockId)
VALUES ('film6', 'action', 'stuff6', 6, 2)

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
VALUES (3, 1, 5)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (4, 1, 5)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (5, 1, 5)

INSERT INTO [VOTES] (VoterId, BlockId, FilmId)
VALUES (6, 1, 5)

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
SELECT * FROM [VOTERS]
SELECT * FROM [VOTES] ORDER BY [BlockId]