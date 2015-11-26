CREATE TABLE [dbo].[ARTISTS]
(
	[ArtistID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ArtistFName] VARCHAR(30) NOT NULL, 
    [ArtistLName] VARCHAR(30) NOT NULL, 
    [ArtistCompany] VARCHAR(30) NULL,
	[ArtistEmail] VARCHAR(30) NULL,
	[ArtistAddress] VARCHAR(50) NULL,
	[ArtistCity] VARCHAR(30) NULL,
	[ArtistState] VARCHAR(2) NULL,
	[ArtistZip] INT NULL,
	[ArtistPhone] VARCHAR(30) NULL
)
