CREATE TABLE [dbo].[VOTES]
(
	[FilmID] INT NOT NULL,
	[BlockID] INT NOT NULL,
	[VoterID] INT NOT NULL,
	[VoteComment] nvarchar(200) Null,

    constraint [PK_VOTE] Primary Key (FilmID, BlockID, VoterID),
	constraint [FK_VOTE_FILM] Foreign Key (FilmId) references dbo.FILMS(FilmId) on Delete cascade,
	constraint [FK_VOTE_BLOCK] Foreign Key (BlockId) references dbo.BLOCKS(BlockId) on delete cascade,
	constraint [FK_VOTE_VOTER] Foreign Key (VoterId) references dbo.VOTERS(VoterId) on delete cascade
)
