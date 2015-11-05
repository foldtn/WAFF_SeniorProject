CREATE TABLE [dbo].[Films]
(
	[FilmID] INT NOT NULL PRIMARY KEY identity, 
    [FilmName] VARCHAR(30) NOT NULL, 
    [FilmGenre] VARCHAR(30) NOT NULL, 
    [FilmDesc] VARCHAR(250) NOT NULL,
	[FilmLength] VARCHAR(30) NOT NULL,
	[BlockId] INT NOT NULL,
	FOREIGN KEY (BlockID) REFERENCES Blocks(BlockID)
)
