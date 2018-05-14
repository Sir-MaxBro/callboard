CREATE PROCEDURE [callboardDB].[sp_select_category]
AS
(
    SELECT [CategoryId], [Name] 
    FROM [callboardDB].[Category]
);
GO