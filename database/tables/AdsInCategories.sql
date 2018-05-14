USE [callboardDB];
CREATE TABLE [dbo].[AdsInCategories]
(
  [AdId]       INT NOT NULL,
  [CategoryId] INT NOT NULL,

  PRIMARY KEY CLUSTERED ([AdId] ASC, [CategoryId] ASC),
  FOREIGN KEY ([AdId]) REFERENCES [dbo].[Ad]([AdId]),
  FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category]([CategoryId])
);
GO