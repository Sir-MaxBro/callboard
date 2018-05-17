USE [callboardDB];
CREATE TABLE [dbo].[AdDetails]
(
    [AdId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [AddressLine] NVARCHAR(MAX) NULL,

    PRIMARY KEY CLUSTERED ([AdId] ASC),
    FOREIGN KEY ([AdId]) REFERENCES [dbo].[Ad]([AdId]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([UserId])
);
GO