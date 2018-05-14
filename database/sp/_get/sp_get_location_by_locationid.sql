USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_get_location_by_locationid]
    @LocationId int 
AS
(
    SELECT [LocationId], [AddressLine], [CityId], [AreaId], [CountryId]
    FROM [dbo].[Location]
    WHERE [LocationId] = @LocationId
);
GO