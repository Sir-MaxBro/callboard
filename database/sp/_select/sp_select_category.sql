CREATE PROCEDURE [sp_select_category]
AS
(
    SELECT [CategoryId], [Name] 
    FROM [Category]
);
GO