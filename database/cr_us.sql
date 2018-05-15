CREATE LOGIN WanidaBenshoof   
    WITH PASSWORD = 'my_password';  
GO
CREATE USER Wanida FOR LOGIN WanidaBenshoof   
    WITH DEFAULT_SCHEMA = sys;  
GO  