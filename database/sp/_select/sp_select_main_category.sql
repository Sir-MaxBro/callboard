USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_main_category]
AS
BEGIN
    SELECT [CategoryId], [Name], [ParentId] 
    FROM [dbo].[Category]
    WHERE ISNULL([ParentId], -1) = -1
    OR [ParentId] = 0
END
GO