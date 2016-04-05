CREATE PROCEDURE [dbo].[getGenres]
	@event int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT b.EventID, f.FilmGenre
	FROM [FILMS] f
	JOIN FILMBLOCKS fb
	ON f.FilmID = fb.FilmID
	JOIN BLOCKS b
	ON b.BlockID = fb.BlockID
	WHERE b.EventID = @event
	GROUP BY b.EventID, f.FilmGenre
END
