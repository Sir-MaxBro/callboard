USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_area_by_id] 
	@AreaId INT
AS
BEGIN
	SELECT [AreaId], [Name]
	FROM [dbo].Area
	WHERE [Area].AreaId = @AreaId
END
GO