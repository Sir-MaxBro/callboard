USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_category]
AS
(
    SELECT [CategoryId], [Name], [ParentId] 
    FROM [dbo].[Category]
    WHERE ISNULL([ParentId], -1) = -1
);
GO