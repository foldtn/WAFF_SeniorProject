CREATE PROCEDURE [dbo].[GetVotesPerBlock]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		v.BlockID AS BlockID,
		COUNT(v.VoterID) AS [Votes]

	FROM [VOTES] v

	GROUP BY
		v.BlockID
END
