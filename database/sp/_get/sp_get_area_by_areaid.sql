CREATE PROCEDURE [callboardDB].[sp_get_area_by_areaid]
    @AreaId int 
AS
(
    SELECT [AreaId], [Name], [CountryId]
    FROM [callboardDB].[Area]
    WHERE [AreaId] = @AreaId
);
GO