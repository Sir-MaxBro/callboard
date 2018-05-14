CREATE PROCEDURE [callboard_db].[sp_get_area_by_areaid]
    @AreaId int 
AS
(
    SELECT [AreaId], [Name], [CountryId]
    FROM [callboard_db].[Area]
    WHERE [AreaId] = @AreaId
);
GO