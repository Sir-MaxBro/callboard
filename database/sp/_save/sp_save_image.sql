Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_image
(
    @ImageId INT,
    @Data VARBINARY(MAX), 
    @Extension NVARCHAR(50), 
    @AdId INT
)
AS BEGIN
	IF @ImageId <= 0
		BEGIN
			DECLARE @NewImageId TABLE ([ImageId] INT NOT NULL);

			INSERT INTO [dbo].[Image]([Data], [Extension])
			OUTPUT inserted.ImageId INTO @NewImageId
			VALUES (@Data, @Extension);

			SET @ImageId = (SELECT * FROM @NewImageId);

			INSERT INTO [dbo].ImagesInAds([AdId], [ImageId])
			VALUES (@AdId, @ImageId)
		END
	ELSE
		BEGIN
			UPDATE [Image]
			SET [Data] = @Data,
				[Extension] = @Extension
		END
END