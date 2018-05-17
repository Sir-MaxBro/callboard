USE [callboardDB];
CREATE TABLE [dbo].[Mail]
(
    [EmailId] INT IDENTITY(1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    [Email] NVARCHAR(MAX) NOT NULL,
    
    PRIMARY KEY CLUSTERED ([EmailId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([UserId])
);
GO