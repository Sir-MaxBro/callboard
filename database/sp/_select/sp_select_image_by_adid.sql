USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_image_by_adid]
    @AdId INT
AS
(
    SELECT [Image].[ImageId] AS [ImageId], [Data], [MimeType], [ImagesInAds].[AdId] AS [AdId]
    FROM [dbo].[Image]
    INNER JOIN [dbo].[ImagesInAds]
    ON [Image].[ImageId] = [ImagesInAds].[ImageId]
    WHERE [ImagesInAds].[AdId] = @AdId
);
GO
