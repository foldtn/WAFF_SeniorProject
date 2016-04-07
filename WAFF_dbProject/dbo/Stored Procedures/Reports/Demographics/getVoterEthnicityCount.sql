CREATE PROCEDURE [dbo].[getVoterEthnicityCount]
	@ethnicity varchar(50),
	@event int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT COUNT(VoterEthnicity) AS VoterCount
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
	WHERE VoterEthnicity = @ethnicity
END