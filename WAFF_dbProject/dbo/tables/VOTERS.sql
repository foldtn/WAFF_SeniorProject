CREATE TABLE [dbo].[VOTERS]
(
	[VoterID] INT NOT NULL, 
    [VoterAge] INT NULL, 
    [VoterEthnicity] VARCHAR(50) NULL, 
    [VoterEducation] VARCHAR(50) NULL, 
    [VoterIncome] MONEY NULL,
	[VoterFirstTimer] BIT NOT NULL DEFAULT 0,
	[EventID] INT NOT NULL DEFAULT 1,
	PRIMARY KEY (VoterID),
	FOREIGN KEY (EventID) REFERENCES [EVENTS](EventID)
)
