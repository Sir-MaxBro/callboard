USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_role_by_id] 
	@RoleId INT
AS
BEGIN
    DELETE 
    FROM [dbo].[Role]
    WHERE [Role].[RoleId] = @RoleId
END
GO