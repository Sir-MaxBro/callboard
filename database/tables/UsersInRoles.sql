USE [callboardDB];
CREATE TABLE [dbo].[UsersInRoles]
(
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([UserId]),
    FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role]([RoleId])
)