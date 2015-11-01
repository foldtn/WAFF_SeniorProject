CREATE TABLE [dbo].[Votes]
(
	[FilmId] INT NOT NULL,
	[BlockId] INT NOT NULL,
	[VoterId] INT NOT NULL,
	[VoteComment] nvarchar(200) Null,

	constraint [PK_Votes] Primary Key (FilmId, BlockId, VoterId),
	constraint [FK_Votes_Films] Foreign Key (FilmId) references dbo.Films(FilmId) on Delete cascade,
	constraint [FK_Votes_Blocks] Foreign Key (BlockId) references dbo.Blocks(BlockId) on delete cascade,
	constraint [FK_Votes_Voters] Foreign Key (VoterId) references dbo.Voters(VoterId) on delete cascade
)
