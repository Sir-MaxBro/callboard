Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_create_membership
(
    @Login NVARCHAR(MAX),
    @Password NVARCHAR(MAX)
)
AS 
BEGIN
	DECLARE @UserIdTable TABLE ([UserId] INT)
	DECLARE @UserId INT
	DECLARE @UserCount INT
	DECLARE @RoleId INT = 1
	SET @UserCount = (SELECT COUNT(*) FROM [dbo].[User])

	INSERT INTO [dbo].[User]([Name])
	OUTPUT inserted.UserId INTO @UserIdTable
	VALUES (CONCAT('user-', @UserCount))

	SET @UserId = (SELECT [UserId] FROM @UserIdTable)

	INSERT INTO [dbo].Membership([UserId], [Login], [Password])
	VALUES (@UserId, @Login, @Password)

	EXEC [dbo].[sp_set_role_for_user] @UserId, @RoleId

	EXEC [dbo].[sp_get_user_by_userid] @UserId
END