USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_select_state]
AS
BEGIN
    SELECT [StateId], [Condition]
    FROM [dbo].[State]
END
GO