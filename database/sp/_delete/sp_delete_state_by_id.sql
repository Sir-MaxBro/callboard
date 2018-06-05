USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_state_by_id] 
	@StateId INT
AS
BEGIN
    DELETE 
    FROM [dbo].[State]
    WHERE [State].[StateId] = @StateId
END
GO