CREATE PROCEDURE [callboardDB].[sp_get_location_by_locationid]
    @LocationId int 
AS
(
    SELECT [LocationId], [AddressLine], [CityId], [AreaId], [CountryId]
    FROM [callboardDB].[Location]
    WHERE [LocationId] = @LocationId
);
GO