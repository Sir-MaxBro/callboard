CREATE PROCEDURE [callboardDB].[sp_get_city_by_cityid]
    @CityId INT
AS
(
    SELECT [CityId], [AreaId], [CountryId], [Name]  
    FROM [callboardDB].[City]
    WHERE [CityId] = @CityId
);
GO