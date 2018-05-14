CREATE TABLE [callboardDB].[Subcategory]
(
    [SubcategoryId] INT IDENTITY(1, 1) NOT NULL,
    [CategoryId] INT NOT NULL,
    [ParentCategoryId] INT NOT NULL,

    PRIMARY KEY CLUSTERED ([SubcategoryInCategoriesId] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [callboardDB].[Category]([CategoryId]),
    FOREIGN KEY ([ParentCategoryId]) REFERENCES [callboardDB].[Category]([CategoryId])
);
GO