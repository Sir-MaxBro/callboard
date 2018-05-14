CREATE TABLE [callboardDB].[Area]
(
    [AreaId]    INT NOT NULL,
    [CountryId] INT NOT NULL,
    [Name]      NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([AreaId] ASC, [CountryId] ASC),
    FOREIGN KEY ([CountryId]) REFERENCES [callboardDB].[Country]([CountryId])
);
GO