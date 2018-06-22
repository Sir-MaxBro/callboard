USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_images_by_adid] 
	@AdId INT
AS
BEGIN
BEGIN TRANSACTION;
BEGIN TRY
	DECLARE @Images AS TABLE([ImageId] INT)

	INSERT INTO @Images([ImageId])
	SELECT [Image].[ImageId]
	FROM [dbo].[Image]
	INNER JOIN [dbo].ImagesInAds
	ON [Image].ImageId = [ImagesInAds].ImageId
	WHERE [ImagesInAds].AdId = @AdId

	DELETE
	FROM [dbo].ImagesInAds
	WHERE [ImagesInAds].AdId = @AdId

	DELETE [image]
	FROM [dbo].[Image] AS [image]
	INNER JOIN @Images AS [images]
	ON [image].ImageId = [images].ImageId
	WHERE [images].[ImageId] = [image].ImageId
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