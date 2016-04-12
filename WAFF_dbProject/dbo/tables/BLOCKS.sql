CREATE TABLE [dbo].[BLOCKS]
(
	[BlockID] INT NOT NULL identity PRIMARY KEY,
	[BlockStart] DateTime NOT NULL,
	[BlockEnd] DateTime	NOT NULL,
	[BlockLocation] varchar(255) NOT NULL,
	[BlockDescription] varchar(255) NULL,
	[BlockType] varchar(50) NOT NULL,
	[EventID] INT NOT NULL,
	FOREIGN KEY (EventID) REFERENCES EVENTS(EventID)
)
