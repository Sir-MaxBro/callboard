USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_select_user]
AS
BEGIN
	DECLARE @User TABLE (
			[UserId] INT, 
			[Name] NVARCHAR(MAX), 
			[PhotoData] VARBINARY(MAX), 
			[PhotoExtension] NVARCHAR(50)
			);

	INSERT INTO @User
    SELECT [UserId], [Name], [PhotoData], [PhotoExtension]
    FROM [dbo].[User]

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
GO