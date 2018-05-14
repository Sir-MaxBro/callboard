CREATE TABLE [callboardDB].[City]
(
    [CityId]    INT NOT NULL,
    [AreaId]    INT NOT NULL,
    [CountryId] INT NOT NULL,
    [Name]      NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([CityId] ASC, [AreaId] ASC, [CountryId] ASC),
    FOREIGN KEY ([AreaId], [CountryId]) REFERENCES [callboardDB].[Area]([AreaId], [CountryId])
);
GO