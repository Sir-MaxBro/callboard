using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class ImageRepository : EntityRepository, IImageRepository
    {
        private const string TABLE_NAME = "Image";
        public ImageRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<Image> GetImagesByAdId(int adId)
        {
            IReadOnlyCollection<Image> images = base.GetEntities<Image>("selectByAdId", MapImage, adId);
            return images;
        }

        private Image MapImage(DbDataReader reader)
        {
            return new Image
            {
                AdId = Mapper.MapProperty<int>(reader, "AdId", base.GetName),
                Data = Mapper.MapProperty<byte[]>(reader, "Data", base.GetName),
                ImageId = Mapper.MapProperty<int>(reader, "ImageId", base.GetName),
                MimeType = Mapper.MapProperty<string>(reader, "MimeType", base.GetName)
            };
        }
    }
}
