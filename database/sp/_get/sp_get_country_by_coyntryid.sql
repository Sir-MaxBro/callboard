CREATE PROCEDURE [sp_get_country_by_coyntryid]
    @CountryId int 
AS
(
    SELECT [Country].[CountryId], [Country].[Name]
    FROM [Country]
    WHERE [Country].[CountryId] = @CountryId
);
GO