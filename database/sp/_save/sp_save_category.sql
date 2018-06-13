Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_category
(
    @CategoryId INT,
    @Name NVARCHAR(MAX), 
    @ParentId INT
)
AS BEGIN
	SET @ParentId = IIF(@ParentId = 0, NULL, @ParentId)
	IF @CategoryId <= 0
		BEGIN
			INSERT INTO [dbo].[Category]([Name], [ParentId])
            VALUES (@Name, @ParentId)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Category]
			SET [Name] = @Name,
				[ParentId] = @ParentId
            WHERE [Category].[CategoryId] = @CategoryId
		END
END