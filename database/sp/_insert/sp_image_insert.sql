USE [callboardDB];
GO

CREATE PROCEDURE [dbo].[sp_image_insert]
(
    @Extension NVARCHAR(50),
    @CurrentPath NVARCHAR(MAX)
)
AS
BEGIN

Declare @sql nvarchar(max)
SET @sql = N'INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT ' + @Extension + ' AS [Extension], * FROM OPENROWSET(BULK ' + CONVERT(NVARCHAR(MAX), @CurrentPath) + ', SINGLE_BLOB) AS [Data]'
EXEC (@sql)

END
GO