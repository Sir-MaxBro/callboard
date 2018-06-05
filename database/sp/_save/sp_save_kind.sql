Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_kind
(
    @KindId INT,
    @Type NVARCHAR(50)
)
AS BEGIN
	IF @KindId <= 0
		BEGIN
			INSERT INTO [dbo].[Kind]([Type])
            VALUES (@Type)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Kind]
			SET [Type] = @Type
            WHERE [Kind].[KindId] = @KindId
		END
END