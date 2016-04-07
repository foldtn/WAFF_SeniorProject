CREATE PROCEDURE [dbo].[getFilmsB]
	@block int
AS
BEGIN
	SET NOCOUNT ON;

  SELECT f.FilmID, f.FilmName 
  FROM FILMS f
  JOIN FILMBLOCKS fb
  ON f.FilmID = fb.FilmID
  WHERE fb.BlockID = @block
  ORDER BY f.FilmName
END
