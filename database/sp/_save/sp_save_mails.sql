Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_mails
(
    @Mails [dbo].MailTable READONLY,
    @UserId INT
)
AS BEGIN
	DELETE
	FROM [dbo].[Mail]
	WHERE [Mail].[UserId] = @UserId
	
	DECLARE @cur_MailId INT
	DECLARE @cur_Email NVARCHAR(MAX)

	DECLARE mail_cursor CURSOR LOCAL for
		SELECT [MailId], [Email] FROM @Mails
	OPEN mail_cursor

	FETCH NEXT FROM mail_cursor INTO @cur_MailId, @cur_Email

	WHILE @@FETCH_STATUS = 0 BEGIN
		EXEC [dbo].sp_save_mail @cur_MailId, @cur_Email, @UserId
		FETCH NEXT FROM mail_cursor INTO @cur_MailId, @cur_Email
	END
	CLOSE mail_cursor
	DEALLOCATE mail_cursor
END