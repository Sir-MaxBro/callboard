USE [callboardDB];
CREATE TABLE [dbo].[Category]
(
    [CategoryId] INT NOT NULL,
    [Name] NVARCHAR(MAX) NOT NULL,

    PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);
GO