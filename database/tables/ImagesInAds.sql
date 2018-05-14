CREATE TABLE [callboard_db].[ImagesInAds]
(
    [ImageId] INT NOT NULL,
    [AdId] INT NOT NULL,

    PRIMARY KEY CLUSTERED ([ImageId] ASC, [AdId] ASC),
    FOREIGN KEY ([ImageId]) REFERENCES [callboard_db].[Image]([ImageId]),
    FOREIGN KEY ([AdId]) REFERENCES [callboard_db].[Ad]([AdId])
);
GO