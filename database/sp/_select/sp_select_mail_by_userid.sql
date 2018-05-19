USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_select_mail_by_userid]
    @UserId INT
AS
(
    SELECT [MailId], [Email], [UserId]
    FROM [dbo].[Mail]
    WHERE [Mail].[UserId] = @UserId
);
GO