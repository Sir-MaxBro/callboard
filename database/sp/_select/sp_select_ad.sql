CREATE PROCEDURE [sp_select_ad]
AS
(
    SELECT  [AdId], [Name], [Description], [Price], [CreationDate],
            [UserId], [LocationId],
            (SELECT [Type] FROM [Kind] WHERE [Kind].[KindId] = [Ad].[KindId]) AS [Kind],
            (SELECT [Condition] FROM [State] WHERE [State].[StateId] = [Ad].[StateId]) AS [State]
    FROM [Ad]
);
GO