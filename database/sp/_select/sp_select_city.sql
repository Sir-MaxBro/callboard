USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_city]
AS
(
    SELECT [CityId], [Name]  
    FROM [dbo].[City]
);
GO