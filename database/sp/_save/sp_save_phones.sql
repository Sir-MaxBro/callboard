Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_phones
(
    @Phones [dbo].PhoneTable READONLY,
    @UserId INT
)
AS BEGIN
	DECLARE @cur_PhoneId INT
	DECLARE @cur_Number NVARCHAR(50)

	DECLARE phone_cursor CURSOR LOCAL for
		SELECT [PhoneId], [Number] FROM @Phones
	OPEN phone_cursor

	FETCH NEXT FROM phone_cursor INTO @cur_PhoneId, @cur_Number

	WHILE @@FETCH_STATUS = 0 BEGIN
		EXEC [dbo].sp_save_phone @cur_PhoneId, @cur_Number, @UserId
		FETCH NEXT FROM phone_cursor INTO @cur_PhoneId, @cur_Number
	END
	CLOSE phone_cursor
	DEALLOCATE phone_cursor
END