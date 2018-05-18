USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_addetails_by_adid]
    @AdId INT
AS
(
    SELECT  ads.*, [UserId], [Description], [AddressLine]
    FROM [dbo].func_select_ad() AS ads
    INNER JOIN [dbo].[AdDetails]
    ON [AdDetails].[AdId] = ads.[AdId]
    WHERE ads.[AdId] = @AdId
);
GO