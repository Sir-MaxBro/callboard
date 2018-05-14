CREATE TABLE [callboardDB].[AdsInCategories]
(
  [AdId]       INT NOT NULL,
  [CategoryId] INT NOT NULL,

  PRIMARY KEY CLUSTERED ([AdId] ASC, [CategoryId] ASC),
  FOREIGN KEY ([AdId]) REFERENCES [callboardDB].[Ad]([AdId]),
  FOREIGN KEY ([CategoryId]) REFERENCES [callboardDB].[Category]([CategoryId])
);
GO