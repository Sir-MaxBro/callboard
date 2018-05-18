USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_ad]
AS
(
    SELECT  ads.*
    FROM [dbo].func_select_ad() AS ads
);
GO