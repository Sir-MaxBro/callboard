USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_addetails_by_adid]
    @AdId INT
AS
(
    SELECT  [Ad].[AdId] AS [AdId], [Name], [Price], [CreationDate], [CityId],
            [dbo].func_get_kind_by_kindid([Ad].[KindId]) AS [Kind],
            [dbo].func_get_state_by_stateid([Ad].[StateId]) AS [State],
            [UserId], [Description], [AddressLine]
    FROM [dbo].[Ad]
    INNER JOIN [dbo].[AdDetails]
    ON [AdDetails].[AdId] = [Ad].[AdId]
    WHERE [Ad].[AdId] = @AdId
);
GO