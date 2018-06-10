Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_delete_user_role
(
    @UserId INT,
    @RoleId INT
)
AS BEGIN
    DELETE 
    FROM [dbo].[UsersInRoles]
    WHERE [UsersInRoles].[UserId] = @UserId 
    AND [UsersInRoles].[RoleId] = @RoleId
END