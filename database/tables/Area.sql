USE [callboardDB];
CREATE TABLE [dbo].[Area]
(
    [AreaId]    INT NOT NULL,
    [CountryId] INT NOT NULL,
    [Name]      NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([AreaId] ASC, [CountryId] ASC),
    FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country]([CountryId])
);
GO