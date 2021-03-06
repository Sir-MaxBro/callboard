USE MASTER;
GO

CREATE LOGIN callboard_admin 
    WITH PASSWORD = N'1D2F2f3E3asd', 
    DEFAULT_DATABASE = MASTER, 
    DEFAULT_LANGUAGE = US_ENGLISH;
GO

ALTER LOGIN callboard_admin ENABLE;
GO

ALTER SERVER ROLE  sysadmin  ADD MEMBER callboard_admin;  

GRANT CONTROL SERVER TO callboard_admin;