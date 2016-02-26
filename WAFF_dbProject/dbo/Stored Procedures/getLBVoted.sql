CREATE PROCEDURE [dbo].[getLBVoted]
	@event int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT DISTINCT v.FilmID, v.BlockID
	FROM VOTES v
	JOIN BLOCKS b
	ON v.BlockID = b.BlockID
	WHERE b.EventID = @event

END