CREATE PROCEDURE [callboard_db].[sp_get_location_by_locationid]
    @LocationId int 
AS
(
    SELECT [LocationId], [AddressLine], [CityId], [AreaId], [CountryId]
    FROM [callboard_db].[Location]
    WHERE [LocationId] = @LocationId
);
GO