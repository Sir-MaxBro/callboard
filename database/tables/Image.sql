CREATE TABLE [callboard_db].[Image]
(
    [ImageId] INT IDENTITY(1, 1) NOT NULL,
    [Data] VARBINARY(MAX) NOT NULL,
    [MimeType] NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([ImageId] ASC)
);
GO