USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_location_by_cityid]
    @CityId INT
AS
(
    SELECT [City], [Area], [Country]
    FROM [dbo].func_get_location_by_cityid(@CityId)
);
GO