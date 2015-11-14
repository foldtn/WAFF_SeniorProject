INSERT INTO [EVENTS]
	(EventStartDate
	,EventEndDate
	,EventLocation)
VALUES
	(GETUTCDATE()
	,DATEADD(d, 3, GETUTCDATE())
	,'Jacksonville')

INSERT INTO BLOCKS
	(BlockStart
	,BlockEnd
	,BlockLocation
	,BlockType
	,EventID)
VALUES
	(GETUTCDATE()
	,DATEADD(HOUR, 2, GETUTCDATE())
	,'Musuem'
	,'Type 1'
	,1)

INSERT INTO FILMS
	(FilmName
	,FilmGenre
	,FilmDesc
	,FilmLength
	,BlockId)
VALUES
	('Film 1'
	,'Genre 1'
	,'This is a descriptuion'
	,70
	,1)


INSERT INTO Artists
	(ArtistFName
	,ArtistLName
	,ArtistCompany
	,ArtistEmail
	,ArtistAddress
	,ArtistCity
	,ArtistState
	,ArtistZip
	,ArtistPhone)
VALUES
	('s2dfg'
	,'cfampsdfgernini'
	,'fislm c3e4ompany A'
	,'ni@3fidlm.com'
	,'24 Stdgreet'
	,'Jasonville'
	,'Flida'
	,'2325'
	,'2342 1552')

INSERT INTO FILMARTISTS
	(FilmID
	,ArtistID)
VALUES
	(1,
	1)
 
INSERT INTO FILMARTISTS
	(FilmID
	,ArtistID)
VALUES
	(1,
	2)

INSERT INTO [VOTERS]
	(VoterId
	,VoterQRCode)
VALUES
	(1,
	'/Vote/Vote/1')


INSERT INTO VOTES
	(FilmId
	,BlockId
	,VoterId
	,VoteComment)
VALUES
	(1
	,1
	,1
	,'i am a comment')

SELECT * FROM Artists
SELECT * FROM Blocks
SELECT * FROM [Event]
SELECT * FROM FilmArtists
SELECT * FROM Films
SELECT * FROM Voters
SELECT * FROM Votes