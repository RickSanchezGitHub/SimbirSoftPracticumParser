CREATE PROCEDURE [dbo].[GetUrl]
	@searchUrl nvarchar(100) = null
AS
	SELECT Id FROM Urls WHERE Url = @searchUrl
RETURN 0
