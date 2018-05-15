USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_filter_ad_by_categoryid]
    @CategoryId INT
AS
(
    SELECT  [Ad].[AdId] as [AdId], [Name], [Description], [Price], [CreationDate],
            [UserId], [LocationId],
            (SELECT [Type] FROM [dbo].[Kind] WHERE [Kind].[KindId] = [Ad].[KindId]) AS [Kind],
            (SELECT [Condition] FROM [dbo].[State] WHERE [State].[StateId] = [Ad].[StateId]) AS [State]
    FROM [dbo].[Ad]
    INNER JOIN [AdsInCategories]
    ON [AdsInCategories].[AdId] = [Ad].[AdId]
    WHERE [AdsInCategories].[CategoryId] = @CategoryId
);
GO