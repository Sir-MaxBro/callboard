USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_select_ad]
AS
(
    SELECT  [AdId], [Name], [Description], [Price], [CreationDate],
            [UserId], [LocationId],
            (SELECT [Type] FROM [dbo].[Kind] WHERE [Kind].[KindId] = [Ad].[KindId]) AS [Kind],
            (SELECT [Condition] FROM [dbo].[State] WHERE [State].[StateId] = [Ad].[StateId]) AS [State]
    FROM [dbo].[Ad]
);
GO