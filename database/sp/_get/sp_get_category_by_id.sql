USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_category_by_id] 
	@CategoryId INT
AS
BEGIN
	SELECT [CategoryId], [Name], [ParentId]
	FROM [dbo].Category
	WHERE [Category].CategoryId = @CategoryId
END
GO