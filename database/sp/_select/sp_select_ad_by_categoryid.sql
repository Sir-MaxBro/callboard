USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_ad_by_categoryid]
    @CategoryId INT
AS
BEGIN
	DECLARE @Ads TABLE (
			[AdId] INT, 
			[Name] NVARCHAR(MAX), 
			[Price] DECIMAL(18, 2), 
			[CreationDate] DATETIME, 
			[CityId] INT,
			[Kind] NVARCHAR(50),
			[State] NVARCHAR(50)
			);

	DECLARE @Subcategories TABLE ([CategoryId] INT, [ParentId] INT, [Level] VARCHAR(MAX))
	INSERT INTO @Subcategories
	EXEC [dbo].[sp_select_all_subcategories_by_categoryid] @CategoryId

	INSERT INTO @Ads
	SELECT ads.* 
	FROM [dbo].func_select_ad() AS ads
	INNER JOIN [AdsInCategories]
    ON [AdsInCategories].[AdId] = ads.[AdId]
	INNER JOIN @Subcategories AS subcategories
	ON [AdsInCategories].[CategoryId] = subcategories.CategoryId
	UNION
	SELECT ads.* 
	FROM [dbo].func_select_ad() AS ads
	INNER JOIN [AdsInCategories]
    ON [AdsInCategories].[AdId] = ads.[AdId]
	WHERE [AdsInCategories].CategoryId = @CategoryId

	SELECT  [AdId], ads.[Name], [Price], [CreationDate], [Kind], [State], 
			ads.[CityId] AS [LocationId], 
			[City].[Name] AS [City], 
			[Area].Name AS [Area], 
			[Country].Name AS [Country]
	FROM @Ads AS ads
	INNER JOIN [City]
	ON [City].CityId = ads.[CityId]
	INNER JOIN [Area]
	ON [Area].AreaId = [City].AreaId
	INNER JOIN [Country]
	ON [Country].CountryId = [Area].CountryId

	SELECT ads.[AdId], [Category].[CategoryId], [Category].[Name], [ParentId]
	FROM @Ads AS ads
	INNER JOIN [AdsInCategories]
	ON [AdsInCategories].AdId = ads.AdId
	INNER JOIN [Category]
	ON [Category].CategoryId = [AdsInCategories].CategoryId

	SELECT ads.[AdId], [Image].[ImageId], [Data], [Extension]
	FROM @Ads AS ads
	INNER JOIN [ImagesInAds]
	ON [ImagesInAds].AdId = ads.AdId
	INNER JOIN [Image]
	ON [Image].ImageId = [ImagesInAds].ImageId
END