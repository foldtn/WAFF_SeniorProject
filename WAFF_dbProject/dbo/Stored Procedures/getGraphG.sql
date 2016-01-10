CREATE PROCEDURE [dbo].[getGraphG]
	@genre varchar(30)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT f.[FilmID], f.[FilmName], COUNT(v.FilmID) AS [FilmVotes]
	FROM [FILMS] f
	JOIN [VOTES] v
	ON v.[FilmID] = f.[FilmID]
	WHERE f.[FilmGenre] = @genre
	GROUP BY f.[FilmID], f.[FilmName]
END
