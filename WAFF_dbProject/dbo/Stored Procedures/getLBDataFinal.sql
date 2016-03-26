CREATE PROCEDURE [dbo].[getLBDataFinal]
	@film int,
	@block int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	v.FilmID, v.FilmName, v.FilmGenre, v.BlockID,
			(LEFT(RIGHT(CONVERT(VARCHAR, b.[BlockStart], 100), 7), 5) + ' ' +
			RIGHT(CONVERT(VARCHAR, b.[BlockStart], 100), 2)) AS [BlockStart],
			(LEFT(RIGHT(CONVERT(VARCHAR,b.[BlockEnd], 100), 7), 5) + ' ' +
			RIGHT(CONVERT(VARCHAR, b.[BlockEnd], 100), 2)) AS [BlockEnd],
			DATENAME(DW,b.[BlockStart]) AS [BlockDayOfWeek]
	FROM
		(
			SELECT v.FilmID, v.BlockID, f.FilmName, f.FilmGenre
			FROM 
				(
					SELECT DISTINCT v.FilmID, v.BlockID
					FROM VOTES v
					WHERE v.FilmID = @film AND v.BlockID = @block
				) v
			JOIN FILMS f
			ON v.FilmID = f.FilmID 
		) v
	JOIN BLOCKS b
	ON v.BlockID = b.BlockID
END