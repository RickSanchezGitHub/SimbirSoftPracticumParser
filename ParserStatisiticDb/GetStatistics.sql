CREATE PROCEDURE [dbo].[GetStatistics]
	@urlId int = 0
AS
	SELECT WS.Word,
		WS.Count
		FROM WordsStatistics WS
		WHERE WS.UrlId = @urlId
RETURN 0
