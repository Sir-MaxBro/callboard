CREATE TABLE [callboard_db].[Phone]
(
    [PhoneId] INT IDENTITY(1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    [Number] NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([PhoneId] ASC, [UserId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [callboard_db].[User](UserId)
);
GO