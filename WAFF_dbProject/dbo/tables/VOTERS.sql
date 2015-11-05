CREATE TABLE [dbo].[VOTERS]
(
	[VoterID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [VoterAge] VARCHAR(2) NOT NULL, 
    [VoterEthnicity] VARCHAR(50) NOT NULL, 
    [VoterEducation] VARCHAR(50) NOT NULL, 
    [VoterIncome] MONEY NOT NULL, 
    [VoterQRCode] VARCHAR(200) NOT NULL
)
