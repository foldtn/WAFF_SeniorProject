CREATE PROCEDURE [dbo].[GetBlockRemainingDurationByBlockId]
	@blockId int
AS
	select
		ISNULL(SUM(f.FilmLength), 0)
	from FILMBLOCKS fb

	JOIN FILMS f
		on fb.FilmID = f.FilmID

	JOIN BLOCKS b
		on fb.BlockID = b.BlockID

	where fb.BlockID = @blockId

RETURN 0
