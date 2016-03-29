CREATE PROCEDURE [dbo].[getGraphsB]
	@block int,
	@event int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT f.FilmID, f.FilmName, v.Votes AS FilmVotes
	FROM
		(
			SELECT f.FilmID, f.FilmName
			FROM	
				(
					SELECT FilmID FROM BLOCKS b
					JOIN FILMBLOCKS fb
					ON fb.BlockID = b.BlockID
					WHERE EventID = @event AND fb.BlockID = @block
				) fb
			JOIN FILMS f
			ON fb.FilmID = f.FilmID
		) f
	JOIN
		(
			SELECT v.FilmID, v.BlockID, COUNT(v.FilmID) AS Votes
			FROM VOTES v
			WHERE v.BlockID = @block
			GROUP BY v.FilmID, v.BlockID
		) v
	ON f.FilmID = v.FilmID
END