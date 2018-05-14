USE [callboardDB];
CREATE TABLE [dbo].[ImagesInAds]
(
    [ImageId] INT NOT NULL,
    [AdId] INT NOT NULL,

    PRIMARY KEY CLUSTERED ([ImageId] ASC, [AdId] ASC),
    FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Image]([ImageId]),
    FOREIGN KEY ([AdId]) REFERENCES [dbo].[Ad]([AdId])
);
GO