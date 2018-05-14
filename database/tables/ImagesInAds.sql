CREATE TABLE [callboardDB].[ImagesInAds]
(
    [ImageId] INT NOT NULL,
    [AdId] INT NOT NULL,

    PRIMARY KEY CLUSTERED ([ImageId] ASC, [AdId] ASC),
    FOREIGN KEY ([ImageId]) REFERENCES [callboardDB].[Image]([ImageId]),
    FOREIGN KEY ([AdId]) REFERENCES [callboardDB].[Ad]([AdId])
);
GO