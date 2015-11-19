CREATE PROCEDURE [dbo].[GetVotesPerBlock]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		v.BlockID AS BlockID,
		COUNT(v.VoterID) AS [Votes]

	FROM [Votes] v

	GROUP BY
		v.BlockID
END
