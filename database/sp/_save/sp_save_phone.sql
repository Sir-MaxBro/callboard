Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_phone
(
    @PhoneId INT,
    @Number NVARCHAR(50), 
	@UserId INT
)
AS BEGIN
	IF @PhoneId <= 0
		BEGIN
			INSERT INTO [dbo].Phone([Number], [UserId])
			VALUES(@Number, @UserId)
		END
	ELSE
		BEGIN
			UPDATE [Phone]
			SET [Number] = @Number,
				[UserId] = @UserId
			WHERE [Phone].[PhoneId] = @PhoneId
		END
END