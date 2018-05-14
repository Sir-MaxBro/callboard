CREATE TABLE [Ad]
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
    FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]),
    FOREIGN KEY ([LocationId]) REFERENCES [Location]([LocationId]),
    FOREIGN KEY ([KindId]) REFERENCES [Kind]([KindId]),
    FOREIGN KEY ([StateId]) REFERENCES [State]([StateId])
);
GO