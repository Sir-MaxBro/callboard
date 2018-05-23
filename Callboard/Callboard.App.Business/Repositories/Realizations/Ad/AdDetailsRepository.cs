using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class AdDetailsRepository : IAdDetailsRepository
    {
        private Data::IAdDetailsRepository _repository;
        public AdDetailsRepository()
        {
            _repository = DataContainer.GetInstance<Data::IAdDetailsRepository>();
        }

        public AdDetails GetAdDetails(int adId)
        {
            return _repository.GetAdDetails(adId);
        }
    }
}
