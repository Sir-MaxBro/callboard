using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class AdRepository : IAdRepository
    {
        private Data::IAdRepository _repository;
        public AdRepository()
        {
            _repository = DataContainer.GetInstance<Data::IAdRepository>();
        }

        public IReadOnlyCollection<Ad> Items
        {
            get => _repository.Items;
        }

        public IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId)
        {
            return _repository.GetAdsByCategoryId(categoryId);
        }
    }
}
