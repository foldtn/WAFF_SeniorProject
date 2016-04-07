CREATE PROCEDURE [dbo].[getGraphsG]
	@genre varchar(30),
	@event int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT f.FilmID, f.FilmName, COUNT(f.FilmName) AS FilmVotes
	FROM VOTES v
	JOIN
		(
			SELECT fb.FilmID, fb.BlockID, f.FilmName
			FROM BLOCKS b
			JOIN FILMBLOCKS fb
			ON b.BlockID = fb.BlockID
			JOIN FILMS f
			ON fb.FilmID = f.FilmID
			WHERE b.EventID = @event AND f.FilmGenre = @genre
		) f
	ON v.FilmID = f.FilmID AND v.BlockID = f.BlockID
	GROUP BY f.FilmID, f.FilmName
	ORDER BY f.FilmName
END