CREATE PROCEDURE [dbo].[getBlocks]
	@event int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	b.EventID, b.BlockID, 
		(DATENAME(DW,b.[BlockStart]) + ' ' +
		LEFT(RIGHT(CONVERT(VARCHAR(19),b.[BlockStart], 100), 7), 5) + ' ' +
		RIGHT(CONVERT(VARCHAR, b.[BlockStart], 100), 2)) AS [BlockStart]
	FROM [BLOCKS] b
	WHERE b.EventID = @event
END
