USE [callboardDB];
CREATE TABLE [dbo].[State]
(
    [StateId]   INT NOT NULL,
    [Condition] NVARCHAR(50) NOT NULL,

    PRIMARY KEY CLUSTERED ([StateId] ASC)
);
GO