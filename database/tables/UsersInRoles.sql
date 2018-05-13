CREATE TABLE [UsersInRoles]
(
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]),
    FOREIGN KEY ([RoleId]) REFERENCES [Role]([RoleId])
)