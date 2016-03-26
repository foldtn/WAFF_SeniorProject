CREATE PROCEDURE [dbo].[GetFilmsByBlockByEvent]
	--DECLARE @currentDate DateTime
	@date date = '12-21-05',
	@currentDate datetime = @date


AS

	select
		f.FilmID as [FilmId]
		,fb.BlockID as [BlockId]
		,b.EventID as [EventId]
		,f.FilmName as [FilmName]
		,f.FilmDesc as [FilmDescription]
		,f.FilmGenre as [FilmGenre]
		,f.FilmLength as [FilmLength]
		,b.BlockStart as [BlockStart]
		,b.BlockEnd as [BlockEnd]
		,b.BlockLocation as [BlockLocation]
	from  films f

	join FILMBLOCKS fb
		on f.FilmID = fb.FilmID

	join blocks b
		on b.BlockID = fb.BlockID

	join [EVENTS] e
		on e.EventEndDate = b.EventID

	where (e.EventStartDate <= @currentDate AND e.EventEndDate >= @currentDate)

RETURN 0
