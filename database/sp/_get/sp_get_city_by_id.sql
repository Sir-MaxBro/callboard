USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_city_by_id]
    @CityId INT
AS
BEGIN
    SELECT [CityId], [Name]  
    FROM [dbo].[City]
    WHERE [CityId] = @CityId
END
GO