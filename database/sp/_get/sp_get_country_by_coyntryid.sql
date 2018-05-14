CREATE PROCEDURE [callboard_db].[sp_get_country_by_coyntryid]
    @CountryId int 
AS
(
    SELECT [CountryId], [Name]
    FROM [callboard_db].[Country]
    WHERE [CountryId] = @CountryId
);
GO