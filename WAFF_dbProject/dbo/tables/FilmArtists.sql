CREATE TABLE [dbo].[FilmArtists]
(
	[FilmID] INT NOT NULL,
	[ArtistID] INT NOT NULL,
	PRIMARY KEY (FilmID, ArtistID),
	FOREIGN KEY (FilmID) REFERENCES Films(FilmID),
	FOREIGN KEY (ArtistID) REFERENCES Artists(ArtistID)
)
