USE [callboardDB];
CREATE TABLE [dbo].[Ad]
(
    [AdId] INT IDENTITY(1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    [LocationId] INT NULL,
    [KindId] INT NULL,
    [StateId] INT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Price] DECIMAL(18, 2) NOT NULL,
    [CreationDate] DATETIME NOT NULL,

    PRIMARY KEY CLUSTERED ([AdId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([UserId]),
    FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location]([LocationId]),
    FOREIGN KEY ([KindId]) REFERENCES [dbo].[Kind]([KindId]),
    FOREIGN KEY ([StateId]) REFERENCES [dbo].[State]([StateId])
);
GO