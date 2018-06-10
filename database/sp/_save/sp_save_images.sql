Use [callboardDB];
GO
CREATE PROCEDURE [dbo].sp_save_images
(
    @Images [dbo].ImagesTable READONLY,
    @AdId INT
)
AS BEGIN
	EXEC [dbo].[sp_delete_images_by_adid] @AdId
	
	DECLARE @cur_ImageId INT
	DECLARE @cur_Data VARBINARY(MAX)
	DECLARE @cur_Extension NVARCHAR(50)

	DECLARE image_cursor CURSOR LOCAL for
		SELECT [ImageId], [Data], [Extension] FROM @Images
	OPEN image_cursor

	FETCH NEXT FROM image_cursor INTO @cur_ImageId, @cur_Data, @cur_Extension

	WHILE @@FETCH_STATUS = 0 BEGIN
		EXEC [dbo].sp_save_image @cur_ImageId, @cur_Data, @cur_Extension, @AdId
		FETCH NEXT FROM image_cursor INTO @cur_ImageId, @cur_Data, @cur_Extension
	END
	CLOSE image_cursor
	DEALLOCATE image_cursor
END