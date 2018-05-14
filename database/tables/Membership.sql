CREATE TABLE [callboard_db].[Membership]
(
    [MembershipId] INT IDENTITY(1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    [Login] NVARCHAR(MAX) NOT NULL,
    [Password] NVARCHAR(MAX) NOT NULL,

    PRIMARY KEY CLUSTERED ([MembershipId] ASC, [UserId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [callboard_db].[User]([UserId])
);
GO