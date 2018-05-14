CREATE TABLE [callboardDB].[UsersInRoles]
(
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [callboardDB].[User]([UserId]),
    FOREIGN KEY ([RoleId]) REFERENCES [callboardDB].[Role]([RoleId])
)