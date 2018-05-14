CREATE PROCEDURE [sp_get_location_by_locationid]
    @LocationId int 
AS
(
    SELECT [Location].[LocationId], [Location].[AddressLine], [CityId], [AreaId], [CountryId]
    FROM [Location]
    WHERE [Location].[LocationId] = @LocationId
);
GO