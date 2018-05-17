Use [callboardDB];
GO
CREATE FUNCTION [dbo].func_get_kind_by_kindid (@KindId INT)
RETURNS NVARCHAR(50)
AS BEGIN
    DECLARE @type NVARCHAR(50)
    
    SELECT @type = [Kind].[Type]
    FROM [Kind] 
    WHERE [Kind].[KindId] = @KindId

    RETURN @type
END