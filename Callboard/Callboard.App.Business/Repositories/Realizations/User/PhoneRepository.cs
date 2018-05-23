using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class PhoneRepository : IPhoneRepository
    {
        private Data::IPhoneRepository _repository;
        public PhoneRepository()
        {
            _repository = DataContainer.GetInstance<Data::IPhoneRepository>();
        }

        public IReadOnlyCollection<Phone> GetPhonesByUserId(int userId)
        {
            return _repository.GetPhonesByUserId(userId);
        }
    }
}
