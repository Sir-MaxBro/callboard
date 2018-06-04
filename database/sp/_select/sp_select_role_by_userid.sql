USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_select_role_by_userid]
    @UserId INT
AS
(
    SELECT [Role].[RoleId] AS [RoleId], [Name]
    FROM [dbo].[Role]
    INNER JOIN [dbo].[UsersInRoles]
    ON [Role].[RoleId] = [UsersInRoles].[RoleId]
    WHERE [UsersInRoles].[UserId] = @UserId
);
GO