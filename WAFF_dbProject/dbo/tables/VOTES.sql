CREATE TABLE [dbo].[VOTES]
(
	[FilmID] INT NOT NULL,
	[BlockID] INT NOT NULL,
	[VoterID] INT NOT NULL,
	[VoteComment] nvarchar(200) Null,

    constraint [PK_VOTE] Primary Key (FilmID, BlockID, VoterID),
	constraint [FK_VOTE_FILM] Foreign Key (FilmID) references dbo.FILMS(FilmID) on Delete cascade,
	constraint [FK_VOTE_BLOCK] Foreign Key (BlockID) references dbo.BLOCKS(BlockID) on delete cascade,
	constraint [FK_VOTE_VOTER] Foreign Key (VoterID) references dbo.VOTERS(VoterID) on delete cascade
)
