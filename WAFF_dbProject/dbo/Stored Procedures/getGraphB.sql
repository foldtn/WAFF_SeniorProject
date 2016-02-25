CREATE PROCEDURE [dbo].[getGraphB]
	@block int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT v.[FilmID], f.[FilmName], COUNT(v.FilmID) AS [FilmVotes]
	FROM [VOTES] v
	JOIN [FILMS] f
	ON v.[FilmID] = f.[FilmID]
	WHERE v.[BlockID] = @block
	GROUP BY v.[FilmID], f.[FilmName]

END
