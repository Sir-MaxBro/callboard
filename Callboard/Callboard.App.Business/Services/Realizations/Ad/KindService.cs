using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Results;
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

        public IResult<Kind> Delete(int id)
        {
            _checker.CheckId(id);
            return _kindRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<Kind>> GetAll()
        {
            return _kindRepository.GetAll();
        }

        public IResult<Kind> GetById(int id)
        {
            _checker.CheckId(id);
            return _kindRepository.GetById(id);
        }

        public IResult<Kind> Save(Kind obj)
        {
            _checker.CheckForNull(obj);
            return _kindRepository.Save(obj);
        }
    }
}