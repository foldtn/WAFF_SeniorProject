CREATE PROCEDURE [dbo].[getEvents]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	EventID, 
			(CONVERT(VARCHAR, [EventStartDate], 107) + '  -  ' + 
			CONVERT(VARCHAR, [EventEndDate], 107)) AS EventDate 
	FROM [EVENTS]
END
