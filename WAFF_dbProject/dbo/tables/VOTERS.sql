CREATE TABLE [dbo].[VOTERS]
(
	[VoterID] INT NOT NULL PRIMARY KEY, 
    [VoterAge] VARCHAR(2) NULL, 
    [VoterEthnicity] VARCHAR(50) NULL, 
    [VoterEducation] VARCHAR(50) NULL, 
    [VoterIncome] MONEY NULL, 
    [VoterQRCode] VARCHAR(200) NOT NULL
)
