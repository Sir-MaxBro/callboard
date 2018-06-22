USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_area_by_id] 
	@AreaId INT
AS
BEGIN
BEGIN TRANSACTION;
BEGIN TRY
	DELETE [City]
	FROM [dbo].[City]
	WHERE [City].[AreaId] = @AreaId

    DELETE [Area]
    FROM [dbo].[Area]
    WHERE [Area].[AreaId] = @AreaId
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
END CATCH;
IF @@TRANCOUNT > 0
    COMMIT TRANSACTION;
END
GO