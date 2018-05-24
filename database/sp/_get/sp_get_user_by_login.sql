USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_user_by_login]
    @Login NVARCHAR(MAX) 
AS
(
    SELECT [User].[UserId] AS [UserId], [Name], [PhotoData], [PhotoMimeType]
    FROM [dbo].[User]
    INNER JOIN [dbo].[Membership]
    ON [User].[UserId] = [Membership].[UserId]
    WHERE [Membership].[Login] = @Login
);
GO