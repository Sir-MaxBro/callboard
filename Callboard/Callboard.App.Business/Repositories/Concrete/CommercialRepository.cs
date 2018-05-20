using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities.Commercial;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class CommercialRepository : ICommercialRepository
    {
        private Data::ICommercialRepository _repository;
        public CommercialRepository()
        {
            _repository = DataContainer.GetInstance<Data::ICommercialRepository>();
        }

        public IReadOnlyCollection<Commercial> Items => _repository.Items;
    }
}
