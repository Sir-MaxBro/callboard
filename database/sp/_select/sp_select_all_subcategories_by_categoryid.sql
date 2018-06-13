USE [callboardDB];
GO

CREATE PROCEDURE [dbo].[sp_select_all_subcategories_by_categoryid]
	@CategoryId INT
AS
BEGIN
	WITH subcategories as
	(
	  SELECT [categories].CategoryId, [categories].ParentId, CAST([categories].CategoryId AS VARCHAR(MAX)) AS Level
	  FROM [dbo].[Category] AS [categories]
	  WHERE [categories].ParentId = @CategoryId

	  UNION ALL

	  SELECT [categories].CategoryId, [categories].ParentId, CAST([categories].CategoryId AS VARCHAR(MAX)) + ', ' + subcategories.Level
	  FROM [dbo].[Category] AS [categories]
	  INNER JOIN subcategories
	  ON subcategories.[CategoryId] = [categories].[ParentId]
	 )
	SELECT * FROM subcategories
END