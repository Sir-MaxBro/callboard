USE [callboardDB];
CREATE TABLE [dbo].[Category]
(
    [CategoryId] INT IDENTITY(1, 1) NOT NULL,
    [Name] NVARCHAR(MAX) NOT NULL,
    [ParentId] INT NULL

    PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);
GO