CREATE TABLE [callboard_db].[UsersInRoles]
(
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [callboard_db].[User]([UserId]),
    FOREIGN KEY ([RoleId]) REFERENCES [callboard_db].[Role]([RoleId])
)