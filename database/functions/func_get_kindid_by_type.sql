Use [callboardDB];
GO
CREATE FUNCTION [dbo].func_get_kindid_by_type (@Type NVARCHAR(50))
RETURNS INT
AS BEGIN
    DECLARE @KindId INT
    
    SELECT @KindId = [Kind].[KindId]
    FROM [Kind] 
    WHERE [Kind].[Type] = @Type

    RETURN @KindId
END