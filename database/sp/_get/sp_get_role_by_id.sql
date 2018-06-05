USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_role_by_id]
    @RoleId INT
AS
(
    SELECT [RoleId], [Name]
    FROM [dbo].[Role]
    WHERE [Role].[RoleId] = @RoleId
);
GO