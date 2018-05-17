USE [callboardDB];
CREATE TABLE [dbo].[Kind]
(
    [KindId] INT IDENTITY(1, 1) NOT NULL,
    [Type]   NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([KindId] ASC)
);
GO