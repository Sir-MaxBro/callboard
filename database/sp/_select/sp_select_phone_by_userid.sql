USE [callboardDB];
GO
CREATE PROCEDURE [dbo].[sp_select_phone_by_userid]
    @UserId INT
AS
(
    SELECT [PhoneId], [Number]
    FROM [dbo].[Phone]
    WHERE [Phone].[UserId] = @UserId
);
GO