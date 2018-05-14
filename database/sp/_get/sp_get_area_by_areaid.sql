CREATE PROCEDURE [sp_get_area_by_areaid]
    @AreaId int 
AS
(
    SELECT [Area].[AreaId], [Area].[Name]
    FROM [Area]
    WHERE [Area].[AreaId] = @AreaId
);
GO