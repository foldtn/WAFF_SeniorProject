CREATE TABLE [dbo].[EVENTS]
(
	[EventID] INT NOT NULL PRIMARY KEY identity, 
    [EventStartDate] DATETIME NOT NULL, 
    [EventEndDate] DATETIME NOT NULL, 
    [EventLocation] VARCHAR(50) NOT NULL
)
