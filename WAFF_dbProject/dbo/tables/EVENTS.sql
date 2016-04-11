CREATE TABLE [dbo].[EVENTS]
(
	[EventID] INT NOT NULL PRIMARY KEY identity, 
    [EventStartDate] DATE NOT NULL, 
    [EventEndDate] DATE NOT NULL, 
    [EventLocation] VARCHAR(50) NOT NULL
)
