USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_ad_by_categoryid]
    @CategoryId INT
AS
(
    SELECT ads.*
    FROM [dbo].func_select_ad() AS ads
    INNER JOIN [AdsInCategories]
    ON [AdsInCategories].[AdId] = ads.[AdId]
    WHERE [AdsInCategories].[CategoryId] = @CategoryId
);
GO