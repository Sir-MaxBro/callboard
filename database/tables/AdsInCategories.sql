CREATE TABLE [callboard_db].[AdsInCategories]
(
  [AdId]       INT NOT NULL,
  [CategoryId] INT NOT NULL,

  PRIMARY KEY CLUSTERED ([AdId] ASC, [CategoryId] ASC),
  FOREIGN KEY ([AdId]) REFERENCES [callboard_db].[Ad]([AdId]),
  FOREIGN KEY ([CategoryId]) REFERENCES [callboard_db].[Category]([CategoryId])
);
GO