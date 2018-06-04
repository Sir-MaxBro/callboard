USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_area_by_areaid]
    @AreaId int 
AS
(
    SELECT [AreaId], [Name], [CountryId]
    FROM [dbo].[Area]
    WHERE [AreaId] = @AreaId
);
GO