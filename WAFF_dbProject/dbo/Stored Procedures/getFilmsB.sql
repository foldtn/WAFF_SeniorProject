CREATE PROCEDURE [dbo].[getFilmsB]
	@block int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT FilmID, FilmName
	FROM [FILMS]
	WHERE BlockID = @block
END
