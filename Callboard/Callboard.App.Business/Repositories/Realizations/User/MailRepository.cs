using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class MailRepository : IMailRepository
    {
        private Data::IMailRepository _repository;
        public MailRepository()
        {
            _repository = DataContainer.GetInstance<Data::IMailRepository>();
        }

        public IReadOnlyCollection<Mail> GetMailsByUserId(int userId)
        {
            return _repository.GetMailsByUserId(userId);
        }
    }
}
