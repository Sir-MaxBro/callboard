USE [callboardDB];
CREATE TABLE [dbo].[City]
(
    [CityId]    INT IDENTITY(1, 1) NOT NULL,
    [AreaId]    INT NOT NULL,
    [Name]      NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([CityId] ASC, [AreaId] ASC),
    FOREIGN KEY ([AreaId]) REFERENCES [dbo].[Area]([AreaId])
);
GO