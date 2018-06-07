USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_user_by_id] 
	@UserId INT
AS
BEGIN
BEGIN TRANSACTION;
BEGIN TRY
	DECLARE @Ads TABLE ([AdId] INT)
	
	DELETE
	FROM [dbo].[Phone]
	WHERE [Phone].[UserId] = @UserId

	DELETE
	FROM [dbo].[Mail]
	WHERE [Mail].[UserId] = @UserId

	DELETE
	FROM [dbo].[Membership]
	WHERE [Membership].[UserId] = @UserId

	DELETE
	FROM [dbo].[UsersInRoles]
	WHERE [UsersInRoles].[UserId] = @UserId

	INSERT INTO @Ads([AdId])
	SELECT [AdId]
	FROM [dbo].[AdDetails]
	WHERE [AdDetails].[UserId] = @UserId

	DECLARE @AdId int
	DECLARE ad_cursor CURSOR LOCAL FOR
		SELECT [AdId] FROM @Ads
	OPEN ad_cursor
	FETCH NEXT FROM ad_cursor INTO @AdId
	WHILE @@FETCH_STATUS = 0 BEGIN
		EXEC [dbo].sp_delete_ad_by_id @AdId
		FETCH NEXT FROM ad_cursor INTO @AdId
	END
	CLOSE ad_cursor
	DEALLOCATE ad_cursor

    DELETE 
    FROM [dbo].[User]
    WHERE [User].[UserId] = @UserId

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