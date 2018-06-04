Use [callboardDB];
GO
CREATE TYPE dbo.ImagesTable AS TABLE ([ImageId] INT, [Data] VARBINARY(MAX), [Extension] NVARCHAR(50));