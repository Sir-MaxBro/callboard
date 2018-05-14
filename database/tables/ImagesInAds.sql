CREATE TABLE [ImagesInAds]
(
    [ImageId] INT NOT NULL,
    [AdId] INT NOT NULL,

    PRIMARY KEY CLUSTERED ([ImageId] ASC, [AdId] ASC),
    FOREIGN KEY ([ImageId]) REFERENCES [Image]([ImageId]),
    FOREIGN KEY ([AdId]) REFERENCES [Ad]([AdId])
);
GO