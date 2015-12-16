CREATE PROCEDURE [dbo].[getBlocks]
	@param1 int = 0,
	@param2 int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	BlockID, 
		(DATENAME(DW,b.[BlockStart]) + ' ' +
		CONVERT(VARCHAR(5),b.[BlockStart], 108) + ' ' +
		RIGHT(CONVERT(VARCHAR, b.[BlockStart], 100), 2)) AS [BlockStart]
	FROM [BLOCKS] b
END
