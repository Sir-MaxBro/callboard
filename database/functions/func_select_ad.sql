Use [callboardDB];
GO
CREATE FUNCTION [dbo].func_select_ad ()
RETURNS @ads TABLE 
(
    [AdId] INT,
    [Name] NVARCHAR(MAX), 
    [Price] DECIMAL(18, 2), 
    [CreationDate] DATETIME, 
    [CityId] INT,
    [Kind] NVARCHAR(50),
    [State] NVARCHAR(50)
)
AS BEGIN
    
    INSERT INTO @ads
    SELECT [AdId], [Name], [Price], [CreationDate], [CityId],
            [dbo].func_get_kind_by_kindid([Ad].[KindId]) AS [Kind],
            [dbo].func_get_state_by_stateid([Ad].[StateId]) AS [State]
    FROM [dbo].[Ad]

    RETURN
END