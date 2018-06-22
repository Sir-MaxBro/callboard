USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_category_by_id] 
	@CategoryId INT
AS
BEGIN
BEGIN TRANSACTION;
BEGIN TRY
    DECLARE @Subcategories TABLE ([CategoryId] INT, [ParentId] INT, [Level] VARCHAR(MAX))
	INSERT INTO @Subcategories
	EXEC [dbo].[sp_select_all_subcategories_by_categoryid] @CategoryId

    DELETE 
    FROM [dbo].[Category]
    WHERE [Category].[CategoryId] = @CategoryId
    OR [Category].[CategoryId] IN ( 
		SELECT [categories].[CategoryId] 
		FROM @Subcategories AS [categories]
	)
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