Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_set_role_for_user
(
    @UserId INT,
    @RoleId INT
)
AS BEGIN
	INSERT INTO [dbo].[UsersInRoles]([UserId], [RoleId])
	VALUES (@UserId, @RoleId)
END