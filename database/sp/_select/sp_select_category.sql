USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_category]
AS
(
    SELECT [CategoryId], [Name], [ParentId] 
    FROM [dbo].[Category]
);
GO