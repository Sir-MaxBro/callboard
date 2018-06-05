USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_role]
AS
(
    SELECT [RoleId], [Name]
    FROM [dbo].[Role]
);
GO