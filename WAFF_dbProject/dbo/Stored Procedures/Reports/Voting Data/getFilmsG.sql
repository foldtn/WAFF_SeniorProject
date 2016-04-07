CREATE PROCEDURE [dbo].[getFilmsG]
	@genre varchar(30),
	@event int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT f.FilmID, f.FilmName
	FROM FILMS f
	JOIN FILMBLOCKS fb
	ON f.FilmID = fb.FilmID
	JOIN BLOCKS b
	ON fb.BlockID = b.BlockID
	WHERE f.FilmGenre = @genre AND b.EventID = @event
	GROUP BY f.FilmID, f.FilmName
	ORDER BY f.FilmName
END