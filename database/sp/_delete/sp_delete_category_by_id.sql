USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_category_by_id] 
	@CategoryId INT
AS
BEGIN
    DECLARE @Subcategories TABLE ([CategoryId] INT, [ParentId] INT, [Level] VARCHAR(MAX))
	INSERT INTO @Subcategories
	EXEC [dbo].[sp_select_all_subcategories_by_categoryid] @CategoryId

    DELETE 
    FROM [dbo].[Category]
    WHERE [Category].[CategoryId] = @CategoryId
    OR [Category].[CategoryId] IN ( 
		SELECT [categories].[CategoryId] 
		FROM @Subcategories AS [categories]
	)
END
GO