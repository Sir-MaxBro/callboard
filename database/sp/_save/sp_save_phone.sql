Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_phone
(
    @PhoneId INT,
    @Number NVARCHAR(50), 
	@UserId INT
)
AS BEGIN
	INSERT INTO [dbo].Phone([Number], [UserId])
	VALUES(@Number, @UserId)
END