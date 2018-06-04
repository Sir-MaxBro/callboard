USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_select_kind]
AS
BEGIN
    SELECT [KindId], [Type]
    FROM [dbo].[Kind]
END
GO