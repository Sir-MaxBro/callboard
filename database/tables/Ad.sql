USE [callboardDB];
CREATE TABLE [dbo].[Ad]
(
    [AdId] INT IDENTITY(1, 1) NOT NULL,
    [KindId] INT NULL,
    [StateId] INT NULL,
    [CityId] INT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [Price] DECIMAL(18, 2) NOT NULL,
    [CreationDate] DATETIME NOT NULL,

    PRIMARY KEY CLUSTERED ([AdId] ASC),
    FOREIGN KEY ([KindId]) REFERENCES [dbo].[Kind]([KindId]),
    FOREIGN KEY ([StateId]) REFERENCES [dbo].[State]([StateId]),
    FOREIGN KEY ([CityId]) REFERENCES [dbo].[City]([CityId])
);
GO