Use [callboardDB];
GO
CREATE FUNCTION [dbo].func_get_stateid_by_condition (@Condition NVARCHAR(50))
RETURNS INT
AS BEGIN
    DECLARE @StateId INT
    
    SELECT @StateId = [State].[StateId]
    FROM [State] 
    WHERE [State].[Condition] = @Condition

    RETURN @StateId
END