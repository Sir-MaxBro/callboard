CREATE TABLE [SubcategoryInCategories]
(
    [SubcategoryInCategoriesId] INT IDENTITY(1, 1) NOT NULL,
    [CategoryId] INT NOT NULL,
    [SubcategoryId] INT NOT NULL,

    PRIMARY KEY CLUSTERED ([SubcategoryInCategoriesId] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [Category]([CategoryId]),
    FOREIGN KEY ([SubcategoryId]) REFERENCES [Category]([CategoryId])
);
GO