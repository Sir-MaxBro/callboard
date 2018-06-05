USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_kind_by_id] 
	@KindId INT
AS
BEGIN
    DELETE 
    FROM [dbo].[Kind]
    WHERE [Kind].[KindId] = @KindId
END
GO