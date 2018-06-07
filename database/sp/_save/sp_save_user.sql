Use [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_save_user]
(
	@UserId INT,
	@Name NVARCHAR(MAX),
	@PhotoData VARBINARY(MAX) = NULL,
	@PhotoExtension NVARCHAR(50) = NULL,
    @Phones [dbo].PhoneTable NULL READONLY,
    @Mails [dbo].MailTable NULL READONLY
)
AS BEGIN
	BEGIN
		UPDATE [dbo].[User]
		SET [Name] = @Name,
			PhotoData = @PhotoData,
			PhotoExtension = @PhotoExtension
        WHERE [User].[UserId] = @UserId

		EXEC [dbo].sp_save_mails @Mails, @UserId
		EXEC [dbo].sp_save_phones @Phones, @UserId
	END
END