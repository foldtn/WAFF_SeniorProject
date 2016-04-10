CREATE PROCEDURE [dbo].[GetFilmsByBlockByEvent]
	--DECLARE @currentDate DateTime
	@currentDate datetime

AS

	select
		f.FilmID as [FilmId]
		,e.EventStartDate as [Event Start Date]
		,e.EventEndDate
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

	left join FILMBLOCKS fb
		on f.FilmID = fb.FilmID

	left join blocks b
		on b.BlockID = fb.BlockID

	left join [EVENTS] e
		on e.EventID = b.EventID

	where (e.EventStartDate <= GETDATE() AND e.EventEndDate >= GETDATE())

RETURN 0
