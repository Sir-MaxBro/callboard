USE [callboardDB];
CREATE TABLE [dbo].[User]
(
    [UserId] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(MAX) NOT NULL,
    [PhotoData]  VARBINARY(MAX) NULL,
    [PhotoExtension] NVARCHAR(50) NULL,

    PRIMARY KEY CLUSTERED ([UserId] ASC)
);
GO