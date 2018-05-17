CREATE LOGIN max_bro WITH PASSWORD = '1111'
GO

Use [callboardDB];
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'max_bro')
BEGIN
    CREATE USER [max_bro] FOR LOGIN [max_bro]
    EXEC sp_addrolemember N'db_owner', N'max_bro'
END;
GO