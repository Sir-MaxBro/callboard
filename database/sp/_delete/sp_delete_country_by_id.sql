USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_country_by_id] 
	@CountryId INT
AS
BEGIN
BEGIN TRANSACTION;
BEGIN TRY
	DELETE [city]
	FROM [dbo].[City] as [city]
	INNER JOIN [dbo].[Area] as [area]
	ON [city].[AreaId] = [area].[AreaId]
	WHERE [area].[CountryId] = @CountryId

	DELETE 
	FROM [dbo].[Area]
	WHERE [Area].[CountryId] = @CountryId

    DELETE 
    FROM [dbo].[Country]
    WHERE [Country].[CountryId] = @CountryId
END TRY
BEGIN CATCH
	SELECT 
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE() AS ErrorLine,
        ERROR_MESSAGE() AS ErrorMessage;
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
END CATCH
IF @@TRANCOUNT > 0
    COMMIT TRANSACTION;
END
GO