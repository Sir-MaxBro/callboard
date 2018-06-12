Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_mail
(
    @MailId INT,
    @Email NVARCHAR(MAX), 
	@UserId INT
)
AS BEGIN
	INSERT INTO [dbo].[Mail]([Email], [UserId])
	VALUES(@Email, @UserId)
END