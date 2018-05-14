CREATE TABLE [callboardDB].[Ad]
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
    FOREIGN KEY ([UserId]) REFERENCES [callboardDB].[User]([UserId]),
    FOREIGN KEY ([LocationId]) REFERENCES [callboardDB].[Location]([LocationId]),
    FOREIGN KEY ([KindId]) REFERENCES [callboardDB].[Kind]([KindId]),
    FOREIGN KEY ([StateId]) REFERENCES [callboardDB].[State]([StateId])
);
GO