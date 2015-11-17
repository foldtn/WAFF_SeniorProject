SELECT f.FilmName, f.FilmGenre, f.BlockID, COUNT(v.FilmID) AS [Votes For]
FROM [FILMS] f
JOIN VOTES v ON f.FilmID = v.FilmID
GROUP BY f.FilmName, f.FilmGenre, f.BlockID