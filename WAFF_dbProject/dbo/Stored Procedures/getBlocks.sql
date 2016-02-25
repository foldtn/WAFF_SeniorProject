CREATE PROCEDURE [dbo].[getBlocks]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	BlockID, 
		(DATENAME(DW,b.[BlockStart]) + ' ' +
		CONVERT(VARCHAR(5),b.[BlockStart], 108) + ' ' +
		RIGHT(CONVERT(VARCHAR, b.[BlockStart], 100), 2)) AS [BlockStart]
	FROM [BLOCKS] b
END
