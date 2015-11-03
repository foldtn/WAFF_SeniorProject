CREATE TABLE [dbo].[Artists]
(
	[ArtistID] INT NOT NULL PRIMARY KEY, 
    [ArtistFName] VARCHAR(30) NOT NULL, 
    [ArtistLName] VARCHAR(30) NOT NULL, 
    [ArtistCompany] VARCHAR(30) NOT NULL,
	[ArtistEmail] VARCHAR(30) NOT NULL,
	[ArtistAddress] VARCHAR(50) NOT NULL,
	[ArtistCity] VARCHAR(30) NOT NULL,
	[ArtistZip] VARCHAR(30) NOT NULL,
	[ArtistPhone] VARCHAR(30) NOT NULL
)
