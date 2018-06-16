using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class KindService : IEntityService<Kind>
    {
        private IChecker _checker;
        private IRepository<Kind> _kindRepository;
        public KindService(IRepository<Kind> kindRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(kindRepository);
            _kindRepository = kindRepository;
        }

        public void Delete(int id)
        {
            _checker.CheckId(id);
            _kindRepository.Delete(id);
        }

        public IReadOnlyCollection<Kind> GetAll()
        {
            return _kindRepository.GetAll();
        }

        public Kind GetById(int id)
        {
            _checker.CheckId(id);
            return _kindRepository.GetById(id);
        }

        public void Save(Kind obj)
        {
            _checker.CheckForNull(obj);
            _kindRepository.Save(obj);
        }
    }
}