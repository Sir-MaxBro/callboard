Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_country
(
    @CountryId INT,
    @Name NVARCHAR(50)
)
AS BEGIN
	IF @CountryId <= 0
		BEGIN
			INSERT INTO [dbo].[Country]([Name])
            VALUES (@Name)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Country]
			SET [Name] = @Name
            WHERE [Country].[CountryId] = @CountryId
		END
END