﻿CREATE PROCEDURE [dbo].[GetVoterIDs]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT VoterID
	FROM VOTERS
END
