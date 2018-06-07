USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_save_addetails] 
	@AdId INT,
    @Kind NVARCHAR(50),
    @State NVARCHAR(50),
    @Name NVARCHAR(MAX),
    @Price DECIMAL(18, 2),
    @CreationDate DATETIME,
    @UserId INT,
    @Description NVARCHAR(MAX),
    @AddressLine NVARCHAR(MAX),
    @LocationId INT,
	@Images [dbo].ImagesTable NULL READONLY,
	@Categories [dbo].CategoriesTable NULL READONLY
AS
BEGIN
	DECLARE @KindId INT
	DECLARE @StateId INT
	SET @KindId = [dbo].func_get_kindid_by_type(@Kind);
	SET @StateId = [dbo].func_get_stateid_by_condition(@State);
	IF @AdId <= 0
		BEGIN
			DECLARE @NewAdId TABLE ([AdId] INT NOT NULL)
			
			INSERT INTO [dbo].[Ad]([KindId], [StateId], [Name], [Price], [CreationDate], [CityId])
			OUTPUT inserted.AdId INTO @NewAdId
			VALUES (@KindId, @StateId, @Name, @Price, @CreationDate, @LocationId);

			SET @AdId = (SELECT [AdId] FROM @NewAdId);

			INSERT INTO [dbo].AdDetails([AdId], [UserId], [AddressLine], [Description])
			VALUES(@AdId, @UserId, @AddressLine, @Description)

			INSERT INTO [dbo].AdsInCategories([AdId], [CategoryId])
			SELECT @AdId, [CategoryId]
			FROM @Categories
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Ad]
			SET [KindId] = @KindId, 
				[StateId] = @StateId, 
				[Name] = @Name, 
				[Price] = @Price, 
				[CreationDate] = @CreationDate, 
				[CityId] = @LocationId
			WHERE [AdId] = @AdId

			UPDATE [dbo].[AdDetails]
			SET [UserId] = @UserId, 
				[AddressLine] = @AddressLine, 
				[Description] = @Description
			WHERE [AdId] = @AdId

			UPDATE [dbo].AdsInCategories
			SET [CategoryId] = categories.[CategoryId]
			FROM @Categories AS categories
			WHERE [AdId] = @AdId
		END

	EXEC [dbo].sp_save_images @Images, @AdId
END
GO