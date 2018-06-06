Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_mail
(
    @MailId INT,
    @Email NVARCHAR(50), 
	@UserId INT
)
AS BEGIN
	IF @MailId <= 0
		BEGIN
			INSERT INTO [dbo].[Mail]([Email], [UserId])
			VALUES(@Email, @UserId)
		END
	ELSE
		BEGIN
			UPDATE [Mail]
			SET [Email] = @Email,
				[UserId] = @UserId
			WHERE [Mail].[MailId] = @MailId
		END
END