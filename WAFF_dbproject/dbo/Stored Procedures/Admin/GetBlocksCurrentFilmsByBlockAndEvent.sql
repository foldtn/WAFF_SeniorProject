CREATE PROCEDURE [dbo].[GetBlocksCurrentFilmsByBlockAndEvent]
	@blockId int,
	@eventId int
AS
	SELECT 
		fb.*,
		e.EventId,
		f.FilmName,
		f.FilmLength
	FROM FILMBLOCKS fb

	JOIN FILMS f
		ON fb.FilmID = f.FilmID

	JOIN BLOCKS b
		ON fb.BlockID = b.BlockID

	JOIN [EVENTS] e
		ON b.EventID = e.EventID

	WHERE e.EventID = @eventId
		AND fb.BlockID = @blockId

RETURN 0
