Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_state
(
    @StateId INT,
    @Condition NVARCHAR(50)
)
AS BEGIN
	IF @StateId <= 0
		BEGIN
			INSERT INTO [dbo].[State]([Condition])
            VALUES (@Condition)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[State]
			SET [Condition] = @Condition
            WHERE [State].[StateId] = @StateId
		END
END