USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_area]
AS
(
    SELECT [AreaId], [Name]
    FROM [dbo].[Area]
);
GO