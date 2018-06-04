USE [callboardDB];
CREATE TABLE [dbo].[Mail]
(
    [MailId] INT IDENTITY(1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    [Email] NVARCHAR(MAX) NOT NULL,
    
    PRIMARY KEY CLUSTERED ([MailId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([UserId])
);
GO