USE [callboardDB];
CREATE TABLE [dbo].[Area]
(
    [AreaId]    INT IDENTITY(1, 1) NOT NULL,
    [CountryId] INT NOT NULL,
    [Name]      NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([AreaId] ASC),
    FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country]([CountryId])
);
GO