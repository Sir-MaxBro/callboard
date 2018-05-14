CREATE TABLE [callboardDB].[Mail]
(
    [EmailId] INT IDENTITY(1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    [Email] NVARCHAR(MAX) NOT NULL,
    
    PRIMARY KEY CLUSTERED ([EmailId] ASC, [UserId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [callboardDB].[User]([UserId])
);
GO