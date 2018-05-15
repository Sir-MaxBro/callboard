CREATE LOGIN maxbr WITH PASSWORD = 'maxbro2968';
GO

EXEC master..sp_addsrvrolemember @loginame = N'maxbr', @rolename = N'sysadmin'
GO