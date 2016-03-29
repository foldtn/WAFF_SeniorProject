CREATE PROCEDURE [dbo].[getVotes]
	@film int,
	@block int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT T1.FilmID, T1.BlockID, T1.Votes, T2.VotesPerBlock
	FROM
		(
			SELECT FilmID, BlockID, COUNT(FilmID) AS Votes
			FROM VOTES 
			WHERE (FilmID = @film AND BlockID = @block)
			GROUP BY FilmID, BlockID
		) T1
	JOIN
		(
			SELECT BlockID, COUNT(BlockID) AS VotesPerBlock
			FROM VOTES
			GROUP BY BlockID
		) T2
	ON T1.BlockID = T2.BlockID

END
