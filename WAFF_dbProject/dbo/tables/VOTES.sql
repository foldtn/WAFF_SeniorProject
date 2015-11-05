CREATE TABLE [dbo].[VOTES]
(
	[FilmId] INT NOT NULL,
	[BlockId] INT NOT NULL,
	[VoterId] INT NOT NULL,
	[VoteComment] nvarchar(200) Null,

    constraint [PK_VOTE] Primary Key (FilmId, BlockId, VoterId),
	constraint [FK_VOTE_FILM] Foreign Key (FilmId) references dbo.FILMS(FilmId) on Delete cascade,
	constraint [FK_VOTE_BLOCK] Foreign Key (BlockId) references dbo.BLOCKS(BlockId) on delete cascade,
	constraint [FK_VOTE_VOTER] Foreign Key (VoterId) references dbo.VOTERS(VoterId) on delete cascade
)
