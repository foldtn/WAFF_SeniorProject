CREATE TABLE [dbo].[VOTERS]
(
	[VoterID] INT NOT NULL PRIMARY KEY, 
    [VoterAge] INT NULL, 
    [VoterEthnicity] VARCHAR(50) NULL, 
    [VoterEducation] VARCHAR(50) NULL, 
    [VoterIncome] MONEY NULL,
)
