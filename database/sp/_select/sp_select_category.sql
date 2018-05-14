CREATE PROCEDURE [callboard_db].[sp_select_category]
AS
(
    SELECT [CategoryId], [Name] 
    FROM [callboard_db].[Category]
);
GO