USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_state_by_id]
    @StateId INT
AS
(
    SELECT [StateId], [Condition]
    FROM [dbo].[State]
    WHERE [State].[StateId] = @StateId
);
GO