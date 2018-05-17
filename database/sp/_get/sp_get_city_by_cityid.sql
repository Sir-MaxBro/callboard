USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_city_by_cityid]
    @CityId INT
AS
(
    SELECT [CityId], [AreaId], [Name]  
    FROM [dbo].[City]
    WHERE [CityId] = @CityId
);
GO