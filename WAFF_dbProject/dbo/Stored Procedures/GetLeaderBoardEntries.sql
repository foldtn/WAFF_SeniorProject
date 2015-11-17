CREATE PROCEDURE [dbo].[GetLeaderBoardEntries]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		f.FilmName,
		f.FilmGenre,
		f.BlockID,
		COUNT(v.FilmID) AS [Votes]

	FROM [FILMS] f

	JOIN [VOTES] v 
		ON f.FilmID = v.FilmID

	GROUP BY
		f.FilmName,
		f.FilmGenre,
		f.BlockID
END
