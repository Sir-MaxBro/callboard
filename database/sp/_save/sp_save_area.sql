Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_area
(
    @CountryId INT,
    @AreaId INT,
    @Name NVARCHAR(50)
)
AS BEGIN
	IF @AreaId <= 0
		BEGIN
			INSERT INTO [dbo].[Area]([CountryId], [Name])
            VALUES (@CountryId, @Name)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Area]
			SET [Name] = @Name,
                [CountryId] = @CountryId
            WHERE [AreaId] = @AreaId
		END
END