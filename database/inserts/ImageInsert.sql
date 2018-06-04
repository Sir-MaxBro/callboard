USE [callboardDB];
INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT 'jpg' AS [Extension], * FROM OPENROWSET(BULK N'E:\_github\_epam\callboard\database\images\amazon.jpg', SINGLE_BLOB) AS [Data]
INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT 'png' AS [Extension], * FROM OPENROWSET(BULK N'E:\_github\_epam\callboard\database\images\breakfast.png', SINGLE_BLOB) AS [Data]
INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT 'jpg' AS [Extension], * FROM OPENROWSET(BULK N'E:\_github\_epam\callboard\database\images\burger.jpg', SINGLE_BLOB) AS [Data]
INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT 'jpg' AS [Extension], * FROM OPENROWSET(BULK N'E:\_github\_epam\callboard\database\images\christmas.jpg', SINGLE_BLOB) AS [Data]
INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT 'png' AS [Extension], * FROM OPENROWSET(BULK N'E:\_github\_epam\callboard\database\images\coffee.png', SINGLE_BLOB) AS [Data]
INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT 'jpg' AS [Extension], * FROM OPENROWSET(BULK N'E:\_github\_epam\callboard\database\images\cola.jpg', SINGLE_BLOB) AS [Data]
INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT 'png' AS [Extension], * FROM OPENROWSET(BULK N'E:\_github\_epam\callboard\database\images\gatorade.png', SINGLE_BLOB) AS [Data]
INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT 'jpg' AS [Extension], * FROM OPENROWSET(BULK N'E:\_github\_epam\callboard\database\images\ketchup.jpg', SINGLE_BLOB) AS [Data]
INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT 'jpg' AS [Extension], * FROM OPENROWSET(BULK N'E:\_github\_epam\callboard\database\images\nike.jpg', SINGLE_BLOB) AS [Data]
INSERT INTO [dbo].[Image]([Extension], [Data]) SELECT 'jpg' AS [Extension], * FROM OPENROWSET(BULK N'E:\_github\_epam\callboard\database\images\nike2.jpg', SINGLE_BLOB) AS [Data]
GO