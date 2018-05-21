using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class ImageRepository : IImageRepository
    {
        private Data::IImageRepository _repository;
        public ImageRepository()
        {
            _repository = DataContainer.GetInstance<Data::IImageRepository>();
        }

        public IReadOnlyCollection<Image> Items
        {
            get => _repository.Items;
        }

        public IReadOnlyCollection<Image> GetImagesByAdId(int adId)
        {
            return _repository.GetImagesByAdId(adId);
        }
    }
}
