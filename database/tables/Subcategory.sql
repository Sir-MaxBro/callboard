CREATE TABLE [callboard_db].[Subcategory]
(
    [SubcategoryId] INT IDENTITY(1, 1) NOT NULL,
    [CategoryId] INT NOT NULL,
    [ParentCategoryId] INT NOT NULL,

    PRIMARY KEY CLUSTERED ([SubcategoryInCategoriesId] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [callboard_db].[Category]([CategoryId]),
    FOREIGN KEY ([ParentCategoryId]) REFERENCES [callboard_db].[Category]([CategoryId])
);
GO