USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_get_user_by_userid]
    @UserId int 
AS
(
    SELECT [UserId], [Name], [PhotoData], [PhotoMimeType]
    FROM [dbo].[User]
    WHERE [UserId] = @UserId
);
GO