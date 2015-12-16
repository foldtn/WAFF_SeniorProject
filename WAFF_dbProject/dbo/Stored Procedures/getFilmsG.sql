CREATE PROCEDURE [dbo].[getFilmsG]
	@genre varchar
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT FilmID, FilmName
	FROM [FILMS]
	WHERE FilmGenre = @genre
END
	
