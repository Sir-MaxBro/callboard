CREATE PROCEDURE [callboard_db].[sp_select_ad]
AS
(
    SELECT  [AdId], [Name], [Description], [Price], [CreationDate],
            [UserId], [LocationId],
            (SELECT [Type] FROM [callboard_db].[Kind] WHERE [Kind].[KindId] = [Ad].[KindId]) AS [Kind],
            (SELECT [Condition] FROM [callboard_db].[State] WHERE [State].[StateId] = [Ad].[StateId]) AS [State]
    FROM [callboard_db].[Ad]
);
GO