USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_city_by_areaid]
    @AreaId INT
AS
(
    SELECT [CityId], [Name]  
    FROM [dbo].[City]
    WHERE [AreaId] = @AreaId
);
GO