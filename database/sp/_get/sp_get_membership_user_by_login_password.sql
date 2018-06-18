USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_membership_user_by_login_password]
    @Login NVARCHAR(MAX),
    @Password NVARCHAR(MAX)
AS
BEGIN
    DECLARE @User TABLE (
		[UserId] INT, 
		[Name] NVARCHAR(MAX),
		[Login] NVARCHAR(MAX), 
		[Password] NVARCHAR(MAX)
		);

    INSERT INTO @User
    SELECT TOP 1 [User].[UserId], [Name], [Login], [Password]
    FROM [dbo].[User]
    INNER JOIN [dbo].[Membership]
    ON [User].[UserId] = [Membership].[UserId]
    WHERE [Login] = @Login

	IF (SELECT COUNT(*) FROM @User) = 0
		BEGIN	
			RAISERROR('Login is invalid', 16, 2)
		END
	ELSE
		BEGIN
			DECLARE @IsPasswordValid INT 
			SET @IsPasswordValid = (SELECT COUNT(*) FROM @User as [user] WHERE [user].[Password] =  @Password)

			IF @IsPasswordValid = 0
				BEGIN
					RAISERROR('Password is invalid', 16, 3)
				END
			ELSE
				BEGIN
					SELECT [UserId], [Name]
					FROM @User

					DECLARE @UserId INT
					SET @UserId = (SELECT [UserId] FROM @User)

					EXEC [dbo].[sp_select_role_by_userid] @UserId
				END
		END
END
GO