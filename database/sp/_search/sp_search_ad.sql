USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_search_ad] 
	@Name NVARCHAR(MAX) NULL = '',
	@State NVARCHAR(50) NULL = '',
	@Kind NVARCHAR(50) NULL = '',
	@CountryId INT NULL = 0,
	@AreaId INT NULL = 0,
	@CityId INT NULL = 0,
	@MinPrice DECIMAL(18, 2) NULL = 0,
	@MaxPrice DECIMAL(18, 2) NULL = 999999999999,
	@Categories [dbo].CategoriesTable NULL READONLY
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

	DECLARE @dataCount int = (SELECT COUNT(1) FROM @Categories)

	INSERT INTO @Ads
	SELECT ads.* 
	FROM [dbo].func_select_ad() AS ads
	WHERE (
		(@dataCount = 0) OR (ads.[AdId] IN (
			SELECT [AdsInCategories].[AdId]
			FROM @Categories AS categories
			INNER JOIN [dbo].[AdsInCategories]
			ON categories.[CategoryId] = [AdsInCategories].[CategoryId]
			)
		)
	)
	AND ads.Name LIKE '%' + ISNULL(@Name, '') + '%'
	AND ads.[State] = IIF(@State = '', ads.[State], @State)
	AND ads.[Kind] = IIF(@Kind = '', ads.[Kind], @Kind)
	AND ads.Price BETWEEN @MinPrice AND iif(@MaxPrice = 0, 999999999999, @MaxPrice)
	AND ads.CityId = IIF(@CityId = 0, ads.CityId, @CityId)

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
	WHERE [Area].AreaId = IIF(@AreaId = 0, [Area].AreaId, @AreaId)
	AND [Country].CountryId = IIF(@CountryId = 0, [Country].CountryId, @CountryId)

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
GO