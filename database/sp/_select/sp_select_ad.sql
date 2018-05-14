CREATE PROCEDURE [callboardDB].[sp_select_ad]
AS
(
    SELECT  [AdId], [Name], [Description], [Price], [CreationDate],
            [UserId], [LocationId],
            (SELECT [Type] FROM [callboardDB].[Kind] WHERE [Kind].[KindId] = [Ad].[KindId]) AS [Kind],
            (SELECT [Condition] FROM [callboardDB].[State] WHERE [State].[StateId] = [Ad].[StateId]) AS [State]
    FROM [callboardDB].[Ad]
);
GO