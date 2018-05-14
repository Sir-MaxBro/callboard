CREATE PROCEDURE [sp_get_city_by_cityid]
    @CityId INT
AS
(
    SELECT [CityId], [AreaId], [CountryId], [Name]  
    FROM [City]
    WHERE [City].[CityId] = @CityId
);
GO