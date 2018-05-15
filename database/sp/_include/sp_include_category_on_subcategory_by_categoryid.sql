USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_include_category_on_subcategory_by_categoryid]
    @CategoryId INT
AS
(
    SELECT [Category].[CategoryId] as [CategoryId], [Category].[Name] as [Name]
    FROM [Subcategory]
    INNER JOIN [Category]
    ON [Subcategory].[CategoryId] = [Category].[CategoryId]
    WHERE [Subcategory].[ParentCategoryId] = @CategoryId
);
GO