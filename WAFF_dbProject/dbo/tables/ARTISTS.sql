CREATE TABLE [dbo].[ARTISTS]
(
	[ArtistID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ArtistFName] VARCHAR(30) NOT NULL, 
    [ArtistLName] VARCHAR(30) NOT NULL, 
    [ArtistCompany] VARCHAR(30) NOT NULL,
	[ArtistEmail] VARCHAR(30) NOT NULL,
	[ArtistAddress] VARCHAR(50) NOT NULL,
	[ArtistCity] VARCHAR(30) NOT NULL,
	[ArtistState] VARCHAR(2) NOT NULL,
	[ArtistZip] INT NOT NULL,
	[ArtistPhone] VARCHAR(30) NOT NULL
)
