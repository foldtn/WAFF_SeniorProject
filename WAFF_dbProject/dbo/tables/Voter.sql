CREATE TABLE [dbo].[Voters]
(
	[VoterID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [VoterAge] NCHAR(10) NOT NULL, 
    [VoterEthnicity] VARCHAR(50) NOT NULL, 
    [VoterEducation] VARCHAR(50) NOT NULL, 
    [VoterIncome] MONEY NOT NULL, 
    [VoterQRCode] NVARCHAR(200) NOT NULL
)
