CREATE PROCEDURE [dbo].[getBlocks]
	@event int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	b.EventID, b.BlockID, 
		(DATENAME(DW,b.[BlockStart]) + ' ' +
		CONVERT(VARCHAR(5),b.[BlockStart], 108) + ' ' +
		RIGHT(CONVERT(VARCHAR, b.[BlockStart], 100), 2)) AS [BlockStart]
	FROM [BLOCKS] b
	WHERE b.EventID = @event
END
