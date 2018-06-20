Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_city
(
    @CityId INT,
    @AreaId INT,
    @Name NVARCHAR(50)
)
AS BEGIN
	IF @CityId <= 0
		BEGIN
			INSERT INTO [dbo].[City]([AreaId], [Name])
            VALUES (@AreaId, @Name)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[City]
			SET [Name] = @Name,
                [AreaId] = @AreaId
            WHERE [CityId] = @CityId
		END
END