CREATE PROCEDURE [dbo].[AddStatistics]
	@urlId int = 0,
	@word nvarchar(50) = null,
	@count int = 0
AS
	INSERT INTO WordsStatistics (UrlId, Word, Count) VALUES(@urlId, @word, @count)
RETURN 0
