USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_search_ad_by_name] 
	@SearchName NVARCHAR(MAX)
AS
(
	SELECT ads.*
	FROM [dbo].func_select_ad() AS ads
	WHERE ads.[Name] LIKE '%'+@SearchName+'%'
);
GO