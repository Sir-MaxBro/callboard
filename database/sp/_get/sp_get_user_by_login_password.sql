USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_user_by_login_password]
    @Login NVARCHAR(MAX),
    @Password NVARCHAR(MAX)
AS
BEGIN
    SELECT TOP 1 [User].[UserId], [Name], [PhotoData], [PhotoExtension]
    FROM [dbo].[User]
    INNER JOIN [dbo].[Membership]
    ON [User].[UserId] = [Membership].[UserId]
    WHERE [Login] = @Login AND [Password] = @Password
END
GO