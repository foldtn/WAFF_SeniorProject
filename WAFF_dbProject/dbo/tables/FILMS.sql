CREATE TABLE [dbo].[FILMS]
(
	[FilmID] INT NOT NULL PRIMARY KEY identity, 
    [FilmName] VARCHAR(100) NOT NULL, 
    [FilmGenre] VARCHAR(30) NOT NULL, 
    [FilmDesc] VARCHAR(250) NULL,
	[FilmLength] INT NOT NULL,
	[FilmVotable] BIT NOT NULL DEFAULT 1
)
