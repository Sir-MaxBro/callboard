CREATE TABLE [Subcategory]
(
    [SubcategoryId] INT IDENTITY(1, 1) NOT NULL,
    [CategoryId] INT NOT NULL,
    [ParentCategoryId] INT NOT NULL,

    PRIMARY KEY CLUSTERED ([SubcategoryInCategoriesId] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [Category]([CategoryId]),
    FOREIGN KEY ([ParentCategoryId]) REFERENCES [Category]([CategoryId])
);
GO