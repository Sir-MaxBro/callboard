USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_ad]
AS
(
    SELECT  [AdId], [Name], [Price], [CreationDate], [CityId],
            [dbo].func_get_kind_by_kindid([Ad].[KindId]) AS [Kind],
            [dbo].func_get_state_by_stateid([Ad].[StateId]) AS [State]
    FROM [dbo].[Ad]
);
GO