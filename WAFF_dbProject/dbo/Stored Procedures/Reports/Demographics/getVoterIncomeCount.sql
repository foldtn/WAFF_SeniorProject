CREATE PROCEDURE [dbo].[getVoterIncomeCount]
	@begin int,
	@end float,
	@event int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT COUNT(VoterIncome) AS VoterCount
	FROM VOTERS v
	JOIN 
		(
			SELECT DISTINCT v.VoterID 
			FROM BLOCKS b
			JOIN VOTES v
			ON b.BlockID = v.BlockID
			WHERE b.EventID = @event
		) b
	ON v.VoterID = b.VoterID
	WHERE VoterIncome BETWEEN @begin AND @end
END
