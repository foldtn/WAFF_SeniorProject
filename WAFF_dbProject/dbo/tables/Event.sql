CREATE TABLE [dbo].[Event]
(
	[EventID] INT NOT NULL PRIMARY KEY, 
    [EventStartDate] DATETIME NOT NULL, 
    [EventEndDate] DATETIME NOT NULL, 
    [EventLocation] VARCHAR(50) NOT NULL
)
