USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_area_by_countryid]
    @CountryId int 
AS
(
    SELECT [AreaId], [Name]
    FROM [dbo].[Area]
    WHERE [CountryId] = @CountryId
);
GO