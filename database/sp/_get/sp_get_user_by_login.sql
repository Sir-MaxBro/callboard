USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_user_by_login]
    @Login NVARCHAR(MAX) 
AS
BEGIN
    DECLARE @User TABLE (
		[UserId] INT, 
		[Name] NVARCHAR(MAX), 
		[PhotoData] VARBINARY(MAX), 
		[PhotoExtension] NVARCHAR(50)
		);

	INSERT INTO @User
    SELECT TOP 1 [User].[UserId], [Name], [PhotoData], [PhotoExtension]
    FROM [dbo].[User]
    INNER JOIN [dbo].[Membership]
    ON [User].[UserId] = [Membership].[UserId]
    WHERE [Membership].[Login] = @Login

	SELECT * 
	FROM @User

	SELECT [MailId], [Email], [user].[UserId]
    FROM @User AS [user]
    INNER JOIN [dbo].[Mail]
	ON [user].[UserId] = [Mail].UserId

	SELECT [PhoneId], [Number], [user].[UserId]
    FROM @User AS [user]
	INNER JOIN [dbo].[Phone]
	ON [user].UserId = [Phone].UserId
END