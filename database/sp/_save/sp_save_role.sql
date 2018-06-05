Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_role
(
    @RoleId INT,
    @Name NVARCHAR(50)
)
AS BEGIN
	IF @RoleId <= 0
		BEGIN
			INSERT INTO [dbo].[Role]([Name])
            VALUES (@Name)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Role]
			SET [Name] = @Name
            WHERE [Role].[RoleId] = @RoleId
		END
END