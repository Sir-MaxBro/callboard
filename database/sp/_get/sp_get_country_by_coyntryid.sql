CREATE PROCEDURE [callboardDB].[sp_get_country_by_coyntryid]
    @CountryId int 
AS
(
    SELECT [CountryId], [Name]
    FROM [callboardDB].[Country]
    WHERE [CountryId] = @CountryId
);
GO