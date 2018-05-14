CREATE TABLE [callboard_db].[Area]
(
    [AreaId]    INT NOT NULL,
    [CountryId] INT NOT NULL,
    [Name]      NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([AreaId] ASC, [CountryId] ASC),
    FOREIGN KEY ([CountryId]) REFERENCES [callboard_db].[Country]([CountryId])
);
GO