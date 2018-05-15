USE [callboardDB];
GO
CREATE LOGIN admin_max 
    WITH PASSWORD    = N'maxbro2968',
    CHECK_POLICY     = OFF,
    CHECK_EXPIRATION = OFF;
GO
EXEC sp_addsrvrolemember 
    @loginame = N'admin_max', 
    @rolename = N'sysadmin';