CREATE PROCEDURE [dbo].[getFilmInfo]
	@film int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	f.FilmName, f.FilmGenre, f.FilmDesc, f.FilmLength,
			a.ArtistFName, a.ArtistLName, a.ArtistCompany, a.ArtistEmail,
			a.ArtistPhone, a.ArtistAddress, a.ArtistCity, a.ArtistState,
			ISNULL(a.ArtistZip, 0) AS 'ArtistZip'
	FROM FILMS f
	LEFT JOIN FILMARTISTS fa
	ON f.FilmID = fa.FilmID
	LEFT JOIN ARTISTS a
	ON fa.ArtistID = a.ArtistID
	WHERE f.FilmID = @film
END
