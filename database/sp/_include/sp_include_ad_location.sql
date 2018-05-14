CREATE PROCEDURE [sp_include_ad_location]
    @LocationId int 
AS
(
    SELECT [Location].[LocationId], [Location].[AddressLine]
    FROM [Location]
    WHERE [Location].[LocationId] = @LocationId
);
GO