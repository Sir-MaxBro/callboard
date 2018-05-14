CREATE PROCEDURE [sp_get_location_by_locationid]
    @LocationId int 
AS
(
    SELECT [Location].[LocationId], [Location].[AddressLine]
    FROM [Location]
    WHERE [Location].[LocationId] = @LocationId
);
GO