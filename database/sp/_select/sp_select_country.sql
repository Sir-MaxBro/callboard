USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_country]
AS
(
    SELECT [CountryId], [Name]  
    FROM [dbo].[Country]
);
GO