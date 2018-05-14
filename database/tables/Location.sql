USE [callboardDB];
CREATE TABLE [dbo].[Location]
(
    [LocationId] INT IDENTITY(1, 1) NOT NULL,
    [CityId]      INT NOT NULL,
    [AreaId]      INT NOT NULL,
    [CountryId]   INT NOT NULL,
    [AddressLine] NVARCHAR(MAX) NULL,

    PRIMARY KEY CLUSTERED ([LocationId] ASC, [CityId] ASC, [AreaId] ASC, [CountryId] ASC),
    FOREIGN KEY ([CityId], [AreaId], [CountryId]) REFERENCES [dbo].[City]([CityId], [AreaId], [CountryId])
);
GO