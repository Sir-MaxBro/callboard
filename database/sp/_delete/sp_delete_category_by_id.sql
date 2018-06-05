USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_category_by_id] 
	@CategoryId INT
AS
BEGIN
    DELETE 
    FROM [dbo].[Category]
    WHERE [Category].[CategoryId] = @CategoryId
END
GO