CREATE TABLE [dbo].[Voters]
(
	[VoterId] INT NOT NULL PRIMARY KEY, 
    [Age] NCHAR(10) NOT NULL, 
    [Ethnicity] VARCHAR(50) NOT NULL, 
    [Education] VARCHAR(50) NOT NULL, 
    [Income] MONEY NOT NULL
)
