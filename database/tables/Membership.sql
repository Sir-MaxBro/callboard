USE [callboardDB];
CREATE TABLE [dbo].[Membership]
(
    [UserId] INT NOT NULL,
    [Login] NVARCHAR(MAX) NOT NULL,
    [Password] NVARCHAR(MAX) NOT NULL,

    PRIMARY KEY CLUSTERED ([UserId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([UserId])
);
GO