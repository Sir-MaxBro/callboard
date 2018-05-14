CREATE PROCEDURE [callboard_db].[sp_get_city_by_cityid]
    @CityId INT
AS
(
    SELECT [CityId], [AreaId], [CountryId], [Name]  
    FROM [callboard_db].[City]
    WHERE [CityId] = @CityId
);
GO