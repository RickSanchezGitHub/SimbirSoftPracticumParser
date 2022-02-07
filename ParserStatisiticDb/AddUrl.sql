CREATE PROCEDURE [dbo].[AddUrl]
	@addUrl nvarchar(100) = null
AS
	INSERT INTO Urls (Url) VALUES(@addUrl)
	SELECT SCOPE_IDENTITY()
RETURN 0
