USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_delete_ad] 
	@AdId INT
AS
BEGIN
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

	DELETE 
	FROM [dbo].[AdsInCategories]
	WHERE [AdsInCategories].AdId = @AdId

	DELETE 
	FROM [AdDetails]
	WHERE [AdDetails].AdId = @AdId

	DELETE
	FROM [Ad]
	WHERE [Ad].AdId = @AdId
END
GO