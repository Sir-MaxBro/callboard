USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_country_by_id]
    @CountryId int 
AS
(
    SELECT [CountryId], [Name]
    FROM [dbo].[Country]
    WHERE [CountryId] = @CountryId
);
GO