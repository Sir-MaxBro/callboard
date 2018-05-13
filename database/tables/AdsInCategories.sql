CREATE TABLE [AdsInCategories]
(
  [AdId]       INT NOT NULL,
  [CategoryId] INT NOT NULL,

  PRIMARY KEY CLUSTERED ([AdId] ASC, [CategoryId] ASC),
  FOREIGN KEY ([AdId]) REFERENCES [Ad]([AdId]),
  FOREIGN KEY ([CategoryId]) REFERENCES [Category]([CategoryId])
);
GO