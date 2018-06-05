USE [callboardDB]
GO
CREATE PROCEDURE [dbo].[sp_get_kind_by_id]
    @KindId INT
AS
(
    SELECT [KindId], [Type]
    FROM [dbo].[Kind]
    WHERE [Kind].[KindId] = @KindId
);
GO