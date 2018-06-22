USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_membership_user_by_login]
    @Login NVARCHAR(MAX) 
AS
BEGIN
    DECLARE @User TABLE (
		[UserId] INT, 
		[Name] NVARCHAR(MAX)
		);

	INSERT INTO @User
    SELECT TOP 1 [User].[UserId], [Name]
    FROM [dbo].[User]
    INNER JOIN [dbo].[Membership]
    ON [User].[UserId] = [Membership].[UserId]
    WHERE [Membership].[Login] = @Login

	SELECT * 
	FROM @User

	DECLARE @UserId INT
	SET @UserId = (SELECT [UserId] FROM @User)

	EXEC [dbo].[sp_select_role_by_userid] @UserId
END