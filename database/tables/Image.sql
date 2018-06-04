USE [callboardDB];
CREATE TABLE [dbo].[Image]
(
    [ImageId] INT IDENTITY(1, 1) NOT NULL,
    [Data] VARBINARY(MAX) NOT NULL,
    [Extension] NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([ImageId] ASC)
);
GO