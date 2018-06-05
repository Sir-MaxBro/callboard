USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_city_by_id] 
	@CityId INT
AS
BEGIN
    DELETE 
    FROM [dbo].[City]
    WHERE [City].[CityId] = @CityId
END
GO