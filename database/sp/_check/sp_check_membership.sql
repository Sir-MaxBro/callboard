USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_check_membership]
    @Login NVARCHAR(MAX),
    @Password NVARCHAR(MAX)
AS
BEGIN
IF EXISTS (SELECT [UserId] FROM [dbo].[Membership] WHERE [Login] = @Login AND [Password] = @Password)
    BEGIN
            RETURN CAST(1 AS BIT)
    END
ELSE
    BEGIN
            RETURN CAST(0 AS BIT)
    END   
END