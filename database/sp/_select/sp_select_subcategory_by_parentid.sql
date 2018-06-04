USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_select_subcategory_by_parentid]
    @ParentId INT
AS
(
    SELECT [CategoryId], [Name], [ParentId]
    FROM [dbo].[Category]
    WHERE [ParentId] = @ParentId
);
GO