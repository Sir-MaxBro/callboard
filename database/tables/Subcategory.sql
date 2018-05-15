USE [callboardDB];
CREATE TABLE [dbo].[Subcategory]
(
    [SubcategoryId] INT IDENTITY(1, 1) NOT NULL,
    [CategoryId] INT NOT NULL,
    [ParentCategoryId] INT NOT NULL,

    PRIMARY KEY CLUSTERED ([SubcategoryId] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category]([CategoryId]),
    FOREIGN KEY ([ParentCategoryId]) REFERENCES [dbo].[Category]([CategoryId])
);
GO