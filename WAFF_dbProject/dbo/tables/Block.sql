CREATE TABLE [dbo].[BLOCK]
(
	[BlockID] INT NOT NULL identity PRIMARY KEY,
	[BlockStart] DateTime NOT NULL,
	[BlockEnd] DateTime	NOT NULL,
	[BlockLocation] varchar(255) NOT NULL,
	[BlockType] varchar(50) NOT NULL,
	[EventID] INT NOT NULL,
	FOREIGN KEY (EventID) REFERENCES dbo.EVENT(EventID)
)
