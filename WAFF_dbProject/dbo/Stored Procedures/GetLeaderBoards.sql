CREATE PROCEDURE [dbo].[GetLeaderBoards]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 10 v.[FilmName], v.[FilmGenre], v.[BlockID], 
	p.[BlockStart], p.[BlockEnd], p.[BlockDayOfWeek],
	(
		CAST
		(
			(
			CAST(v.[Votes] as decimal(5,2))
			/
			CAST(p.[VotesPerBlock] as decimal(5,2)) 
			* 100 
			) as decimal(5,2)
		)
	) AS [VotePercentage] 
	FROM
		(SELECT f.[FilmName], f.[FilmGenre], f.[BlockID], COUNT(v.[FilmID]) AS [Votes]
			FROM [FILMS] f
			JOIN [VOTES] v
				ON f.[FilmID] = v.[FilmID]
			GROUP BY
				f.[FilmName],
				f.[FilmGenre],
				f.[BlockID]		
		) v
	JOIN 
		(SELECT v.[BlockID], DATENAME(DW,b.[BlockStart]) AS [BlockDayOfWeek],
				/*	Gives me a string of a date in the format 'HH:MM' 
					How 'CONVERT' works:
							'CONVERT(datatype, convertThis,
								style)'
							Datatype is the type you want to convert to.
							convertThis is what you want to convert into
								the datatype.
							style is what kind of styling you want it 
								to come out with.
				*/
				(CONVERT(VARCHAR(5),b.[BlockStart], 108) + ' ' +
				/*	Gives me a string of a date in the format 'AM/PM'.
					How this works:
						'RIGHT(string, number)'
						you first get the string by doing the 'convert' as
						in the statement above.
						you then set the number of character 'spots' you 
						want to grab (right to left).
						So in this case:
							'HH:MM:AM' you will be grabbing the 2 characters
							starting from the right or 'AM' 
				*/
				+ RIGHT(CONVERT(VARCHAR, b.[BlockStart], 100), 2)) AS [BlockStart], 
				(CONVERT(VARCHAR(5),b.[BlockEnd], 108) + ' ' +
				+ RIGHT(CONVERT(VARCHAR, b.[BlockEnd], 100), 2)) AS [BlockEnd], 
				COUNT(v.VoterID) AS [VotesPerBlock]
			FROM [BLOCKS] b
			JOIN [VOTES] v
				ON b.[BlockID] = v.[BlockID]
			GROUP BY 
				v.[BlockID],
				b.[BlockStart],
				b.[BlockEnd]
		) p
	ON v.[BlockID] = p.[BlockID]
	ORDER BY [VotePercentage] DESC
END