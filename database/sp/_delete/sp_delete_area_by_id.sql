USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_area_by_id] 
	@AreaId INT
AS
BEGIN
    DELETE 
    FROM [dbo].[Area]
    WHERE [Area].[AreaId] = @AreaId
END
GO