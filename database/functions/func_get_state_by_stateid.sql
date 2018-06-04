Use [callboardDB];
GO
CREATE FUNCTION [dbo].func_get_state_by_stateid (@StateId INT)
RETURNS NVARCHAR(50)
AS BEGIN
    DECLARE @state NVARCHAR(50)
    
    SELECT @state = [State].[Condition]
    FROM [State] 
    WHERE [State].[StateId] = @StateId

    RETURN @state
END