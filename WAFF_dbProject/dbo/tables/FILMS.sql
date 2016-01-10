CREATE TABLE [dbo].[FILMS]
(
	[FilmID] INT NOT NULL PRIMARY KEY identity, 
    [FilmName] VARCHAR(30) NOT NULL, 
    [FilmGenre] VARCHAR(30) NOT NULL, 
    [FilmDesc] VARCHAR(250) NOT NULL,
	[FilmLength] INT NOT NULL,
)
