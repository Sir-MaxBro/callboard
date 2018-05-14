USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_select_category]
AS
(
    SELECT [CategoryId], [Name] 
    FROM [dbo].[Category]
);
GO