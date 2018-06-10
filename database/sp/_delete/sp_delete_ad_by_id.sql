USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_ad_by_id] 
	@AdId INT
AS
BEGIN
BEGIN TRANSACTION;
BEGIN TRY
	EXEC [dbo].[sp_delete_images_by_adid] @AdId

	DELETE 
	FROM [dbo].[AdsInCategories]
	WHERE [AdsInCategories].AdId = @AdId

	DELETE 
	FROM [AdDetails]
	WHERE [AdDetails].AdId = @AdId

	DELETE
	FROM [Ad]
	WHERE [Ad].AdId = @AdId
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