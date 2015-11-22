CREATE PROCEDURE [dbo].[GetLeaderBoards]
AS
BEGIN
	SET NOCOUNT ON;

	Select v.FilmName, v.FilmGenre, v.BlockID, 
	(
		CAST(
			(
			CAST(v.Votes as decimal(5,2))
			/
			CAST(p.VotesPerBlock as decimal(5,2)) 
			* 100.00 
			) as decimal(5,2)
		)
	) AS VotePercentage 
	FROM
		(SELECT f.FilmName, f.FilmGenre, f.BlockID, COUNT(v.FilmID) AS [Votes]
			FROM [FILMS] f
			JOIN [VOTES] v
				ON f.FilmID = v.FilmID
			GROUP BY
				f.FilmName,
				f.FilmGenre,
				f.BlockID		
		) v
	JOIN 
		(SELECT v.BlockID, COUNT(v.VoterID) AS [VotesPerBlock]
			FROM [VOTES] v
			GROUP BY
				v.BlockID	
		) p
	ON v.BlockID = p.BlockID
	ORDER BY VotePercentage DESC
END