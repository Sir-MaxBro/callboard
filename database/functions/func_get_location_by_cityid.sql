Use [callboardDB];
GO
CREATE FUNCTION [dbo].func_get_location_by_cityid (@CityId INT)
RETURNS @location TABLE
(
    [City] NVARCHAR(50),
    [Area] NVARCHAR(50),
    [Country] NVARCHAR(50)
)
AS BEGIN
    DECLARE @temp_table table ([City] NVARCHAR(50), [Area] NVARCHAR(50), [Country] NVARCHAR(50))
    
    INSERT INTO @temp_table 
    SELECT [City].[Name] AS [City], [Area].[Name] AS [Area], [Country].[Name] AS [Country]
    FROM [dbo].[City]
    INNER JOIN [dbo].[Area]
    ON [City].[AreaId] = [Area].[AreaId]
    INNER JOIN [dbo].[Country]
    ON [Area].[CountryId] = [Country].[CountryId]
    WHERE [City].[CityId] = @CityId

    INSERT INTO @location
    SELECT [City], [Area], [Country] FROM @temp_table

    RETURN
END