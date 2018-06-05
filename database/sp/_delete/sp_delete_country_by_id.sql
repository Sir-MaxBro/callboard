USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_country_by_id] 
	@CountryId INT
AS
BEGIN
    DELETE 
    FROM [dbo].[Country]
    WHERE [Country].[CountryId] = @CountryId
END
GO